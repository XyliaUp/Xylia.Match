using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Threading;
using System.Windows.Forms;

using Xylia.Drawing;
using Xylia.Preview.Common.Interface;
using Xylia.Preview.Data.Record;
using Xylia.Preview.Project.Controls;
using Xylia.Preview.Project.Designer;


namespace Xylia.Preview.Project.Core.Item.Cell.Basic
{
	[OnlyAutoSize(true)]
	[Designer(typeof(FixedDesigner))]
	public partial class ItemNameCell : Panel
	{
		#region 构造
		public ItemNameCell()
		{
			InitializeComponent();

			CheckForIllegalCrossThreadCalls = false;

			//初始状态
			this.BackColor = Color.Transparent;
			this.DoubleBuffered = true;
			this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.Selectable | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);

			//this.AutoScaleMode = AutoScaleMode.None;
			this.ResizeRedraw = false;

			this.Refresh();
		}
		#endregion

		#region 委托与事件
		//定义委托
		public delegate void NameChangedHandle(object sender, EventArgs e);

		/// <summary>
		/// 名称改变事件
		/// </summary>
		public event NameChangedHandle NameChanged;
		#endregion

		#region 字段
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[Editor("System.ComponentModel.Design.MultilineStringEditor", typeof(UITypeEditor))]
		[Category("Appearance"), Description("物品名称")]
		public override string Text
		{
			get => base.Text;
			set
			{
				base.Text = value;
				this.Refresh();

				//委托事件
				this.NameChanged?.Invoke(null, null);
			}
		}


		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override Color ForeColor => m_itemgrade.ItemGrade(); 



		private byte m_itemgrade = 6;

		[Category("Data"), Description("物品品质")]
		public byte ItemGrade
		{
			get => m_itemgrade;
			set
			{
				m_itemgrade = value;
				this.Refresh();
			}
		}


		private Bitmap m_TagImage;
		[Category("Data"), Description("标签图片")]
		public Bitmap TagImage
		{
			get => this.m_TagImage;
			set
			{
				this.m_TagImage = value;
				this.Refresh();
			}
		}

		/// <summary>
		/// 物品别名
		/// </summary>
		public IRecord ObjectRef;
		#endregion


		#region 方法
		float ExpectHeight, ExpectWidth;
		bool Loaded = false;

		protected override void OnPaint(PaintEventArgs e) => GoPaint(e.Graphics);

		public void GoPaint(Graphics g)
		{
			#region 初始化
			ExpectWidth = ExpectHeight = 0;

			int MaxWidth = 0;
			float LocX = 0, LocY = 0;

			if (this.MaximumSize.Width != 0)
			{
				MaxWidth = this.MaximumSize.Width;
			}
			#endregion

			#region 绘制文本
			foreach (var Info in ContentPanel.SplitMultiLine(this.Text, MaxWidth, this.Font, ref LocX, ref LocY))
			{
				ExpectWidth = Math.Max(ExpectWidth, (int)Math.Ceiling(LocX + 4.0F));
				g?.DrawString(Info.Text, this.Font, new SolidBrush(this.ForeColor), Info.Location);
			}

			if (LocY != 0) ExpectWidth = Math.Max(ExpectWidth, MaxWidth);
			ExpectHeight = (int)LocY + this.Font.Height;
			#endregion

			#region 绘制附加图片
			if (this.TagImage != null)
			{
				//图片渲染前景色
				var Img = this.TagImage.ChangeColor(this.ForeColor);

				//绘制时图片高度
				int TarHeight = this.Font.Height - 7;
				int TarWidth = TarHeight * Img.Width / Img.Height;

				//设置绘制位置
				var Rectangle = new RectangleF(LocX, LocY + (this.Font.Height - TarHeight) / 2, TarWidth, TarHeight);

				ExpectWidth = Math.Max(ExpectWidth, Rectangle.X + Rectangle.Width);
				ExpectHeight = Math.Max(ExpectHeight, Rectangle.Y + Rectangle.Height);

				g?.DrawImage(Img, Rectangle);
			}
			#endregion

			this.GoResize();
		}

		private void GoResize()
		{
			if (this.AutoSize)
			{
				this.Height = (int)Math.Ceiling(ExpectHeight);
				this.Width = (int)Math.Ceiling(ExpectWidth);
			}
		}

		private void ItemNameCell_Load(object sender, EventArgs e)
		{
			Loaded = true;
			this.Refresh();
		}

		public override void Refresh()
		{
			base.Refresh();

			//如果没有load，则使用空指针方式计算控件大小信息
			if (!this.Loaded) this.GoPaint(null);
			else this.OnPaint(new PaintEventArgs(this.CreateGraphics(), new Rectangle()));
		}

		public void OnDoubleClick(object sender, EventArgs e) 
		{
			var t = new Thread(act => ObjectRef.PreviewShow());

			t.SetApartmentState(ApartmentState.STA);
			t.Start();
		}
		#endregion
	}
}
