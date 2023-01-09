using System.ComponentModel;

using Xylia.Attribute.Component;

namespace Xylia.Preview.Common.Enums
{
	public enum EquipType
	{
		None,

		[Description("武器")]
		Weapon,

		[Description("服装")]
		Costume,

		[Description("耳环")]
		Earring,

		[Description("脸饰")]
		Eyeglass,

		[Description("头饰")]
		Hat,

		[Description("戒指")]
		Ring,

		[Description("项链")]
		Necklace,

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
		Attach,

		[Description("腰带")]
		Belt,

		[Description("手镯")]
		Bracelet,

		[Description("魂")]
		Soul,

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

		[Description("神功牌")]
		[Signal("rune-1")]
		Rune1,

		[Description("秘功牌")]
		[Signal("rune-2")]
		Rune2,

		[Description("星")]
		Nova,

		[Description("天光石")]
		[Signal("badge-1-premium")]
		Badge1Premium,

		[Description("地光石")]
		[Signal("badge-2-premium")]
		Badge2Premium,

		[Description("人光石")]
		[Signal("badge-3-premium")]
		Badge3Premium,

		[Description("天辉石")]
		[Signal("badge-1-normal")]
		Badge1Normal,

		[Description("地辉石")]
		[Signal("badge-2-normal")]
		Badge2Normal,

		[Description("人辉石")]
		[Signal("badge-3-normal")]
		Badge3Normal,

		[Description("焕彩石")]
		[Signal("badge-appearance")]
		BadgeAppearance,

		[Description("坐骑")]
		Vehicle,
	}
}
