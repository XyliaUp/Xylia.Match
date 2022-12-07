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
	/// <summary>
	/// 预览功能帮助界面
	/// </summary>
	public partial class Helper : Form
	{
		public Helper()
		{
			InitializeComponent();
		}

		private void Helper_Load(object sender, EventArgs e)
		{
			this.label1.Text = Properties.Resources.helper;
		}
	}
}
