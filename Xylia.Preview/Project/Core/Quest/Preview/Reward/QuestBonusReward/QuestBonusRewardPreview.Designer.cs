namespace Xylia.Preview.Project.Core.Quest.Preview.SubGroup.Reward.QuestBonusReward
{
	partial class QuestBonusRewardPreview
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
			this.EventTime_FixedDate = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// EventTime_FixedDate
			// 
			this.EventTime_FixedDate.AutoSize = true;
			this.EventTime_FixedDate.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.EventTime_FixedDate.ForeColor = System.Drawing.Color.White;
			this.EventTime_FixedDate.Location = new System.Drawing.Point(152, 60);
			this.EventTime_FixedDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.EventTime_FixedDate.Name = "EventTime_FixedDate";
			this.EventTime_FixedDate.Size = new System.Drawing.Size(121, 20);
			this.EventTime_FixedDate.TabIndex = 9;
			this.EventTime_FixedDate.Text = "基本特别奖励次数";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(153, 24);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(93, 20);
			this.label1.TabIndex = 10;
			this.label1.Text = "未知副本名称";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.label2.ForeColor = System.Drawing.Color.White;
			this.label2.Location = new System.Drawing.Point(15, 139);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(65, 20);
			this.label2.TabIndex = 11;
			this.label2.Text = "获取更多";
			// 
			// QuestBonusRewardPreview
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Transparent;
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.EventTime_FixedDate);
			this.Name = "QuestBonusRewardPreview";
			this.Size = new System.Drawing.Size(449, 272);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label EventTime_FixedDate;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
	}
}
