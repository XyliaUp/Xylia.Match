using System.Collections.Generic;
using System.ComponentModel;

using NPOI.SS.UserModel;

using Xylia.Extension;
using Xylia.Preview.Project.Common.Interface;
using Xylia.Preview.Data.Record;
using Xylia.Preview.Common.Cast;

namespace Xylia.Preview.Third.Content
{
	public class ItemTransformRecipe : OutBase
	{
		public override string SheetName => "ItemTransformRecipe";

		public override void CreateData()
		{
			#region 配置列宽
			ExcelInfo.sheet.SetColumnWidth(0, 40 * 256);
			ExcelInfo.sheet.SetColumnWidth(1, 25 * 256);
			ExcelInfo.sheet.SetColumnWidth(2, 25 * 256);
			ExcelInfo.sheet.SetColumnWidth(3, 15 * 256);
			ExcelInfo.sheet.SetColumnWidth(4, 20 * 256);
			ExcelInfo.sheet.SetColumnWidth(5, 20 * 256);
			ExcelInfo.sheet.SetColumnWidth(6, 15 * 256);
			#endregion

			#region 配置标题
			var TitleRow = MainSheet.CreateRow(0);

			var TitleCells = new List<ICell>();
			for (int i = 0; i <= 30; i++) TitleCells.Add(this.ExcelInfo.CreateCell(TitleRow, i));

			int CurCellIdx = 0;
			TitleCells[CurCellIdx++].SetCellValue("alias");
			TitleCells[CurCellIdx++].SetCellValue("目标道具");
			TitleCells[CurCellIdx++].SetCellValue("结果道具");
			TitleCells[CurCellIdx++].SetCellValue("概率方式");
			TitleCells[CurCellIdx++].SetCellValue("配方目录");
			TitleCells[CurCellIdx++].SetCellValue("装备类型");
			TitleCells[CurCellIdx++].SetCellValue("物品等级");
			#endregion

			#region 输出内容
			int RowIdx = 1;
			FileCache.Data.ItemTransformRecipe.ForEach(Info =>
			{
				#region 初始化当前行
				var CurRow = MainSheet.CreateRow(RowIdx++);

				var CurCells = new List<ICell>();
				for (int i = 0; i <= 30; i++) CurCells.Add(this.ExcelInfo.CreateCell(CurRow, i));
				#endregion

				#region	设置内容
				CurCellIdx = 0;
				CurCells[CurCellIdx++].SetCellValue(Info.Alias);

				#region 获取主祭品
				IRecord MainIngredient = null;
				if (Info.MainIngredient != null)
				{
					//主祭品信息转换
					MainIngredient = Info.MainIngredient.GetObject();
					if (MainIngredient != null)
					{
						if (MainIngredient is ItemBrand)
						{
							var ItemBrandTooltip = FileCache.Data.ItemBrandTooltip.Find(d => d.ID == MainIngredient.ID && d.ItemConditionType == Info.MainIngredientConditionType);
							MainIngredient = ItemBrandTooltip;

							if (ItemBrandTooltip != null) CurCells[CurCellIdx].SetCellValue(ItemBrandTooltip.Name2);
						}
						else if (MainIngredient is Item item)
						{
							MainIngredient = item;
							CurCells[CurCellIdx].SetCellValue(item.NameText());
						}
					}
				}

				CurCellIdx++;
				#endregion

				CurCells[CurCellIdx++].SetCellValue(Info.TitleItem.GetItemInfo()?.NameText());
				CurCells[CurCellIdx++].SetCellValue(Info.UseRandom ? "随机" : "必成");

				//目录信息
				string CategoryInfo = Info.category.ContainAttribute(out DescriptionAttribute description) ? description.Description : Info.category.ToString();
				CurCells[CurCellIdx++].SetCellValue(CategoryInfo);


				if (MainIngredient is null) return;
				if (MainIngredient is ItemBrandTooltip ItemBrandTooltip2)
				{
					CurCells[CurCellIdx++].SetCellValue("CondType: " + ItemBrandTooltip2.ItemConditionType);
					CurCells[CurCellIdx++].SetCellValue(ItemBrandTooltip2.ItemGrade);
				}
				else if (MainIngredient is Item itemInfo)
				{
					//类型信息
					string EquipTypeInfo = itemInfo.EquipType.ContainAttribute(out DescriptionAttribute description2) ? description2.Description : itemInfo.EquipType.ToString();

					CurCells[CurCellIdx++].SetCellValue(EquipTypeInfo);
					CurCells[CurCellIdx++].SetCellValue(itemInfo.ItemGrade);
				}
				#endregion
			});
			#endregion
		}
	}
}
