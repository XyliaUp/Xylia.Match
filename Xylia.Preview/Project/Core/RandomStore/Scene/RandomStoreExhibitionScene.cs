using HZH_Controls;

using System.Collections.Generic;
using System.Windows.Forms;

using Xylia.Drawing;
using Xylia.Preview.Project.Controls.PanelEx;
using Xylia.Preview.Project.Core.Store.Cell;
using Xylia.Preview.Data.Record;


namespace Xylia.Preview.Project.RunForm
{
    public partial class RandomStoreExhibitionScene : Form
	{
		#region 构造
		public RandomStoreExhibitionScene()
		{
			InitializeComponent();
		}
		#endregion

		#region 方法
		private void RandomStoreExhibitionScene_Load(object sender, System.EventArgs e)
		{

		}

		private void TabControl_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (ControlHelper.IsDesignMode) return;

			if (this.TabControl.SelectedTab == this.tabPage1)
			{
				if (RandomStoreItemDisplayList_1.Cells is null)
					RandomStoreItemDisplayList_1.Cells = GetCells(RandomStoreNumber.RandomStore1);
			}
			else if (this.TabControl.SelectedTab == this.tabPage2)
			{
				if (RandomStoreItemDisplayList_2.Cells is null)
					RandomStoreItemDisplayList_2.Cells = GetCells(RandomStoreNumber.RandomStore2);
			}
		}

		private List<ListCell> GetCells(RandomStoreNumber RandomStoreType)
		{
			//"最新" 图标
			var SlotItem_New = Properties.Resources.SlotItem_New.ImageThumbnail(1.4);
			var StoreItems = new List<ListCell>();

			//读取为实例
			var RandomStoreItemDisplay = FileCache.Data.RandomStoreItemDisplay;
			//RandomStoreItemDisplay.Sort(new RandomStoreItemDisplaySort());

			foreach (var Record in RandomStoreItemDisplay.Where(a => a.RandomStoreNumber == RandomStoreType))
			{
				#region 初始化
				var DisplayItem = Record.DisplayItem.GetItemInfo();
				var ItemIcon = DisplayItem.IconExtra;

				//追加最新图标
				if (Record.NewArrival) ItemIcon = ItemIcon.ImageCombine(SlotItem_New, Compose.DrawLocation.TopLeft);
				#endregion

				StoreItems.Add(new ItemListCell(DisplayItem, ItemIcon));
			};

			return StoreItems;
		}
		#endregion
	}
}
