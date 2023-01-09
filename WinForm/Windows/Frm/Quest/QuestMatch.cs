using System;
using System.Threading;
using System.Windows.Forms;

using Xylia.Preview.Data.Helper;
using Xylia.Preview.Project.Core.Quest.Preview;

namespace Xylia.Match.Windows.Panel
{
	public partial class QuestMatch : UserControl
	{
		#region 构造
		public QuestMatch()
		{
			InitializeComponent();
			//Logger.Write($"启用任务模块");
			CheckForIllegalCrossThreadCalls = false;

			//读取上一次的选择
			Num.Num = MySet.Core.Quest_Select ?? 1;
		}
		#endregion


		#region 重做方法
		/// <summary>
		/// 绑定快捷键
		/// </summary>
		/// <param name="keys"></param>
		public void MatchQuest_KeyDown(Keys keys)
		{
			switch (keys)
			{
				case Keys.Up: Num.Num++; break;
				case Keys.Down: Num.Num--; break;

				case Keys.Enter: metroButton1_Click(null, null); break;
			}
		}

		private void metroButton1_Click(object sender, EventArgs e)
		{
			if (Num.Num <= 0) return;

			var thread = new Thread((ThreadStart)delegate
			{
				var temp = ReadQuestData.GetQuestData((int)Num.Num);
				if (temp is null) return;

				//创建界面
				
				new QuestPreview(temp).ShowDialog();
			});

			thread.SetApartmentState(ApartmentState.STA);
			thread.Start();
		}

		private void Num_NumChanged(object sender, EventArgs e) => MySet.Core.Quest_Select = (int)this.Num.Num;

		private void Btn_QuestList_Click(object sender, EventArgs e) => new QuestSelect().ShowDialog();

		private void Btn_QusetEpic_Click(object sender, EventArgs e) => new GUI.Epic().Show();

		private void Output_QuestList_Click(object sender, EventArgs e) => Xylia.Preview.Third.Content.Quest.QuestList();

		private void Output_EpicList_Click(object sender, EventArgs e) => Xylia.Preview.Third.Content.Quest.EpicList();
		#endregion
	}
}