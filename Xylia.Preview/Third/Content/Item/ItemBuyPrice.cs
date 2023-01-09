using System.Collections.Generic;

using NPOI.SS.UserModel;

using Xylia.Preview.Data.Record;
using Xylia.Preview.Project.Controls.Currency;

namespace Xylia.Preview.Third.Content
{
	public sealed class ItemBuyPrice : OutBase
	{
		public override string SheetName => "物品购买价格";

		public override void CreateData()
		{
			#region 配置标题
			var TitleRow = this.ExcelInfo.CreateRow(0);

			var TitleCells = new List<ICell>();
			for (int i = 0; i <= 30; i++) TitleCells.Add(this.ExcelInfo.CreateCell(TitleRow, i));

			int CurCellIdx = 0;
			ExcelInfo.sheet.SetColumnWidth(CurCellIdx, 70 * 256);
			TitleCells[CurCellIdx++].SetCellValue("alias");

			ExcelInfo.sheet.SetColumnWidth(CurCellIdx, 15 * 256);
			TitleCells[CurCellIdx++].SetCellValue("钱币");

			ExcelInfo.sheet.SetColumnWidth(CurCellIdx, 20 * 256);
			TitleCells[CurCellIdx++].SetCellValue("物品组");

			ExcelInfo.sheet.SetColumnWidth(CurCellIdx, 25 * 256);
			TitleCells[CurCellIdx++].SetCellValue("物品1");

			ExcelInfo.sheet.SetColumnWidth(CurCellIdx, 25 * 256);
			TitleCells[CurCellIdx++].SetCellValue("物品2");

			ExcelInfo.sheet.SetColumnWidth(CurCellIdx, 25 * 256);
			TitleCells[CurCellIdx++].SetCellValue("物品3");

			ExcelInfo.sheet.SetColumnWidth(CurCellIdx, 25 * 256);
			TitleCells[CurCellIdx++].SetCellValue("物品4");

			TitleCells[CurCellIdx++].SetCellValue("灵气");
			TitleCells[CurCellIdx++].SetCellValue("仙豆");
			TitleCells[CurCellIdx++].SetCellValue("龙果");
			TitleCells[CurCellIdx++].SetCellValue("仙桃");
			TitleCells[CurCellIdx++].SetCellValue("珍珠");


			TitleCells[CurCellIdx++].SetCellValue("满足成就点数");
			TitleCells[CurCellIdx++].SetCellValue("满足完成成就");
			TitleCells[CurCellIdx++].SetCellValue("满足势力等级");
			TitleCells[CurCellIdx++].SetCellValue("满足个人战比武等级");
			TitleCells[CurCellIdx++].SetCellValue("满足车轮战比武等级");
			TitleCells[CurCellIdx++].SetCellValue("满足升龙谷等级");
			TitleCells[CurCellIdx++].SetCellValue("满足白鲸湖等级");
			TitleCells[CurCellIdx++].SetCellValue("满足银河遗迹等级");
			TitleCells[CurCellIdx++].SetCellValue("限购设置");
			#endregion


			#region 输出内容
			FileCache.Data.ItemBuyPrice.ForEach(Info =>
			{
				#region	初始化
				var CurRow = MainSheet.CreateRow(Info.Index + 1);

				var CurCells = new List<ICell>();
				for (int i = 0; i <= 30; i++) CurCells.Add(this.ExcelInfo.CreateCell(CurRow, i));

				CurCellIdx = 0;
				#endregion


				CurCells[CurCellIdx++].SetCellValue(Info.Alias);
				CurCells[CurCellIdx++].SetCellValue(new MoneyConvert(Info.Money).ToString(false));

				if (Info.RequiredItembrand is null) CurCellIdx++;
				else
				{
					//搜索对象
					var ItemBrand = FileCache.Data.ItemBrand[Info.RequiredItembrand];
					var ItemTooltip = FileCache.Data.ItemBrandTooltip[ItemBrand.ID, (byte)Info.RequiredItembrandConditionType];

					//物品组信息 (tooltip获取出现问题会导致输出异常)
					var ItemBrandInfo = ItemTooltip?.NameText() ?? Info.RequiredItembrand;
					CurCells[CurCellIdx++].SetCellValue(ItemBrandInfo);
				}


				#region 获取兑换物品信息
				void GetRequiredItem(string RequiredItem, short RequiredItemCount)
				{
					if (RequiredItem != null)
					{
						string ItemName = RequiredItem.GetItemInfo()?.NameText() ?? Info.RequiredItem1;
						CurCells[CurCellIdx].SetCellValue($"{ItemName} {RequiredItemCount}个");
					}

					CurCellIdx++;
				}

				GetRequiredItem(Info.RequiredItem1, Info.RequiredItemCount1);
				GetRequiredItem(Info.RequiredItem2, Info.RequiredItemCount2);
				GetRequiredItem(Info.RequiredItem3, Info.RequiredItemCount3);
				GetRequiredItem(Info.RequiredItem4, Info.RequiredItemCount4);
				#endregion


				CurCells[CurCellIdx++].SetCellValue(Info.RequiredFactionScore);
				CurCells[CurCellIdx++].SetCellValue(Info.RequiredDuelPoint);
				CurCells[CurCellIdx++].SetCellValue(Info.RequiredPartyBattlePoint);
				CurCells[CurCellIdx++].SetCellValue(Info.RequiredFieldPlayPoint);
				CurCells[CurCellIdx++].SetCellValue(Info.RequiredLifeContentsPoint);
				CurCells[CurCellIdx++].SetCellValue(Info.RequiredAchievementScore);

				#region 获取成就名称
				string AchievementName = null;
				if (Info.RequiredAchievementId != 0) AchievementName = FileCache.Data.Achievement.Find(o => o.ID == Info.RequiredAchievementId && o.Step == Info.RequiredAchievementStepMin)?.NameText();
				CurCells[CurCellIdx++].SetCellValue(AchievementName);
				#endregion

				CurCells[CurCellIdx++].SetCellValue(Info.FactionLevel);
				CurCells[CurCellIdx++].SetCellValue(Info.CheckSoloDuelGrade);
				CurCells[CurCellIdx++].SetCellValue(Info.CheckTeamDuelGrade);
				CurCells[CurCellIdx++].SetCellValue(Info.CheckBattleFieldGradeOccupationWar);
				CurCells[CurCellIdx++].SetCellValue(Info.CheckBattleFieldGradeCaptureTheFlag);
				CurCells[CurCellIdx++].SetCellValue(Info.CheckBattleFieldGradeLeadTheBall);
				CurCells[CurCellIdx++].SetCellValue(Info.CheckContentQuota);
			});
			#endregion
		}
	}
}