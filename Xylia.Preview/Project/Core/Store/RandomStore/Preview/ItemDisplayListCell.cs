using System;
using System.Collections.Generic;
using System.Linq;

using Xylia.Drawing;
using Xylia.Preview.Data.Record;
using Xylia.Preview.Project.Core.Store.Cell;
using Xylia.Preview.Resources;

using static Xylia.Preview.Data.Record.RandomStoreItemDisplay;


namespace Xylia.Preview.Project.Core.RandomStore.Cell
{
	public sealed class ItemDisplayListCell : ItemListCell
	{
		public RandomStoreItemDisplay data;

		public ItemDisplayListCell(RandomStoreItemDisplay Record) : base()
		{
			this.data = Record;

			var DisplayItem = Record.DisplayItem.GetItemInfo();

			//追加最新图标
			//TODO: 考虑绘制时再读取图标
			var ItemIcon = DisplayItem.IconExtra;
			if (Record.NewArrival) ItemIcon = ItemIcon.ImageCombine(Resource_Common.SlotItem_New, Compose.DrawLocation.TopLeft);

			this.ItemShow.LoadData(DisplayItem, ItemIcon);
		}


		public static List<ItemDisplayListCell> GetCells(RandomStoreTypeSeq RandomStoreType)
		{
			var Dt = DateTime.Now;

			var StoreItems = FileCache.Data.RandomStoreItemDisplay.Where(o => o.RandomStoreType == RandomStoreType).Select(o => new ItemDisplayListCell(o)).ToList();
			StoreItems.Sort(new DisplayListCellSort());

			System.Diagnostics.Trace.WriteLine($"[Debug] 载入数据完成 { (DateTime.Now - Dt).TotalSeconds }s");

			return StoreItems;
		}
	}

	/// <summary>
	/// 排序器
	/// </summary>
	public sealed class DisplayListCellSort : IComparer<ItemDisplayListCell>
	{
		public int Compare(ItemDisplayListCell x, ItemDisplayListCell y)
		{
			//判断是否是新物品
			if (!x.data.NewArrival && y.data.NewArrival) return 1;
			else if (x.data.NewArrival && !y.data.NewArrival) return -1;

			var Ix = x.data.DisplayItem.GetItemInfo();
			var Iy = y.data.DisplayItem.GetItemInfo();

			//判断物品品质（大的在前）
			if (Ix.ItemGrade != Iy.ItemGrade) return Iy.ItemGrade - Ix.ItemGrade;

			//判断物品种类（小的在前）
			if (Ix.GameCategory3 != Iy.GameCategory3) return Ix.GameCategory3 - Iy.GameCategory3;


			//最后判断顺序（小的在前）
			return x.data.Index - y.data.Index;
		}
	}
}
