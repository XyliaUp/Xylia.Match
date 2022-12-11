using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using Xylia.bns.Modules.GameData.Enums;
using Xylia.Preview.Common.Extension;
using Xylia.Preview.Data.Record;

namespace Xylia.Preview.Project.Core.Skill
{
	public partial class SkillTraitPreview : Form
	{
		#region 构造
		public SkillTraitPreview()
		{
			InitializeComponent();
		}
		#endregion

		#region 方法
		SkillTrait Default;

		Dictionary<byte, TraitTier> TraitTiers;

		public void LoadData()
		{
			this.TraitTiers = new();

			foreach (var SkillTrait in FileCache.Data.SkillTrait.Where(o => o.Job == Job.소환사 && o.JobStyle == JobStyle.Advanced3))
			{
				if (SkillTrait.Tier == 0)
				{
					Default = SkillTrait;

					this.SetData(SkillTrait);
					continue;
				}


				if (!TraitTiers.ContainsKey(SkillTrait.Tier)) TraitTiers[SkillTrait.Tier] = new TraitTier();
				var CurTier = TraitTiers[SkillTrait.Tier];

				if (SkillTrait.TierVariation == 1) CurTier.Variation1 = SkillTrait;
				else if (SkillTrait.TierVariation == 2) CurTier.Variation2 = SkillTrait;
				else if (SkillTrait.TierVariation == 3) CurTier.Variation3 = SkillTrait;
			}

			int PosY = 0;
			foreach (var o in TraitTiers.Values)
			{
				if (!this.Controls.Contains(o)) this.Controls.Add(o);

				o.Location = new Point(0, PosY);
				PosY = o.Bottom;
			}
		}

		public void SetData(SkillTrait SkillTrait)
		{
			System.Diagnostics.Trace.WriteLine(SkillTrait.Attributes);

			this.TooltipTrainName.Text = SkillTrait.TooltipTrainName.GetText();
			this.TooltipTrainDescription.Text = SkillTrait.TooltipTrainDescription.GetText();
			this.TooltipEffectDescription.Text = SkillTrait.TooltipEffectDescription.GetText();

			this.Refresh();
		}

		/// <summary>
		/// 获取当前所有技能
		/// </summary>
		/// <returns></returns>
		public List<Skill3> GetSkills()
		{
			Dictionary<int, byte> skill = new();

			LoadTrait(this.Default);
			foreach (var tier in this.TraitTiers)
			{
				if (tier.Value.SeletedIndex == 1) LoadTrait(tier.Value.Variation1);
				else if (tier.Value.SeletedIndex == 2) LoadTrait(tier.Value.Variation2);
				else if (tier.Value.SeletedIndex == 3) LoadTrait(tier.Value.Variation3);
			}


			void LoadTrait(SkillTrait SkillTrait)
			{
				for (int idx = 1; idx <= 64; idx++)
				{
					var FixedSkill3Id = SkillTrait.Attributes["fixed-skill3-id-" + idx];
					if (FixedSkill3Id is null) break;

					skill[int.Parse(FixedSkill3Id)] = 1;
				}

				for (int idx = 1; idx <= 32; idx++)
				{
					var variableSkill3Id = SkillTrait.Attributes["variable-skill3-id-" + idx];
					var variableSkill3VariationId = SkillTrait.Attributes["variable-skill3-variation-id-" + idx];

					if (variableSkill3Id is null) break;
					var VariationId = byte.Parse(variableSkill3VariationId);
					if (VariationId != 1) VariationId += 1;

					skill[int.Parse(variableSkill3Id)] = (byte)VariationId;
				}
			}



			return skill.Select(o => FileCache.Data.Skill3[o.Key, o.Value]).Where(o => o is not null).ToList();
		}
		#endregion

		#region 控件方法
		private void Form1_Load(object sender, EventArgs e) => this.LoadData();

		private void ucBtnExt1_BtnClick(object sender, EventArgs e) => new SkillTrainCategoryPreview(this.GetSkills()).MyShowDialog();

		public override void Refresh()
		{
			base.Refresh();

			this.TooltipEffectDescription.Location = new Point(this.TooltipEffectDescription.Location.X, this.TooltipTrainDescription.Bottom);
		}
		#endregion
	}
}