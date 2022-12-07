using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Xylia.Preview.Project.Core.Item.Preview.Reward
{
	/// <summary>
	/// 奖励分页数据
	/// </summary>
	public class RewardPage
	{
		#region 字段
		public RewardPage(DecomposeRewardInfo RewardInfo, DecomposeByItem2 OpenItem2)
		{
			this.RewardInfo = RewardInfo;
			this.OpenItem2 = OpenItem2;
		}


		/// <summary>
		/// 奖励数据
		/// </summary>
		public DecomposeRewardInfo RewardInfo;

		/// <summary>
		/// 开启花费
		/// </summary>
		public DecomposeByItem2 OpenItem2;

		/// <summary>
		/// 存在开启物品
		/// </summary>
		public bool HasOpenItem2 => !this.OpenItem2?.INVALID ?? false;
		#endregion


		#region 方法
		public static List<RewardPage> GetPages(DecomposeInfo DecomposeInfo)
		{
			var result = new List<RewardPage>();

			#region 处理普通奖励组
			void GetPage(DecomposeRewardInfo RewardInfo, DecomposeByItem2 OpenItem)
			{
				if (RewardInfo is null) return;

				//创建奖励成员元素
				var Cells = RewardInfo.Preview;
				if (!Cells.Any()) Debug.WriteLine($"虽然绑定奖励对象，但是其内容为空");

				result.Add(new RewardPage(RewardInfo, OpenItem));
			}

			GetPage(DecomposeInfo.DecomposeReward1, DecomposeInfo.Decompose_By_Item2_1);
			GetPage(DecomposeInfo.DecomposeReward2, DecomposeInfo.Decompose_By_Item2_2);
			GetPage(DecomposeInfo.DecomposeReward3, DecomposeInfo.Decompose_By_Item2_3);
			GetPage(DecomposeInfo.DecomposeReward4, DecomposeInfo.Decompose_By_Item2_4);
			GetPage(DecomposeInfo.DecomposeReward5, DecomposeInfo.Decompose_By_Item2_5);
			GetPage(DecomposeInfo.DecomposeReward6, DecomposeInfo.Decompose_By_Item2_6);
			GetPage(DecomposeInfo.DecomposeReward7, DecomposeInfo.Decompose_By_Item2_7);
			#endregion



			#region 处理职业专用组
			var RewardGroup_Job = DecomposeInfo.DecomposeJobRewards;
			if (RewardGroup_Job != null && RewardGroup_Job.Any())
			{
				//数量大于一定值时，仍然分页显示
				int CellSum = RewardGroup_Job.Sum(group => group.Preview.Count);
				if (CellSum >= 30)
				{
					foreach (var group in RewardGroup_Job)
						result.Add(new RewardPage(group, null));
				}
				else
				{
					//创建一个临时组，以实现合并显示
					DecomposeJobRewardInfo tempReward = new(ItemDecomposeJobReward.None, null);

					tempReward._preview = new();
					foreach (var group in RewardGroup_Job) tempReward._preview.AddRange(group.Preview);

					result.Add(new RewardPage(tempReward, DecomposeInfo.Job_Decompose_By_Item2_1));
				}
			}
			#endregion

			return result;
		}
		#endregion
	}
}
