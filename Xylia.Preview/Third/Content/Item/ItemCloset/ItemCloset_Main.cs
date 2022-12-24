
using Xylia.Extension;
using Xylia.Files;
using Xylia.Files.Excel;

using static Xylia.Preview.Data.Record.Item;

namespace Xylia.Preview.Third.Content
{
	public class ItemCloset_Main : OutBase
	{
		public override string SheetName => "Item_closet";

		public override void CreateData()
		{
			#region 配置标题
			ExcelInfo.sheet.SetColumnWidth(0, 15 * 256);
			ExcelInfo.sheet.SetColumnWidth(1, 40 * 256);
			ExcelInfo.sheet.SetColumnWidth(2, 25 * 256);
			ExcelInfo.sheet.SetColumnWidth(3, 15 * 256);
			ExcelInfo.sheet.SetColumnWidth(4, 15 * 256);
			ExcelInfo.sheet.SetColumnWidth(5, 15 * 256);
			ExcelInfo.sheet.SetColumnWidth(6, 20 * 256);
			ExcelInfo.sheet.SetColumnWidth(7, 20 * 256);

			var TitleRow = this.ExcelInfo.CreateRow(0);
			TitleRow.AddCell("物品编号");
			TitleRow.AddCell("物品别名");
			TitleRow.AddCell("物品名称");
			TitleRow.AddCell("装备类型");
			TitleRow.AddCell("性别");
			TitleRow.AddCell("种族");
			TitleRow.AddCell("衣柜归属");
			TitleRow.AddCell("衣柜目录");
			#endregion


			#region 配置内容
			int RowIdx = 1;
			FileCache.Data.Item.ForEach(ItemInfo =>
			{
				#region 初始化
				//指示是否需要输出
				bool Flag = false;

				//对于服装类型，不需要额外判断
				if (ItemInfo.Type == ItemType.Costume) Flag = true;
				//对于武器类型，需要判断是否存在衣柜关联
				else if (ItemInfo.Type == ItemType.Weapon && ItemInfo.ClosetGroupId != 0) Flag = true;
				//对于饰品，需要判断其饰品类型
				else if (ItemInfo.Type == ItemType.Accessory &&
					(ItemInfo.AccessoryType == AccessoryTypeSeq.CostumeAttach || ItemInfo.AccessoryType == AccessoryTypeSeq.Vehicle)) Flag = true;


				if (!Flag) return;
				else if (ItemInfo.UsableDuration != 0) return;  //过滤所有期限型物品
				#endregion
							   

				var CurRow = this.ExcelInfo.CreateRow(RowIdx++);

				CurRow.AddCell(ItemInfo.ID);
				CurRow.AddCell(ItemInfo.Alias);
				CurRow.AddCell(ItemInfo.NameText());
				CurRow.AddCell(ItemInfo.EquipType.GetDescription());
				CurRow.AddCell(ItemInfo.EquipSex.GetDescription(true));
				CurRow.AddCell(ItemInfo.EquipRace.GetDescription(true));
				CurRow.AddCell(ItemInfo.ClosetGroupId);

				if (ItemInfo.ClosetGroupId != 0)
					CurRow.AddCell($"Name.closet-group.category.{ FileCache.Data.ClosetGroup[ItemInfo.ClosetGroupId]?.Category.GetSignal() }".GetText());
			});
			#endregion
		}
	}
}