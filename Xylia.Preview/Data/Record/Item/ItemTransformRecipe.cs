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
		public int MoneyCost;

		public string MainIngredient;
		public ConditionType MainIngredientConditionType = ConditionType.All;
		public int MainIngredientMinLevel;
		public int MainIngredientStackCount;
		public string MainIngredientTitleName;

		public string TitleItem;
		public string TitleName;

		public CategorySeq Category;
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


		public bool UseRandom;


		/// <summary>
		/// 警告信息
		/// </summary>
		public WarningSeq Warning;
		public enum WarningSeq : byte
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
			return FileCache.Data.ItemTransformRecipe.Where(o =>
			{
				if (o.MainIngredient is null) return false;
				else if (o.MainIngredient.MyStartsWith("Item:")) return o.MainIngredient.MyEquals("Item:" + ItemInfo.Alias);
				else if (o.MainIngredient.MyStartsWith("ItemBrand:") && o.MainIngredient.MyEquals("ItemBrand:" + ItemInfo.Brand))
				{
					//校验条件类型
					if (ItemInfo.ConditionTypes.Contains(o.MainIngredientConditionType)) return true;
				}

				return false;


			},true);
		}
		#endregion
	}
}