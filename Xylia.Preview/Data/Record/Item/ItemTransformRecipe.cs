using System.Collections.Generic;

using Xylia.Attribute.Component;
using Xylia.bns.Modules.GameData.Enums;
using Xylia.Extension;
using Xylia.Preview.Common.Interface;

namespace Xylia.Preview.Data.Record
{
	/// <summary>
	/// 物品成长
	/// </summary>
	public sealed class ItemTransformRecipe : IRecord
	{
		#region 属性字段
		public int RequiredInvenCapacity;
		public int MoneyCost;

		/// <summary>
		/// 主祭品
		/// </summary>
		public string MainIngredient;
		public ConditionType MainIngredientConditionType;
		public int MainIngredientMinLevel;
		public int MainIngredientStackCount;
		public string MainIngredientTitleName;

		public bool KeepMainIngredientWeaponGemSlot;
		public bool KeepMainIngredientWeaponAppearance;
		public bool KeepMainIngredientSpirit;
		
		public string TitleItem;
		public string TitleName;
		public string TitleReward;

		public string RandomboxPreview;
		public CategorySeq Category;
		public bool UseRandom;


		/// <summary>
		/// 警告信息
		/// </summary>
		public Warning warning;
		#endregion

		#region 枚举
		public enum CategorySeq : byte
		{
			None,

			Event,

			Material,

			Costume,

			Weapon,

			[Signal("legendary-weapon")]
			LegendaryWeapon,

			Accessory,

			[Signal("weapon-gem-adder")]
			WeaponGemAdder,

			[Signal("weapon-gem2")]
			WeaponGem2,

			Piece,

			Purification,

			Special,

			Pet,

			[Signal("pet-legend")]
			PetLegend,

			[Signal("pet-change")]
			PetChange,

			[Signal("taiji-gem")]
			TaijiGem,

			Division,

			[Signal("weapon-enchant-gem")]
			WeaponEnchantGem,

			Sewing,

			[Signal("weapon-transform")]
			WeaponTransform,

			[Signal("accessory-transform")]
			AccessoryTransform,

			[Signal("equip-gem")]
			EquipGem,
		}

		public enum Warning : byte
		{
			None,

			Fail,

			Stuck,

			Gemslotreset,

			[Signal("fail-gemslotreset")]
			FailGemslotreset,

			[Signal("stuck-gemslotreset")]
			StuckGemslotreset,

			Change,

			Lower,

			[Signal("lower-gemslotreset")]
			LowerGemslotreset,

			Partialfail,

			Tradeimpossible,

			[Signal("delete-particle")]
			DeleteParticle,

			[Signal("delete-design")]
			DeleteDesign,

			Spiritreset,

			[Signal("fail-spiritreset")]
			FailSpiritreset,

			[Signal("gemslotreset-spiritreset")]
			GemslotresetSpiritreset,

			[Signal("fail-gemslotreset-spiritreset")]
			FailGemslotresetSpiritreset,

			[Signal("lower-spiritreset")]
			LowerSpiritreset,

			[Signal("lower-gemslotreset-spiritreset")]
			LowerGemslotresetSpiritreset,

			[Signal("partialfail-spiritreset")]
			PartialfailSpiritreset,

			[Signal("cannot-division")]
			CannotDivision,

			[Signal("fail-cannot-division")]
			FailCannotDivision,
		}
		#endregion




		#region 方法
		/// <summary>
		/// 查询物品成长路径
		/// </summary>
		public static IEnumerable<ItemTransformRecipe> QueryRecipe(Item ItemInfo)
		{
			if (ItemInfo is null) return null;

			return FileCache.Data.ItemTransformRecipe.Where(a =>
			{
				var CurMainIngredient = a.MainIngredient;

				if (CurMainIngredient is null) return false;
				else if (CurMainIngredient.MyStartsWith("Item:")) return CurMainIngredient.MyEquals("Item:" + ItemInfo.Alias);
				else if (CurMainIngredient.MyStartsWith("ItemBrand:") && CurMainIngredient.MyEquals("ItemBrand:" + ItemInfo.Brand))
				{
					//校验条件类型
					if (ItemInfo.ConditionTypes.Contains(a.MainIngredientConditionType))
					{
						return CurMainIngredient.MyEquals("ItemBrand:" + ItemInfo.Brand);
					}
					else
					{
						//Console.WriteLine($"没有对应数据 => " a.alias + "_" + a.MainIngredientConditionType);
					}
				}

				return false;
			});
		}
		#endregion
	}
}
