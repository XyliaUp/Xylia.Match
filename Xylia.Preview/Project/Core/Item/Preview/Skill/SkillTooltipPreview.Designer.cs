using Xylia.Preview.Project.Controls;

namespace Xylia.Preview.Project.Core.Item
{
	partial class SkillTooltipPreview
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
			this.ContentPanel = new ContentPanel();
			this.JobStyleSelect = new Xylia.Preview.Project.Core.Item.Preview.JobStyleSelect();
			this.SuspendLayout();
			// 
			// ContentPanel
			// 
			this.ContentPanel.BackColor = System.Drawing.Color.Transparent;
			this.ContentPanel.BasicLineHeight = 20;
			this.ContentPanel.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.ContentPanel.ForeColor = System.Drawing.Color.White;
			this.ContentPanel.Location = new System.Drawing.Point(2, 35);
			this.ContentPanel.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
			this.ContentPanel.Name = "ContentPanel";
			this.ContentPanel.TabIndex = 0;
			this.ContentPanel.Text = "ContentPanel";
			// 
			// JobStyleSelect
			// 
			this.JobStyleSelect.AutoSize = true;
			this.JobStyleSelect.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.JobStyleSelect.BackColor = System.Drawing.Color.Transparent;
			this.JobStyleSelect.Location = new System.Drawing.Point(1, 0);
			this.JobStyleSelect.Name = "JobStyleSelect";
			this.JobStyleSelect.Size = new System.Drawing.Size(109, 34);
			this.JobStyleSelect.TabIndex = 1;
			// 
			// SkillTooltipPreview
			// 
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = System.Drawing.Color.Transparent;
			this.Controls.Add(this.JobStyleSelect);
			this.Controls.Add(this.ContentPanel);
			this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			this.Name = "SkillTooltipPreview";
			this.Size = new System.Drawing.Size(113, 60);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private ContentPanel ContentPanel;
		private Preview.JobStyleSelect JobStyleSelect;
	}
}
