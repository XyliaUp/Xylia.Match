
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Xylia.bns.Modules.GameData.Enums;
using Xylia.Extension;
using Xylia.Preview.Data.Record;
using Xylia.Preview.Project.Controls.Currency;
using Xylia.Preview.Project.Core.Item.Cell.Basic;


namespace Xylia.Preview.Project.Core.Quest.Preview.Reward.QuestBonusReward
{
	public partial class BonusRewardPreview : UserControl
	{
		#region 构造
		public BonusRewardPreview()
		{
			InitializeComponent();

			this.Title.Text = "UI.BonusReward.Title".GetText();
		}
		#endregion



		#region 方法
		public bool INVALID = true;

		public void LoadData(QuestBonusRewardSetting QuestBonusRewardSetting)
		{
			int ContentY = 0;
			this.BonusRewardPanel.Controls.Remove<ItemIconCell>();
			this.PaidBonusRewardPanel.Controls.Remove<ItemIconCell>();

			if (INVALID = QuestBonusRewardSetting is null) return;

			#region	BasicQuota
			ContentY = AttractionReward_ChanceNum.Bottom;

			var BasicQuota = FileCache.Data.ContentQuota[QuestBonusRewardSetting.BasicQuota];
			if (BasicQuota is null) this.WarningPreview.Visible = false;
			else
			{
				#region ContentQuota
				this.AttractionReward_ChanceNum.Text = "UI.AttractionReward.ChanceNum".GetText() + $" {BasicQuota.MaxValue}/{BasicQuota.MaxValue}";

				var ContentsReset = FileCache.Data.ContentsReset[QuestBonusRewardSetting.ContentsReset1];
				if (ContentsReset is null) this.AttractionReward_ChargeChanceNum.Visible = false;
				else
				{
					var ResetItem = ContentsReset.Attributes["reset-item-1"].GetItemInfo();
					//System.Diagnostics.Trace.WriteLine(ResetItem.NameText());

					this.AttractionReward_ChargeChanceNum.Visible = true;
					this.AttractionReward_ChargeChanceNum.Text = "UI.AttractionReward.ChargeChanceNum".GetText() + $" ({ResetItem.ItemNameWithGrade})";

					ContentY = AttractionReward_ChargeChanceNum.Bottom;
				}
				#endregion

				#region WarningPreview
				this.WarningPreview.Visible = true;
				this.WarningPreview.Params = new()
				{
					BasicQuota.ChargeTime < 12 ? "Name.Time.Morning".GetText() : "Name.Time.Afternoon".GetText(),
					BasicQuota.ChargeTime,
				};

				if (BasicQuota.ChargeInterval == ResetType.Daily) this.WarningPreview.Text = "UI.DungeonBonusReward.Guide.QuotaDesc.Daily".GetText();
				else if (BasicQuota.ChargeInterval == ResetType.Weekly)
				{
					this.WarningPreview.Text = BasicQuota.ChargeDayOfWeek switch
					{
						DayOfWeek.Sun => "UI.DungeonBonusReward.Guide.QuotaDesc.Sun".GetText(),
						DayOfWeek.Mon => "UI.DungeonBonusReward.Guide.QuotaDesc.Mon".GetText(),
						DayOfWeek.Tue => "UI.DungeonBonusReward.Guide.QuotaDesc.Tue".GetText(),
						DayOfWeek.Wed => "UI.DungeonBonusReward.Guide.QuotaDesc.Wed".GetText(),
						DayOfWeek.Thu => "UI.DungeonBonusReward.Guide.QuotaDesc.Thu".GetText(),
						DayOfWeek.Fri => "UI.DungeonBonusReward.Guide.QuotaDesc.Fri".GetText(),
						DayOfWeek.Sat => "UI.DungeonBonusReward.Guide.QuotaDesc.Sat".GetText(),
					};
				}
				else this.WarningPreview.Text = "未知重置信息";
				#endregion
			}
			#endregion


			#region BonusReward
			ContentY += 15;

			var Reward = FileCache.Data.QuestBonusReward[QuestBonusRewardSetting.Reward];
			//System.Diagnostics.Trace.WriteLine(Reward.Attributes);

			void RandomItemClickEvent(bool Paid = false)
			{
				var TotalInputCount = Paid ? Reward.PaidRandomItemTotalInputCount : Reward.RandomItemTotalInputCount;
				for (int idx = 1; idx <= TotalInputCount; idx++)
				{
					var Prefix = Paid ? "paid-" : null;
					var RandomItem = Reward.Attributes[Prefix + "random-item-" + idx].GetItemInfo();
					var StackCountMin = Reward.Attributes[Prefix + "random-item-stack-count-min-" + idx].ConvertToShort();
					var StackCountMax = Reward.Attributes[Prefix + "random-item-stack-count-max-" + idx].ConvertToShort();

					System.Diagnostics.Trace.WriteLine($"{RandomItem?.NameText()}  {StackCountMin}~{StackCountMax}");
				}
			}


			#region	NormalBonusReward
			if (Reward.NormalBonusRewardTotalCount == 0) this.BonusRewardPanel.Visible = false;
			else
			{
				this.BonusRewardPanel.Visible = true;
				this.BonusRewardPanel.Location = new Point(0, ContentY);

				#region Items
				var items = new List<ItemIconCell>();

				#region FixedItem
				//System.Diagnostics.Trace.WriteLine("FixedItemTotalCount: " + Reward.FixedItemTotalCount);
				items.AddItem(Reward.FixedItem1.GetObjIcon(Reward.FixedItemCount1));
				items.AddItem(Reward.FixedItem2.GetObjIcon(Reward.FixedItemCount2));
				items.AddItem(Reward.FixedItem3.GetObjIcon(Reward.FixedItemCount3));
				items.AddItem(Reward.FixedItem4.GetObjIcon(Reward.FixedItemCount4));
				#endregion

				#region RandomItem
				//System.Diagnostics.Trace.WriteLine("RandomItemSelectedCount: " + Reward.RandomItemSelectedCount);
				for (int i = 0; i < Reward.RandomItemSelectedCount; i++)
				{
					var o = Resources.Resource_Common.RandomItem.GetObjIcon();
					o.Click += new((s, e) => RandomItemClickEvent());

					items.Add(o);
				}
				#endregion

				int ContentX = 0;
				foreach (var c in items)
				{
					this.BonusRewardPanel.Controls.Add(c);

					c.Location = new Point(ContentX, 0);
					ContentX = c.Right + 5;
				}
				#endregion

				ContentY = BonusRewardPanel.Bottom;
			}
			#endregion

			#region PaidBonusReward
			if (Reward.PaidBonusRewardTotalCount == 0) this.PaidBonusRewardPanel.Visible = false;
			else
			{
				this.PaidBonusRewardPanel.Visible = true;
				this.PaidBonusRewardPanel.Location = new Point(0, ContentY);

				#region PaidItemCost
				if (Reward.PaidItemCost == 0) this.CostToggle.Visible = false;
				else
				{
					this.CostToggle.Visible = true;
					this.CostToggle.Params = new() { new MoneyConvert(Reward.PaidItemCost) };
					this.CostToggle.Text = "UI.DungeonBonusReward.Cost.Toggle".GetText();
				}
				#endregion


				#region Items
				var items = new List<ItemIconCell>();

				#region FixedItem
				//System.Diagnostics.Trace.WriteLine("FixedItemTotalCount: " + Reward.PaidFixedItemTotalCount);
				items.AddItem(Reward.PaidFixedItem1.GetObjIcon(Reward.PaidFixedItemCount1));
				items.AddItem(Reward.PaidFixedItem2.GetObjIcon(Reward.PaidFixedItemCount2));
				items.AddItem(Reward.PaidFixedItem3.GetObjIcon(Reward.PaidFixedItemCount3));
				items.AddItem(Reward.PaidFixedItem4.GetObjIcon(Reward.PaidFixedItemCount4));
				#endregion

				#region RandomItem
				//System.Diagnostics.Trace.WriteLine("PaidRandomItemSelectedCount: " + Reward.PaidRandomItemSelectedCount);
				for (int i = 0; i < Reward.RandomItemSelectedCount; i++)
				{
					var o = Resources.Resource_Common.RandomItem.GetObjIcon();
					o.Click += new((s, e) => RandomItemClickEvent(true));

					items.Add(o);
				}
				#endregion


				int ContentX = 0;
				foreach (var c in items)
				{
					this.PaidBonusRewardPanel.Controls.Add(c);

					c.Location = new Point(ContentX, 30);
					ContentX = c.Right + 5;
				}
				#endregion

				ContentY = PaidBonusRewardPanel.Bottom;
			}
			#endregion
			#endregion

			#region 最后处理
			if (BasicQuota != null)
			{
				this.WarningPreview.Location = new Point(this.WarningPreview.Left, ContentY + 20);
				ContentY = this.WarningPreview.Bottom;
			}

			this.Height = ContentY;
			#endregion
		}
		#endregion
	}
}