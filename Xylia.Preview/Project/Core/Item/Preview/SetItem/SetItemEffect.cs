using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Xylia.Preview.Project.Core.Item.Cell
{
	public partial class SetItemEffect : UserControl
	{
		#region 构造
		public SetItemEffect()
		{
			InitializeComponent();
			this.BackColor = Color.Transparent;
			this.PanelContent.AutoSize = true;
			this.PanelContent.ForeColor = Xylia.Drawing.Font.Util.GetFontStruct("UI.Label_Green03_12").Color;
		}
		#endregion

		#region 字段
		private int _count = 1;

		/// <summary>
		/// 套装数量设置
		/// </summary>
		[Category("Set"), Description("套装数量")]
		public int Count
		{
			get => _count;
			set
			{
				switch (_count = value)
				{
					case 2: this.CountTooltip.Image = Resources.BnsCommon_Old.tooltip_gem02_image; break;
					case 3: this.CountTooltip.Image = Resources.BnsCommon_Old.tooltip_gem03_image; break;
					case 4: this.CountTooltip.Image = Resources.BnsCommon_Old.tooltip_gem04_image; break;
					case 5: this.CountTooltip.Image = Resources.BnsCommon_Old.tooltip_gem05_image; break;
					case 6: this.CountTooltip.Image = Resources.BnsCommon_Old.tooltip_gem06_image; break;
					case 7: this.CountTooltip.Image = Resources.BnsCommon_Old.tooltip_gem07_image; break;
					case 8: this.CountTooltip.Image = Resources.BnsCommon_Old.tooltip_gem08_image; break;
					case 9: this.CountTooltip.Image = Resources.BnsCommon_Old.tooltip_gem09_image; break;
					case 10: this.CountTooltip.Image = Resources.BnsCommon_Old.tooltip_gem10_image; break;

					case 1 or _: this.CountTooltip.Image = Resources.BnsCommon_Old.tooltip_gem01_image; break;
				}
			}
		}



		/// <summary>
		/// 套装效果设置
		/// </summary>
		[Category("Set"), Description("套装效果")]
		public override string Text
		{
			get => this.PanelContent.Text;
			set
			{
				this.PanelContent.Text = value;
				this.Height = this.PanelContent.Height + 5;
			}
		}
		#endregion


		#region 方法
			//设置层宽度
			//int Width = this.Width - this.PanelContent.Location.X;
			//this.PanelContent.MaximumSize = new Size(Width, this.PanelContent.Height);
		#endregion
	}
}
