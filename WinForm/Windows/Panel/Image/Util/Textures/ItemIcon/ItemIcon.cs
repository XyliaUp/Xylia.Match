using System;
using System.Threading.Tasks;

using Xylia.bns.Modules.DataFormat.Bin;
using Xylia.Match.Util.Game.ItemData.Util;

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
		public ItemIcon(string GameFolder = null) : base(GameFolder) { }


		internal override void AnalyseSourceData()
		{
			Action("正在分析物品数据...");

			var localization = new TextBinData(Path_Local);

			//设置并发线程数量
			var pOptions = new ParallelOptions()
			{
				//MaxDegreeOfParallelism = 6,
			};


			//读取外部文件
			var CacheList = ChvLoad.LoadData(ChvPath, null);

			//读取物品数据
			var ItemTable = this.GameData["item"];
			Parallel.ForEach(ItemTable.CellDatas(), pOptions, (field) =>
			{
				int MainId = field.FID;
				if (isWhiteList && (CacheList is null || !CacheList.Contains(MainId))) return;
				if (!isWhiteList && (CacheList != null && CacheList.Contains(MainId))) return;

				#region 获取数据
				var Data = field.Field.Data;

				int IconId = BitConverter.ToInt32(Data, LocDefine.IconId);
				short IconIdx = BitConverter.ToInt16(Data, LocDefine.IconId + 8);

				byte Grade = Data[LocDefine.Grade];
				string Name2 = localization.GetText(BitConverter.ToInt32(Data, LocDefine.Name2));

				//获取 GroceryType
				byte GroceryType = 0;
				if (field.FType == 2) GroceryType = Data[LocDefine.GroceryType];
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
			});

			localization = null;
		}
		#endregion
	}
}