using System.ComponentModel;

using Xylia.Extension;



namespace Xylia.Preview.Data.Record
{

	public sealed partial class Item
	{
		#region 字段
		[Description("custom-dress-design-state")]
		public CustomDressDesignState customDressDesignState => this.Attributes["custom-dress-design-state"].ToEnum<CustomDressDesignState>();
		#endregion


		#region 枚举
		public enum CustomDressDesignState
		{
			None,
			Disabled,
			Activated,
		}
		#endregion
	}
}
