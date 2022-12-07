using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using HZH_Controls.Controls;

namespace Xylia.Preview.Project.Core.Item.Scene
{
	public partial class DataGridScene : Form
	{
		public DataGridScene(IEnumerable<object> Params, ParamTable ParamTable = null)
		{
			this.InitializeComponent();

			#region 初始化
			this.ucDataGridView1.Columns = new List<DataGridViewColumnEntity>
			{
				new() { DataField = "Name", HeadText = "字段", Width = 40, WidthType = SizeType.Percent , ParamTable = ParamTable },
				new() { DataField = "Value", HeadText = "数值", Width = 60, WidthType = SizeType.Percent },
			};
			#endregion

			//考虑是否可以将文本别名转换为文本值 ?
			if (Params is not null) this.ucDataGridView1.DataSource = Params.ToList();
		}

		private void Form1_Shown(object sender, EventArgs e)
		{

		}
	}
}
