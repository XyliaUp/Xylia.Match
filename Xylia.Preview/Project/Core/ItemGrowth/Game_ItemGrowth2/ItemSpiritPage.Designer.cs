
namespace Xylia.Preview.Project.Core.ItemGrowth.Page
{
	partial class ItemSpiritPage
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemSpiritPage));
			this.ItemGrowth2Panel_AbilityDescription_WeaponName_1 = new System.Windows.Forms.PictureBox();
			this.label4 = new System.Windows.Forms.Label();
			this.contentPanel1 = new Xylia.Preview.Project.Controls.ContentPanel();
			this.GrowthState = new Xylia.Preview.Project.Controls.ContentPanel();
			((System.ComponentModel.ISupportInitialize)(this.ItemGrowth2Panel_AbilityDescription_WeaponName_1)).BeginInit();
			this.ItemGrowth2Panel_AbilityDescription_WeaponName_1.SuspendLayout();
			this.SuspendLayout();
			// 
			// MoneyCostPreview
			// 
			this.MoneyCostPreview.UseDiscount = false;
			// 
			// SubIngredientPreview
			// 
			this.SubIngredientPreview.Visible = false;
			// 
			// SubIngredientTitle
			// 
			this.SubIngredientTitle.Visible = false;
			// 
			// ItemGrowth2Panel_AbilityDescription_WeaponName_1
			// 
			this.ItemGrowth2Panel_AbilityDescription_WeaponName_1.Controls.Add(this.label4);
			this.ItemGrowth2Panel_AbilityDescription_WeaponName_1.Image = ((System.Drawing.Image)(resources.GetObject("ItemGrowth2Panel_AbilityDescription_WeaponName_1.Image")));
			this.ItemGrowth2Panel_AbilityDescription_WeaponName_1.Location = new System.Drawing.Point(231, 192);
			this.ItemGrowth2Panel_AbilityDescription_WeaponName_1.Name = "ItemGrowth2Panel_AbilityDescription_WeaponName_1";
			this.ItemGrowth2Panel_AbilityDescription_WeaponName_1.Size = new System.Drawing.Size(233, 30);
			this.ItemGrowth2Panel_AbilityDescription_WeaponName_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.ItemGrowth2Panel_AbilityDescription_WeaponName_1.TabIndex = 27;
			this.ItemGrowth2Panel_AbilityDescription_WeaponName_1.TabStop = false;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.ForeColor = System.Drawing.Color.White;
			this.label4.Location = new System.Drawing.Point(88, 5);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(56, 17);
			this.label4.TabIndex = 28;
			this.label4.Text = "传授属性";
			// 
			// contentPanel1
			// 
			this.contentPanel1.BackColor = System.Drawing.Color.Transparent;
			this.contentPanel1.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.contentPanel1.ForeColor = System.Drawing.Color.White;
			this.contentPanel1.Location = new System.Drawing.Point(293, 230);
			this.contentPanel1.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
			this.contentPanel1.Name = "contentPanel1";
			this.contentPanel1.TabIndex = 28;
			this.contentPanel1.Text = "降魔攻击力 1~999\r\n暴击伤害 1~999";
			// 
			// GrowthState
			// 
			this.GrowthState.BackColor = System.Drawing.Color.Transparent;
			this.GrowthState.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.GrowthState.ForeColor = System.Drawing.Color.White;
			this.GrowthState.Location = new System.Drawing.Point(320, 80);
			this.GrowthState.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
			this.GrowthState.Name = "GrowthState";
			this.GrowthState.TabIndex = 32;
			this.GrowthState.Text = "<font name=\"00008130.ItemGrowth_Probability_28\">传授</font>";
			// 
			// ItemSpiritPage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.Controls.Add(this.GrowthState);
			this.Controls.Add(this.contentPanel1);
			this.Controls.Add(this.ItemGrowth2Panel_AbilityDescription_WeaponName_1);
			this.Name = "ItemSpiritPage";
			this.Controls.SetChildIndex(this.SubIngredientTitle, 0);
			this.Controls.SetChildIndex(this.MoneyCostPreview, 0);
			this.Controls.SetChildIndex(this.FixedIngredientPreview, 0);
			this.Controls.SetChildIndex(this.SubIngredientPreview, 0);
			this.Controls.SetChildIndex(this.WarningPreview, 0);
			this.Controls.SetChildIndex(this.ItemGrowth2Panel_AbilityDescription_WeaponName_1, 0);
			this.Controls.SetChildIndex(this.contentPanel1, 0);
			this.Controls.SetChildIndex(this.GrowthState, 0);
			((System.ComponentModel.ISupportInitialize)(this.ItemGrowth2Panel_AbilityDescription_WeaponName_1)).EndInit();
			this.ItemGrowth2Panel_AbilityDescription_WeaponName_1.ResumeLayout(false);
			this.ItemGrowth2Panel_AbilityDescription_WeaponName_1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		private System.Windows.Forms.PictureBox ItemGrowth2Panel_AbilityDescription_WeaponName_1;
		private System.Windows.Forms.Label label4;
		private Controls.ContentPanel contentPanel1;
		protected Controls.ContentPanel GrowthState;
	}
}
