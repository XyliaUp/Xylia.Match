namespace Xylia.Preview.Project.Core.Store
{
	partial class Searcher
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
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.Btn_StartMatch = new HZH_Controls.Controls.UCBtnExt();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.textBox1.Location = new System.Drawing.Point(31, 102);
			this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(400, 26);
			this.textBox1.TabIndex = 0;
			// 
			// Btn_StartMatch
			// 
			this.Btn_StartMatch.BtnBackColor = System.Drawing.Color.Empty;
			this.Btn_StartMatch.BtnFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.Btn_StartMatch.BtnForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.Btn_StartMatch.BtnText = "确定";
			this.Btn_StartMatch.ConerRadius = 8;
			this.Btn_StartMatch.Cursor = System.Windows.Forms.Cursors.Hand;
			this.Btn_StartMatch.DialogResult = System.Windows.Forms.DialogResult.None;
			this.Btn_StartMatch.EnabledMouseEffect = false;
			this.Btn_StartMatch.FillColor = System.Drawing.Color.White;
			this.Btn_StartMatch.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.Btn_StartMatch.IsRadius = true;
			this.Btn_StartMatch.IsShowRect = true;
			this.Btn_StartMatch.IsShowTips = false;
			this.Btn_StartMatch.Location = new System.Drawing.Point(341, 148);
			this.Btn_StartMatch.Margin = new System.Windows.Forms.Padding(0);
			this.Btn_StartMatch.Name = "Btn_StartMatch";
			this.Btn_StartMatch.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.Btn_StartMatch.RectWidth = 1;
			this.Btn_StartMatch.Size = new System.Drawing.Size(90, 38);
			this.Btn_StartMatch.TabIndex = 100;
			this.Btn_StartMatch.TabStop = false;
			this.Btn_StartMatch.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
			this.Btn_StartMatch.TipsText = "";
			this.Btn_StartMatch.BtnClick += new System.EventHandler(this.Btn_StartMatch_BtnClick);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.label1.Location = new System.Drawing.Point(27, 69);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(107, 20);
			this.label1.TabIndex = 101;
			this.label1.Text = "请输入筛选条件";
			// 
			// Searcher
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(472, 215);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.Btn_StartMatch);
			this.Controls.Add(this.textBox1);
			this.KeyPreview = true;
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.Name = "Searcher";
			this.Padding = new System.Windows.Forms.Padding(23, 85, 23, 28);
			this.Text = "筛选";
			this.Load += new System.EventHandler(this.Searcher_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Searcher_KeyDown);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private HZH_Controls.Controls.UCBtnExt Btn_StartMatch;
		public System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label1;
	}
}