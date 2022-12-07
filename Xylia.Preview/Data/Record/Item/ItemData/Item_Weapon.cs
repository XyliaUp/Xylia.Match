using System.ComponentModel;

using Xylia.Extension;



namespace Xylia.Preview.Data.Record
{

	public sealed partial class Item
	{
		#region 字段
		[Description("weapon-type")]
		public WeaponType weaponType => this.Attributes["weapon-type"]?.ToEnum<WeaponType>() ?? 0;

		[Description("weapon-appearance-change-type")]
		public WeaponAppearanceChangeType weaponAppearanceChangeType => this.Attributes["weapon-appearance-change-type"]?.ToEnum<WeaponAppearanceChangeType>() ?? 0;
		#endregion


		#region 枚举
		public enum WeaponType
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

		public enum WeaponAppearanceChangeType
		{
			None,

			[Description("used-only-as-target-weapon")]
			UsedOnlyAsTargetWeapon,

			[Description("used-only-as-applying-weapon")]
			UsedOnlyAsApplyingWeapon,

			[Description("both")]
			Both,
		}
		#endregion
	}
}
