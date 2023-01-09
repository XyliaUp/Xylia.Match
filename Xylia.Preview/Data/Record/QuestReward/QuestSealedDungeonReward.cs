using System.ComponentModel;

using Xylia.Preview.Common.Interface;

namespace Xylia.Preview.Data.Record
{
	public sealed class QuestSealedDungeonReward : IRecord
	{
		#region 属性字段
		public byte Level;

		[Description("reward-item-1")] public string RewardItem1;
		[Description("reward-item-2")] public string RewardItem2;
		[Description("reward-item-3")] public string RewardItem3;
		[Description("reward-item-4")] public string RewardItem4;

		[Description("reward-item-count-1")] public short RewardItemCount1;
		[Description("reward-item-count-2")] public short RewardItemCount2;
		[Description("reward-item-count-3")] public short RewardItemCount3;
		[Description("reward-item-count-4")] public short RewardItemCount4;
		#endregion
	}
}