namespace Xylia.Match.Windows
{
	partial class QuestSelect
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
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.textBoxEx1 = new HZH_Controls.Controls.TextBoxEx();
			this.SuspendLayout();
			// 
			// listBox1
			// 
			this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.listBox1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.listBox1.FormattingEnabled = true;
			this.listBox1.ItemHeight = 32;
			this.listBox1.Location = new System.Drawing.Point(23, 85);
			this.listBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(759, 536);
			this.listBox1.TabIndex = 1;
			this.listBox1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ListBox1_DrawItem);
			this.listBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListBox1_MouseDoubleClick);
			// 
			// textBoxEx1
			// 
			this.textBoxEx1.DecLength = 2;
			this.textBoxEx1.InputType = HZH_Controls.TextInputType.NotControl;
			this.textBoxEx1.Location = new System.Drawing.Point(376, 44);
			this.textBoxEx1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.textBoxEx1.MaxValue = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.textBoxEx1.MinValue = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
			this.textBoxEx1.MyRectangle = new System.Drawing.Rectangle(0, 0, 0, 0);
			this.textBoxEx1.Name = "textBoxEx1";
			this.textBoxEx1.OldText = null;
			this.textBoxEx1.PromptColor = System.Drawing.Color.Gray;
			this.textBoxEx1.PromptFont = new System.Drawing.Font("Microsoft YaHei UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.textBoxEx1.PromptText = "";
			this.textBoxEx1.RegexPattern = "";
			this.textBoxEx1.Size = new System.Drawing.Size(255, 23);
			this.textBoxEx1.TabIndex = 4;
			this.textBoxEx1.Visible = false;
			this.textBoxEx1.TextChanged += new System.EventHandler(this.textBoxEx1_TextChanged);
			// 
			// QuestSelect
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(805, 649);
			this.Controls.Add(this.textBoxEx1);
			this.Controls.Add(this.listBox1);
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.Name = "QuestSelect";
			this.Padding = new System.Windows.Forms.Padding(23, 85, 23, 28);
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "任务列表";
			this.TextChanged += new System.EventHandler(this.QuestSelect_TextChanged);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox listBox1;
		private HZH_Controls.Controls.TextBoxEx textBoxEx1;
	}
}