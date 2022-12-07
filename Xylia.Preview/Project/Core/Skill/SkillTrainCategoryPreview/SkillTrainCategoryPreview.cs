using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Xylia.Preview.Data.Record;
using Xylia.Preview.Project.Core.Item.Cell.Basic;

using GameSeq = Xylia.bns.Modules.GameData.Enums;

namespace Xylia.Preview.Project.Core.Skill
{
	public partial class SkillTrainCategoryPreview : Form
	{
		public SkillTrainCategoryPreview()
		{
			InitializeComponent();
		}

		public SkillTrainCategoryPreview(List<Skill3> Skills) : this()
		{
			this.LoadData(Skills);
		}


		public void LoadData(List<Skill3> Skills)
		{
			int LoX = 0;
			int LoY = 0;

			Dictionary<GameSeq.KeyCommand, Skill3> test = new();
			foreach (var Skill in Skills)
			{
				System.Diagnostics.Debug.WriteLine(Skill.ShortCutKey + " " + Skill.NameText());

				ItemIconCell ItemIconCell = new()
				{
					Scale = 64,
					ObjectRef = Skill,

					ItemIcon = Skill.MainIcon(),
					Location = new Point(LoX, LoY),
				};

				LoX = ItemIconCell.Right;
				this.Controls.Add(ItemIconCell);
			}
		}
	}
}
