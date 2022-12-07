namespace Xylia.Preview.Project.Core.Item.Scene
{
    partial class DataGridScene
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
			this.ucDataGridView1 = new HZH_Controls.Controls.UCDataGridView();
			this.SuspendLayout();
			// 
			// ucDataGridView1
			// 
			this.ucDataGridView1.AutoScroll = true;
			this.ucDataGridView1.BackColor = System.Drawing.Color.White;
			this.ucDataGridView1.Columns = null;
			this.ucDataGridView1.DataSource = null;
			this.ucDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ucDataGridView1.HeadFont = new System.Drawing.Font("微软雅黑", 12F);
			this.ucDataGridView1.HeadHeight = 40;
			this.ucDataGridView1.HeadPadingLeft = 0;
			this.ucDataGridView1.HeadTextColor = System.Drawing.Color.Black;
			this.ucDataGridView1.IsShowCheckBox = false;
			this.ucDataGridView1.IsShowHead = true;
			this.ucDataGridView1.Location = new System.Drawing.Point(0, 0);
			this.ucDataGridView1.Name = "ucDataGridView1";
			this.ucDataGridView1.RowHeight = 40;
			this.ucDataGridView1.RowType = typeof(HZH_Controls.Controls.UCDataGridViewRow);
			this.ucDataGridView1.Size = new System.Drawing.Size(720, 422);
			this.ucDataGridView1.TabIndex = 0;
			// 
			// DataGridScene
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(720, 422);
			this.Controls.Add(this.ucDataGridView1);
			this.DoubleBuffered = true;
			this.ForeColor = System.Drawing.Color.DimGray;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "DataGridScene";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "查看字段";
			this.Shown += new System.EventHandler(this.Form1_Shown);
			this.ResumeLayout(false);

        }

		#endregion

		//private Xylia.Preview.Project.Controls.PanelEx.PanelContent panelContent1;
		//private Project.Core.Item.Cell.Basic.FrameIconCell frameIconCell1;
		private Project.Core.Item.Cell.Basic.ItemNameCell itemNameCell1;
		private HZH_Controls.Controls.UCDataGridView ucDataGridView1;
	}
}

