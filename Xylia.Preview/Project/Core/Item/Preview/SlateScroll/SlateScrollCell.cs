using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Xylia.Preview.Project.Core.Item.Cell
{
	/// <summary>
	/// 刻印书单元
	/// </summary>
	public partial class SlateScrollCell : UserControl
	{
		#region 构造
		public SlateScrollCell()
		{
			InitializeComponent();

			this.AutoSize = false;
			this.BackColor = Color.Transparent;
		}
		#endregion

		#region 字段
		[Category("Appearance"), Description("")]
		public Bitmap Icon
		{
			set => this.Panel_ItemInfo.ItemIcon = value;
			get => this.Panel_ItemInfo.ItemIcon;
		}

		[Category("Appearance"), Description("")]
		public override string Text
		{
			get => this.Panel_ItemInfo.ItemName;
			set => this.Panel_ItemInfo.ItemName = value;
		}

		[Category("Appearance"), Description("品质")]
		public byte Grade
		{
			get => this.Panel_ItemInfo.ItemGrade;
			set => this.Panel_ItemInfo.ItemGrade = value;
		}

		/// <summary>
		/// 能力值信息
		/// </summary>
		[Category("Appearance"), Description("能力值")]
		public string AbilityInfo
		{
			get => this.lbl_AbilityInfo.Text;
			set
			{
				this.lbl_AbilityInfo.Text = value;
				SlateScrollCell_SizeChanged(null, null);
			}
		}
		#endregion

		#region 界面处理
		/// <summary>
		/// 要求界面重绘
		/// </summary>
		public override void Refresh()
		{

		}

		private void RewardCell_Load(object sender, EventArgs e)
		{
			//Load会比构造函数慢
			this.Refresh();
		}

		private void SlateScrollCell_SizeChanged(object sender, EventArgs e)
		{
			this.lbl_AbilityInfo.Location = new Point(this.Width - this.lbl_AbilityInfo.Width, this.lbl_AbilityInfo.Location.Y);
		}
		#endregion
	}
}
