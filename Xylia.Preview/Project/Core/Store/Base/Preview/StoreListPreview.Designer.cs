namespace Xylia.Preview.Project.Core.Store
{
	partial class StoreListPreview
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
			this.components = new System.ComponentModel.Container();
			this.MainMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.SaveAsImage = new System.Windows.Forms.ToolStripMenuItem();
			this.MainMenu.SuspendLayout();
			this.SuspendLayout();
			// 

			// 
			// MainMenu
			// 
			this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveAsImage});
			this.MainMenu.Name = "Menu";
			this.MainMenu.Size = new System.Drawing.Size(137, 26);
			// 
			// SaveAsImage
			// 
			this.SaveAsImage.Name = "SaveAsImage";
			this.SaveAsImage.Size = new System.Drawing.Size(136, 22);
			this.SaveAsImage.Text = "存储为图片";
			this.SaveAsImage.Click += new System.EventHandler(this.SaveAsImage_Click);
			// 
			// StoreListPreview
			// 
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(26)))), ((int)(((byte)(35)))));
			this.ContextMenuStrip = this.MainMenu;
			this.Size = new System.Drawing.Size(10, 10);
			//this.SizeChanged += new System.EventHandler(this.StoreListPreview_SizeChanged);

			this.MainMenu.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.ToolStripMenuItem SaveAsImage;
		public System.Windows.Forms.ContextMenuStrip MainMenu;
	}
}
