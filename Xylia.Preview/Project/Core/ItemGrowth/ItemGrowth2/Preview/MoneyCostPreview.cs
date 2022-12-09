using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xylia.Preview.Project.Core.ItemGrowth.Preview
{
	public partial class MoneyCostPreview : UserControl
	{
		public MoneyCostPreview()
		{
			InitializeComponent();

			this.BackColor = Color.Transparent;
			this.AutoSize = false;

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
				this.priceCell1.CurrencyCount = value;

				//计算优惠价格
				this.priceCell2.CurrencyCount = (int)(value * DiscountRate);

				this.Refresh();
			}
		}

		public override Size MaximumSize
		{
			get => base.MaximumSize;
			set
			{
				base.MaximumSize = value;
				this.Width = value.Width;

				this.Refresh();
			}
		}
		#endregion

		#region 方法
		public override void Refresh()
		{
			//如果宽度为空，则设置默认宽度
			if (this.Width == 0) this.Width = Math.Max(this.label2.Width + priceCell1.Width, this.label1.Width + priceCell2.Width) + 20;

			this.priceCell1.Location = new Point(this.Width - this.priceCell1.Width, this.priceCell1.Location.Y);
			this.priceCell2.Location = new Point(this.Width - this.priceCell2.Width, this.priceCell2.Location.Y);
		}

		private void MoneyCostPreview_SizeChanged(object sender, EventArgs e)
		{
			this.Refresh();
		}
		#endregion
	}
}
