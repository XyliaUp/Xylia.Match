using System;
using System.Collections.Generic;
using System.Drawing;
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
		#endregion

		#region 构造
		public ChallengeListFrm()
		{
			InitializeComponent();
			CheckForIllegalCrossThreadCalls = false;

			foreach (var item in TodayChallengeType) this.DaySelect.Source.Add(item.Value);
			this.DaySelect.SelectedIndex = 0;
		}
		#endregion


		#region 界面方法
		private void DaySelect_SelectedChangedEvent(object sender, EventArgs e)
		{
			foreach (var item in TodayChallengeType)
			{
				if (DaySelect.TextValue == item.Value)
				{
					this.Controls.Remove<ChallengeCell>();

					LoadData(item.Key);
					this.Refresh();

					break;
				}
			}
		}

		private void OutputList_Click(object sender, EventArgs e) => Execute.ThirdStart<Third.Content.ChallengeList>();
		#endregion

		#region 方法
		List<ChallengeCell> ChallengeCells;

		public void LoadData(ChallengeList.ChallengeTypeSeq ChallengeType)
		{
			var challengeList = FileCache.Data.ChallengeList.Find(o => o.ChallengeType == ChallengeType);
			if (challengeList is null) return;

			List<ChallengeCell> ChallengeCells = new();

			#region 加载任务课题
			for (int Idx = 1; Idx <= 20; Idx++)
			{
				var ChallengeQuestBasic = challengeList.Attributes["challenge-quest-basic-" + Idx];
				var ChallengeQuestExpansion = challengeList.Attributes["challenge-quest-expansion-" + Idx];
				var ChallengeQuestGrade = challengeList.Attributes["challenge-quest-grade-" + Idx].ToEnum<ChallengeList.Grade>();
				var ChallengeQuestAttraction = challengeList.Attributes["challenge-quest-attraction-" + Idx];

				if (ChallengeQuestBasic is null) break;

				ChallengeCell ChallengeCell = new();
				ChallengeCell.LoadData(ChallengeQuestBasic, ChallengeQuestExpansion, ChallengeQuestGrade, ChallengeQuestAttraction);
				ChallengeCells.Add(ChallengeCell);
			}
			#endregion

			#region 加载击杀课题
			for (int Idx = 1; Idx <= 20; Idx++)
			{
				var ChallengeNpcDifficulty = challengeList.Attributes["challenge-npc-difficulty-" + Idx].ToEnum<DifficultyType>();
				var ChallengeNpcKill = challengeList.Attributes["challenge-npc-kill-" + Idx];
				var ChallengeNpcAttraction = challengeList.Attributes["challenge-npc-attraction-" + Idx];
				var ChallengeNpcGrade = challengeList.Attributes["challenge-npc-grade-" + Idx].ToEnum<ChallengeList.Grade>();
				var ChallengeNpcQuest = challengeList.Attributes["challenge-npc-quest-" + Idx];

				if (ChallengeNpcKill is null) break;

				ChallengeCell ChallengeCell = new();
				ChallengeCell.LoadData(ChallengeNpcDifficulty, ChallengeNpcKill, ChallengeNpcGrade, ChallengeNpcAttraction, ChallengeNpcQuest);
				ChallengeCells.Add(ChallengeCell);
			}
			#endregion

			this.ChallengeCells = ChallengeCells;
		}

		public override void Refresh()
		{
			if (ChallengeCells is null) return;

			int LocY = label1.Bottom + 10;
			foreach (var cell in ChallengeCells)
			{
				this.Controls.Add(cell);

				cell.Location = new Point(10, LocY);
				LocY = cell.Bottom;
			}
		}
		#endregion
	}
}