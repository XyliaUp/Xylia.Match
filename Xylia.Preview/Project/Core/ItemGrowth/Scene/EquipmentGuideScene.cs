using System.Windows.Forms;

using Xylia.Preview.Data.Record;
using Xylia.Preview.Project.Core.ItemGrowth.Page;

using ItemData = Xylia.Preview.Data.Record.Item;


namespace Xylia.Preview.Project.Core.ItemGrowth.Scene
{
	public partial class EquipmentGuideScene : Form
	{
		#region 构造
		public ItemData ItemInfo;

		private EquipmentGuideScene() => InitializeComponent();

		public EquipmentGuideScene(ItemData MyWeapon) : this() => this.ItemInfo = MyWeapon;
		#endregion


		ItemGrowth2Page ItemGrowth2Page = new();

		ItemImprovePage ItemImprovePage = new();
		


		#region 方法
		public void ShowItemGrowth2()
		{
			#region 初始化
			//查询成长路径 如果数据不存在，则关闭页面查看
			var Recipes = ItemTransformRecipe.QueryRecipe(ItemInfo);
			if (Recipes is null) return;
			#endregion

			this.ItemGrowth2Page.MyWeapon = ItemInfo;
			this.ItemGrowth2Page.SetData(Recipes);

			this.ItemGrowth2Page.Dock = DockStyle.Fill;
			this.Controls.Add(this.ItemGrowth2Page);
		}

		public void ShowItemImprove()
		{
			var ImproveData = FileCache.Data.ItemImprove[ItemInfo.ImproveId, ItemInfo.ImproveLevel];
			if(ImproveData is null) return;

			this.ItemImprovePage.MyWeapon = ItemInfo;
			this.ItemImprovePage.SetData(ImproveData, ItemInfo.ImprovePrevItem, ItemInfo.ImproveNextItem);

			this.ItemImprovePage.Dock = DockStyle.Fill;
			this.Controls.Add(this.ItemImprovePage);
		}
		#endregion
	}
}
