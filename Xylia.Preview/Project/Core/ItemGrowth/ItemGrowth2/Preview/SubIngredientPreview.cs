using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using Xylia.bns.Modules.GameData.Enums;
using Xylia.Extension;
using Xylia.Preview.Common.Cast;
using Xylia.Preview.Data.Record;
using Xylia.Preview.Project.Core.ItemGrowth.Cell;

using ItemData = Xylia.Preview.Data.Record.Item;



namespace Xylia.Preview.Project.Core.ItemGrowth.Preview
{
	public partial class SubIngredientPreview : Panel
	{
		#region 事件与委托
		//定义委托
		public delegate void RecipeChangedHandle(RecipeChangedEventArgs e);

		//定义事件
		public event RecipeChangedHandle RecipeChanged;
		#endregion


		#region 方法
		private FeedItemIconCell CreateNew(string ItemAlias, Bitmap Image, int StackCount, ref int LocX)
		{
			var ItemIcon = new FeedItemIconCell
			{
				ItemAlias = ItemAlias,
				Image = Image,
				Location = new Point(LocX, 0),
				StackCount = StackCount,
				Size = new Size(82, 90),
				ShowStackCount = true,
				ShowStackCountOnlyOne = false
			};

			ItemIcon.Click += new EventHandler((s, e) =>
			{
				this.Controls.OfType<FeedItemIconCell>().ForEach(c => c.ShowFrameImage = false);
				ItemIcon.ShowFrameImage = true;

				//this.RecipeChanged?.Invoke(ItemIcon, new RecipeChangedEventArgs(Recipe));
			});

			this.Controls.Add(ItemIcon);
			LocX = ItemIcon.Right + 5;

			return ItemIcon;
		}

		private void HandleSize(int LocX)
		{
			this.Width = LocX;
			this.Height = 90;

			//触发第一个选项 
			this.Controls.OfType<FeedItemIconCell>().FirstOrDefault()?.CallEvent("OnClick");
		}


		public void SetData(IEnumerable<ItemTransformRecipe> ResultRecipes)
		{
			//清理资源
			this.Controls.Remove<FeedItemIconCell>();

			#region 加载控件
			int LocX = 0;
			foreach (var Recipe in ResultRecipes)
			{
				#region 获取数据
				var SubIngredient1 = Recipe.Attributes["sub-ingredient-1"].GetObject();
				var SubIngredientStackCount1 = Recipe.Attributes["sub-ingredient-stack-count-1"].ConvertToShort();
				var SubIngredientConditionType1 = Recipe.Attributes["sub-ingredient-condition-type-1"].ToEnum<ConditionType>();

				string ItemAlias = null;
				Bitmap Image = null;

				if (SubIngredient1 is ItemData ItemInfo)
				{
					ItemAlias = ItemInfo.Alias;
					Image = ItemInfo.Icon;
				}
				else if (SubIngredient1 is ItemBrand ItemBrand)
				{
					//搜索对象
					var ItemTooltip = FileCache.Data.ItemBrandTooltip.Find(info => info.ID == ItemBrand.ID && info.ItemConditionType == SubIngredientConditionType1);

					ItemAlias = ItemBrand.Alias + "_" + ItemTooltip?.ItemConditionType + $" ({ ItemTooltip?.Name2.GetText() })";
					Image = ItemTooltip?.MainIcon();
				}
				#endregion

				//绑定事件
				this.CreateNew(ItemAlias, Image, SubIngredientStackCount1, ref LocX).Click += new EventHandler((s, e) =>
					this.RecipeChanged?.Invoke(new RecipeChangedEventArgs(Recipe)));
			}
			#endregion

			this.HandleSize(LocX);
		}

		public void SetData(ItemImprove ItemImprove)
		{
			//清理资源
			this.Controls.Remove<FeedItemIconCell>();

			#region 加载控件
			int LocX = 0;
			for (byte idx = 1; idx <= 5; idx++)
			{
				var CostMainItem = ItemImprove.Attributes["cost-main-item-" + idx];
				var CostMainItemCount = ItemImprove.Attributes["cost-main-item-count-" + idx].ConvertToShort();
				if (CostMainItem is null) break;

				//绑定事件
				byte CurIdx = idx;
				this.CreateNew(CostMainItem, CostMainItem.GetItemInfo()?.Icon, CostMainItemCount, ref LocX).Click += new EventHandler((s, e) =>
					this.RecipeChanged?.Invoke(new RecipeChangedEventArgs(ItemImprove, CurIdx)));
			}
			#endregion

			this.HandleSize(LocX);
		}
		#endregion
	}

	/// <summary>
	/// 成长路径变更事件
	/// </summary>
	public class RecipeChangedEventArgs : EventArgs
	{
		public ItemTransformRecipe ItemTransformRecipe { get; }
		public RecipeChangedEventArgs(ItemTransformRecipe ItemTransformRecipe) => this.ItemTransformRecipe = ItemTransformRecipe;



		public byte Index { get; }
		public ItemImprove ItemImprove { get; }
		public RecipeChangedEventArgs(ItemImprove ItemImprove, byte Index)
		{
			this.ItemImprove = ItemImprove;
			this.Index = Index;
		}
	}
}
