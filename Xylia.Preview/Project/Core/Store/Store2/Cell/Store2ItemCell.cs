using System.Collections.Generic;
using System.Drawing;
using System.Linq;

using Xylia.Extension;
using Xylia.Preview.Data.Record;
using Xylia.Preview.Project.Core.Store.Cell;
using Xylia.Preview.Resources;

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
			this.BuyPriceCell.Dock = System.Windows.Forms.DockStyle.Right;
			this.Controls.Add(this.BuyPriceCell);

			this.LoadData(ItemBuyPrice);
		}

		private void LoadData(ItemBuyPrice ItemBuyPrice)
		{
			//如果购买价格无效，则将图标显示为异常图标
			if (ItemBuyPrice is null)
			{
				this.ItemShow.IconCell.FrameImage = Resource_Common.ItemError;
				this.ItemShow.IconCell.FrameType = false;

				return;
			}


			#region 初始化控件信息
			this.ItemShow.IconCell.FrameImage = null;
			this.BuyPriceCell.LoadData(ItemBuyPrice);
			#endregion

			#region 处理限购策略信息
			List<string> TipInfo = new();

			var ContentQuota = FileCache.Data.ContentQuota[ItemBuyPrice.CheckContentQuota];
			if (ContentQuota != null)
			{
				this.quotaTxt.Visible = true;
				this.quotaTxt.Text = ContentQuota.Info;
				this.quotaTxt.BringToFront();

				TipInfo.Add(ContentQuota.ResetInfo + "初始化购买限制");
			}
			#endregion

			#region 处理购买价格信息
			if (ItemBuyPrice.RequiredAchievementScore != 0)
			{
				TipInfo.Add("需要成就点数：" + ItemBuyPrice.RequiredAchievementScore);
				this.ItemShow.IconCell.ExtraBottomLeft = Resource_BNSR.unuseable_Achievement;
			}

			if (ItemBuyPrice.RequiredAchievementId != 0)
			{
				string AchievementName = FileCache.Data.Achievement.Find(o => o.ID == ItemBuyPrice.RequiredAchievementId && o.Step == ItemBuyPrice.RequiredAchievementStepMin).NameText();

				TipInfo.Add("需要完成成就：" + AchievementName);
				this.ItemShow.IconCell.ExtraBottomLeft = Resource_BNSR.unuseable_Achievement;
			}

			if (ItemBuyPrice.FactionLevel != 0)
			{
				var MainFaction1 = ((MainFaction1)ItemBuyPrice.FactionLevel).ToString().Replace("_", null);
				var MainFaction2 = ((MainFaction2)ItemBuyPrice.FactionLevel).ToString().Replace("_", null);

				TipInfo.Add($"需要势力阶级\n武林盟：{ MainFaction1 }以上\n浑天教：{ MainFaction2 }以上");
				this.ItemShow.IconCell.ExtraBottomLeft = Resource_BNSR.unuseable_lock;
			}

			//可以合并显示
			if (ItemBuyPrice.CheckSoloDuelGrade != 0)
			{
				TipInfo.Add("需要个人战：" + ItemBuyPrice.CheckSoloDuelGrade + "以上");
				this.ItemShow.IconCell.ExtraBottomLeft = Resource_BNSR.unuseable_lock;
			}

			if (ItemBuyPrice.CheckTeamDuelGrade != 0)
			{
				TipInfo.Add("需要车轮战：" + ItemBuyPrice.CheckTeamDuelGrade + "以上");
				this.ItemShow.IconCell.ExtraBottomLeft = Resource_BNSR.unuseable_lock;
			}

			if (ItemBuyPrice.CheckBattleFieldGradeOccupationWar != 0)
			{
				TipInfo.Add("需要升龙谷：" + ItemBuyPrice.CheckBattleFieldGradeOccupationWar + "以上");
				this.ItemShow.IconCell.ExtraBottomLeft = Resource_BNSR.unuseable_lock;
			}

			if (ItemBuyPrice.CheckBattleFieldGradeCaptureTheFlag != 0)
			{
				TipInfo.Add("需要白鲸湖：" + ItemBuyPrice.CheckBattleFieldGradeCaptureTheFlag + "以上");
				this.ItemShow.IconCell.ExtraBottomLeft = Resource_BNSR.unuseable_lock;
			}

			if (ItemBuyPrice.CheckBattleFieldGradeLeadTheBall != 0)
			{
				TipInfo.Add("需要银河遗迹：" + ItemBuyPrice.CheckBattleFieldGradeLeadTheBall + "以上");
				this.ItemShow.IconCell.ExtraBottomLeft = Resource_BNSR.unuseable_lock;
			}


			//设置提示内容
			if (TipInfo.Count != 0) this.SetToolTip(TipInfo.Aggregate((sum, now) => sum + "\n" + now));
			#endregion
		}
		#endregion



		private void Store2ItemCell_SizeChanged(object sender, System.EventArgs e)
		{
			//控制物品名称不与购买价格重叠
			this.ItemShow.MaximumSize = new Size(this.BuyPriceCell.Left - 5, 0);

			//this.Height = Math.Max(Math.Max(this.Height, this.BuyPriceCell.MyHeight), this.NameCell.Height);
		}
	}
}
