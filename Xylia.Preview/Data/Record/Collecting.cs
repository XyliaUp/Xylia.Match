using System;

using Xylia.Attribute.Component;
using Xylia.Preview.Common.Enums;
using Xylia.Preview.Common.Interface;

namespace Xylia.Preview.Data.Record
{
	public sealed class Collecting : IRecord ,IName
	{
		#region 枚举
		public enum CategorySeq
		{
			None,
			Category1,
			Category2,
			Category3,
			Category4,
			Category5,
			Category6,
			Category7,
			Category8,
			Category9,
			Category10,

			[Signal("category-special")]
			CategorySpecial,

		}
		#endregion


		#region	属性字段
		public string Name;

		public CategorySeq Category;

		[Signal("collect-closet-1")]
		public string CollectCloset1;

		[Signal("collect-closet-2")]
		public string CollectCloset2;

		[Signal("collect-closet-3")]
		public string CollectCloset3;

		[Signal("collect-closet-4")]
		public string CollectCloset4;

		[Signal("collect-closet-5")]
		public string CollectCloset5;

		[Signal("collect-closet-6")]
		public string CollectCloset6;

		[Signal("collect-closet-7")]
		public string CollectCloset7;

		[Signal("collect-closet-8")]
		public string CollectCloset8;

		[Signal("collect-closet-replace-1")]
		public string CollectClosetReplace1;

		[Signal("collect-closet-replace-2")]
		public string CollectClosetReplace2;

		[Signal("collect-closet-replace-3")]
		public string CollectClosetReplace3;

		[Signal("collect-closet-replace-4")]
		public string CollectClosetReplace4;

		[Signal("collect-closet-replace-5")]
		public string CollectClosetReplace5;

		[Signal("collect-closet-replace-6")]
		public string CollectClosetReplace6;

		[Signal("collect-closet-replace-7")]
		public string CollectClosetReplace7;

		[Signal("collect-closet-replace-8")]
		public string CollectClosetReplace8;

		[Signal("collect-closet-subreplace-1")]
		public string CollectClosetSubreplace1;

		[Signal("collect-closet-subreplace-2")]
		public string CollectClosetSubreplace2;

		[Signal("collect-closet-subreplace-3")]
		public string CollectClosetSubreplace3;

		[Signal("collect-closet-subreplace-4")]
		public string CollectClosetSubreplace4;

		[Signal("collect-closet-subreplace-5")]
		public string CollectClosetSubreplace5;

		[Signal("collect-closet-subreplace-6")]
		public string CollectClosetSubreplace6;

		[Signal("collect-closet-subreplace-7")]
		public string CollectClosetSubreplace7;

		[Signal("collect-closet-subreplace-8")]
		public string CollectClosetSubreplace8;

		[Signal("collect-skill-skin-1")]
		public string CollectSkillSkin1;

		[Signal("collect-skill-skin-2")]
		public string CollectSkillSkin2;

		[Signal("collect-skill-skin-3")]
		public string CollectSkillSkin3;

		[Signal("collect-skill-skin-4")]
		public string CollectSkillSkin4;

		[Signal("reward-item-1")]
		public string RewardItem1;

		[Signal("reward-item-2")]
		public string RewardItem2;

		[Signal("reward-item-3")]
		public string RewardItem3;

		[Signal("reward-item-4")]
		public string RewardItem4;

		[Signal("reward-item-5")]
		public string RewardItem5;

		[Signal("reward-item-6")]
		public string RewardItem6;

		[Signal("reward-item-count-1")]
		public short RewardItemCount1;

		[Signal("reward-item-count-2")]
		public short RewardItemCount2;

		[Signal("reward-item-count-3")]
		public short RewardItemCount3;

		[Signal("reward-item-count-4")]
		public short RewardItemCount4;

		[Signal("reward-item-count-5")]
		public short RewardItemCount5;

		[Signal("reward-item-count-6")]
		public short RewardItemCount6;

		[Signal("reward-money")]
		public int RewardMoney;

		[Signal("reward-collecting-score")]
		public int RewardCollectingScore;

		[Signal("ability-1")]
		public AttachAbility Ability1;

		[Signal("ability-2")]
		public AttachAbility Ability2;

		[Signal("ability-3")]
		public AttachAbility Ability3;

		[Signal("ability-value-1")]
		public int AbilityValue1;

		[Signal("ability-value-2")]
		public int AbilityValue2;

		[Signal("ability-value-3")]
		public int AbilityValue3;

		[Signal("expiration-time")]
		public DateTime ExpirationTime;

		[Signal("can-not-used")]
		public bool CanNotUsed;
		#endregion

		#region 接口字段
		public string NameText() => this.Name.GetText();
		#endregion
	}
}