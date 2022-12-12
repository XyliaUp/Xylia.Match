using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using Xylia.Extension;
using Xylia.Preview.Data.Record;
using Xylia.Preview.Project.Core.Item.Cell.Basic;

namespace Xylia.Preview.Project.Core.ItemGrowth.ItemGrowth2.Preview
{
	[Designer(typeof(Designer.FixedHeightDesigner))]
	public partial class ResultWeaponPreview : UserControl
	{
		#region 构造
		public ResultWeaponPreview() => InitializeComponent();
		#endregion

		#region 事件与委托
		//定义委托
		public delegate void ResultItemChangedHandle(ResultItemChangedEventArgs e);

		//定义事件
		public event ResultItemChangedHandle ResultItemChanged;
		#endregion



		#region 界面方法
		/// <summary>
		/// 单页最大目标数量
		/// </summary>
		const byte MaxCellNum = 5;

		private List<FeedItemIconCell> Items;

		private byte Index = 0;

		private byte RemainCount => (byte)(Items.Count - MaxCellNum - Index);


		private void Btn_Prev_Click(object sender, EventArgs e)
		{
			if (Index == 0) return;

			Index--;
			ShowItems();
		}

		private void Btn_Next_Click(object sender, EventArgs e)
		{
			if (RemainCount == 0) return;

			Index++;
			ShowItems();
		}

		private void ShowItems()
		{
			this.Controls.Remove<FeedItemIconCell>();
			this.Controls.Remove<ItemNameCell>();

			this.Btn_Prev.SetToolTip("+" + Index);
			this.Btn_Next.SetToolTip("+" + RemainCount);


			int LocX = 35;
			foreach (var o in Items.Skip(Index).Take(MaxCellNum))
			{
				this.Controls.Add(o);
				this.Controls.Add(o.BindName);

				o.Location = new Point(LocX, 0);
				LocX = o.Right;

				o.BindName.MaximumSize = new Size(o.Width, int.MaxValue);
				o.BindName.Location = new Point(o.Left + (o.Width - o.BindName.Width) / 2, o.Bottom + 5);
			}
		}
		#endregion



		#region 方法
		private void SetData(Action<string> action, params string[] NextItem)
		{
			this.Items = new();
			foreach (var TitleItem in NextItem)
			{
				#region 创建目标物品控件
				var ItemInfo = TitleItem.GetItemInfo();
				if (ItemInfo is null) continue;

				var cell = new FeedItemIconCell()
				{
					Size = new Size(82, 90),

					ShowStackCount = false,
					ObjectRef = ItemInfo,
					Image = ItemInfo.IconExtra,

					//创建名称
					BindName = new ItemNameCell()
					{
						Text = ItemInfo.ItemName,
						ItemGrade = ItemInfo.ItemGrade,
					},
				};
				this.Items.Add(cell);
				#endregion

				#region 委托绑定事件
				cell.Click += new EventHandler((s, e) =>
				{
					//将其他对象的选择状态取消
					this.Items.ForEach(c =>
					{
						c.ShowFrameImage = false;
						c.Refresh();
					});

					cell.ShowFrameImage = true;
					cell.Refresh();

					action(TitleItem);
				});
				#endregion
			}


			this.Btn_Prev.Visible = this.Btn_Next.Visible = this.Items.Count > MaxCellNum;
			this.ShowItems();

			this.Items.FirstOrDefault()?.CallEvent("OnClick");
		}


		public void SetData(IEnumerable<ItemTransformRecipe> Recipes)
		{
			//获得成长目标信息
			var PreviewResult = Recipes.Select(r => r.TitleItem).Distinct();
			this.SetData(item => this.ResultItemChanged?.Invoke(new ResultItemChangedEventArgs(Recipes.Where(o => o.TitleItem == item))), PreviewResult.ToArray());
		}

		public void SetData(ItemImprove ItemImprove, string ImproveNextItem)
		{
			this.SetData(item => this.ResultItemChanged?.Invoke(new ResultItemChangedEventArgs(ItemImprove)), ImproveNextItem);
		}

		public void SetData(IEnumerable<ItemSpirit> ItemSpirits)
		{
			this.SetData(item => this.ResultItemChanged?.Invoke(new ResultItemChangedEventArgs(ItemSpirits.First(o => o.MainIngredient == item))),
				ItemSpirits.Select(r => r.MainIngredient).ToArray());
		}
		#endregion
	}



	/// <summary>
	/// 目标物品变更事件
	/// </summary>
	public class ResultItemChangedEventArgs : EventArgs
	{
		public IEnumerable<ItemTransformRecipe> Recipes { get; set; }
		public ResultItemChangedEventArgs(IEnumerable<ItemTransformRecipe> Recipes) => this.Recipes = Recipes;


		public ItemImprove ItemImprove;
		public ResultItemChangedEventArgs(ItemImprove ItemImprove) => this.ItemImprove = ItemImprove;


		public ItemSpirit ItemSpirit;
		public ResultItemChangedEventArgs(ItemSpirit ItemSpirit) => this.ItemSpirit = ItemSpirit;
	}
}