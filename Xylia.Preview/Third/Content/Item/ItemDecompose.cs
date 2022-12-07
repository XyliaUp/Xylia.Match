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
		#region 字段
		public override string SheetName => "分解数据";
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
			FileCacheData.Data.Item.ForEach(Info =>
			{
				//跳过奖励类型
				if (Info.Type == Item.ItemType.grocery && Info.UnsealAcquireItem1 == null)
					return;

				//判断是否可以分解
				if (!Info.ContainsAttribute("decompose-reward-1", out string RewardAlias))
					return;


				var RewardInfo = FileCacheData.Data.Reward.GetInfo(RewardAlias);

				var CurRow = this.ExcelInfo.CreateRow(RowIdx++);
				CurRow.AddCell(Info.ID);
				CurRow.AddCell(Info.Alias);
				CurRow.AddCell(Info.NameText());

				CurRow.AddCell(RewardInfo.FixedItemInfo1);
				CurRow.AddCell(RewardInfo.FixedItemInfo2);
				CurRow.AddCell(RewardInfo.FixedItemInfo3);
				CurRow.AddCell(RewardInfo.FixedItemInfo4);
				CurRow.AddCell(RewardInfo.FixedItemInfo5);
				CurRow.AddCell(RewardInfo.FixedItemInfo6);
				CurRow.AddCell(RewardInfo.FixedItemInfo7);
				CurRow.AddCell(RewardInfo.FixedItemInfo8);
			});
			#endregion
		}
		#endregion
	}
}
