﻿using Xylia.Preview.Project.Controls.PanelEx;
using Xylia.Preview.Project.Controls;


namespace Xylia.Preview.Project.Core.ItemGrowth.Preview
{
	partial class WarningPreview
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WarningPreview));
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.panelContent1 = new ContentPanel();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox2
			// 
			this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
			this.pictureBox2.Location = new System.Drawing.Point(0, -1);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(35, 32);
			this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox2.TabIndex = 20;
			this.pictureBox2.TabStop = false;
			// 
			// panelContent1
			// 
			this.panelContent1.AutoSize = true;
			this.panelContent1.BackColor = System.Drawing.Color.Transparent;
			this.panelContent1.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F);
			this.panelContent1.ForeColor = System.Drawing.Color.White;
			this.panelContent1.Location = new System.Drawing.Point(46, 5);
			this.panelContent1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.panelContent1.Name = "panelContent1";
			this.panelContent1.TabIndex = 19;
			this.panelContent1.Text = "123";
			// 
			// WarningPreview
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.BackColor = System.Drawing.Color.Black;
			this.Controls.Add(this.panelContent1);
			this.Controls.Add(this.pictureBox2);
			this.Name = "WarningPreview";
			this.Size = new System.Drawing.Size(78, 34);
		//	this.SizeChanged += new System.EventHandler(this.WarningPreview_SizeChanged);
			this.Resize += new System.EventHandler(this.WarningPreview_Resize);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private ContentPanel panelContent1;
		private System.Windows.Forms.PictureBox pictureBox2;
	}
}
