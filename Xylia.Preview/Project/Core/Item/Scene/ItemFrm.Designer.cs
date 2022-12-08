using Xylia.Preview.Project.Controls;

namespace Xylia.Preview.Project.Core.Item.Scene
{
	partial class ItemFrm
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
			this.ItemIcon = new System.Windows.Forms.PictureBox();
			this.lbl_Category = new System.Windows.Forms.Label();
			this.lbl_JobLimit = new System.Windows.Forms.Label();
			this.lbl_Trade_Account = new System.Windows.Forms.Label();
			this.MenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.MenuItem_IconSaveAs = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItem_SaveAsImage = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItem_SwitchUserOperPanel = new System.Windows.Forms.ToolStripMenuItem();
			this.durabilityPreview1 = new Xylia.Preview.Project.Core.Item.DurabilityPreview();
			this.lbl_MainInfo = new ContentPanel();
			this.lbl_SubInfo = new ContentPanel();
			this.PricePreview = new Xylia.Preview.Project.Controls.PriceCell();
			this.ItemNameCell = new Xylia.Preview.Project.Core.Item.Cell.Basic.ItemNameCell();
			((System.ComponentModel.ISupportInitialize)(this.ItemIcon)).BeginInit();
			this.MenuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// ItemIcon
			// 
			this.ItemIcon.BackColor = System.Drawing.Color.SlateGray;
			this.ItemIcon.Location = new System.Drawing.Point(8, 42);
			this.ItemIcon.Margin = new System.Windows.Forms.Padding(4);
			this.ItemIcon.Name = "ItemIcon";
			this.ItemIcon.Size = new System.Drawing.Size(84, 84);
			this.ItemIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.ItemIcon.TabIndex = 1;
			this.ItemIcon.TabStop = false;
			// 
			// lbl_Category
			// 
			this.lbl_Category.AutoSize = true;
			this.lbl_Category.BackColor = System.Drawing.Color.Transparent;
			this.lbl_Category.Font = new System.Drawing.Font("Microsoft YaHei UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.lbl_Category.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.lbl_Category.Location = new System.Drawing.Point(393, 3);
			this.lbl_Category.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbl_Category.Name = "lbl_Category";
			this.lbl_Category.Size = new System.Drawing.Size(76, 20);
			this.lbl_Category.TabIndex = 2;
			this.lbl_Category.Text = "Category";
			this.lbl_Category.Visible = false;
			this.lbl_Category.TextChanged += new System.EventHandler(this.lbl_Category_TextChanged);
			this.lbl_Category.VisibleChanged += new System.EventHandler(this.lbl_Category_VisibleChanged);
			// 
			// lbl_JobLimit
			// 
			this.lbl_JobLimit.AutoSize = true;
			this.lbl_JobLimit.BackColor = System.Drawing.Color.Transparent;
			this.lbl_JobLimit.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.lbl_JobLimit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(88)))), ((int)(((byte)(66)))));
			this.lbl_JobLimit.Location = new System.Drawing.Point(1, 292);
			this.lbl_JobLimit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbl_JobLimit.Name = "lbl_JobLimit";
			this.lbl_JobLimit.Size = new System.Drawing.Size(66, 20);
			this.lbl_JobLimit.TabIndex = 5;
			this.lbl_JobLimit.Text = "JobLimit";
			// 
			// lbl_Trade_Account
			// 
			this.lbl_Trade_Account.AutoSize = true;
			this.lbl_Trade_Account.BackColor = System.Drawing.Color.Transparent;
			this.lbl_Trade_Account.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.lbl_Trade_Account.ForeColor = System.Drawing.Color.White;
			this.lbl_Trade_Account.Location = new System.Drawing.Point(1, 341);
			this.lbl_Trade_Account.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbl_Trade_Account.Name = "lbl_Trade_Account";
			this.lbl_Trade_Account.Size = new System.Drawing.Size(65, 20);
			this.lbl_Trade_Account.TabIndex = 8;
			this.lbl_Trade_Account.Text = "账号专用";
			this.lbl_Trade_Account.Visible = false;
			// 
			// MenuStrip
			// 
			this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_IconSaveAs,
            this.MenuItem_SaveAsImage,
            this.MenuItem_SwitchUserOperPanel});
			this.MenuStrip.Name = "Menu";
			this.MenuStrip.Size = new System.Drawing.Size(187, 70);
			// 
			// MenuItem_IconSaveAs
			// 
			this.MenuItem_IconSaveAs.Name = "MenuItem_IconSaveAs";
			this.MenuItem_IconSaveAs.Size = new System.Drawing.Size(186, 22);
			this.MenuItem_IconSaveAs.Text = "图标另存为";
			this.MenuItem_IconSaveAs.Click += new System.EventHandler(this.MenuItem_IconSaveAs_Click);
			// 
			// MenuItem_SaveAsImage
			// 
			this.MenuItem_SaveAsImage.Name = "MenuItem_SaveAsImage";
			this.MenuItem_SaveAsImage.Size = new System.Drawing.Size(186, 22);
			this.MenuItem_SaveAsImage.Text = "[Ctrl+A] 生成截图";
			this.MenuItem_SaveAsImage.Click += new System.EventHandler(this.MenuItem_SaveAsImage_Click);
			// 
			// MenuItem_SwitchUserOperPanel
			// 
			this.MenuItem_SwitchUserOperPanel.Checked = true;
			this.MenuItem_SwitchUserOperPanel.CheckOnClick = true;
			this.MenuItem_SwitchUserOperPanel.CheckState = System.Windows.Forms.CheckState.Checked;
			this.MenuItem_SwitchUserOperPanel.Name = "MenuItem_SwitchUserOperPanel";
			this.MenuItem_SwitchUserOperPanel.Size = new System.Drawing.Size(186, 22);
			this.MenuItem_SwitchUserOperPanel.Text = "[Ctrl+G] 使用操作板";
			this.MenuItem_SwitchUserOperPanel.CheckedChanged += new System.EventHandler(this.MenuItem_SwitchUserOperPanel_CheckedChanged);
			// 
			// durabilityPreview1
			// 
			this.durabilityPreview1.AutoSize = true;
			this.durabilityPreview1.BackColor = System.Drawing.Color.Transparent;
			this.durabilityPreview1.Durability = 500;
			this.durabilityPreview1.ForeColor = System.Drawing.Color.White;
			this.durabilityPreview1.Location = new System.Drawing.Point(8, 225);
			this.durabilityPreview1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			this.durabilityPreview1.Name = "durabilityPreview1";
			this.durabilityPreview1.Size = new System.Drawing.Size(471, 28);
			this.durabilityPreview1.TabIndex = 20;
			this.durabilityPreview1.Visible = false;
			// 
			// lbl_MainInfo
			// 
			this.lbl_MainInfo.BackColor = System.Drawing.Color.Transparent;
			this.lbl_MainInfo.BasicLineHeight = 24;
			this.lbl_MainInfo.Font = new System.Drawing.Font("Microsoft YaHei UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.lbl_MainInfo.ForeColor = System.Drawing.Color.White;
			this.lbl_MainInfo.Location = new System.Drawing.Point(108, 42);
			this.lbl_MainInfo.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			this.lbl_MainInfo.Name = "lbl_MainInfo";
			this.lbl_MainInfo.TabIndex = 19;
			this.lbl_MainInfo.Text = "MainInfo";
			// 
			// lbl_SubInfo
			// 
			this.lbl_SubInfo.BackColor = System.Drawing.Color.Transparent;
			this.lbl_SubInfo.BasicLineHeight = 20;
			this.lbl_SubInfo.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.lbl_SubInfo.ForeColor = System.Drawing.Color.White;
			this.lbl_SubInfo.Location = new System.Drawing.Point(111, 79);
			this.lbl_SubInfo.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
			this.lbl_SubInfo.Name = "lbl_SubInfo";
			this.lbl_SubInfo.TabIndex = 18;
			this.lbl_SubInfo.Text = "SubInfo";
			// 
			// PricePreview
			// 
			this.PricePreview.AutoSize = true;
			this.PricePreview.BackColor = System.Drawing.Color.Transparent;
			this.PricePreview.CurrencyCount = 1;
			this.PricePreview.CurrencyType = Xylia.Preview.Project.Controls.Enums.CurrencyType.Money;
			this.PricePreview.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.PricePreview.FontStyle = System.Drawing.FontStyle.Regular;
			this.PricePreview.ForeColor = System.Drawing.Color.White;
			this.PricePreview.Location = new System.Drawing.Point(346, 445);
			this.PricePreview.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			this.PricePreview.Name = "PricePreview";
			this.PricePreview.Size = new System.Drawing.Size(131, 19);
			this.PricePreview.TabIndex = 2;
			this.PricePreview.Tooltip = "出售价格为每个";
			// 
			// ItemNameCell
			// 
			this.ItemNameCell.AutoSize = true;
			this.ItemNameCell.BackColor = System.Drawing.Color.Transparent;
			this.ItemNameCell.Font = new System.Drawing.Font("Microsoft YaHei UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.ItemNameCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(132)))));
			this.ItemNameCell.ItemGrade = 8;
			this.ItemNameCell.Location = new System.Drawing.Point(2, 1);
			this.ItemNameCell.Margin = new System.Windows.Forms.Padding(7, 10, 7, 10);
			this.ItemNameCell.Name = "ItemNameCell";
			this.ItemNameCell.Size = new System.Drawing.Size(112, 29);
			this.ItemNameCell.TabIndex = 23;
			this.ItemNameCell.TagImage = null;
			this.ItemNameCell.Text = "ItemName";
			this.ItemNameCell.DoubleClick += new System.EventHandler(this.ItemNameCell_DoubleClick);
			// 
			// ItemFrm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(26)))), ((int)(((byte)(35)))));
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.ClientSize = new System.Drawing.Size(483, 469);
			this.ContextMenuStrip = this.MenuStrip;
			this.Controls.Add(this.durabilityPreview1);
			this.Controls.Add(this.lbl_MainInfo);
			this.Controls.Add(this.lbl_SubInfo);
			this.Controls.Add(this.PricePreview);
			this.Controls.Add(this.lbl_Trade_Account);
			this.Controls.Add(this.lbl_JobLimit);
			this.Controls.Add(this.ItemIcon);
			this.Controls.Add(this.lbl_Category);
			this.Controls.Add(this.ItemNameCell);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.KeyPreview = true;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "ItemFrm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "ItemScene  1.57";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFrm_FormClosing);
			this.Load += new System.EventHandler(this.Preview_Load);
			this.Shown += new System.EventHandler(this.ItemFrm_Shown);
			this.SizeChanged += new System.EventHandler(this.Preview_SizeChanged);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Preview_KeyDown);
			((System.ComponentModel.ISupportInitialize)(this.ItemIcon)).EndInit();
			this.MenuStrip.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.PictureBox ItemIcon;
		private System.Windows.Forms.Label lbl_Category;
		private System.Windows.Forms.Label lbl_JobLimit;
		private System.Windows.Forms.Label lbl_Trade_Account;
		private Xylia.Preview.Project.Controls.PriceCell PricePreview;
		private ContentPanel lbl_SubInfo;
		private ContentPanel lbl_MainInfo;
		private System.Windows.Forms.ContextMenuStrip MenuStrip;
		private System.Windows.Forms.ToolStripMenuItem MenuItem_IconSaveAs;
		private System.Windows.Forms.ToolStripMenuItem MenuItem_SaveAsImage;
		private Xylia.Preview.Project.Core.Item.DurabilityPreview durabilityPreview1;
		private Cell.Basic.ItemNameCell ItemNameCell;
		private System.Windows.Forms.ToolStripMenuItem MenuItem_SwitchUserOperPanel;
		//private CustomControl.Item.EventTimePreview eventTimePreview1;
	}
}
