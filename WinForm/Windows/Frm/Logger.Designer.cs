namespace Xylia.Windows
{
    partial class LoggerFrm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoggerFrm));
			this.ucDataGridView2 = new HZH_Controls.Controls.UCDataGridView();
			this.PublicTip = new System.Windows.Forms.ToolTip(this.components);
			this.SuspendLayout();
			// 
			// ucDataGridView2
			// 
			this.ucDataGridView2.AutoScroll = true;
			this.ucDataGridView2.BackColor = System.Drawing.Color.White;
			this.ucDataGridView2.Columns = null;
			this.ucDataGridView2.DataSource = null;
			this.ucDataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucDataGridView2.HeadFont = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.ucDataGridView2.HeadHeight = 40;
			this.ucDataGridView2.HeadPadingLeft = 0;
			this.ucDataGridView2.HeadTextColor = System.Drawing.Color.Black;
			this.ucDataGridView2.IsShowCheckBox = false;
			this.ucDataGridView2.IsShowHead = true;
			this.ucDataGridView2.Location = new System.Drawing.Point(0, 0);
			this.ucDataGridView2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.ucDataGridView2.Name = "ucDataGridView2";
			this.ucDataGridView2.RowHeight = 40;
			this.ucDataGridView2.RowType = typeof(HZH_Controls.Controls.UCDataGridViewRow);
			this.ucDataGridView2.Size = new System.Drawing.Size(755, 412);
			this.ucDataGridView2.TabIndex = 3;
			// 
			// LoggerFrm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(755, 412);
			this.Controls.Add(this.ucDataGridView2);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.Name = "LoggerFrm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "日志系统";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Logger_FormClosing);
			this.Load += new System.EventHandler(this.LoggerFrm_Load);
			this.ResumeLayout(false);

        }

        #endregion

        private HZH_Controls.Controls.UCDataGridView ucDataGridView2;
        private System.Windows.Forms.ToolTip PublicTip;

    }
}
