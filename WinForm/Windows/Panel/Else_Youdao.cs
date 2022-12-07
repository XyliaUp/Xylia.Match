
using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Xylia.Dev.GetUrl
{
	public partial class Form1 : UserControl
	{
		public Form1()
		{
			InitializeComponent();
			CheckForIllegalCrossThreadCalls = false;
		}

		string DownPath = null;

		private void Clear()
		{
			Prog.Visible = Percent.Visible = Btn_Download.Visible = false;
			label3.Text = "文件信息";
			textBox3.Text = "";
		}

		Xylia.Net.Youdao.NoteShare.Info GetInfo = new Xylia.Net.Youdao.NoteShare.Info();


		private void Btn_Start_Click(object sender, EventArgs e)
		{
			Clear();

			Regex re = new Regex(@"(?<url>http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?)");
			MatchCollection mc = re.Matches(textBox1.Text);

			if (mc.Count == 1)
			{
				new Xylia.Net.Youdao.NoteShare(mc[0].Result("${url}"), checkBox1.Checked, Info => { GetInfo = Info; label3.Text = string.Format("文件名称：{0}\n\n浏览次数：{1}                     文件大小：{2}\n", Info.FileName, Info.BrowseTimes, Info.FileSize); },

				 (State, Key, ID) =>
				 {
					 if (State)
					 {
						 textBox3.Text = Key;
						 DownPath = ID == null ? Xylia.Net.Youdao.NoteShare.UrlCombine(Key, textBox2.Text = ID) : Key;

						 textBox2.Text = ID;
						 Btn_Download.Visible = true;
					 }
				 }
			 );
			}
			else
			{
				Tip.Message("无效的链接信息");
			}
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(textBox3.Text);
			MessageBox.Show("粘贴至剪贴板成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}


		private void TextBox1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			textBox1.SelectAll();
		}

		private void TextBox3_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			textBox3.SelectAll();
		}

		private void Btn_Download_Click(object sender, EventArgs e)
		{
			Invoke(new Action(() =>
			{
				Open.FileName = GetInfo.FileName;


				Prog.Visible = Percent.Visible = true;

				try { Open.Filter = "其他文件 | *" + Path.GetExtension(Open.FileName); }
				catch { }

				if (Open.ShowDialog() == DialogResult.OK)
				{
					try
					{
						Prog.Visible = true;
						Xylia.Net.Download.Http.DownloadFile(new Uri(DownPath), Open.FileName);
					}
					catch (Exception ee)
					{
						Prog.Visible = false;

						MessageBox.Show(ee.Message);
						MessageBox.Show(DownPath);
					}
				}
			}));
		}

		private void CheckBox1_CheckedChanged(object sender, EventArgs e)
		{
			textBox2.Visible = Copy2.Visible = checkBox1.Checked;
		}


		private void Button1_Click_1(object sender, EventArgs e)
		{

		}

		private void ucBtnExt1_BtnClick(object sender, EventArgs e)
		{

		}
	}
}
