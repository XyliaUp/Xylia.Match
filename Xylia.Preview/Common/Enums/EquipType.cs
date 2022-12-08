using System.ComponentModel;

using Xylia.Attribute.Component;

namespace Xylia.Preview.Common.Enums
{
	public enum EquipType
	{
		None,

		[Description("武器")]
		weapon,

		[Description("服装")]
		costume,

		[Description("耳环")]
		earring,

		[Description("脸饰")]
		eyeglass,

		[Description("头饰")]
		hat,

		[Description("戒指")]
		ring,

		[Description("项链")]
		necklace,

		[Signal("Gem-1")]
		Gem1,

		[Signal("Gem-2")]
		Gem2,

		[Signal("Gem-3")]
		Gem3,

		[Signal("Gem-4")]
		Gem4,

		[Signal("Gem-5")]
		Gem5,

		[Signal("Gem-6")]
		Gem6,

		[Signal("Gem-7")]
		Gem7,

		[Signal("Gem-8")]
		Gem8,

		[Description("服饰")]
		attach,

		[Description("腰带")]
		belt,

		[Description("手镯")]
		bracelet,

		[Description("魂")]
		soul,

		[Description("灵")]
		[Signal("soul-2")]
		Soul2,

		[Description("手套")]
		[Signal("gloves")]
		Gloves,

		[Description("守护石")]
		[Signal("pet-1")]
		Pet1,

		[Signal("pet-2")]
		Pet2,

		[Signal("rune-1")]
		Rune1,

		[Signal("rune-2")]
		Rune2,

		nova,

		[Signal("badge-1-premium")]
		Badge1Premium,

		[Signal("badge-2-premium")]
		Badge2Premium,

		[Signal("badge-3-premium")]
		Badge3Premium,

		[Signal("badge-1-normal")]
		Badge1Normal,

		[Signal("badge-2-normal")]
		Badge2Normal,

		[Signal("badge-3-normal")]
		Badge3Normal,

		[Signal("badge-appearance")]
		BadgeAppearance,


		vehicle,
	}
}
