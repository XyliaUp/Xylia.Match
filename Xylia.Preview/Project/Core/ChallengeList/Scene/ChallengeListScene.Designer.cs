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
			this.label2 = new System.Windows.Forms.Label();
			this.RewardPreview = new Xylia.Preview.Project.Core.ChallengeList.ChallengeListRewardPreview();
			this.label3 = new System.Windows.Forms.Label();
			this.TaskPanel = new System.Windows.Forms.Panel();
			this.RequiredTime = new Xylia.Preview.Project.Controls.ContentPanel();
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
			this.label1.Location = new System.Drawing.Point(37, 184);
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
			this.DaySelect.Location = new System.Drawing.Point(14, 7);
			this.DaySelect.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
			this.DaySelect.Name = "DaySelect";
			this.DaySelect.RectColor = System.Drawing.Color.Sienna;
			this.DaySelect.RectWidth = 1;
			this.DaySelect.SelectedIndex = -1;
			this.DaySelect.Size = new System.Drawing.Size(109, 45);
			this.DaySelect.TabIndex = 110;
			this.DaySelect.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.DaySelect.TextValue = "内容选择";
			this.DaySelect.TriangleColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			this.DaySelect.SelectedChangedEvent += new System.EventHandler(this.DaySelect_SelectedChangedEvent);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.label2.ForeColor = System.Drawing.Color.White;
			this.label2.Location = new System.Drawing.Point(297, 28);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(82, 24);
			this.label2.TabIndex = 111;
			this.label2.Text = "挑战奖励";
			// 
			// RewardPreview
			// 
			this.RewardPreview.AutoSize = true;
			this.RewardPreview.BackColor = System.Drawing.Color.Transparent;
			this.RewardPreview.ForeColor = System.Drawing.Color.White;
			this.RewardPreview.Location = new System.Drawing.Point(151, 87);
			this.RewardPreview.Name = "RewardPreview";
			this.RewardPreview.Size = new System.Drawing.Size(356, 51);
			this.RewardPreview.TabIndex = 112;
			this.RewardPreview.PrevSeleted += new Xylia.Preview.Project.Core.ChallengeList.ChallengeListRewardPreview.RewardSeletedHandle(this.RewardPreview_PrevSeleted);
			this.RewardPreview.NextSeleted += new Xylia.Preview.Project.Core.ChallengeList.ChallengeListRewardPreview.RewardSeletedHandle(this.RewardPreview_NextSeleted);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.ForeColor = System.Drawing.Color.White;
			this.label3.Location = new System.Drawing.Point(311, 67);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(51, 17);
			this.label3.TabIndex = 115;
			this.label3.Text = "完成1个";
			// 
			// TaskPanel
			// 
			this.TaskPanel.AutoScroll = true;
			this.TaskPanel.ContextMenuStrip = this.MenuStrip;
			this.TaskPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.TaskPanel.Location = new System.Drawing.Point(0, 215);
			this.TaskPanel.Name = "TaskPanel";
			this.TaskPanel.Size = new System.Drawing.Size(672, 338);
			this.TaskPanel.TabIndex = 116;
			// 
			// RequiredTime
			// 
			this.RequiredTime.BackColor = System.Drawing.Color.Transparent;
			this.RequiredTime.BasicLineHeight = 19;
			this.RequiredTime.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.RequiredTime.ForeColor = System.Drawing.Color.White;
			this.RequiredTime.Location = new System.Drawing.Point(506, 7);
			this.RequiredTime.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
			this.RequiredTime.Name = "RequiredTime";
			this.RequiredTime.TabIndex = 117;
			this.RequiredTime.Text = "今日挑战<br/><image enablescale=\"true\" imagesetpath=\"00009076.RequiredTime\" scalerate" +
    "=\"1.4\"/><timer id=\"1\" type=\"dhm-plusonesec\"/>还剩";
			// 
			// ChallengeListFrm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(26)))), ((int)(((byte)(35)))));
			this.ClientSize = new System.Drawing.Size(672, 553);
			this.Controls.Add(this.RequiredTime);
			this.Controls.Add(this.TaskPanel);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.RewardPreview);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.DaySelect);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "ChallengeListFrm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "每日挑战";
			this.Load += new System.EventHandler(this.ChallengeListFrm_Load);
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
		private System.Windows.Forms.Label label2;
		private Core.ChallengeList.ChallengeListRewardPreview RewardPreview;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Panel TaskPanel;
		private Controls.ContentPanel RequiredTime;
	}
}