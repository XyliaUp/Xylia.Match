using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

using Xylia.Drawing;
using Xylia.Preview.Project.Controls.PanelEx;

namespace Xylia.Preview.Project.Core.Store
{
	/// <summary>
	/// 商店列表控件
	/// </summary>
	public partial class StoreListPreview : Panel
	{
		#region 构造
		public StoreListPreview()
		{
			InitializeComponent();

			this.Controls.Clear();
			this.ContextMenuStrip = null;
		}
		#endregion

		#region 委托
		public EventHandler ItemCellDoubleClick;
		#endregion


		#region 字段
		/// <summary>
		/// 商店别名
		/// </summary>
		public string StoreAlias;

		/// <summary>
		/// 最大单页控件数量
		/// </summary>
		public int MaxCellNum { get; set; }

		/// <summary>
		/// 最大页面数量
		/// </summary>
		public int MaxPageNum { get; set; } = 0;




		private IEnumerable<ListCell> m_Cells;

		/// <summary>
		/// 设置商店成员实例
		/// </summary>
		public IEnumerable<ListCell> Cells
		{
			get => this.m_Cells;
			set
			{
				this.m_Cells = value;
				this.ContextMenuStrip = null;

				//要求复位
				//this.ScrollBar.Reset();
				this.Controls.Clear();
				if (value is null) return;


				//如果不为空才设置菜单栏
				this.ContextMenuStrip = MainMenu;

				//遍历子元素控件
				int LocY = 0;
				foreach (var o in value)
				{
					this.Controls.Add(o);

					if (ItemCellDoubleClick != null) o.DoubleClick += ItemCellDoubleClick;

					o.ForeColor = Color.White;
					o.Location = new Point(0, LocY);
					o.Width = this.Width - 20;

					LocY = o.Bottom;
				}
			}
		}
		#endregion

		#region 方法
		/// <summary>
		/// 另存为图片
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void SaveAsImage_Click(object sender, EventArgs e)
		{
			new Thread((ThreadStart)delegate
			{
				try
				{
					//设置默认保存名称
					this.DrawMeToBitmap().SaveDialog(StoreAlias ?? "兑换列表");
				}
				catch (Exception ee)
				{
					Tip.Message(ee.ToString());
				}

			}).Start();

			GC.Collect();
		}
		#endregion
	}
}
