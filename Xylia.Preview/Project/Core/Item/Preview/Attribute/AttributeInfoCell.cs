using System;
using System.Drawing;
using System.Windows.Forms;

using Xylia.Extension;
using Xylia.Preview.Data.Record;

namespace Xylia.Preview.Project.Core.Item.Cell
{
	public partial class AttributeInfoCell : UserControl
	{
		#region 构造
		public AttributeInfoCell(ItemRandomAbilitySlot RandomAbilitySlot)
		{
			InitializeComponent();

			this.lbl_MainInfo.Text = RandomAbilitySlot.ability.GetDescription() + " " + RandomAbilitySlot.ValueMin;
			this.panelContent1.Text = "最大" + RandomAbilitySlot.ValueMax;
		}
		#endregion


		private void AttributeInfoCell_Resize(object sender, EventArgs e)
		{
			this.panelContent1.Location = new Point(this.Width - this.panelContent1.Width - 5, 0);
		}
	}
}