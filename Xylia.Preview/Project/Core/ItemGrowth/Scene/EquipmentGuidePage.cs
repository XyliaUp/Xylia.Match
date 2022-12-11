using System.Drawing;
using System.Windows.Forms;

using ItemData = Xylia.Preview.Data.Record.Item;


namespace Xylia.Preview.Project.Core.ItemGrowth.Page
{
	public partial class EquipmentGuidePage : UserControl
	{
		#region 构造
		public EquipmentGuidePage()
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

				this.MyWeapon_Icon.Image = value.Icon;
				this.MyWeapon_Name.Text = value.NameText();
				this.MyWeapon_Name.ItemGrade = value.ItemGrade;
				this.MyWeapon_Name.Location = new Point(this.MyWeapon_Icon.Left + (this.MyWeapon_Icon.Scale - this.MyWeapon_Name.Width) / 2, this.MyWeapon_Name.Top);
			}
		}
		#endregion



		private void WarningPreview_TextChanged(object sender, System.EventArgs e)
		{
			this.WarningPreview.Location = new Point((this.Width - this.WarningPreview.Width) / 2, this.WarningPreview.Location.Y);
		}
	}
}