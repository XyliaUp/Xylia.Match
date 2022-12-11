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
			this.ItemSpirits = ItemSpirit.Query(MyWeapon.EquipType);
		}

		private void EquipmentGuideScene_Load(object sender, System.EventArgs e)
		{
			this.ShowItemGrowth2();
			this.ShowItemImprove();
			this.ShowItemSpirit();
		}
		#endregion


		public bool Valid => this.HasItemTransformRecipe || this.HasItemImprove || this.HasItemSpirit;


		#region ItemTransformRecipe
		IEnumerable<ItemTransformRecipe> ItemTransformRecipes;

	    bool HasItemTransformRecipe => ItemTransformRecipes != null && ItemTransformRecipes.Any();

		private void ShowItemGrowth2()
		{
			if (!HasItemTransformRecipe) return;

			ItemGrowth2Page Page = new() { Dock = DockStyle.Fill };
			this.Controls.Add(Page);

			Page.MyWeapon = ItemInfo;
			Page.SetData(ItemTransformRecipes);
		}
		#endregion

		#region ItemImprove
		ItemImprove ItemImprove;

		bool HasItemImprove => this.ItemImprove != null;

		private void ShowItemImprove()
		{
			if (!HasItemImprove) return;

			ItemImprovePage Page = new() { Dock = DockStyle.Fill };
			this.Controls.Add(Page);

			Page.MyWeapon = ItemInfo;
			Page.SetData(this.ItemImprove, ItemInfo.ImprovePrevItem, ItemInfo.ImproveNextItem);
		}
		#endregion

		#region ItemSpirit
		IEnumerable<ItemSpirit> ItemSpirits;

		bool HasItemSpirit => ItemSpirits != null && ItemSpirits.Any();

		private void ShowItemSpirit()
		{
			if (!HasItemSpirit) return;

			ItemSpiritPage Page = new() { Dock = DockStyle.Fill };
			this.Controls.Add(Page);

			Page.MyWeapon = ItemInfo;
			Page.SetData(ItemSpirits);
		}
		#endregion
	}
}
