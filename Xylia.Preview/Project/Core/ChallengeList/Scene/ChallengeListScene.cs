using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using Xylia.bns.Modules.GameData.Enums;
using Xylia.Extension;
using Xylia.Preview.Common.Extension;
using Xylia.Preview.Data.Record;
using Xylia.Preview.Project.Core.ChallengeList.Cell;


namespace Xylia.Preview.Project.RunForm
{
	public partial class ChallengeListFrm : Form
	{
		#region 字段
		public static Dictionary<ChallengeList.ChallengeTypeSeq, string> TodayChallengeType = new()
		{
			{ ChallengeList.ChallengeTypeSeq.mon, "星期一" },
			{ ChallengeList.ChallengeTypeSeq.tue, "星期二" },
			{ ChallengeList.ChallengeTypeSeq.wed, "星期三" },
			{ ChallengeList.ChallengeTypeSeq.thu, "星期四" },
			{ ChallengeList.ChallengeTypeSeq.fri, "星期五" },
			{ ChallengeList.ChallengeTypeSeq.sat, "星期六" },
			{ ChallengeList.ChallengeTypeSeq.sun, "星期日" },
		};
		


		public static DayOfWeek WeeklyResetDayOfWeek = DayOfWeek.Friday;

		public static byte DailyResetTime = 6;

		public static byte WeeklyResetTime = 6;
		#endregion


		#region 构造
		public ChallengeListFrm()
		{
			InitializeComponent();
			CheckForIllegalCrossThreadCalls = false;


			foreach (var item in TodayChallengeType) this.DaySelect.Source.Add(item.Value);
			this.DaySelect.Source.Add("本周挑战");
			this.DaySelect.SelectedIndex = 0;
		}
		#endregion


		#region 界面方法
		private void ChallengeListFrm_Load(object sender, EventArgs e)
		{

		}

		private void OutputList_Click(object sender, EventArgs e) => Execute.ThirdStart<Third.Content.ChallengeList>();
		#endregion


		#region 课题处理
		public static string GetTimeInfo(DayOfWeek DayOfWeek, DateTime TodayDate)
		{
			//获取到指定重置日期
			var DiffDay = (int)DayOfWeek - (int)TodayDate.DayOfWeek;
			if (DiffDay < 0) DiffDay += 7;


			//获取到指定重置时间的剩余时间
			var ResetTime = TodayDate.Date.AddDays(DiffDay).AddHours(DailyResetTime);
			var span = ResetTime - TodayDate;
			if (span.Days > 0) return string.Format("{0:dd}日 {0:hh}小时 {0:mm}分钟", span);
			else if (span.Hours > 0) return string.Format("{0:hh}小时 {0:mm}分钟", span);
			else if (span.Milliseconds > 0) return string.Format("{0:mm}分钟", span);
			else return "不足1分钟";
		}

		private void DaySelect_SelectedChangedEvent(object sender, EventArgs e)
		{
			var TodayDate = DateTime.Now;
			if (DaySelect.TextValue == "本周挑战")
			{
				this.RequiredTime.Text = "本周挑战<br/>剩余<image enablescale=\"true\" imagesetpath=\"00009076.RequiredLongTime_7\" scalerate =\"1.4\" />" + GetTimeInfo(WeeklyResetDayOfWeek, TodayDate);

				var Week1 = FileCache.Data.ChallengeList.Find(o => o.ChallengeType == ChallengeList.ChallengeTypeSeq.week1);
				System.Diagnostics.Trace.WriteLine(Week1.WeekStartDateTime);

				this.LoadData(ChallengeList.ChallengeTypeSeq.week1);
			}
			else
			{
				var ChallengeType = TodayChallengeType.First(o => DaySelect.TextValue == o.Value).Key;
				var ChallengeDayOfWeek = (DayOfWeek)(ChallengeType - 1);
				if (ChallengeDayOfWeek == TodayDate.DayOfWeek) this.RequiredTime.Text = $"今日挑战<br/><image enablescale=\"true\" imagesetpath=\"00009076.RequiredTime\" scalerate=\"1.4\"/>还剩" + GetTimeInfo(ChallengeDayOfWeek + 1, TodayDate);
				else
				{
					string DayInfo = ChallengeDayOfWeek == TodayDate.DayOfWeek + 1 ? "明日" : DaySelect.TextValue;
					this.RequiredTime.Text = $"距{DayInfo}挑战<br/><image enablescale=\"true\" imagesetpath=\"00009076.RequiredLongTime\" scalerate=\"1.4\"/>还剩" + GetTimeInfo(ChallengeDayOfWeek, TodayDate);
				}

				this.LoadData(ChallengeType);
			}
		}

		private void LoadData(ChallengeList.ChallengeTypeSeq ChallengeType)
		{
			TaskPanel.Controls.Remove<ChallengeCell>();

			var ChallengeList = FileCache.Data.ChallengeList.Find(o => o.ChallengeType == ChallengeType);
			if (ChallengeList is null) return;


			#region 加载任务课题
			int LocY = 0;

			for (byte Idx = 1; Idx <= 20; Idx++)
			{
				var ChallengeQuestBasic = ChallengeList.Attributes["challenge-quest-basic-" + Idx];
				var ChallengeQuestExpansion = ChallengeList.Attributes["challenge-quest-expansion-" + Idx];
				var ChallengeQuestGrade = ChallengeList.Attributes["challenge-quest-grade-" + Idx].ToEnum<ChallengeList.Grade>();
				var ChallengeQuestAttraction = ChallengeList.Attributes["challenge-quest-attraction-" + Idx];

				if (ChallengeQuestBasic is null) break;

				ChallengeCell ChallengeCell = new();
				ChallengeCell.LoadData(ChallengeQuestBasic, ChallengeQuestExpansion, ChallengeQuestGrade, ChallengeQuestAttraction);

				TaskPanel.Controls.Add(ChallengeCell);
				ChallengeCell.Location = new Point(10, LocY);
				LocY = ChallengeCell.Bottom;
			}
			#endregion

			#region 加载击杀课题
			for (byte Idx = 1; Idx <= 20; Idx++)
			{
				var ChallengeNpcDifficulty = ChallengeList.Attributes["challenge-npc-difficulty-" + Idx].ToEnum<DifficultyType>();
				var ChallengeNpcKill = ChallengeList.Attributes["challenge-npc-kill-" + Idx];
				var ChallengeNpcAttraction = ChallengeList.Attributes["challenge-npc-attraction-" + Idx];
				var ChallengeNpcGrade = ChallengeList.Attributes["challenge-npc-grade-" + Idx].ToEnum<ChallengeList.Grade>();
				var ChallengeNpcQuest = ChallengeList.Attributes["challenge-npc-quest-" + Idx];

				if (ChallengeNpcKill is null) break;


				ChallengeCell ChallengeCell = new();
				ChallengeCell.LoadData(ChallengeNpcDifficulty, ChallengeNpcKill, ChallengeNpcGrade, ChallengeNpcAttraction, ChallengeNpcQuest);

				TaskPanel.Controls.Add(ChallengeCell);
				ChallengeCell.Location = new Point(10, LocY);
				LocY = ChallengeCell.Bottom;
			}
			#endregion


			#region 加载奖励
			this.ChallengeListRewards = new();
			for (byte Idx = 1; Idx <= 20; Idx++)
			{
				var ChallengeListReward = FileCache.Data.ChallengeListReward[ChallengeList.Attributes["reward-" + Idx]];
				if (ChallengeListReward is null) break;

				ChallengeListReward.ChallengeCountForReward = ChallengeList.Attributes["challenge-count-for-reward-" + Idx].ConvertToByte();
				this.ChallengeListRewards.Add(ChallengeListReward);
			}

			this.SelectReward(0);
			#endregion
		}
		#endregion

		#region 奖励处理
		private List<ChallengeListReward> ChallengeListRewards;

		public byte SeletedIndex;

		private void RewardPreview_PrevSeleted() => SelectReward(this.SeletedIndex - 1);

		private void RewardPreview_NextSeleted() => SelectReward(this.SeletedIndex + 1);


		private void SelectReward(int Index)
		{
			if (Index < 0 || Index >= ChallengeListRewards.Count) return;

			var reward = ChallengeListRewards[Index];
			this.label3.Text = $"完成{ reward.ChallengeCountForReward }个";

			this.SeletedIndex = (byte)Index;
			this.RewardPreview.LoadData(reward);
			this.RewardPreview.Location = new Point((this.Width - this.RewardPreview.Width) / 2, RewardPreview.Location.Y);
		}
		#endregion
	}
}