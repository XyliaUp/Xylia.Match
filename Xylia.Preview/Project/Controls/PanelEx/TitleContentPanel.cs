using System.ComponentModel;
using System.Drawing.Design;

namespace Xylia.Preview.Project.Controls.PanelEx
{
	/// <summary>
	/// 带标题的控件块
	/// </summary>
	public partial class TitleContentPanel : TitlePanel
	{
		#region 构造
		public TitleContentPanel()
		{
			InitializeComponent();
		}
		#endregion

		#region 字段
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
		#endregion


		#region 方法
		private void TitleContentPanel_Load(object sender, System.EventArgs e)
		{

		}

		private void TitleContentPanel_SizeChanged(object sender, System.EventArgs e)
		{
			this.ContentPanel.Width = this.Width;
			this.ContentPanel.MaximumSize = this.MaximumSize;
		}

		public override void Refresh()
		{
			//刷新内容板大小
			this.ContentPanel.Refresh();

			//刷新控件总体高度
			this.Height = this.ContentPanel.Bottom;
		}
		#endregion
	}
}
