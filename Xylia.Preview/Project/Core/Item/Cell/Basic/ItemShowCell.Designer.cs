namespace Xylia.Preview.Project.Core.Item.Cell.Basic
{
	partial class ItemShowCell
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemShowCell));
			this.ItemNameCell = new Xylia.Preview.Project.Core.Item.Cell.Basic.ItemNameCell();
			this.IconCell = new Xylia.Preview.Project.Core.Item.Cell.Basic.ItemIconCell();
			((System.ComponentModel.ISupportInitialize)(this.IconCell)).BeginInit();
			this.SuspendLayout();
			// 
			// ItemNameCell
			// 
			this.ItemNameCell.AutoSize = true;
			this.ItemNameCell.BackColor = System.Drawing.Color.Transparent;
			this.ItemNameCell.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.ItemNameCell.ItemGrade = ((byte)(7));
			this.ItemNameCell.Location = new System.Drawing.Point(63, 16);
			this.ItemNameCell.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
			this.ItemNameCell.Name = "ItemNameCell";
			this.ItemNameCell.Size = new System.Drawing.Size(85, 22);
			this.ItemNameCell.TabIndex = 1;
			this.ItemNameCell.TagImage = null;
			this.ItemNameCell.Text = "ItemName";
			this.ItemNameCell.NameChanged += new Xylia.Preview.Project.Core.Item.Cell.Basic.ItemNameCell.NameChangedHandle(this.ItemName_NameChanged);
		
			this.ItemNameCell.DoubleClick += new System.EventHandler(this.ItemName_DoubleClick);
			// 
			// IconCell
			// 
			this.IconCell.BackColor = System.Drawing.Color.Transparent;
			this.IconCell.ExtraBottomLeft = null;
			this.IconCell.ExtraBottomRight = null;
			this.IconCell.ExtraTopLeft = null;
			this.IconCell.ExtraTopRight = null;
			this.IconCell.ForeColor = System.Drawing.Color.Black;
			this.IconCell.FrameImage = null;
			this.IconCell.FrameType = true;
			this.IconCell.Image = ((System.Drawing.Bitmap)(resources.GetObject("IconCell.ItemIcon")));
			this.IconCell.Location = new System.Drawing.Point(0, 0);
			this.IconCell.Margin = new System.Windows.Forms.Padding(4);
			this.IconCell.Name = "IconCell";
			this.IconCell.Scale = 52;
			this.IconCell.ShowStackCount = false;
			this.IconCell.ShowStackCountOnlyOne = true;
			this.IconCell.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.IconCell.StackCount = 1;
			this.IconCell.TabIndex = 2;
			this.IconCell.TabStop = false;
			// 
			// ItemShowCell
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = System.Drawing.Color.Transparent;
			this.Controls.Add(this.IconCell);
			this.Controls.Add(this.ItemNameCell);
			this.ForeColor = System.Drawing.Color.Black;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "ItemShowCell";
			this.Size = new System.Drawing.Size(154, 56);
			
			((System.ComponentModel.ISupportInitialize)(this.IconCell)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		public ItemNameCell ItemNameCell;
		public ItemIconCell IconCell;
	}
}
