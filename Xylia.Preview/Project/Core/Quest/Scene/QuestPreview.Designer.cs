using Xylia.Preview.Project.Controls;

namespace Xylia.Preview.Project.Core.Quest.Preview
{
	partial class QuestPreview
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuestPreview));
			this.Quest_ICON = new System.Windows.Forms.PictureBox();
			this.Quest_Group = new System.Windows.Forms.Label();
			this.QuestName = new Xylia.Preview.Project.Controls.ContentPanel();
			this.ContentInfo = new Xylia.Preview.Project.Core.Quest.Preview.SubGroup.ContentInfo();
			this.taskInfo = new Xylia.Preview.Project.Core.Quest.Preview.SubGroup.TaskInfo();
			this.MenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.SwitchTestMode = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.OpenFileData = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)(this.Quest_ICON)).BeginInit();
			this.MenuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// Quest_ICON
			// 
			this.Quest_ICON.Image = ((System.Drawing.Image)(resources.GetObject("Quest_ICON.Image")));
			this.Quest_ICON.Location = new System.Drawing.Point(5, 26);
			this.Quest_ICON.Margin = new System.Windows.Forms.Padding(4);
			this.Quest_ICON.Name = "Quest_ICON";
			this.Quest_ICON.Size = new System.Drawing.Size(32, 32);
			this.Quest_ICON.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.Quest_ICON.TabIndex = 7;
			this.Quest_ICON.TabStop = false;
			// 
			// Quest_Group
			// 
			this.Quest_Group.AutoSize = true;
			this.Quest_Group.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.Quest_Group.ForeColor = System.Drawing.SystemColors.ActiveBorder;
			this.Quest_Group.Location = new System.Drawing.Point(4, 4);
			this.Quest_Group.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.Quest_Group.Name = "Quest_Group";
			this.Quest_Group.Size = new System.Drawing.Size(48, 19);
			this.Quest_Group.TabIndex = 11;
			this.Quest_Group.Text = "组名称";
			// 
			// QuestName
			// 
			this.QuestName.BackColor = System.Drawing.Color.Transparent;
			//this.QuestName.BasicLineHeight = 26;
			this.QuestName.Font = new System.Drawing.Font("Microsoft YaHei UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.QuestName.ForeColor = System.Drawing.Color.LightGreen;
			this.QuestName.Location = new System.Drawing.Point(48, 29);
			this.QuestName.Margin = new System.Windows.Forms.Padding(2, 7, 2, 7);
			this.QuestName.Name = "QuestName";
			this.QuestName.TabIndex = 14;
			this.QuestName.Text = "任务名称";
			// 
			// ContentInfo
			// 
			this.ContentInfo.AutoSize = true;
			this.ContentInfo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ContentInfo.BackColor = System.Drawing.Color.Transparent;
			this.ContentInfo.GroupText = "内容";
			this.ContentInfo.Location = new System.Drawing.Point(4, 66);
			this.ContentInfo.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
			this.ContentInfo.Name = "ContentInfo";
			this.ContentInfo.Size = new System.Drawing.Size(110, 59);
			this.ContentInfo.TabIndex = 12;
			this.ContentInfo.Text = "进行书信对话";
			// 
			// taskInfo
			// 
			this.taskInfo.AutoSize = true;
			this.taskInfo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.taskInfo.BackColor = System.Drawing.Color.Transparent;
			this.taskInfo.GroupText = "任务";
			this.taskInfo.Location = new System.Drawing.Point(4, 162);
			this.taskInfo.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
			this.taskInfo.Name = "taskInfo";
			this.taskInfo.Size = new System.Drawing.Size(58, 26);
			this.taskInfo.TabIndex = 10;
			// 
			// MenuStrip
			// 
			this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SwitchTestMode,
            this.toolStripMenuItem1,
            this.OpenFileData});
			this.MenuStrip.Name = "MenuStrip";
			this.MenuStrip.Size = new System.Drawing.Size(214, 70);
			// 
			// SwitchTestMode
			// 
			this.SwitchTestMode.Checked = true;
			this.SwitchTestMode.CheckOnClick = true;
			this.SwitchTestMode.CheckState = System.Windows.Forms.CheckState.Checked;
			this.SwitchTestMode.Name = "SwitchTestMode";
			this.SwitchTestMode.Size = new System.Drawing.Size(213, 22);
			this.SwitchTestMode.Text = "切换测试模式 *";
			this.SwitchTestMode.Click += new System.EventHandler(this.SwitchTestMode_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Font = new System.Drawing.Font("Microsoft YaHei UI", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(213, 22);
			this.toolStripMenuItem1.Text = "* 表示下一次打开界面才会生效";
			this.toolStripMenuItem1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			// 
			// OpenFileData
			// 
			this.OpenFileData.Name = "OpenFileData";
			this.OpenFileData.Size = new System.Drawing.Size(213, 22);
			this.OpenFileData.Text = "查看任务文件";
			this.OpenFileData.Click += new System.EventHandler(this.OpenFileData_Click);
			// 
			// QuestPreview
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(817, 0);
			this.ContextMenuStrip = this.MenuStrip;
			this.Controls.Add(this.QuestName);
			this.Controls.Add(this.ContentInfo);
			this.Controls.Add(this.Quest_Group);
			this.Controls.Add(this.Quest_ICON);
			this.Controls.Add(this.taskInfo);
			this.ForeColor = System.Drawing.Color.DimGray;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MaximumSize = new System.Drawing.Size(2147483647, 1000);
			this.Name = "QuestPreview";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "任务预览";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QuestPreview_FormClosing);
			this.Load += new System.EventHandler(this.QuestPreview_Load);
			((System.ComponentModel.ISupportInitialize)(this.Quest_ICON)).EndInit();
			this.MenuStrip.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		public System.Windows.Forms.PictureBox Quest_ICON;
		private SubGroup.TaskInfo taskInfo;
		public System.Windows.Forms.Label Quest_Group;
		private SubGroup.ContentInfo ContentInfo;
		private SubGroup.RewardInfo rewardInfo;
		private ContentPanel QuestName;
		private System.Windows.Forms.ContextMenuStrip MenuStrip;
		private System.Windows.Forms.ToolStripMenuItem SwitchTestMode;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem OpenFileData;
	}
}
