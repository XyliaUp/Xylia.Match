using Xylia.Extension;
using Xylia.Files;
using Xylia.Files.Excel;
using Xylia.Preview.Data.Record;


namespace Xylia.Preview.Third.Content
{
	/// <summary>
	/// 输出物品分解数据
	/// </summary>
	public class ItemDecompose : OutBase
	{
		public override string SheetName => "分解数据";

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

			TitleRow.AddCell("分解物1");
			TitleRow.AddCell("分解物2");
			TitleRow.AddCell("分解物3");
			TitleRow.AddCell("分解物4");
			TitleRow.AddCell("分解物5");
			TitleRow.AddCell("分解物6");
			TitleRow.AddCell("分解物7");
			TitleRow.AddCell("分解物8");
			#endregion


			#region 配置内容
			int RowIdx = 1;
			FileCache.Data.Item.ForEach(Info =>
			{
				//跳过奖励类型
				if (Info.Type == Item.ItemType.Grocery && Info.UnsealAcquireItem1 == null)
					return;

				//判断是否可以分解
				if (!Info.ContainsAttribute("decompose-reward-1", out string DecomposeReward1))
					return;


				var Reward = FileCache.Data.Reward[DecomposeReward1];
				var CurRow = this.ExcelInfo.CreateRow(RowIdx++);
				CurRow.AddCell(Info.ID);
				CurRow.AddCell(Info.Alias);
				CurRow.AddCell(Info.NameText());

				for (int idx = 1; idx <= 8; idx++)
				{
					var FixedItem = Reward.Attributes["fixed-item-" + idx];
					var FixedItemMin = Reward.Attributes["fixed-item-min-" + idx].ConvertToInt();
					var FixedItemMax= Reward.Attributes["fixed-item-max-" + idx].ConvertToInt();

					CurRow.AddCell(GetFixedItem(FixedItem, FixedItemMin, FixedItemMax));
				}
			});
			#endregion
		}

		private string GetFixedItem(string Item, int Min, int Max)
		{
			if (string.IsNullOrWhiteSpace(Item)) return null;
			else if (Min == Max) return Item.GetItemInfo().NameText() + $" {Min}个";
			else return Item.GetItemInfo().NameText() + $" {Min}~{Max}个";
		}
	}
}