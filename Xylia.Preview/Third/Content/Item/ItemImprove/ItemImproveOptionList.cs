using System.Linq;

using Xylia.Files;

namespace Xylia.Preview.Third.Content
{
	public sealed class ItemImproveOptionList : OutBase
	{
		public override void CreateData()
		{
			#region 配置标题
			var TitleRow = MainSheet.CreateRow(0);
			#endregion



			//获取所有ID的集合
			int RowIdx = 1;
			var CurRow = MainSheet.CreateRow(RowIdx++);


			var ImproveId = FileCache.Data.Item[2847886, 1].Attributes["improve-id"];
			if (ImproveId is null) return;


			int Index = 1;
			var improves = FileCache.Data.ItemImprove.Where(o => o.ID == int.Parse(ImproveId) && o.SuccessOptionListId != 0);
			foreach (var improve in improves)
			{
				var optionlist = FileCache.Data.ItemImproveOptionList[improve.SuccessOptionListId];
				System.Diagnostics.Debug.WriteLine($"\n {improve.Level} 强化成功时追加第{Index++}个强化效果 ↓↓↓   重置钱币: {optionlist.DrawCostMoney1} {optionlist.DrawCostMainItem1}");


				for (int i = 1; i <= 100; i++)
				{
					var option = FileCache.Data.ItemImproveOption[optionlist.Attributes["option-" + i]];
					if (option is null) break;

					var options = FileCache.Data.ItemImproveOption.Where(o => o.ID == option.ID);
					var MaxLevelOption = options.OrderBy(o => o.Level).Last();

					System.Diagnostics.Debug.WriteLine(MaxLevelOption.ToString());

					CurRow.AddCell(MaxLevelOption.ToString());
				}
			}
		}
	}
}
