namespace Xylia.Preview.Project.Core.Quest.Preview.SubGroup
{
	partial class CaseInfoPanel
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CaseInfoPanel));
			this.label1 = new System.Windows.Forms.Label();
			this.contentPanel1 = new Xylia.Preview.Project.Controls.ContentPanel();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(27, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(20, 22);
			this.label1.TabIndex = 0;
			this.label1.Text = "◆";
			// 
			// contentPanel1
			// 
			this.contentPanel1.BackColor = System.Drawing.Color.Transparent;
			this.contentPanel1.BasicLineHeight = 25;
			this.contentPanel1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.contentPanel1.ForeColor = System.Drawing.Color.White;
			this.contentPanel1.Location = new System.Drawing.Point(46, 0);
			this.contentPanel1.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
			this.contentPanel1.Name = "contentPanel1";
			this.contentPanel1.TabIndex = 1;
			this.contentPanel1.Text = "contentPanel1";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(0, -1);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(26, 26);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 2;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Visible = false;
			this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
			// 
			// CaseInfoPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = System.Drawing.Color.Transparent;
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.contentPanel1);
			this.Name = "CaseInfoPanel";
			this.Size = new System.Drawing.Size(149, 30);
			this.Load += new System.EventHandler(this.CaseInfoPanel_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private Controls.ContentPanel contentPanel1;
		private System.Windows.Forms.PictureBox pictureBox1;
	}
}
