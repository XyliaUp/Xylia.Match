using System.ComponentModel;

using Xylia.Extension;



namespace Xylia.Preview.Data.Record
{

	public sealed partial class Item
	{
		#region 字段
		public AccessoryType accessoryType => this.Attributes["accessory-type"].ToEnum<AccessoryType>();
		#endregion



		#region 枚举
		public enum AccessoryType
		{
			/// <summary>
			/// 服饰
			/// </summary>
			CostumeAttach = 1,

			Ring,
			Earring,
			Necklace,
			Belt,
			Bracelet,
			Soul,
			Soul2,
			Gloves,
			Rune1,
			Rune2,

			/// <summary>
			/// 星
			/// </summary>
			Nova,

			/// <summary>
			/// 坐骑
			/// </summary>
			Vehicle,


			[Description("appearance-normal")]
			AppearanceNormal,

			[Description("appearance-idle")]
			AppearanceIdle,

			[Description("appearance-hypermove")]
			AppearanceHypermove,

			[Description("appearance-chat")]
			AppearanceChat,

			[Description("appearance-frame")]
			AppearanceFrame,
		}
		#endregion
	}
}
