using System.Linq;
using System.Windows.Forms;

using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

using Xylia.Files;
using Xylia.Preview.Common.Cast;
using Xylia.Preview.Data.Helper;


namespace Xylia.Preview.Third.Content
{
	public static class Quest
	{
		/// <summary>
		/// 输出任务列表
		/// </summary>
		public static void QuestList()
		{
			#region	初始化
			var Save = new SaveFileDialog
			{
				Filter = "表格文件|*.xlsx",
				FileName = "任务列表"
			};

			if (Save.ShowDialog() != DialogResult.OK) return;

			ReadQuestData.GetQuests();
			#endregion

			#region 输出内容初始化
			IWorkbook workbook = new XSSFWorkbook();
			ISheet sheet = workbook.CreateSheet("任务列表");

			//创建字体通用风格
			var style = workbook.CreateStyle();

			IRow TitleRow = sheet.CreateRow(0);
			TitleRow.RowStyle = style;

			sheet.SetColumnWidth(0, 10 * 256);
			sheet.SetColumnWidth(1, 15 * 256);
			sheet.SetColumnWidth(2, 30 * 256);
			sheet.SetColumnWidth(3, 25 * 256);
			sheet.SetColumnWidth(4, 10 * 256);
			sheet.SetColumnWidth(5, 10 * 256);
			sheet.SetColumnWidth(6, 10 * 256);
			sheet.SetColumnWidth(7, 10 * 256);
			sheet.SetColumnWidth(8, 10 * 256);
			sheet.SetColumnWidth(9, 35 * 256);

			//创建行基本信息(标题行）
			TitleRow.AddCell("任务序号");
			TitleRow.AddCell("任务别名");
			TitleRow.AddCell("任务名称");
			TitleRow.AddCell("group");
			TitleRow.AddCell("category");
			TitleRow.AddCell("content-type");
			TitleRow.AddCell("reset-type");
			TitleRow.AddCell("retired");
			TitleRow.AddCell("tutorial");
			TitleRow.AddCell("相关副本");
			#endregion

			#region 开始输出内容
			int CurProcess = 0;
			foreach (var Quest in FileCache.Data.Quest.Values.OrderBy(o => o.id))
			{
				IRow TempRow = sheet.CreateRow(++CurProcess);
				TempRow.RowStyle = style;

				//创建行信息
				TempRow.AddCell(Quest.id);
				TempRow.AddCell(Quest.Alias);
				TempRow.AddCell(Quest.Name2.GetText());
				TempRow.AddCell(Quest.Group2.GetText());
				TempRow.AddCell(Quest.Category);
				TempRow.AddCell(Quest.ContentType);
				TempRow.AddCell(Quest.ResetType);
				TempRow.AddCell(Quest.Retired);
				TempRow.AddCell(Quest.Tutorial);
				TempRow.AddCell(Quest.AttractionInfo.GetName());
			}

			workbook.Save(Save.FileName);
			#endregion

			Tip.SendMessage("完成!");
		}

		public static void EpicList()
		{
			#region	初始化
			var Save = new SaveFileDialog
			{
				Filter = "表格文件|*.xlsx",
				FileName = "主线任务列表"
			};

			if (Save.ShowDialog() != DialogResult.OK) return;
			#endregion

			#region 输出内容初始化
			IWorkbook workbook = new XSSFWorkbook();
			ISheet sheet = workbook.CreateSheet("主线任务");

			//创建字体通用风格
			var style = workbook.CreateStyle();

			IRow TitleRow = sheet.CreateRow(0);
			TitleRow.RowStyle = style;

			sheet.SetColumnWidth(0, 10 * 256);
			sheet.SetColumnWidth(1, 15 * 256);
			sheet.SetColumnWidth(2, 30 * 256);
			sheet.SetColumnWidth(3, 25 * 256);

			//创建行基本信息(标题行）
			TitleRow.AddCell("任务序号");
			TitleRow.AddCell("任务别名");
			TitleRow.AddCell("任务名称");
			TitleRow.AddCell("group");
			#endregion

			#region 开始输出内容
			int CurRow = 0;
			ReadQuestData.GetEpicInfo(data =>
			{
				#region 创建节点
				string Group2 = data.Group2.GetText();
				string QuestName = data.Name2.GetText();

				IRow TempRow = sheet.CreateRow(++CurRow);
				TempRow.RowStyle = style;

				//创建行信息
				TempRow.AddCell(data.id);
				TempRow.AddCell(data.Alias);
				TempRow.AddCell(data.Name2.GetText());
				TempRow.AddCell(data.Group2.GetText());
				#endregion
			});

			workbook.Save(Save.FileName);
			#endregion

			Tip.SendMessage("完成!");
		}
	}
}