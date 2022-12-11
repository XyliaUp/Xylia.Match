using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Xylia.Preview.Resources;

namespace Xylia.Preview.Project.Controls.Paging
{
	[Designer(typeof(Designer.FixedWidthDesigner))]
	public partial class PageBtn : UserControl
	{

		public PageBtn()
		{
			InitializeComponent();

			//初始状态
			this.BackColor = Color.Transparent;
		}



		#region 字段
		/// <summary>
		/// 按钮模式
		/// </summary>
		public enum btnMode
		{
			Next,
			Prev,

			Page,
		}

		private btnMode m_BtnMode;

		[Browsable(true)]
		public btnMode BtnMode
		{
			get => this.m_BtnMode;
			set
			{
				this.m_BtnMode = value;
				this.Refresh();
			}
		}




		/// <summary>
		/// 页面编号
		/// </summary>
		private int? m_PageID;

		/// <summary>
		/// 页面编号
		/// </summary>
		[Browsable(true)]
		public int? PageID
		{
			get => this.m_PageID;
			set
			{
				this.m_PageID = value;
				this.Refresh();
			}
		}


		/// <summary>
		/// 被选择的页面
		/// </summary>
		public bool IsSelected = false;
		#endregion


		#region 方法
		private void PageBtn_Load(object sender, EventArgs e)
		{


		}

		public override void Refresh()
		{
			base.Refresh();

			this.lbl_Text.Text = "Temp";
			int HeightCenter = this.pictureBox1.Location.Y;

			#region 显示内容
			if (BtnMode == btnMode.Prev)
			{
				this.lbl_Text.Text = "前";

				this.pictureBox1.Visible = true;
				this.pictureBox1.Image = Resource_Common.icPager_Prev;

				this.pictureBox1.Location = new Point(15, HeightCenter);
				this.lbl_Text.Location = new Point(this.pictureBox1.Right + 5, this.lbl_Text.Location.Y);


				this.Width = this.lbl_Text.Right + 2;
				
			}
			else if (BtnMode == btnMode.Next)
			{
				this.lbl_Text.Text = "后";

				this.pictureBox1.Visible = true;
				this.pictureBox1.Image = Resource_Common.icPager_Next;

				this.lbl_Text.Location = new Point(2, this.lbl_Text.Location.Y);
				this.pictureBox1.Location = new Point(this.lbl_Text.Right + 5, HeightCenter);

				this.Width = this.pictureBox1.Right + 15;
			}
			else
			{
				this.lbl_Text.Text = (this.PageID ?? 1).ToString();

				this.pictureBox1.Visible = false;
				this.pictureBox1.Image = null;

				this.lbl_Text.Location = new Point(5, this.lbl_Text.Location.Y);

				this.Width = 5 * 2 + this.lbl_Text.Width;
			}
			#endregion


			this.Height = Math.Max(this.lbl_Text.Bottom, this.pictureBox1.Bottom) + 4;
		}


		protected override void OnPaint(PaintEventArgs pevent)
		{
			float X = this.Width - 1;
			float Y = this.Height - 1;

			PointF[] pointfs =
			{
				new PointF(2,     0),
				new PointF(X-2,   0),
				new PointF(X-1,   1),
				new PointF(X,     2),
				new PointF(X,     Y-2),
				new PointF(X-1,   Y-1),
				new PointF(X-2,   Y),
				new PointF(2,     Y),
				new PointF(1,     Y-1),
				new PointF(0,     Y-2),
				new PointF(0,     2),
				new PointF(1,     1)
			};

			GraphicsPath path = new GraphicsPath();
			path.AddLines(pointfs);


			//将区域赋值给Region
			this.Region = new Region(path);
			base.OnPaint(pevent);
		}
		#endregion
	}
}
