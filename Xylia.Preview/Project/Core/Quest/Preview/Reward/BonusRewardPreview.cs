using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Xylia.Extension;
using Xylia.Preview.Data.Record;
using Xylia.Preview.Project.Controls.Currency;
using Xylia.Preview.Project.Core.Item.Cell.Basic;


namespace Xylia.Preview.Project.Core.Quest.Preview.Reward.QuestBonusReward
{
	public partial class BonusRewardPreview : UserControl
	{
		#region 构造
		public BonusRewardPreview() => InitializeComponent();
		#endregion



		#region 方法
		public bool INVALID = false;

		public void LoadData(QuestBonusRewardSetting QuestBonusRewardSetting)
		{
			this.Controls.Remove<ItemIconCell>();


			if (INVALID = QuestBonusRewardSetting is null) return;


			//重置数据
			var ContentsReset = FileCache.Data.ContentsReset[QuestBonusRewardSetting.ContentsReset1];
			//System.Diagnostics.Trace.WriteLine(ContentsReset.Attributes["reset-item-1"].GetItemInfo().NameText());



			var items = new List<ItemIconCell>();

			//额外奖励数据
			var BonusReward = FileCache.Data.QuestBonusReward[QuestBonusRewardSetting.Reward];
			System.Diagnostics.Trace.WriteLine(BonusReward.Attributes);

			if (BonusReward.NormalBonusRewardTotalCount != 0)
			{
				items.AddItem(BonusReward.FixedItem1.GetObjIcon(BonusReward.FixedItemCount1));
				items.AddItem(BonusReward.FixedItem2.GetObjIcon(BonusReward.FixedItemCount2));
				items.AddItem(BonusReward.FixedItem3.GetObjIcon(BonusReward.FixedItemCount3));
				items.AddItem(BonusReward.FixedItem4.GetObjIcon(BonusReward.FixedItemCount4));

				for (int i = 0; i < BonusReward.RandomItemSelectedCount; i++)
					items.Add(Resources.Resource_Common.RandomItem.GetObjIcon());

				System.Diagnostics.Trace.WriteLine(BonusReward.RandomItemSelectedCount);
			}



			int ContentX = 0;
			foreach (var c in items)
			{
				this.Controls.Add(c);

				c.Location = new Point(ContentX, 87);
				ContentX = c.Right + 5;
			}






			if (BonusReward.PaidBonusRewardTotalCount != 0)
			{
				this.label2.Text = $"用{ new MoneyConvert(BonusReward.PaidItemCost) }获取更多";

				System.Diagnostics.Trace.WriteLine("获取更多: ");
				System.Diagnostics.Trace.WriteLine(BonusReward.PaidFixedItem1?.GetItemInfo().NameText());
				System.Diagnostics.Trace.WriteLine(BonusReward.PaidFixedItem2?.GetItemInfo().NameText());
				System.Diagnostics.Trace.WriteLine(BonusReward.PaidFixedItem3?.GetItemInfo().NameText());
				System.Diagnostics.Trace.WriteLine(BonusReward.PaidRandomItemSelectedCount);
			}
		}
		#endregion
	}
}