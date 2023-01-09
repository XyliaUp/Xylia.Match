using System.ComponentModel;
using System.Windows.Forms;

namespace Xylia.Preview.Project.Core.Quest.Preview.Reward.RewardCell
{
	public partial class RewardCellBase : Panel
	{
		#region 构造
		public RewardCellBase()
		{
			InitializeComponent();

			this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);

			this.AutoSize = true;
		}
		#endregion



		#region 字段
		/// <summary>
		/// 标题
		/// </summary>
		public string Title { get => this.RewardTitle.Text; set => this.RewardTitle.Text = value; }

		/// <summary>
		/// 信息文本
		/// </summary>
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		public override string Text { get => this.panelContent1.Text; set => this.panelContent1.Text = value; }

		/// <summary>
		/// 使用基础信息板
		/// </summary>
		public virtual bool UseBasicPanel { get => this.panelContent1.Visible; set => this.panelContent1.Visible = value; }
		#endregion
	}
}
