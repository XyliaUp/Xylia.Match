namespace Xylia.Match.Windows.Forms
{
    partial class PublicSet
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PublicSet));
			this.colorDialog1 = new System.Windows.Forms.ColorDialog();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.Folder = new System.Windows.Forms.FolderBrowserDialog();
			this.FolderTabPage = new MetroFramework.Controls.MetroTabPage();
			this.lbl_Region = new System.Windows.Forms.Label();
			this.GRoot_Searcher = new MetroFramework.Controls.MetroButton();
			this.GRoot_Path = new System.Windows.Forms.TextBox();
			this.GRoot_Note = new System.Windows.Forms.Label();
			this.Faster_Folder_Btn = new MetroFramework.Controls.MetroButton();
			this.Faster_Folder_Path = new System.Windows.Forms.TextBox();
			this.Faster_Folder_Note = new System.Windows.Forms.Label();
			this.SettingsTabControl = new MetroFramework.Controls.MetroTabControl();
			this.FolderTabPage.SuspendLayout();
			this.SettingsTabControl.SuspendLayout();
			this.SuspendLayout();
			// 
			// colorDialog1
			// 
			this.colorDialog1.AnyColor = true;
			this.colorDialog1.FullOpen = true;
			// 
			// FolderTabPage
			// 
			this.FolderTabPage.Controls.Add(this.lbl_Region);
			this.FolderTabPage.Controls.Add(this.GRoot_Searcher);
			this.FolderTabPage.Controls.Add(this.GRoot_Path);
			this.FolderTabPage.Controls.Add(this.GRoot_Note);
			this.FolderTabPage.Controls.Add(this.Faster_Folder_Btn);
			this.FolderTabPage.Controls.Add(this.Faster_Folder_Path);
			this.FolderTabPage.Controls.Add(this.Faster_Folder_Note);
			this.FolderTabPage.HorizontalScrollbarBarColor = true;
			this.FolderTabPage.HorizontalScrollbarSize = 14;
			this.FolderTabPage.Location = new System.Drawing.Point(4, 36);
			this.FolderTabPage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.FolderTabPage.Name = "FolderTabPage";
			this.FolderTabPage.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.FolderTabPage.Size = new System.Drawing.Size(476, 227);
			this.FolderTabPage.TabIndex = 4;
			this.FolderTabPage.Text = "目录";
			this.FolderTabPage.UseVisualStyleBackColor = true;
			this.FolderTabPage.VerticalScrollbarBarColor = true;
			this.FolderTabPage.VerticalScrollbarSize = 12;
			// 
			// lbl_Region
			// 
			this.lbl_Region.AutoSize = true;
			this.lbl_Region.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.lbl_Region.Location = new System.Drawing.Point(117, 76);
			this.lbl_Region.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbl_Region.Name = "lbl_Region";
			this.lbl_Region.Size = new System.Drawing.Size(104, 17);
			this.lbl_Region.TabIndex = 16;
			this.lbl_Region.Text = "客户端所属区域：";
			this.lbl_Region.Visible = false;
			// 
			// GRoot_Searcher
			// 
			this.GRoot_Searcher.Location = new System.Drawing.Point(363, 40);
			this.GRoot_Searcher.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.GRoot_Searcher.Name = "GRoot_Searcher";
			this.GRoot_Searcher.Size = new System.Drawing.Size(88, 33);
			this.GRoot_Searcher.TabIndex = 15;
			this.GRoot_Searcher.Text = "选择目录";
			this.GRoot_Searcher.Click += new System.EventHandler(this.button1_Click);
			// 
			// GRoot_Path
			// 
			this.GRoot_Path.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.GRoot_Path.Location = new System.Drawing.Point(6, 42);
			this.GRoot_Path.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.GRoot_Path.Name = "GRoot_Path";
			this.GRoot_Path.Size = new System.Drawing.Size(336, 23);
			this.GRoot_Path.TabIndex = 11;
			this.GRoot_Path.TextChanged += new System.EventHandler(this.GRoot_Path_TextChanged);
			// 
			// GRoot_Note
			// 
			this.GRoot_Note.AutoSize = true;
			this.GRoot_Note.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.GRoot_Note.Location = new System.Drawing.Point(7, 21);
			this.GRoot_Note.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.GRoot_Note.Name = "GRoot_Note";
			this.GRoot_Note.Size = new System.Drawing.Size(92, 17);
			this.GRoot_Note.TabIndex = 13;
			this.GRoot_Note.Text = "设置游戏根目录";
			// 
			// Faster_Folder_Btn
			// 
			this.Faster_Folder_Btn.Location = new System.Drawing.Point(363, 150);
			this.Faster_Folder_Btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.Faster_Folder_Btn.Name = "Faster_Folder_Btn";
			this.Faster_Folder_Btn.Size = new System.Drawing.Size(88, 33);
			this.Faster_Folder_Btn.TabIndex = 12;
			this.Faster_Folder_Btn.Text = "选择目录";
			this.Faster_Folder_Btn.Click += new System.EventHandler(this.Faster_Folder_Btn_Click);
			// 
			// Faster_Folder_Path
			// 
			this.Faster_Folder_Path.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.Faster_Folder_Path.Location = new System.Drawing.Point(6, 150);
			this.Faster_Folder_Path.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.Faster_Folder_Path.Name = "Faster_Folder_Path";
			this.Faster_Folder_Path.Size = new System.Drawing.Size(336, 23);
			this.Faster_Folder_Path.TabIndex = 15;
			this.Faster_Folder_Path.TextChanged += new System.EventHandler(this.Faster_Folder_Path_TextChanged);
			// 
			// Faster_Folder_Note
			// 
			this.Faster_Folder_Note.AutoSize = true;
			this.Faster_Folder_Note.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.Faster_Folder_Note.Location = new System.Drawing.Point(7, 129);
			this.Faster_Folder_Note.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.Faster_Folder_Note.Name = "Faster_Folder_Note";
			this.Faster_Folder_Note.Size = new System.Drawing.Size(113, 17);
			this.Faster_Folder_Note.TabIndex = 10;
			this.Faster_Folder_Note.Text = "信息/资源 存储目录";
			// 
			// SettingsTabControl
			// 
			this.SettingsTabControl.Controls.Add(this.FolderTabPage);
			this.SettingsTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SettingsTabControl.Location = new System.Drawing.Point(23, 85);
			this.SettingsTabControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.SettingsTabControl.Multiline = true;
			this.SettingsTabControl.Name = "SettingsTabControl";
			this.SettingsTabControl.Padding = new System.Drawing.Point(6, 8);
			this.SettingsTabControl.SelectedIndex = 0;
			this.SettingsTabControl.Size = new System.Drawing.Size(484, 267);
			this.SettingsTabControl.TabIndex = 4;
			this.SettingsTabControl.SelectedIndexChanged += new System.EventHandler(this.SettingsTabControl_SelectedIndexChanged);
			// 
			// PublicSet
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(530, 380);
			this.Controls.Add(this.SettingsTabControl);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "PublicSet";
			this.Padding = new System.Windows.Forms.Padding(23, 85, 23, 28);
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "设置";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PublicSet_FormClosed);
			this.Load += new System.EventHandler(this.SettingsForm_Load);
			this.MouseEnter += new System.EventHandler(this.SettingsForm_MouseEnter);
			this.FolderTabPage.ResumeLayout(false);
			this.FolderTabPage.PerformLayout();
			this.SettingsTabControl.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.FolderBrowserDialog Folder;
		private MetroFramework.Controls.MetroTabPage FolderTabPage;
		private System.Windows.Forms.Label lbl_Region;
		private MetroFramework.Controls.MetroButton GRoot_Searcher;
		private System.Windows.Forms.TextBox GRoot_Path;
		private System.Windows.Forms.Label GRoot_Note;
		private MetroFramework.Controls.MetroButton Faster_Folder_Btn;
		private System.Windows.Forms.TextBox Faster_Folder_Path;
		private System.Windows.Forms.Label Faster_Folder_Note;
		private MetroFramework.Controls.MetroTabControl SettingsTabControl;
	}
}