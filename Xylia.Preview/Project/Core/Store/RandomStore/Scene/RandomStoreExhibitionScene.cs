using System.Windows.Forms;

using Xylia.Preview.Data.Record;
using Xylia.Preview.Project.Core.RandomStore;
using Xylia.Preview.Project.Core.RandomStore.Cell;


namespace Xylia.Preview.Project.RunForm
{
	public partial class RandomStoreExhibitionScene : Form
	{
		#region 构造
		public RandomStoreExhibitionScene()
		{
			InitializeComponent();

			this.TabControl.SelectedIndex = 0;
		}
		#endregion


		#region 方法
		private void TabControl_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.DesignMode) return;

			if (this.TabControl.SelectedTab == this.tabPage3)
			{
				
			}
			else if (this.TabControl.SelectedTab == this.tabPage1)
			{
				if (RandomStoreItemDisplayList_1.Cells is null)
					RandomStoreItemDisplayList_1.Cells = ItemDisplayListCell.GetCells(RandomStoreItemDisplay.RandomStoreTypeSeq.Paid);
			}
			else if (this.TabControl.SelectedTab == this.tabPage2)
			{
				if (RandomStoreItemDisplayList_2.Cells is null)
					RandomStoreItemDisplayList_2.Cells = ItemDisplayListCell.GetCells(RandomStoreItemDisplay.RandomStoreTypeSeq.Free);
			}
		}
		#endregion
	}
}
