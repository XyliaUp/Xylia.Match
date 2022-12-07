using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using Xylia.Configure;
using Xylia.Extension;
using Xylia.Preview.Project.Common.Interface;
using Xylia.Preview.Project.Controls.PanelEx;
using Xylia.Preview.Project.Core.Store.Cell;

using ItemData = Xylia.Preview.Data.Record.Item;


namespace Xylia.Preview.Project.Core.Item.Scene
{
	public partial class SearcherScene : Form
	{
		#region 构造
		public SearcherScene()
		{
			InitializeComponent();

			this.CloseFrmAfterChooseItem.Checked = Ini.ReadValue("Preview", nameof(this.CloseFrmAfterChooseItem)).ToBool();
		}
		#endregion


		#region 方法
		private void SearcherScene_Load(object sender, EventArgs e)
		{
			this.ItemList.ContextMenuStrip = this.MenuStrip;
		}

		private void CloseFrmAfterChooseItem_Click(object sender, EventArgs e)
		{
			Ini.WriteValue("Preview", nameof(this.CloseFrmAfterChooseItem), this.CloseFrmAfterChooseItem.Checked);
		}

		private void ShowItemID_Click(object sender, EventArgs e)
		{
			Ini.WriteValue("Preview", nameof(this.ShowItemID), this.ShowItemID.Checked);

			foreach (var Cell in this.ItemList.Cells.OfType<ItemListCell>())
			{
				if (ShowItemID.Checked) Cell.ItemShow.ItemName = $"[{Cell.ItemShow.ItemData.ID}] {Cell.ItemShow.ItemData.NameText()}";
				else Cell.ItemShow.ItemName = Cell.ItemShow.ItemData.NameText();
			}
		}

		/// <summary>
		/// 显示物品信息
		/// </summary>
		/// <param name="IRecords"></param>
		public void ShowItemList(IEnumerable<IRecord> IRecords)
		{
			//设置单页数量
			this.ItemList.MaxCellNum = 100;

			//物品单元集合
			var StoreItems = new BlockingCollection<ListCell>();
			foreach (var ItemInfo in IRecords.OfType<ItemData>())
			{
				var StoreItemCell = new ItemListCell(ItemInfo)
				{
					ShowRightText = true
				};

				StoreItems.Add(StoreItemCell);
			};

			//设置双击事件
			this.ItemList.ItemCellDoubleClick = new EventHandler((o, e) =>
			{
				if (!this.CloseFrmAfterChooseItem.Checked)
				{
					this.Close();
				}
			});

			this.ItemList.Cells = StoreItems;
		}
		#endregion
	}
}
