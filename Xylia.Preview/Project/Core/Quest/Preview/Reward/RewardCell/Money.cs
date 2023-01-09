﻿using Xylia.Preview.Project.Controls.Currency;

namespace Xylia.Preview.Project.Core.Quest.Preview.Reward.RewardCell
{
	/// <summary>
	/// 钱币
	/// </summary>
	public sealed partial class Money : PriceBase
	{
		#region 字段
		public Money() => InitializeComponent();

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
