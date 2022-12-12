using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

using Xylia.bns.Modules.DataFormat.Bin;
using Xylia.bns.Modules.DataFormat.Bin.Entity.BDAT.Interface;
using Xylia.bns.Util.Sort;
using Xylia.Extension;
using Xylia.Files.XmlEx;
using Xylia.Match.Properties.Resx;
using Xylia.Match.Util.Game.ItemData.Util;


namespace Xylia.Match.Util.ItemList
{
/// <summary>
/// 用于读取数据
/// </summary>
	public class Read : IDisposable
	{

		#region 构造
		public Read(Action<string> action)
		{
			GetAction = action;
		}

		/// <summary>
		/// 构造时立即查询data路径
		/// </summary>
		/// <param name="action"></param>
		/// <param name="is64"></param>
		/// <param name="FolderPath"></param>
		public Read(Action<string> action, bool is64, string FolderPath) : this(action)
		{
			this.GetPath(is64, FolderPath);
		}
		#endregion



		#region 字段
		public static ReadPara GetReadInfo = new();

		private readonly Action<string> GetAction = null;

		public ChvInfo ChvInfo = new();

		/// <summary>
		/// 数据
		/// </summary>
		public IEnumerable<IObject> XmlData = null;

		public TextBinData Localization = null;

		public string OldPath = null;
		#endregion



		#region 方法
		/// <summary>
		/// 读取旧数据
		/// </summary>
		/// <param name="Show"></param>
		/// <returns></returns>
		public List<int> GetOld(bool Show = true)
		{
			var vs = new List<int>();
			if (!GetReadInfo.OnlyNew || string.IsNullOrWhiteSpace(GetReadInfo.Path.Chv)) return vs;


			try
			{
				//本地文件
				if (File.Exists(GetReadInfo.Path.Chv))
				{
					var rd = File.OpenText(GetReadInfo.Path.Chv);

					string line;
					while ((line = rd.ReadLine()) != null)
					{
						if (int.TryParse(line.Replace("\"", ""), out int @int)) vs.Add(@int);
					}

					rd.Close();  // 关闭文件
				}

				//网络文件
				else if (!string.IsNullOrEmpty(OldPath))
				{
					if (Show && GetAction != null) GetAction("正在尝试下载并解析云端配置文件");

					string list = Encoding.UTF8.GetString(new HttpClient().GetByteArrayAsync(OldPath).Result).Replace("\"", "");

					foreach (var Str in new List<string>(list.Split(new[] { "\r\n" }, StringSplitOptions.None)))
					{
						if (Str.Contains('='))
						{
							ChvInfo_Creat(Str);
							continue;
						}

						if (int.TryParse(Str, out int @int)) vs.Add(@int);
					}

					string Msg = null;
					if (!string.IsNullOrEmpty(ChvInfo.Title)) Msg += $"目前加载的是「{ ChvInfo.Title }」";
					if (!string.IsNullOrEmpty(ChvInfo.Verison)) Msg += $"（版本{ ChvInfo.Verison + ChvInfo.Publish ?? "，发布于" + ChvInfo.Publish }）\n";
					if (!Msg.IsNull() && Show && GetAction != null) GetAction(Msg);
				}
			}
			catch (Exception ee)
			{
				GetAction?.Invoke(ee.Message);
			}

			if (Show && vs.Count > 0) GetAction?.Invoke($"共加载到{ vs.Count }个历史版本道具，将会自动跳过");

			return vs;
		}

		public void ChvInfo_Creat(string Str)
		{
			if (Str.Contains("Verison")) ChvInfo.Verison = Str.Replace("Verison", null).Replace("=", null).Replace(" ", null);
			else if (Str.Contains("Publish")) ChvInfo.Publish = Str.Replace("Publish", null).Replace("=", null).Replace(" ", null);
			else if (Str.Contains("Title")) ChvInfo.Title = Str.Replace("Title", null).Replace("=", null).Replace(" ", null);
		}

		/// <summary>
		/// 读取Dat文件路径
		/// </summary>
		/// <param name="is64"></param>
		/// <param name="FolderPath"></param>
		public void GetPath(bool is64, string FolderPath)
		{
			var getDataPath = new bns.Read.GetDataPath(FolderPath, is64);

			Task task1 = this.LoadXml(getDataPath.TargetXml);
			Task task2 = this.LoadLocal(getDataPath.TargetLocal);

			while (!task1.IsCompleted || !task2.IsCompleted) System.Threading.Thread.Sleep(2000);
		}

		/// <summary>
		/// 加载 xml.dat 文件
		/// </summary>
		/// <param name="Path"></param>
		public async Task LoadXml(string Path)
		{
			GetAction?.Invoke("正在对比新增道具，资源文件处理耗时较长，请耐心等待。");

			try
			{
				var tmp = new BinData(Path, true);

				this.GetAction("当前版本：" + tmp._content.UpdateTime.GetTimeStr());

				//加载记录文件
				this.XmlData = ExtractData(tmp, false, GetReadInfo.OnlyNew ? GetOld() : null);
			}
			catch (Exception ee)
			{
				throw new bns.Read.ReadException($"解析游戏数据文件时发生异常", ee);
			}
		}

		/// <summary>
		/// 加载 local.dat 文件
		/// </summary>
		/// <param name="Path"></param>
		public async Task LoadLocal(string Path)
		{
			try
			{
				//这里如果出现问题，可能是解包代码出现问题
				this.Localization = new TextBinData(Path);
			}
			catch (Exception ee)
			{
				throw new bns.Read.ReadException($"解析汉化文件时发生异常", ee);
			}
		}

		/// <summary>
		/// 获取特殊文件
		/// </summary>
		/// <returns></returns>
		public static Dictionary<string, string> GetSpecial()
		{
			var dictionary = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
			var xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(Progrm.Game);

			foreach (XmlNode xmlNode in xmlDocument.SelectNodes("Game/General"))
			{
				var XmlProperty = xmlNode.Property();

				try
				{
					string Id = XmlProperty.Attributes["ID"];
					string Alias = XmlProperty.Attributes["Alias"];
					string Text = XmlProperty.Attributes["Name2"];

					if (!Text.IsNull())
					{
						if (!Id.IsNull() && !dictionary.ContainsKey(Id)) dictionary.Add(Id, Text);
						if (!Alias.IsNull() && !dictionary.ContainsKey(Alias.ToLower())) dictionary.Add(Alias.ToLower(), Text);
					}
				}
				catch { continue; }
			}
			return dictionary;
		}
		#endregion




		public static IEnumerable<IObject> ExtractData(BinData GameData,  bool Distinct = false, IEnumerable<int> Old = null)
		{
			if (!GameData.ContainsAlias("item", out var ListID)) 
				throw new Exception("无效对象");

			#region 初始化
			var Result = new BlockingCollection<IObject>();
			HashSet<int> CacheList = new();
			if (Old != null) foreach (var o in Old) CacheList.Add(o);
			#endregion

			#region 处理数据
			Parallel.ForEach(GameData[ListID].CellDatas(), Table =>
			{
				//读取数据编号
				if (Old != null && CacheList.Contains(Table.FID)) return;

				Result.Add(Table);
			});
			#endregion

			#region 最后处理
			var ObjList = Result.ToList();
			Result.Dispose();
			Result = null;

			//对数据进行排序处理
			ObjList.Sort(new SeriDataSortById());
			if (Distinct) ObjList = ObjList.Distinct(new RemoveObjectSameID()).ToList();

			return ObjList;
			#endregion
		}



		#region Dispose
		private bool disposedValue;
		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					// TODO: 释放托管状态(托管对象)
				}

				//this.Sinicization = null;
				this.XmlData = null;

				// TODO: 释放未托管的资源(未托管的对象)并替代终结器
				// TODO: 将大型字段设置为 null
				disposedValue = true;
			}
		}

		// // TODO: 仅当“Dispose(bool disposing)”拥有用于释放未托管资源的代码时才替代终结器
		// ~Read()
		// {
		//     // 不要更改此代码。请将清理代码放入“Dispose(bool disposing)”方法中
		//     Dispose(disposing: false);
		// }
		public void Dispose()
		{
			// 不要更改此代码。请将清理代码放入“Dispose(bool disposing)”方法中
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}
		#endregion
	}
}