using System.ComponentModel;

using Xylia.Extension;



namespace Xylia.Preview.Data.Record
{

	public sealed partial class Item
	{
		#region 字段
		[Description("weapon-type")]
		public WeaponTypeSeq WeaponType => this.Attributes["weapon-type"]?.ToEnum<WeaponTypeSeq>() ?? 0;
		public enum WeaponTypeSeq
		{
			BareHand = 1,
			Sword,
			Gauntlet,
			AuraBangle,
			Pistol,
			Rifle,
			TwoHandedAxe,
			Bow,
			Staff,
			Dagger,
			Pet1,
			Pet2,
			Gun,
			GreatSword,
			LongBow,
			Spear,
			Orb,

			[Description("dual-blade")]
			DualBlade,
		}



		[Description("weapon-appearance-change-type")]
		public WeaponAppearanceChangeTypeSeq WeaponAppearanceChangeType => this.Attributes["weapon-appearance-change-type"]?.ToEnum<WeaponAppearanceChangeTypeSeq>() ?? 0;
		public enum WeaponAppearanceChangeTypeSeq
		{
			None,

			[Description("used-only-as-target-weapon")]
			UsedOnlyAsTargetWeapon,

			[Description("used-only-as-applying-weapon")]
			UsedOnlyAsApplyingWeapon,

			[Description("both")]
			Both,
		}


		public SkillByEquipment SkillByEquipment => FileCache.Data.SkillByEquipment[this.Attributes["skill-by-equipment"]];
		#endregion
	}
}
