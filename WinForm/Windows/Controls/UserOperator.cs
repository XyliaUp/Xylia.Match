using System.Windows.Forms;

using Xylia.Extension;


namespace Xylia.Match.Windows.Controls
{
	/// <summary>
	/// 用户操作类
	/// </summary>
	public static class UserOperator
	{
		public static ContextMenuStrip contextMenu
		{
			get
			{
				ContextMenuStrip Menu = new ContextMenuStrip();
				ToolStripMenuItem copy = new ToolStripMenuItem() { Name = "copy", Text = "复制", /*Size = new Size(100, 22),*/ };


				#region  显示控制
				Menu.Opening += (o, a) =>
				{
					// 判断来源是否富文本控件
					if (Menu.SourceControl is RichTextBox box)
					{
						// 当选择内容为空时，复制功能不可用
						copy.Enabled = !box.SelectedText.IsNull();
					}
				};
				#endregion

				#region  功能控制
				// 绑定复制事件
				copy.Click += (o, a) =>
				{
					// 判断来源是否富文本控件
					if (Menu.SourceControl is RichTextBox box)
					{
						Clipboard.SetDataObject(box.SelectedText, true);
					}
				};



				#endregion

				Menu.Items.AddRange(new ToolStripItem[] { copy });
				return Menu;
			}
		}
	}
}
