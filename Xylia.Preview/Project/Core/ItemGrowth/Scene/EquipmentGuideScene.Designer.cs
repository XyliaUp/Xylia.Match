
namespace Xylia.Preview.Project.Core.ItemGrowth.Scene
{
	partial class EquipmentGuideScene
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EquipmentGuideScene));
			this.TabControl = new System.Windows.Forms.TabControl();
			this.Page_ItemGrowth2 = new System.Windows.Forms.TabPage();
			this.equipmentGuidePage1 = new Xylia.Preview.Project.Core.ItemGrowth.Page.EquipmentGuidePage();
			this.Page_Intension = new System.Windows.Forms.TabPage();
			this.Page_IntensionResetConfirm = new System.Windows.Forms.TabPage();
			this.Page_ItemSpirit = new System.Windows.Forms.TabPage();
			this.TabControl.SuspendLayout();
			this.Page_ItemGrowth2.SuspendLayout();
			this.SuspendLayout();
			// 
			// TabControl
			// 
			this.TabControl.Controls.Add(this.Page_ItemGrowth2);
			this.TabControl.Controls.Add(this.Page_Intension);
			this.TabControl.Controls.Add(this.Page_IntensionResetConfirm);
			this.TabControl.Controls.Add(this.Page_ItemSpirit);
			this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TabControl.Location = new System.Drawing.Point(0, 0);
			this.TabControl.Margin = new System.Windows.Forms.Padding(4);
			this.TabControl.Name = "TabControl";
			this.TabControl.SelectedIndex = 0;
			this.TabControl.Size = new System.Drawing.Size(696, 743);
			this.TabControl.TabIndex = 5;
			// 
			// Page_ItemGrowth2
			// 
			this.Page_ItemGrowth2.BackColor = System.Drawing.Color.Black;
			this.Page_ItemGrowth2.Controls.Add(this.equipmentGuidePage1);
			this.Page_ItemGrowth2.Location = new System.Drawing.Point(4, 26);
			this.Page_ItemGrowth2.Margin = new System.Windows.Forms.Padding(4);
			this.Page_ItemGrowth2.Name = "Page_ItemGrowth2";
			this.Page_ItemGrowth2.Padding = new System.Windows.Forms.Padding(4);
			this.Page_ItemGrowth2.Size = new System.Drawing.Size(688, 713);
			this.Page_ItemGrowth2.TabIndex = 0;
			this.Page_ItemGrowth2.Text = "成长";
			// 
			// equipmentGuidePage1
			// 
			this.equipmentGuidePage1.BackColor = System.Drawing.Color.Transparent;
			this.equipmentGuidePage1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("equipmentGuidePage1.BackgroundImage")));
			this.equipmentGuidePage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.equipmentGuidePage1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.equipmentGuidePage1.Location = new System.Drawing.Point(4, 4);
			this.equipmentGuidePage1.Margin = new System.Windows.Forms.Padding(4);
			this.equipmentGuidePage1.Name = "equipmentGuidePage1";
			this.equipmentGuidePage1.Size = new System.Drawing.Size(680, 705);
			this.equipmentGuidePage1.TabIndex = 0;
			this.equipmentGuidePage1.Visible = false;
			// 
			// Page_Intension
			// 
			this.Page_Intension.BackColor = System.Drawing.Color.Black;
			this.Page_Intension.Location = new System.Drawing.Point(4, 26);
			this.Page_Intension.Margin = new System.Windows.Forms.Padding(4);
			this.Page_Intension.Name = "Page_Intension";
			this.Page_Intension.Padding = new System.Windows.Forms.Padding(4);
			this.Page_Intension.Size = new System.Drawing.Size(688, 713);
			this.Page_Intension.TabIndex = 1;
			this.Page_Intension.Text = "强化";
			// 
			// Page_IntensionResetConfirm
			// 
			this.Page_IntensionResetConfirm.BackColor = System.Drawing.Color.Black;
			this.Page_IntensionResetConfirm.Location = new System.Drawing.Point(4, 26);
			this.Page_IntensionResetConfirm.Margin = new System.Windows.Forms.Padding(4);
			this.Page_IntensionResetConfirm.Name = "Page_IntensionResetConfirm";
			this.Page_IntensionResetConfirm.Padding = new System.Windows.Forms.Padding(4);
			this.Page_IntensionResetConfirm.Size = new System.Drawing.Size(688, 713);
			this.Page_IntensionResetConfirm.TabIndex = 2;
			this.Page_IntensionResetConfirm.Text = "效果重设";
			// 
			// Page_ItemSpirit
			// 
			this.Page_ItemSpirit.BackColor = System.Drawing.Color.Black;
			this.Page_ItemSpirit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.Page_ItemSpirit.Location = new System.Drawing.Point(4, 26);
			this.Page_ItemSpirit.Name = "Page_ItemSpirit";
			this.Page_ItemSpirit.Size = new System.Drawing.Size(688, 713);
			this.Page_ItemSpirit.TabIndex = 3;
			this.Page_ItemSpirit.Text = "传授";
			// 
			// EquipmentGuideScene
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(696, 743);
			this.Controls.Add(this.TabControl);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.KeyPreview = true;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MaximizeBox = false;
			this.Name = "EquipmentGuideScene";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "装备管理";
			this.Load += new System.EventHandler(this.EquipmentGuideScene_Load);
			this.TabControl.ResumeLayout(false);
			this.Page_ItemGrowth2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl TabControl;
		private System.Windows.Forms.TabPage Page_IntensionResetConfirm;
		private System.Windows.Forms.TabPage Page_ItemGrowth2;
		private System.Windows.Forms.TabPage Page_Intension;
		private System.Windows.Forms.TabPage Page_ItemSpirit;
		private Page.EquipmentGuidePage equipmentGuidePage1;
	}
}