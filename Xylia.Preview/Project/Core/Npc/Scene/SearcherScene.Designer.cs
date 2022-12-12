
namespace Xylia.Preview.Project.Core.Npc.Scene
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearcherScene));
			this.storeListPreview1 = new Xylia.Preview.Project.Core.Store.StoreListPreview();
			this.storeItemCell1 = new Xylia.Preview.Project.Core.Store.Cell.ItemListCell();
			this.SuspendLayout();
			// 
			// storeListPreview1
			// 
			this.storeListPreview1.AutoScroll = true;
			this.storeListPreview1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(26)))), ((int)(((byte)(35)))));
			this.storeListPreview1.Cells = null;
			this.storeListPreview1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.storeListPreview1.Location = new System.Drawing.Point(0, 0);
			this.storeListPreview1.MaxCellNum = 0;
			this.storeListPreview1.MaxPageNum = 0;
			this.storeListPreview1.Name = "storeListPreview1";
			//this.storeListPreview1.ShowItemID = false;
			this.storeListPreview1.Size = new System.Drawing.Size(439, 274);
			this.storeListPreview1.TabIndex = 0;
			// 
			// storeItemCell1
			// 
			this.storeItemCell1.AutoSize = true;
			this.storeItemCell1.BackColor = System.Drawing.Color.Transparent;
			this.storeItemCell1.ForeColor = System.Drawing.Color.Black;

			//this.storeItemCell1.ItemIconPath = null;

			this.storeItemCell1.Location = new System.Drawing.Point(0, 0);
			this.storeItemCell1.Name = "storeItemCell1";
			this.storeItemCell1.RightText = "";

			this.storeItemCell1.ShowRightText = true;
			this.storeItemCell1.Size = new System.Drawing.Size(382, 55);
			this.storeItemCell1.StoreBundleCount = 2;
			this.storeItemCell1.TabIndex = 0;
	
			// 
			// SearcherScene
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(439, 274);
			this.Controls.Add(this.storeListPreview1);
			this.MaximizeBox = false;
			this.Name = "SearcherScene";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "搜索";
			//this.Load += new System.EventHandler(this.SearcherScene_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private Store.StoreListPreview storeListPreview1;
		private Store.Cell.ItemListCell storeItemCell1;
	}
}