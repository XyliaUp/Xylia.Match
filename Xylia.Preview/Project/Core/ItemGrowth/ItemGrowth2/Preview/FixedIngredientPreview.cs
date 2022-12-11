using System.Drawing;
using System.Windows.Forms;

using Xylia.Extension;
using Xylia.Preview.Data.Record;
using Xylia.Preview.Project.Core.Item.Cell.Basic;

using ItemData = Xylia.Preview.Data.Record.Item;


namespace Xylia.Preview.Project.Core.ItemGrowth.Preview
{
	public partial class FixedIngredientPreview : Panel
	{
		#region 事件与委托
		public delegate void DataLoadedHandle();

		public event DataLoadedHandle DataLoaded;
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

			this.DataLoaded?.Invoke();
		}



		public void LoadData(ItemTransformRecipe record)
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

		public void LoadData(ItemImprove record, byte Index)
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

		public void LoadData(ItemSpirit record)
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
