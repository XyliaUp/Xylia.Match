using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using Xylia.Extension;
using Xylia.Preview.Project.Controls;

namespace Xylia.Preview.Project.Core.ItemGrowth.Game_Intension.Preview
{
	public sealed class OptionList : Panel
	{
		#region 构造
		public OptionList()
		{
			this.AutoScroll = true;
		}


		[DllImport("user32.dll")]
		private static extern bool ShowScrollBar(IntPtr hWnd, int wBar, bool bShow);

		protected override void WndProc(ref Message m)
		{
			//禁用水平滚动条
			ShowScrollBar(this.Handle, 0, false);
			base.WndProc(ref m);
		}
		#endregion

		#region 事件与委托
		public int SelectedIndex = 0;

		public event EventHandler SelectedItemChanged;
		#endregion

		#region 内容处理
		[Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
		[Category(), Description("内容")]
		public readonly List<string> Options = new();

		public void Add(string Option) => Options.Add(Option);

		public void Clear() => Options.Clear();
		#endregion


		#region 方法
		/// <summary>
		/// 刷新列表内容
		/// </summary>
		public void RefreshList()
		{
			this.Controls.Clear();

			int LocY = 0;
			for (int idx = 0; idx < Options.Count; idx++)
			{
				var CurIdx = idx;
				var panel = new ContentPanel(Options[idx])
				{
					Location = new Point(0, LocY),
					ForeColor = this.ForeColor,

					UseMaxWidth = true,
				};

				panel.Click += new((s, e) =>
				{
					this.Controls.OfType<ContentPanel>().ForEach(o => o.BackColor = Color.Transparent);
					panel.BackColor = Color.SteelBlue;

					this.SelectedIndex = CurIdx;
					this.SelectedItemChanged?.Invoke(s, e);
				});

				this.Controls.Add(panel);
				panel.Refresh();
				LocY = panel.Bottom;
			}
		}
		#endregion
	}
}
