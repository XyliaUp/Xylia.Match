using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;

using Xylia.Preview.Common.Cast;
using Xylia.Preview.Data.Record;
using Xylia.Preview.Common.Interface;
using Xylia.Preview.Project.Controls.PanelEx;
using Xylia.Preview.Project.Core.Item.Cell;
using Xylia.Preview.Project.Core.Item.Cell.Basic;

using ItemData = Xylia.Preview.Data.Record.Item;

namespace Xylia.Preview.Project.Core.Item
{
	public partial class ExchangePreview : PreviewControl, IPreview
	{
		#region 构造
		public ExchangePreview()
		{
			this.InitializeComponent();
		}
		#endregion


		#region 接口方法
		bool Valid = false;

		bool IPreview.INVALID() => !Valid;

		void IPreview.LoadData(IRecord record)
		{
			var Item = record as ItemData;

			int PosY = 0;
			var CrystallRules = new List<ItemExchange>();

			#region 查询当前物品为加工目标物品 
			var CrystallFrom = ItemExchange.LoadNormalItem(Item.Alias);

			//对于加工来源，需要限制加载类型
			var temp = CrystallFrom.Where(rule => rule.ruleUsage == ItemExchange.RuleUsage.Crystallization);
			CrystallRules.AddRange(temp);

			if (temp.Any())
			{
				this.ProcessMaterialTitle.Visible = true;
				this.ProcessMaterialTitle.Location = new Point(0, PosY);
				PosY = this.ProcessMaterialTitle.Bottom;

				foreach (var rule in temp)
				{
					void LoadObject(IRecord data)
					{
						ItemShowCell itemShowCell = null;

						if (data is null) return;
						else if (data is ItemData info) itemShowCell = new ItemShowCell(info, false);
						else itemShowCell = new ItemShowCell();

						this.Controls.Add(itemShowCell);
						itemShowCell.Location = new Point(5, PosY);

						PosY = itemShowCell.Bottom;
					}

					LoadObject(rule.RequiredItem1?.GetObject());
					LoadObject(rule.RequiredItem2?.GetObject());
					LoadObject(rule.RequiredItem3?.GetObject());
					LoadObject(rule.RequiredItem4?.GetObject());
				}
			}
			#endregion

			#region 查询当前物品为加工起始物品
			var CrystallTo = ItemExchange.LoadRequiredItem(Item.Alias, Item.Brand);
			if (CrystallTo.Any())
			{
				CrystallRules.AddRange(CrystallTo);

				LoadCrystallTo(CrystallTo.Where(rule => rule.ruleUsage == ItemExchange.RuleUsage.Crystallization), ref PosY, "加工品");
				LoadCrystallTo(CrystallTo.Where(rule => rule.ruleUsage == ItemExchange.RuleUsage.AntiqueExchange), ref PosY, "旧物交换");
			}
			#endregion


			#region 生成兑换关系
			this.Valid = CrystallRules.Any();
			if (!this.Valid) return;

			ProcessComparison.Location = new Point(0, PosY);
			PosY += ProcessComparison.Height + 2;

			CrystallRules.ForEach(rule =>
			{
				var CrystallizationCell = new ProcessComparisonCell(rule);

				this.Controls.Add(CrystallizationCell);
				CrystallizationCell.Location = new Point(5, PosY);

				PosY += CrystallizationCell.Height;
			});

			this.Height = PosY + 5;
			#endregion
		}
		#endregion


		#region 方法
		public void LoadCrystallTo(IEnumerable<ItemExchange> Rule, ref int PosY, string Title)
		{
			//校验是否存在内容
			if (!Rule.Any()) return;


			var TitlePanel = new TitlePanel()
			{
				Title = Title,
				AutoSize = true,
				Location = new Point(0, PosY),
			};
			this.Controls.Add(TitlePanel);

			int PosY2 = 21;
			foreach (var rule in Rule)
			{
				int PosX2 = 5;

				void LoadObject(ItemData data)
				{
					if (data is null) return;

					var itemShowCell = new ItemShowCell(data, false);
					itemShowCell.Location = new Point(PosX2, PosY2);

					TitlePanel.Controls.Add(itemShowCell);

					PosX2 = itemShowCell.Right + 10;
				}

				LoadObject(rule.NormalItem1?.GetItemInfo());
				LoadObject(rule.NormalItem2?.GetItemInfo());
				LoadObject(rule.NormalItem3?.GetItemInfo());
				LoadObject(rule.NormalItem4?.GetItemInfo());

				PosY2 += 56;
			}

			PosY = TitlePanel.Bottom;
		}
		#endregion
	}


	/// <summary>
	/// 控件信息
	/// </summary>
	public class ExchangeControlInfo
	{
		/// <summary>
		/// 标题控件
		/// </summary>
		public TitlePanel ParentControl;

		/// <summary>
		/// 渲染起始位置
		/// </summary>
		public int Top = 0;
	}
}
