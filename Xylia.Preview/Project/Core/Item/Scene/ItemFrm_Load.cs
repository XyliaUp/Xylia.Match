using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using Xylia.Attribute.Component;
using Xylia.Drawing.Font;
using Xylia.Extension;
using Xylia.Preview.Common.Enums;
using Xylia.Preview.Data.Package.Pak;
using Xylia.Preview.Data.Record;
using Xylia.Preview.Project.Controls;
using Xylia.Preview.Project.Controls.Currency;
using Xylia.Preview.Project.Controls.PanelEx;
using Xylia.Preview.Project.Core.Item.Util;

using static Xylia.Extension.String;
using static Xylia.Preview.Data.Record.Item;

namespace Xylia.Preview.Project.Core.Item.Scene
{
	public partial class ItemFrm
	{
		#region 控件
		/// <summary>
		/// 操作按钮
		/// </summary>
		readonly UserOperPanel UserOperScene;

		/// <summary>
		/// 控件组
		/// </summary>
		readonly List<Control> PreviewList = new();

		readonly List<Control> BottomControl = new();


		readonly AttributePreview AttributePreview = new();
		#endregion

		#region 控件属性
		[Category("Item"), Description("物品详细信息")]
		public string ItemName { get => this.ItemNameCell.Text; set => this.ItemNameCell.Text = value; }


		public Bitmap CardImage;

		private List<MyInfo> MainInfo { get; set; } = new();

		private List<MyInfo> SubInfo { get; set; } = new();
		#endregion




		#region 载入控件
		/// <summary>
		/// 加载描述
		/// </summary>
		/// <param name="info"></param>
		/// <returns></returns>
		public static ContentPanel LoadDescription2(params string[] info)
		{
			var temp = info.Where(t => t != null);
			if (temp.Any()) return new ContentPanel(temp.Aggregate((sum, now) => sum + "<br/>" + now));

			return null;
		}

		public static TitlePanel LoadDescription(string Title, string Text) => (Title is null || Text is null) ? null : new TitleContentPanel(Title, Text);

		public static ContentPanel LoadDescription7(string Text) => Text is null ? null : new ContentPanel(Text);

		

		/// <summary>
		/// 载入底部控件
		/// </summary>
		/// <param name="Tag"></param>
		/// <param name="Text"></param>
		/// <param name="ForeColor"></param>
		/// <param name="Font"></param>
		public void LoadBottomControl(string Tag, string Text, Color? ForeColor = null, Font Font = null)
		{
			if (Font is null) Font = new Font("Microsoft YaHei UI", 10F);
			if (ForeColor is null) ForeColor = Color.FromArgb(255, 88, 66);

			//目标控件
			var tc = this.BottomControl.Find(c => (string)c.Tag == Tag);
			if (tc != null) return;



			var o = new Label()
			{
				BackColor = Color.Transparent,
				Font = new Font("Microsoft YaHei UI", 10F),
				ForeColor = ForeColor.Value,
				Text = Text,
				Tag = Tag,

				AutoSize = true,
			};

			this.Controls.Add(o);
			this.BottomControl.Add(o);
		}

		/// <summary>
		/// 控件控制方法
		/// </summary>
		/// <param name="Preview"></param>
		public void LoadPreview(Control Preview)
		{
			if (Preview is null || !Preview.Visible) return;

			if (Preview is not ContentPanel)
				Preview.Width = this.Width;


			this.Controls.Add(Preview);
			this.PreviewList.Add(Preview);
		}
		#endregion




		#region 载入数据
		private Dictionary<MainAbility, long> ItemAbility { get; set; } = new();

		/// <summary>
		/// 白字属性部分
		/// </summary>
		private void LoadAbility()
		{
			Dictionary<MainAbility, long> result = new();

			#region 读取攻击力
			var AttackPowerEquipMin = this.ItemInfo.Attributes["attack-power-equip-min"].ConvertToInt();
			var AttackPowerEquipMax = this.ItemInfo.Attributes["attack-power-equip-max"].ConvertToInt();
			result[MainAbility.AttackPowerEquipMinAndMax] = (AttackPowerEquipMin + AttackPowerEquipMax) / 2;

			var PveBossLevelNpcAttackPowerEquipMin = this.ItemInfo.Attributes["pve-boss-level-npc-attack-power-equip-min"].ConvertToInt();
			var PveBossLevelNpcAttackPowerEquipMax = this.ItemInfo.Attributes["pve-boss-level-npc-attack-power-equip-max"].ConvertToInt();
			result[MainAbility.PveBossLevelNpcAttackPowerEquipMinAndMax] = (PveBossLevelNpcAttackPowerEquipMin + PveBossLevelNpcAttackPowerEquipMax) / 2;

			var PvpAttackPowerEquipMin = this.ItemInfo.Attributes["pvp-attack-power-equip-min"].ConvertToInt();
			var PvpAttackPowerEquipMax = this.ItemInfo.Attributes["pvp-attack-power-equip-max"].ConvertToInt();
			result[MainAbility.PvpAttackPowerEquipMinAndMax] = (PvpAttackPowerEquipMin + PvpAttackPowerEquipMax) / 2;
			#endregion

			#region 读取其他属性
			foreach (MainAbility ability in Enum.GetValues(typeof(MainAbility)))
			{
				if (ability == MainAbility.None) continue;

				var Signal = ability.GetAttribute<Signal>().Description;
				var Value = this.ItemInfo.Attributes[Signal];
				var ValueEquip = this.ItemInfo.Attributes[Signal + "-equip"];

				if (Value != null) result[ability] = int.Parse(Value);
				else if (ValueEquip != null) result[ability] = int.Parse(ValueEquip);
			}
			#endregion

			this.ItemAbility = result;
		}


		/// <summary>
		/// 读取宝石类的Buff属性信息
		/// </summary>
		private void LoadEffectInfo()
		{
			for (int i = 1; i <= 4; i++)
			{
				var EffectEquip = FileCache.Data.Effect[this.ItemInfo.Attributes[$"effect-equip-{i}"]];
				if (EffectEquip is not null)
				{
					//显示附加效果文本提示信息
					if (!string.IsNullOrWhiteSpace(EffectEquip.Name3))
						this.MainInfo.Add(new MyInfo(EffectEquip.Name3.GetText()));

					if (!string.IsNullOrWhiteSpace(EffectEquip.Description3))
						this.SubInfo.Add(new MyInfo(EffectEquip.Description3.GetText()));
				}
			}
		}

		/// <summary>
		/// 加载奖励信息
		/// </summary>
		private void LoadReward()
		{
			//判断是否为封印物品
			var Preview = new RewardPreview((this.ItemInfo.Type == ItemType.Grocery && this.ItemInfo.UnsealAcquireItem1.IsNull()) ? "奖励" : "分解");

			#region 绑定修改奖励分页事件
			Preview.SelRewardChanged += (o, s) =>
			{
				//清理先前提示
				this.MainInfo.RemoveAll(Info => Info.Tag == "RewardPreview");

				//如果存在开启物品
				if (s.Page.HasOpenItem2)
				{
					var OpenItem = s.Page.OpenItem2.Item.GetItemInfo();
					var OpenItemCount = s.Page.OpenItem2.StackCount;

					string Info = "需要";
					if (OpenItemCount != 1 && OpenItemCount != 0) Info += OpenItemCount + "个";
					Info += OpenItem?.ItemNameWithGrade;

					this.MainInfo.Insert(0, new MyInfo(Info, "RewardPreview"));
				}



				var SelectedItemAssuredCount = s.Page.RewardInfo.DecomposeReward?.Attributes["selected-item-assured-count"].ConvertToInt() ?? 0;
				if (SelectedItemAssuredCount != 0) this.MainInfo.Add(new MyInfo($"可选择{ SelectedItemAssuredCount }项", "RewardPreview"));

				this.Refresh();
			};
			#endregion

			this.LoadPreview(Preview.LoadInfo(this.ItemInfo));
		}

		/// <summary>
		/// 加载额外信息
		/// </summary>
		private ContentPanel LoadExtraInfo()
		{
			string ExtraInfo = null;

			#region 加载辉石信息
			var BadgeInfo = new List<string>();

			if (this.ItemInfo.BadgeGearScore != 0) BadgeInfo.Add("徽章套装点数 " + this.ItemInfo.BadgeGearScore);
			if (this.ItemInfo.BadgeSynthesisScore != 0) BadgeInfo.Add("徽章合成点数 " + this.ItemInfo.BadgeSynthesisScore);

			if (BadgeInfo.Any()) this.LoadPreview(new ContentPanel(BadgeInfo.Aggregate((sum, now) => sum + "<br/>" + now)));
			#endregion

			#region 加载邮寄费用
			if (this.ItemInfo.DecomposeInfo.DecomposeMoneyCost != 0)
				this.MainInfo.Insert(0, new MyInfo("需要" + new MoneyConvert(this.ItemInfo.DecomposeInfo.DecomposeMoneyCost)));

			//判断是否可以邮寄，限制5铜以上邮费价格道具才能显示追加信息
			if (this.ItemInfo.BaseFee > 5 && (this.ItemInfo.AccountUsed || !this.ItemInfo.CannotTrade))
			{
				string Info = $"邮寄时，每个需要 { new MoneyConvert(this.ItemInfo.BaseFee) }<br/>";
				ExtraInfo += Info;
			}

			var AccountPostCharge = this.ItemInfo.AccountPostCharge;
			if (AccountPostCharge != null)
			{
				var ChargeItem1 = AccountPostCharge.ChargeItem1.GetItemInfo();
				var ChargeItem2 = AccountPostCharge.ChargeItem2.GetItemInfo();

				if (ChargeItem1 != null || ChargeItem2 != null)
				{
					if (ChargeItem1 != null && ChargeItem2 != null)
					{
						ExtraInfo += $"账号交易时，需要" +
						 $"{ ChargeItem1.ItemNameWithGrade }<ga/> { AccountPostCharge.ChargeItemAmount1 }个、<wa/> " +
						 $"{ ChargeItem2.ItemNameWithGrade }<ga/> { AccountPostCharge.ChargeItemAmount2 }个。";
					}
					else
					{
						var ChargeItem = ChargeItem1;
						int ItemCount;
						if (ChargeItem != null) ItemCount = AccountPostCharge.ChargeItemAmount1;
						else
						{
							ChargeItem = ChargeItem2;
							ItemCount = AccountPostCharge.ChargeItemAmount2;
						}

						ExtraInfo += $"账号交易时，需要{ ChargeItem.ItemNameWithGrade }</font><ga/> { ItemCount }个。";
					}
				}
			}
			#endregion


			if (this.ItemInfo.UseRecycleGroupDuration != 0)
				this.MainInfo.Add(new MyInfo("冷却时间 " + TimeSpan.FromMilliseconds(this.ItemInfo.UseRecycleGroupDuration).ToMyString()));


			if (ExtraInfo != null) return new ContentPanel(ExtraInfo);
			return null;
		}

		/// <summary>
		/// 获取交易类别
		/// </summary>
		/// <returns></returns>
		private void LoadTrade()
		{
			if (this.ItemInfo.AccountUsed)
				this.LoadBottomControl("TradeInfo_Account", "账号专用");

			#region 处理前端文本
			string TradeInfo;

			//交易属性显示
			if (this.ItemInfo.CannotTrade)
			{
				if (this.ItemInfo.Auctionable) TradeInfo = "无法个人交易";
				else TradeInfo = "无法交易";
			}
			else if (this.ItemInfo.EquipUsed && ItemInfo.Type != ItemType.Grocery)
			{
				//支持无目标封印状态
				TradeInfo = this.ItemInfo.CannotTrade ? "封印状态时，解除封印后无法交易" : "装备后无法交易";
			}
			else if (this.ItemInfo.AcquireUsed) TradeInfo = "无法交易";  //拾取后无法交易
			else if (this.ItemInfo.Auctionable) TradeInfo = null;
			else TradeInfo = "无法拍卖行交易";
			#endregion

			if (TradeInfo != null) this.LoadBottomControl("TradeInfo", TradeInfo);
		}

		public static Bitmap LoadCardImage(Bitmap CardImage, byte ItemGrade)
		{
			if (CardImage is null) return null;

			var bitmap = new Bitmap(500, 635 + 60);
			Graphics g = Graphics.FromImage(bitmap);

			#region 获取背景图
			var bg = ItemGrade switch
			{
				2 => Resources.Resource_BNSR.CollectionCard_Preview_2,
				3 => Resources.Resource_BNSR.CollectionCard_Preview_3,
				4 => Resources.Resource_BNSR.CollectionCard_Preview_4,
				5 => Resources.Resource_BNSR.CollectionCard_Preview_5,
				6 => Resources.Resource_BNSR.CollectionCard_Preview_6,
				7 => Resources.Resource_BNSR.CollectionCard_Preview_7,
				8 => Resources.Resource_BNSR.CollectionCard_Preview_8,
				9 => Resources.Resource_BNSR.CollectionCard_Preview_9,
				_ => Resources.Resource_BNSR.CollectionCard_Preview_1,
			};
			#endregion

			g.DrawImage(CardImage, 0, 60);
			g.DrawImage(bg, 0, 0, bitmap.Width, bitmap.Height);

			return bitmap;
		}

		private void LoadCardImage()
		{
			if (this.ItemInfo.Card is null) return;

			this.CardImage = LoadCardImage(this.ItemInfo.Card.CardImage.GetUObject().GetImage(), this.ItemInfo.ItemGrade);
		}
		#endregion




		/// <summary>
		/// 载入数据
		/// </summary>
		private void LoadData()
		{
			#region 加载信息
			this.Text = $"[{ this.ItemInfo.ID }] { this.ItemInfo.ItemName }";

			this.ItemIcon.Image = this.ItemInfo.IconExtra;
			this.ItemNameCell.ItemGrade = this.ItemInfo.ItemGrade;
			this.ItemNameCell.TagImage = this.ItemInfo.TagIconGrade;
			this.lbl_Category.Text = $"Name.item.game-category-3.{ this.ItemInfo.GameCategory3.GetSignal() }".GetText(true);
			this.PricePreview.CurrencyCount = this.ItemInfo.Attributes["price"].ConvertToInt();
			this.ItemName = this.ItemInfo.ItemName;


			this.MainInfo = new List<MyInfo>()
			{
				new MyInfo(this.ItemInfo.MainInfo),
				new MyInfo(this.ItemInfo.IdentifyMainInfo),
			};

			this.SubInfo = new List<MyInfo>()
			{
				new MyInfo(this.ItemInfo.SubInfo),
				new MyInfo(this.ItemInfo.IdentifySubInfo),
			};

			this.LoadAbility();


			//潜力值
			if (this.ItemInfo.ContainsAttribute("hidden-power-attach", out string HiddenPower))
				this.LoadBottomControl("hidden-power-attach", "潜力" + HiddenPower, MyColor.Vital_LightYellow);

			//限制使用区域
			if (this.ItemInfo.ContainsAttribute("valid-attraction-name", out string ValidAttractionName))
				this.LoadBottomControl("valid-attraction-name", ValidAttractionName.GetText() + "专用");

			//显示职业信息
			var JobInfo = this.ItemInfo.JobInfo;
			if (JobInfo != null) this.LoadBottomControl("JobLimit", JobInfo + ", 专用");

			//加载交易信息
			this.LoadTrade();
			#endregion



			#region 载入提示工具 (按纵向顺序)
			this.LoadPreview(new ExchangePreview().LoadInfo(this.ItemInfo));
			this.LoadEffectInfo();

			//加载绿字部分信息
			this.LoadPreview(LoadDescription7(this.ItemInfo.Description7));
			this.LoadPreview(new SkillTooltipPreview().LoadInfo(this.ItemInfo));

			//加载套装信息
			this.LoadPreview(new SetItemPreview().LoadInfo(this.ItemInfo));

			//加载技能变更信息
			this.LoadPreview(new SkillByEquipmentTooltip().LoadInfo(this.ItemInfo.SkillByEquipment));

			//加载奖励信息
			this.LoadReward();

			//加载封印&解印信息
			this.LoadPreview(new SealPreview().LoadInfo(this.ItemInfo));

			//加载刻印书信息
			this.LoadPreview(new SlateScrollTooltip().LoadInfo(this.ItemInfo.SlateScroll));

			//加载描述4~6
			this.LoadPreview(LoadDescription(this.ItemInfo.Description4Title, this.ItemInfo.Description4));
			this.LoadPreview(LoadDescription(this.ItemInfo.Description5Title, this.ItemInfo.Description5));
			this.LoadPreview(LoadDescription(this.ItemInfo.Description6Title, this.ItemInfo.Description6));

			//加载描述信息
			this.LoadPreview(LoadDescription2(this.ItemInfo.Description2, this.ItemInfo.IdentifyDescription));

			//加载额外信息
			this.LoadPreview(this.LoadExtraInfo());

			//加载事件信息
			this.LoadPreview(new EventTimePreview().LoadInfo(this.ItemInfo.EventInfo));

			//加载可成长八卦牌属性信息
			this.AttributePreview.LoadInfo(this.ItemInfo);
			#endregion



			if (this.ItemInfo.Type == ItemType.Grocery)
			{
				#region 可用技能测试
				var Skill3Data = this.ItemInfo.Skill3;
				if (Skill3Data != null) System.Diagnostics.Trace.WriteLine($"发动技能 => { Skill3Data.Alias } ({ Skill3Data.NameText() })");
				#endregion

				if (this.ItemInfo.Card != null) this.LoadCardImage();
			}
		}
	}
}