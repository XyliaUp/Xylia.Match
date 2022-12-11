using System.ComponentModel;

using Xylia.Attribute.Component;
using Xylia.Extension;



namespace Xylia.Preview.Data.Record
{

	public sealed partial class Item
	{
		#region 字段
		public AccessoryTypeSeq AccessoryType => this.Attributes["accessory-type"].ToEnum<AccessoryTypeSeq>();

		//public CustomDressDesignStateSeq CustomDressDesignState => this.Attributes["custom-dress-design-state"].ToEnum<CustomDressDesignStateSeq>();
		#endregion


		#region 枚举
		public enum AccessoryTypeSeq
		{
			Accessory,

			[Signal("costume-attach")]
			CostumeAttach,

			Ring,

			Earring,

			Necklace,

			Belt,

			Bracelet,

			Soul,

			[Signal("soul-2")]
			Soul2,

			Gloves,

			[Signal("rune-1")]
			Rune1,

			[Signal("rune-2")]
			Rune2,

			Nova,

			Vehicle,

			[Signal("appearance-normal")]
			AppearanceNormal,

			[Signal("appearance-idle")]
			AppearanceIdle,

			[Signal("appearance-chat")]
			AppearanceChat,

			[Signal("appearance-frame")]
			AppearanceFrame,

			[Signal("appearance-hypermove")]
			AppearanceHypermove,

			[Signal("appearance-name-plate")]
			AppearanceNamePlate,

			[Signal("appearance-speech-bubble")]
			AppearanceSpeechBubble,
		}
		#endregion
	}
}
