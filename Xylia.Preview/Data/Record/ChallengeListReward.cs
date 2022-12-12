using Xylia.Attribute.Component;
using Xylia.Preview.Common.Interface;


namespace Xylia.Preview.Data.Record
{
	/// <summary>
	/// 挑战奖励
	/// </summary>
	public sealed class ChallengeListReward : IRecord
	{
		#region 属性字段
		[Signal("reward-money")]
		public int RewardMoney;

		[Signal("reward-account-exp")]
		public int RewardAccountExp;
		#endregion



		public byte ChallengeCountForReward;
	}
}
