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
		public void SetData(IEnumerable<ItemTransformRecipe> Recipes)
		{
			if (Recipes is null) throw new Exception("没有成长路径");

			//目标物品
			this.ResultWeaponPreview.SetData(Recipes);
			this.Refresh();
		}

		public override void Refresh()
		{
			base.Refresh();

			this.ResultWeaponPreview.Refresh();
			this.SubIngredientPreview.Refresh();
			this.FixedIngredientPreview.Refresh();
		}


		/// <summary>
		/// 目标物品改变
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected virtual void ResultWeaponPreview_ResultItemChanged(ResultItemChangedEventArgs e)
		{
			this.SubIngredientPreview.SetData(e.Recipes);
			this.SubIngredientPreview.Location = new Point((this.Width - this.SubIngredientPreview.Width) / 2, this.SubIngredientPreview.Location.Y);
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
			this.FixedIngredientPreview.Location = new Point((this.Width - this.FixedIngredientPreview.Width) / 2, this.FixedIngredientPreview.Location.Y);

			//更新手续费信息
			this.MoneyCostPreview.MoneyCost = e.ItemTransformRecipe.MoneyCost;

			//获取特殊说明	
			var warning = e.ItemTransformRecipe.Warning;
			if (warning == ItemTransformRecipe.WarningSeq.None) this.WarningPreview.Text = null;
			else this.WarningPreview.Text = $"Transform.Warning.{ warning.GetSignal() }".GetText();
			this.WarningPreview.Location = new Point((this.Width - this.WarningPreview.Width) / 2, this.WarningPreview.Location.Y);
		}
		#endregion
	}
}