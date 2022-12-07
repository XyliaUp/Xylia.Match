using System;
using System.IO;
using System.Windows.Forms;

using Xylia.bns.Read.Util;

namespace Xylia.Match.Windows.Forms
{
	public partial class PublicSet : MetroFramework.Forms.MetroForm
	{
		/// <summary>
		/// 是否窗体正在启动
		/// </summary>
		private bool IsStarting { get; set; } = false;


		public Action<string> GetAction = null;


		public PublicSet(Action<string> action, int StartIndex = 0)
		{
			GetAction = action;

			InitializeComponent();
			this.TopMost = true;


			try { SettingsTabControl.SelectedIndex = StartIndex; }
			catch { }
		}



		/* Form Events */
		private void SettingsForm_Load(object sender, EventArgs e)
		{
			this.IsStarting = true;

			GRoot_Path.Text = MySet.Core.Folder_Game_Bns;
			Faster_Folder_Path.Text = MySet.Core.Folder_Output;

			GetRegion();

			this.IsStarting = false;
		}



		private void Faster_Folder_Btn_Click(object sender, EventArgs e)
		{
			Folder.SelectedPath = Faster_Folder_Path.Text;
			if (Folder.ShowDialog() == DialogResult.OK)
			{
				Faster_Folder_Path.Text = Path.GetFullPath(Folder.SelectedPath);
			}
		}

		/// <summary>
		/// 获取客户端区域
		/// </summary>
		public void GetRegion()
		{
			var RegionInfo = DataPathes.GetRegion(GRoot_Path.Text);
			if (RegionInfo != null)
			{
				lbl_Region.Text = "客户端所属区域：" + RegionInfo;
				lbl_Region.Visible = true;
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Folder.Description = "请选择游戏根目录（即包含bin、TCLS等的文件夹）";
			Folder.SelectedPath = GRoot_Path.Text;

			if (Folder.ShowDialog() == DialogResult.OK)
			{
				GRoot_Path.Text = Folder.SelectedPath;


				GetAction?.Invoke(Path.GetFullPath(Folder.SelectedPath));

				//获取客户端区域
				this.GetRegion();

				Folder.Description = "";
			}
		}


		private void SettingsForm_MouseEnter(object sender, EventArgs e)
		{
			this.TopMost = false;
		}


		private void SettingsTabControl_SelectedIndexChanged(object sender, EventArgs e)
		{
			var TabPage = SettingsTabControl.TabPages[SettingsTabControl.SelectedIndex];
		}


		private void PublicSet_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.DialogResult = DialogResult.OK;
		}


		private void GRoot_Path_TextChanged(object sender, EventArgs e)
		{
			var Txt = ((TextBox)sender).Text;

			if (Directory.Exists(Txt) && !this.IsStarting)
			{
				MySet.Core.Folder_Game_Bns = Txt;

				TitleChange();
			}
		}

		private void Faster_Folder_Path_TextChanged(object sender, EventArgs e)
		{
			var Txt = ((TextBox)sender).Text;

			if (Directory.Exists(Txt) && !this.IsStarting)
			{
				MySet.Core.Folder_Output = Txt;
				TitleChange();
			}
		}


		/// <summary>
		/// 设置定时器
		/// </summary>
		Timer Timer = new Timer() 
		{ 
			Interval = 3000 
		};

		public void TitleChange(string Text = "设置  (保存成功!)")
		{
			this.Text = Text;
			this.Refresh();

			Timer.Tick += new EventHandler((o, e) =>
			{
				this.Text = $"设置";
				this.Refresh();
			});

			Timer.Start();
		}
	}
}







