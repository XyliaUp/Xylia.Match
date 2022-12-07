
using Xylia.Attribute.Component;
using Xylia.Preview.Project.Common.Interface;

namespace Xylia.Preview.Data.Record
{
	public sealed class FieldZone : IRecord, IName
	{
		#region 属性字段
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

		public string Name2;

		public string Desc;

		[Signal("ui-text-grade")]
		public byte UiTextGrade;

		[Signal("reward-summary")]
		public string RewardSummary;



		[Signal("guild-battle-field-zone")]
		public string GuildBattleFieldZone;

		[Signal("min-fixed-channel")]
		public int MinFixedChannel;
		#endregion

		#region 接口字段
		public string NameText() => this.Name2.GetText();
		#endregion
	}
}
