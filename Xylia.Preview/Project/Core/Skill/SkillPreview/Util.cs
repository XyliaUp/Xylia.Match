using System;
using System.Collections.Generic;
using System.Linq;

using Xylia.bns.Modules.GameData.Enums;
using Xylia.Extension;
using Xylia.Preview.Data.Record;
using Xylia.Preview.Project.Controls;


namespace Xylia.Preview.Project.Core.Skill
{
	public static class Util
	{
		public static IEnumerable<SkillTooltip> GetSkillTooltips(this Skill3 Skill)
		{
			//返回结果较慢
			if (false) return FileCache.Data.SkillTooltip.Where(tooltip => tooltip.Skill == Skill.Alias);


			List<string> temp = new();
			for (int idx = 1; idx <= 10; idx++) temp.AddItem(Skill.Attributes["sub-tooltip-" + idx]);
			for (int idx = 1; idx <= 5; idx++)
			{
				temp.AddItem(Skill.Attributes["main-tooltip-1-" + idx]);
				temp.AddItem(Skill.Attributes["main-tooltip-2-" + idx]);
				temp.AddItem(Skill.Attributes["stance-tooltip-" + idx]);
				temp.AddItem(Skill.Attributes["condition-tooltip-" + idx]);
			}

			return temp.Select(o => FileCache.Data.SkillTooltip[o]);
		}


		public static string GetDuration(this int Duration) => Duration == 0 ? "即时" : TimeSpan.FromMilliseconds(Duration).ToMyString();




		public static void LoadArg(this ContentPanel Panel, SkillTooltipAttribute.ArgType ArgType, string Arg, SkillTooltip Tooltip)
		{
			if (ArgType == SkillTooltipAttribute.ArgType.None) return;

			//防止出现空值导致处理崩溃
			if (!int.TryParse(Arg, out int ValueConvert)) ValueConvert = 0;


			Panel.Params.Add(ArgType switch
			{
				SkillTooltipAttribute.ArgType.DamagePercentMinMax => GetDamageInfo(Arg.Split(',')[0].ToInt(), Arg.Split(',')[1].ToInt(), Tooltip.SkillAttackAttributeCoefficientPercent),
				SkillTooltipAttribute.ArgType.DamagePercent => GetDamageInfo(Arg.ToInt(), 0, Tooltip.SkillAttackAttributeCoefficientPercent),
				SkillTooltipAttribute.ArgType.Time => (float)ValueConvert / 1000 + "秒",
				SkillTooltipAttribute.ArgType.StackCount => ValueConvert,
				SkillTooltipAttribute.ArgType.Effect => $"<font name=\"00008130.Program.Fontset_ItemGrade_6\">{ FileCache.Data.Effect[Arg]?.NameText() ?? Arg }</font>",
				SkillTooltipAttribute.ArgType.HealPercent => ValueConvert + "%",
				SkillTooltipAttribute.ArgType.DrainPercent => ValueConvert + "%",
				SkillTooltipAttribute.ArgType.Skill => $"<font name=\"00008130.Program.Fontset_ItemGrade_4\">{ FileCache.Data.Skill3[Arg]?.NameText() ?? Arg }</font>",
				SkillTooltipAttribute.ArgType.ConsumePercent => ValueConvert + "%",
				SkillTooltipAttribute.ArgType.ProbabilityPercent => ValueConvert + "%",
				SkillTooltipAttribute.ArgType.StanceType => Arg.ToEnum<Stance>().GetDescription(),
				SkillTooltipAttribute.ArgType.Percent => ValueConvert + "%",
				SkillTooltipAttribute.ArgType.Counter => ValueConvert + "次",
				SkillTooltipAttribute.ArgType.Distance => (float)ValueConvert / 100 + "米",
				SkillTooltipAttribute.ArgType.KeyCommand => FileCache.Data.Skill3[Arg]?.CurrentShortCutKey.GetImage(),
				SkillTooltipAttribute.ArgType.Number => ValueConvert,
				SkillTooltipAttribute.ArgType.TextAlias => Arg.GetText(),

				_ => null,
			});
		}


		public static int AttackPower = 6464;

		public static double AttackAttributePercent = 3.8837;

		public static string GetDamageInfo(int Value) => GetDamageInfo(Value, Value, 100);

		public static string GetDamageInfo(int MinValue, int MaxValue, int AttributePercent)
		{
			if (false)
			{
				string result = MaxValue == 0 ? $"{MinValue}%" : $"{MinValue}~{MaxValue}%";
				return AttributePercent > 0 ? result + " [功力]" : result;
			}
			else
			{
				var temp = AttackPower * 0.01;
				if (AttributePercent > 0) temp = temp * (AttributePercent * 0.01) * (AttackAttributePercent * 0.97);

				return $"{ MinValue * temp * 0.985:N0}~{ MaxValue * temp * 1.015:N0}";
			}
		}
	}
}