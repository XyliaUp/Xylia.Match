using Xylia.Preview.Project.Controls;

namespace Xylia.Preview
{
    partial class DebugFrm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.contentPanel1 = new Xylia.Preview.Project.Controls.ContentPanel();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(12, 92);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(270, 23);
			this.textBox1.TabIndex = 0;
			this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// contentPanel1
			// 
			this.contentPanel1.BackColor = System.Drawing.Color.Transparent;
			this.contentPanel1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.contentPanel1.ForeColor = System.Drawing.Color.White;
			this.contentPanel1.Location = new System.Drawing.Point(352, 279);
			this.contentPanel1.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
			this.contentPanel1.Name = "contentPanel1";
			this.contentPanel1.TabIndex = 1;
			this.contentPanel1.Text = "<font name=\"00008130.ItemGrowth_Awaken_28\">传授</font>";
			// 
			// DebugFrm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.AutoSize = true;
			this.BackColor = System.Drawing.Color.Black;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(813, 442);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.contentPanel1);
			this.DoubleBuffered = true;
			this.ForeColor = System.Drawing.Color.DimGray;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MaximumSize = new System.Drawing.Size(2147483647, 850);
			this.Name = "DebugFrm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "调试窗口";
			this.Load += new System.EventHandler(this.DebugFrm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }


		#endregion

		private System.Windows.Forms.TextBox textBox1;
		private ContentPanel contentPanel1;
	}
}

