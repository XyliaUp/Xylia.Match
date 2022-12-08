
using Xylia.Attribute.Component;
using Xylia.Preview.Common.Interface;

namespace Xylia.Preview.Data.Record
{
	public sealed class ClassicFieldZone : IRecord, IName
	{
		#region 属性字段
		[Signal("zone-1")]
		public string Zone1;

		[Signal("zone-2")]
		public string Zone2;

		public string Group;

		[Signal("attraction-quest-1")]
		public string AttractionQuest1;

		[Signal("attraction-quest-2")]
		public string AttractionQuest2;

		[Signal("attraction-quest-3")]
		public string AttractionQuest3;

		[Signal("attraction-quest-4")]
		public string AttractionQuest4;

		[Signal("attraction-quest-5")]
		public string AttractionQuest5;

		[Signal("ui-filter-attraction-quest-only")]
		public bool UiFilterAttractionQuestOnly;

		[Signal("respawn-confirm-text")]
		public string RespawnConfirmText;

		[Signal("escape-cave-confirm-text")]
		public string EscapeCaveConfirmText;

		[Signal("recommend-attack-power")]
		public short RecommendAttackPower;

		[Signal("standard-gear-weapon")]
		public string StandardGearWeapon;

		[Signal("classic-field-zone-name2")]
		public string ClassicFieldZoneName2;

		[Signal("classic-field-zone-desc")]
		public string ClassicFieldZoneDesc;

		[Signal("thumbnail-image")]
		public string ThumbnailImage;

		[Signal("reward-summary")]
		public string RewardSummary;

		[Signal("ui-text-grade")]
		public byte UiTextGrade;

		public string Tactic;

		[Signal("recommend-alias")]
		public string RecommendAlias;

		[Signal("recommend-level-min")]
		public byte RecommendLevelMin;

		[Signal("recommend-level-max")]
		public byte RecommendLevelMax;

		[Signal("recommend-mastery-level-min")]
		public byte RecommendMasteryLevelMin;

		[Signal("recommend-mastery-level-max")]
		public byte RecommendMasteryLevelMax;
		#endregion

		#region 接口字段
		public string NameText() => this.ClassicFieldZoneName2.GetText();
		#endregion
	}
}
