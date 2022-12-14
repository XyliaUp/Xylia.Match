using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;

using HZH_Controls;

using Xylia.Extension;
using Xylia.Preview.Common.Attribute.ArgTest;
using Xylia.Preview.Project.Designer;

namespace Xylia.Preview.Project.Controls
{
	[OnlyAutoSize(true)]
	[Designer(typeof(FixedDesigner))]
	public partial class ContentPanel : Panel
	{
		#region 构造
		public ContentPanel(string Text) : this() => base.Text = Text;

		public ContentPanel()
		{
			InitializeComponent();
			CheckForIllegalCrossThreadCalls = false;

			//初始状态
			this.BackColor = Color.Transparent;
			this.DoubleBuffered = true;
			this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.Selectable | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
			this.ResizeRedraw = false;
		}
		#endregion


		#region 重写字段
		[DefaultValue(true)]
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		public override bool AutoSize { get => base.AutoSize; set => base.AutoSize = value; }

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public new Size Size { get => base.Size; set => base.Size = value; }


		/// <summary>
		/// 图标
		/// </summary>
		public Bitmap Icon;


		/// <summary>
		/// 符号标记
		/// </summary>
		public string Signal;



		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[Category("Set"), Description("内容")]
		[Editor("System.ComponentModel.Design.MultilineStringEditor", typeof(UITypeEditor))]
		public override string Text
		{
			get => base.Text;
			set
			{
				base.Text = value;
				/*if (Loaded)*/ this.Refresh(); //TODO: 界面显示以后后再触发刷新
			}
		}

		[Category("Set"), Description("基础前景色")]
		public override Color ForeColor
		{
			get => base.ForeColor;
			set
			{
				base.ForeColor = value;
				this.Refresh();
			}
		}
		#endregion



		#region 字段
		/// <summary>
		/// 默认参数
		/// </summary>
		public readonly static List<object> defaultParams = new()
		{
			new Creature(),
		};

		/// <summary>
		/// 参数组
		/// </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public List<object> Params { get; set; } = ControlHelper.IsDesignMode ? null : new(defaultParams);

		private int m_BasicLineHeight = -1;

		/// <summary>
		/// 基本行高度
		/// </summary>
		public int BasicLineHeight
		{
			set => this.m_BasicLineHeight = value;
			get
			{
				if (m_BasicLineHeight == -1)
					m_BasicLineHeight = this.Font.Height + 1;

				return m_BasicLineHeight;
			}
		}

		/// <summary>
		/// 允许的最大宽度
		/// </summary>
		int MaxWidth = 0;
		#endregion



		#region 界面处理方法
		private void PanelContent_Paint(object sender, PaintEventArgs e) => GoPaint(e.Graphics);

		/// <summary>
		/// 通知界面重绘
		/// </summary>
		public override void Refresh()
		{
			base.Refresh();

			if (string.IsNullOrWhiteSpace(Text)) return;
			else this.OnPaint(new PaintEventArgs(this.CreateGraphics(), new Rectangle()));
		}

		/// <summary>
		/// 双击控件复制内容
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void PanelContent_DoubleClick(object sender, EventArgs e)
		{
			var CopyTxt = this.Text/*.CutText()*/;
			if (!string.IsNullOrWhiteSpace(CopyTxt))
				CopyTxt.SetClipboard();
		}

		//protected override void OnAutoSizeChanged(EventArgs e)
		//{
		//	base.OnAutoSizeChanged(e);
		//	this.Refresh();
		//}
		#endregion
	}
}
