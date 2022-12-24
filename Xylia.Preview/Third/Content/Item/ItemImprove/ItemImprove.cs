using System.Collections.Generic;
using System.Linq;

using NPOI.SS.UserModel;

using Xylia.Files;


namespace Xylia.Preview.Third.Content
{
	public class ItemImprove : OutBase
	{
		public override void CreateData()
		{
			#region 配置标题
			Dictionary<int, IRow> Rows = new();

			var TitleRow = MainSheet.CreateRow(0);
			#endregion


			
			int ColumnIdx = -1;

			//获取所有ID的集合
			foreach (var id in FileCache.Data.ItemImproveOption.Select(a => a.ID).Distinct())
			{
				ColumnIdx++;

				int RowIdx = 1;

				//获取随等级提高的选项对象集合
				var OptionLevel = FileCache.Data.ItemImproveOption.Where(a => a.ID == id).ToList();
				foreach (var option in OptionLevel)
				{
					//获取行位置
					IRow CurRow = null;													   

					int CurRowIdx = RowIdx++;
					if (Rows.ContainsKey(CurRowIdx)) CurRow = Rows[CurRowIdx];
					else Rows.Add(CurRowIdx, CurRow = MainSheet.CreateRow(CurRowIdx));

					CurRow.CreateCell(ColumnIdx, option.ToString().CutText());
				}
			}
		}
	}
}