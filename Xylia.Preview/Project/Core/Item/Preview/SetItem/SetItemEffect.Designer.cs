using Xylia.Preview.Project.Controls.PanelEx;
using Xylia.Preview.Project.Controls;

namespace Xylia.Preview.Project.Core.Item.Cell
{
	partial class SetItemEffect
	{
		/// <summary> 
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region 组件设计器生成的代码

		/// <summary> 
		/// 设计器支持所需的方法 - 不要修改
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetItemEffect));
			this.CountTooltip = new System.Windows.Forms.PictureBox();
			this.PanelContent = new ContentPanel();
			((System.ComponentModel.ISupportInitialize)(this.CountTooltip)).BeginInit();
			this.SuspendLayout();
			// 
			// CountTooltip
			// 
			this.CountTooltip.Image = ((System.Drawing.Image)(resources.GetObject("CountTooltip.Image")));
			this.CountTooltip.Location = new System.Drawing.Point(1, 1);
			this.CountTooltip.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.CountTooltip.Name = "CountTooltip";
			this.CountTooltip.Size = new System.Drawing.Size(26, 20);
			this.CountTooltip.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.CountTooltip.TabIndex = 0;
			this.CountTooltip.TabStop = false;
			// 
			// PanelContent
			// 
			this.PanelContent.BackColor = System.Drawing.Color.Transparent;
			this.PanelContent.BasicLineHeight = 20;
			this.PanelContent.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.PanelContent.ForeColor = System.Drawing.Color.White;
			this.PanelContent.Location = new System.Drawing.Point(33, 0);
			this.PanelContent.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
			this.PanelContent.MaximumSize = new System.Drawing.Size(400, 99999);
			this.PanelContent.Name = "PanelContent";
			this.PanelContent.TabIndex = 1;
			this.PanelContent.Text = "PanelContent";
			// 
			// SetItemEffect
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = System.Drawing.Color.Transparent;
			this.Controls.Add(this.PanelContent);
			this.Controls.Add(this.CountTooltip);
			this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "SetItemEffect";
			this.Size = new System.Drawing.Size(131, 26);
			//this.SizeChanged += new System.EventHandler(this.SetCell_SizeChanged);
			((System.ComponentModel.ISupportInitialize)(this.CountTooltip)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox CountTooltip;
		private ContentPanel PanelContent;
	}
}
