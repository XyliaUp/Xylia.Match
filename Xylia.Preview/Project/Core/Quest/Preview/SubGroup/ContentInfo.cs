using System.ComponentModel;
using System.Drawing.Design;
using System.Drawing;
namespace Xylia.Preview.Project.Core.Quest.Preview.SubGroup
{
	public partial class ContentInfo : GroupBase
	{
		#region 构造
		public ContentInfo()
		{
			InitializeComponent();
			this.ContentPanel.Location = new Point(ContentStartX, this.ContentPanel.Location.Y);
		}
		#endregion

		#region 字段
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[Category("Set"), Description("内容")]
		[Editor("System.ComponentModel.Design.MultilineStringEditor", typeof(UITypeEditor))]
		public override string Text
		{
			get => this.ContentPanel.Text;
			set
			{
				this.ContentPanel.Text = value;
				this.Refresh();
			}
		}
		#endregion
	}
}
