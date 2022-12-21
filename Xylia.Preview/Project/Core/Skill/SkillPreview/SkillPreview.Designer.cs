namespace Xylia.Preview.Project.Core.Skill
{
	partial class SkillPreview
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SkillPreview));
			this.SkillName = new Xylia.Preview.Project.Core.Item.Cell.Basic.ItemNameCell();
			this.SkillIcon = new System.Windows.Forms.PictureBox();
			this.M1_Panel = new Xylia.Preview.Project.Core.Skill.SkillTooltipPanel();
			this.M2_Panel = new Xylia.Preview.Project.Core.Skill.SkillTooltipPanel();
			this.SUB_Panel = new Xylia.Preview.Project.Core.Skill.SkillTooltipPanel();
			this.CONDITION_Panel = new Xylia.Preview.Project.Core.Skill.SkillTooltipPanel();
			this.DamageRateStandardStats = new System.Windows.Forms.Label();
			this.DamageRatePvp = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.SkillIcon)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// SkillName
			// 
			this.SkillName.AutoSize = true;
			this.SkillName.BackColor = System.Drawing.Color.Transparent;
			this.SkillName.Font = new System.Drawing.Font("Microsoft YaHei UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.SkillName.ItemGrade = ((byte)(4));
			this.SkillName.Location = new System.Drawing.Point(3, 0);
			this.SkillName.Margin = new System.Windows.Forms.Padding(7, 10, 7, 10);
			this.SkillName.Name = "SkillName";
			this.SkillName.Size = new System.Drawing.Size(107, 28);
			this.SkillName.TabIndex = 24;
			this.SkillName.TagImage = null;
			this.SkillName.Text = "SkillName";
			// 
			// SkillIcon
			// 
			this.SkillIcon.BackColor = System.Drawing.Color.Transparent;
			this.SkillIcon.Location = new System.Drawing.Point(6, 28);
			this.SkillIcon.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.SkillIcon.Name = "SkillIcon";
			this.SkillIcon.Size = new System.Drawing.Size(90, 90);
			this.SkillIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.SkillIcon.TabIndex = 25;
			this.SkillIcon.TabStop = false;
			// 
			// M1_Panel
			// 
			this.M1_Panel.Location = new System.Drawing.Point(99, 28);
			this.M1_Panel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.M1_Panel.Name = "M1_Panel";
			this.M1_Panel.Size = new System.Drawing.Size(326, 36);
			this.M1_Panel.TabIndex = 26;
			// 
			// M2_Panel
			// 
			this.M2_Panel.Location = new System.Drawing.Point(99, 78);
			this.M2_Panel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.M2_Panel.Name = "M2_Panel";
			this.M2_Panel.Size = new System.Drawing.Size(326, 41);
			this.M2_Panel.TabIndex = 27;
			// 
			// SUB_Panel
			// 
			this.SUB_Panel.Location = new System.Drawing.Point(6, 137);
			this.SUB_Panel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.SUB_Panel.Name = "SUB_Panel";
			this.SUB_Panel.Size = new System.Drawing.Size(419, 168);
			this.SUB_Panel.TabIndex = 28;
			// 
			// CONDITION_Panel
			// 
			this.CONDITION_Panel.Location = new System.Drawing.Point(6, 380);
			this.CONDITION_Panel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.CONDITION_Panel.Name = "CONDITION_Panel";
			this.CONDITION_Panel.Size = new System.Drawing.Size(419, 84);
			this.CONDITION_Panel.TabIndex = 29;
			// 
			// DamageRateStandardStats
			// 
			this.DamageRateStandardStats.AutoSize = true;
			this.DamageRateStandardStats.ForeColor = System.Drawing.Color.White;
			this.DamageRateStandardStats.Location = new System.Drawing.Point(99, 351);
			this.DamageRateStandardStats.Name = "DamageRateStandardStats";
			this.DamageRateStandardStats.Size = new System.Drawing.Size(39, 17);
			this.DamageRateStandardStats.TabIndex = 29;
			this.DamageRateStandardStats.Text = "1.000";
			// 
			// DamageRatePvp
			// 
			this.DamageRatePvp.AutoSize = true;
			this.DamageRatePvp.ForeColor = System.Drawing.Color.White;
			this.DamageRatePvp.Location = new System.Drawing.Point(299, 351);
			this.DamageRatePvp.Name = "DamageRatePvp";
			this.DamageRatePvp.Size = new System.Drawing.Size(39, 17);
			this.DamageRatePvp.TabIndex = 30;
			this.DamageRatePvp.Text = "1.000";
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(99, 478);
			this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(50, 29);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 31;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Visible = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(299, 490);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(27, 17);
			this.label1.TabIndex = 32;
			this.label1.Text = "0秒";
			// 
			// SkillPreview
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = System.Drawing.Color.Transparent;
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.CONDITION_Panel);
			this.Controls.Add(this.DamageRatePvp);
			this.Controls.Add(this.DamageRateStandardStats);
			this.Controls.Add(this.SUB_Panel);
			this.Controls.Add(this.M2_Panel);
			this.Controls.Add(this.M1_Panel);
			this.Controls.Add(this.SkillIcon);
			this.Controls.Add(this.SkillName);
			this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.Name = "SkillPreview";
			this.Size = new System.Drawing.Size(428, 510);
			((System.ComponentModel.ISupportInitialize)(this.SkillIcon)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private Item.Cell.Basic.ItemNameCell SkillName;
		private System.Windows.Forms.PictureBox SkillIcon;
		private SkillTooltipPanel M1_Panel;
		private SkillTooltipPanel M2_Panel;
		private SkillTooltipPanel SUB_Panel;
		private SkillTooltipPanel CONDITION_Panel;

		private System.Windows.Forms.Label DamageRateStandardStats;
		private System.Windows.Forms.Label DamageRatePvp;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label1;
	}
}
