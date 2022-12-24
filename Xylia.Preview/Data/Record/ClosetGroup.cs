
using Xylia.Attribute.Component;
using Xylia.Preview.Common.Interface;

namespace Xylia.Preview.Data.Record
{
	public sealed class ClosetGroup : IRecord
	{
		#region	属性字段
		public CategorySeq Category;

		public enum CategorySeq : byte
		{
			None,

			Custom,

			Jeryoung,

			Daesanak,

			Suwal,

			Baekchung,

			Geonwon,

			Seorock,

			Seongye,

			[Signal("npc-trade")]
			NpcTrade,

			Transform,

			Event,

			Shop,

			Faction,

			Etc,

			Cashshop,

			Ingameshop,

			Yongyuenshop,

			Fashionista,

			Unusable,

			[Signal("northland-east")]
			NorthlandEast,
		}




		[Signal("sort-no")]
		public short SortNo;

		[Signal("charge-of-item-for-instant-payment")]
		public string ChargeOfItemForInstantPayment;

		[Signal("item-to-be-paid")]
		public string ItemToBePaid;

		[Signal("check-equip-characteristics")]
		public bool CheckEquipCharacteristics;
		#endregion
	}
}