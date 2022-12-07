using System.ComponentModel;

using Xylia.Attribute.Component;

using RewardData = Xylia.Preview.Data.Record.Reward;


namespace Xylia.Preview.Project.Core.Item.Preview.Reward
{
	/// <summary>
	/// 奖励信息
	/// </summary>
	public class DecomposeJobRewardInfo : DecomposeRewardInfo
	{
		#region 构造
		/// <summary>
		/// 职业奖励特征名
		/// </summary>
		public ItemDecomposeJobReward Signal;

		public DecomposeJobRewardInfo(ItemDecomposeJobReward Signal, RewardData Reward) : base(Reward)
		{
			this.Signal = Signal;
		}
		#endregion
	}



	/// <summary>
	/// 奖励类型
	/// </summary>
	public enum ItemDecomposeJobReward
	{
		None,


		[Signal("decompose-job-reward-blade-master")]
		[Description("剑士")]
		DecomposeJobRewardBladeMaster,

		[Signal("decompose-job-reward-kung-fu-fighter")]
		[Description("拳师")]
		DecomposeJobRewardKungFuFighter,

		[Signal("decompose-job-reward-force-master")]
		[Description("气功")]
		DecomposeJobRewardForceMaster,

		[Signal("decompose-job-reward-destroyer")]
		[Description("力士")]
		DecomposeJobRewardDestroyer,

		[Signal("decompose-job-reward-summoner")]
		[Description("召唤")]
		DecomposeJobRewardSummoner,

		[Signal("decompose-job-reward-assassin")]
		[Description("刺客")]
		DecomposeJobRewardAssassin,

		[Signal("decompose-job-reward-sword-master")]
		[Description("灵剑")]
		DecomposeJobRewardSwordMaster,

		[Signal("decompose-job-reward-warlock")]
		[Description("咒术")]
		DecomposeJobRewardWarlock,

		[Signal("decompose-job-reward-soul-fighter")]
		[Description("气宗")]
		DecomposeJobRewardSoulFighter,

		[Signal("decompose-job-reward-shooter")]
		[Description("枪手")]
		DecomposeJobRewardShooter,

		[Signal("decompose-job-reward-warrior")]
		[Description("斗士")]
		DecomposeJobRewardWarrior,

		[Signal("decompose-job-reward-archer")]
		[Description("弓手")]
		DecomposeJobRewardArcher,

		[Signal("decompose-job-reward-spear-master")]
		[Description("矛手")]
		DecomposeJobRewardSpearMaster,

		[Signal("decompose-job-reward-thunderer")]
		[Description("星术")]
		DecomposeJobRewardThunderer,

		[Signal("decompose-job-reward-dual-blader")]
		[Description("双剑")]
		DecomposeJobRewardDualBlader,

		[Signal("decompose-job-reward-bard")]
		[Description("乐师")]
		DecomposeJobRewardBard,
	}
}
