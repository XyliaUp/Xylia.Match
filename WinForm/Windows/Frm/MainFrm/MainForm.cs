using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

using HZH_Controls.Forms;

using Xylia.Extension;
using Xylia.Match.Properties;
using Xylia.Match.Util;
using Xylia.Match.Windows.Panel;
using Xylia.Windows.Forms;

namespace Xylia.Match.Windows
{
	public partial class MainForm : FrmWithTitle
	{
		#region 字段
		readonly SubGroup subGroup = null;

		readonly TipMessage TipMessage = new();
		#endregion

		#region 构造
		public MainForm()
		{
			this.InitializeComponent();

			this.ShowInTaskbar = true;
			this.Panel.Dock = DockStyle.Top;

			CheckForIllegalCrossThreadCalls = false;

			this.Memory.BackColor = tvMenu.BackColor;
			this.Title = $"{ Program.Title} ({ AssemblyEx.BuildDate:yyyyMMdd})";

			#region 载入页签
			this.subGroup = new SubGroup();

			List<ControlPage> ControlPages = new();
			ControlPages.Add(new("道具获取", subGroup.matchProp));
			ControlPages.Add(new("任务查询", subGroup.matchQuest));
			ControlPages.Add(new("图标生成", subGroup.matchICON));
			ControlPages.Add(new("汉化对比", subGroup.matchLocal));
			ControlPages.Add(new("汉化修改", subGroup.modifyLocal));

			//if (HideDebugInfo) this.tvMenu.Nodes.Add("Open_BnsTool", "BnsTool");
			ControlPages.Add(new("Pak功能", subGroup.PakExtract));


			foreach (var page in ControlPages) this.tvMenu.Nodes.Add(page.Key, page.Text);

			this.tvMenu.AfterSelect += new TreeViewEventHandler((o, e) =>
			{
				var key = e.Node.Name.Trim();

				var page = ControlPages.Find(page => page.Key == key);
				if (page is null) FrmTips.ShowTipsError("选择的菜单项尚未定义功能，请您选择其他选项。");
				else AddControl(page.Content);
			});
			#endregion
		}
		#endregion



		private void MainForm2_Shown(object sender, EventArgs e)
		{
			Thread thread = new(act =>
			{
				Xylia.Match.Load.GetNotice();
				this.CheckUpdate();
			});

			thread.SetApartmentState(ApartmentState.STA);
			thread.Start();


			MySet.ClearMemory();


			if (ExistLock == false)
			{
				Tip.Message("您正在非开发环境下运行待评估版本，可能发生异常错误\n\n如遇崩溃问题请及时上报日志文件");
			}
		}

		private void MainForm2_FormClosing(object sender, FormClosingEventArgs e)
		{
			FrmWithOKCancel1 frmWith = new()
			{
				Content = "您正在关闭应用程序，是否确认这么做吗？"
			};

			if (frmWith.ShowDialog() != DialogResult.OK)
			{
				e.Cancel = true;
				return;
			}


			this.Hide();
			Logger.Write("用户退出主程序");

			Environment.Exit(0);
		}

		private void GetUsedMemory_Tick(object sender, EventArgs e)
		{
			string Msg = Xylia.Sys.lib.GetProcessUsedMemory();
			Memory.ForeColor = Msg.Contains("GB") ? Color.Red : Color.MediumAquamarine;
			Memory.Text = $"   内存 { Msg }";
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			Logger.Show();
		}

		private void MainForm2_LocationChanged(object sender, EventArgs e)
		{
			FrmAnchorTips.CloseLastTip();
		}

		private void MainForm2_KeyDown(object sender, KeyEventArgs e)
		{
			switch (tvMenu.SelectedNode.Name.Trim())
			{
				case "Open_MatchQuest":
				{
					((QuestMatch)subGroup.matchQuest).MatchQuest_KeyDown(e.KeyCode); break;
				}
			}
		}

		private void OpenRes_Click(object sender, EventArgs e)
		{
			Xylia.Sys.lib.OpenForm(new DownRes(Url.PublicConfig));
		}

		private void Tips_Tick(object sender, EventArgs e)
		{
			string Tip = TipMessage.GetNextTip;

			//保证文本不会重复
			while (Tip == Footer.Text) Tip = TipMessage.GetNextTip;
			Footer.Text = Tip;
		}

		private void Footer_Click(object sender, EventArgs e)
		{
			if (!Tips.Enabled) Tips.Enabled = true;
		}

		private void MainForm_DragDrop(object sender, DragEventArgs e)
		{
			string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
			if (files.Length == 0) return;

			for (int i = 0; i < files.Length; i++)
			{
				if (files[i].ToLower().EndsWith(".chv"))
				{
					Tip.Message("Chv转储文件已选择！");
					continue;
				}
				else if (files[i].ToLower().EndsWith(".dat") && files[i].ToLower().Contains("local")) continue;
				else Tip.Stop("暂不支持的文件类型");
			}
		}

		private void MainForm_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop, false)) e.Effect = DragDropEffects.All;
		}

		private void OpenFolder_Click(object sender, EventArgs e)
		{
			Process.Start("explorer", MySet.Core.Folder_Output);
		}

		private void Set_Click(object sender, EventArgs e)
		{
			var Set = new Forms.PublicSet(Info => { });
			if (Set.ShowDialog() == DialogResult.OK)
			{
				MySet.Core.Folder_Game_Bns = Xylia.Configure.Ini.ReadValue("Game", "BnsFolder");
				MySet.Core.Folder_Output = Xylia.Configure.Ini.ReadValue("Out", "MainFolder");

				//同步显示
				if (subGroup.matchProp != null)
				{
					((MatchProp)subGroup.matchProp).GRoot_Path.Text = MySet.Core.Folder_Game_Bns;
				}
			}
		}

		private void MainForm2_SizeChanged(object sender, EventArgs e)
		{
			this.Panel.Height = this.Height - 100;

			this.Footer.Location = new Point(this.Footer.Location.X, this.Height - this.Footer.Height - 5);
			this.Memory.Location = new Point(this.Memory.Location.X, this.Height - this.Memory.Height - 5);
		}

		private void Panel_SizeChanged(object sender, EventArgs e)
		{
			foreach (Control c in this.Panel.Controls)
			{
				if (c is UserControl || c is Form)
				{
					c.Width = this.Panel.Width;
					c.Height = this.Panel.Height;
				}
			}
		}

		private void Btn_update_Click(object sender, EventArgs e)
		{
			this.CheckUpdate(true);
		}

		private void Btn_AboutUs_Click(object sender, EventArgs e)
		{
			new Forms.AboutUs().Show();
		}

		private void ClearResource_Tick(object sender, EventArgs e)
		{
			MySet.ClearMemory();
		}

		#region 调试功能
		private int click = 0;
		private DateTime lastClickTime = DateTime.MinValue;

		private void Memory_Click(object sender, EventArgs e)
		{
			DateTime now = DateTime.Now;

			// 两次点击间隔小于100毫秒时，算连续点击
			if ((now - lastClickTime).TotalMilliseconds <= 1900)
			{
				click++;
				if (click >= 5)
				{
					click = 0;
				}
			}
			else click = 1;

			lastClickTime = now;
		}
		#endregion




		private void AddControl(Control c)
		{
			this.Panel.Controls.Clear();
			this.Panel.Controls.Add(c);
		}


		/// <summary>
		/// 是否存在测试文件
		/// </summary>
		private bool? ExistLock
		{
			get
			{
				if (Program.GetVerType != VerType.开发版本) return null;

				return File.Exists("Xylia.Match.lock");
			}
		}

		/// <summary>
		/// 检查是否存在更新
		/// </summary>
		public void CheckUpdate(bool Show = true)
		{
			if (new Util.Update().Compare(Show))
			{
				Btn_update.Visible = true;
				Btn_update.Image = Xylia.Match.Properties.Resx.Progrm.Update24_Orange;
				toolTip.SetToolTip(Btn_update, "发现新版本更新");
			}
			else
			{
				Btn_update.Image = Xylia.Match.Properties.Resx.Progrm.Update24_Pink;
				toolTip.SetToolTip(Btn_update, "未发现版本更新");
			}
		}
	}
}