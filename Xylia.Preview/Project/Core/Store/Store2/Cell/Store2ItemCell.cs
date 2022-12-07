using System.Drawing;

using Xylia.Extension;
using Xylia.Preview.Data.Record;
using Xylia.Preview.Project.Core.Store.Cell;

using ItemData = Xylia.Preview.Data.Record.Item;


namespace Xylia.Preview.Project.Core.Store.Store2
{
	public partial class Store2ItemCell : ItemListCell
	{
		#region 构造
		public Store2ItemCell(ItemData ItemInfo, ItemBuyPrice ItemBuyPrice = null) : base(ItemInfo)
		{
			InitializeComponent();

			//禁止显示右侧文本
			this.ShowRightText = false;

			this.BuyPriceCell = new BuyPriceCell();
			this.Controls.Add(this.BuyPriceCell);

			this.BuyPriceCell.Dock = System.Windows.Forms.DockStyle.Right;
			this.BuyPriceCell.ParentHeight = this.Height;
			
			this.LoadData(ItemBuyPrice);
		}
		#endregion

		#region 方法
		public void LoadData(ItemBuyPrice ItemBuyPrice)
		{
			base.Refresh();
			this.SuspendLayout();

			this.BuyPriceCell.ItemBuyPrice = ItemBuyPrice;


			#region 初始化控件信息
			//这段代码原先是为了控制物品名称不与购买价格重叠
			this.ItemShow.MaximumSize = new Size(this.BuyPriceCell.Left - this.ItemShow.Left, 999999);
			this.ItemShow.BringToFront();

			//设置高度
			//this.Height = Math.Max(Math.Max(this.Height, this.BuyPriceCell.MyHeight), this.NameCell.Height);
			#endregion

			#region 处理限购策略信息
			var ContentQuota = FileCacheData.Data.ContentQuota.GetInfo(ItemBuyPrice.CheckContentQuota);
			if (ContentQuota is null) this.quotaTxt.Visible = false;
			else
			{
				string ContentQuotaInfo = ContentQuota.Info;
				if (!string.IsNullOrWhiteSpace(ContentQuotaInfo))
				{
					this.quotaTxt.Visible = true;
					this.quotaTxt.Text = ContentQuotaInfo;
					this.quotaTxt.BringToFront();
				}
			}
			#endregion

			#region 处理购买价格信息
			string TipInfo = null;

			if (ItemBuyPrice != null)
			{
				this.ItemShow.IconCell.FrameImage = null;

				if (ItemBuyPrice.RequiredAchievementScore != 0)
				{
					TipInfo += "需要成就点数：" + ItemBuyPrice.RequiredAchievementScore + "\n";
					this.ItemShow.IconCell.ExtraBottomLeft = Resources.BnsCommon.unuseable_Achievement;
				}

				if (ItemBuyPrice.RequiredAchievementId != 0)
				{
					string AchievementName = FileCacheData.Data.Achievement.Find(o => o.ID == ItemBuyPrice.RequiredAchievementId && o.Step == ItemBuyPrice.RequiredAchievementStepMin).NameText();

					TipInfo += "需要完成成就：" + AchievementName + "\n";
					this.ItemShow.IconCell.ExtraBottomLeft = Resources.BnsCommon.unuseable_Achievement;
				}

				if (ItemBuyPrice.FactionLevel != 0)
				{
					var MainFaction1 = ((MainFaction1)ItemBuyPrice.FactionLevel).ToString().Replace("_", null);
					var MainFaction2 = ((MainFaction2)ItemBuyPrice.FactionLevel).ToString().Replace("_", null);


					TipInfo += $"需要势力阶级\n武林盟：{ MainFaction1 }以上\n浑天教：{ MainFaction2 }以上\n";
					this.ItemShow.IconCell.ExtraBottomLeft = Resources.BnsCommon.unuseable_lock;
				}

				//可以合并显示
				if (ItemBuyPrice.CheckSoloDuelGrade != 0)
				{
					TipInfo += "需要个人战：" + ItemBuyPrice.CheckSoloDuelGrade + "以上\n";
					this.ItemShow.IconCell.ExtraBottomLeft = Resources.BnsCommon.unuseable_lock;
				}

				if (ItemBuyPrice.CheckTeamDuelGrade != 0)
				{
					TipInfo += "需要车轮战：" + ItemBuyPrice.CheckTeamDuelGrade + "以上\n";
					this.ItemShow.IconCell.ExtraBottomLeft = Resources.BnsCommon.unuseable_lock;
				}

				if (ItemBuyPrice.CheckBattleFieldGradeOccupationWar != 0)
				{
					TipInfo += "需要升龙谷：" + ItemBuyPrice.CheckBattleFieldGradeOccupationWar + "以上\n";
					this.ItemShow.IconCell.ExtraBottomLeft = Resources.BnsCommon.unuseable_lock;
				}

				if (ItemBuyPrice.CheckBattleFieldGradeCaptureTheFlag != 0)
				{
					TipInfo += "需要白鲸湖：" + ItemBuyPrice.CheckBattleFieldGradeCaptureTheFlag + "以上\n";
					this.ItemShow.IconCell.ExtraBottomLeft = Resources.BnsCommon.unuseable_lock;
				}

				if (ItemBuyPrice.CheckBattleFieldGradeLeadTheBall != 0)
				{
					TipInfo += "需要银河遗迹：" + ItemBuyPrice.CheckBattleFieldGradeLeadTheBall + "以上\n";
					this.ItemShow.IconCell.ExtraBottomLeft = Resources.BnsCommon.unuseable_lock;
				}
			}

			//如果购买价格无效，则将图标显示为异常图标
			else if (this.ItemShow.IconCell.ItemIcon != null)
			{
				this.ItemShow.IconCell.FrameImage = Properties.Resources.ItemError;
				this.ItemShow.IconCell.FrameType = false;
			}
			#endregion

			#region 设置提示内容
			if (!(ContentQuota?.ResetInfo).IsNull()) TipInfo += ContentQuota?.ResetInfo + "初始化购买限制" + "\n";
			if (!TipInfo.IsNull()) this.SetToolTip(TipInfo.RemoveSuffixString("\n"));
			#endregion

			this.ResumeLayout();
		}
		#endregion
	}
}
