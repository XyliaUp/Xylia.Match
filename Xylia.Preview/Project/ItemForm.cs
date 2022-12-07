using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xylia.Match.Windows.Panel.Item
{
	public partial class ItemForm : System.Windows.Forms.Form
	{
		public ItemForm()
		{
			InitializeComponent();
			
			
					
		}


		private void ItemForm_Load(object sender, EventArgs e)
		{
			this.Width = this.preview.Width + 20;
			this.Height = this.preview.Height + 40;

			

			this.preview = preview;

			this.Refresh();
		}
	}
}
