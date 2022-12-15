
using Xylia.Attribute.Component;
using Xylia.Preview.Common.Interface;

namespace Xylia.Preview.Data.Record
{
	public sealed class FactionBattleFieldZone : IRecord, IName
	{
		#region 属性字段
		public string Zone;

		public string Group;

		[Signal("ui-filter-attraction-quest-only")]
		public bool UiFilterAttractionQuestOnly;

		[Signal("respawn-confirm-text")]
		public string RespawnConfirmText;

		[Signal("required-level")]
		public byte RequiredLevel;

		[Signal("required-faction-level")]
		public byte RequiredFactionLevel;

		[Signal("faction-battle-field-zone-name2")]
		public string FactionBattleFieldZoneName2;

		[Signal("faction-battle-field-zone-desc")]
		public string FactionBattleFieldZoneDesc;

		[Signal("thumbnail-image")]
		public string ThumbnailImage;

		[Signal("reward-summary")]
		public string RewardSummary;
		#endregion

		#region 接口字段
		public string NameText() => this.FactionBattleFieldZoneName2.GetText();
		#endregion
	}
}
