using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

using Xylia.Preview.Data.Record;
using Xylia.Preview.Project.Core.Item.Cell.Basic;

namespace Xylia.Preview.Project.Core.ItemGrowth.Cell
{
	public class FeedItemIconCell : PictureBox
	{
		#region 构造
		public FeedItemIconCell()
		{
			this.DoubleClick += new EventHandler((o, e) =>
			{
				var t = new Thread(act => ItemAlias.PreviewShow());

				t.SetApartmentState(ApartmentState.STA);
				t.Start();
			});

			this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.Selectable | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
		}
		#endregion


		#region 字段
		public Bitmap FrameImage { get; set; } = Properties.Resources.FeedItem;

		/// <summary>
		/// 物品别名
		/// </summary>
		public string ItemAlias;

		private bool m_ShowFrameImage;

		[Category("Apperance"), Description("显示框架图标")]
		public bool ShowFrameImage
		{
			get => this.m_ShowFrameImage;
			set
			{
				m_ShowFrameImage = value;
				this.Refresh();
			}
		}

		#region 物品数量处理
		/// <summary>
		/// 物品数量
		/// </summary>
		[Category("Item"), Description("物品数量")]
		public uint StackCount { get; set; }

		/// <summary>
		/// 显示物品数量
		/// </summary>
		[Category("Item"), Description("显示物品数量")]
		public bool ShowStackCount { get; set; }

		/// <summary>
		/// 显示物品数量
		/// </summary>
		[Category("Item"), Description("当数量为1时，是否显示物品数量")]
		public bool ShowStackCountOnlyOne { get; set; }
		#endregion
		#endregion


		#region 方法
		protected override void OnPaint(PaintEventArgs pe)
		{
			if (this.FrameImage is null) base.OnPaint(pe);
			this.Width = this.FrameImage.Width * this.Height / this.FrameImage.Height;

			#region 计算边界大小
			float WRatio = (float)this.Width / this.FrameImage.Width;
			float HRatio = (float)this.Height / this.FrameImage.Height;
			int Left = 13, Right = 13, Top = 20, Bottom = 14;
			#endregion


			#region 处理图片信息
			int RealWidth = (int)(WRatio * (this.FrameImage.Width - Left - Right));
			int RealHeight = (int)(HRatio * (this.FrameImage.Height - Bottom - Top));

			var Img = this.Image ?? Xylia.Resources.BnsCommon_Old.ItemIcon;
			pe.Graphics.DrawImage(Img, new Rectangle((int)(WRatio * Left), (int)(HRatio * Top), RealWidth, RealHeight));
			#endregion

			//绘制堆叠信息
			if (ShowStackCount && (ShowStackCountOnlyOne || this.StackCount != 1))
				ItemIconCell.DrawStackCount(pe.Graphics, this.StackCount, new SizeF(
					(int)(WRatio * (this.FrameImage.Width - Right)),
					(int)(HRatio * (this.FrameImage.Height - Bottom))));

			//绘制背景层
			if (this.ShowFrameImage) pe.Graphics.DrawImage(this.FrameImage, new Rectangle(0, 0, this.Width, this.Height));
		}
		#endregion
	}
}
