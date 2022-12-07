using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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

		#region 字段
		public bool InLoading = false;
		#endregion


		#region 方法
		public void ShowItemGrowth2(ItemData ItemInfo, IEnumerable<ItemTransformRecipe> Recipes = null)
		{
			#region 初始化
			if (ItemInfo is null) return;

			if (this.InLoading)
			{
				//等待到加载完成，所以要注意这个等待标志值不能发生异常
				while (this.InLoading) Thread.Sleep(100);
				return;
			}

			this.InLoading = true;
			this.itemGrowth2Page1.MyWeapon = ItemInfo;

			//查询成长路径
			if (Recipes is null) Recipes = ItemTransformRecipe.QueryRecipe(ItemInfo);
			#endregion




			#region 显示内容
			if (Recipes != null && Recipes.Any())
			{
				string Info = null;
				Recipes.ToList().ForEach(r => Info += $"{r.Alias}    -    { r.warning }" + "\n");

				Info = $"查询物品 { ItemInfo.NameText() } 相关成长路径如下：\n" + Info?.RemoveSuffixString("\n");
				Console.WriteLine(Info);

				this.itemGrowth2Page1.SetData(Recipes);
			}
			else
			{
				//关闭页面查看
			}
			#endregion

			this.InLoading = false;
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
