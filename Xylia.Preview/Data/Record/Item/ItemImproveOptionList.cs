using Xylia.Attribute.Component;
using Xylia.Preview.Common.Interface;

namespace Xylia.Preview.Data.Record
{
	public sealed class ItemImproveOptionList : IRecord
	{
		#region 属性字段
		[Signal("draw-cost-money-1")]
		public int DrawCostMoney1;

		[Signal("draw-cost-main-item-1")]
		public string DrawCostMainItem1;

		[Signal("draw-cost-main-item-count-1")]
		public int DrawCostMainItemCount1;
		#endregion
	}
}
