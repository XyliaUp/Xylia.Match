
using Xylia.Attribute.Component;
using Xylia.Preview.Project.Common.Interface;

namespace Xylia.Preview.Data.Record
{
	/// <summary>
	/// 刻印书
	/// </summary>
	public class SlateScroll : IRecord
	{
		#region 属性字段
		[Signal("ingredient-item-1")]
		public string IngredientItem1;

		[Signal("ingredient-item-2")]
		public string IngredientItem2;

		[Signal("ingredient-item-3")]
		public string IngredientItem3;

		[Signal("ingredient-item-4")]
		public string IngredientItem4;

		[Signal("ingredient-item-5")]
		public string IngredientItem5;

		[Signal("ingredient-count-1")]
		public short IngredientCount1;

		[Signal("ingredient-count-2")]
		public short IngredientCount2;

		[Signal("ingredient-count-3")]
		public short IngredientCount3;

		[Signal("ingredient-count-4")]
		public short IngredientCount4;

		[Signal("ingredient-count-5")]
		public short IngredientCount5;

		[Signal("secondary-cash-enable")]
		public bool SecondaryCashEnable;

		[Signal("ingredient-money")]
		public int IngredientMoney;

		[Signal("secondary-cash")]
		public string SecondaryCash;
		#endregion
	}
}
