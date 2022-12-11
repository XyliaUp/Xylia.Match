
using Xylia.Attribute.Component;
using Xylia.Preview.Common.Interface;

namespace Xylia.Preview.Data.Record
{
	public sealed class BossChallenge : IRecord, IName
	{
		#region 属性字段
		[Signal("boss-challenge-name2")]
		public string BossChallengeName2;

		[Signal("boss-challenge-desc")]
		public string BossChallengeDesc;

		[Signal("ui-text-grade")]
		public byte UiTextGrade;

		[Signal("reward-summary")]
		public string RewardSummary;
		#endregion

		#region 接口字段
		public string NameText() => this.BossChallengeName2.GetText();
		#endregion
	}
}
