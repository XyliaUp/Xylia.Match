
namespace Xylia.Preview.Project.Core.ItemGrowth.Preview
{
	partial class ResultWeaponPreview
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResultWeaponPreview));
			this.Btn_Next = new System.Windows.Forms.PictureBox();
			this.Btn_Prev = new System.Windows.Forms.PictureBox();
			this.itemPreviewCell1 = new Xylia.Preview.Project.Core.ItemGrowth.Cell.ItemPreviewCell();
			((System.ComponentModel.ISupportInitialize)(this.Btn_Next)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Btn_Prev)).BeginInit();
			this.SuspendLayout();
			// 
			// Btn_Next
			// 
			this.Btn_Next.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Next.Image")));
			this.Btn_Next.Location = new System.Drawing.Point(380, 16);
			this.Btn_Next.Name = "Btn_Next";
			this.Btn_Next.Size = new System.Drawing.Size(32, 60);
			this.Btn_Next.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.Btn_Next.TabIndex = 15;
			this.Btn_Next.TabStop = false;
			// 
			// Btn_Prev
			// 
			this.Btn_Prev.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Prev.Image")));
			this.Btn_Prev.Location = new System.Drawing.Point(0, 16);
			this.Btn_Prev.Name = "Btn_Prev";
			this.Btn_Prev.Size = new System.Drawing.Size(32, 60);
			this.Btn_Prev.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.Btn_Prev.TabIndex = 16;
			this.Btn_Prev.TabStop = false;
			// 
			// itemPreviewCell1
			// 
			this.itemPreviewCell1.BackColor = System.Drawing.Color.Transparent;
			this.itemPreviewCell1.FrameImage = ((System.Drawing.Bitmap)(resources.GetObject("itemPreviewCell1.FrameImage")));
			this.itemPreviewCell1.Grade = 6;
			this.itemPreviewCell1.Icon = null;
			this.itemPreviewCell1.ItemInfo = null;
			this.itemPreviewCell1.Location = new System.Drawing.Point(38, 0);
			this.itemPreviewCell1.Name = "itemPreviewCell1";
			this.itemPreviewCell1.ShowFrameImage = true;
			this.itemPreviewCell1.ShowStackCount = false;
			this.itemPreviewCell1.Size = new System.Drawing.Size(99, 107);
			this.itemPreviewCell1.TabIndex = 17;
			this.itemPreviewCell1.Text = "测试文本";
			// 
			// ResultWeaponPreview
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.BackColor = System.Drawing.Color.Transparent;
			this.Controls.Add(this.itemPreviewCell1);
			this.Controls.Add(this.Btn_Prev);
			this.Controls.Add(this.Btn_Next);
			this.Name = "ResultWeaponPreview";
			this.Size = new System.Drawing.Size(415, 164);
			this.SizeChanged += new System.EventHandler(this.ResultWeaponPreview_SizeChanged);
			((System.ComponentModel.ISupportInitialize)(this.Btn_Next)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Btn_Prev)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.PictureBox Btn_Next;
		private System.Windows.Forms.PictureBox Btn_Prev;
		private Cell.ItemPreviewCell itemPreviewCell1;
	}
}
