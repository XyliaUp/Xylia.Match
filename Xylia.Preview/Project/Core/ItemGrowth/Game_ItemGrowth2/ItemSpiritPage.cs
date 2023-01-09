using System;

using Xylia.Extension;
using Xylia.Preview.Common.Enums;
using Xylia.Preview.Data.Record;

namespace Xylia.Preview.Project.Core.ItemGrowth.Page
{
	public partial class ItemSpiritPage : EquipmentGuidePage
	{
		#region 方法
		public ItemSpiritPage() => InitializeComponent();

		public void SetData(ItemSpirit ItemSpirit)
		{
			if (ItemSpirit is null) throw new ArgumentNullException(nameof(ItemSpirit));

			#region Ability
			string AbilityText = "无变更";
			if (ItemSpirit.AttachAbility1 != MainAbility.None) AbilityText = $"{ItemSpirit.AttachAbility1.GetDescription()} {ItemSpirit.AbilityMin1}~{ItemSpirit.AbilityMax1}";
			if (ItemSpirit.AttachAbility2 != MainAbility.None) AbilityText += $"\n{ItemSpirit.AttachAbility2.GetDescription()} {ItemSpirit.AbilityMin2}~{ItemSpirit.AbilityMax2}";
			this.AbilityInfo.Text = AbilityText;
			#endregion

			#region	ApplicablePart
			string ApplicablePartText = null;
			if (ItemSpirit.ApplicablePart1 != EquipType.None) ApplicablePartText = ItemSpirit.ApplicablePart1.GetDescription();
			if (ItemSpirit.ApplicablePart2 != EquipType.None) ApplicablePartText += "、" + ItemSpirit.ApplicablePart2.GetDescription();
			if (ItemSpirit.ApplicablePart3 != EquipType.None) ApplicablePartText += "、" + ItemSpirit.ApplicablePart3.GetDescription();
			if (ItemSpirit.ApplicablePart4 != EquipType.None) ApplicablePartText += "、" + ItemSpirit.ApplicablePart4.GetDescription();

			this.ApplicablePartInfo.Text = ApplicablePartText;
			#endregion


			this.FixedIngredientPreview.SetData(ItemSpirit);
			this.MoneyCostPreview.MoneyCost = ItemSpirit.MoneyCost;

			//获取特殊说明
			if (ItemSpirit.Warning == ItemSpirit.WarningSeq.Fail) this.WarningPreview.Text = $"有一定概率失败。";
		}
		#endregion
	}
}