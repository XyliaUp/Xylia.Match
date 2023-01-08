using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Xylia.Extension;
using Xylia.Preview.Common.Enums;
using Xylia.Preview.Data.Package.Pak;
using Xylia.Preview.Data.Record;
using Xylia.Preview.Project.Controls;

namespace Xylia.Preview.Project.Core.Skill
{
	public partial class SkillPreview : UserControl
	{
		#region 构造
		public SkillPreview()
		{
			InitializeComponent();

			this.UI_Tooltip_Scale.Text = "UI.Tooltip.Scale".GetText();
			this.UI_Tooltip_Casting.Text = "UI.Tooltip.Casting".GetText();
			this.UI_Tooltip_Reuse.Text = "UI.Tooltip.Reuse".GetText();

			//Distance.Text = "Name.Skill.CastingRange.Default".GetText();
			//"Name.Skill.CastingRange".GetText();
			//"Name.Skill.CastingRange.MinMax".GetText();
			//"Name.Skill.ScaleRange".GetText();
			//"Name.Skill.ScaleRange.WidthHeight".GetText();
			//"Name.Skill.ScaleRange.Default".GetText();
		}
		#endregion


		#region 方法
		public void LoadData(Skill3 Skill)
		{
			#region 初始化
			this.M1_Panel.Tooltips.Clear();
			this.M2_Panel.Tooltips.Clear();
			this.SUB_Panel.Tooltips.Clear();
			this.CONDITION_Panel.Tooltips.Clear();

			if (Skill is null)
			{
				this.SkillName.Text = "无效技能";
				this.SkillIcon.Image = null;

				return;
			}
			#endregion

			#region 获取基本信息
			System.Diagnostics.Debug.WriteLine(Skill.Attributes);

			this.SkillName.Text = Skill.NameText();   //获取技能名称
			this.SkillIcon.Image = Skill.MainIcon();  //获取图标信息

			this.DamageRateStandardStats.Text = ((float)Skill.DamageRateStandardStats / 1000).ToString("F3");
			this.DamageRatePvp.Text = ((float)Skill.DamageRatePvp / 1000).ToString("F3");

			this.Casting.Text = Skill.CastDuration.GetDuration();
			this.Reuse.Text = Skill.RecycleGroupDuration.GetDuration();
			#endregion




			var GatherRange = FileCache.Data.SkillGatherRange3[Skill.GatherRange];
			if (GatherRange != null)
			{
				System.Diagnostics.Debug.WriteLine($"GatherRange: 距离 {GatherRange.CastMax}  范围 {GatherRange.RadiusMax}\n" + GatherRange.Attributes);

				Distance.Text = GatherRange.CastMax / 100 + "米";
			}

			System.Diagnostics.Debug.WriteLine($"FlowType: " + Skill.FlowType);
			System.Diagnostics.Debug.WriteLine($"FlowRepeat: " + Skill.FlowRepeat);

			if (Skill.FlowRepeat >= 1) System.Diagnostics.Debug.WriteLine($"ExecGatherType1: " + Skill.ExecGatherType1);
			if (Skill.FlowRepeat >= 2) System.Diagnostics.Debug.WriteLine($"ExecGatherType2: " + Skill.ExecGatherType2);
			if (Skill.FlowRepeat >= 3) System.Diagnostics.Debug.WriteLine($"ExecGatherType3: " + Skill.ExecGatherType3);
			if (Skill.FlowRepeat >= 4) System.Diagnostics.Debug.WriteLine($"ExecGatherType4: " + Skill.ExecGatherType4);
			if (Skill.FlowRepeat >= 5) System.Diagnostics.Debug.WriteLine($"ExecGatherType5: " + Skill.ExecGatherType5);


			#region GatherType
			GatherType GatherType = Skill.ExecGatherType1;
			if (GatherType == GatherType.Target && Skill.FlowRepeat >= 2) GatherType = Skill.ExecGatherType2;
			if (GatherType == GatherType.Target && Skill.FlowRepeat >= 3) GatherType = Skill.ExecGatherType3;
			if (GatherType == GatherType.Target && Skill.FlowRepeat >= 4) GatherType = Skill.ExecGatherType4;
			if (GatherType == GatherType.Target && Skill.FlowRepeat >= 5) GatherType = Skill.ExecGatherType5;


			if (GatherType == GatherType.Target)
			{
				Scale.Text = "Name.Skill.ScaleRange.Default".GetText();
				this.SkillGatherType.Image = null;
			}
			else
			{
				Scale.Text = GatherRange.RadiusMax / 100 + "米";

				string res = "BNSR/Content/Art/UI/GameUI/Resource/GameUI_ImageSet/SkillGatherType/" + GatherType.GetSignal().Replace("-", "_");
				this.SkillGatherType.Image = res.GetUObject().GetImage();
			}
			#endregion


			#region 获取提示信息
			foreach (var Tooltip in Skill.GetSkillTooltips())
			{
				#region 获取组信息
				var group = Tooltip.tooltipGroup switch
				{
					SkillTooltip.TooltipGroup.M1 => this.M1_Panel,
					SkillTooltip.TooltipGroup.M2 => this.M2_Panel,
					SkillTooltip.TooltipGroup.SUB => this.SUB_Panel,
					SkillTooltip.TooltipGroup.STANCE => null,
					SkillTooltip.TooltipGroup.CONDITION => this.CONDITION_Panel,
				};

				if (group is null) continue;

				List<ContentPanel> panels = new();
				group.Tooltips.Add(panels);
				#endregion

				#region 获取属性 
				//获取字体
				var _font = Tooltip.tooltipGroup == SkillTooltip.TooltipGroup.M1 ? new Font(this.Font.FontFamily, this.Font.Size + 3, FontStyle.Regular) : this.Font;
				if (Tooltip.DefaultText != null)
				{
					ContentPanel MainContent = new()
					{
						Tag = "#main",
						Font = _font,
						Text = Tooltip.DefaultText.GetText(),
					};

					panels.Add(MainContent);
				}

				var ConditionAttribute = FileCache.Data.SkillTooltipAttribute[Tooltip.ConditionAttribute];
				if (ConditionAttribute != null)
				{
					//实例化对象
					ContentPanel CondContent = new(ConditionAttribute.Text.GetText())
					{
						Tag = "#condition",
						Font = _font,
						Icon = ConditionAttribute.Icon?.GetIcon(),
					};

					CondContent.LoadArg(ConditionAttribute.ArgType1, Tooltip.ConditionArg1, Tooltip);
					CondContent.LoadArg(ConditionAttribute.ArgType2, Tooltip.ConditionArg2, Tooltip);
					panels.Add(CondContent);
				}

				var TargetAttribute = FileCache.Data.SkillTooltipAttribute[Tooltip.TargetAttribute];
				if (TargetAttribute != null)
				{
					panels.Add(new ContentPanel()
					{
						Tag = "#target",
						Font = _font,
						Icon = TargetAttribute.Icon?.GetIcon(),
						Text = TargetAttribute.Text.GetText(),
					});
				}

				var AfterStanceAttribute = FileCache.Data.SkillTooltipAttribute[Tooltip.AfterStanceAttribute];
				if (AfterStanceAttribute != null)
				{
					panels.Add(new ContentPanel()
					{
						Tag = "#after-stance",
						Font = _font,
						Icon = AfterStanceAttribute.Icon?.GetIcon(),
						Text = AfterStanceAttribute.Text.GetText(),
					});
				}

				var BeforeStanceAttribute = FileCache.Data.SkillTooltipAttribute[Tooltip.BeforeStanceAttribute];
				if (BeforeStanceAttribute != null)
				{
					panels.Add(new ContentPanel()
					{
						Tag = "#before-stance",
						Font = _font,
						Icon = BeforeStanceAttribute.Icon?.GetIcon(),
						Text = BeforeStanceAttribute.Text.GetText(),
					});
				}

				var EffectAttribute = FileCache.Data.SkillTooltipAttribute[Tooltip.EffectAttribute];
				if (EffectAttribute != null)
				{
					ContentPanel EffectContent = new(EffectAttribute.Text.GetText())
					{
						Tag = "#effect",
						Font = _font,
						Icon = EffectAttribute.Icon?.GetIcon(),
					};


					EffectContent.LoadArg(EffectAttribute.ArgType1, Tooltip.EffectArg1, Tooltip);
					EffectContent.LoadArg(EffectAttribute.ArgType2, Tooltip.EffectArg2, Tooltip);
					EffectContent.LoadArg(EffectAttribute.ArgType3, Tooltip.EffectArg3, Tooltip);
					EffectContent.LoadArg(EffectAttribute.ArgType4, Tooltip.EffectArg4, Tooltip);

					panels.Add(EffectContent);
				}
				#endregion
			}
			#endregion
		}




		public override void Refresh()
		{
			this.SuspendLayout();
			base.Refresh();


			this.M1_Panel.Refresh();

			this.M2_Panel.Location = new Point(this.M2_Panel.Location.X, this.M1_Panel.Bottom);
			this.M2_Panel.Refresh();

			this.SUB_Panel.Refresh();
			this.SUB_Panel.Location = new Point(this.SUB_Panel.Location.X, Math.Max(this.SkillIcon.Bottom, this.M2_Panel.Bottom) + 5);
			this.SUB_Panel.Height = this.SUB_Panel.Bottom - this.SUB_Panel.Top;

			this.CONDITION_Panel.Refresh();

			this.ResumeLayout();
		}
		#endregion
	}
}