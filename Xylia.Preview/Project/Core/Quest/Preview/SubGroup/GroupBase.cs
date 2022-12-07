using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Xylia.Preview.Project.Core.Quest.Preview.SubGroup
{
	/// <summary>
	/// 分组控件基类
	/// </summary>
	public partial class GroupBase : UserControl
	{
		#region 构造
		public GroupBase()
		{
			InitializeComponent();

			this.BackColor = Color.Transparent;
		}
		#endregion


		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		public string GroupText { get => this.GroupName.Text; set => this.GroupName.Text = value; }

		/// <summary>
		/// 内容起始横坐标
		/// </summary>
		public const int ContentStartX = 20;
	}
}
