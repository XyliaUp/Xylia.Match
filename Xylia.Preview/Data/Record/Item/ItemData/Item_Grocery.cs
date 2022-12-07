using System.ComponentModel;

using Xylia.Extension;



namespace Xylia.Preview.Data.Record
{

	public sealed partial class Item
	{
		#region 字段
		[Description("grocery-type")]
		public GroceryType groceryType => this.Attributes["grocery-type"].ToEnum<GroceryType>();

		/// <summary>
		/// 堆叠数量
		/// </summary>
		public int StackCount => this.Attributes["stack-count"].ToIntWithNull() ?? 0;

		public int BonusExp => this.Attributes["bonus-exp"].ToIntWithNull() ?? 0;
		public int BonusMasteryExp => this.Attributes["bonus-mastery-exp"].ToIntWithNull() ?? 0;
		public int BonusAccountExp => this.Attributes["bonus-account-exp"].ToIntWithNull() ?? 0;

		public string UnsealAcquireItem1 => this.Attributes["unseal-acquire-item-1"];
		public string UnsealAcquireItem2 => this.Attributes["unseal-acquire-item-2"];
		public string UnsealAcquireItem3 => this.Attributes["unseal-acquire-item-3"];
		public string UnsealAcquireItem4 => this.Attributes["unseal-acquire-item-4"];
		#endregion


		#region 枚举
		public enum GroceryType
		{
			Other = 0,
			Repair,
			Seal,


			[Description("random-box")]
			RandomBox,

			CaveEscape,

			Key,

			WeaponGemSlotExpander,

			Sealed,

			WeaponGemSlotAdder,
			Messenger,

			[Description("quest-replay-epic")]
			QuestReplayEpic,

			[Description("base-camp-warp")]
			BaseCampWarp,

			PetFood,

			[Description("reset-dungeon")]
			ResetDungeon,

			SkillBook,

			FishingPaste,
			Badge,

			Scroll,

			[Description("fusion-subitem")]
			FusionSubitem,

			Card,
		}
		#endregion
	}
}
