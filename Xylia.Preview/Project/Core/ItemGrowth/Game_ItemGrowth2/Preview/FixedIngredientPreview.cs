using System;
using System.Drawing;
using System.Windows.Forms;

using Xylia.Extension;
using Xylia.Preview.Data.Record;
using Xylia.Preview.Project.Core.Item.Cell.Basic;

using ItemData = Xylia.Preview.Data.Record.Item;


namespace Xylia.Preview.Project.Core.ItemGrowth.ItemGrowth2.Preview
{
	public partial class FixedIngredientPreview : Panel
	{
		#region 事件与委托

		public event EventHandler DataLoaded;
		#endregion


		#region 方法
		private void CreateNew(ItemData Item, int StackCount, ref int LocX)
		{
			var ItemIcon = new ItemIconCell()
			{
				ObjectRef = Item,
				Image = Item.Icon,
				ShowStackCount = true,
				StackCount = StackCount,

				Location = new Point(LocX, 0),
				Scale = 45,
			};

			this.Controls.Add(ItemIcon);
			LocX = ItemIcon.Right + 3;
		}

		private void HandleSize(int LocX)
		{
			this.Width = LocX;
			this.Height = 50;

			this.DataLoaded?.Invoke(this, null);
		}

		#endregion



		#region SetData
		public void SetData(ItemTransformRecipe record)
		{
			this.Controls.Remove<ItemIconCell>();

			#region 加载控件
			int LocX = 0;
			for (int i = 1; i <= 8; i++)
			{
				var FixedIngredient = record.Attributes["fixed-ingredient-" + i].GetItemInfo();
				if (FixedIngredient is null) continue;

				var FixedIngredientStackCount = record.Attributes["fixed-ingredient-stack-count-" + i].ConvertToShort();

				CreateNew(FixedIngredient, FixedIngredientStackCount, ref LocX);
			}
			#endregion

			this.HandleSize(LocX);
		}

		public void SetData(ItemImprove record, byte Index)
		{
			this.Controls.Remove<ItemIconCell>();

			#region 加载控件
			int LocX = 0;
			for (int i = 1; i <= 8; i++)
			{
				var CostSubItem = record.Attributes[$"cost-sub-item-{Index}-{i}"].GetItemInfo();
				if (CostSubItem is null) continue;

				var CostSubItemCount = record.Attributes[$"cost-sub-item-count-{Index}-{i}"].ConvertToShort();

				CreateNew(CostSubItem, CostSubItemCount, ref LocX);
			}
			#endregion

			this.HandleSize(LocX);
		}

		public void SetData(ItemImproveOptionList record, byte Index)
		{
			this.Controls.Remove<ItemIconCell>();

			#region 加载控件
			int LocX = 0;
			for (int i = 1; i <= 6; i++)
			{
				var DrawCostSubItem = record.Attributes[$"draw-cost-sub-item-{Index}-{i}"].GetItemInfo();
				if (DrawCostSubItem is null) continue;

				var DrawCostSubItemCount = record.Attributes[$"draw-cost-sub-item-count-{Index}-{i}"].ConvertToShort();

				CreateNew(DrawCostSubItem, DrawCostSubItemCount, ref LocX);
			}
			#endregion

			this.HandleSize(LocX);
		}

		public void SetData(ItemSpirit record)
		{
			this.Controls.Remove<ItemIconCell>();

			#region 加载控件
			int LocX = 0;
			for (int i = 1; i <= 8; i++)
			{
				var FixedIngredient = record.Attributes["fixed-ingredient-" + i].GetItemInfo();
				if (FixedIngredient is null) continue;

				var FixedIngredientStackCount = record.Attributes["fixed-ingredient-stack-count-" + i].ConvertToShort();

				CreateNew(FixedIngredient, FixedIngredientStackCount, ref LocX);
			}
			#endregion

			this.HandleSize(LocX);
		}
		#endregion
	}
}
