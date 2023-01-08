using System.Collections.Generic;

using Xylia.Preview.Data.Record;

namespace Xylia.Preview.Project.Core.Item.Cell
{
	/// <summary>
	/// 奖励显示排序方法
	/// </summary>
	public class RewardCellSort : IComparer<RewardCell>
	{
		public int Compare(RewardCell x, RewardCell y)
		{
			#region Fixed 组
			if (x.Group == RewardCell.CellGroup.Fixed && y.Group != RewardCell.CellGroup.Fixed) return -1;
			else if (y.Group == RewardCell.CellGroup.Fixed && x.Group != RewardCell.CellGroup.Fixed) return 1;
			#endregion

			#region Selected 组
			else if (x.Group == RewardCell.CellGroup.Selected && y.Group != RewardCell.CellGroup.Selected) return -1;
			else if (y.Group == RewardCell.CellGroup.Selected && x.Group != RewardCell.CellGroup.Selected) return 1;
			#endregion


			#region 同类型道具再按品质排序
			var GradeA = x.ItemGrade;
			var GradeB = y.ItemGrade;

			if (GradeA == GradeB) return x.CellIdx - y.CellIdx;
			return GradeA - GradeB;
			#endregion
		}
	}
}