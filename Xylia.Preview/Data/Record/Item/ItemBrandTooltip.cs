using System.Drawing;

using Xylia.Attribute.Component;
using Xylia.bns.Modules.GameData.Enums;
using Xylia.Preview.Project.Common.Interface;

namespace Xylia.Preview.Data.Record
{
	public sealed class ItemBrandTooltip : IRecord ,IName ,IPicture
	{
		#region 属性字段
		public override int ID => this.BrandID;

		public int BrandID => int.Parse(this.Attributes["brand-id"]);



		[Signal("item-condition-type")]
		public ConditionType ItemConditionType;

		public string Name2;

		[Signal("game-category-3")]
		public string GameCategory3;

		[Signal("item-grade")]
		public byte ItemGrade;

		[Signal("equip-level")]
		public byte EquipLevel;

		[Signal("equip-mastery-level")]
		public byte EquipMasteryLevel;

		[Signal("equip-job-check-1")]
		public Job EquipJobCheck1;

		[Signal("equip-job-check-2")]
		public Job EquipJobCheck2;

		[Signal("equip-job-check-3")]
		public Job EquipJobCheck3;

		[Signal("equip-job-check-4")]
		public Job EquipJobCheck4;

		[Signal("equip-sex")]
		public Sex EquipSex;

		[Signal("equip-race")]
		public Race EquipRace;

		[Signal("equip-solo-duel-grade")]
		public byte EquipSoloDuelGrade;

		[Signal("equip-team-duel-grade")]
		public byte EquipTeamDuelGrade;

		public string Icon;

		[Signal("tag-icon")]
		public string TagIcon;

		[Signal("tag-icon-grade")]
		public string TagIconGrade;

		[Signal("main-info")]
		public string MainInfo;

		[Signal("sub-info")]
		public string SubInfo;

		public string Description2;

		[Signal("description4-title")]
		public string Description4Title;

		[Signal("description5-title")]
		public string Description5Title;

		[Signal("description6-title")]
		public string Description6Title;

		public string Description4;

		public string Description5;

		public string Description6;

		[Signal("store-description")]
		public string StoreDescription;

		[Signal("title-item")]
		public string TitleItem;
		#endregion



		#region 获取信息
		public string NameText() => this.Name2.GetText();

		public Bitmap MainIcon() => this.Icon.GetIconWithGrade(this.ItemGrade);
		#endregion
	}
}
