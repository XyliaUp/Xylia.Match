using System.Drawing;
using System.Windows.Forms;

using Xylia.bns.Modules.GameData.Enums;
using Xylia.Extension;
using Xylia.Preview.Common.Cast;
using Xylia.Preview.Data.Helper;

using ChallengeListData = Xylia.Preview.Data.Record.ChallengeList;

namespace Xylia.Preview.Project.Core.ChallengeList.Cell
{
	public partial class ChallengeCell : UserControl
	{
		public ChallengeCell()
		{
			InitializeComponent();
		}


		#region 方法
		public void LoadData(string ChallengeQuestBasic, string ChallengeQuestExpansion, ChallengeListData.Grade ChallengeQuestGrade, string Attraction)
		{
			var Quest = ReadQuestData.GetQuestData(ChallengeQuestBasic);
			if(Quest != null)
			{
				this.ChallengeName.Text = Quest.Name2.GetText();
				this.ChallengeName.ForeColor = Quest.ForeColor;
				this.ChallengeIcon.Image = Quest.Icon;
			}


			this.AttractionInfo.Text = Attraction.CastObject().GetName();
			this.ChallengeDifficultyType.Visible = false;

			this.pictureBox1.Location = new Point(this.pictureBox1.Location.X, this.ChallengeIcon.Bottom + 5);
			this.AttractionInfo.Location = new Point(this.AttractionInfo.Location.X, this.ChallengeIcon.Bottom + 10);
		}

		public void LoadData(DifficultyType ChallengeNpcDifficulty, string ChallengeNpcKill, ChallengeListData.Grade ChallengeQuestGrade, string Attraction, string ChallengeNpcQuest)
		{
			var KillNpc = FileCache.Data.Npc[ChallengeNpcKill];


			this.AttractionInfo.Text = Attraction.CastObject().GetName();
			this.ChallengeName.Text = $"<font name=\"00008130.Program.Fontset_ItemGrade_5\">{ this.AttractionInfo.Text }</font> { KillNpc?.NameText() } 击杀";
			//this.ChallengeIcon.Image = null;

			this.ChallengeDifficultyType.Text = ChallengeNpcDifficulty.GetDescription() + "队伍";
		}
		#endregion
	}
}
