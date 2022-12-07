namespace Xylia.Match.Windows.Forms
{
	partial class AboutUs
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutUs));
			this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
			this.UpdateLog = new MetroFramework.Controls.MetroTabPage();
			this.Panel1 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.metroTabControl1.SuspendLayout();
			this.UpdateLog.SuspendLayout();
			this.Panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// metroTabControl1
			// 
			this.metroTabControl1.Controls.Add(this.UpdateLog);
			this.metroTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.metroTabControl1.Location = new System.Drawing.Point(23, 85);
			this.metroTabControl1.Margin = new System.Windows.Forms.Padding(4);
			this.metroTabControl1.Name = "metroTabControl1";
			this.metroTabControl1.Padding = new System.Drawing.Point(6, 8);
			this.metroTabControl1.SelectedIndex = 0;
			this.metroTabControl1.Size = new System.Drawing.Size(730, 362);
			this.metroTabControl1.TabIndex = 2;
			// 
			// UpdateLog
			// 
			this.UpdateLog.AutoScroll = true;
			this.UpdateLog.Controls.Add(this.Panel1);
			this.UpdateLog.HorizontalScrollbar = true;
			this.UpdateLog.HorizontalScrollbarBarColor = true;
			this.UpdateLog.HorizontalScrollbarSize = 14;
			this.UpdateLog.Location = new System.Drawing.Point(4, 36);
			this.UpdateLog.Margin = new System.Windows.Forms.Padding(4);
			this.UpdateLog.Name = "UpdateLog";
			this.UpdateLog.Size = new System.Drawing.Size(722, 322);
			this.UpdateLog.TabIndex = 2;
			this.UpdateLog.Text = "更新日志";
			this.UpdateLog.VerticalScrollbar = true;
			this.UpdateLog.VerticalScrollbarBarColor = true;
			this.UpdateLog.VerticalScrollbarSize = 12;
			// 
			// Panel1
			// 
			this.Panel1.AutoScroll = true;
			this.Panel1.BackColor = System.Drawing.Color.Transparent;
			this.Panel1.Controls.Add(this.label1);
			this.Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Panel1.Location = new System.Drawing.Point(0, 0);
			this.Panel1.Margin = new System.Windows.Forms.Padding(4);
			this.Panel1.Name = "Panel1";
			this.Panel1.Size = new System.Drawing.Size(722, 322);
			this.Panel1.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(4, 0);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(106, 21);
			this.label1.TabIndex = 109;
			this.label1.Text = "文本信息区域";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.label2.Location = new System.Drawing.Point(598, 11);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(55, 21);
			this.label2.TabIndex = 3;
			this.label2.Text = "label2";
			// 
			// AboutUs
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(776, 475);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.metroTabControl1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "AboutUs";
			this.Padding = new System.Windows.Forms.Padding(23, 85, 23, 28);
			this.Style = MetroFramework.MetroColorStyle.Orange;
			this.Text = "关于";
			this.TransparencyKey = System.Drawing.Color.LightSkyBlue;
			this.Load += new System.EventHandler(this.ExpProject_Load);
			this.SizeChanged += new System.EventHandler(this.ExpProject_SizeChanged);
			this.metroTabControl1.ResumeLayout(false);
			this.UpdateLog.ResumeLayout(false);
			this.Panel1.ResumeLayout(false);
			this.Panel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private MetroFramework.Controls.MetroTabControl metroTabControl1;
		private MetroFramework.Controls.MetroTabPage UpdateLog;
		private System.Windows.Forms.Panel Panel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
	}
}