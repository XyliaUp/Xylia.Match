using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Xylia.Preview.Data.Record;

using ItemData = Xylia.Preview.Data.Record.Item;


namespace Xylia.Preview.Project.Core.ItemGrowth.Page
{
	public partial class ItemGrowth2Page : UserControl
	{
		#region 构造
		public ItemGrowth2Page()
		{
			InitializeComponent();
		}
		#endregion


		#region 字段
		/// <summary>
		/// 设置起始物品
		/// </summary>
		public ItemData MyWeapon
		{
			set
			{
				if (value is null) return;

				this.itemIconCell1.ItemIcon = value.Icon;
				this.MyWeapon_Name.Text = value.NameText();
				this.MyWeapon_Name.ItemGrade = value.ItemGrade;
				this.MyWeapon_Name.Location = new Point(this.itemIconCell1.Left + (this.itemIconCell1.Scale - this.MyWeapon_Name.Width) / 2, this.MyWeapon_Name.Top);
			}
		}
		#endregion

		#region 方法
		public void SetData(IEnumerable<ItemTransformRecipe> Recipes)
		{
			#region 异常处理
			if (Recipes is null)
			{
				Console.WriteLine("没有成长路径");
				return;
			}
			#endregion

			#region 处理目标物品
			this.ResultWeaponPreview.ResultItemChanged += new Preview.ResultWeaponPreview.ResultItemChangedHandle((o, s) =>
			{
				//无对象时异常处理
				if (s is null)
				{
					this.FixedIngredientPreview.Visible = this.SubIngredientPreview.Visible = false;
					return;
				}


				this.SubIngredientPreview.RecipeChanged += new Preview.SubIngredientPreview.RecipeChangedHandle((o2, s2) =>
				{
					//更新固定祭品信息
					this.FixedIngredientPreview.LoadData(s2.ItemTransformRecipe);

					//更新手续费信息
					this.moneyCostPreview1.MoneyCost = (int)s2.ItemTransformRecipe.MoneyCost;

					//获取特殊说明
					this.warningPreview1.Type = s2.ItemTransformRecipe.warning;
				});

				this.SubIngredientPreview.SetData(s.Recipes);
			});
			#endregion

			//目标物品
			this.ResultWeaponPreview.SetData(this, Recipes);
			this.Refresh();
		}

		public override void Refresh()
		{
			base.Refresh();

			this.ResultWeaponPreview.Refresh();
			this.SubIngredientPreview.Refresh();
			this.FixedIngredientPreview.Refresh();
		}

		private void ItemGrowth2Page_SizeChanged(object sender, EventArgs e)
		{
			this.FixedIngredientPreview.Width = this.Width;
		}


		/// <summary>
		/// 最后输入的按键
		/// </summary>
		public static Keys LastKey = Keys.None;

		public new void KeyDown(Keys key) => LastKey = key;

		public new void KeyUp(Keys key) => LastKey = Keys.None;
		#endregion
	}
}
