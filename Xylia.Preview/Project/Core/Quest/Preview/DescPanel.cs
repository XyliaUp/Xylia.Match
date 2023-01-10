using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;

namespace Xylia.Preview.Project.Core.Quest.Preview.Desc
{
	public partial class DescPanel : GroupBase
	{
		#region 构造
		public DescPanel()
		{
			InitializeComponent();
			this.Content.Location = new Point(ContentStartX, this.Content.Location.Y);
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
			get => this.Content.Text;
			set
			{
				this.Content.Text = value;
				this.Refresh();
			}
		}

		//public override void Refresh()
		//{
		//	base.Refresh();
		//	this.Height = this.Content.Bottom;
		//}
		#endregion
	}
}