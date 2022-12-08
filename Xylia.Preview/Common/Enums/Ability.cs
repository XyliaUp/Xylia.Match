using System.ComponentModel;

using Xylia.Attribute.Component;

namespace Xylia.Preview.Common.Enums
{
	public enum AttachAbility : byte
	{
		None,

		[Signal("attack-power-creature-min-max")]
		[Description("攻击")]
		AttackPowerCreatureMinMax,

		[Signal("pve-boss-level-npc-attack-power-creature-min-max")]
		[Description("降魔攻击力")]
		PveBossLevelNpcAttackPowerCreatureMinMax,

		[Signal("pvp-attack-power-creature-min-max")]
		[Description("PVP攻击力")]
		PvpAttackPowerCreatureMinMax,

		[Signal("attack-hit-value")]
		[Description("命中")]
		AttackHitValue,

		[Signal("attack-critical-value")]
		[Description("暴击")]
		AttackCriticalValue,

		[Signal("attack-critical-damage-value")]
		[Description("暴击伤害")]
		AttackCriticalDamageValue,

		[Signal("attack-attribute-value")]
		[Description("功力")]
		AttackAttributeValue,

		[Signal("attack-pierce-value")]
		[Description("穿刺")]
		AttackPierceValue,

		[Signal("abnormal-attack-power-value")]
		[Description("状态异常伤害")]
		AbnormalAttackPowerValue,

		[Signal("max-hp")]
		[Description("生命")]
		MaxHp,

		[Signal("defend-power-creature-value")]
		[Description("防御")]
		DefendPowerCreatureValue,

		[Signal("pve-boss-level-npc-defend-power-creature-value")]
		[Description("降魔防御力")]
		PveBossLevelNpcDefendPowerCreatureValue,

		[Signal("pvp-defend-power-creature-value")]
		[Description("PVP防御力")]
		PvpDefendPowerCreatureValue,

		[Signal("defend-dodge-value")]
		[Description("闪避")]
		DefendDodgeValue,

		[Signal("defend-parry-value")]
		[Description("格挡")]
		DefendParryValue,

		[Signal("defend-critical-value")]
		[Description("暴击防御")]
		DefendCriticalValue,

		[Signal("hp-regen")]
		[Description("恢复")]
		HpRegen,

		[Signal("heal-power-value")]
		[Description("治疗")]
		HealPowerValue,

		[Signal("abnormal-defend-power-value")]
		[Description("状态异常防御力")]
		AbnormalDefendPowerValue,

		[Signal("r-attack-stiff-duration-value")]
		RAttackStiffDurationValue,

		[Signal("r-defend-stiff-duration-value")]
		RDefendStiffDurationValue,

		[Signal("r-attack-concentrate-value")]
		RAttackConcentrateValue,

		[Signal("r-aoe-defend-power-value")]
		RAoeDefendPowerValue,

		[Signal("r-defend-strength-creature-value")]
		RDefendStrengthCreatureValue,

		[Signal("r-attack-precise-creature-value")]
		RAttackPreciseCreatureValue,

		[Signal("r-attack-aoe-pierce-value")]
		RAttackAoePierceValue,

		[Signal("r-attack-abnormal-hit-value")]
		RAttackAbnormalHitValue,

		[Signal("r-defend-abnormal-dodge-value")]
		RDefendAbnormalDodgeValue,

		[Signal("r-support-power-value")]
		RSupportPowerValue,
	}



	public enum MainAbility : byte
	{
		[Signal("none")]
		None,

		[Signal("attack-power-equip-min-and-max")]
		[Description("攻击")]
		AttackPowerEquipMinAndMax,

		[Signal("defend-power-equip-value")]
		[Description("防御")]
		DefendPowerEquipValue,

		[Signal("defend-resist-power-equip-value")]
		DefendResistPowerEquipValue,

		[Signal("attack-hit-base-percent")]
		[Description("命中率")]
		AttackHitBasePercent,

		[Signal("attack-hit-value")]
		[Description("命中")]
		AttackHitValue,

		[Signal("attack-critical-base-percent")]
		[Description("暴击率")]
		AttackCriticalBasePercent,

		[Signal("attack-critical-value")]
		[Description("暴击")]
		AttackCriticalValue,

		[Signal("defend-critical-base-percent")]
		[Description("暴击防御率")]
		DefendCriticalBasePercent,

		[Signal("defend-critical-value")]
		[Description("暴击防御")]
		DefendCriticalValue,

		[Signal("defend-dodge-base-percent")]
		[Description("闪避率")]
		DefendDodgeBasePercent,

		[Signal("defend-dodge-value")]
		[Description("闪避")]
		DefendDodgeValue,

		[Signal("defend-parry-base-percent")]
		[Description("格挡率")]
		DefendParryBasePercent,

		[Signal("defend-parry-value")]
		[Description("格挡")]
		DefendParryValue,

		[Signal("attack-stiff-duration-base-percent")]
		AttackStiffDurationBasePercent,

		[Signal("attack-stiff-duration-value")]
		AttackStiffDurationValue,

		[Signal("defend-stiff-duration-base-percent")]
		DefendStiffDurationBasePercent,

		[Signal("defend-stiff-duration-value")]
		DefendStiffDurationValue,

		[Signal("cast-duration-base-percent")]
		CastDurationBasePercent,

		[Signal("cast-duration-value")]
		CastDurationValue,

		[Signal("defend-physical-damage-reduce-percent")]
		DefendPhysicalDamageReducePercent,

		[Signal("defend-force-damage-reduce-percent")]
		DefendForceDamageReducePercent,

		[Signal("attack-damage-modify-percent")]
		[Description("额外伤害率")]
		AttackDamageModifyPercent,

		[Signal("attack-damage-modify-diff")]
		[Description("额外伤害")]
		AttackDamageModifyDiff,

		[Signal("defend-damage-modify-percent")]
		[Description("额外伤害减免率")]
		DefendDamageModifyPercent,

		[Signal("defend-damage-modify-diff")]
		[Description("额外伤害减免")]
		DefendDamageModifyDiff,

		[Signal("max-hp")]
		[Description("生命")]
		MaxHp,

		[Signal("hp-regen")]
		[Description("恢复")]
		HpRegen,

		[Signal("hp-regen-combat")]
		[Description("战斗中恢复")]
		HpRegenCombat,

		[Signal("attack-pierce-value")]
		[Description("穿刺")]
		AttackPierceValue,

		[Signal("attack-concentrate-value")]
		AttackConcentrateValue,

		[Signal("defend-perfect-parry-reduce-percent")]
		DefendPerfectParryReducePercent,

		[Signal("defend-counter-reduce-percent")]
		DefendCounterReducePercent,

		[Signal("attack-critical-damage-percent")]
		[Description("暴击伤害率")]
		AttackCriticalDamagePercent,

		[Signal("pve-boss-level-npc-attack-power-equip-min-and-max")]
		[Description("降魔攻击力")]
		PveBossLevelNpcAttackPowerEquipMinAndMax,

		[Signal("pve-boss-level-npc-defend-power-equip-value")]
		[Description("降魔防御力")]
		PveBossLevelNpcDefendPowerEquipValue,

		[Description("PVP攻击力")]
		[Signal("pvp-attack-power-equip-min-and-max")]
		PvpAttackPowerEquipMinAndMax,

		[Signal("pvp-defend-power-equip-value")]
		[Description("PVP防御力")]
		PvpDefendPowerEquipValue,

		[Signal("attack-critical-damage-value")]
		[Description("暴击伤害")]
		AttackCriticalDamageValue,

		[Signal("max-guard-gauge")]
		[Description("刚体")]
		MaxGuardGauge,

		[Signal("attack-attribute-value")]
		[Description("功力")]
		AttackAttributeValue,

		[Signal("r-attack-stiff-duration-equip-value")]
		RAttackStiffDurationEquipValue,

		[Signal("r-defend-stiff-duration-equip-value")]
		RDefendStiffDurationEquipValue,

		[Signal("r-aoe-defend-power-value-equip")]
		RAoeDefendPowerValueEquip,

		[Signal("r-heal-power-equip-value")]
		RHealPowerEquipValue,

		[Signal("r-defend-strength-equip-value")]
		RDefendStrengthEquipValue,

		[Signal("r-attack-precise-equip-value")]
		RAttackPreciseEquipValue,

		[Signal("r-attack-aoe-pierce-value-equip")]
		RAttackAoePierceValueEquip,

		[Signal("r-attack-abnormal-hit-equip-value")]
		RAttackAbnormalHitEquipValue,

		[Signal("r-defend-abnormal-dodge-equip-value")]
		RDefendAbnormalDodgeEquipValue,

		[Signal("r-support-power-equip-value")]
		RSupportPowerEquipValue,

		[Signal("r-hypermove-power-equip-value")]
		RHypermovePowerEquipValue,

		[Signal("attack-attribute-base-percent")]
		[Description("功力率")]
		AttackAttributeBasePercent,

		[Signal("defend-difficulty-type-damage-reduce-percent")]
		DefendDifficultyTypeDamageReducePercent,
	}
}
