
using Xylia.Attribute.Component;
using Xylia.Preview.Common.Interface;

namespace Xylia.Preview.Data.Record
{
	public sealed class GuildBattleFieldZone : IRecord, IName
	{
		#region 属性字段
		[Signal("guild-battle-field-zone-name2")]
		public string GuildBattleFieldZoneName2;

		[Signal("guild-battle-field-zone-desc")]
		public string GuildBattleFieldZoneDesc;

		[Signal("thumbnail-image")]
		public string ThumbnailImage;

		[Signal("reward-summary")]
		public string RewardSummary;
		#endregion

		#region 接口字段
		public string NameText() => this.GuildBattleFieldZoneName2.GetText();
		#endregion
	}
}
