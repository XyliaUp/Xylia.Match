using System;

using Xylia.Extension;
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


			string Text = "无变更";
			if (ItemSpirit.AttachAbility1 != Common.Enums.MainAbility.None) Text = $"{ItemSpirit.AttachAbility1.GetDescription()} {ItemSpirit.AbilityMin1}~{ItemSpirit.AbilityMax1}";
			if (ItemSpirit.AttachAbility2 != Common.Enums.MainAbility.None) Text += $"\n{ItemSpirit.AttachAbility2.GetDescription()} {ItemSpirit.AbilityMin2}~{ItemSpirit.AbilityMax2}";
			this.contentPanel1.Text = Text;


			this.FixedIngredientPreview.SetData(ItemSpirit);
			this.MoneyCostPreview.MoneyCost = ItemSpirit.MoneyCost;

			//获取特殊说明
			if (ItemSpirit.Warning == ItemSpirit.WarningSeq.Fail) this.WarningPreview.Text = $"有一定概率失败。";
		}
		#endregion
	}
}