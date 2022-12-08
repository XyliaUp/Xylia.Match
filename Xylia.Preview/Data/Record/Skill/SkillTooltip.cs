using System.ComponentModel;

using Xylia.Preview.Common.Interface;

namespace Xylia.Preview.Data.Record
{
	public sealed class SkillTooltip : IRecord
	{
		#region 属性字段
		public string Skill;

		[Description("tooltip-group")]
		public TooltipGroup tooltipGroup;

		[Description("ect-order")]
		public ECTOrder EctOrder;
		public ECTOrder EctOrderEnglish;
		public ECTOrder EctOrderFrench;
		public ECTOrder EctOrderGerman;
		public ECTOrder EctOrderRussian;
		public ECTOrder EctOrderBportuguese;

		[Description("effect-attribute")] public string EffectAttribute;
		[Description("effect-arg-1")] public string EffectArg1;
		[Description("effect-arg-2")] public string EffectArg2;
		[Description("effect-arg-3")] public string EffectArg3;
		[Description("effect-arg-4")] public string EffectArg4;

		[Description("condition-attribute")] public string ConditionAttribute;
		[Description("condition-arg-1")] public string ConditionArg1;
		[Description("condition-arg-2")] public string ConditionArg2;


		[Description("target-attribute")]
		public string TargetAttribute;

		[Description("before-stance-attribute")]
		public string BeforeStanceAttribute;

		[Description("after-stance-attribute")]
		public string AfterStanceAttribute;

		[Description("default-text")]
		public string DefaultText;

		[Description("attribute-color-text")]
		public string AttributeColorText;

		[Description("skill-modify-diff-repeat-count")]
		public byte SkillModifyDiffRepeatCount;

		[Description("skill-attack-attribute-coefficient-percent")]
		public short SkillAttackAttributeCoefficientPercent;

		[Description("item-default-text")]
		public string ItemDefaultText;

		[Description("item-replace-text")]
		public string ItemReplaceText;
		#endregion


		#region 枚举
		public enum TooltipGroup
		{
			M1,
			M2,
			SUB,
			STANCE,
			CONDITION
		}

		public enum ECTOrder
		{
			CTE,
			CET,
			TCE,
			TEC,
			ECT,
			ETC,
		}
		#endregion
	}
}
