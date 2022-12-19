using System.Collections.Generic;
using System.Drawing;
using System.Linq;

using Xylia.Extension;
using Xylia.Preview.Common.Cast;
using Xylia.Preview.Common.Interface;
using Xylia.Preview.Data.Record;
using Xylia.Preview.Project.Controls.Currency;
using Xylia.Preview.Project.Core.Item.Cell.Basic;
using Xylia.Preview.Project.Core.Quest.Preview.SubGroup.Reward.QuestBonusReward;
using Xylia.Preview.Project.Core.Quest.Preview.SubGroup.Reward.RewardCell;

using QuestData = Xylia.bns.Modules.Quest.Entities.Quest;


namespace Xylia.Preview.Project.Core.Quest.Preview.SubGroup
{
	/// <summary>
	/// 任务奖励界面
	/// </summary>
	public partial class RewardInfo : GroupBase
	{
		#region 构造
		readonly FixedItem FixedCommon = new();
		readonly OptionaItem OptionalCommon = new();
		readonly FixedItem Fixed = new() { Visible = false };
		readonly OptionaItem Optional = new() { Visible = false };
		List<RewardCellBase> RewardCells;

		private Dictionary<string, QuestRewardGroup> QuestRewardGroups = new();

		public RewardInfo()
		{
			InitializeComponent();

			this.BackColor = Color.Transparent;

			//添加控件
			this.Controls.Add(FixedCommon);
			this.Controls.Add(OptionalCommon);
			this.Controls.Add(Fixed);
			this.Controls.Add(Optional);
		}
		#endregion

		#region 字段
		public void LoadData(QuestData Quest)
		{
			List<QuestReward> Rewards = new();

			var MissionStep = Quest.MissionSteps.Value.SelectMany(s => s.Missions).Where(step => step.Reward1 != null || step.Reward2 != null);
			if (MissionStep.Any())
			{
				foreach (var step in MissionStep)
				{
					var Reward1 = FileCache.Data.QuestReward[step.Reward1];
					var Reward2 = FileCache.Data.QuestReward[step.Reward2];

					if (Reward1 != null)
					{
						Reward1.Step = step.id;
						Rewards.Add(Reward1);
					}

					if (Reward2 != null)
					{
						Reward2.Step = step.id;
						Rewards.Add(Reward2);
					}
				}
			}

			if (Rewards.Count == 0) this.Visible = false;
			else
			{
				QuestReward = Rewards.Last();
				System.Diagnostics.Trace.WriteLine("绑定的任务奖励数量: " + Rewards.Count);
			}

			//载入追加奖励信息
			var QuestBonusRewardSetting = FileCache.Data.QuestBonusRewardSetting.Where(o => int.TryParse(o.Quest, out var QuestID) ? QuestID == Quest.id : o.Quest == Quest.Alias);
			if (QuestBonusRewardSetting.Any())
			{
				this.GroupText += " (当前任务包含特别奖励，尚未支持处理)";

				var preview = new QuestBonusRewardPreview();
				preview.LoadData(QuestBonusRewardSetting);
			}
		}

		/// <summary>
		/// 任务奖励
		/// </summary>
		public QuestReward QuestReward
		{
			set
			{
				if (value is null)
				{
					//没有奖励内容时，隐藏界面
					this.Visible = false;
					return;
				}


				#region 固定奖励内容
				//加载货币类型奖励信息
				var FixedCommonObjs = new List<ItemIconCell>();

				for (int i = 1; i <= 4; i++)
				{
					if (value.ContainsAttribute($"fixed-skill3-{i}", out string AttrVal))
					{
						var SkillInfo = FileCache.Data.Skill3[AttrVal];
						if (SkillInfo is null) continue;

						FixedCommonObjs.Add(new ItemIconCell()
						{
							Image = SkillInfo.MainIcon(),
						});
					}
				}

				for (int i = 1; i <= 4; i++)
				{
					if (value.ContainsAttribute($"fixed-common-slot-{i}", out string AttrVal))
						FixedCommonObjs.AddItem(GetItem(AttrVal, value.Attributes[$"fixed-common-item-count-{i}"]));
				}


				FixedCommon.Items = FixedCommonObjs;

				foreach (var f in value.Fixeds)
				{
					var Name = f.GroupName ?? f.Group;

					QuestRewardGroups.Add(Name, f);
					RewardSelect.Source.Add(Name);
				}
				#endregion

				#region 随机奖励内容
				//加载货币类型奖励信息
				var OptionalCommonObjs = new List<ItemIconCell>();
				for (int i = 1; i <= 4; i++)
				{
					if (value.ContainsAttribute($"optional-common-slot-{i}", out string AttrVal))
						OptionalCommonObjs.AddItem(GetItem(AttrVal, value.Attributes[$"optional-common-item-count-{i}"]));
				}

				OptionalCommon.Items = OptionalCommonObjs;

				foreach (var f in value.Optionals)
				{
					var Name = f.GroupName ?? f.Group;

					if (!QuestRewardGroups.ContainsKey(Name))
						RewardSelect.Source.Add(Name);

					QuestRewardGroups.Add(Name + "#optional", f);
				}
				#endregion

				#region 货币型奖励
				//加载货币类型奖励信息
				this.RewardCells = new List<RewardCellBase>();

				#region 钱币
				if (value.BasicMoney != 0)
				{
					var MoneyElement = new Money()
					{
						CurrencyType = CurrencyType.Money,
						CurrencyCount = value.BasicMoney,
					};

					int Ratio = 30;
					MoneyElement.SetToolTip($"此为基础金币，应用{Ratio}%增益后为 {Money.ConvertInfo((long)(value.BasicMoney * (1 + (double)Ratio / 100)))}");
					RewardCells.Add(MoneyElement);
				}
				#endregion

				#region 经验
				if (value.BasicExp != 0)
				{
					RewardCells.Add(new HonorExp()
					{
						Title = "经验值",
						Text = value.BasicExp.ToString(),
					});
				}
				#endregion

				#region 声望
				if (value.BasicAccountExp != 0)
				{
					RewardCells.Add(new HonorExp()
					{
						Text = value.BasicAccountExp.ToString(),
					});
				}
				#endregion

				#region 仙豆
				if (value.BasicDuelPoint != 0)
				{
					RewardCells.Add(new PriceBase()
					{
						Title = "仙豆",
						CurrencyType = CurrencyType.DuelPoint,
						CurrencyCount = value.BasicDuelPoint,
					});
				}
				#endregion

				#region 龙果
				if (value.BasicPartyBattlePoint != 0)
				{
					RewardCells.Add(new PriceBase()
					{
						Title = "龙果",
						CurrencyType = CurrencyType.PartyBattlePoint,
						CurrencyCount = value.BasicPartyBattlePoint,
					});
				}
				#endregion

				#region 仙桃
				if (value.BasicFieldPlayPoint != 0)
				{
					RewardCells.Add(new PriceBase()
					{
						Title = "仙桃",
						CurrencyType = CurrencyType.FieldPlayPoint,
						CurrencyCount = value.BasicFieldPlayPoint,
					});
				}
				#endregion

				#region 势力贡献度
				if (value.BasicFieldPlayPoint != 0)
				{
					RewardCells.Add(new RewardCellBase()
					{
						Title = "势力贡献度",
						Text = value.BasicFieldPlayPoint.ToString(),
					});
				}
				#endregion

				#region 信誉度
				if (value.BasicProductionExp != 0)
				{
					RewardCells.Add(new RewardCellBase()
					{
						Title = "信誉度",
						Text = value.BasicProductionExp.ToString(),
					});
				}
				#endregion
				#endregion



				#region 封魔录奖励
				if (value.ContainsAttribute("sealed-dungeon-reward", out string tmp) && int.TryParse(tmp, out var SealedDungeonReward))
				{
					foreach (var reward in FileCache.Data.QuestSealedDungeonReward.Where(o => o.ID == SealedDungeonReward))
					{
						var Name = reward.Level + "层";

						QuestRewardGroups.Add(Name, new QuestRewardGroup()
						{
							Slot1 = "item:" + reward.RewardItem1,
							Slot2 = "item:" + reward.RewardItem2,
							Slot3 = "item:" + reward.RewardItem3,
							Slot4 = "item:" + reward.RewardItem4,

							ItemCount1 = reward.RewardItemCount1,
							ItemCount2 = reward.RewardItemCount2,
							ItemCount3 = reward.RewardItemCount3,
							ItemCount4 = reward.RewardItemCount4,
						});

						RewardSelect.Source.Add(Name);
					}
				}
				#endregion



				#region 最后处理
				if (RewardSelect.Source.Count == 0)
				{
					RewardSelect.Visible = false;
					this.Refresh();
				}
				else
				{
					RewardSelect.Visible = true;
					RewardSelect.SelectedIndex = 0;
				}
				#endregion
			}
		}
		#endregion


		#region 方法
		private void RewardSelect_SelectedChangedEvent(object sender, System.EventArgs e)
		{
			//获取主键
			var Key = this.RewardSelect.TextValue;

			this.Fixed.Items = QuestRewardGroups.ContainsKey(Key) ? GetItem(QuestRewardGroups[Key]) : null;
			this.Optional.Items = QuestRewardGroups.ContainsKey(Key + "#optional") ? GetItem(QuestRewardGroups[Key + "#optional"]) : null;

			this.Refresh();
		}

		/// <summary>
		/// 获取物品图标信息
		/// </summary>
		/// <param name="AliasInfo"></param>
		/// <param name="StackCount"></param>
		/// <returns></returns>
		private static ItemIconCell GetItem(string AliasInfo, int StackCount)
		{
			var Obj = AliasInfo.CastObject();
			if (Obj is null || Obj is not IPicture o) return null;

			return new ItemIconCell()
			{
				ShowStackCount = true,
				StackCount = StackCount,

				ObjectRef = Obj,
				Image = o.MainIcon(),
			};
		}

		private static ItemIconCell GetItem(string AliasInfo, string StackCount) => GetItem(AliasInfo, StackCount.ToIntWithNull() ?? 1);

		private static List<ItemIconCell> GetItem(QuestRewardGroup group)
		{
			//获取物品信息
			var items = new List<ItemIconCell>();
			items.AddItem(GetItem(group.Slot1, group.ItemCount1));
			items.AddItem(GetItem(group.Slot2, group.ItemCount2));
			items.AddItem(GetItem(group.Slot3, group.ItemCount3));
			items.AddItem(GetItem(group.Slot4, group.ItemCount4));

			return items;
		}

		public override void Refresh()
		{
			this.SuspendLayout();

			int ContentY = 40;

			void RefreshItems(FixedItem c)
			{
				if (c.Items != null && c.Items.Any())
				{
					c.Location = new Point(ContentStartX, ContentY);
					ContentY = c.Bottom + 10;
				}
			}

			RefreshItems(FixedCommon);
			RefreshItems(Fixed);
			RefreshItems(OptionalCommon);
			RefreshItems(Optional);



			if (RewardCells != null)
			{
				ContentY += 5;

				foreach (var cell in RewardCells)
				{
					if (!this.Controls.Contains(cell))
						this.Controls.Add(cell);

					cell.Location = new Point(ContentStartX, ContentY);
					ContentY = cell.Bottom;
				}
			}

			base.Refresh();
			this.ResumeLayout();
		}
		#endregion
	}
}
