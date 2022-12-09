
namespace Xylia.Preview.Project.Core.ItemGrowth.Cell
{
	partial class ItemPreviewCell
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemPreviewCell));
			this.ItemName = new Xylia.Preview.Project.Core.Item.Cell.Basic.ItemNameCell();
			this.ItemIcon = new Xylia.Preview.Project.Core.ItemGrowth.Cell.FeedItemIconCell();
			((System.ComponentModel.ISupportInitialize)(this.ItemIcon)).BeginInit();
			this.SuspendLayout();
			// 
			// ItemName
			// 
			this.ItemName.AutoSize = true;
			this.ItemName.BackColor = System.Drawing.Color.Transparent;
			this.ItemName.Font = new System.Drawing.Font("Microsoft YaHei UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.ItemName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(178)))), ((int)(((byte)(72)))));
			this.ItemName.ItemGrade = ((byte)(6));
			this.ItemName.Location = new System.Drawing.Point(5, 99);
			this.ItemName.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
			this.ItemName.Name = "ItemName";
			this.ItemName.Size = new System.Drawing.Size(78, 19);
			this.ItemName.TabIndex = 24;
			this.ItemName.TagImage = null;
			this.ItemName.Text = "ItemName";
			// 
			// ItemIcon
			// 
			this.ItemIcon.FrameImage = ((System.Drawing.Bitmap)(resources.GetObject("ItemIcon.FrameImage")));
			this.ItemIcon.Location = new System.Drawing.Point(0, 0);
			this.ItemIcon.Margin = new System.Windows.Forms.Padding(4);
			this.ItemIcon.Name = "ItemIcon";
			this.ItemIcon.ShowFrameImage = false;
			this.ItemIcon.ShowStackCount = false;
			this.ItemIcon.ShowStackCountOnlyOne = false;
			this.ItemIcon.Size = new System.Drawing.Size(90, 98);
			this.ItemIcon.StackCount = 0;
			this.ItemIcon.TabIndex = 25;
			this.ItemIcon.TabStop = false;
			// 
			// ItemPreviewCell
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = System.Drawing.Color.Black;
			this.Controls.Add(this.ItemName);
			this.Controls.Add(this.ItemIcon);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "ItemPreviewCell";
			this.Size = new System.Drawing.Size(94, 125);
			((System.ComponentModel.ISupportInitialize)(this.ItemIcon)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		public Item.Cell.Basic.ItemNameCell ItemName;
		public FeedItemIconCell ItemIcon;
	}
}
