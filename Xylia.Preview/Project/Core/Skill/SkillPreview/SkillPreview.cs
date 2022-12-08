using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Xylia.bns.Modules.GameData.Enums;
using Xylia.Extension;
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

			this.BackColor = Color.Transparent;
			this.AutoSize = false;
		}
		#endregion


		#region 方法
		private void SkillPreview_Load(object sender, EventArgs e)
		{
			
		}


		public void LoadData(string SkillAlias) => LoadData(FileCache.Data.Skill3[SkillAlias]);

		public void LoadData(Skill3 Skill)
		{
			this.M1_Panel.Tooltips.Clear();
			this.M2_Panel.Tooltips.Clear();
			this.SUB_Panel.Tooltips.Clear();
			this.CONDITION_Panel.Tooltips.Clear();

			if (Skill is null)
			{
				this.SkillName.Text = "无效技能";
				this.SkillIcon.Image = null;

				this.Refresh();
				return;
			}


			//System.Diagnostics.Debug.WriteLine(FileCacheData.Data.SkillCastCondition3[Skill.CastCondition]?.Property.OuterText);

			//var GatherRange = FileCacheData.Data.SkillGatherRange3[Skill.GatherRange];
			//System.Diagnostics.Debug.WriteLine(Skill.Property.OuterText);
			//System.Diagnostics.Debug.WriteLine("冷却时间: " + Skill.RecycleGroupDuration);
			//System.Diagnostics.Debug.WriteLine($"GatherRange: {GatherRange?.Distance} {GatherRange?.Radius}" + GatherRange?.Property.OuterText);

			this.SkillName.Text = Skill.NameText();   //获取技能名称
			this.SkillIcon.Image = Skill.MainIcon();  //获取图标信息
			this.DamageRateStandardStats.Text = ((float)Skill.DamageRateStandardStats / 1000).ToString("F3");
			this.DamageRatePvp.Text = ((float)Skill.DamageRatePvp / 1000).ToString("F3");

			//读取提示信息
			foreach (var Tooltip in FileCache.Data.SkillTooltip.Where(tooltip => tooltip.Skill == Skill.Alias))
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


				#region 获取默认文本
				//获取字体
				var _font = Tooltip.tooltipGroup == SkillTooltip.TooltipGroup.M1 ?
					new Font(this.Font.FontFamily, this.Font.Size + 3, FontStyle.Regular) :
					this.Font;

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
				#endregion

				#region 获取属性 
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

					LoadArg(CondContent, ConditionAttribute.ArgType1, Tooltip.ConditionArg1, Tooltip);
					LoadArg(CondContent, ConditionAttribute.ArgType2, Tooltip.ConditionArg2, Tooltip);
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

					LoadArg(EffectContent, EffectAttribute.ArgType1, Tooltip.EffectArg1, Tooltip);
					LoadArg(EffectContent, EffectAttribute.ArgType2, Tooltip.EffectArg2, Tooltip);
					LoadArg(EffectContent, EffectAttribute.ArgType3, Tooltip.EffectArg3, Tooltip);
					LoadArg(EffectContent, EffectAttribute.ArgType4, Tooltip.EffectArg4, Tooltip);

					panels.Add(EffectContent);
				}
				#endregion
			}

			this.Refresh();
		}

		private static void LoadArg(ContentPanel Panel, SkillTooltipAttribute.ArgType ArgType, string Arg, SkillTooltip Tooltip)
		{
			if (ArgType == SkillTooltipAttribute.ArgType.None) return;

			//防止出现空值导致处理崩溃
			if (!int.TryParse(Arg, out int ValueConvert)) ValueConvert = 0;

			//填充参数
			Panel.Params.Add(ArgType switch
			{
				SkillTooltipAttribute.ArgType.DamagePercentMinMax => GetDamageInfo(Arg.Split(',')[0], Arg.Split(',')[1], Tooltip.SkillAttackAttributeCoefficientPercent),
				SkillTooltipAttribute.ArgType.DamagePercent => GetDamageInfo(Arg, "0", Tooltip.SkillAttackAttributeCoefficientPercent),

				SkillTooltipAttribute.ArgType.Time => (float)ValueConvert / 1000 + "秒",
				SkillTooltipAttribute.ArgType.StackCount => ValueConvert,
				SkillTooltipAttribute.ArgType.Effect => $"<font name=\"00008130.Program.Fontset_ItemGrade_6\">{ FileCache.Data.Effect[Arg]?.NameText() ?? Arg }</font>",
				SkillTooltipAttribute.ArgType.HealPercent => (float)ValueConvert + "%",
				SkillTooltipAttribute.ArgType.DrainPercent => null,
				SkillTooltipAttribute.ArgType.Skill => $"<font name=\"00008130.Program.Fontset_ItemGrade_4\">{ FileCache.Data.Skill3[Arg]?.NameText() ?? Arg }</font>",
				SkillTooltipAttribute.ArgType.ConsumePercent => (float)ValueConvert + "%",
				SkillTooltipAttribute.ArgType.ProbabilityPercent => (float)ValueConvert + "%",
				SkillTooltipAttribute.ArgType.StanceType => Arg.ToEnum<Stance>().GetDescription(),
				SkillTooltipAttribute.ArgType.Percent => (float)ValueConvert + "%",
				SkillTooltipAttribute.ArgType.Counter => ValueConvert + "次",
				SkillTooltipAttribute.ArgType.Distance => (float)ValueConvert / 100 + "米",
				SkillTooltipAttribute.ArgType.KeyCommand => FileCache.Data.Skill3[Arg]?.ShortCutKey.GetDescription(),
				SkillTooltipAttribute.ArgType.Number => ValueConvert,
				SkillTooltipAttribute.ArgType.TextAlias => Arg.GetText(),

				_ => null,
			});
		}




		/// <summary>
		/// 获取伤害信息 
		/// </summary>
		/// <param name="Min"></param>
		/// <param name="Max"></param>
		/// <param name="AttributePercent">功力系数</param>
		/// <returns></returns>
		private static string GetDamageInfo(string Min, string Max, int AttributePercent) => GetDamageInfo(Min.ToIntWithNull(), Max.ToIntWithNull(), AttributePercent);

		private static string GetDamageInfo(int? Min, int? Max, int AttributePercent)
		{
			string result = null;
			if (Max == 0) result = $"{Min}X AP";
			else result = $"{Min}~{Max}X AP";


			if (AttributePercent > 0) result += " [功力]";
			return result;
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
