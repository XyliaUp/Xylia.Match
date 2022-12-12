using System;
using System.ComponentModel;
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
		}
		#endregion

		#region 字段
		[Category(""), Description("")]
		public string LeftText { get => this.lbl_LeftText.Text; set => this.lbl_LeftText.Text = value; }
		#endregion
	}
}
