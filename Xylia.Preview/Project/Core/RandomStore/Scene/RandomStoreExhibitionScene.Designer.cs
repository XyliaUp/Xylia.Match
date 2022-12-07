
namespace Xylia.Preview.Project.RunForm
{
	partial class RandomStoreExhibitionScene
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
			this.TabControl = new System.Windows.Forms.TabControl();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.drawRewardPreview1 = new Xylia.Preview.Project.Core.RandomStore.DrawRewardPreview();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.RandomStoreItemDisplayList_1 = new Xylia.Preview.Project.Core.Store.StoreListPreview();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.RandomStoreItemDisplayList_2 = new Xylia.Preview.Project.Core.Store.StoreListPreview();
			this.TabControl.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.SuspendLayout();
			// 
			// TabControl
			// 
			this.TabControl.Controls.Add(this.tabPage3);
			this.TabControl.Controls.Add(this.tabPage1);
			this.TabControl.Controls.Add(this.tabPage2);
			this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TabControl.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.TabControl.Location = new System.Drawing.Point(0, 0);
			this.TabControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.TabControl.Name = "TabControl";
			this.TabControl.SelectedIndex = 0;
			this.TabControl.Size = new System.Drawing.Size(556, 618);
			this.TabControl.TabIndex = 4;
			this.TabControl.SelectedIndexChanged += new System.EventHandler(this.TabControl_SelectedIndexChanged);
			// 
			// tabPage3
			// 
			this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(26)))), ((int)(((byte)(35)))));
			this.tabPage3.Controls.Add(this.drawRewardPreview1);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.tabPage3.Size = new System.Drawing.Size(548, 592);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "开启奖励";
			// 
			// drawRewardPreview1
			// 
			this.drawRewardPreview1.AutoScroll = true;
			this.drawRewardPreview1.BackColor = System.Drawing.Color.Transparent;
			this.drawRewardPreview1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.drawRewardPreview1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.drawRewardPreview1.Location = new System.Drawing.Point(4, 4);
			this.drawRewardPreview1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.drawRewardPreview1.Name = "drawRewardPreview1";
			this.drawRewardPreview1.Size = new System.Drawing.Size(540, 584);
			this.drawRewardPreview1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.RandomStoreItemDisplayList_1);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.tabPage1.Size = new System.Drawing.Size(600, 866);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "钥匙";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// RandomStoreItemDisplayList_1
			// 
			this.RandomStoreItemDisplayList_1.AutoScroll = true;
			this.RandomStoreItemDisplayList_1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(26)))), ((int)(((byte)(25)))));
			this.RandomStoreItemDisplayList_1.Cells = null;
			this.RandomStoreItemDisplayList_1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.RandomStoreItemDisplayList_1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.RandomStoreItemDisplayList_1.Location = new System.Drawing.Point(4, 4);
			this.RandomStoreItemDisplayList_1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.RandomStoreItemDisplayList_1.MaxCellNum = 0;
			this.RandomStoreItemDisplayList_1.MaxPageNum = 0;
			this.RandomStoreItemDisplayList_1.Name = "RandomStoreItemDisplayList_1";
			//this.RandomStoreItemDisplayList_1.ShowItemID = false;
			this.RandomStoreItemDisplayList_1.Size = new System.Drawing.Size(592, 858);
			this.RandomStoreItemDisplayList_1.TabIndex = 3;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.RandomStoreItemDisplayList_2);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.tabPage2.Size = new System.Drawing.Size(600, 866);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "金币";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// RandomStoreItemDisplayList_2
			// 
			this.RandomStoreItemDisplayList_2.AutoScroll = true;
			this.RandomStoreItemDisplayList_2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(26)))), ((int)(((byte)(25)))));
			this.RandomStoreItemDisplayList_2.Cells = null;
			this.RandomStoreItemDisplayList_2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.RandomStoreItemDisplayList_2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.RandomStoreItemDisplayList_2.Location = new System.Drawing.Point(4, 4);
			this.RandomStoreItemDisplayList_2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.RandomStoreItemDisplayList_2.MaxCellNum = 0;
			this.RandomStoreItemDisplayList_2.MaxPageNum = 0;
			this.RandomStoreItemDisplayList_2.Name = "RandomStoreItemDisplayList_2";
			//this.RandomStoreItemDisplayList_2.ShowItemID = false;
			this.RandomStoreItemDisplayList_2.Size = new System.Drawing.Size(592, 858);
			this.RandomStoreItemDisplayList_2.TabIndex = 4;
			// 
			// RandomStoreExhibitionScene
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(26)))), ((int)(((byte)(35)))));
			this.ClientSize = new System.Drawing.Size(556, 618);
			this.Controls.Add(this.TabControl);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.Name = "RandomStoreExhibitionScene";
			this.Text = "聚灵阁开启次数 & 奖励预览";
			this.Load += new System.EventHandler(this.RandomStoreExhibitionScene_Load);
			this.TabControl.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private Xylia.Preview.Project.Core.Store.StoreListPreview RandomStoreItemDisplayList_1;
		private System.Windows.Forms.TabControl TabControl;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private Xylia.Preview.Project.Core.Store.StoreListPreview RandomStoreItemDisplayList_2;
		private System.Windows.Forms.TabPage tabPage3;
		private Xylia.Preview.Project.Core.RandomStore.DrawRewardPreview drawRewardPreview1;
	}
}