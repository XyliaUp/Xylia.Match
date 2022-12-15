using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using Xylia.bns.Modules.GameData.Enums;
using Xylia.Extension;
using Xylia.Preview.Common.Cast;
using Xylia.Preview.Common.Interface;
using Xylia.Preview.Data.Record;

using ItemData = Xylia.Preview.Data.Record.Item;


namespace Xylia.Preview.Project.Core.ItemGrowth.ItemGrowth2.Preview
{
	public partial class SubIngredientPreview : Panel
	{
		#region 事件与委托
		//定义委托
		public delegate void RecipeChangedHandle(RecipeChangedEventArgs e);

		public event RecipeChangedHandle RecipeChanged;


		public event EventHandler DataLoaded;
		#endregion


		#region 方法
		private FeedItemIconCell CreateNew(IRecord ObjectRef, Bitmap Image, int StackCount, ref int LocX)
		{
			var ItemIcon = new FeedItemIconCell
			{
				ObjectRef = ObjectRef,
				Image = Image,
				Location = new Point(LocX, 0),
				StackCount = StackCount,
				Size = new Size(82, 90),
				ShowStackCount = true,
				ShowStackCountOnlyOne = false
			};

			ItemIcon.Click += new EventHandler((s, e) =>
			{
				var Cells = this.Controls.OfType<FeedItemIconCell>();
				if (Cells.Count() == 1) return;

				Cells.ForEach(c =>
				{
					c.ShowFrameImage = false;
					c.Refresh();
				});

				ItemIcon.ShowFrameImage = true;
				ItemIcon.Refresh();
			});

			this.Controls.Add(ItemIcon);
			LocX = ItemIcon.Right + 5;

			return ItemIcon;
		}

		private void HandleSize(int LocX)
		{
			this.Width = LocX;
			this.Height = 90;

			this.DataLoaded?.Invoke(this,new());

			//触发第一个选项 
			this.Controls.OfType<FeedItemIconCell>().FirstOrDefault()?.CallEvent("OnClick");
		}
		#endregion


		#region SetData
		public void SetData(IEnumerable<ItemTransformRecipe> ResultRecipes)
		{
			//清理资源
			this.Controls.Remove<FeedItemIconCell>();

			#region 加载控件
			int LocX = 0;
			foreach (var Recipe in ResultRecipes)
			{
				#region 获取数据
				var SubIngredient1 = Recipe.Attributes["sub-ingredient-1"].CastObject();
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
				this.CreateNew(SubIngredient1, Image, SubIngredientStackCount1, ref LocX).Click += 
					new((s, e) => this.RecipeChanged?.Invoke(new RecipeChangedEventArgs(Recipe)));
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
				var CostMainItem = ItemImprove.Attributes["cost-main-item-" + idx].GetItemInfo();
				if (CostMainItem is null) break;

				var CostMainItemCount = ItemImprove.Attributes["cost-main-item-count-" + idx].ConvertToShort();


				//绑定事件
				byte CurIdx = idx;
				this.CreateNew(CostMainItem, CostMainItem?.Icon, CostMainItemCount, ref LocX).Click += 
					new((s, e) => this.RecipeChanged?.Invoke(new RecipeChangedEventArgs(ItemImprove, CurIdx)));
			}
			#endregion

			this.HandleSize(LocX);
		}

		public void SetData(ItemImproveOptionList ItemImproveOptionList)
		{
			//清理资源
			this.Controls.Remove<FeedItemIconCell>();

			#region 加载控件
			int LocX = 0;
			for (byte idx = 1; idx <= 4; idx++)
			{
				var DrawCostMainItem = ItemImproveOptionList.Attributes["draw-cost-main-item-" + idx].GetItemInfo();
				if (DrawCostMainItem is null) break;

				var DrawCostMainItemCount = ItemImproveOptionList.Attributes["draw-cost-main-item-count-" + idx].ConvertToShort();

				//绑定事件
				byte CurIdx = idx;
				this.CreateNew(DrawCostMainItem, DrawCostMainItem?.Icon, DrawCostMainItemCount, ref LocX).Click += 
					new((s, e) => this.RecipeChanged?.Invoke(new RecipeChangedEventArgs(ItemImproveOptionList, CurIdx)));
			}
			#endregion

			this.HandleSize(LocX);
		}
		#endregion
	}

	/// <summary>
	/// 成长路径变更事件
	/// </summary>
	public sealed class RecipeChangedEventArgs : EventArgs
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


		public ItemImproveOptionList ItemImproveOptionList { get; }
		public RecipeChangedEventArgs(ItemImproveOptionList ItemImproveOptionList, byte Index)
		{
			this.ItemImproveOptionList = ItemImproveOptionList;
			this.Index = Index;
		}
	}
}