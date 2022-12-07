using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xylia.Preview.Project.Core.Item
{
	//[Designer(typeof(Designer.FixedWidthDesigner))]
	public partial class DurabilityPreview : UserControl
	{
		public DurabilityPreview()
		{
			InitializeComponent();

			this.BackColor = Color.Transparent;
		}

		private void DurabilityPreview_Load(object sender, EventArgs e)
		{

		}


		#region 字段
		private int _durability;

		public int Durability
		{
			get => this._durability;
			set
			{
				this._durability = value;
				this.label1.Text = $"{ value } / { value }";
			}
		}
		#endregion
	}
}
