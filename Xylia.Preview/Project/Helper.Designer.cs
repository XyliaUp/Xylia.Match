namespace Xylia.Preview.Project.Core.Item
{
	partial class Helper
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Helper));
			this.label1 = new System.Windows.Forms.Label();
			this.BackGround = new System.Windows.Forms.Panel();
			this.BackGround.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoEllipsis = true;
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(596, 552);
			this.label1.TabIndex = 108;
			this.label1.Text = resources.GetString("label1.Text");
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// BackGround
			// 
			this.BackGround.AutoScroll = true;
			this.BackGround.AutoSize = true;
			this.BackGround.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackGround.Controls.Add(this.label1);
			this.BackGround.Dock = System.Windows.Forms.DockStyle.Fill;
			this.BackGround.Location = new System.Drawing.Point(0, 0);
			this.BackGround.Name = "BackGround";
			this.BackGround.Size = new System.Drawing.Size(596, 554);
			this.BackGround.TabIndex = 109;
			// 
			// Helper
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(21)))));
			this.ClientSize = new System.Drawing.Size(596, 554);
			this.Controls.Add(this.BackGround);
			this.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.ForeColor = System.Drawing.SystemColors.ControlText;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Name = "Helper";
			this.Text = "物品预览功能帮助页面";
			this.Load += new System.EventHandler(this.Helper_Load);
			this.BackGround.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel BackGround;
	}
}
