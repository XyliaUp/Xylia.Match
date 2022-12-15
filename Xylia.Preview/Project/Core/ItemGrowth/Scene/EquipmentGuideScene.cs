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
			this.ItemSpirit = ItemSpirit.Query(MyWeapon);
		}

		private void EquipmentGuideScene_Load(object sender, System.EventArgs e)
		{
			this.ShowItemGrowth2();
			this.ShowIntension();
			this.ShowItemSpirit();
		}
		#endregion


		#region 页面控制

		#endregion




		public bool Valid => this.HasItemTransformRecipe || this.HasItemImprove || this.HasItemSpirit;


		#region ItemTransformRecipe
		IEnumerable<ItemTransformRecipe> ItemTransformRecipes;

		bool HasItemTransformRecipe => ItemTransformRecipes != null && ItemTransformRecipes.Any();

		private void ShowItemGrowth2()
		{
			if (!HasItemTransformRecipe)
			{
				this.TabControl.TabPages.Remove(this.Page_ItemGrowth2);
				return;
			}

			ItemGrowth2Page Page = new();
			this.Page_ItemGrowth2.Controls.Add(Page);

			Page.MyWeapon = ItemInfo;
			Page.SetData(ItemTransformRecipes);
		}
		#endregion

		#region Intension
		ItemImprove ItemImprove;

		bool HasItemImprove => ItemInfo.ImproveId != 0;

		private void ShowIntension()
		{
			if (this.ItemImprove == null) this.TabControl.TabPages.Remove(this.Page_Intension);
			else
			{
				IntensionPanel Page = new();
				Page.MyWeapon = ItemInfo;
				Page.SetData(this.ItemImprove, ItemInfo.ImprovePrevItem, ItemInfo.ImproveNextItem);
				this.Page_Intension.Controls.Add(Page);
			}


			if (ItemInfo.ImproveId == 0) this.TabControl.TabPages.Remove(this.Page_IntensionResetConfirm);
			else
			{
				IntensionResetConfirmPanel Page2 = new();
				Page2.SetData(ItemInfo.ImproveId, ItemInfo.ImproveLevel);
				this.Page_IntensionResetConfirm.Controls.Add(Page2);
			}
		}
		#endregion

		#region ItemSpirit
		ItemSpirit ItemSpirit;

		bool HasItemSpirit => ItemSpirit != null;

		private void ShowItemSpirit()
		{
			if (!HasItemSpirit)
			{
				this.TabControl.TabPages.Remove(this.Page_ItemSpirit);
				return;
			}

			ItemSpiritPage Page = new();
			this.Page_ItemSpirit.Controls.Add(Page);

			Page.MyWeapon = ItemInfo;
			Page.SetData(ItemSpirit);
		}
		#endregion
	}
}
