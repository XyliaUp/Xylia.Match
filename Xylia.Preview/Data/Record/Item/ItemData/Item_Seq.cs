using System.Collections.Generic;

using Xylia.bns.Modules.GameData.Enums;

namespace Xylia.Preview.Data.Record
{
	/// <summary>
	/// 枚举支持
	/// </summary>
	public sealed partial class Item
	{
		/// <summary>
		/// 物品类型
		/// </summary>
		public enum ItemType
		{
			weapon = 0,

			/// <summary>
			/// 服装
			/// </summary>
			costume,

			grocery,

			gem,

			/// <summary>
			/// 饰品
			/// </summary>
			accessory
		}

		/// <summary>
		/// 物品条件类型
		/// </summary>
		public List<ConditionType> ConditionTypes
		{
			get
			{
				var CondTypes = new List<ConditionType>
				{
					ConditionType.All
				};

				var Type = this.Type;



				if (Type == ItemType.weapon)
				{
					var WeaponType = this.weaponType;

					if (WeaponType != WeaponType.Pet1 && WeaponType != WeaponType.Pet2) CondTypes.Add(ConditionType.Weapon);

					switch (WeaponType)
					{
						case WeaponType.Sword: CondTypes.Add(ConditionType.Sword); break;
						case WeaponType.Gauntlet: CondTypes.Add(ConditionType.Gauntlet); break;
						case WeaponType.AuraBangle: CondTypes.Add(ConditionType.AuraBangle); break;
						case WeaponType.TwoHandedAxe: CondTypes.Add(ConditionType.Axe); break;
						case WeaponType.Staff: CondTypes.Add(ConditionType.Staff); break;
						case WeaponType.Dagger:
						{
							CondTypes.Add(ConditionType.Dagger);
						}
						break;
						case WeaponType.Pet1: CondTypes.Add(ConditionType.Pet1); break;
						case WeaponType.Pet2: CondTypes.Add(ConditionType.Pet2); break;
						case WeaponType.Gun: CondTypes.Add(ConditionType.ShooterGun); break;
						case WeaponType.GreatSword: CondTypes.Add(ConditionType.GreatSword); break;
						case WeaponType.LongBow: CondTypes.Add(ConditionType.LongBow); break;
						case WeaponType.Spear: CondTypes.Add(ConditionType.Spear); break;
						case WeaponType.Orb: CondTypes.Add(ConditionType.Orb); break;
					}
				}
				else if (Type == ItemType.accessory)
				{
					CondTypes.Add(ConditionType.Accessory);

					switch (this.accessoryType)
					{
						case AccessoryType.Ring: CondTypes.Add(ConditionType.Ring); break;
						case AccessoryType.Earring: CondTypes.Add(ConditionType.Earring); break;
						case AccessoryType.Necklace: CondTypes.Add(ConditionType.Necklace); break;
						case AccessoryType.Belt: CondTypes.Add(ConditionType.Belt); break;
						case AccessoryType.Bracelet: CondTypes.Add(ConditionType.Bracelet); break;
						case AccessoryType.Soul: CondTypes.Add(ConditionType.Soul); break;
						case AccessoryType.Gloves: CondTypes.Add(ConditionType.Gloves); break;
						case AccessoryType.Rune1: CondTypes.Add(ConditionType.Rune1); break;
						case AccessoryType.Rune2: CondTypes.Add(ConditionType.Rune2); break;
					}
				}

				return CondTypes;
			}
		}
	}
}