using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Xylia.Preview.Project.Controls.PanelEx
{
	/// <summary>
	/// 列表的对象单元
	/// </summary>
	public partial class ListCell : UserControl
	{
		#region 构造
		public ListCell()
		{
			InitializeComponent();
			if (this.Site == null) this.lbl_RightText.Text = null;
		}
		#endregion

		#region 字段
		/// <summary>
		/// 显示右侧文本
		/// </summary>
		public virtual bool ShowRightText { get => this.lbl_RightText.Visible; set => this.lbl_RightText.Visible = value; }

		/// <summary>
		/// 右侧文本
		/// </summary>
		[Category("右侧文本"), Description("")]
		public string RightText { get => this.lbl_RightText.Text; set => this.lbl_RightText.Text = value; }
		#endregion


		#region 重写方法
		/// <summary>
		/// 绘制分隔符事件
		/// </summary>
		/// <param name="e"></param>
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			Color C1 = Color.FromArgb(25, 34, 48);
			Color C2 = Color.FromArgb(28, 36, 50);

			var Brush1 = new LinearGradientBrush(this.ClientRectangle, C1, C2, LinearGradientMode.Horizontal);      //渐变画刷1
			var Brush2 = new LinearGradientBrush(this.ClientRectangle, C2, C1, LinearGradientMode.Horizontal);      //渐变画刷2

			//计算宽度的一半
			float Half = this.ClientRectangle.Width / 2;

			e.Graphics.FillRectangle(Brush1, new RectangleF(new PointF(0, this.ClientRectangle.Bottom - 2), new SizeF(Half, 2)));
			e.Graphics.FillRectangle(Brush2, new RectangleF(new PointF(Half, this.ClientRectangle.Bottom - 2), new SizeF(Half, 2)));
		}
		#endregion
	}
}
