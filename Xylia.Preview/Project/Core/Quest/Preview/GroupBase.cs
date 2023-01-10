using System.ComponentModel;
using System.Windows.Forms;

using Xylia.Preview.Common.Interface;

namespace Xylia.Preview.Project.Core.Quest.Preview
{
	/// <summary>
	/// 分组控件基类
	/// </summary>
	public partial class GroupBase : UserControl , IPreview
	{
		#region 构造
		public GroupBase() => InitializeComponent();
		#endregion


		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		public string Title { get => this.GroupName.Text; set => this.GroupName.Text = value; }

		/// <summary>
		/// 内容起始横坐标
		/// </summary>
		public const int ContentStartX = 20;
	}
}