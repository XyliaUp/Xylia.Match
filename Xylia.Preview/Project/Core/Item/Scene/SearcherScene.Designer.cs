
namespace Xylia.Preview.Project.Core.Item.Scene
{
	partial class SearcherScene
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
			this.MenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.CloseFrmAfterChooseItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ShowItemID = new System.Windows.Forms.ToolStripMenuItem();
			this.ItemList = new Xylia.Preview.Project.Core.Store.StoreListPreview();
			this.storeItemCell1 = new Xylia.Preview.Project.Core.Store.Cell.ItemListCell();
			this.MenuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// MenuStrip
			// 
			this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CloseFrmAfterChooseItem,
            this.ShowItemID});
			this.MenuStrip.Name = "contextMenuStrip1";
			this.MenuStrip.Size = new System.Drawing.Size(185, 70);
			// 
			// CloseFrmAfterChooseItem
			// 
			this.CloseFrmAfterChooseItem.Checked = true;
			this.CloseFrmAfterChooseItem.CheckOnClick = true;
			this.CloseFrmAfterChooseItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.CloseFrmAfterChooseItem.Name = "CloseFrmAfterChooseItem";
			this.CloseFrmAfterChooseItem.Size = new System.Drawing.Size(184, 22);
			this.CloseFrmAfterChooseItem.Text = "跳转后不关闭此界面";
			this.CloseFrmAfterChooseItem.Click += new System.EventHandler(this.CloseFrmAfterChooseItem_Click);
			// 
			// ShowItemID
			// 
			this.ShowItemID.CheckOnClick = true;
			this.ShowItemID.Name = "ShowItemID";
			this.ShowItemID.Size = new System.Drawing.Size(184, 22);
			this.ShowItemID.Text = "显示物品ID";
			this.ShowItemID.Click += new System.EventHandler(this.ShowItemID_Click);
			// 
			// ItemList
			// 
			this.ItemList.AutoScroll = true;
			this.ItemList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(26)))), ((int)(((byte)(35)))));
			this.ItemList.Cells = null;
			this.ItemList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ItemList.Location = new System.Drawing.Point(0, 0);
			this.ItemList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.ItemList.MaxCellNum = 0;
			this.ItemList.MaxPageNum = 0;
			this.ItemList.Name = "ItemList";
			this.ItemList.Size = new System.Drawing.Size(486, 751);
			this.ItemList.TabIndex = 0;
			// 
			// storeItemCell1
			// 
			this.storeItemCell1.AutoSize = true;
			this.storeItemCell1.BackColor = System.Drawing.Color.Transparent;
			this.storeItemCell1.ForeColor = System.Drawing.Color.Black;
			this.storeItemCell1.Location = new System.Drawing.Point(0, 0);
			this.storeItemCell1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			this.storeItemCell1.Name = "storeItemCell1";
			this.storeItemCell1.RightText = "地图名称";
			this.storeItemCell1.ShowRightText = true;
			this.storeItemCell1.Size = new System.Drawing.Size(382, 55);
			this.storeItemCell1.StoreBundleCount = 2;
			this.storeItemCell1.TabIndex = 0;
			// 
			// SearcherScene
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(486, 751);
			this.ContextMenuStrip = this.MenuStrip;
			this.Controls.Add(this.ItemList);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.MaximizeBox = false;
			this.Name = "SearcherScene";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "物品搜索 （双击物品即跳转）";
			this.Load += new System.EventHandler(this.SearcherScene_Load);
			this.MenuStrip.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private Store.StoreListPreview ItemList;
		private System.Windows.Forms.ContextMenuStrip MenuStrip;
		private System.Windows.Forms.ToolStripMenuItem CloseFrmAfterChooseItem;
		private Store.Cell.ItemListCell storeItemCell1;
		private System.Windows.Forms.ToolStripMenuItem ShowItemID;
	}
}