using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using NPOI.SS.UserModel;

using Xylia.bns.Modules.DataFormat.BinData.Handle.Local;
using Xylia.Extension;
using Xylia.Files;
using Xylia.Match.Util.ItemMatch.Util;
using Xylia.Match.Util.Static;
using Xylia.Preview.Third;

namespace Xylia.Match.Util.ItemList
{
	/// <summary>
	/// 处理物品信息对照表
	/// </summary>
	public class ItemMatch
	{
		#region 构造
		public ItemMatch(Action<string> action)
		{
			Application.DoEvents();
			GetOutput = action;
		}
		#endregion

		#region 字段
		/// <summary>
		/// 指明是否输出表格文档
		/// </summary>
		public bool UseExcel = false;
		public string Folder_Output = null;

		/// <summary>
		/// 汉化配对失败时，也输出配置
		/// </summary>
		public bool OutWhenErrorLocal = false;


		private readonly Action<string> GetOutput = null;

		public Structs.FilePath File = new();

		public List<int> Old = null;

		public static Color Default_Font, DefaultColor = new();

		public Read ReadInfo;
		#endregion



		#region 方法
		public static void CheckFile(string Path)
		{
			if (System.IO.File.Exists(Path)) return;

			FileStream Creat = new(Path, FileMode.Create);
			Creat.Close();
		}

		/// <summary>
		/// 快速匹配函数
		/// </summary>
		/// <param name="StartTime"></param>
		public void StartMatch_Fast(DateTime StartTime)
		{
			#region 初始化
			if (Folder_Output.IsNull()) throw new Exception("输出文件夹异常");
			if (StartTime == default) StartTime = DateTime.Now;

			//文件夹路径
			File.Directory = Folder_Output + $@"\信息导出\物品列表\{ StartTime:yyyy年MM月\\dd日\\HH时mm分}";

			//创建文件夹
			Directory.CreateDirectory(File.Directory);

			//CHV文件存储路径
			File.Backup = File.Directory + $@"\{ StartTime:yyyy-MM-dd HH-mm}.chv";

			//失败记录存储路径
			File.Failure = File.Directory + @"\未汉化道具.txt";

			//数据存储路径
			File.PlainTXT = File.Directory + @"\导出数据." + (UseExcel ? "xlsx" : "txt");

			CheckFile(File.PlainTXT);
			CheckFile(File.Backup);

			StreamWriter outfile_Chv = new(File.Backup);
			foreach (var item in Old) outfile_Chv.WriteLine(item);
			Old.Clear();

			//重置异常采集集合
			File.Failures = new BlockingCollection<ItemDataInfo>();

			var Localization = this.ReadInfo.Localization;
			var Items = new BlockingCollection<ItemDataInfo>();

			//记录数据数量
			int Count = ReadInfo.XmlData.Count();
			#endregion


			#region 分析数据
			foreach (var Item in ReadInfo.XmlData)
			{
				#region 初始化
				var CurAlias = Item.Alias.Replace("SEW_", "GB_");
				bool Status = Localization.GetName2(CurAlias, Item.FID, out string Text);

				var ItemDataInfo = new ItemDataInfo()
				{
					Alias = CurAlias,
					id = Item.FID,

					Text = Text,

					Info = Localization?.GetDesc(CurAlias),
					Desc = Localization?.GetDesc(CurAlias),

					Job = CurAlias.GetJob(),
				};
				#endregion

				if (!Status) File.Failures.Add(ItemDataInfo);
				if (Status || OutWhenErrorLocal) outfile_Chv.WriteLine(Item.FID);

				Items.Add(ItemDataInfo);
			}

			ReadInfo.Dispose();
			outfile_Chv.Close();
			#endregion



			#region 输出信息
			if (UseExcel) this.CreateExcel(Items);
			else this.CreateText(Items);   //以普通文本形式生成

			Items.Dispose();
			Items = null;
			#endregion

			#region 异常信息
			if (File.Failures.Count != 0)
			{
				using StreamWriter Out_Failure = new(File.Failure);

				Out_Failure.WriteLine("汉化异常道具共" + File.Failures.Count + "个");
				foreach (var Item in File.Failures) Out_Failure.WriteLine($"{Item.id,-20}   {Item.Text,-30}");
			}
			#endregion

			#region 最后处理
			TimeSpan ts = DateTime.Now - StartTime;
			GetOutput($"本次拉取数据共计{ Count }条，总耗{ ts.Minutes }分{ ts.Seconds }秒。");

			File.Failures.Dispose();
			File.Failures = null;

			GC.Collect();
			#endregion
		}




		/// <summary>
		/// 生成表格格式文件
		/// </summary>
		public void CreateExcel(IEnumerable<ItemDataInfo> Info)
		{
			IWorkbook workbook = new NPOI.XSSF.UserModel.XSSFWorkbook();
			ISheet sheet = workbook.CreateSheet("道具数据");
			ICellStyle style = workbook.CreateStyle();

			try
			{
				#region 标题
				IRow TitleRow = sheet.CreateRow(0);
				TitleRow.CreateCell(0).SetCellValue("物品代码");
				TitleRow.CreateCell(1).SetCellValue("物品名称");
				TitleRow.CreateCell(2).SetCellValue("物品标识");
				TitleRow.CreateCell(3).SetCellValue("专用职业");
				TitleRow.CreateCell(4).SetCellValue("物品描述");
				TitleRow.CreateCell(5).SetCellValue("物品信息");

				//设置单元格字体
				for (int i = 0; i <= 5; i++) TitleRow.GetCell(i).CellStyle = style;

				sheet.SetColumnWidth(0, 256 * 10);
				sheet.SetColumnWidth(1, 256 * 30);
				sheet.SetColumnWidth(2, 256 * 30);
				sheet.SetColumnWidth(3, 256 * 20);
				sheet.SetColumnWidth(4, 256 * 80);
				sheet.SetColumnWidth(5, 256 * 80);
				#endregion

				int Row = 1;
				foreach (var Item in Info)
				{
					IRow rowData = sheet.CreateRow(Row++);

					rowData.CreateCell(0).SetCellValue(Item.id);
					rowData.CreateCell(1).SetCellValue(Item.Text);
					rowData.CreateCell(2).SetCellValue(Item.Alias);
					rowData.CreateCell(3).SetCellValue(Item.Job);
					rowData.CreateCell(4).SetCellValue(Item.Desc);
					rowData.CreateCell(5).SetCellValue(Item.Info);

					for (int i = 0; i <= 5; i++) rowData.GetCell(i).CellStyle = style;
				}

				Application.DoEvents();

				//保存为Excel文件
				workbook.Save(File.PlainTXT);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		/// <summary>
		/// 生成文本格式文件
		/// </summary>
		/// <param name="Info"></param>
		public void CreateText(IEnumerable<ItemDataInfo> Info)
		{
			using StreamWriter Out_Main = new(File.PlainTXT);
			foreach (var Item in Info)
			{
				//Out_Main.WriteLine(Item.id + "," + Item.Text);
				//continue;

				string Message = null;
				string IdTxt = $"{ Item.id,-15 }";
				if (IdTxt.Length > 15) IdTxt += "    ";

				string ResultTxt = $"{ Item.Text,-20 }";
				if (ResultTxt.Length > 15) ResultTxt += "    ";

				Message = Item.Text.IsNull() ? $"{ IdTxt }  暂无汉化 ({ Item.Alias })"
					: $"{ IdTxt }{ ResultTxt }{ "别名：" + Item.Alias }";

				#region 获取道具的标识和文本
				var ExtraInfo = new List<KeyValuePair<string, string>>()
				{
					 new KeyValuePair<string, string>("职业" ,Item.Job),
					 new KeyValuePair<string, string>("描述" ,Item.Desc),
					 new KeyValuePair<string, string>("信息" ,Item.Info),
				};

				foreach (var t in ExtraInfo.Where(t => !string.IsNullOrWhiteSpace(t.Value)))
				{
					Message += $"\t{t.Key}：{t.Value}";
				}
				#endregion

				Out_Main.WriteLine(Message.Replace("<br>", "\r\n"));
			}
		}
		#endregion
	}
}
