using Xylia.Extension;
using Xylia.Files;
using Xylia.Files.Excel;
using Xylia.Preview.Project.Common.Interface;
using Xylia.Preview.Data.Record;
using Xylia.Preview.Common.Cast;

namespace Xylia.Preview.Third.Content
{
	public class Expedition : OutBase
	{
		#region 字段
		public override string SheetName => "Expedition";
		#endregion


		#region 方法
		public override void CreateData()
		{
			#region 配置标题
			ExcelInfo.sheet.SetColumnWidth(0, 8 * 256);
			ExcelInfo.sheet.SetColumnWidth(1, 8 * 256);
			ExcelInfo.sheet.SetColumnWidth(2, 42 * 256);
			ExcelInfo.sheet.SetColumnWidth(3, 10 * 256);
			ExcelInfo.sheet.SetColumnWidth(4, 65 * 256);


			var TitleRow = this.ExcelInfo.CreateRow(0);

			TitleRow.AddCell("编号");
			TitleRow.AddCell("阶段");
			TitleRow.AddCell("别名");
			#endregion


			#region 配置内容
			int RowIdx = 1;
			foreach (var item in FileCache.Data.WorldAccountExpedition)
			{
				var CurRow = this.ExcelInfo.CreateRow(RowIdx++);

				CurRow.AddCell(item.ID);
				CurRow.AddCell(item.Step);
				CurRow.AddCell(item.Alias);
				CurRow.AddCell(item.Category);
				CurRow.AddCell(item.Name2.GetText());
				CurRow.AddCell(item.Description2.GetText());


				CurRow.AddCell(item.Tooltip1.GetText().CutText());



				//获取数值信息
				void GetAbility(Project.Common.Enums.AttachAbility Ability, int AbilityValue)
				{
					if (Ability == Project.Common.Enums.AttachAbility.None)
					{
						CurRow.AddCell("");
						return;
					}

					CurRow.AddCell(Ability.GetDescription() + " " + AbilityValue);
				}

				GetAbility(item.Ability1, item.AbilityValue1);
				GetAbility(item.Ability2, item.AbilityValue2);
				GetAbility(item.Ability3, item.AbilityValue3);
				GetAbility(item.Ability4, item.AbilityValue4);
				GetAbility(item.Ability5, item.AbilityValue5);


				//获取目标讯息
				CurRow.AddCell(item.Unknown ? item.Attributes["item-count-1"] : " / ");

				for (int i = 1; i <= 20; i++)
				{
					if (!item.ContainsAttribute("item-" + i, out string Item)) break;

					string ItemInfo = false ? Item : Item.GetName();
					string TimeInfo = item.Unknown ? "" : item.Attributes["item-count-" + i]  + "次";

					CurRow.AddCell($"{ItemInfo} {TimeInfo}");
				}
			}
			#endregion
		}
		#endregion
	}
}
