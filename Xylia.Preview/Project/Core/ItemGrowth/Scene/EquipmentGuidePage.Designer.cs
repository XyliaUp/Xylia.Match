
namespace Xylia.Preview.Project.Core.ItemGrowth.Page
{
	partial class EquipmentGuidePage
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EquipmentGuidePage));
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.MyWeapon_Title = new System.Windows.Forms.Label();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.MyWeapon_Name = new Xylia.Preview.Project.Core.Item.Cell.Basic.ItemNameCell();
			this.MyWeapon_Icon = new Xylia.Preview.Project.Core.Item.Cell.Basic.ItemIconCell();
			this.WarningPreview = new Xylia.Preview.Project.Core.ItemGrowth.Preview.WarningPreview();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.MyWeapon_Icon)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(313, 238);
			this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(64, 64);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 2;
			this.pictureBox1.TabStop = false;
			// 
			// MyWeapon_Title
			// 
			this.MyWeapon_Title.AutoSize = true;
			this.MyWeapon_Title.BackColor = System.Drawing.Color.Transparent;
			this.MyWeapon_Title.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.MyWeapon_Title.ForeColor = System.Drawing.Color.White;
			this.MyWeapon_Title.Location = new System.Drawing.Point(42, 17);
			this.MyWeapon_Title.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.MyWeapon_Title.Name = "MyWeapon_Title";
			this.MyWeapon_Title.Size = new System.Drawing.Size(74, 21);
			this.MyWeapon_Title.TabIndex = 11;
			this.MyWeapon_Title.Text = "当前装备";
			// 
			// pictureBox2
			// 
			this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
			this.pictureBox2.Location = new System.Drawing.Point(28, 59);
			this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(96, 72);
			this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox2.TabIndex = 22;
			this.pictureBox2.TabStop = false;
			// 
			// MyWeapon_Name
			// 
			this.MyWeapon_Name.AutoSize = true;
			this.MyWeapon_Name.BackColor = System.Drawing.Color.Transparent;
			this.MyWeapon_Name.Font = new System.Drawing.Font("Microsoft YaHei UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.MyWeapon_Name.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(119)))), ((int)(((byte)(10)))));
			this.MyWeapon_Name.ItemGrade = ((byte)(7));
			this.MyWeapon_Name.Location = new System.Drawing.Point(42, 136);
			this.MyWeapon_Name.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
			this.MyWeapon_Name.Name = "MyWeapon_Name";
			this.MyWeapon_Name.Size = new System.Drawing.Size(63, 19);
			this.MyWeapon_Name.TabIndex = 23;
			this.MyWeapon_Name.TagImage = null;
			this.MyWeapon_Name.Text = "物品名称";
			// 
			// MyWeapon_Icon
			// 
			this.MyWeapon_Icon.BackColor = System.Drawing.Color.Transparent;
			this.MyWeapon_Icon.ExtraBottomLeft = null;
			this.MyWeapon_Icon.ExtraBottomRight = null;
			this.MyWeapon_Icon.ExtraTopLeft = null;
			this.MyWeapon_Icon.ExtraTopRight = null;
			this.MyWeapon_Icon.ForeColor = System.Drawing.Color.Black;
			this.MyWeapon_Icon.FrameImage = null;
			this.MyWeapon_Icon.FrameType = true;
			this.MyWeapon_Icon.ItemIcon = null;
			this.MyWeapon_Icon.Location = new System.Drawing.Point(43, 62);
			this.MyWeapon_Icon.Margin = new System.Windows.Forms.Padding(4);
			this.MyWeapon_Icon.Name = "MyWeapon_Icon";
			this.MyWeapon_Icon.Scale = 64;
			this.MyWeapon_Icon.ShowStackCount = false;
			this.MyWeapon_Icon.ShowStackCountOnlyOne = true;
			this.MyWeapon_Icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.MyWeapon_Icon.StackCount = 1;
			this.MyWeapon_Icon.TabIndex = 21;
			this.MyWeapon_Icon.TabStop = false;
			// 
			// WarningPreview
			// 
			this.WarningPreview.AutoSize = true;
			this.WarningPreview.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.WarningPreview.BackColor = System.Drawing.Color.Transparent;
			this.WarningPreview.Location = new System.Drawing.Point(274, 651);
			this.WarningPreview.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			this.WarningPreview.Name = "WarningPreview";
			this.WarningPreview.Size = new System.Drawing.Size(103, 30);
			this.WarningPreview.TabIndex = 20;
			this.WarningPreview.Visible = false;
			// 
			// EquipmentGuidePage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Transparent;
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.Controls.Add(this.MyWeapon_Name);
			this.Controls.Add(this.MyWeapon_Icon);
			this.Controls.Add(this.WarningPreview);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.MyWeapon_Title);
			this.Controls.Add(this.pictureBox2);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "EquipmentGuidePage";
			this.Size = new System.Drawing.Size(680, 700);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.MyWeapon_Icon)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label MyWeapon_Title;
		public Preview.WarningPreview WarningPreview;
		private Item.Cell.Basic.ItemIconCell MyWeapon_Icon;
		private System.Windows.Forms.PictureBox pictureBox2;
		private Item.Cell.Basic.ItemNameCell MyWeapon_Name;
		protected System.Windows.Forms.PictureBox pictureBox1;
	}
}
