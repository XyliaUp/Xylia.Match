﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xylia.Preview.Project.Controls.Enums;

namespace Xylia.Preview.Project.Core.Quest.Preview.SubGroup.Reward.RewardCell
{
	public partial class PriceBase : RewardCellBase
	{
		#region 初始化
		public PriceBase()
		{
			InitializeComponent();
		}
		#endregion


		#region 字段
		/// <summary>
		/// 货币数量
		/// </summary>
		public int CurrencyCount 
		{ 
			get => (int)this.priceCell1.CurrencyCount; 
			set => this.priceCell1.CurrencyCount = value; 
		}

		/// <summary>
		/// 货币类型
		/// </summary>
		public virtual CurrencyType CurrencyType 
		{ 
			get => this.priceCell1.CurrencyType; 
			set => this.priceCell1.CurrencyType = value;
		}
		#endregion
	}
}