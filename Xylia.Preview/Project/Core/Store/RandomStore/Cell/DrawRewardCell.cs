using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using Xylia.Preview.Data.Record;
using Xylia.Preview.Project.Core.Item.Cell.Basic;


namespace Xylia.Preview.Project.Core.RandomStore.Cell
{
	public partial class DrawRewardCell : UserControl
	{
		#region 构造
		public DrawRewardCell()
		{
			InitializeComponent();

			this.AutoSize = true;
			this.BackColor = Color.Transparent;
		}
		#endregion

		#region 字段
		private int m_DrawCount { get; set; } = 0;

		[Category("Data"), Description("需要开启次数")]
		public int DrawCount
		{
			get => m_DrawCount;
			set => this.label1.Text = (m_DrawCount = value) + "次";
		}
		#endregion


		#region 界面处理
		public void LoadData(RandomStoreDrawReward record)
		{
			#region 读取物品
			//读取需要开启次数
			this.DrawCount = record.RequiredDrawCount;

			List<ItemIconCell> RewardItems = new();
			for (int idx = 1; idx <= 8; idx++)
			{
				var FixedReward = GetRewardItem(record.Attributes["fixed-reward-" + idx], record.Attributes["fixed-reward-count-" + idx]);
				if (FixedReward != null)
				{
					FixedReward.Tag = "#fixed-reward";
					RewardItems.Add(FixedReward);
				}

				var OptionalReward = GetRewardItem(record.Attributes["optional-reward-" + idx], record.Attributes["optional-reward-count-" + idx]);
				if (OptionalReward != null)
				{
					OptionalReward.Tag = "#optional-reward";
					RewardItems.Add(OptionalReward);
				}
			}
			#endregion


			#region 界面处理
			//固定物品起始坐标
			const int StartLocX = 85;
			int LocX = StartLocX, LocY = 0;
			int Padding = 7;

			var Fixed = RewardItems.Where(item => (string)item.Tag == "#fixed-reward");
			if (Fixed.Any())
			{
				foreach (var o in Fixed)
				{
					o.Location = new Point(LocX, LocY);
					LocX = o.Right + Padding;
				}

				LocY += 65;
			}

			var Optional = RewardItems.Where(item => (string)item.Tag == "#optional-reward").ToArray();
			if (Optional.Any())
			{
				OptionTitle.Visible = true;
				OptionTitle.Location = new Point(StartLocX, LocY);

				for (int i = 0; i < Optional.Length; i++)
				{
					if (i % 4 == 0)
					{
						LocX = StartLocX;
						LocY = i == 0 ? OptionTitle.Bottom + 5 : LocY + 65;
					}

					var o = Optional[i];
					o.Location = new Point(LocX, LocY);
					LocX = o.Right + Padding;

				}
			}
			#endregion
		}


		private ItemIconCell GetRewardItem(string Item, string Count)
		{
			var ItemInfo = Item.GetItemInfo();
			if (ItemInfo is null) return null;

			byte.TryParse(Count, out byte _count);

			//物品图标
			var ItemIconCell = new ItemIconCell()
			{
				Scale = 45,
				StackCount = _count,
				ObjectRef = ItemInfo,
				ItemIcon = ItemInfo?.IconExtra,

				ShowStackCount = true,
				ShowStackCountOnlyOne = false,
			};

			this.Controls.Add(ItemIconCell);
			return ItemIconCell;
		}
		#endregion
	}
}
