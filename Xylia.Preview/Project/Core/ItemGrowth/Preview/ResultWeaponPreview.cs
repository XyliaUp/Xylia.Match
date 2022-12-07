using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using Xylia.Extension;
using Xylia.Preview.Data.Record;
using Xylia.Preview.Project.Core.ItemGrowth.Cell;

using ItemData = Xylia.Preview.Data.Record.Item;


namespace Xylia.Preview.Project.Core.ItemGrowth.Preview
{
	[Designer(typeof(Designer.FixedHeightDesigner))]
	public partial class ResultWeaponPreview : UserControl
	{
		#region 字段
		/// <summary>
	 	/// 单页最大目标数量
		/// </summary>
		const int MaxCellNum = 5;

		readonly  List<ItemPreviewCell> ItemPreviewCells = new();
		#endregion

		#region 事件与委托
		//定义委托
		public delegate void ResultItemChangedHandle(object sender, ResultItemChangedEventArgs e);

		//定义事件
		public event ResultItemChangedHandle ResultItemChanged;
		#endregion

		#region 构造
		public ResultWeaponPreview()
		{
			InitializeComponent();

			this.BackColor = Color.Transparent;
			this.AutoSize = false;


			if (!DesignMode) this.Controls.Remove(this.itemPreviewCell1);
		}
		#endregion

		#region 方法
		/// <summary>
		/// 设置数据
		/// </summary>
		/// <param name="Recipes"></param>
		public void SetData(IEnumerable<ItemTransformRecipe> Recipes)
		{
			ItemPreviewCells.Clear();
			this.Controls.OfType<ItemPreviewCell>().ToList().ForEach(r => this.Controls.Remove(r));

			//获得成长目标信息
			var PreviewResults = Recipes.Select(r => r.TitleItem).Distinct();
			if (PreviewResults.Any())
			{
				#region 缓存查询数据
				var ItemRecipes = new Dictionary<ItemData, IEnumerable<ItemTransformRecipe>>();
				foreach (var Result in PreviewResults)
				{
					var ResultItem = Result.GetItemInfo();
					ItemRecipes.Add(ResultItem, Recipes.Where(r => r.TitleItem == Result));
				}
				#endregion

				#region 创建目标物品控件
				foreach (var Result in ItemRecipes)
				{
					#region 创建控件对象
					ItemPreviewCell ItemPreviewCell = new()
					{
						ItemInfo = Result.Key,
						ShowStackCount = false,
					};

					ItemPreviewCells.Add(ItemPreviewCell);
					#endregion

					#region 委托绑定事件
					ItemPreviewCell.Click += new EventHandler((s, e) =>
					{
						//将其他对象的选择状态取消
						this.ItemPreviewCells.ForEach(c => c.ShowFrameImage = false);
						ItemPreviewCell.ShowFrameImage = true;

						this.ResultItemChanged?.Invoke(this, new ResultItemChangedEventArgs(Result.Key, Result.Value));
					});
					#endregion
				}
				#endregion

				//触发第一个选项 
				Page.ItemGrowth2Page.LastKey = Keys.None;
				this.ItemPreviewCells.First().CallEvent("OnClick");
			}
			else
			{
				//传递无可成长对象
				this.ResultItemChanged?.Invoke(this, null);
			}
		}

		public override void Refresh()
		{
			this.SuspendLayout();

			int LocX = 50;
			foreach (var IconCell in this.ItemPreviewCells)
			{
				if (!this.Controls.Contains(IconCell)) this.Controls.Add(IconCell);

				IconCell.Location = new Point(LocX, 0);
				LocX = IconCell.Right;
			}

			this.ResumeLayout();

			base.Refresh();
		}

		private void ResultWeaponPreview_SizeChanged(object sender, EventArgs e)
		{
			
		}
		#endregion
	}


	/// <summary>
	/// 目标物品变更事件
	/// </summary>
	public class ResultItemChangedEventArgs : EventArgs
	{
		public ResultItemChangedEventArgs(ItemData ItemInfo, IEnumerable<ItemTransformRecipe> Recipes)
		{
			this.ItemInfo = ItemInfo;
			this.Recipes = Recipes;
		}

		public ItemData ItemInfo { get; set; }

		public IEnumerable<ItemTransformRecipe> Recipes { get; set; }
	}
}
