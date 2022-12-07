namespace Xylia.Match.Windows.Panel.Item
{
	partial class ItemForm
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
			this.preview = new Xylia.Match.Windows.Panel.Item.Preview();
			this.SuspendLayout();
			// 
			// preview
			// 
			this.preview.AccountUsed = true;
			this.preview.Alias = null;
			this.preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(21)))));
			this.preview.Category = "Category";
			this.preview.Description2 = "description2";
			this.preview.Description7 = "description7";
			this.preview.Dock = System.Windows.Forms.DockStyle.Fill;
			this.preview.Id = null;
			this.preview.ItemGrade = 8;
			this.preview.ItemName = "ItemName";
			this.preview.Location = new System.Drawing.Point(0, 0);
			this.preview.Name = "preview";
			this.preview.Size = new System.Drawing.Size(413, 756);
			this.preview.TabIndex = 0;
			this.preview.Trade = "交易属性";
			// 
			// ItemForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(21)))));
			this.ClientSize = new System.Drawing.Size(413, 756);
			this.Controls.Add(this.preview);
			this.ForeColor = System.Drawing.SystemColors.Window;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "ItemForm";
			this.Opacity = 0.97D;
			this.ShowIcon = false;
			this.Text = "ItemInfo_物品信息说明";
			this.TransparencyKey = System.Drawing.Color.Transparent;
			this.Load += new System.EventHandler(this.ItemForm_Load);
			this.ResumeLayout(false);

		}

		#endregion

		public Preview preview;
	}
}