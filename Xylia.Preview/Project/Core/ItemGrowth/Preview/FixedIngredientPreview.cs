using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using Xylia.Preview.Data.Record;
using Xylia.Preview.Project.Common.Interface;
using Xylia.Preview.Project.Core.Item.Cell.Basic;
using Xylia.Preview.Project.Core.Item.Preview.Reward;

namespace Xylia.Preview.Project.Core.ItemGrowth.Preview
{
	public partial class FixedIngredientPreview : UserControl, IPreview
	{
		#region 字段
		const int MyScale = 42;
		const int MyPadding = 3;

		List<Control> Ctls = new List<Control>();
		#endregion

		#region 构造
		public FixedIngredientPreview()
		{
			InitializeComponent();

			this.BackColor = Color.Transparent;
			this.AutoSize = false;
		}
		#endregion

		#region 接口方法
		public bool INVALID() => false;

		public void LoadData(IRecord record)
		{
			var Record = record as ItemTransformRecipe;

			this.Clear();
			this.Ctls = new List<Control>();

			LoadFixedIngredient(Record.FixedIngredient1, Record.FixedIngredientStackCount1);
			LoadFixedIngredient(Record.FixedIngredient2, Record.FixedIngredientStackCount2);
			LoadFixedIngredient(Record.FixedIngredient3, Record.FixedIngredientStackCount3);
			LoadFixedIngredient(Record.FixedIngredient4, Record.FixedIngredientStackCount4);
			LoadFixedIngredient(Record.FixedIngredient5, Record.FixedIngredientStackCount5);
			LoadFixedIngredient(Record.FixedIngredient6, Record.FixedIngredientStackCount6);
			LoadFixedIngredient(Record.FixedIngredient7, Record.FixedIngredientStackCount7);
			LoadFixedIngredient(Record.FixedIngredient8, Record.FixedIngredientStackCount8);
		
			this.Refresh();
		}

		void LoadFixedIngredient(string Item, short StackCount)
		{
			if (Item is null) return;

			var ItemObj = Item.GetItemInfo();
			if (ItemObj != null)
			{
				Ctls.Add(new ItemIconCell()
				{
					ObjectRef = ItemObj,
					ItemIcon = ItemObj.Icon,

					ShowStackCount = true,
					StackCount = Math.Max(1, (uint)StackCount),

					Scale = MyScale,
				});
			}
		}
		#endregion



		#region 重写方法
		public void Clear()
		{
			foreach (var c in this.Controls.OfType<ItemIconCell>()) this.Controls.Remove(c);
		}

		public override void Refresh()
		{
			this.SuspendLayout();
			this.Clear();

			#region 显示控件
			//遵守居中对齐设计，所以在这里需要位置
			//图标大小 + Padding区域大小
			int LocX = (this.Width - (Ctls.Count * MyScale + (Ctls.Count - 1) * MyPadding)) / 2;
			foreach (var c in Ctls)
			{
				if (!this.Controls.Contains(c))
				{
					this.Controls.Add(c);

					//if(!this.IsHandleCreated) 
					//else
					//{
					//	this.Invoke(new MethodInvoker(delegate
					//	{
					//		this.Controls.Add(c);
					//	}));
					//}
				}

				c.Location = new Point(LocX, this.label2.Location.Y - (MyScale - this.label2.Height));
				LocX = c.Right + MyPadding;
			}
			#endregion

			this.ResumeLayout();
		}
		#endregion
	}
}
