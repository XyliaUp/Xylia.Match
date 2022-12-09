using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using Xylia.Extension;
using Xylia.Preview.Data.Record;

using ItemData = Xylia.Preview.Data.Record.Item;


namespace Xylia.Preview.Project.Core.ItemGrowth.Scene
{
	public partial class ItemGrowthScene : Form
	{
		#region 构造
		public ItemGrowthScene()
		{
			InitializeComponent();
		}
		#endregion




		#region 方法
		public void ShowItemGrowth2(ItemData ItemInfo, IEnumerable<ItemTransformRecipe> Recipes = null)
		{
			#region 初始化
			if (ItemInfo is null) return;

			this.itemGrowth2Page1.MyWeapon = ItemInfo;

			//查询成长路径
			if (Recipes is null) Recipes = ItemTransformRecipe.QueryRecipe(ItemInfo);

			//关闭页面查看
			if (Recipes is null || !Recipes.Any()) return;
			#endregion


			System.Diagnostics.Trace.WriteLine($"查询物品 { ItemInfo.NameText() } 相关成长路径如下：\n" +
				Recipes.Aggregate(string.Empty, (sum, now) => sum + $"{now.Alias}  {now.warning}\n"));

			this.itemGrowth2Page1.SetData(Recipes);
		}






		private void ItemGrowthScene_SizeChanged(object sender, EventArgs e)
		{
			this.itemGrowth2Page1.Width = this.Width;
		}

		private void ItemGrowthScene_KeyDown(object sender, KeyEventArgs e)
		{
			this.itemGrowth2Page1.KeyDown(e.KeyCode);
		}

		private void ItemGrowthScene_KeyUp(object sender, KeyEventArgs e)
		{
			this.itemGrowth2Page1.KeyUp(e.KeyCode);
		}
		#endregion
	}
}
