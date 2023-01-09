using System;
using System.Drawing;
using System.Windows.Forms;

using NPOI.SS.Formula;

using Xylia.Extension;
using Xylia.Preview.Project.Core.Item.Cell.Basic;
using Xylia.Preview.Project.Core.ItemGrowth.ItemGrowth2.Preview;

using ItemData = Xylia.Preview.Data.Record.Item;


namespace Xylia.Preview.Project.Core.ItemGrowth.Page
{
	public partial class EquipmentGuidePage : UserControl
	{
		#region 构造
		public EquipmentGuidePage()
		{
			InitializeComponent();

			this.Width = this.BackgroundImage.Width;
			this.Height = this.BackgroundImage.Height;
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

				this.MyWeapon_Icon.Image = value.Icon;
				this.MyWeapon_Name.Text = value.NameText();
				this.MyWeapon_Name.ItemGrade = value.ItemGrade;
				this.MyWeapon_Name.Location = new Point(this.MyWeapon_Icon.Left + (this.MyWeapon_Icon.Width - this.MyWeapon_Name.Width) / 2, this.MyWeapon_Name.Top);
			}
		}
		#endregion




		private void SubIngredientPreview_DataLoaded(object sender, EventArgs e) => this.SubIngredientPreview.Location = new Point((this.Width - this.SubIngredientPreview.Width) / 2, this.SubIngredientPreview.Location.Y);

		private void FixedIngredientPreview_DataLoaded(object sender, EventArgs e) => this.FixedIngredientPreview.Location = new Point((this.Width - this.FixedIngredientPreview.Width) / 2, this.FixedIngredientPreview.Location.Y);

		private void WarningPreview_TextChanged(object sender, EventArgs e) => this.WarningPreview.Location = new Point((this.Width - this.WarningPreview.Width) / 2, this.WarningPreview.Location.Y);


		/// <summary>
		/// 主要祭品改变
		/// </summary>
		/// <param name="e"></param>
		protected virtual void SubIngredientPreview_RecipeChanged(RecipeChangedEventArgs e)
		{
			//this.FixedIngredientPreview.Controls.Remove<ItemIconCell>();
			//this.FixedIngredientPreview.LocX = 0;
		}
	}
}