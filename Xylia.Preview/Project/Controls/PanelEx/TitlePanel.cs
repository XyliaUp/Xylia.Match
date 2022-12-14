using System.ComponentModel;

using Xylia.Preview.Common.Interface;

namespace Xylia.Preview.Project.Controls.PanelEx
{
	/// <summary>
	/// 带标题的控件块
	/// </summary>
	public partial class TitlePanel : PreviewControl
	{
		public TitlePanel()
		{
			InitializeComponent();
			this.ResizeRedraw = false;
		}

		/// <summary>
		/// 标题
		/// </summary>
		[Category("外观"), Description("标题")]
		public virtual string Title { get => this.lbl_Title.Text; set => this.lbl_Title.Text = value; }
	}
}