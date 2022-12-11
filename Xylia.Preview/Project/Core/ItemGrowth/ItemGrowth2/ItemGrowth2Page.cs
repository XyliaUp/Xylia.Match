using System;
using System.Collections.Generic;
using System.Drawing;

using Xylia.Extension;
using Xylia.Preview.Data.Record;
using Xylia.Preview.Project.Core.ItemGrowth.Preview;

namespace Xylia.Preview.Project.Core.ItemGrowth.Page
{
	public partial class ItemGrowth2Page : EquipmentGuidePage
	{
		#region 构造
		public ItemGrowth2Page()
		{
			InitializeComponent();
		}
		#endregion

		#region 方法
		private void SubIngredientPreview_DataLoaded() => this.SubIngredientPreview.Location = new Point((this.Width - this.SubIngredientPreview.Width) / 2, this.SubIngredientPreview.Location.Y);

		private void FixedIngredientPreview_DataLoaded() => this.FixedIngredientPreview.Location = new Point((this.Width - this.FixedIngredientPreview.Width) / 2, this.FixedIngredientPreview.Location.Y);


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

		/// <summary>
		/// 主要祭品改变
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected virtual void SubIngredientPreview_RecipeChanged(RecipeChangedEventArgs e)
		{
			//更新固定祭品信息
			this.FixedIngredientPreview.LoadData(e.ItemTransformRecipe);
			
			//更新手续费信息
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
		#endregion
	}
}