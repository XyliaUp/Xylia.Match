using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using Xylia.Preview.Data.Record;
using Xylia.Preview.Project.Core.ItemGrowth.Page;

using ItemData = Xylia.Preview.Data.Record.Item;


namespace Xylia.Preview.Project.Core.ItemGrowth.Scene
{
	public partial class EquipmentGuideScene : Form
	{
		#region 构造
		private readonly ItemData ItemInfo;

		public EquipmentGuideScene(ItemData MyWeapon)
		{
			InitializeComponent();

			this.ItemInfo = MyWeapon;

			this.ItemTransformRecipes = ItemTransformRecipe.QueryRecipe(ItemInfo);
			this.ItemImprove = FileCache.Data.ItemImprove[ItemInfo.ImproveId, ItemInfo.ImproveLevel];
		}

		private void EquipmentGuideScene_Load(object sender, System.EventArgs e)
		{
			this.ShowItemGrowth2();
			this.ShowItemImprove();
		}
		#endregion



		#region ItemTransformRecipe
		IEnumerable<ItemTransformRecipe> ItemTransformRecipes;

		public bool HasItemTransformRecipe => ItemTransformRecipes != null && ItemTransformRecipes.Any();

		private void ShowItemGrowth2()
		{
			if (!HasItemTransformRecipe) return;

			ItemGrowth2Page ItemGrowth2Page = new() { Dock = DockStyle.Fill };
			this.Controls.Add(ItemGrowth2Page);

			ItemGrowth2Page.MyWeapon = ItemInfo;
			ItemGrowth2Page.SetData(ItemTransformRecipes);
		}
		#endregion

		#region ItemImprove
		ItemImprove ItemImprove;

		public bool HasItemImprove => this.ItemImprove != null;

		private void ShowItemImprove()
		{
			if (!HasItemImprove) return;

			ItemImprovePage ItemImprovePage = new() { Dock = DockStyle.Fill };
			this.Controls.Add(ItemImprovePage);

			ItemImprovePage.MyWeapon = ItemInfo;
			ItemImprovePage.SetData(this.ItemImprove, ItemInfo.ImprovePrevItem, ItemInfo.ImproveNextItem);
		}
		#endregion
	}
}
