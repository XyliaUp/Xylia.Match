using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

using HZH_Controls;

using Xylia.bns.Modules.DataFormat.Analyse;
using Xylia.bns.Modules.DataFormat.Analyse.DeSerialize;
using Xylia.bns.Modules.DataFormat.Analyse.Enums;
using Xylia.bns.Modules.DataFormat.Analyse.Output;
using Xylia.bns.Modules.DataFormat.Bin;
using Xylia.bns.Modules.DataFormat.Bin.Entity.BDAT;
using Xylia.Extension;

using Xylia.Preview.Common.Interface;
using Xylia.Preview.Common.Interface.RecordAttribute;
using Xylia.Preview.Properties;
using Xylia.Preview.Properties.AnalyseSection;


namespace Xylia.Preview.Data
{
	/// <summary>
	/// 数据表
	/// </summary>
	public class DataTable<T> : IEnumerable<T>, IEnumerable where T : IRecord, new()
	{
		#region 字段
		/// <summary>
		/// 公共读取属性
		/// </summary>
		public virtual bool PublicSet { get; set; } = true;

		/// <summary>
		/// 是否显示调试信息
		/// </summary>
		internal virtual bool ShowDebugInfo => true;




		public string DefaultPath;

		public string ResFilePath
		{
			get
			{
				//获取相对路径
				var RelativeFilePath = DefaultPath is null ? typeof(T).Name : DefaultPath?.Trim();

				string IPath = null;
				bool Success = false;

				//逐次查询
				if (!Success) Success = VaildPath(RelativeFilePath, out IPath);
				if (!Success) Success = VaildPath(RelativeFilePath + ".xml", out IPath);
				if (!Success) Success = VaildPath(RelativeFilePath + "Data.xml", out IPath);

				//if (!Success) Console.WriteLine("配置文件不存在: " + RelativeFilePath);
				return IPath;
			}
		}

		/// <summary>
		/// 路径验证
		/// </summary>
		/// <returns></returns>
		public bool VaildPath(string Path, out string PathCopy)
		{
			PathCopy = CommonPath.WorkingDirectory + @"\" + Path;

			//判断是否存在测试模式文件
			if (true)
			{
				string TempPath = System.IO.Path.GetDirectoryName(PathCopy) + @"\" +
					   System.IO.Path.GetFileNameWithoutExtension(PathCopy) + "_test" +
					   System.IO.Path.GetExtension(PathCopy);

				if (File.Exists(TempPath))
				{
					Console.WriteLine("目前读取的是测试用文件");

					PathCopy = TempPath;
					return true;
				}
			}

			return File.Exists(PathCopy);
		}
		#endregion

		#region 数据处理
		/// <summary>
		/// 正在加载状态中
		/// </summary>
		public bool InLoading = false;

		/// <summary>
		/// 判断是否有数据
		/// </summary>
		public virtual bool HasData => !InLoading && this.data != null;


		private Lazy<T>[] data;

		protected Lazy<T>[] Data
		{
			set => this.data = value;
			get
			{
				if (!this.HasData) this.Load();

				return this.data;
			}
		}


		protected readonly Hashtable ht_alias = new(StringComparer.Create(CultureInfo.InvariantCulture, true));
		protected readonly Hashtable ht_id = new();

		/// <summary>
		/// 错误配置路径
		/// </summary>

		private readonly List<string> ErrorConfigPath = new();
		#endregion



		#region 加载方法
		protected virtual bool LoadFromGame => CommonPath.DataLoadMode;

		/// <summary>
		/// 配置内容
		/// </summary>
		protected virtual string ConfigContent => null;

		BDAT_LIST ListData;

		DeSerializer DeSerializer;

		TableInfo TableInfo;



		/// <summary>
		/// 尝试载入数据
		/// 用于需要事先载入数据的场景
		/// </summary>
		public void TryLoad() => this.Load();

		/// <summary>
		/// 加载资源
		/// </summary>
		/// <param name="Path"></param>
		/// <param name="Reload">指示在存在数据时，是否可以重新加载</param>
		protected void Load(bool Reload = false, string Path = null)
		{
			#region 初始化
			//如果是设计器模式，则不进行处理
			if (ControlHelper.IsDesignMode) return;

			//如果正在加载状态，等待到数据加载完成
			if (this.InLoading)
			{
				//等待到加载完成，所以要注意这个等待标志值不能发生异常
				//可能的异常原因：结束后不解除标志、在同一线程上多次请求加载
				while (this.InLoading) Thread.Sleep(100);
				return;
			}

			//如果有数据且并非要求重载，返回
			if (this.data != null && this.data.Length > 0 && !Reload) return;
			#endregion


			//进入加载状态
			this.InLoading = true;
			this.data = null;

			lock (this)
			{
				var task = new Task(() =>
				{
					try
					{
						if (!LoadFromGame) this.LoadXml(Path);
						else this.LoadGame();
					}
					catch (Exception ex)
					{
						//载入失败的处理
						this.data = Array.Empty<Lazy<T>>();
						this.FullLoad = true;

						Trace.WriteLine($"[{ DateTime.Now }] 加载失败: { Path ?? typeof(T).Name } -> {ex}");
					}

					//资源清理
					InLoading = false;
				});

				task.Start();
				task.Wait();
			}
		}


		/// <summary>
		/// 加载外部配置文件
		/// </summary>
		/// <param name="Path"></param>
		private void LoadXml(string Path)
		{
			#region 路径判断
			if (string.IsNullOrWhiteSpace(Path)) Path = ResFilePath;

			if (!File.Exists(Path))
			{
				//限制配置文件不存在提示仅首次提示
				if (!ErrorConfigPath.Contains(Path))
				{
					ErrorConfigPath.Add(Path);
					Trace.WriteLine($"路径 { Path } 不存在");
				}

				//防止出现异常
				this.data = Array.Empty<Lazy<T>>();
				this.InLoading = false;
				return;
			}

			var FileName = System.IO.Path.GetFileNameWithoutExtension(Path);
			#endregion

			#region 载入数据
			var xElements = (from ele in XElement.Load(Path).Elements() select ele).ToArray();

			this.data = new Lazy<T>[xElements.Length];
			for (var x = 0; x < this.data.Length; x++)
			{
				int CurIndex = x;
				var CurElement = xElements[x];
				this.data[x] = new Lazy<T>(() =>
				{
					//实例化对象
					var Obejct = new T()
					{
						Index = CurIndex,
						Attributes = new XElementData(CurElement),
					};

					//向成员赋值
					if (this.PublicSet)
					{
						foreach (var Attr in CurElement.Attributes())
							Obejct.SetMember(Attr.Name.LocalName, Attr.Value, true, ShowDebugInfo ? null : true);
					}

					return Obejct;
				});

				//对象别名
				string CurAlias = CurElement.Attribute("alias")?.Value;
				if (CurAlias != null) this.ht_alias[CurAlias] = this.data[x];

				//数据编号
				if (!int.TryParse(CurElement.Attribute("id")?.Value, out int CurID)) CurID = x + 1;
				this.ht_id[CurID] = this.data[x];
			}

			Trace.WriteLine($"[{ DateTime.Now }] 完成信息载入: { FileName } ({ this.data.Length }项)");
			#endregion
		}



		private void LoadGame()
		{
			string content = ConfigContent;
			if (content is null) content = DataRes.ResourceManager.GetString(typeof(T).Name + "Data_Simple");
			if (content is null) content = DataRes.ResourceManager.GetString(typeof(T).Name + "Data");
			if (content is null) content = DataRes.ResourceManager.GetString(typeof(T).Name);
			if (content is null) throw new FileNotFoundException($"没有获取到结构配置数据");

			var TableInfo = LoadConfig.LoadSingleByXml(content, DataRes.Public);
			if (TableInfo.DataType == DataType.Local) this.LoadGame(FileCache.Data.LocalData, TableInfo);
			else this.LoadGame(FileCache.Data.GameData, TableInfo);
		}

		private void LoadGame(BinData GameData, TableInfo TableInfo)
		{
			this.DeSerializer = new DeSerializer()
			{
				GameData = GameData,
				LocalData = null,
			};

			this.TableInfo = TableInfo;
			this.ListData = DeSerializer.GetList(TableInfo);
			if (this.ListData is null) throw new Exception($"没有获取到指定数据");

			this.data = new Lazy<T>[this.ListData.ObjectCount];
		}
		#endregion



		#region 对象处理
		private ObjectOutput GetObject(int MainID, int Variation)
		{
			var o = DeSerializer?.GetObject(ListData, TableInfo, MainID, Variation);
			if (o is null) Debug.WriteLine($"[{ typeof(T).Name }] 读取失败  id: {MainID} variation: {Variation}");

			return o;
		}

		private Lazy<T> Test(int MainID, int Variation)
		{
			var o = this.GetObject(MainID, Variation);
			if (o is null) return null;

			return new Lazy<T>(() => CreateNew(o, MainID));
		}

		/// <summary>
		/// 目前未支持缓存读取
		/// </summary>
		/// <param name="o"></param>
		/// <param name="Index"></param>
		/// <returns></returns>
		private T CreateNew(ObjectOutput o, int Index = 0)
		{
			//新建一个对象，需要进行缓存
			var temp = new T()
			{
				Index = Index,
			};

			temp.SetAttribute(o, this.PublicSet, ShowDebugInfo);
			return temp;
		}







		bool FullLoad = false;

		/// <summary>
		/// 获取全部数据临时方法
		/// </summary>
		private IEnumerable<T> CreateTest(bool Preload = false)
		{
			if (!FullLoad)
			{
				var Objects = DeSerializer.GetObjects(this.ListData, this.TableInfo, Preload);
				for (var x = 0; x < Objects.Count; x++)
				{
					var idx = x;
					var obj = Objects[x];

					this.data[x] = new Lazy<T>(() => CreateNew(obj, idx));
				}

				FullLoad = true;
			}

			return this.data.Select(o => o.Value);
		}
		#endregion


		#region 获取对象信息
		public T this[string Alias] => this.GetInfo(Alias);

		public T this[int MainID, int Variation = 0] => this.GetLazyInfo(MainID, Variation)?.Value;

		public T GetInfo(string Alias) => GetLazyInfo(Alias)?.Value;

		protected virtual Lazy<T> GetLazyInfo(string Alias)
		{
			#region 初始化
			if (string.IsNullOrWhiteSpace(Alias)) return null;
			if (int.TryParse(Alias, out int MainID)) return GetLazyInfo(MainID, this is ItemTable ? 1 : 0);

			if (!this.HasData) this.Load();
			#endregion

			#region 获取对象
			//判断alias对应数组
			if (this.ht_alias.ContainsKey(Alias)) return (Lazy<T>)this.ht_alias[Alias];

			if (this.LoadFromGame)
			{
				if (!this.HasData) return null;

				#region 通过别名表获取对象信息
				var AliasTable = FileCache.Data.GameData._content.AliasTable.List[typeof(T).Name];
				if (AliasTable is null) return null;

				var AliasInfo = AliasTable[Alias];
				if (AliasInfo is null) return null;
				#endregion

				#region 返回最终结果
				var result = this.Test(AliasInfo.MainID, AliasInfo.Variation);
				if (result is null) return null;

				this.ht_alias[Alias] = result;
				return result;
				#endregion
			}
			#endregion


			if (this.data.Length != 0) Debug.WriteLine($"[{ typeof(T).Name }] 读取失败  alias: {Alias}");
			return null;
		}

		protected virtual Lazy<T> GetLazyInfo(int MainID, int Variation)
		{
			#region 初始化
			if (MainID == 0) return null;

			if (!this.HasData) this.Load();
			#endregion

			#region 获取对象
			if (this.LoadFromGame) return this.Test(MainID, Variation);
			else if (this.ht_id.ContainsKey(MainID)) return (Lazy<T>)this.ht_id[MainID];
			#endregion


			if (this.data.Length != 0) Debug.WriteLine($"[{ typeof(T).Name }] 读取失败  id: {MainID} variation: {Variation}");
			return null;
		}
		#endregion

		#region 处理类方法
		/// <summary>
		/// 搜寻第一个符合规则的对象，不存在时返回默认值。
		/// </summary>
		/// <param name="SearchRule"></param>
		/// <returns></returns>
		public T Find(Predicate<T> SearchRule) => this.FirstOrDefault(Info => SearchRule(Info));

		/// <summary>
		///  对每个元素执行指定操作。
		/// </summary>
		/// <param name="action"></param>
		public void ForEach(Action<T> action)
		{
			foreach (var t in this) action(t);
		}

		/// <summary>
		/// 搜寻所有符合规则的对象
		/// </summary>
		/// <param name="SearchRule"></param>
		/// <returns></returns>
		public IEnumerable<T> Where(Predicate<T> SearchRule)
		{
			if (!this.HasData) this.Load();
			if (!this.LoadFromGame) return this.Data.Where(Info => SearchRule(Info.Value)).Select(d => d.Value);

			return CreateTest().Where(Info => SearchRule(Info));
		}



		/// <summary>
		/// 查询测试
		/// </summary>
		/// <param name="AttrName"></param>
		/// <param name="SearchRule"></param>
		/// <returns></returns>
		/// <exception cref="Exception"></exception>
		public IEnumerable<T> WhereTest(string AttrName, Predicate<string> SearchRule)
		{
			if (!this.HasData) this.Load();
			if (!this.LoadFromGame) throw new Exception("不支持的加载方式");


			return CreateTest(true)
				.Where(o => SearchRule(o.Attributes[AttrName]))
				.Select(o =>
				{
					var Output = (o.Attributes as OutputData).Object;
					if (Output.FullLoad) return o;


					Output.DesObject();
					o.SetAttribute(Output, this.PublicSet, ShowDebugInfo);
					return o;
				});
		}
		#endregion



		#region 接口方法
		/// <summary>
		/// 清除数据
		/// </summary>
		public void Clear()
		{
			this.data = null;
			this.FullLoad = false;
		}


		public IEnumerator<T> GetEnumerator()
		{
			if (!this.HasData) this.Load();

			if (this.LoadFromGame) foreach (var info in this.CreateTest()) yield return info;
			else foreach (var info in this.Data) yield return info.Value;

			//结束迭代
			yield break;
		}

		IEnumerator IEnumerable.GetEnumerator() => throw new NotImplementedException();
		#endregion
	}
}
