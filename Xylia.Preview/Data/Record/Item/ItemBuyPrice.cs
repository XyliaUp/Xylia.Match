using Xylia.Attribute.Component;
using Xylia.Preview.Common.Enums;
using Xylia.Preview.Common.Interface;
using Xylia.bns.Modules.GameData.Enums;

namespace Xylia.Preview.Data.Record
{
	/// <summary>
	/// 物品购买价格
	/// </summary>
	public sealed class ItemBuyPrice : IRecord
	{
		#region 属性字段
		public int Money;

		[Signal("required-itembrand")]
		public string RequiredItembrand;

		[Signal("required-itembrand-condition-type")]
		public ConditionType RequiredItembrandConditionType = ConditionType.All;

		[Signal("required-item-1")]
		public string RequiredItem1;

		[Signal("required-item-2")]
		public string RequiredItem2;

		[Signal("required-item-3")]
		public string RequiredItem3;

		[Signal("required-item-4")]
		public string RequiredItem4;

		[Signal("required-item-count-1")]
		public short RequiredItemCount1;

		[Signal("required-item-count-2")]
		public short RequiredItemCount2;

		[Signal("required-item-count-3")]
		public short RequiredItemCount3;

		[Signal("required-item-count-4")]
		public short RequiredItemCount4;

		[Signal("required-faction-score")]
		public int RequiredFactionScore;

		[Signal("required-duel-point")]
		public int RequiredDuelPoint;

		[Signal("required-party-battle-point")]
		public int RequiredPartyBattlePoint;

		[Signal("required-field-play-point")]
		public int RequiredFieldPlayPoint;

		[Signal("required-life-contents-point")]
		public int RequiredLifeContentsPoint;

		[Signal("required-achievement-score")]
		public int RequiredAchievementScore;

		[Signal("required-achievement-id")]
		public int RequiredAchievementId;

		[Signal("required-achievement-step-min")]
		public short RequiredAchievementStepMin;

		[Signal("faction-level")]
		public short FactionLevel;

		[Signal("check-solo-duel-grade")]
		public byte CheckSoloDuelGrade;

		[Signal("check-team-duel-grade")]
		public byte CheckTeamDuelGrade;

		[Signal("check-battle-field-grade-occupation-war")]
		public byte CheckBattleFieldGradeOccupationWar;

		[Signal("check-battle-field-grade-capture-the-flag")]
		public byte CheckBattleFieldGradeCaptureTheFlag;

		[Signal("check-battle-field-grade-lead-the-ball")]
		public byte CheckBattleFieldGradeLeadTheBall;

		[Signal("check-closet-collecting-grade")]
		public byte CheckClosetCollectingGrade;

		[Signal("check-content-quota")]
		public string CheckContentQuota;

		[Signal("check-soul-boost-season-bm")]
		public int CheckSoulBoostSeasonBm;

		[Signal("required-level")]
		public byte RequiredLevel;

		[Signal("required-mastery-level")]
		public byte RequiredMasteryLevel;

		[Signal("required-account-level")]
		public short RequiredAccountLevel;
		#endregion
	}
}
