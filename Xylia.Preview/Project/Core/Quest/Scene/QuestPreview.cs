using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using CSCore.SoundOut;

using Xylia.bns.Modules.Quest.Enums;
using Xylia.Extension;

using QuestData = Xylia.bns.Modules.Quest.Entities.Quest;

namespace Xylia.Preview.Project.Core.Quest.Preview
{
	/// <summary>
	/// 任务预览组件
	/// </summary>
	public partial class QuestPreview : Form
	{
		#region 构造
		public QuestPreview()
		{
			InitializeComponent();
			this.MaximumSize = new(2000, 1000);
		}
		public QuestPreview(QuestData QuestData) : this() => this.LoadData(QuestData);
		#endregion


		#region 字段
		public WaveOut SoundOut = new() { Latency = 100 };

		/// <summary>
		/// 测试模式
		/// </summary>
		public static bool TestMode = false;
		#endregion



		#region 界面方法
		private void SwitchTestMode_Click(object sender, EventArgs e) => TestMode = this.SwitchTestMode.Checked;

		private void QuestPreview_Load(object sender, EventArgs e)
		{
			this.SwitchTestMode.Checked = TestMode;
			this.Refresh();
		}

		private void QuestPreview_FormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				if (this.SoundOut.PlaybackState != PlaybackState.Stopped)
					this.SoundOut.Stop();

				this.SoundOut.Dispose();
				this.SoundOut = null;
			}
			catch
			{

			}	
		}

		public override void Refresh()
		{
			#region 处理内容组
			int LocY = QuestName.Bottom + 10;
			foreach (var s in this.Controls.OfType<GroupBase>())
			{
				if (!s.Visible) continue;

				s.Location = new Point(0, LocY);
				//s.Width = this.Width - 15;

				LocY = s.Bottom;
			}
			#endregion

			this.Height = LocY + 45;
			base.Refresh();
		}
		#endregion


		#region 方法
		QuestData _data;

		public void LoadData(QuestData value)
		{
			_data = value;
			if (value is null) return;


			this.QuestName.Text = value.Name2.GetText();
			this.QuestName.ForeColor = value.ForeColor;
			this.Quest_ICON.Image = value.Icon;
			this.Quest_Group.Text = value.Group2.GetText();

			//处理内容部分
			if (value.Desc is null) this.DescInfo.Visible = false;
			else this.DescInfo.Text = value.Desc.GetText();


			this.TaskInfo.LoadData(value, SoundOut);
			this.RewardInfo.LoadData(value);

			if (value.Category == Category.Dungeon)
			{
				this.Quest_ICON.SetToolTip("此类型为副本进度任务");

				List<string> DifficultyType = new();
				if (value.ProgressDifficultyType1) DifficultyType.Add("入门");
				if (value.ProgressDifficultyType2) DifficultyType.Add("普通");
				if (value.ProgressDifficultyType3) DifficultyType.Add("熟练");

				this.QuestName.Text += $" [{DifficultyType.Aggregate((sum, now) => sum + "/" + now)}]";
			}
		}

		private void OpenFileData_Click(object sender, EventArgs e)
		{
			var Editor = new Crypto_Notepad.MainForm();

			//修改内容委托
			Editor.SaveContent += (o, a) =>
			{
				//ReadTest.Dat.XML_Content[filePath].Data = Encoding.UTF8.GetBytes(Editor.Content);

				////存储内容
				//new BNSDat().CompressFiles(DataPath, filePath, Encoding.UTF8.GetBytes(Editor.Content), false);

				//FrmTips.ShowTipsSuccess("修改成功");
			};

			Editor.Content = _data.OwnerDocument.Text();
			Editor.Show();
		}
		#endregion
	}
}