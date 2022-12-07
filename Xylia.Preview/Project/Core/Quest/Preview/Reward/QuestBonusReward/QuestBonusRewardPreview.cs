using System.Collections.Generic;
using System.Windows.Forms;

using Xylia.Preview.Project.Controls;
using Xylia.Preview.Data.Record;


namespace Xylia.Preview.Project.Core.Quest.Preview.SubGroup.Reward.QuestBonusReward
{
	public partial class QuestBonusRewardPreview : UserControl
	{
		#region 构造
		public QuestBonusRewardPreview()
		{
			InitializeComponent();
		}
		#endregion

		#region 方法
		public void LoadData(IEnumerable<QuestBonusRewardSetting> QuestBonusRewardSettings)
		{
			foreach (var setting in QuestBonusRewardSettings)
			{
				//重置数据
				var ContentsReset = FileCache.Data.ContentsReset[setting.ContentsReset1];
				//System.Diagnostics.Trace.WriteLine(ContentsReset.Attributes["reset-item-1"].GetItemInfo().NameText());


				System.Diagnostics.Trace.WriteLine(setting.Alias + "  " + setting.type);

				//额外奖励数据
				var BonusReward = FileCache.Data.QuestBonusReward[setting.Reward];
				//System.Diagnostics.Trace.WriteLine(BonusReward?.Property.OuterText);

				if(BonusReward.NormalBonusRewardTotalCount !=0)
				{
					System.Diagnostics.Trace.WriteLine(BonusReward.FixedItem1?.GetItemInfo().NameText());
					System.Diagnostics.Trace.WriteLine(BonusReward.RandomItemSelectedCount);
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
		}
		#endregion
	}
}
