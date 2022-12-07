using System;
using System.Windows.Forms;
using System.Drawing;
using Xylia.Preview.Data.Record;

namespace Xylia.Preview.Project.Core.Skill
{
	public partial class TraitTier : UserControl
	{
		public TraitTier()
		{
			InitializeComponent();
		}


		public byte SeletedIndex = 1;

		public SkillTrait Variation1 { get => this.traitTierCell1.SkillTrait;  set => this.traitTierCell1.SkillTrait = value; }

		public SkillTrait Variation2 { get => this.traitTierCell2.SkillTrait; set => this.traitTierCell2.SkillTrait = value; }

		public SkillTrait Variation3 { get => this.traitTierCell3.SkillTrait; set => this.traitTierCell3.SkillTrait = value; }


		private void traitTierCell1_Click(object sender, EventArgs e)
		{
			this.traitTierCell1.BackColor = this.traitTierCell2.BackColor = this.traitTierCell3.BackColor = Color.Transparent;

			if (sender == this.traitTierCell1) SeletedIndex = 1;
			else if (sender == this.traitTierCell2) SeletedIndex = 2;
			else if (sender == this.traitTierCell3) SeletedIndex = 3;

			var TraitTierCell = ((TraitTierCell)sender);
			var SkillTrait = TraitTierCell.SkillTrait;

			TraitTierCell.BackColor = Color.Blue;
			System.Diagnostics.Trace.WriteLine(SkillTrait.Attributes);

			SkillTraitPreview.test.TooltipTrainName.Text = SkillTrait.TooltipTrainName.GetText();
			SkillTraitPreview.test.TooltipTrainDescription.Text = SkillTrait.TooltipTrainDescription.GetText();
			SkillTraitPreview.test.TooltipEffectDescription.Text = SkillTrait.TooltipEffectDescription.GetText();
		}
	}
}
