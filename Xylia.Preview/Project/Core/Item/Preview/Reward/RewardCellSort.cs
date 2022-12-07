using System.Collections.Generic;

namespace Xylia.Preview.Project.Core.Item.Cell
{
	/// <summary>
	/// 奖励显示排序方法
	/// </summary>
	public class RewardCellSort : IComparer<RewardCell>
	{
		/// <summary>
		/// 排序，1表示 A在后，-1表示 A在前
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		public int Compare(RewardCell x, RewardCell y)
		{
			#region Fixed 组
			if (x.Group == RewardCell.CellGroup.Fixed && y.Group != RewardCell.CellGroup.Fixed) return -1;
			else if (y.Group == RewardCell.CellGroup.Fixed && x.Group != RewardCell.CellGroup.Fixed) return 1;
			#endregion

			#region Selected 组
			else if (x.Group == RewardCell.CellGroup.selected && y.Group != RewardCell.CellGroup.selected) return -1;
			else if (y.Group == RewardCell.CellGroup.selected && x.Group != RewardCell.CellGroup.selected) return 1;
			#endregion


			#region 同类型道具再按品质排序
			var GradeA = x.ItemGrade;
			var GradeB = y.ItemGrade;

			if (GradeA == GradeB)
			{
				if (x.Group == RewardCell.CellGroup.rare && y.Group == RewardCell.CellGroup.rare) return x.ItemInfo.ID - y.ItemInfo.ID;
				else if (x.Group == RewardCell.CellGroup.g3 && y.Group == RewardCell.CellGroup.g3) return x.CellIdx - y.CellIdx;

				//最后判断物品id
				else return x.ItemInfo.ID - y.ItemInfo.ID;
			}
			else return GradeA - GradeB;
			#endregion
		}
	}
}
