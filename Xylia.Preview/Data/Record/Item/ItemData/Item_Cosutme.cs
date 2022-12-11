using System.ComponentModel;

using Xylia.Extension;



namespace Xylia.Preview.Data.Record
{

	public sealed partial class Item
	{
		#region 字段
		[Description("custom-dress-design-state")]
		public CustomDressDesignStateSeq CustomDressDesignState => this.Attributes["custom-dress-design-state"].ToEnum<CustomDressDesignStateSeq>();
		#endregion

		#region 枚举
		public enum CustomDressDesignStateSeq
		{
			None,
			Disabled,
			Activated,
		}
		#endregion
	}
}
