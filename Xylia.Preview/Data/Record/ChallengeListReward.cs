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
		[Signal("reward-item-1")]
		public string RewardItem1;

		[Signal("reward-item-2")]
		public string RewardItem2;

		[Signal("reward-item-3")]
		public string RewardItem3;

		[Signal("reward-item-4")]
		public string RewardItem4;

		[Signal("reward-item-5")]
		public string RewardItem5;

		[Signal("reward-item-6")]
		public string RewardItem6;

		[Signal("reward-item-count-1")]
		public short RewardItemCount1;

		[Signal("reward-item-count-2")]
		public short RewardItemCount2;

		[Signal("reward-item-count-3")]
		public short RewardItemCount3;

		[Signal("reward-item-count-4")]
		public short RewardItemCount4;

		[Signal("reward-item-count-5")]
		public short RewardItemCount5;

		[Signal("reward-item-count-6")]
		public short RewardItemCount6;

		[Signal("reward-money")]
		public int RewardMoney;

		[Signal("reward-account-exp")]
		public int RewardAccountExp;
		#endregion
	}
}
