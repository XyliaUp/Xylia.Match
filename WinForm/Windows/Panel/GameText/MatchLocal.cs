using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

using HZH_Controls.Forms;

using Xylia.Extension;
using Xylia.Match.Properties;
using Xylia.Match.Util;

namespace Xylia.Match.Windows.Panel
{
	public partial class MatchLocal : UserControl
	{
		public MatchLocal()
		{
			InitializeComponent();

			this.BackColor = Color.Transparent;
			Logger.Write($"启用汉化匹配模块");
		}

		private void OpenLocal(TextBox Text)
		{
			Open.Filter = @"汉化文件|local*.dat|外部汉化文件|TextData*.xml|所有文件|*.*";
			Open.RestoreDirectory = false;

			if (Open.ShowDialog() == DialogResult.OK)
			{
				Text.Text = Open.FileName;
				Logger.Write(Text.Name + "已选择汉化配置文件");
			}
		}

		public void OutLocal(string Sources, bool Mode = false)
		{
			Save.FileName = "lookupGeneral";
			Save.Filter = !Chk_OnlyNew.Checked ? "txt文件|*.txt" : "html文件|*.html";

			if (Save.ShowDialog() == DialogResult.OK)
			{
				new Thread((ThreadStart)delegate
				{
					try { new Function(Str => Xylia.Tip.SendMessage(Str)).OutLocal(Sources, Save.FileName, o => Step1.StepIndex = o, Mode); }
					catch (Exception ee) { Xylia.Tip.Message(ee.Message); }
				}).Start();
			}
		}

		private void metroButton2_Click(object sender, EventArgs e)
		{
			OpenLocal(Path_Local1);
		}

		private void metroButton1_Click(object sender, EventArgs e)
		{
			OpenLocal(Path_Local2);
		}

		private void Btn_OutLocal_1_Click(object sender, EventArgs e)
		{
			OutLocal(Path_Local1.Text,!this.checkBox1.Checked);
		}

		private void Btn_OutLocal_2_Click(object sender, EventArgs e)
		{
			OutLocal(Path_Local2.Text, !this.checkBox1.Checked);
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			string Temp = Path_Local1.Text;
			Path_Local1.Text = Path_Local2.Text;
			Path_Local2.Text = Temp;
		}

		private void MatchLocal_Load(object sender, EventArgs e)
		{
			Path_Local1.Text = Xylia.Configure.Ini.ReadValue("Out", "Path_Local1");
			Path_Local2.Text = Xylia.Configure.Ini.ReadValue("Out", "Path_Local2");


			new Thread((ThreadStart)delegate { JudgeUp(); }).Start();
		}

		#region 比对不同版本的汉化

		/// <summary>汉化比对线程</summary>
		Thread CompareThread { get; set; }

		private void Btn_End_BtnClick(object sender, EventArgs e)
		{
			if (CompareThread == null) CompareExec();
			else if (FrmDialog.ShowDialog("是否确认终止操作？", null, true) == DialogResult.OK) CompareEnd();
		}

		/// <summary>强制终止操作</summary>
		public void CompareEnd()
		{
			try
			{
				this.Invoke(new Action(() =>
				{
					CompareThread.Interrupt();
					CompareThread = null;

					Tip.SendMessage("操作已强制终止!");
					metroButton2.Enabled = metroButton1.Enabled = pictureBox1.Enabled = true;
					Btn_StartWithEnd.BtnText = "开始";
				}));
			}
			catch
			{ 
			
			}
		}

		/// <summary>
		/// 匹配开始执行
		/// </summary>
		public void CompareExec()
		{
			if (!Directory.Exists(MySet.Core.Folder_Output))
			{
				FrmTips.ShowTipsWarning("请先设置导出文件夹路径！");
				return;
			}

			if (!File.Exists(Path_Local1.Text))
			{
				FrmTips.ShowTipsError("旧版本的汉化文件不存在！");
				return;
			}

			if (!File.Exists(Path_Local2.Text))
			{
				FrmTips.ShowTipsError("新版本的汉化文件不存在！");
				return;
			}

			metroButton2.Enabled = metroButton1.Enabled = pictureBox1.Enabled = false;

			Btn_StartWithEnd.BtnText = "终止";

			CompareThread = new Thread((ThreadStart)delegate
			{
				try
				{
					Step1.StepIndex++;

					string OutPath = MySet.Core.Folder_Output + $@"\信息导出\汉化数据\{ DateTime.Now:yyyy年MM月\\dd日\\HH时mm分}.html";
					bool Status = Function.Compare(Path_Local1.Text, Path_Local2.Text, OutPath, o => Step1.StepIndex = o);

					metroButton2.Enabled = metroButton1.Enabled = pictureBox1.Enabled = true;
					Btn_StartWithEnd.BtnText = "开始";
					GC.Collect();

					this.Invoke(new Action(() =>
					{
						FrmTips.ShowTipsSuccess(Status ? "执行已经结束,请在输出目录查看" : "执行已结束，但是未发现任何变更");

						CompareThread = null;
						GC.Collect();
					}));
				}
				catch (Exception ee)
				{
					if (CompareThread != null && CompareThread.IsAlive) Xylia.Tip.Message(ee.ToString());
					CompareEnd();
				}
			});

			CompareThread.SetApartmentState(ApartmentState.STA);
			CompareThread.Start();
		}






		public static string PackageFolder = Xylia.Configure.PathDefine.MainFolder + @"Resources\Package";

		/// <summary>
		/// 判断Package资源包文件信息
		/// </summary>
		public void JudgeUp()
		{
			return;

			try
			{
				if (!Directory.Exists(PackageFolder) && FrmDialog.ShowDialog("汉化对比功能已进行更新，需要另行下载图片资源，是否立即下载？\n\n注意：不进行下载不会影响正常使用，但是会无法显示图片）", null, true) == DialogResult.OK)
				{
					Xylia.Sys.Update update = new(Url.GetUpdate, "Res_Package", new Version(0,0));
					Xylia.Update.Updater.ReleaseUpdater(update.result.downPath, PackageFolder, update.result.Content, update.result.ForceName, false, false);
				}
				else
				{
					string IniPath = PackageFolder + @"\FileInfo.ini";
					if (!File.Exists(IniPath))
					{
						Xylia.Tip.Message("版本号异常，请修复版本自述文件后再更新！");
						return;
					}

					List<string> Vers = new();
					Xylia.Configure.Ini.ReadAllKeyWithVal("Version", IniPath)
						  .Where(a => a.Key.StartsWith("version", StringComparison.InvariantCultureIgnoreCase)).ToList()
						  .ForEach(a => Vers.Add(a.Value));

					Vers.ForEach(a => Console.WriteLine(a));

					return;

					//Sys.Update update = new Sys.Update(Url.GetUpdate(), "Res_Package", Ver, Ext);

					//if (!update.result.downPath.IsNull() && FrmDialog.ShowDialog("发现资源更新，是否进行更新操作？", null, true) == DialogResult.OK)
					//{
					//        Sys.Update.ReleaseUpdater(update.result.downPath, PackageFolder, update.result.Content, update.result.ForceName, false,false);
					//}
				}
			}
			catch (Exception ee)
			{
				if (!(ee is FileNotFoundException))
				{
					Xylia.Tip.Message(ee.Message, "更新失败");
					Console.WriteLine(ee);
				}
			}
		}
		#endregion

		private void Path_Local1_TextChanged(object sender, EventArgs e)
		{
			string DefinePath = Path_Local1.Text;

			if (!DefinePath.IsNull() && File.Exists(DefinePath)) Xylia.Configure.Ini.WriteValue("Out", "Path_Local1", DefinePath);
		}

		private void Path_Local2_TextChanged(object sender, EventArgs e)
		{
			string DefinePath = Path_Local2.Text;

			if (!DefinePath.IsNull() && File.Exists(DefinePath)) Xylia.Configure.Ini.WriteValue("Out", "Path_Local2", DefinePath);
		}

		private void Open_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
		{

		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{

		}
	}
}
