using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Xylia.Preview.Project.Controls.Enums;
using Xylia.Resources;


namespace Xylia.Preview.Project.Controls
{
	/// <summary>
	/// 出售价格控件
	/// </summary>
	[Designer(typeof(Designer.FixedHeightDesigner))]
	public partial class PriceCell : Panel
	{
		#region 构造
		public PriceCell()
		{
			InitializeComponent();

			this.BackColor = Color.Transparent;
			this.ForeColor = Color.White;
			//this.AutoSize = false;

			this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.Selectable | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
		}
		#endregion

		#region 隐藏不需要的属性
		[Browsable(false)]
		public new bool Visible => base.Visible = this.CurrencyCount != 0 || DesignMode;
		#endregion



		#region 字段
		/// <summary>
		/// 描述信息
		/// </summary>
		[Category("Appearance"), Description("描述信息")]
		public string Tooltip { get; set; }

		[Category("Appearance"), Description("字体风格")]
		public FontStyle FontStyle { get; set; }



		private int m_count = 1;

		[Category("Item"), Description("货币数量")]
		public int CurrencyCount
		{
			get => m_count;
			set
			{
				m_count = value;
				this.StartPaint();
			}
		}



		private CurrencyType m_currencyType = CurrencyType.Money;

		[Category("Item"), Description("货币类型")]
		public CurrencyType CurrencyType
		{
			get => m_currencyType;
			set
			{
				m_currencyType = value;
				this.StartPaint();
			}
		}
		#endregion




		#region 方法
		/// <summary>
		/// 开始进行绘制
		/// </summary>
		private void StartPaint()
		{
			this.Refresh();
			this.OnPaint(new PaintEventArgs(this.CreateGraphics(), new Rectangle()));
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			//记录当前位置
			int LoX = 0;


			if (!string.IsNullOrWhiteSpace(this.Tooltip))
			{
				//创建标签行
				e.Graphics.DrawString(this.Tooltip, this.Font, new SolidBrush(this.ForeColor), new Point(LoX, 0));

				//测量长度
				LoX = (int)(e.Graphics.MeasureString(this.Tooltip, this.Font).Width - 4F);
			}


			if (this.CurrencyType == CurrencyType.Money)
			{
				//计算各部分数量
				if (this.CurrencyCount == 0) this.CreateMeta(e.Graphics, 0, BnsCommon_Old.bronze, ref LoX);
				else
				{
					var MoneyConvert = new MoneyConvert(this.CurrencyCount);

					float TxtPadding = 0F;
					int IconPadding = 0;

					if (MoneyConvert.Gold != 0) this.CreateMeta(e.Graphics, MoneyConvert.Gold, BnsCommon_Old.gold, ref LoX, TxtPadding, IconPadding);
					if (MoneyConvert.Silver != 0) this.CreateMeta(e.Graphics, MoneyConvert.Silver, BnsCommon_Old.silver, ref LoX, TxtPadding, IconPadding);
					if (MoneyConvert.Copper != 0) this.CreateMeta(e.Graphics, MoneyConvert.Copper, BnsCommon_Old.bronze, ref LoX, TxtPadding, IconPadding);
				}

				this.Height = 19;
			}
			else
			{
				this.CreateMeta(e.Graphics, this.CurrencyCount, this.CurrencyType.GetCurrencyIcon(), ref LoX);
				this.Height = 23;
			}

			this.Width = LoX;
		}

		/// <summary>
		/// 生成货币单元
		/// </summary>
		public void CreateMeta(Graphics g, int Count, Image Icon, ref int LoX, float TxtPadding = 0, int IconPadding = 0, Size? IconSize = null)
		{
			//如果未传递，则使用常用图标Size
			Size RealSize = IconSize ?? new Size(24, 24);

			//创建标签行
			g.DrawString(Count.ToString(), this.Font, new SolidBrush(this.ForeColor), new Point(LoX, 0));

			//测量长度
			int StrLength = (int)(g.MeasureString(Count.ToString(), this.Font).Width - 4F + TxtPadding);

			if ((FontStyle & FontStyle.Strikeout) == FontStyle.Strikeout)
			{
				//计算删除线位置
				int LineLocY = this.Font.Height / 2 + 1;
				g.DrawLine(new Pen(this.ForeColor, 1.5F), new Point(LoX, LineLocY), new Point(LoX + StrLength, LineLocY));
			}


			//判断图标的显示形式，否则会出现小图标被拉伸的问题
			if (Icon.Width < RealSize.Width && Icon.Height < RealSize.Height)
			{
				RealSize = Icon.Size;
			}


			LoX += StrLength;

			//绘制图像
			g.DrawImage(Icon, new Rectangle(new Point(LoX, 0), RealSize));

			LoX += RealSize.Width + IconPadding;
		}
		#endregion
	}


	/// <summary>
	/// 价格转换
	/// </summary>
	public struct MoneyConvert
	{
		#region 构造
		public MoneyConvert(int? Total) => this.Total = Total ?? 0;

		public MoneyConvert(string Total)
		{
			if (int.TryParse(Total, out int temp)) this.Total = temp;
			else this.Total = 0;
		}
		#endregion


		public int Total { get; set; }

		public int Gold => this.Total / 10000;

		public int Silver => (this.Total % 10000) / 100;

		public int Copper => this.Total % 100;



		public override string ToString() => this.ToString(true);

		public string ToString(bool ShowImg = true)
		{
			string Info = null;

			if (this.Gold != 0) Info += this.Gold + (!ShowImg ? "金" : "<image enablescale=\"true\" path=\"00009076.GameUI_Coin_Gold\" scalerate=\"1.2\"/>");
			if (this.Silver != 0) Info += this.Silver + (!ShowImg ? "银" : "<image enablescale=\"true\" path=\"00009076.GameUI_Coin_Silver\" scalerate=\"1.2\"/>");
			if (this.Copper != 0) Info += this.Copper + (!ShowImg ? "铜" : "<image enablescale=\"true\" path=\"00009076.GameUI_Coin_Bronze\" scalerate=\"1.2\"/>");

			return Info;
		}
	}
}
