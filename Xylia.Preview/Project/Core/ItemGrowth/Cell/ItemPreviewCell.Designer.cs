
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
			this.itemNameCell1 = new Xylia.Preview.Project.Core.Item.Cell.Basic.ItemNameCell();
			this.feedItemIconCell1 = new Xylia.Preview.Project.Core.ItemGrowth.Cell.FeedItemIconCell();
			((System.ComponentModel.ISupportInitialize)(this.feedItemIconCell1)).BeginInit();
			this.SuspendLayout();
			// 
			// itemNameCell1
			// 
			this.itemNameCell1.AutoSize = true;
			this.itemNameCell1.BackColor = System.Drawing.Color.Transparent;
			this.itemNameCell1.Font = new System.Drawing.Font("Microsoft YaHei UI", 11F);
			this.itemNameCell1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(178)))), ((int)(((byte)(72)))));
			this.itemNameCell1.ItemGrade = 6;
			this.itemNameCell1.Location = new System.Drawing.Point(10, 84);
			this.itemNameCell1.Margin = new System.Windows.Forms.Padding(5);
			this.itemNameCell1.Name = "itemNameCell1";
			this.itemNameCell1.Size = new System.Drawing.Size(78, 20);
			this.itemNameCell1.TabIndex = 24;
			this.itemNameCell1.TagImage = null;
			this.itemNameCell1.Text = "ItemName";
			// 
			// feedItemIconCell1
			// 
			this.feedItemIconCell1.FrameImage = ((System.Drawing.Bitmap)(resources.GetObject("feedItemIconCell1.FrameImage")));
			this.feedItemIconCell1.Location = new System.Drawing.Point(5, -7);
			this.feedItemIconCell1.Name = "feedItemIconCell1";
			this.feedItemIconCell1.ShowFrameImage = false;
			this.feedItemIconCell1.ShowStackCount = false;
			this.feedItemIconCell1.ShowStackCountOnlyOne = false;
			this.feedItemIconCell1.Size = new System.Drawing.Size(88, 96);
			this.feedItemIconCell1.StackCount = ((uint)(0u));
			this.feedItemIconCell1.TabIndex = 25;
			this.feedItemIconCell1.TabStop = false;
			// 
			// ItemPreviewCell
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = System.Drawing.Color.Black;
			this.Controls.Add(this.itemNameCell1);
			this.Controls.Add(this.feedItemIconCell1);
			this.Name = "ItemPreviewCell";
			this.Size = new System.Drawing.Size(96, 109);
			this.SizeChanged += new System.EventHandler(this.ItemPreviewCell_SizeChanged);
			this.Click += new System.EventHandler(this.ItemPreviewCell_Click);
			((System.ComponentModel.ISupportInitialize)(this.feedItemIconCell1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		public Item.Cell.Basic.ItemNameCell itemNameCell1;
		public FeedItemIconCell feedItemIconCell1;
	}
}
