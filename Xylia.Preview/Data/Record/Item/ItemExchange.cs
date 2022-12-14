using System.Collections.Generic;
using System.ComponentModel;

using Xylia.Attribute.Component;
using Xylia.Extension;
using Xylia.Preview.Common.Interface;

namespace Xylia.Preview.Data.Record
{
	public sealed class ItemExchange : IRecord
	{
		#region 属性字段
		public RuleUsage ruleUsage;

		[Signal("required-item-1")]
		public string RequiredItem1;

		[Signal("required-item-2")]
		public string RequiredItem2;

		[Signal("required-item-3")]
		public string RequiredItem3;

		[Signal("required-item-4")]
		public string RequiredItem4;

		[Signal("required-item-min-level-1")]
		public byte RequiredItemMinLevel1;

		[Signal("required-item-min-level-2")]
		public byte RequiredItemMinLevel2;

		[Signal("required-item-min-level-3")]
		public byte RequiredItemMinLevel3;

		[Signal("required-item-min-level-4")]
		public byte RequiredItemMinLevel4;

		[Signal("required-item-stack-count-1")]
		public short RequiredItemStackCount1;

		[Signal("required-item-stack-count-2")]
		public short RequiredItemStackCount2;

		[Signal("required-item-stack-count-3")]
		public short RequiredItemStackCount3;

		[Signal("required-item-stack-count-4")]
		public short RequiredItemStackCount4;

		[Signal("normal-item-1")]
		public string NormalItem1;

		[Signal("normal-item-2")]
		public string NormalItem2;

		[Signal("normal-item-3")]
		public string NormalItem3;

		[Signal("normal-item-4")]
		public string NormalItem4;

		[Signal("normal-item-stack-count-1")]
		public short NormalItemStackCount1;

		[Signal("normal-item-stack-count-2")]
		public short NormalItemStackCount2;

		[Signal("normal-item-stack-count-3")]
		public short NormalItemStackCount3;

		[Signal("normal-item-stack-count-4")]
		public short NormalItemStackCount4;
		#endregion

		#region 枚举
		public enum RuleUsage
		{
			/// <summary>
			/// 旧物交换
			/// </summary>
			[Signal("antique-exchange")]
			[Description("旧物交换")]
			AntiqueExchange,

			/// <summary>
			/// 加工
			/// </summary>
			[Signal("crystallization")]
			[Description("加工")]
			Crystallization,
		}
		#endregion


		#region 方法
		public static IEnumerable<ItemExchange> LoadNormalItem(string ItemAlias)
			=> FileCache.Data.ItemExchange.Where(Info =>
			   (Info.NormalItem1?.MyEquals(ItemAlias) ?? false)
			|| (Info.NormalItem2?.MyEquals(ItemAlias) ?? false)
			|| (Info.NormalItem3?.MyEquals(ItemAlias) ?? false)
			|| (Info.NormalItem4?.MyEquals(ItemAlias) ?? false));

		public static IEnumerable<ItemExchange> LoadRequiredItem(string ItemAlias, string IteBrand)
			=> FileCache.Data.ItemExchange.Where(Info =>
			   (Info.RequiredItem1?.MyEquals("item:" + ItemAlias) ?? false) || (Info.RequiredItem1?.MyEquals("itembrand:" + IteBrand) ?? false)
			|| (Info.RequiredItem2?.MyEquals("item:" + ItemAlias) ?? false) || (Info.RequiredItem2?.MyEquals("itembrand:" + IteBrand) ?? false)
			|| (Info.RequiredItem3?.MyEquals("item:" + ItemAlias) ?? false) || (Info.RequiredItem3?.MyEquals("itembrand:" + IteBrand) ?? false)
			|| (Info.RequiredItem4?.MyEquals("item:" + ItemAlias) ?? false) || (Info.RequiredItem4?.MyEquals("itembrand:" + IteBrand) ?? false));
		#endregion
	}
}
