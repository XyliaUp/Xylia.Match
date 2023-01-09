using Xylia.Preview.Project.Controls;

namespace Xylia.Preview.Project.Core.Quest.Preview.SubGroup
{
	partial class DescPanel
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
			this.Content = new Xylia.Preview.Project.Controls.ContentPanel();
			this.SuspendLayout();
			// 
			// Content
			// 
			this.Content.BackColor = System.Drawing.Color.Transparent;
			this.Content.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.Content.ForeColor = System.Drawing.Color.White;
			this.Content.Location = new System.Drawing.Point(26, 32);
			this.Content.Margin = new System.Windows.Forms.Padding(2, 7, 2, 7);
			this.Content.Name = "Content";
			this.Content.TabIndex = 8;
			this.Content.Text = "PanelContent";
			// 
			// DescPanel
			// 
			this.Controls.Add(this.Content);
			this.GroupText = "内容";
			this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			this.Name = "DescPanel";
			this.Size = new System.Drawing.Size(123, 57);
			this.Controls.SetChildIndex(this.Content, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Controls.ContentPanel Content;
	}
}
