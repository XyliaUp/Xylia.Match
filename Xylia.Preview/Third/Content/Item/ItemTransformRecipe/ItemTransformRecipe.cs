using System.Collections.Generic;

using NPOI.SS.UserModel;

using Xylia.Extension;
using Xylia.Files;
using Xylia.Preview.Common.Cast;
using Xylia.Preview.Data.Record;

namespace Xylia.Preview.Third.Content
{
	public class ItemTransformRecipe : OutBase
	{
		public override string SheetName => "物品成长配方";

		public override void CreateData()
		{
			#region 配置标题
			var TitleRow = MainSheet.CreateRow(0);

			var TitleCells = new List<ICell>();
			for (int i = 0; i <= 10; i++) TitleCells.Add(this.ExcelInfo.CreateCell(TitleRow, i));

			int CurCellIdx = 0;

			ExcelInfo.sheet.SetColumnWidth(CurCellIdx, 40 * 256);
			TitleCells[CurCellIdx++].SetCellValue("alias");

			ExcelInfo.sheet.SetColumnWidth(CurCellIdx, 25 * 256);
			TitleCells[CurCellIdx++].SetCellValue("目标道具");

			ExcelInfo.sheet.SetColumnWidth(CurCellIdx, 20 * 256);
			TitleCells[CurCellIdx++].SetCellValue("装备类型");

			ExcelInfo.sheet.SetColumnWidth(CurCellIdx, 15 * 256);
			TitleCells[CurCellIdx++].SetCellValue("物品等级");


			ExcelInfo.sheet.SetColumnWidth(CurCellIdx, 25 * 256);
			TitleCells[CurCellIdx++].SetCellValue("结果道具");

			ExcelInfo.sheet.SetColumnWidth(CurCellIdx, 15 * 256);
			TitleCells[CurCellIdx++].SetCellValue("概率方式");

			ExcelInfo.sheet.SetColumnWidth(CurCellIdx, 20 * 256);
			TitleCells[CurCellIdx++].SetCellValue("配方目录");
			#endregion

			#region 输出内容
			int RowIdx = 1;
			FileCache.Data.ItemTransformRecipe.ForEach(Info =>
			{
				#region 初始化当前行
				var CurRow = MainSheet.CreateRow(RowIdx++);

				var CurCells = new List<ICell>();
				for (int i = 0; i <= 10; i++) CurCells.Add(this.ExcelInfo.CreateCell(CurRow, i));
				#endregion

				#region	设置内容
				CurCellIdx = 0;
				CurCells[CurCellIdx++].SetCellValue(Info.Alias);

				#region 获取主祭品
				var MainIngredient = Info.MainIngredient?.CastObject();
				if (MainIngredient is ItemBrand)
				{
					var ItemBrandTooltip = FileCache.Data.ItemBrandTooltip[MainIngredient.ID, (byte)Info.MainIngredientConditionType];
					CurCells[CurCellIdx++].SetCellValue(ItemBrandTooltip?.Name2);
					CurCells[CurCellIdx++].SetCellValue("CondType: " + ItemBrandTooltip?.ItemConditionType);
					CurCells[CurCellIdx++].SetCellValue(ItemBrandTooltip?.ItemGrade);
				}
				else if (MainIngredient is Item Item)
				{
					CurCells[CurCellIdx++].SetCellValue(Item.ItemName);
					CurCells[CurCellIdx++].SetCellValue(Item.EquipType.GetDescription());
					CurCells[CurCellIdx++].SetCellValue(Item.ItemGrade);
				}
				else CurCellIdx += 3;
				#endregion

				CurCells[CurCellIdx++].SetCellValue(Info.TitleItem.GetItemInfo()?.ItemName);
				CurCells[CurCellIdx++].SetCellValue(Info.UseRandom ? "随机" : "必成");
				CurCells[CurCellIdx++].SetCellValue(Info.Category.GetDescription());
				#endregion
			});
			#endregion
		}
	}
}