﻿
using Xylia.Preview.Project.Controls.Enums;

namespace Xylia.Preview.Project.Core.Quest.Preview.SubGroup.Reward.RewardCell
{
	/// <summary>
	/// 钱币
	/// </summary>
	public sealed partial class Money : PriceBase
	{
		#region 构造
		public Money()
		{
			InitializeComponent();
		}
		#endregion


		#region 字段
		public override CurrencyType CurrencyType => CurrencyType.Money;

		public static string ConvertInfo(long Money)
		{
			var Amount3 = Money % 10000 % 100;
			var Amount2 = Money % 10000 - Amount3;
			var Amount1 = Money - Amount2 - Amount3;

			return $"{Amount1 / 10000}金 {Amount2 / 100}银 {Amount3}铜";
		}
		#endregion
	}
}