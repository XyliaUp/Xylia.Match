
namespace Xylia.Preview.Project.Core.ItemGrowth.Scene
{
	partial class ItemGrowthScene
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemGrowthScene));
			this.itemGrowth2Page1 = new Xylia.Preview.Project.Core.ItemGrowth.Page.ItemGrowth2Page();
			this.SuspendLayout();
			// 
			// itemGrowth2Page1
			// 
			this.itemGrowth2Page1.BackColor = System.Drawing.Color.Transparent;
			this.itemGrowth2Page1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("itemGrowth2Page1.BackgroundImage")));
			this.itemGrowth2Page1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.itemGrowth2Page1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.itemGrowth2Page1.Location = new System.Drawing.Point(0, 0);
			this.itemGrowth2Page1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
			this.itemGrowth2Page1.Name = "itemGrowth2Page1";
			this.itemGrowth2Page1.Size = new System.Drawing.Size(684, 698);
			this.itemGrowth2Page1.TabIndex = 0;
			// 
			// ItemGrowthScene
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(684, 698);
			this.Controls.Add(this.itemGrowth2Page1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.KeyPreview = true;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MaximizeBox = false;
			this.Name = "ItemGrowthScene";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "提炼";
			this.SizeChanged += new System.EventHandler(this.ItemGrowthScene_SizeChanged);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ItemGrowthScene_KeyDown);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ItemGrowthScene_KeyUp);
			this.ResumeLayout(false);

		}

		#endregion

		private Page.ItemGrowth2Page itemGrowth2Page1;
	}
}