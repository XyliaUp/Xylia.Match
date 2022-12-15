using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using HZH_Controls;

using Xylia.Extension;
using Xylia.Preview.Common.Cast;
using Xylia.Preview.Common.Interface;
using Xylia.Preview.Data.Record;
using Xylia.Preview.Project.Core.Item.Cell.Basic;


namespace Xylia.Preview.Project.Core.Item.Cell
{
	public partial class ProcessComparisonCell : UserControl
	{
		#region 构造
		public ProcessComparisonCell()
		{
			InitializeComponent();
			this.BackColor = Color.Transparent;


			if (!ControlHelper.IsDesignMode)
			{
				this.Controls.Remove(this.itemIconCell1);
				this.Controls.Remove(this.itemIconCell2);
			}
		}

		public ProcessComparisonCell(ItemExchange CrystallRule) : this()
		{
			this.LoadData(CrystallRule);
		}
		#endregion

		#region 方法
		public void LoadData(ItemExchange CrystallRule)
		{
			if (CrystallRule is null) return;

			#region 处理需要物品
			var RequiredItems = new List<ItemIconCell>();
			RequiredItems.AddItem(LoadRequiredItem(CrystallRule.RequiredItem1, CrystallRule.RequiredItemStackCount1));
			RequiredItems.AddItem(LoadRequiredItem(CrystallRule.RequiredItem2, CrystallRule.RequiredItemStackCount2));
			RequiredItems.AddItem(LoadRequiredItem(CrystallRule.RequiredItem3, CrystallRule.RequiredItemStackCount3));
			RequiredItems.AddItem(LoadRequiredItem(CrystallRule.RequiredItem4, CrystallRule.RequiredItemStackCount4));
			#endregion

			#region 处理目标物品
			var NormalItems = new List<ItemIconCell>();
			NormalItems.AddItem(LoadNormalItem(CrystallRule.NormalItem1, CrystallRule.NormalItemStackCount1));
			NormalItems.AddItem(LoadNormalItem(CrystallRule.NormalItem2, CrystallRule.NormalItemStackCount2));
			NormalItems.AddItem(LoadNormalItem(CrystallRule.NormalItem3, CrystallRule.NormalItemStackCount3));
			NormalItems.AddItem(LoadNormalItem(CrystallRule.NormalItem4, CrystallRule.NormalItemStackCount4));
			#endregion


			#region 处理界面
			this.SuspendLayout();

			int LocX = 0;
			int Padding = 2;

			foreach (var c in RequiredItems)
			{
				if (!this.Controls.Contains(c)) this.Controls.Add(c);

				c.Location = new Point(LocX, 0);
				LocX += c.Scale + Padding;
			}

			this.pictureBox3.Location = new Point(LocX + 20, this.pictureBox3.Top);
			LocX += 40 + this.pictureBox3.Width;

			foreach (var c in NormalItems)
			{
				if (!this.Controls.Contains(c)) this.Controls.Add(c);

				c.Location = new Point(LocX, 0);
				LocX += c.Scale + Padding;
			}

			this.ResumeLayout();
			#endregion
		}


		//注意这俩个数据存在区别
		private static ItemIconCell LoadRequiredItem(string ItemAlias, short StackCount) => GetCell(ItemAlias.CastObject(), StackCount);

		private static ItemIconCell LoadNormalItem(string ItemAlias, short StackCount) => GetCell(ItemAlias.GetItemInfo(), StackCount);


		private static ItemIconCell GetCell(IRecord Obj, short StackCount)
		{
			if (Obj is null || Obj is not IPicture o) return null;

			return new ItemIconCell()
			{
				ObjectRef = Obj,
				Image = o.MainIcon(),

				Scale = 52,
				StackCount = StackCount,
				ShowStackCount = true,
				ShowStackCountOnlyOne = false,
			};
		}
		#endregion
	}
}