using System.ComponentModel;

using Xylia.Attribute.Component;
using Xylia.Preview.Common.Interface;

namespace Xylia.Preview.Data.Record
{
	public sealed class RandomStoreItemDisplay : IRecord
	{
		#region 属性字段
		[Signal("random-store-type")]
		public RandomStoreTypeSeq RandomStoreType;

		[Signal("display-item")]
		public string DisplayItem;

		[Signal("draw-group")]
		public DrawGroupSeq DrawGroup;

		[Signal("probability-group")]
		public ProbabilityGroupSeq ProbabilityGroup;

		[Signal("new-arrival")]
		public bool NewArrival;
		#endregion

		#region 枚举
		public enum RandomStoreTypeSeq : byte
		{
			None,

			Paid,

			Free,
		}

		public enum DrawGroupSeq : byte
		{
			None,

			[Description("鸿运专属宝物")]
			Premium,

			[Description("宝物")]
			Normal,
		}

		public enum ProbabilityGroupSeq : byte
		{
			None,

			[Description("稀有概率")]
			Rare,

			[Description("一般概率")]
			Normal,
		}
		#endregion
	}
}
