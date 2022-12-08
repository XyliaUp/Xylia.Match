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


		[Signal("draw-cost-money-2")]
		public int DrawCostMoney2;

		[Signal("draw-cost-main-item-1")]
		public string DrawCostMainItem2;

		[Signal("draw-cost-main-item-count-2")]
		public int DrawCostMainItemCount2;


		[Signal("draw-cost-money-3")]
		public int DrawCostMoney3;

		[Signal("draw-cost-main-item-3")]
		public string DrawCostMainItem3;

		[Signal("draw-cost-main-item-count-3")]
		public int DrawCostMainItemCount3;



		[Signal("draw-cost-money-4")]
		public int DrawCostMoney4;

		[Signal("draw-cost-main-item-4")]
		public string DrawCostMainItem4;

		[Signal("draw-cost-main-item-count-4")]
		public int DrawCostMainItemCount4;
		#endregion
	}
}
