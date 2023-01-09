using Xylia.Preview.Project.Controls.Currency;

namespace Xylia.Preview.Project.Core.Quest.Preview.Reward.RewardCell
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
