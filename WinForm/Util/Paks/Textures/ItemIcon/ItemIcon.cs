using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Xylia.bns.Modules.DataFormat.BinData;
using Xylia.bns.Modules.DataFormat.BinData.Handle.Local;
using Xylia.Extension;
using Xylia.Preview.Data.Record;


namespace Xylia.Match.Util.Paks.Textures
{
	/// <summary>
	/// 物品图标
	/// </summary>
	public sealed class ItemIcon : IconOutBase
	{
		#region 实例属性
		/// <summary>
		/// 指示是否有背景
		/// </summary>
		public bool UseBackground = false;



		/// <summary>
		/// 指示白名单模式
		/// </summary>
		public bool isWhiteList = false;

		/// <summary>
		/// 缓存文件路径
		/// </summary>
		public string ChvPath = null;
		#endregion



		#region 方法
		public ItemIcon(Action<string> action, string GameFolder = null) : base(action, GameFolder) { }

		internal override void AnalyseSourceData(ConcurrentDictionary<int, IconTexture> IconPath)
		{
			#region 读取物品数据
			Action("正在分析物品数据...");

			var localization = new Localization(Path_Local);

			//设置并发线程数量
			var pOptions = new ParallelOptions()
			{
				//MaxDegreeOfParallelism = 6,
			};



			#region 读取外部文件
			var CacheList = new BlockingCollection<int>();
			if (!string.IsNullOrWhiteSpace(ChvPath) && File.Exists(ChvPath))  //校验
			{
				var rd = File.OpenText(ChvPath);

				string line;
				while ((line = rd.ReadLine()) != null)
				{
					if (int.TryParse(line.Replace("\"", ""), out int @int)) CacheList.Add(@int);
				}

				rd.Close();  // 关闭文件
			}
			#endregion

			//读取物品数据
			Parallel.ForEach(HandleData.BinHandle.ExtractData(0, true, isWhiteList ? null : CacheList), pOptions, (field) =>
			{
				int MainId = field.FID;
				var FData = field.Field.Data;

				if (!isWhiteList || CacheList.Contains(MainId))
				{
					#region 获取数据
					int IconId = BitConverter.ToInt32(FData, LocDefine.IconId);
					short IconIdx = BitConverter.ToInt16(FData, LocDefine.IconId + 8);

					byte Grade = FData[LocDefine.Grade];
					string Name2 = localization.GetText(BitConverter.ToInt32(FData, LocDefine.Name2));

					//获取 GroceryType
					byte GroceryType = 0;
					if (field.FType.Value == 2) GroceryType = FData[LocDefine.GroceryType];
					#endregion


					this.QuoteInfos.Add(new ItemQuoteInfo()
					{
						MainId = MainId,
						Alias = field.Alias,
						Name = Name2,

						IconTextureId = IconId,
						IconIndex = IconIdx,

						Grade = Grade,
						GroceryType = GroceryType,
						NoBG = !this.UseBackground,
					});
				}
			});
			#endregion

			localization = null;
		}
		#endregion
	}
}
