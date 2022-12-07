using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;

using Xylia.Preview.Project.Controls.PanelEx;


namespace Xylia.Preview.Project.Core.Npc.Cell
{
	public partial class InfoCell : ListCell
	{
		#region 构造
		public InfoCell()
		{
			InitializeComponent();
			this.BackColor = Color.Transparent;
		}
		#endregion

		#region 字段
		[Category(""), Description("")]
		public string LeftText { get => this.lbl_LeftText.Text; set => this.lbl_LeftText.Text = value; }
		#endregion

		#region 控件方法
		private void Item_DoubleClick(object sender, EventArgs e)
		{
			var t = new Thread((ThreadStart)delegate
			{
				try
				{
					base.OnDoubleClick(e);
				}
				catch
				{

				}
			});

			t.SetApartmentState(ApartmentState.STA);
			t.Start();

			GC.Collect();
		}
		#endregion
	}
}
