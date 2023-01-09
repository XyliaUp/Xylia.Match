using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Xylia.Extension;
using Xylia.Preview.Project.Core.Item.Cell.Basic;

namespace Xylia.Preview.Project.Core.Quest.Preview.Reward.RewardCell
{
	/// <summary>
	/// 奖励物品
	/// </summary>
	public partial class FixedItem : Panel
	{
		protected virtual int ContentStart { get; set; } = 0;

		public FixedItem() => InitializeComponent();


		

		public bool INVALID = true;

		public List<ItemIconCell> Items
		{
			set
			{
				this.Controls.Remove<ItemIconCell>();

				this.INVALID = value is null || value.Count == 0;
				if (INVALID) return;


				#region 渲染对象
				int temp = ContentStart;
				foreach (var cell in value)
				{
					this.Controls.Add(cell);

					cell.Location = new Point(temp, 0);
					temp = cell.Right + 5;
				}
				#endregion
			}
		}
	}
}