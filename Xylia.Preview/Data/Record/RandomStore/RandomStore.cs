using System.ComponentModel;
using System.Linq;

using Xylia.Extension;
using Xylia.Files.XmlEx;
using Xylia.Preview.Common.Interface;
using Xylia.Attribute.Component;

namespace Xylia.Preview.Data.Record
{
	public sealed class RandomStore : IRecord
	{
		#region 属性字段
		/// <summary>
		/// 聚灵阁类型
		/// </summary>
		public RandomStoreNumber RandomStoreNumber;

		public int LimitLevel;

		[Signal("charge-of-item-draw")]
		public string ChargeOfItemDraw;

		[Signal("charge-of-money-draw")]
		public string ChargeOfMoneyDraw;

		/// <summary>
		/// 额外奖励次数
		/// </summary>
		[Signal("acquire-draw-reward-set-repeat-count")]
		public int AcquireDrawRewardSetRepeatCount;
		#endregion
	}


	/// <summary>
	/// 聚灵阁类型
	/// </summary>
	public enum RandomStoreNumber : uint
	{
		InvalidNumber,

		[Description("聚灵阁")]
		RandomStore1,

		[Description("金币聚灵阁")]
		RandomStore2,
	}
}
