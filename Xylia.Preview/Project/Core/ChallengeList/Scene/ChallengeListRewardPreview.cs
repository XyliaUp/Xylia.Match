using System.Drawing;
using System.Windows.Forms;

using Xylia.Extension;
using Xylia.Preview.Data.Record;
using Xylia.Preview.Project.Core.Item.Cell.Basic;

namespace Xylia.Preview.Project.Core.ChallengeList
{
	public partial class ChallengeListRewardPreview : UserControl
	{
		#region 构造
		public ChallengeListRewardPreview() => InitializeComponent();
		#endregion

		#region 事件与委托
		public delegate void RewardSeletedHandle();

		public event RewardSeletedHandle PrevSeleted;

		public event RewardSeletedHandle NextSeleted;


		private void Btn_Prev_Click(object sender, System.EventArgs e)
		{
			this.PrevSeleted?.Invoke();
		}

		private void Btn_Next_Click(object sender, System.EventArgs e)
		{
			this.NextSeleted?.Invoke();
		}
		#endregion

		#region 方法
		public void LoadData(ChallengeListReward Reward)
		{
			this.Controls.Remove<ItemIconCell>();

			#region 加载控件
			int LocX = this.Btn_Prev.Right + 20;
			for (int i = 1; i <= 8; i++)
			{
				var RewardItem = Reward.Attributes["reward-item-" + i].GetItemInfo();
				var RewardItemCount = Reward.Attributes["reward-item-count-" + i].ConvertToShort();
				if (RewardItem is null) continue;

				var ItemIcon = new ItemIconCell()
				{
					ObjectRef = RewardItem,
					Image = RewardItem.IconExtra,
					ShowStackCount = true,
					StackCount = RewardItemCount,

					Location = new Point(LocX, 0),
					Scale = 60,
				};

				this.Controls.Add(ItemIcon);
				LocX = ItemIcon.Right + 10;
			}

			this.Btn_Next.Location = new Point(LocX + 10, this.Btn_Next.Location.Y);
			this.Width = this.Btn_Next.Right;
			#endregion
		}
		#endregion
	}
}