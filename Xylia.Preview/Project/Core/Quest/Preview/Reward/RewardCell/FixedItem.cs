using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Xylia.Extension;
using Xylia.Preview.Project.Core.Item.Cell.Basic;

namespace Xylia.Preview.Project.Core.Quest.Preview.SubGroup.Reward.RewardCell
{
	/// <summary>
	/// 奖励物品
	/// </summary>
	public partial class FixedItem : Panel
	{
		#region 初始化
		public FixedItem()
		{
			InitializeComponent();
		}
		#endregion


		#region 方法
		public virtual int ContentStart { get; set; } = 0;


		List<ItemIconCell> _items;

		public List<ItemIconCell> Items
		{
			get => this._items;
			set
			{
				_items = value;

				this.Controls.Remove<ItemIconCell>();
				if (value is null || value.Count == 0)
				{
					this.Hide();
					return;
				}

				#region 渲染对象
				this.Show();

				int temp = ContentStart;
				foreach (var cell in value)
				{
					this.Controls.Add(cell);

					cell.Scale = 45;
					cell.Location = new Point(temp, 0);

					temp = cell.Right + 5;
				}
				#endregion
			}
		}
		#endregion
	}
}
