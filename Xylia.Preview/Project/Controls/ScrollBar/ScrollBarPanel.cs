using System;
using System.Drawing;
using System.Windows.Forms;

namespace Xylia.Preview.Project.Controls.PanelEx.ScrollBar
{
	public partial class ScrollBarPanel : Panel
	{
		#region 字段
		public ScrollBar ScrollBar = null;

		public HideScrollBarPanel ContentPanel = null;
		#endregion

		#region 构造
		public ScrollBarPanel()
		{
			InitializeComponent();

			this.ContentPanel = new HideScrollBarPanel()
			{
				Location = new Point(0, 0),
				AutoScroll = true,
			};

			this.ScrollBar = new ScrollBar()
			{
				RelaPanel = ContentPanel,
			};

			base.Controls.Add(ContentPanel);
			base.Controls.Add(ScrollBar);

			this.Refresh();
		}
		#endregion


		private void ScrollBarPanel_SizeChanged(object sender, EventArgs e)
		{
			this.Refresh();
		}

		public override void Refresh()
		{
			ScrollBar.BringToFront();
			ScrollBar.Location = new Point(this.Width - ScrollBar.Width, 0);
			ScrollBar.Height = this.Height;

			ContentPanel.Width = this.Width - ScrollBar.Width;
			ContentPanel.Height = this.Height;

			base.Refresh();
		}

		/// <summary>
		/// 防止滚动条自动复位
		/// </summary>
		/// <param name="activeControl"></param>
		/// <returns></returns>
		protected override Point ScrollToControl(Control activeControl)
		{
			return this.AutoScrollPosition;
		}
	}
}
