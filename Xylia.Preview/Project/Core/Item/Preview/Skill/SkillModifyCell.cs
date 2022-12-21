using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;

namespace Xylia.Preview.Project.Core.Item.Cell
{
	public partial class SkillModifyCell : UserControl
	{
		#region 构造
		public SkillModifyCell()
		{
			InitializeComponent();

			this.BackColor = Color.Transparent;
		}
		#endregion

		#region 字段
		/// <summary>
		/// 技能名称
		/// </summary>
		[Browsable(true)]
		public string SkillName 
		{ 
			set => this.SkillName_Txt.Text = value; 
			get => this.SkillName_Txt.Text;
		}

		/// <summary>
		/// 提示文本
		/// </summary>
		[Browsable(true)]
		[Editor("System.ComponentModel.Design.MultilineStringEditor", typeof(UITypeEditor))]
		public string TooltipText 
		{
			get => this.TooltipText_Txt.Text;
			set
			{
				this.TooltipText_Txt.Text = value;
				this.Refresh();
			}
		}
		#endregion


		#region 重写方法
		public override void Refresh()
		{
			this.Height = SkillName_Txt.Bottom + this.TooltipText_Txt.Height;
		}
		#endregion
	}
}
