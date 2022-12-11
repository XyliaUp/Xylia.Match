using System;
using System.Collections.Generic;
using System.Drawing;

using Xylia.Preview.Data.Record;
using Xylia.Preview.Project.Core.ItemGrowth.Preview;


namespace Xylia.Preview.Project.Core.ItemGrowth.Page
{
	public partial class ItemSpiritPage : ItemGrowth2Page
	{
		#region 方法
		public ItemSpiritPage() => InitializeComponent();

		public void SetData(IEnumerable<ItemSpirit> ItemSpirits)
		{
			if (ItemSpirits is null) throw new Exception("没有数据");
			this.ResultWeaponPreview.SetData(ItemSpirits);


			foreach (var ItemSpirit in ItemSpirits)
				System.Diagnostics.Trace.WriteLine(ItemSpirit.Attributes);
		}

		protected override void ResultWeaponPreview_ResultItemChanged(ResultItemChangedEventArgs e)
		{
			this.SubIngredientPreview.SetData(e.ItemSpirit);
		}

		protected override void SubIngredientPreview_RecipeChanged(RecipeChangedEventArgs e)
		{
			//更新固定祭品信息
			this.FixedIngredientPreview.LoadData(e.ItemSpirit);

			//更新手续费信息
			this.MoneyCostPreview.MoneyCost = e.ItemSpirit.MoneyCost;

			//获取特殊说明
			if (e.ItemSpirit.Warning == ItemSpirit.WarningSeq.Fail) this.WarningPreview.Text = $"有一定概率失败。";
		}
		#endregion
	}
}