
using Xylia.Preview.Project.Core.Skill;

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
			this.SkillName = new Xylia.Preview.Project.Core.Item.Cell.Basic.ItemNameCell();
			this.SkillIcon = new System.Windows.Forms.PictureBox();
			this.M1_Panel = new Xylia.Preview.Project.Core.Skill.SkillTooltipPanel();
			this.M2_Panel = new Xylia.Preview.Project.Core.Skill.SkillTooltipPanel();
			this.SUB_Panel = new Xylia.Preview.Project.Core.Skill.SkillTooltipPanel();
			this.CONDITION_Panel = new Xylia.Preview.Project.Core.Skill.SkillTooltipPanel();
			this.DamageRateStandardStats = new System.Windows.Forms.Label();
			this.DamageRatePvp = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.SkillIcon)).BeginInit();
			this.SuspendLayout();
			// 
			// SkillName
			// 
			this.SkillName.AutoSize = true;
			this.SkillName.BackColor = System.Drawing.Color.Transparent;
			this.SkillName.Font = new System.Drawing.Font("微软雅黑", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.SkillName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(132)))));
			this.SkillName.ItemGrade = ((byte)(8));
			this.SkillName.Location = new System.Drawing.Point(8, 0);
			this.SkillName.Margin = new System.Windows.Forms.Padding(10, 12, 10, 12);
			this.SkillName.Name = "SkillName";
			this.SkillName.Size = new System.Drawing.Size(113, 30);
			this.SkillName.TabIndex = 24;
			this.SkillName.TagImage = null;
			this.SkillName.Text = "SkillName";
			// 
			// SkillIcon
			// 
			this.SkillIcon.BackColor = System.Drawing.Color.SlateGray;
			this.SkillIcon.Location = new System.Drawing.Point(8, 34);
			this.SkillIcon.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
			this.SkillIcon.Name = "SkillIcon";
			this.SkillIcon.Size = new System.Drawing.Size(124, 124);
			this.SkillIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.SkillIcon.TabIndex = 25;
			this.SkillIcon.TabStop = false;
			// 
			// M1_Panel
			// 
			this.M1_Panel.AutoSize = true;
			this.M1_Panel.Location = new System.Drawing.Point(142, 34);
			this.M1_Panel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.M1_Panel.Name = "M1_Panel";
			this.M1_Panel.Size = new System.Drawing.Size(386, 44);
			this.M1_Panel.TabIndex = 26;
			// 
			// M2_Panel
			// 
			this.M2_Panel.AutoSize = true;
			this.M2_Panel.Location = new System.Drawing.Point(142, 96);
			this.M2_Panel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.M2_Panel.Name = "M2_Panel";
			this.M2_Panel.Size = new System.Drawing.Size(386, 51);
			this.M2_Panel.TabIndex = 27;
			// 
			// SUB_Panel
			// 
			this.SUB_Panel.AutoSize = true;
			this.SUB_Panel.Location = new System.Drawing.Point(8, 169);
			this.SUB_Panel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.SUB_Panel.Name = "SUB_Panel";
			this.SUB_Panel.Size = new System.Drawing.Size(524, 207);
			this.SUB_Panel.TabIndex = 28;
			// 
			// CONDITION_Panel
			// 
			this.CONDITION_Panel.AutoSize = true;
			this.CONDITION_Panel.Location = new System.Drawing.Point(8, 469);
			this.CONDITION_Panel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.CONDITION_Panel.Name = "CONDITION_Panel";
			this.CONDITION_Panel.Size = new System.Drawing.Size(524, 104);
			this.CONDITION_Panel.TabIndex = 29;
			// 
			// DamageRateStandardStats
			// 
			this.DamageRateStandardStats.AutoSize = true;
			this.DamageRateStandardStats.ForeColor = System.Drawing.Color.White;
			this.DamageRateStandardStats.Location = new System.Drawing.Point(81, 433);
			this.DamageRateStandardStats.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.DamageRateStandardStats.Name = "DamageRateStandardStats";
			this.DamageRateStandardStats.Size = new System.Drawing.Size(55, 21);
			this.DamageRateStandardStats.TabIndex = 29;
			this.DamageRateStandardStats.Text = "label1";
			// 
			// DamageRatePvp
			// 
			this.DamageRatePvp.AutoSize = true;
			this.DamageRatePvp.ForeColor = System.Drawing.Color.White;
			this.DamageRatePvp.Location = new System.Drawing.Point(312, 433);
			this.DamageRatePvp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.DamageRatePvp.Name = "DamageRatePvp";
			this.DamageRatePvp.Size = new System.Drawing.Size(55, 21);
			this.DamageRatePvp.TabIndex = 30;
			this.DamageRatePvp.Text = "label1";
			// 
			// SkillPreview
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = System.Drawing.Color.Transparent;
			this.Controls.Add(this.CONDITION_Panel);
			this.Controls.Add(this.DamageRatePvp);
			this.Controls.Add(this.DamageRateStandardStats);
			this.Controls.Add(this.SUB_Panel);
			this.Controls.Add(this.M2_Panel);
			this.Controls.Add(this.M1_Panel);
			this.Controls.Add(this.SkillIcon);
			this.Controls.Add(this.SkillName);
			this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
			this.Name = "SkillPreview";
			this.Size = new System.Drawing.Size(536, 576);
			this.Load += new System.EventHandler(this.SkillPreview_Load);
			((System.ComponentModel.ISupportInitialize)(this.SkillIcon)).EndInit();
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
		
	}
}
