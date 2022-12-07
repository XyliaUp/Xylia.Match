using System.Collections.Generic;
using System.ComponentModel;

using Xylia.Preview.Project.Common.Interface;


namespace Xylia.Preview.Data.Record
{
	public sealed class RandomStoreItemDisplay : IRecord
	{
		#region 属性字段
		/// <summary>
		/// 聚灵阁类型
		/// </summary>
		public RandomStoreNumber RandomStoreNumber;

		public string DisplayItem;

		public bool Paid;

		public DrawGroup drawGroup;

		public ProbabilityGroup probabilityGroup;

		public bool NewArrival;
		#endregion



		#region 枚举
		public enum DrawGroup : byte
		{
			None,

			[Description("鸿运专属宝物")]
			Premium,

			[Description("宝物")]
			Normal,
		}

		public enum ProbabilityGroup : byte
		{
			None,

			[Description("稀有概率")]
			Rare,

			[Description("一般概率")]
			Normal,
		}
		#endregion
	}


	/// <summary>
	/// 排序器
	/// </summary>
	public class RandomStoreItemDisplaySort : IComparer<RandomStoreItemDisplay>
	{
		public int Compare(RandomStoreItemDisplay x, RandomStoreItemDisplay y)
		{
			//先判断是否是最新
			if (!x.NewArrival && y.NewArrival) return 1;
			else if (x.NewArrival && !y.NewArrival) return -1;

			var Ix = x.DisplayItem.GetItemInfo();
			var Iy = y.DisplayItem.GetItemInfo();

			//判断物品品质（大的在前）
			if (Ix.ItemGrade != Iy.ItemGrade) return Iy.ItemGrade - Ix.ItemGrade;

			//判断物品种类（小的在前）
			//if (Ix.GameCategory3 != Iy.GameCategory3) return Ix.GameCategory3 - Iy.GameCategory3;

			//最后判断顺序（小的在前）
			return x.ID - y.ID;
		}
	}
}
