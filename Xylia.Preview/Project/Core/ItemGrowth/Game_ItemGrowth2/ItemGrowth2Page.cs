using System;
using System.Collections.Generic;

using Xylia.Extension;
using Xylia.Preview.Data.Record;
using Xylia.Preview.Project.Core.ItemGrowth.ItemGrowth2.Preview;

namespace Xylia.Preview.Project.Core.ItemGrowth.Page
{
	public partial class ItemGrowth2Page : EquipmentGuidePage
	{
		public ItemGrowth2Page() => InitializeComponent();

		public void SetData(IEnumerable<ItemTransformRecipe> Recipes)
		{
			if (Recipes is null) throw new Exception("没有成长路径");
			this.ResultWeaponPreview.SetData(Recipes);
		}

		/// <summary>
		/// 目标物品改变
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected virtual void ResultWeaponPreview_ResultItemChanged(ResultItemChangedEventArgs e)
		{
			this.SubIngredientPreview.SetData(e.Recipes);
		}

		protected override void SubIngredientPreview_RecipeChanged(RecipeChangedEventArgs e)
		{
			this.FixedIngredientPreview.SetData(e.ItemTransformRecipe);
			this.MoneyCostPreview.MoneyCost = e.ItemTransformRecipe.MoneyCost;

			//获取特殊说明	
			var warning = e.ItemTransformRecipe.Warning;
			this.WarningPreview.Text = warning switch
			{
				ItemTransformRecipe.WarningSeq.None => null,
				ItemTransformRecipe.WarningSeq.DeleteParticle => "UI.Sewing.Warning.DeleteParticle".GetText(),
				ItemTransformRecipe.WarningSeq.DeleteDesign => "UI.Sewing.Warning.DeleteDesign".GetText(),

				_ => $"Transform.Warning.{ warning.GetSignal() }".GetText(),
			};
		}
	}
}