using System.ComponentModel;
using System.Drawing;

using Xylia.Preview.Project.Controls.PanelEx;

using ItemData = Xylia.Preview.Data.Record.Item;

namespace Xylia.Preview.Project.Core.Store.Cell
{
	public partial class ItemListCell : ListCell
	{
		#region 构造
		public ItemListCell() => InitializeComponent();

		public ItemListCell(ItemData DisplayItem, Bitmap Icon = null)
		{
			InitializeComponent(); 
			if (DisplayItem is null) return;

			if (Icon != null) this.ItemShow.LoadData(DisplayItem, Icon);
			else this.ItemShow.LoadData(DisplayItem, true);

			//显示职业信息
			var Jobs = DisplayItem.JobInfo;
			if (Jobs != null) this.RightText = Jobs;
		}
		#endregion


		#region 字段
		/// <summary>
		/// 叠加数量
		/// </summary>
		[Category("Item"), Description("叠加数量")]
		public int StoreBundleCount
		{
			get => (int)this.ItemShow.IconCell.StackCount;
			set
			{
				this.ItemShow.IconCell.StackCount = value;

				this.ItemShow.IconCell.ShowStackCountOnlyOne = false;
				this.ItemShow.IconCell.ShowStackCount = true;
			}
		}
		#endregion
	}
}
