using System;
using System.Collections.Generic;
using System.Drawing;

using Xylia.Attribute.Component;
using Xylia.Extension;
using Xylia.Preview.Data.Record;
using Xylia.Preview.Resources;

using static Xylia.Preview.Data.Record.Item;

using ItemData = Xylia.Preview.Data.Record.Item;
using RewardData = Xylia.Preview.Data.Record.Reward;

namespace Xylia.Preview.Project.Core.Item.Preview.Reward
{
	/// <summary>
	/// 物品奖励信息
	/// </summary>
	public sealed class DecomposeInfo
	{
		#region 字段
		/// <summary>
		/// 根据钥匙类型适配奖励
		/// 否则只能获得第一个奖励
		/// </summary>
		[Signal("decompose-reward-by-consume-index")]
		public bool DecomposeRewardByConsumeIndex;

		[Signal("decompose-reward-1")] public DecomposeRewardInfo DecomposeReward1;
		[Signal("decompose-reward-2")] public DecomposeRewardInfo DecomposeReward2;
		[Signal("decompose-reward-3")] public DecomposeRewardInfo DecomposeReward3;
		[Signal("decompose-reward-4")] public DecomposeRewardInfo DecomposeReward4;
		[Signal("decompose-reward-5")] public DecomposeRewardInfo DecomposeReward5;
		[Signal("decompose-reward-6")] public DecomposeRewardInfo DecomposeReward6;
		[Signal("decompose-reward-7")] public DecomposeRewardInfo DecomposeReward7;
		[Signal("decompose-event-reward")] public DecomposeRewardInfo DecomposeEventReward;


		public readonly List<DecomposeRewardInfo> DecomposeJobRewards;

		[Signal("decompose-max")] public int DecomposeMax = 1;
		[Signal("decompose-money-cost")] public int DecomposeMoneyCost;


		[Signal("decompose-by-item2-1")] public DecomposeByItem2 Decompose_By_Item2_1;
		[Signal("decompose-by-item2-2")] public DecomposeByItem2 Decompose_By_Item2_2;
		[Signal("decompose-by-item2-3")] public DecomposeByItem2 Decompose_By_Item2_3;
		[Signal("decompose-by-item2-4")] public DecomposeByItem2 Decompose_By_Item2_4;
		[Signal("decompose-by-item2-5")] public DecomposeByItem2 Decompose_By_Item2_5;
		[Signal("decompose-by-item2-6")] public DecomposeByItem2 Decompose_By_Item2_6;
		[Signal("decompose-by-item2-7")] public DecomposeByItem2 Decompose_By_Item2_7;

		[Signal("job-decompose-by-item2-1")] public DecomposeByItem2 Job_Decompose_By_Item2_1;
		[Signal("job-decompose-by-item2-2")] public DecomposeByItem2 Job_Decompose_By_Item2_2;
		[Signal("job-decompose-by-item2-3")] public DecomposeByItem2 Job_Decompose_By_Item2_3;
		[Signal("job-decompose-by-item2-4")] public DecomposeByItem2 Job_Decompose_By_Item2_4;
		[Signal("job-decompose-by-item2-5")] public DecomposeByItem2 Job_Decompose_By_Item2_5;
		[Signal("job-decompose-by-item2-6")] public DecomposeByItem2 Job_Decompose_By_Item2_6;
		[Signal("job-decompose-by-item2-7")] public DecomposeByItem2 Job_Decompose_By_Item2_7;
		#endregion


		#region 构造
		public DecomposeInfo(ItemData ItemInfo)
		{
			#region 读取数据
			this.DecomposeRewardByConsumeIndex = ItemInfo.Attributes["decompose-reward-by-consume-index"].ToBool();
			this.DecomposeMax = ItemInfo.Attributes["decompose-max"].ToInt();
			this.DecomposeMoneyCost = ItemInfo.Attributes["decompose-money-cost"].ToInt();
			this.Decompose_By_Item2_1 = new DecomposeByItem2(ItemInfo.Attributes["decompose-by-item2-1"], ItemInfo.Attributes["decompose-by-item2-stack-count-1"].ToInt());
			this.Decompose_By_Item2_2 = new DecomposeByItem2(ItemInfo.Attributes["decompose-by-item2-2"], ItemInfo.Attributes["decompose-by-item2-stack-count-2"].ToInt());
			this.Decompose_By_Item2_3 = new DecomposeByItem2(ItemInfo.Attributes["decompose-by-item2-3"], ItemInfo.Attributes["decompose-by-item2-stack-count-3"].ToInt());
			this.Decompose_By_Item2_4 = new DecomposeByItem2(ItemInfo.Attributes["decompose-by-item2-4"], ItemInfo.Attributes["decompose-by-item2-stack-count-4"].ToInt());
			this.Decompose_By_Item2_5 = new DecomposeByItem2(ItemInfo.Attributes["decompose-by-item2-5"], ItemInfo.Attributes["decompose-by-item2-stack-count-5"].ToInt());
			this.Decompose_By_Item2_6 = new DecomposeByItem2(ItemInfo.Attributes["decompose-by-item2-6"], ItemInfo.Attributes["decompose-by-item2-stack-count-6"].ToInt());
			this.Decompose_By_Item2_7 = new DecomposeByItem2(ItemInfo.Attributes["decompose-by-item2-7"], ItemInfo.Attributes["decompose-by-item2-stack-count-7"].ToInt());
			this.Job_Decompose_By_Item2_1 = new DecomposeByItem2(ItemInfo.Attributes["job-decompose-by-item2-1"], ItemInfo.Attributes["job-decompose-by-item2-stack-count-1"].ToInt());
			this.Job_Decompose_By_Item2_2 = new DecomposeByItem2(ItemInfo.Attributes["job-decompose-by-item2-2"], ItemInfo.Attributes["job-decompose-by-item2-stack-count-2"].ToInt());
			this.Job_Decompose_By_Item2_3 = new DecomposeByItem2(ItemInfo.Attributes["job-decompose-by-item2-3"], ItemInfo.Attributes["job-decompose-by-item2-stack-count-3"].ToInt());
			this.Job_Decompose_By_Item2_4 = new DecomposeByItem2(ItemInfo.Attributes["job-decompose-by-item2-4"], ItemInfo.Attributes["job-decompose-by-item2-stack-count-4"].ToInt());
			this.Job_Decompose_By_Item2_5 = new DecomposeByItem2(ItemInfo.Attributes["job-decompose-by-item2-5"], ItemInfo.Attributes["job-decompose-by-item2-stack-count-5"].ToInt());
			this.Job_Decompose_By_Item2_6 = new DecomposeByItem2(ItemInfo.Attributes["job-decompose-by-item2-6"], ItemInfo.Attributes["job-decompose-by-item2-stack-count-6"].ToInt());
			this.Job_Decompose_By_Item2_7 = new DecomposeByItem2(ItemInfo.Attributes["job-decompose-by-item2-7"], ItemInfo.Attributes["job-decompose-by-item2-stack-count-7"].ToInt());
			#endregion

			#region 读取奖励数据
			static DecomposeRewardInfo GetRewardInfo(RewardData reward) => reward is null ? default : new DecomposeRewardInfo(reward);
			this.DecomposeReward1 = GetRewardInfo(FileCache.Data.Reward[ItemInfo.Attributes["decompose-reward-1"]]);
			this.DecomposeReward2 = GetRewardInfo(FileCache.Data.Reward[ItemInfo.Attributes["decompose-reward-2"]]);
			this.DecomposeReward3 = GetRewardInfo(FileCache.Data.Reward[ItemInfo.Attributes["decompose-reward-3"]]);
			this.DecomposeReward4 = GetRewardInfo(FileCache.Data.Reward[ItemInfo.Attributes["decompose-reward-4"]]);
			this.DecomposeReward5 = GetRewardInfo(FileCache.Data.Reward[ItemInfo.Attributes["decompose-reward-5"]]);
			this.DecomposeReward6 = GetRewardInfo(FileCache.Data.Reward[ItemInfo.Attributes["decompose-reward-6"]]);
			this.DecomposeReward7 = GetRewardInfo(FileCache.Data.Reward[ItemInfo.Attributes["decompose-reward-7"]]);


			//开始遍历职业奖励对象
			this.DecomposeJobRewards = new();
			foreach (ItemDecomposeJobReward code in Enum.GetValues(typeof(ItemDecomposeJobReward)))
			{
				if (code == ItemDecomposeJobReward.None) continue;

				//获取名称
				string rewardName = code.GetAttribute<Signal>().Description;
				if (ItemInfo.ContainsAttribute(rewardName, out string AttrVal))
				{
					//获得奖励数据，然后生成结构
					var Reward = FileCache.Data.Reward[AttrVal];
					if (Reward is null) continue;

					this.DecomposeJobRewards.Add(new DecomposeJobRewardInfo(code, Reward));
				}
			}
			#endregion
		}
		#endregion


		#region 方法
		/// <summary>
		/// 获取额外图标
		/// </summary>
		/// <returns></returns>
		public Bitmap GetExtra()
		{
			//存在开启金币或物品时会显示解印图标，但如果开启物品为钥匙或者为选择箱时则显示为锁图标
			if (!this.Decompose_By_Item2_1.INVALID) return GetExtra(this.Decompose_By_Item2_1);
			else if (!this.Job_Decompose_By_Item2_1.INVALID) return GetExtra(this.Job_Decompose_By_Item2_1);
			else if (this.DecomposeMoneyCost != 0) return Resource_BNSR.Weapon_Lock_04;

			return null;
		}

		private static Bitmap GetExtra(DecomposeByItem2 item2)
		{
			if (item2.INVALID) return null;

			var Item2Info = item2.Item.GetItemInfo();
			if (Item2Info != null && Item2Info.Type == ItemType.Grocery && Item2Info.GroceryType == GroceryTypeSeq.Key) return Resource_BNSR.unuseable_KeyLock;
			else return Resource_BNSR.Weapon_Lock_04;
		}
		#endregion
	}
}