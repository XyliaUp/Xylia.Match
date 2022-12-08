using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

using Xylia.Drawing;
using Xylia.Extension;
using Xylia.Preview.Data.Record;
using Xylia.Preview.Common.Interface;

using ItemData = Xylia.Preview.Data.Record.Item;

namespace Xylia.Preview.Project.Core.Item.Cell.Basic
{
	[Designer(typeof(Designer.FixedHeightDesigner))]
	public partial class ItemIconCell : PictureBox
	{
		#region 构造
		public ItemIconCell()
		{
			InitializeComponent();

			this.Scale = 36;

			this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.Selectable | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
			this.Refresh();
		}

		//public ItemIconCell(ItemData ItemData) : this()
		//{
			
		//}
		#endregion






		#region 隐藏不需要的属性
		[Browsable(false)]
		[Obsolete("不再可用的属性")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new int Width => this.Scale;

		[Browsable(false)]
		[Obsolete("不再可用的属性")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new int Height => this.Scale;

		[Browsable(false)]
		[Obsolete("不再可用的属性")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new Size Size => new(this.Scale, this.Scale);

		[Browsable(false)]
		[Obsolete("不再可用的属性")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new Image Image { get => base.Image; set => base.Image = value; }
		#endregion

		#region 物品数量处理
		/// <summary>
		/// 字段：堆叠数量
		/// </summary>
		private uint m_StackCount = 1;

		/// <summary>
		/// 物品数量
		/// </summary>
		[Category("Item"), Description("物品数量")]
		public uint StackCount
		{
			get => this.m_StackCount;
			set
			{
				//文本赋值
				m_StackCount = value;
				this.Refresh();
			}
		}


		/// <summary>
		/// 字段：是否显示堆叠数量
		/// </summary>
		private bool m_ShowStackCount = false;

		/// <summary>
		/// 显示物品数量
		/// </summary>
		[Category("Item"), Description("显示物品数量")]
		public bool ShowStackCount
		{
			get => m_ShowStackCount;
			set
			{
				m_ShowStackCount = value;
				this.Refresh();
			}
		}


		/// <summary>
		/// 字段：当数量为1时，是否显示堆叠数量
		/// </summary>
		private bool m_ShowStackCountOnlyOne = true;

		/// <summary>
		/// 显示物品数量
		/// </summary>
		[Category("Item"), Description("当数量为1时，是否显示物品数量")]
		public bool ShowStackCountOnlyOne
		{
			get => m_ShowStackCountOnlyOne;
			set
			{
				m_ShowStackCountOnlyOne = value;
				this.Refresh();
			}
		}
		#endregion



		#region 字段
		/// <summary>
		/// 物品别名
		/// </summary>
		public IRecord ObjectRef;

		/// <summary>
		/// 附加图标
		/// </summary>
		private Dictionary<Compose.DrawLocation, Bitmap> ExtraIcon { get; set; } = new();


		/// <summary>
		/// 物品图标
		/// </summary>
		[Category("Apperance"), Description("物品图标")]
		public Bitmap ItemIcon
		{
			get => (Bitmap)base.Image;
			set
			{
				base.Image = value;
				this.Refresh();
			}
		}


		/// <summary>
		/// 框架图片
		/// </summary>
		private Bitmap m_FrameImage;

		/// <summary>
		/// 框架图标
		/// </summary>
		[Category("Apperance"), Description("框架图标")]
		public virtual Bitmap FrameImage
		{
			get => m_FrameImage;
			set => m_FrameImage = value;
		}


		/// <summary>
		/// 框架图标显示类型
		/// flase=仅覆盖 | true=计算大小
		/// </summary>
		[Category("Apperance"), Description("框架图标显示类型")]
		public bool FrameType { get; set; } = true;


		/// <summary>
		/// 图片比例
		/// </summary>
		[Category("Apperance"), Description("比例")]
		public new int Scale
		{
			get => base.Width;
			set
			{
				base.Width = base.Height = value;
				this.Refresh();
			}
		}


		[Category("Extra"), Description("")]
		public Bitmap ExtraTopLeft
		{
			get => GetExtraImg(Compose.DrawLocation.TopLeft);
			set => SetExtraImg(Compose.DrawLocation.TopLeft, value);
		}

		[Category("Extra"), Description("右上区域附加图标")]
		public Bitmap ExtraTopRight
		{
			get => GetExtraImg(Compose.DrawLocation.TopRight);
			set => SetExtraImg(Compose.DrawLocation.TopRight, value);
		}

		/// <summary>
		/// 左下区域附加图标
		/// </summary>
		[Category("Extra"), Description("左下区域附加图标")]
		public Bitmap ExtraBottomLeft
		{
			get => GetExtraImg(Compose.DrawLocation.BottomLeft);
			set => SetExtraImg(Compose.DrawLocation.BottomLeft, value);
		}

		[Category("Extra"), Description("")]
		public Bitmap ExtraBottomRight
		{
			get => GetExtraImg(Compose.DrawLocation.BottomRight);
			set => SetExtraImg(Compose.DrawLocation.BottomRight, value);
		}
		#endregion




		#region 特殊方法
		public void SetExtraImg(Compose.DrawLocation location, Bitmap bitmap)
		{
			if (bitmap is null) return;

			if (ExtraIcon.ContainsKey(location)) ExtraIcon[location] = bitmap;
			else ExtraIcon.Add(location, bitmap);

			this.Refresh();
		}

		public Bitmap GetExtraImg(Compose.DrawLocation location)
		{
			return ExtraIcon.ContainsKey(location) ? ExtraIcon[location] : null;
		}

		/// <summary>
		/// 绘制内容
		/// </summary>
		/// <param name="pe"></param>
		protected override void OnPaint(PaintEventArgs pe)
		{
			#region 计算边界大小
			int Border = 0;
			if (this.FrameImage != null)
			{
				if(FrameType)
				{
					//需按照比例缩放框架图片
					var Ratio = (float)this.FrameImage.Width / this.Scale;

					//左边框中点首个透明度图层为0的对象的位置作为边界大小
					for (int x = 0; x < this.Scale; x++)
					{
						var Pixel = this.FrameImage.GetPixel((int)(Ratio * x), (int)(Ratio * this.Scale) / 2);
						if (Pixel.A == 0)
						{
							Border = x;
							break;
						}
					}
				}
			}
			#endregion




			#region 处理图片信息
			var Img = this.ItemIcon ?? Resources.BnsCommon_Old.ItemIcon;
			var ImgScale = this.Scale - 2 * Border;

			//绘制基础图片
			pe.Graphics.DrawImage(Img, new Rectangle(Border, Border, ImgScale, ImgScale));
			#endregion


			#region 处理堆叠数量信息
			if (ShowStackCount && (ShowStackCountOnlyOne || this.StackCount != 1))
				DrawStackCount(pe.Graphics, this.StackCount, new Size(this.Scale - Border, this.Scale - Border));
			#endregion

			//绘制背景层
			if (this.FrameImage != null)
			{
				pe.Graphics.DrawImage(this.FrameImage, new Rectangle(0, 0, this.Scale, this.Scale));
			}

			this.DrawExtraIcon(pe.Graphics, ImgScale, Border);
		}

		/// <summary>
		/// 绘制附加图片
		/// </summary>
		public void DrawExtraIcon(Graphics g, int ImgScale, int Border)
		{
			if (ExtraIcon?.Count != 0)
			{
				foreach (var Extra in ExtraIcon.Where(e => e.Value != null))
				{
					var AttachImg = Extra.Value.ImageThumbnail(ImgScale, ImgScale);

					int LocationX = 0;
					int LocationY = 0;

					#region 根据附加类型计算位置
					switch (Extra.Key)
					{
						case Compose.DrawLocation.Centre:
							LocationX = this.Scale / 2 - AttachImg.Width / 2;
							LocationY = this.Scale / 2 - AttachImg.Height / 2;
							break;

						case Compose.DrawLocation.TopLeft:
							LocationX = 0;
							LocationY = 0;
							break;

						case Compose.DrawLocation.TopRight:
							LocationX = this.Scale - AttachImg.Width;
							LocationY = 0;
							break;

						case Compose.DrawLocation.BottomLeft:
							LocationX = 0;
							LocationY = this.Scale - AttachImg.Height;
							break;

						case Compose.DrawLocation.BottomRight:
							LocationX = this.Scale - AttachImg.Width;
							LocationY = this.Scale - AttachImg.Height;
							break;
					}
					#endregion

					g.DrawImage(Extra.Value, new Rectangle(Border + LocationX, Border + LocationY, AttachImg.Width, AttachImg.Height));
				}
			}
		}

		/// <summary>
		/// 绘制数量信息
		/// </summary>
		/// <param name="g"></param>
		/// <param name="StackCount"></param>
		/// <param name="Size"></param>
		public static void DrawStackCount(Graphics g, uint StackCount, SizeF Size)
		{
			var Txt = StackCount.ToString();

			#region 处理字体大小程度
			var CurFont = new Font("Microsoft YaHei UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 134);

			if (StackCount > 9999) CurFont = new Font(CurFont.FontFamily, CurFont.Size - 2);
			else if (StackCount > 999) CurFont = new Font(CurFont.FontFamily, CurFont.Size - 1);
			else if (StackCount > 99) CurFont = new Font(CurFont.FontFamily, CurFont.Size);
			else if (StackCount > 9) CurFont = new Font(CurFont.FontFamily, CurFont.Size);
			else CurFont = new Font(CurFont.FontFamily, CurFont.Size);
			#endregion




			var TxtSize = Txt.MeasureString(CurFont, false);
			var Rect = new RectangleF(Size.Width - TxtSize.Width - 2, Size.Height - CurFont.Height, TxtSize.Width, CurFont.Height);


			using var path = GetStringPath(Txt, g.DpiY, Rect, CurFont, StringFormat.GenericTypographic);

			//设置字体质量
			g.SmoothingMode = SmoothingMode.AntiAlias;

			//绘制轮廓（描边）
			var StrokePen = new Pen(Color.Black)
			{
				Width = 1.7F,
			};

			g.DrawPath(StrokePen, path);

			//填充轮廓（填充）
			g.FillPath(Brushes.White, path);
		}

		/// <summary>
		/// 获得文本路径
		/// </summary>
		/// <param name="s"></param>
		/// <param name="dpi"></param>
		/// <param name="rect"></param>
		/// <param name="font"></param>
		/// <param name="format"></param>
		/// <returns></returns>
		public static GraphicsPath GetStringPath(string s, float dpi, RectangleF rect, Font font, StringFormat format)
		{
			var path = new GraphicsPath();
			float emSize = dpi * font.SizeInPoints / 72;

			path.AddString(s, font.FontFamily, (int)font.Style, emSize, rect, format);

			return path;
		}
		#endregion



		#region 控件方法
		/// <summary>
		/// 变更大小
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ItemIconCell_Resize(object sender, EventArgs e)
		{
			base.Width = base.Height = this.Scale;
		}

		public void ItemIconCell_DoubleClick(object sender, EventArgs e)
		{
			ObjectRef.PreviewShow();
		}
		#endregion
	}
}
