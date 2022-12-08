using System.Collections.Generic;

using Xylia.Attribute.Component;
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
			weapon,

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




		public enum GameCategory3Seq
		{
			None,

			Sword,

			Gauntlet,

			[Signal("aura-bangle")]
			AuraBangle,

			Axe,

			Dagger,

			Staff,

			[Signal("lyn-sword")]
			LynSword,

			[Signal("warlock-dagger")]
			WarlockDagger,

			[Signal("soul-fighter-gauntlet")]
			SoulFighterGauntlet,

			Gun,

			[Signal("great-sword")]
			GreatSword,

			[Signal("long-bow")]
			LongBow,

			Spear,

			Orb,

			[Signal("dual-blade")]
			DualBlade,

			Necklace,

			Ring,

			Earring,

			Bracelet,

			Belt,

			Gloves,

			Soul,

			[Signal("soul-2")]
			Soul2,

			[Signal("rune-1")]
			Rune1,

			[Signal("rune-2")]
			Rune2,

			Pet,

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

			Costume,

			[Signal("head-attach")]
			HeadAttach,

			[Signal("face-attach")]
			FaceAttach,

			[Signal("costume-attach")]
			CostumeAttach,

			[Signal("summoned-pet-costume")]
			SummonedPetCostume,

			[Signal("summoned-pet-hat")]
			SummonedPetHat,

			[Signal("summoned-pet-attach")]
			SummonedPetAttach,

			Gam1,

			Gan2,

			Jin3,

			Son4,

			Ri5,

			Gon6,

			Tae7,

			Geon8,

			[Signal("synthesis-gem")]
			SynthesisGem,

			[Signal("feed-gem")]
			FeedGem,

			Diamond,

			Ruby,

			Topaz,

			Sapphire,

			Jade,

			Emerald,

			Amethyst,

			Aquamarine,

			Amber,

			Obsidian,

			Garnet,

			[Signal("ruby-topaz")]
			RubyTopaz,

			[Signal("ruby-sapphire")]
			RubySapphire,

			[Signal("ruby-jade")]
			RubyJade,

			[Signal("ruby-amethyst")]
			RubyAmethyst,

			[Signal("ruby-emerald")]
			RubyEmerald,

			[Signal("ruby-diamond")]
			RubyDiamond,

			[Signal("topaz-sapphire")]
			TopazSapphire,

			[Signal("topaz-jade")]
			TopazJade,

			[Signal("topaz-amethyst")]
			TopazAmethyst,

			[Signal("topaz-emerald")]
			TopazEmerald,

			[Signal("topaz-diamond")]
			TopazDiamond,

			[Signal("sapphire-jade")]
			SapphireJade,

			[Signal("sapphire-amethyst")]
			SapphireAmethyst,

			[Signal("sapphire-emerald")]
			SapphireEmerald,

			[Signal("sapphire-diamond")]
			SapphireDiamond,

			[Signal("jade-amethyst")]
			JadeAmethyst,

			[Signal("jade-emerald")]
			JadeEmerald,

			[Signal("jade-diamond")]
			JadeDiamond,

			[Signal("amethyst-emerald")]
			AmethystEmerald,

			[Signal("amethyst-diamond")]
			AmethystDiamond,

			[Signal("emerald-diamond")]
			EmeraldDiamond,

			[Signal("aquamarine-diamond")]
			AquamarineDiamond,

			[Signal("amber-diamond")]
			AmberDiamond,

			[Signal("obsidian-garnet")]
			ObsidianGarnet,

			[Signal("corundum-white")]
			CorundumWhite,

			[Signal("corundum-black")]
			CorundumBlack,

			[Signal("corundum-pink")]
			CorundumPink,

			[Signal("corundum-yellow")]
			CorundumYellow,

			[Signal("corundum-bluegreen")]
			CorundumBluegreen,

			[Signal("corundum-blue")]
			CorundumBlue,

			[Signal("corundum-aquamarine")]
			CorundumAquamarine,

			[Signal("corundum-amber")]
			CorundumAmber,

			[Signal("corundum-ruby")]
			CorundumRuby,

			[Signal("corundum-amethyst")]
			CorundumAmethyst,

			[Signal("corundum-jade")]
			CorundumJade,

			[Signal("skill-stone")]
			SkillStone,

			[Signal("skill-stone-1")]
			SkillStone1,

			[Signal("skill-stone-2")]
			SkillStone2,

			[Signal("skill-stone-accessory")]
			SkillStoneAccessory,

			[Signal("regenerate-potion")]
			RegeneratePotion,

			[Signal("heal-potion")]
			HealPotion,

			[Signal("secret-potion")]
			SecretPotion,

			[Signal("detox-potion")]
			DetoxPotion,

			[Signal("magic-potion")]
			MagicPotion,

			[Signal("hwan-dan")]
			HwanDan,

			Cook,

			[Signal("exp-cook")]
			ExpCook,

			Alcohol,

			[Signal("normal-repair-tool")]
			NormalRepairTool,

			[Signal("urgency-repair-tool")]
			UrgencyRepairTool,

			Key,

			[Signal("weapon-gem-make")]
			WeaponGemMake,

			[Signal("festival-tool")]
			FestivalTool,

			[Signal("fishing-goods")]
			FishingGoods,

			[Signal("reset-talisman")]
			ResetTalisman,

			[Signal("revive-talisman")]
			ReviveTalisman,

			[Signal("party-revive-talisman")]
			PartyReviveTalisman,

			[Signal("growth-talisman")]
			GrowthTalisman,

			[Signal("unseal-talisman")]
			UnsealTalisman,

			[Signal("seal-talisman")]
			SealTalisman,

			[Signal("escape-talisman")]
			EscapeTalisman,

			[Signal("build-up-talisman")]
			BuildUpTalisman,

			Valuables,

			Wealth,

			[Signal("holy-material")]
			HolyMaterial,

			[Signal("weapon-material")]
			WeaponMaterial,

			[Signal("party-battle-material")]
			PartyBattleMaterial,

			[Signal("raid-material")]
			RaidMaterial,

			[Signal("weapon-seed-material")]
			WeaponSeedMaterial,

			[Signal("accessory-material")]
			AccessoryMaterial,

			[Signal("synthetic-material")]
			SyntheticMaterial,

			[Signal("weapon-exp")]
			WeaponExp,

			[Signal("accessory-exp")]
			AccessoryExp,

			[Signal("weapon-maker")]
			WeaponMaker,

			[Signal("talis-maker")]
			TalisMaker,

			[Signal("equip-gem-maker")]
			EquipGemMaker,

			[Signal("accessory-maker")]
			AccessoryMaker,

			[Signal("medicine-maker")]
			MedicineMaker,

			[Signal("food-maker")]
			FoodMaker,

			[Signal("common-maker")]
			CommonMaker,

			[Signal("hypermove-material")]
			HypermoveMaterial,

			[Signal("production-material")]
			ProductionMaterial,

			Cloth,

			[Signal("dress-design")]
			DressDesign,

			[Signal("color-material")]
			ColorMaterial,

			Pattern,

			[Signal("special-material")]
			SpecialMaterial,

			[Signal("normal-material")]
			NormalMaterial,

			[Signal("weapon-coin")]
			WeaponCoin,

			Token,

			[Signal("naryu-coin")]
			NaryuCoin,

			[Signal("pvp-coin")]
			PvpCoin,

			[Signal("rvr-coin")]
			RvrCoin,

			[Signal("festival-coin")]
			FestivalCoin,

			[Signal("hero-coin")]
			HeroCoin,

			[Signal("spirit-coin")]
			SpiritCoin,

			[Signal("normal-coin")]
			NormalCoin,

			[Signal("skill-deed")]
			SkillDeed,

			[Signal("skill-take-deed")]
			SkillTakeDeed,

			Ticket,

			[Signal("reset-deed")]
			ResetDeed,

			[Signal("extend-deed")]
			ExtendDeed,

			[Signal("exchange-deed")]
			ExchangeDeed,

			[Signal("switch-deed")]
			SwitchDeed,

			[Signal("normal-deed")]
			NormalDeed,

			[Signal("guild-deed")]
			GuildDeed,

			[Signal("quest-start")]
			QuestStart,

			[Signal("quest-virtual")]
			QuestVirtual,

			[Signal("chack-item")]
			ChackItem,

			[Signal("sundry-item")]
			SundryItem,

			[Signal("normal-weapon-box")]
			NormalWeaponBox,

			[Signal("shape-weapon-box")]
			ShapeWeaponBox,

			[Signal("normal-accessory-box")]
			NormalAccessoryBox,

			[Signal("normal-dress-box")]
			NormalDressBox,

			[Signal("normal-equip-gem-box")]
			NormalEquipGemBox,

			[Signal("normal-weapon-gem-box")]
			NormalWeaponGemBox,

			[Signal("normal-material-box")]
			NormalMaterialBox,

			[Signal("normal-booty-box")]
			NormalBootyBox,

			[Signal("normal-etc-box")]
			NormalEtcBox,

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

			[Signal("fusion-material")]
			FusionMaterial,

			Card,
		}
	}
}