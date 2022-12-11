using System;
using System.Windows.Forms;

using Xylia.Preview.Resources;

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
			this.label1.Text = Resource_Common.helper;
		}
	}
}
