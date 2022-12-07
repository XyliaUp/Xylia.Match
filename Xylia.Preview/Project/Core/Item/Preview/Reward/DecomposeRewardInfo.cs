using System;
using System.Collections.Generic;

using Xylia.Extension;
using Xylia.Preview.Project.Core.Item.Cell;

using RewardData = Xylia.Preview.Data.Record.Reward;

namespace Xylia.Preview.Project.Core.Item.Preview.Reward
{
	/// <summary>
	/// 奖励信息
	/// </summary>
	public class DecomposeRewardInfo
	{
		#region 构造
		public RewardData DecomposeReward;

		public DecomposeRewardInfo(RewardData Reward)
		{
			this.DecomposeReward = Reward;
		}
		#endregion



		#region 控件方法
		public List<RewardCell> _preview;

		public List<RewardCell> Preview
		{
			get
			{
				if (_preview is null)
				{
					_preview = new();

					_preview.AddRange(CreateGroupPreview(RewardCell.CellGroup.Fixed));
					_preview.AddRange(CreateGroupPreview(RewardCell.CellGroup.g1));
					_preview.AddRange(CreateGroupPreview(RewardCell.CellGroup.g2));
					_preview.AddRange(CreateGroupPreview(RewardCell.CellGroup.rare));
					_preview.AddRange(CreateGroupPreview(RewardCell.CellGroup.g3));
					_preview.AddRange(CreateGroupPreview(RewardCell.CellGroup.selected));

					//物品实例化
					_preview.ForEach(c => c.ItemInstace());
					_preview.Sort(new RewardCellSort());
				}

				return _preview;
			}

		}



		/// <summary>
		/// 生成预览信息
		/// </summary>
		/// <returns></returns>
		private List<RewardCell> CreateGroupPreview(RewardCell.CellGroup RewardGroup)
		{
			#region 初始化
			var result = new List<RewardCell>();
			if (this.DecomposeReward is null) return result;


			string RewardAttr = null, CountMinAttr = null, CountMaxAttr = null, Extra = null;

			//设置职业标记
			if (this is DecomposeJobRewardInfo jobReward)
				Extra = jobReward.Signal.GetDescription();


			#region 生成奖励字段名称
			switch (RewardGroup)
			{
				case RewardCell.CellGroup.Fixed:
				{
					RewardAttr = "fixed-item-";
					CountMinAttr = "fixed-item-min-";
					CountMaxAttr = "fixed-item-max-";
				}
				break;


				case RewardCell.CellGroup.g1:
				{
					RewardAttr = "group-1-item-";
					CountMinAttr = "group-1-item-stack-count-";
					Extra = "G1";
				}
				break;

				case RewardCell.CellGroup.g2:
				{
					RewardAttr = "group-2-item-";
					CountMinAttr = "group-2-item-stack-count-";
					Extra = "G2";
				}
				break;

				case RewardCell.CellGroup.g3:
				{
					RewardAttr = "group-3-item-";
					CountMinAttr = "group-3-item-stack-count-";
					Extra = "G3";
				}
				break;

				case RewardCell.CellGroup.rare:
				{
					RewardAttr = "rare-item-";
					CountMinAttr = "rare-item-stack-count-";
					Extra = "Rare";
				}
				break;

				case RewardCell.CellGroup.selected:
				{
					RewardAttr = "selected-item-";
					CountMinAttr = "selected-item-count-";
				}
				break;

				default: throw new Exception("未知的奖励类型: " + RewardGroup);
			}
			#endregion
			#endregion


			#region 遍历属性
			foreach (var attribute in this.DecomposeReward.Attributes)
			{
				//用于统计时间
				DateTime dt = DateTime.Now;

				if (!attribute.Key.RegexMatch(RewardAttr + @"[0-9]*$")) continue;

				string ItemAlias = attribute.Value;
				if (string.IsNullOrWhiteSpace(ItemAlias)) continue;

				#region	获得数量信息
				string Count = null, Count_Max = null;

				bool ExistMin = !CountMinAttr.IsNull();
				bool ExistMax = !CountMaxAttr.IsNull();

				if (ExistMin || ExistMax)
				{
					//获取当前组内奖励编号
					if (int.TryParse(attribute.Key.RemovePrefixString(RewardAttr), out int WithinIdx))
					{
						if (ExistMin) Count = this.DecomposeReward.Attributes[CountMinAttr + WithinIdx];
						if (ExistMax) Count_Max = this.DecomposeReward.Attributes[CountMaxAttr + WithinIdx];
					}
					else Console.WriteLine("转换组失败 <- " + attribute.Key.RemovePrefixString(RewardAttr));
				}
				#endregion

				result.Add(new RewardCell()
				{
					Group = RewardGroup,
					CellIdx = result.Count,

					ItemAlias = ItemAlias,
					ItemExtra = Extra,
					Count_Max = Count_Max.ToIntWithNull(),
					Count_Min = Count.ToIntWithNull(),
				});


#if DEBUG
				Console.WriteLine($"[Debug] 初始化奖励元素 => { ItemAlias }，耗时{ (DateTime.Now - dt).TotalMilliseconds }ms");
#endif
			}
			#endregion

			return result;
		}
		#endregion
	}
}
