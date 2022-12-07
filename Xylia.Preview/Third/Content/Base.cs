using System;
using System.Windows.Forms;

using HZH_Controls.Forms;

using NPOI.SS.UserModel;

using Xylia.Files.Excel;

namespace Xylia.Preview.Third.Content
{
	public abstract class OutBase
	{
		#region 字段
		public readonly ExcelInfo ExcelInfo = null;

		public virtual string SheetName => this.GetType().Name;

		/// <summary>
		/// 当前执行的工作表
		/// </summary>
		public ISheet MainSheet => ExcelInfo?.sheet;
		#endregion


		#region 构造
		public OutBase()
		{
			#region	初始化
			FrmTips.ShowTipsWarning("此功能基于已生成数据进行二次处理，请留意版本是否准确", 3800);

			var Save = new SaveFileDialog
			{
				Filter = "表格文件|*.xlsx",
				FileName = $"{SheetName} ({ DateTime.Now:yy年MM月}).xlsx",
			};

			if (Save.ShowDialog() != DialogResult.OK) return;

			FrmTips.ShowTipsSuccess("开始执行，请等待结束提示");
			#endregion


			#region 核心方法
			this.ExcelInfo = new ExcelInfo(SheetName);

			//创建数据
			this.CreateData();

			this.ExcelInfo.Save(Save.FileName);
			#endregion


			System.Diagnostics.Debug.WriteLine("[debug] 执行已完成");

			#region 清理资源
			FrmTips.ShowTipsWarning("执行已完成");

			this.ExcelInfo.Dispose();
			this.ExcelInfo = null;

			GC.Collect();
			#endregion
		}
		#endregion


		#region 方法
		/// <summary>
		/// 创建数据
		/// </summary>
		public virtual void CreateData()
		{

		}
		#endregion
	}
}
