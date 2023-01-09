using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;

namespace Xylia.Preview.Project.Core.ItemGrowth.ItemGrowth2.Preview
{
	public partial class WarningPreview : UserControl
	{
		#region 构造
		public WarningPreview() => InitializeComponent();
		#endregion

		#region 字段
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[Editor("System.ComponentModel.Design.MultilineStringEditor", typeof(UITypeEditor))]
		public override string Text
		{
			get => this.panelContent1.Text;
			set
			{
				this.panelContent1.Text = value;
				this.Visible = value is not null;

				if (this.Visible) this.OnTextChanged(new());
			}
		}

		public List<object> Params { get => this.panelContent1.Params; set => this.panelContent1.Params = value; }
		#endregion
	}
}