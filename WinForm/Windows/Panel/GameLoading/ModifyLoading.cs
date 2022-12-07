using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Xylia.bns.Util;
using HZH_Controls.Forms;

namespace Xylia.Match.Windows.Panel
{
	public partial class ModifyLoading : UserControl
	{
		/// <summary>
		/// 定义静态资源
		/// </summary>
		protected class Static
		{
			public static string pwd = "abcde12#";
		}


		public ModifyLoading()
		{
			InitializeComponent();
		}

		private void ucBtnFillet1_BtnClick(object sender, EventArgs e)
		{
			OpenFileDialog fileDialog = new();
			fileDialog.Filter = "过图文件|loading.pkg";

			try { fileDialog.InitialDirectory = Path.GetDirectoryName(this.metroTextBox1.Text); }
			catch { }


			if (fileDialog.ShowDialog() == DialogResult.OK)
			{
				filePath.Text = fileDialog.FileName;
			}
		}

		bool isRun = false;

		private void ucBtnFillet2_BtnClick(object sender, EventArgs e)
		{
			if (isRun) return;

			if (!File.Exists(filePath.Text))
			{
				this.Invoke(new Action(() => FrmTips.ShowTipsError("未选择文件")));
				return;
			}
			else if (Directory.Exists(metroTextBox1.Text) && new DirectoryInfo(metroTextBox1.Text).GetFiles("*.jpg").Length != 0)
			{
				FrmWithOKCancel1 frmWith = new();

				frmWith.Content = "继续操作会覆盖数据，请备份数据！如已完成，请点击确认。";

				if (frmWith.ShowDialog() != DialogResult.OK)
				{
					this.Invoke(new Action(() => FrmTips.ShowTipsSuccess("用户结束操作")));
					return;
				}
			}


			new Thread((ThreadStart)delegate
			{
				if (!Directory.Exists(metroTextBox1.Text)) Directory.CreateDirectory(metroTextBox1.Text);

				Xylia.Compress.Zip.UnCompressFile(filePath.Text, metroTextBox1.Text, Static.pwd);

				GC.Collect();
				this.Invoke(new Action(() => FrmTips.ShowTipsSuccess("已结束输出")));

			}).Start();
		}

		private void ucBtnFillet3_BtnClick(object sender, EventArgs e)
		{
			bool is64 = Path.GetFileName(filePath.Text).Contains("64");


			if (!File.Exists(filePath.Text))
			{
				Xylia.Tip.Message("没有选择文件");
				return;
			}

			new Thread((ThreadStart)delegate
			{
				Xylia.Compress.Zip.ZipDirectory(metroTextBox1.Text, filePath.Text, Static.pwd);
				this.Invoke(new Action(() => FrmTips.ShowTipsSuccess("封包完成")));
			}).Start();
		}

		private void ucBtnFillet4_BtnClick(object sender, EventArgs e)
		{
			OpenFileDialog fileDialog = new OpenFileDialog();

			fileDialog.Filter = "过图文件|local*.dat";

			if (fileDialog.ShowDialog() == DialogResult.OK)
			{
				metroTextBox1.Text = fileDialog.FileName;

				//Xylia.Configure.Ini.WriteValue("Modify", "BnsFolder");
			}
		}

		private void ModifyLocal_Load(object sender, EventArgs e)
		{
			this.filePath.Text = MySet.Core.Loading_File;
		}


		private void filePath_TextChanged(object sender, EventArgs e)
		{
			MySet.Core.Loading_File = this.filePath.Text;
			metroTextBox1.Text = Path.GetDirectoryName(this.filePath.Text) + @"\LoadingImages";
		}
	}
}
