using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using Xylia.Extension;
using Xylia.Preview.Common.Cast;
using Xylia.Preview.Data.Record;
using Xylia.Preview.Project.Core.ItemGrowth.Cell;

using ItemData = Xylia.Preview.Data.Record.Item;


namespace Xylia.Preview.Project.Core.ItemGrowth.Preview
{
	public partial class SubIngredientPreview : UserControl
	{
		#region 字段
		const int MyScale = 92;
		const int MyPadding = 5;

		/// <summary>
		/// 祭品控件
		/// </summary>
		readonly List<FeedItemIconCell> FeedItemIconCells = new();
		#endregion

		#region 构造
		public SubIngredientPreview()
		{
			InitializeComponent();

			this.BackColor = Color.Transparent;
			this.AutoSize = false;
		}
		#endregion

		#region 事件与委托
		//定义委托
		public delegate void RecipeChangedHandle(object sender, RecipeChangedEventArgs e);

		//定义事件
		public event RecipeChangedHandle RecipeChanged;
		#endregion


		#region 方法
		public void SetData(IEnumerable<ItemTransformRecipe> ResultRecipes)
		{
			#region 清理资源
			this.FeedItemIconCells.Clear();
			this.Controls.OfType<FeedItemIconCell>().ToList().ForEach(r => this.Controls.Remove(r));
			#endregion

			#region 加载控件
			var TempCtls = new BlockingCollection<FeedItemIconCell>();
			Parallel.ForEach(ResultRecipes, Recipe =>
			{
				#region 创建控件
				FeedItemIconCell ItemIconCell = null;

				var ResultItem = Recipe.SubIngredient1.GetObject();
				if (ResultItem is ItemData ItemInfo)
				{
					ItemIconCell = new FeedItemIconCell
					{
						Image = ItemInfo.Icon,
						ItemAlias = ItemInfo.Alias,

						StackCount = (uint)Recipe.SubIngredientStackCount1,
					};
				}
				else if (ResultItem is ItemBrand ItemBrand)
				{
					//搜索对象
					var ItemTooltip = FileCache.Data.ItemBrandTooltip.Find(info => info.ID == ItemBrand.ID && info.ItemConditionType == Recipe.SubIngredientConditionType1);
					if (ItemTooltip != null)
					{
						ItemIconCell = new FeedItemIconCell
						{
							Image = ItemTooltip?.MainIcon(),
							ItemAlias = ItemBrand.Alias + "_" + ItemTooltip?.ItemConditionType + $" ({ ItemTooltip.Name2.GetText() })",
						};
					}
				}
				else Console.WriteLine("未知的信息 " + Recipe.SubIngredient1);
				#endregion

				#region 绑定委托
				if (ItemIconCell != null)
				{
					#region 进行公共设置
					ItemIconCell.Size = new Size(92, 100);
					ItemIconCell.Tag = Recipe.ID;
					ItemIconCell.ShowStackCount = true;
					ItemIconCell.ShowStackCountOnlyOne = false;
					ItemIconCell.StackCount = Math.Max(1, ItemIconCell.StackCount);
					ItemIconCell.Click += new EventHandler((s, e) =>
					{
						this.FeedItemIconCells.OfType<FeedItemIconCell>().ToList().ForEach(c => c.ShowFrameImage = false);
						ItemIconCell.ShowFrameImage = true;

						this.RecipeChanged?.Invoke(this, new RecipeChangedEventArgs(Recipe));
					});
					#endregion

					TempCtls.Add(ItemIconCell);
				}
				#endregion
			});
			#endregion

			#region 最后处理
			this.FeedItemIconCells.AddRange(TempCtls.OrderBy(c => c.Tag));
			TempCtls.Dispose();
			TempCtls = null;

			//刷新界面
			this.Refresh();

			//触发第一个选项 
			this.FeedItemIconCells.FirstOrDefault()?.CallEvent("OnClick");
			#endregion
		}
		#endregion


		#region 重写方法
		public override void Refresh()
		{
			this.SuspendLayout();

			#region 显示控件
			//遵守居中对齐设计，所以在这里需要位置
			//图标大小 + Padding区域大小
			int LocX = (this.Width - (FeedItemIconCells.Count * MyScale + (FeedItemIconCells.Count - 1) * MyPadding)) / 2;
			foreach (var c in this.FeedItemIconCells)
			{
				if (!this.Controls.Contains(c)) this.Controls.Add(c);

				c.Location = new Point(LocX, 0);
				LocX = c.Right + MyPadding;
			}
			#endregion

			this.ResumeLayout();
			base.Refresh();
		}
		#endregion
	}

	/// <summary>
	/// 成长路径变更事件
	/// </summary>
	public class RecipeChangedEventArgs : EventArgs
	{
		public RecipeChangedEventArgs(ItemTransformRecipe ItemTransformRecipe)
		{
			this.ItemTransformRecipe = ItemTransformRecipe;
		}

		public ItemTransformRecipe ItemTransformRecipe { get; }
	}
}
