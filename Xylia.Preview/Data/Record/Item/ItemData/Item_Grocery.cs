using System.ComponentModel;

using Xylia.Attribute.Component;
using Xylia.Extension;



namespace Xylia.Preview.Data.Record
{

	public sealed partial class Item
	{
		#region 字段
		[Description("grocery-type")]
		public GroceryTypeSeq GroceryType => this.Attributes["grocery-type"].ToEnum<GroceryTypeSeq>();
		public enum GroceryTypeSeq
		{
			Other,

			Repair,

			Seal,

			[Signal("random-box")]
			RandomBox,

			[Signal("cave-escape")]
			CaveEscape,

			Key,

			[Signal("weapon-gem-slot-expander")]
			WeaponGemSlotExpander,

			Sealed,

			[Signal("weapon-gem-slot-adder")]
			WeaponGemSlotAdder,

			Messenger,

			[Signal("quest-replay-epic")]
			QuestReplayEpic,

			[Signal("base-camp-warp")]
			BaseCampWarp,

			[Signal("pet-food")]
			PetFood,

			[Signal("reset-dungeon")]
			ResetDungeon,

			[Signal("skill-book")]
			SkillBook,

			[Signal("fishing-paste")]
			FishingPaste,

			Badge,

			Scroll,

			[Signal("fusion-subitem")]
			FusionSubitem,

			Card,

			Glyph,

			[Signal("soul-boost")]
			SoulBoost,
		}



		/// <summary>
		/// 堆叠数量
		/// </summary>
		public short StackCount => this.Attributes["stack-count"].ConvertToShort();

		public Skill3 Skill3 => FileCache.Data.Skill3[this.Attributes["skill3"]];
		public Skill3 DuelSkill3 => FileCache.Data.Skill3[this.Attributes["duel-skill3"]];



		public int BonusExp => this.Attributes["bonus-exp"].ConvertToInt();
		public int BonusMasteryExp => this.Attributes["bonus-mastery-exp"].ConvertToInt();
		public int BonusAccountExp => this.Attributes["bonus-account-exp"].ConvertToInt();

		public string UnsealAcquireItem1 => this.Attributes["unseal-acquire-item-1"];
		public string UnsealAcquireItem2 => this.Attributes["unseal-acquire-item-2"];
		public string UnsealAcquireItem3 => this.Attributes["unseal-acquire-item-3"];
		public string UnsealAcquireItem4 => this.Attributes["unseal-acquire-item-4"];




		public int BadgeGearScore => this.Attributes["badge-gear-score"].ConvertToInt();
		public int BadgeSynthesisScore => this.Attributes["badge-synthesis-score"].ConvertToInt();



		public SlateScroll SlateScroll => FileCache.Data.SlateScroll[this.Attributes["slate-scroll"]];

		public WorldAccountCard Card => FileCache.Data.WorldAccountCard[this.Attributes["card"]];

		//public GlyphReward GlyphReward => FileCache.Data.GlyphReward[this.Attributes["glyph-reward"]];
		#endregion
	}
}
