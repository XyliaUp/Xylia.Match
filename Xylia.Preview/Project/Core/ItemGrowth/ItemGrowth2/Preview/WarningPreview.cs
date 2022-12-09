using System.Windows.Forms;

using Xylia.Attribute.Component;
using Xylia.Extension;
using Xylia.Preview.Data.Record;

namespace Xylia.Preview.Project.Core.ItemGrowth.Preview
{
	public partial class WarningPreview : UserControl
	{
		#region 构造
		public WarningPreview()
		{
			InitializeComponent();
		}
		#endregion


		#region 字段
		public override string Text
		{
			get => this.panelContent1.Text;
			set
			{
				this.panelContent1.Text = value;
				this.Visible = value is not null;
			}
		}
		#endregion
	}
}
