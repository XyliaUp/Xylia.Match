using System.Windows.Forms;

namespace Xylia.Preview.Project.Core.ItemGrowth.ItemGrowth2.Preview
{
	public partial class WarningPreview : UserControl
	{
		#region 构造
		public WarningPreview() => InitializeComponent();
		#endregion


		#region 字段
		public override string Text
		{
			get => this.panelContent1.Text;
			set
			{
				this.panelContent1.Text = value;
				this.Visible = value is not null;

				if(this.Visible) this.OnTextChanged(new());
			}
		}
		#endregion
	}
}
