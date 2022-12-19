namespace Xylia.Match.GUI
{
	partial class Epic
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
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.TreeView = new Xylia.Windows.Controls.TreeView();
			this.SuspendLayout();
			// 
			// richTextBox1
			// 
			this.richTextBox1.BackColor = System.Drawing.Color.White;
			this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Right;
			this.richTextBox1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.richTextBox1.Location = new System.Drawing.Point(312, 85);
			this.richTextBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.ReadOnly = true;
			this.richTextBox1.Size = new System.Drawing.Size(485, 550);
			this.richTextBox1.TabIndex = 1;
			this.richTextBox1.Text = "";
			this.richTextBox1.ZoomFactor = 1.2F;
			this.richTextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Epic_KeyDown);
			// 
			// TreeView
			// 
			this.TreeView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(251)))), ((int)(((byte)(244)))));
			this.TreeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.TreeView.Dock = System.Windows.Forms.DockStyle.Left;
			this.TreeView.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
			this.TreeView.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.TreeView.HotTracking = true;
			this.TreeView.Indent = 20;
			this.TreeView.ItemHeight = 30;
			this.TreeView.Location = new System.Drawing.Point(23, 85);
			this.TreeView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.TreeView.Name = "TreeView";
			this.TreeView.ShowLines = false;
			this.TreeView.Size = new System.Drawing.Size(281, 550);
			this.TreeView.TabIndex = 2;
			this.TreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView2_AfterSelect_1);
			// 
			// Epic
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(820, 663);
			this.Controls.Add(this.TreeView);
			this.Controls.Add(this.richTextBox1);
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.Name = "Epic";
			this.Padding = new System.Windows.Forms.Padding(23, 85, 23, 28);
			this.Text = "前世红尘";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Epic_FormClosing);
			this.Load += new System.EventHandler(this.Epic_Load);
			this.Shown += new System.EventHandler(this.Epic_Shown);
			this.SizeChanged += new System.EventHandler(this.Epic_SizeChanged);
			this.TextChanged += new System.EventHandler(this.Epic_TextChanged);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Epic_KeyDown);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.RichTextBox richTextBox1;
		private Xylia.Windows.Controls.TreeView TreeView;
	}
}