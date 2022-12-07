﻿
namespace Xylia.Preview.Project.Core.ItemGrowth.Page
{
	partial class ItemGrowth2Page
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemGrowth2Page));
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.MyWeapon_Title = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.MyWeapon_Name = new Xylia.Preview.Project.Core.Item.Cell.Basic.ItemNameCell();
			this.itemIconCell1 = new Xylia.Preview.Project.Core.Item.Cell.Basic.ItemIconCell();
			this.warningPreview1 = new Xylia.Preview.Project.Core.ItemGrowth.Preview.WarningPreview();
			this.fixedIngredientPreview1 = new Xylia.Preview.Project.Core.ItemGrowth.Preview.FixedIngredientPreview();
			this.moneyCostPreview1 = new Xylia.Preview.Project.Core.ItemGrowth.Preview.MoneyCostPreview();
			this.resultWeaponPreview1 = new Xylia.Preview.Project.Core.ItemGrowth.Preview.ResultWeaponPreview();
			this.subIngredientPreview1 = new Xylia.Preview.Project.Core.ItemGrowth.Preview.SubIngredientPreview();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.itemIconCell1)).BeginInit();
			this.fixedIngredientPreview1.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(313, 187);
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
			this.MyWeapon_Title.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.MyWeapon_Title.ForeColor = System.Drawing.Color.White;
			this.MyWeapon_Title.Location = new System.Drawing.Point(36, 12);
			this.MyWeapon_Title.Name = "MyWeapon_Title";
			this.MyWeapon_Title.Size = new System.Drawing.Size(74, 21);
			this.MyWeapon_Title.TabIndex = 11;
			this.MyWeapon_Title.Text = "当前装备";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(285, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(74, 21);
			this.label1.TabIndex = 17;
			this.label1.Text = "目标装备";
			// 
			// pictureBox2
			// 
			this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
			this.pictureBox2.Location = new System.Drawing.Point(24, 51);
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
			this.MyWeapon_Name.Font = new System.Drawing.Font("微软雅黑", 11F);
			this.MyWeapon_Name.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(119)))), ((int)(((byte)(10)))));
			this.MyWeapon_Name.ItemGrade = 7;
			this.MyWeapon_Name.Location = new System.Drawing.Point(40, 126);
			this.MyWeapon_Name.Margin = new System.Windows.Forms.Padding(5);
			this.MyWeapon_Name.Name = "MyWeapon_Name";
			this.MyWeapon_Name.Size = new System.Drawing.Size(63, 20);
			this.MyWeapon_Name.TabIndex = 23;
			this.MyWeapon_Name.TagImage = null;
			this.MyWeapon_Name.Text = "物品名称";
			// 
			// itemIconCell1
			// 
			this.itemIconCell1.BackColor = System.Drawing.Color.Transparent;
			this.itemIconCell1.ExtraBottomLeft = null;
			this.itemIconCell1.ExtraBottomRight = null;
			this.itemIconCell1.ExtraTopLeft = null;
			this.itemIconCell1.ExtraTopRight = null;
			this.itemIconCell1.ForeColor = System.Drawing.Color.Black;
			this.itemIconCell1.FrameImage = null;
			this.itemIconCell1.ItemIcon = null;
			this.itemIconCell1.Location = new System.Drawing.Point(40, 55);
			this.itemIconCell1.Name = "itemIconCell1";
			this.itemIconCell1.Scale = 63;
			this.itemIconCell1.ShowStackCount = false;
			this.itemIconCell1.ShowStackCountOnlyOne = true;
			this.itemIconCell1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.itemIconCell1.StackCount = ((uint)(1u));
			this.itemIconCell1.TabIndex = 21;
			this.itemIconCell1.TabStop = false;
			// 
			// warningPreview1
			// 
			this.warningPreview1.AutoSize = true;
			this.warningPreview1.BackColor = System.Drawing.Color.Transparent;
			this.warningPreview1.Location = new System.Drawing.Point(217, 639);
			this.warningPreview1.Name = "warningPreview1";
			this.warningPreview1.Size = new System.Drawing.Size(221, 35);
			this.warningPreview1.TabIndex = 20;
			this.warningPreview1.Type = Xylia.Preview.Data.Record.ItemTransformRecipe.Warning.Stuck;
			// 
			// fixedIngredientPreview1
			// 
			this.fixedIngredientPreview1.BackColor = System.Drawing.Color.Transparent;
			this.fixedIngredientPreview1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.fixedIngredientPreview1.Controls.Add(this.moneyCostPreview1);
			this.fixedIngredientPreview1.Location = new System.Drawing.Point(3, 425);
			this.fixedIngredientPreview1.Name = "fixedIngredientPreview1";
			this.fixedIngredientPreview1.Size = new System.Drawing.Size(673, 208);
			this.fixedIngredientPreview1.TabIndex = 0;
			// 
			// moneyCostPreview1
			// 
			this.moneyCostPreview1.AutoSize = true;
			this.moneyCostPreview1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.moneyCostPreview1.BackColor = System.Drawing.Color.Transparent;
			this.moneyCostPreview1.Location = new System.Drawing.Point(136, 145);
			this.moneyCostPreview1.MaximumSize = new System.Drawing.Size(400, 0);
			this.moneyCostPreview1.MoneyCost = ((int)(3000ul));
			this.moneyCostPreview1.Name = "moneyCostPreview1";
			this.moneyCostPreview1.Size = new System.Drawing.Size(400, 50);
			this.moneyCostPreview1.TabIndex = 12;
			// 
			// resultWeaponPreview1
			// 
			this.resultWeaponPreview1.BackColor = System.Drawing.Color.Transparent;
			this.resultWeaponPreview1.Location = new System.Drawing.Point(198, 43);
			this.resultWeaponPreview1.Name = "resultWeaponPreview1";
			this.resultWeaponPreview1.Size = new System.Drawing.Size(478, 138);
			this.resultWeaponPreview1.TabIndex = 0;
			// 
			// subIngredientPreview1
			// 
			this.subIngredientPreview1.BackColor = System.Drawing.Color.Transparent;
			this.subIngredientPreview1.Location = new System.Drawing.Point(3, 312);
			this.subIngredientPreview1.Name = "subIngredientPreview1";
			this.subIngredientPreview1.Size = new System.Drawing.Size(673, 107);
			this.subIngredientPreview1.TabIndex = 1;
			// 
			// ItemGrowth2Page
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.BackColor = System.Drawing.Color.Transparent;
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.Controls.Add(this.MyWeapon_Name);
			this.Controls.Add(this.itemIconCell1);
			this.Controls.Add(this.warningPreview1);
			this.Controls.Add(this.fixedIngredientPreview1);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.MyWeapon_Title);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.resultWeaponPreview1);
			this.Controls.Add(this.subIngredientPreview1);
			this.Controls.Add(this.pictureBox2);
			this.Name = "ItemGrowth2Page";
			this.Size = new System.Drawing.Size(679, 703);
			this.SizeChanged += new System.EventHandler(this.ItemGrowth2Page_SizeChanged);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.itemIconCell1)).EndInit();
			this.fixedIngredientPreview1.ResumeLayout(false);
			this.fixedIngredientPreview1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Preview.FixedIngredientPreview fixedIngredientPreview1;
		private Preview.SubIngredientPreview subIngredientPreview1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label MyWeapon_Title;
		private Preview.MoneyCostPreview moneyCostPreview1;
		private System.Windows.Forms.Label label1;
		private Preview.ResultWeaponPreview resultWeaponPreview1;
		private Preview.WarningPreview warningPreview1;
		private Item.Cell.Basic.ItemIconCell itemIconCell1;
		private System.Windows.Forms.PictureBox pictureBox2;
		private Item.Cell.Basic.ItemNameCell MyWeapon_Name;
	}
}
