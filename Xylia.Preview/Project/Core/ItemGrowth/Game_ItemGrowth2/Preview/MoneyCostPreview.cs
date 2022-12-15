using System.Drawing;
using System.Windows.Forms;

using Xylia.Extension;

namespace Xylia.Preview.Project.Core.ItemGrowth.ItemGrowth2.Preview
{
	public partial class MoneyCostPreview : UserControl
	{
		public MoneyCostPreview()
		{
			InitializeComponent();

			this.priceCell2.SetToolTip($"应用中的折扣率 { 1 - DiscountRate:P0}");
		}

		#region 字段
		/// <summary>
		/// 折扣率
		/// </summary>
		public float DiscountRate = 0.75F;

		public int MoneyCost
		{
			get => this.priceCell1.CurrencyCount;
			set
			{
				//计算优惠价格
				this.priceCell1.CurrencyCount = value;
				this.priceCell2.CurrencyCount = (int)(value * DiscountRate);

				MoneyCostPreview_SizeChanged(null, null);
			}
		}
		#endregion

		private void MoneyCostPreview_SizeChanged(object sender, System.EventArgs e)
		{
			this.priceCell1.Location = new Point(this.Width - this.priceCell1.Width, this.priceCell1.Location.Y);
			this.priceCell2.Location = new Point(this.Width - this.priceCell2.Width, this.priceCell2.Location.Y);
		}
	}
}
