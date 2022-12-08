using System.ComponentModel;

using Xylia.Preview.Common.Interface;

namespace Xylia.Preview.Data.Record
{
	public sealed class ClosetGroup : IRecord
	{
		#region	属性字段
		public Category category;
		public short SortNo;

		public string ChargeOfItemForInstantPayment;
		public string ItemToBePaid;
		#endregion


		#region 枚举
		public enum Category : short
		{
			none = 1,

			[Description("御龙林")]
			jeryoung,

			[Description("大漠")]
			daesanak,

			[Description("水月平原")]
			suwal,

			[Description("白青山脉")]
			baekchung,

			[Description("建元城都")]
			geonwon,

			[Description("西洛")]
			seorock,

			[Description("仙界")]
			seongye,

			[Description("从商人处购买")]
			NpcTrade,

			[Description("变换")]
			transform,

			[Description("活动")]
			Event,

			[Description("商店")]
			shop,

			[Description("势力")]
			Faction,

			[Description("其他")]
			etc,

			[Description("商城")]
			Cashshop,

			[Description("游戏内商店")]
			ingameshop,

			[Description("龙银商店")]
			yongyuenshop,

			[Description("时尚达人")]
			fashionista,



			[Description("无法使用")]
			unusable = 99,
		}
		#endregion
	}
}
