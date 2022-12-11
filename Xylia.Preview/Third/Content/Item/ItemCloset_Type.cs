
using NPOI.SS.UserModel;

using Xylia.Attribute.Component;
using Xylia.Extension;
using Xylia.Files;
using Xylia.Preview.Data.Record;

using static Xylia.Preview.Data.Record.Item;


namespace Xylia.Preview.Third.Content
{
	public class ItemCloset_Type : OutBase
	{
		public override string SheetName => "衣柜";

		#region 方法
		public override void CreateData()
		{
			//移除掉默认的数据表
			this.ExcelInfo.workbook.RemoveSheetAt(0);

			#region 通用处理方法
			//当前行数
			//注意: 由于此字段多表间共享，所以不能同时处理多个工作表！
			int RowIdx = 1;

			//创建单元表
			ISheet CreateSheet(string SheetName, out IRow TitleRow)
			{
				RowIdx = 1;

				var sheet = this.ExcelInfo.workbook.CreateSheet(SheetName);
				sheet.SetColumnWidth(0, 15 * 256);
				sheet.SetColumnWidth(1, 65 * 256);
				sheet.SetColumnWidth(2, 30 * 256);
				sheet.SetColumnWidth(3, 25 * 256);
				sheet.SetColumnWidth(4, 15 * 256);
				sheet.SetColumnWidth(5, 15 * 256);

				TitleRow = this.ExcelInfo.CreateRow(0, sheet);
				TitleRow.AddCell("物品编号");
				TitleRow.AddCell("物品别名");
				TitleRow.AddCell("物品名称");
				TitleRow.AddCell("装备类型");
				TitleRow.AddCell("衣柜编号");
				TitleRow.AddCell("衣柜目录");

				return sheet;
			}

			//创建单元行
			IRow CreateRow(Item ItemInfo, ISheet Sheet)
			{
				var CurRow = this.ExcelInfo.CreateRow(RowIdx++, Sheet);

				CurRow.AddCell(ItemInfo.ID);
				CurRow.AddCell(ItemInfo.Alias);
				CurRow.AddCell(ItemInfo.NameText());
				CurRow.AddCell(ItemInfo.EquipType.GetAttribute<Chinese>()?.Description ?? ItemInfo.EquipType.ToString());

				CurRow.AddCell(ItemInfo.ClosetGroupId);
				CurRow.AddCell(FileCache.Data.ClosetGroup[ItemInfo.ClosetGroupId]?.category.GetDescription());

				return CurRow;
			}
			#endregion




			#region 时装  
			var CostumeSheet = CreateSheet("时装", out var TitleRow);
			CostumeSheet.SetColumnWidth(6, 10 * 256);
			CostumeSheet.SetColumnWidth(7, 10 * 256);
			CostumeSheet.SetColumnWidth(8, 20 * 256);

			TitleRow.AddCell("种族");
			TitleRow.AddCell("性别");
			TitleRow.AddCell("定制类型");


			foreach (var item in FileCache.Data.Item.Where(item =>
				(item.Type == ItemType.costume ||
				(item.Type == ItemType.accessory && item.AccessoryType == AccessoryTypeSeq.CostumeAttach))
				&& item.UsableDuration == 0))
			{
				var CurRow = CreateRow(item, CostumeSheet);

				CurRow.AddCell(item.EquipRace.GetAttribute<Chinese>()?.Description);
				CurRow.AddCell(item.EquipSex.GetAttribute<Chinese>()?.Description);
				CurRow.AddCell(item.CustomDressDesignState, ExcelRow.DisplayType.HideValue);
			}
			#endregion




			#region 幻影石 
			var PetSheet = CreateSheet("幻影石", out _);

			RowIdx = 1;
			foreach (var item in FileCache.Data.Item.Where(item =>
				item.Type == ItemType.weapon &&
				item.weaponType == WeaponType.Pet1 &&
				item.UsableDuration == 0 &&
				(item.weaponAppearanceChangeType == WeaponAppearanceChangeType.UsedOnlyAsApplyingWeapon || item.weaponAppearanceChangeType == WeaponAppearanceChangeType.Both)))

				CreateRow(item, PetSheet);
			#endregion

			#region 幻影武器 
			var WeaponSheet = CreateSheet("武器", out var TitleRow3);
			TitleRow3.AddCell("职业");

			foreach (var item in FileCache.Data.Item.Where(item =>
				item.Type == ItemType.weapon &&
				item.weaponType != WeaponType.Pet1 &&
				item.UsableDuration == 0 &&
				(item.weaponAppearanceChangeType == WeaponAppearanceChangeType.UsedOnlyAsApplyingWeapon)))
			{
				var CurRow = CreateRow(item, WeaponSheet);
				CurRow.AddCell(item.EquipJobCheck1.GetAttribute<Chinese>()?.Description);
			}
			#endregion

			#region 坐骑
			var VehicleSheet = CreateSheet("坐骑", out _);
			foreach (var item in FileCache.Data.Item.Where(item =>
				item.Type == ItemType.accessory &&
				item.AccessoryType == AccessoryTypeSeq.Vehicle))
				CreateRow(item, VehicleSheet);
			#endregion

			#region 外观道具
			var AppearanceItem = CreateSheet("外观道具", out _);
			foreach (var item in FileCache.Data.Item.Where(item =>
				item.Type == ItemType.accessory &&
				item.ContainsAttribute("appearance", out _)))
				CreateRow(item, AppearanceItem);
			#endregion
		}
		#endregion
	}
}
