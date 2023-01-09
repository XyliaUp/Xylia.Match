
using System;
using System.Collections.Concurrent;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xylia.bns.Modules.DataFormat.Bin;
using Xylia.bns.Read;
using Xylia.Extension;
using Xylia.Preview.Data.Record;


namespace Xylia.Match.Util.Paks.Textures
{
	public abstract class IconOutBase : IDisposable
	{
		#region 构造
		public IconOutBase( string GameFolder = null)
		{
			this.GameDirectory = GameFolder;
		}
		#endregion


		#region	字段
		/// <summary>
		/// 客户端数据
		/// </summary>
		internal BinData GameData;

		/// <summary>
		/// 统计Icon路径信息与包名称信息
		/// </summary>
		internal ConcurrentDictionary<int, IconTexture> IconTextures;

		/// <summary>
		/// 关联信息
		/// </summary>
		internal BlockingCollection<QuoteInfo> QuoteInfos = new();


		/// <summary>
		/// 游戏资源文件夹
		/// </summary>
		public string GameDirectory = null;

		/// <summary>
		/// 结果目录
		/// </summary>
		public string OutputDirectory = null;


		/// <summary>
		/// 日志输出器
		/// </summary>

		internal OutLogHelper LogHelper = null;

		public string Path_XML = null;

		public string Path_Local = null;


		/// <summary>
		/// 指示是否显示生成日志
		/// </summary>
		public bool ShowLog_CreateInfo = true;


		internal Action<string> Action = null;
		#endregion




		#region 方法
		/// <summary>
		/// 开始初始化
		/// </summary>
		public void StartInit(Action<string> Action)
		{
			#region 读取资源
			this.LogHelper = new OutLogHelper(Path.GetDirectoryName(this.OutputDirectory));  //设置日志输出路径
			this.Action = Action;


			var select = new GetDataPath(this.GameDirectory, null);    //初始化数据文件
			this.Path_XML = select.TargetXml;
			this.Path_Local = select.TargetLocal;
			#endregion




			#region 分析数据
			this.AnalyseTextureData();

			//清空数据
			this.QuoteInfos = new();

			//开始分析数据
			this.AnalyseSourceData();

			//清理资源
			this.GameData?.Dispose();
			this.GameData = null;
			#endregion
		}

		/// <summary>
		/// 分析贴图数据
		/// </summary>
		public void AnalyseTextureData()
		{
			#region 初始化
			Action("正在分析图标数据...");

			if (this.GameData is null) this.GameData = new BinData(Path_XML);
			this.IconTextures = new();
			#endregion


			#region 读取贴图数据
			var Table = this.GameData["icontexture"];
			Parallel.ForEach(Table.CellDatas(), field =>
			{
				int CurId = field.Field.FID;

				//路径信息
				var Lookups = field.Lookup.TextList;
				if (this.IconTextures.ContainsKey(CurId)) return;


				this.IconTextures.GetOrAdd(CurId, new IconTexture()
				{
					alias = Lookups[0].String,
					iconTexture = Lookups[1].String,
					IconWidth = BitConverter.ToInt16(field.Field.Data, 20),
					IconHeight = BitConverter.ToInt16(field.Field.Data, 22),
					TextureWidth = BitConverter.ToInt16(field.Field.Data, 24),
					TextureHeight = BitConverter.ToInt16(field.Field.Data, 26),
				});
			});
			#endregion
		}

		/// <summary>
		/// 分析指定数据
		/// </summary>
		/// <param name="IconPath"></param>
		/// <param name="OnlyDumpUpks">只输出文件</param>
		internal virtual void AnalyseSourceData() => throw new Exception("请在引用类中分析资源数据");
		#endregion


		#region 生成图标
		/// <summary>
		/// 生成对应的图标文件
		/// </summary>
		/// <param name="SaveFormat"></param>
		public void SaveAsPicture(string SaveFormat)
		{
			#region	设置存储格式
			//去除格式中括号内空格
			bool HasSaveFormat = false;
			if (!SaveFormat.IsNull())
			{
				HasSaveFormat = true;
				SaveFormat = SaveFormat.ToLower();

				SaveFormat = new Regex(@"\[\s+", RegexOptions.Singleline).Replace(SaveFormat, "[");
				SaveFormat = new Regex(@"\s+\]", RegexOptions.Singleline).Replace(SaveFormat, "]");
			}
			#endregion

			#region 开始处理
			//必须进行初始化
			IconTextureExt.PakData.Initialize(this.GameDirectory);

			//多线程处理
			int Count = 0;
			Parallel.ForEach(this.QuoteInfos, QuoteInfo =>
			{
				Action($"正在生成图标，进度{ 100 * Count++ / this.QuoteInfos.Count  }%");

				try
				{
					#region 获取图标
					string ItemMsg = $"数据ID { QuoteInfo.MainId } { (QuoteInfo.Name != null ? $"[{ QuoteInfo.Name }]" : null) } ";
					if (QuoteInfo.IconTextureId == 0)
					{
						LogHelper.Record(ItemMsg + $"缺少道具图标", OutLogHelper.LogGroup.错误记录);
						return;
					}
					else if (!IconTextures.ContainsKey(QuoteInfo.IconTextureId))
					{
						Console.WriteLine($"{ QuoteInfo.IconTextureId } 没有对应结果，是无效的数据。(IconInfo: { IconTextures.Count })");
						return;
					}


					var IconTexture = IconTextures[QuoteInfo.IconTextureId];
					if (string.IsNullOrWhiteSpace(IconTexture.iconTexture))
					{
						LogHelper.Record(ItemMsg + $"图标异常 ({ IconTexture.alias })", OutLogHelper.LogGroup.错误记录);
						return;
					}

					var bitmap = IconTextureExt.GetIcon(IconTexture, QuoteInfo.IconIndex);
					if (bitmap is null)
					{
						LogHelper.Record(ItemMsg + $"资源获取失败 ({ IconTexture.iconTexture })", OutLogHelper.LogGroup.错误记录);
						return;
					}


					lock (bitmap) bitmap = (Bitmap)bitmap.Clone();
					bitmap = QuoteInfo.ProcessImage(bitmap);
					#endregion



					#region 输出名称处理
					string MainId = QuoteInfo.MainId.ToString();
					string OutName = $"{ MainId }_{ QuoteInfo.Name }";

					if (!HasSaveFormat) OutName = MainId;
					else
					{
						//由于正则对中文支持问题，其他中文情况单独列出
						OutName = SaveFormat
						   .Replace("[名称]", QuoteInfo.Name)
						   .Replace("[name]", QuoteInfo.Name).Replace("[name2]", QuoteInfo.Name)
						   .Replace("[alias]", QuoteInfo.Alias).Replace("[别名]", QuoteInfo.Alias)
						   .Replace("[id]", MainId).Replace("[编号]", MainId);
					}

					//判断是否存在非法字符
					if (OutName.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
					{
						LogHelper.Record($"{ QuoteInfo.MainId } [{ QuoteInfo.Name }]  由于名称存在非法字符，生成名称已调整。(非法字符是指<>?*\" |\\/等不可以用于文件名的符号)", OutLogHelper.LogGroup.生成日志);
						foreach (char c in Path.GetInvalidFileNameChars()) OutName = OutName.Replace(c.ToString(), "_");
					}

					//生成最终存储文件名
					string FinalPath = OutputDirectory + @"\" + OutName + (Path.GetExtension(OutName).IsNull() ? ".png" : null);
					#endregion

					#region 存储图片
					// 存储初始化
					if (!Directory.Exists(OutputDirectory)) Directory.CreateDirectory(OutputDirectory);
					if (File.Exists(FinalPath)) File.Delete(FinalPath);

					// 输出图片
					bitmap.Save(FinalPath, ImageFormat.Png);
					bitmap.Dispose();
					bitmap = null;


					//创建成功日志
					if (this.ShowLog_CreateInfo)
					{
						var IconInfo = IconTextures.ContainsKey(QuoteInfo.IconTextureId) ? IconTextures[QuoteInfo.IconTextureId] : null;
						LogHelper.Record($"{ QuoteInfo.MainId } => { IconInfo.iconTexture }", OutLogHelper.LogGroup.生成日志);
					}
					#endregion
				}
				catch (Exception ee)
				{
					LogHelper.Record($@"{ QuoteInfo.MainId } => { ee }", OutLogHelper.LogGroup.错误记录);
				}
			});
			#endregion


			#region 资源清理 
			this.QuoteInfos = null;

			GC.Collect();
			#endregion
		}
		#endregion



		#region Dispose
		private bool disposedValue;

		protected virtual void Dispose(bool disposing)
		{
			try
			{
				if (!disposedValue)
				{
					if (disposing)
					{
						// TODO: 释放托管状态(托管对象)

					}

					this.LogHelper = null;
					this.GameData?.Dispose();
					this.GameData = null;

					// TODO: 释放未托管的资源(未托管的对象)并替代终结器
					// TODO: 将大型字段设置为 null
					disposedValue = true;
				}
			}
			catch
			{

			}
		}

		// // TODO: 仅当“Dispose(bool disposing)”拥有用于释放未托管资源的代码时才替代终结器
		// ~IconTextureBase()
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