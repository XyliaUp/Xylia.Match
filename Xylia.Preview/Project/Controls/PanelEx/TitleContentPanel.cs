using System.ComponentModel;
using System.Drawing.Design;

namespace Xylia.Preview.Project.Controls.PanelEx
{
	/// <summary>
	/// 带标题的控件块
	/// </summary>
	public partial class TitleContentPanel : TitlePanel
	{
		public TitleContentPanel() => InitializeComponent();

		[Editor("System.ComponentModel.Design.MultilineStringEditor", typeof(UITypeEditor))]
		[Category("外观"), Description("内容")]
		public string Content
		{
			get => this.ContentPanel.Text;
			set
			{
				this.ContentPanel.Text = value;
				this.Height = this.ContentPanel.Bottom;
			}													  
		}
	}
}