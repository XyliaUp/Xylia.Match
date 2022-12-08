using Xylia.Attribute.Component;
using Xylia.Preview.Common.Interface;

namespace Xylia.Preview.Data.Record
{
	/// <summary>
	/// 聚灵阁物品
	/// </summary>
	public sealed class RandomStoreItem : IRecord
	{
		#region 属性字段
		public string Item;

		[Signal("item-count")]
		public int ItemCount;

		[Signal("item-price-money")]
		public int ItemPriceMoney;

		/// <summary>
		/// 需要物品
		/// </summary>
		[Signal("item-price-item")]
		public string ItemPriceItem;

		[Signal("item-price-item-amount")]
		public short ItemPriceItemAmount;
		#endregion
	}
}
