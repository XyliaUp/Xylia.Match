using System.ComponentModel;

using Xylia.Preview.Project.Common.Interface;

namespace Xylia.Preview.Data.Record
{
	public sealed class SkillTooltipAttribute : IRecord
	{
		#region 属性字段
		[Description("arg-type-1")] 
		public ArgType ArgType1;

		[Description("arg-type-2")]
		public ArgType ArgType2;

		[Description("arg-type-3")] 
		public ArgType ArgType3;

		[Description("arg-type-4")] 
		public ArgType ArgType4;

		public string Text;

		public string Icon;

		/// <summary>
		/// 技能变更类型
		/// </summary>
		[Description("skill-modify-type")]
		public ModifyType SkillModifyType;
		#endregion


		#region 枚举
		public enum ArgType
		{
			None,

			[Description("damage-percent-min-max")]
			DamagePercentMinMax,

			[Description("damage-percent")]
			DamagePercent,

			Time,

			[Description("stack-count")]
			StackCount,

			Effect,

			[Description("heal-percent")]
			HealPercent,

			[Description("drain-percent")]
			DrainPercent,

			Skill,

			[Description("consume-percent")]
			ConsumePercent,

			[Description("probability-percent")]
			ProbabilityPercent,

			[Description("stance-type")]
			StanceType,

			Percent,

			Counter,

			Distance,

			[Description("key-command")]
			KeyCommand,

			Number,

			[Description("text-alias")]
			TextAlias,

			[Description("r-hypermove")]
			rHypermove,

			[Description("r-heal-percent")]
			rHealPercent,

			[Description("r-heal-diff")]
			rHealDiff,

			[Description("r-shield-percent")]
			rShieldPercent,

			[Description("r-shield-diff")]
			rShieldDiff,

			[Description("r-support-percent")]
			rSupportPercent,

			[Description("r-support-diff")]
			rSupportDiff,

		}

		public enum ModifyType
		{
			None,

			[Description("recycle-duration")]
			RecycleDuration,

			[Description("sp-consume")]
			SpConsume,

			[Description("damage")]
			Damage,

			[Description("hp-drain")]
			HpDrain,

			[Description("heal-percent")]
			HealPercent,
		}
		#endregion
	}
}
