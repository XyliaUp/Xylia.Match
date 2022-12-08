namespace Xylia.Preview.Project.RunForm
{
	partial class ChallengeListFrm
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChallengeListFrm));
			this.MenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.OutputList = new System.Windows.Forms.ToolStripMenuItem();
			this.ModifyFilterRule = new System.Windows.Forms.ToolStripMenuItem();
			this.CancelFilter = new System.Windows.Forms.ToolStripMenuItem();
			this.label1 = new System.Windows.Forms.Label();
			this.DaySelect = new HZH_Controls.Controls.UCCombox();
			this.MenuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// MenuStrip
			// 
			this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OutputList});
			this.MenuStrip.Name = "Menu";
			this.MenuStrip.Size = new System.Drawing.Size(149, 26);
			// 
			// OutputList
			// 
			this.OutputList.Name = "OutputList";
			this.OutputList.Size = new System.Drawing.Size(148, 22);
			this.OutputList.Text = "输出挑战任务";
			this.OutputList.Click += new System.EventHandler(this.OutputList_Click);
			// 
			// ModifyFilterRule
			// 
			this.ModifyFilterRule.Name = "ModifyFilterRule";
			this.ModifyFilterRule.Size = new System.Drawing.Size(32, 19);
			// 
			// CancelFilter
			// 
			this.CancelFilter.Name = "CancelFilter";
			this.CancelFilter.Size = new System.Drawing.Size(32, 19);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(38, 108);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 17);
			this.label1.TabIndex = 1;
			this.label1.Text = "挑战任务";
			// 
			// DaySelect
			// 
			this.DaySelect.BackColor = System.Drawing.Color.Sienna;
			this.DaySelect.BoxStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.DaySelect.ConerRadius = 10;
			this.DaySelect.DropPanelHeight = -1;
			this.DaySelect.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.DaySelect.ForeColor = System.Drawing.Color.White;
			this.DaySelect.IsRadius = true;
			this.DaySelect.IsShowRect = true;
			this.DaySelect.ItemWidth = 40;
			this.DaySelect.Location = new System.Drawing.Point(28, 28);
			this.DaySelect.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
			this.DaySelect.Name = "DaySelect";
			this.DaySelect.RectColor = System.Drawing.Color.Sienna;
			this.DaySelect.RectWidth = 1;
			this.DaySelect.SelectedIndex = -1;
			this.DaySelect.Size = new System.Drawing.Size(109, 45);
			this.DaySelect.TabIndex = 110;
			this.DaySelect.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.DaySelect.TextValue = "奖励组";
			this.DaySelect.TriangleColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			this.DaySelect.SelectedChangedEvent += new System.EventHandler(this.DaySelect_SelectedChangedEvent);
			// 
			// ChallengeListFrm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(26)))), ((int)(((byte)(35)))));
			this.ClientSize = new System.Drawing.Size(672, 441);
			this.ContextMenuStrip = this.MenuStrip;
			this.Controls.Add(this.DaySelect);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "ChallengeListFrm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "每日挑战";
			this.MenuStrip.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.ContextMenuStrip MenuStrip;
		private System.Windows.Forms.ToolStripMenuItem ModifyFilterRule;
		private System.Windows.Forms.ToolStripMenuItem CancelFilter;
	
		private System.Windows.Forms.Label label1;
		private HZH_Controls.Controls.UCCombox DaySelect;
		private System.Windows.Forms.ToolStripMenuItem OutputList;
	}
}