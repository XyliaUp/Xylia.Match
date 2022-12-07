using System;
using System.Drawing;
using System.Windows.Forms;

using Xylia.Attribute.Component;
using Xylia.Extension;
using Xylia.Preview.Data.Record;

namespace Xylia.Preview.Project.Core.ItemGrowth.Preview
{
	public partial class WarningPreview : UserControl
	{
		#region 构造
		public WarningPreview()
		{
			InitializeComponent();

			this.BackColor = Color.Transparent;
			this.AutoSize = false;

			this.Refresh();
		}
		#endregion


		#region 字段
		private ItemTransformRecipe.Warning m_Type;

		public ItemTransformRecipe.Warning Type
		{
			get => this.m_Type;
			set
			{
				this.m_Type = value;

				if (value == ItemTransformRecipe.Warning.None) this.Text = null;
				else this.Text = $"Transform.Warning.{value.GetAttribute<Signal>()?.Description ?? value.ToString()}".GetText();
			}
		}

		public override string Text
		{
			get => this.panelContent1.Text;
			set
			{
				this.panelContent1.Text = value;
				this.Visible = !value.IsNull();

				this.Refresh();
			}
		}
		#endregion

		#region 方法

		#endregion

		#region 重写方法
		private void WarningPreview_Resize(object sender, EventArgs e)
		{
		//	this.Refresh();
		}

		public override void Refresh()
		{
			this.panelContent1.Width = this.Width - this.panelContent1.Left - 10;
			this.pictureBox2.Location = new Point(this.pictureBox2.Location.X, Math.Max(0, (this.panelContent1.Bottom - this.pictureBox2.Height)) / 2);

			this.Height =  this.panelContent1.Bottom;
		}
		#endregion
	}
}
