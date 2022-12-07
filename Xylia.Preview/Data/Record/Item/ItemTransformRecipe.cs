using System.Collections.Generic;

using Xylia.Attribute.Component;
using Xylia.bns.Modules.GameData.Enums;
using Xylia.Extension;
using Xylia.Preview.Project.Common.Interface;

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


		public string SubIngredient1;
		public string SubIngredient2;
		public string SubIngredient3;
		public string SubIngredient4;
		public string SubIngredient5;
		public string SubIngredient6;
		public string SubIngredient7;
		public ConditionType SubIngredientConditionType1;
		public ConditionType SubIngredientConditionType2;
		public ConditionType SubIngredientConditionType3;
		public ConditionType SubIngredientConditionType4;
		public ConditionType SubIngredientConditionType5;
		public ConditionType SubIngredientConditionType6;
		public ConditionType SubIngredientConditionType7;
		public byte SubIngredientMinLevel1;
		public byte SubIngredientMinLevel2;
		public byte SubIngredientMinLevel3;
		public byte SubIngredientMinLevel4;
		public byte SubIngredientMinLevel5;
		public byte SubIngredientMinLevel6;
		public byte SubIngredientMinLevel7;
		public short SubIngredientStackCount1;
		public short SubIngredientStackCount2;
		public short SubIngredientStackCount3;
		public short SubIngredientStackCount4;
		public short SubIngredientStackCount5;
		public short SubIngredientStackCount6;
		public short SubIngredientStackCount7;

		public string SubIngredientTitleName1;
		public string SubIngredientTitleName2;
		public string SubIngredientTitleName3;
		public string SubIngredientTitleName4;
		public string SubIngredientTitleName5;
		public string SubIngredientTitleName6;
		public string SubIngredientTitleName7;
		public string SubIngredientTitleItem1;
		public string SubIngredientTitleItem2;
		public string SubIngredientTitleItem3;
		public string SubIngredientTitleItem4;
		public string SubIngredientTitleItem5;
		public string SubIngredientTitleItem6;
		public string SubIngredientTitleItem7;
		public bool ConsumeSubIngredient;



		public string FixedIngredient1;
		public string FixedIngredient2;
		public string FixedIngredient3;
		public string FixedIngredient4;
		public string FixedIngredient5;
		public string FixedIngredient6;
		public string FixedIngredient7;
		public string FixedIngredient8;
		public short FixedIngredientStackCount1;
		public short FixedIngredientStackCount2;
		public short FixedIngredientStackCount3;
		public short FixedIngredientStackCount4;
		public short FixedIngredientStackCount5;
		public short FixedIngredientStackCount6;
		public short FixedIngredientStackCount7;
		public short FixedIngredientStackCount8;
		public bool ConsumeFixedIngredient;



		public string TitleItem;
		public string TitleName;
		public string TitleReward;


		public string RandomboxPreview;
		public Category category;
		public bool UseRandom;


		public string FailEffect;

		/// <summary>
		/// 警告信息
		/// </summary>
		public Warning warning;
		#endregion

		#region 枚举
		public enum Category : byte
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
		public static IEnumerable<ItemTransformRecipe> QueryRecipe(string ItemAlias) => QueryRecipe(ItemAlias.GetItemInfo());

		/// <summary>
		/// 查询物品成长路径
		/// </summary>
		public static IEnumerable<ItemTransformRecipe> QueryRecipe(Item ItemInfo)
		{
			if (ItemInfo is null) return null;

			return FileCache.Data.ItemTransformRecipe.Where(a =>
			{
				var CurMainIngredient = a.MainIngredient;

				if (CurMainIngredient.IsNull()) return false;
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
