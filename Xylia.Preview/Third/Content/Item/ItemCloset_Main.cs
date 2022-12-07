using System.Collections.Generic;

using Xylia.Extension;
using Xylia.Files;
using Xylia.Files.Excel;
using Xylia.Preview.Data.Record;

using static Xylia.Preview.Data.Record.Item;

namespace Xylia.Preview.Third.Content
{
	public class ItemCloset_Main : OutBase
	{
		#region 字段
		public override string SheetName => "Item_closet";
		#endregion

		#region 方法
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

			//FileCacheData.Data.Item.Sort(new MySort());
			FileCache.Data.Item.ForEach(Info =>
			{
				#region 初始化
				//指示是否需要输出
				bool Flag = false;

				//对于服装类型，不需要额外判断
				if (Info.Type == ItemType.costume) Flag = true;
				//对于武器类型，需要判断是否存在衣柜关联
				else if (Info.Type == ItemType.weapon && Info.ClosetGroupId != 0) Flag = true;
				//对于饰品，需要判断其饰品类型
				else if (Info.Type == ItemType.accessory &&
					(Info.accessoryType == AccessoryType.CostumeAttach || Info.accessoryType == AccessoryType.Vehicle)) Flag = true;


				if (!Flag) return;
				else if (Info.UsableDuration != 0) return;  //过滤所有期限型物品
				#endregion

				var CurRow = this.ExcelInfo.CreateRow(RowIdx++);

				CurRow.AddCell(Info.ID);
				CurRow.AddCell(Info.Alias);
				CurRow.AddCell(Info.NameText());
				CurRow.AddCell(Info.EquipType.GetDescription());
				CurRow.AddCell(Info.EquipSex.GetDescription(true));
				CurRow.AddCell(Info.EquipRace.GetDescription(true));
				CurRow.AddCell(Info.ClosetGroupId);

				if (Info.ClosetGroupId != 0)
				{
					CurRow.AddCell(FileCache.Data.ClosetGroup[Info.ClosetGroupId]?.category.GetDescription());
				}
			});
			#endregion
		}
		#endregion
	}
}
