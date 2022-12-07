using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

using NPOI.SS.UserModel;

using Xylia.bns.Modules.DataFormat.Dat;
using Xylia.Extension;
using Xylia.Files;
using Xylia.Files.Xml;
using Xylia.Preview.Data.Helper;
using Xylia.Preview.Properties;

using static Xylia.Extension.String;

using QuestData = Xylia.bns.Modules.Quest.Entities.Quest;


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
			#endregion

			#region 读取任务文件资源
			var Quests = new BlockingCollection<QuestData>();
			Parallel.ForEach(new BNSDat().ExportFile(ReadData.GetXmlPath(CommonPath.GameFolder)), item =>
			{
				if (item.RelativePath.Contains(@"quest\") && int.TryParse(Regex.Replace(item.RelativePath, @"[^0-9]+", ""), out int Result))
				{
					try
					{
						var QuestData = item.XmlDocument.ReadFile<QuestData>().FirstOrDefault();
						Quests.Add(QuestData);
					}
					catch
					{
						Debug.WriteLine(Result + "任务初始化失败");
						throw;
					}
				}
			});
			#endregion

			#region 读取关联副本信息
			var DungeonNameGroup = new Dictionary<string, string>(StringComparer.CurrentCultureIgnoreCase);
			foreach (var Dungeon in FileCacheData.Data.Dungeon)
			{
				var DungeonName = Dungeon.NameText();

				for (int i = 1; i <= 12; i++)
				{
					if (Dungeon.ContainsAttribute("display-quests-" + i, out string AVal) && !AVal.IsNull())
					{
						if (!DungeonNameGroup.ContainsKey(AVal)) DungeonNameGroup.Add(AVal, DungeonName);
					}
				}
			}

			foreach (var Dungeon in FileCacheData.Data.RaidDungeon)
			{
				var DungeonName = Dungeon.NameText();

				for (int i = 1; i <= 12; i++)
				{
					if (Dungeon.ContainsAttribute("display-quests-" + i, out string AVal) && !AVal.IsNull())
					{
						if (!DungeonNameGroup.ContainsKey(AVal)) DungeonNameGroup.Add(AVal, DungeonName);
					}
				}
			}
			#endregion

			#region 输出内容初始化
			IWorkbook workbook = new NPOI.XSSF.UserModel.XSSFWorkbook();
			ISheet sheet = workbook.CreateSheet("任务列表");

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
			TitleRow.AddCell("category");
			TitleRow.AddCell("content-type");
			TitleRow.AddCell("reset-type");
			TitleRow.AddCell("retired");
			TitleRow.AddCell("tutorial");
			TitleRow.AddCell("相关副本");
			#endregion

			#region 开始输出内容
			var LoadedQuestList = Quests.ToList();
			LoadedQuestList.Sort((x, y) => x.id - y.id);


			int CurProcess = 0;
			LoadedQuestList.ForEach(Quest =>
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

				if (DungeonNameGroup.ContainsKey(Quest.Alias)) TempRow.AddCell(DungeonNameGroup[Quest.Alias]);
				else TempRow.AddCell(null);
			});

			workbook.Save(Save.FileName);
			#endregion


			//最后处理
			Quests = null;
			LoadedQuestList.Clear();

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
			IWorkbook workbook = new NPOI.XSSF.UserModel.XSSFWorkbook();
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
			Tip.SendMessage("完成!");
		}
	}
}
