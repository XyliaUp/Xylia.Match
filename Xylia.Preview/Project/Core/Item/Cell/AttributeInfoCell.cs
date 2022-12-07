using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Xylia.Extension;
using Xylia.Preview.Data.Record;

namespace Xylia.Preview.Project.Core.Item.Cell
{
	public partial class AttributeInfoCell : UserControl
	{
		#region 构造
		public AttributeInfoCell()
		{
			InitializeComponent();

			this.BackColor = Color.Transparent;
			this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.Selectable | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="LeftText">左侧文本</param>
		/// <param name="RightText">右侧文本</param>
		public AttributeInfoCell(string LeftText, string RightText) : this()
		{
			this.LeftText = LeftText;
			this.RightText = RightText;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="RandomAbilitySlot"></param>
		public AttributeInfoCell(ItemRandomAbilitySlot RandomAbilitySlot) : this()
		{
			this.LeftText = RandomAbilitySlot.ability.GetDescription() + " " + RandomAbilitySlot.ValueMin;
			this.RightText = "最大" + RandomAbilitySlot.ValueMax;
		}
		#endregion




		#region 字段
		[Category("Appearacne"), Description("左侧文本")]
		public string LeftText
		{
			get => this.lbl_MainInfo.Text;
			set => this.lbl_MainInfo.Text = value;
		}

		[Category("Appearacne"), Description("右侧文本")]
		public string RightText
		{
			get => this.panelContent1.Text;
			set
			{
				this.panelContent1.Text = value;
				this.panelContent1.Location = new Point(this.Width - this.panelContent1.Width, this.panelContent1.Top);
			}
		}

		public override Font Font 
		{ 
			get => this.lbl_MainInfo.Font;
			set => this.panelContent1.Font = this.lbl_MainInfo.Font = value;
		}
		#endregion

		#region 重写方法
		public override void Refresh()
		{
			this.Height =  this.lbl_MainInfo.Height;
			base.Refresh();
		}
		#endregion

		private void AttributeInfoCell_Load(object sender, EventArgs e)
		{

		}

		private void AttributeInfoCell_Resize(object sender, EventArgs e)
		{
			this.panelContent1.Location = new Point(this.Width - this.panelContent1.Width, this.panelContent1.Top);
		}
	}
}
