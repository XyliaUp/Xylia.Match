namespace Xylia.Match.Windows.Panel
{
    partial class MatchLocal
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MatchLocal));
			this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
			this.Path_Local1 = new System.Windows.Forms.TextBox();
			this.metroButton2 = new MetroFramework.Controls.MetroButton();
			this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
			this.metroButton1 = new MetroFramework.Controls.MetroButton();
			this.Btn_OutLocal_2 = new MetroFramework.Controls.MetroButton();
			this.Path_Local2 = new System.Windows.Forms.TextBox();
			this.Btn_OutLocal_1 = new MetroFramework.Controls.MetroButton();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.Open = new System.Windows.Forms.OpenFileDialog();
			this.Save = new System.Windows.Forms.SaveFileDialog();
			this.Btn_StartWithEnd = new HZH_Controls.Controls.UCBtnExt();
			this.Step1 = new HZH_Controls.Controls.UCStep();
			this.Chk_OnlyNew = new HZH_Controls.Controls.UCSwitch();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// metroLabel1
			// 
			this.metroLabel1.AutoSize = true;
			this.metroLabel1.Location = new System.Drawing.Point(12, 8);
			this.metroLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.metroLabel1.Name = "metroLabel1";
			this.metroLabel1.Size = new System.Drawing.Size(178, 19);
			this.metroLabel1.TabIndex = 89;
			this.metroLabel1.Text = "请选择旧版本 local.dat 文件";
			// 
			// Path_Local1
			// 
			this.Path_Local1.Location = new System.Drawing.Point(12, 42);
			this.Path_Local1.Margin = new System.Windows.Forms.Padding(4);
			this.Path_Local1.Name = "Path_Local1";
			this.Path_Local1.Size = new System.Drawing.Size(473, 23);
			this.Path_Local1.TabIndex = 86;
			this.Path_Local1.TextChanged += new System.EventHandler(this.Path_Local1_TextChanged);
			// 
			// metroButton2
			// 
			this.metroButton2.Location = new System.Drawing.Point(492, 42);
			this.metroButton2.Margin = new System.Windows.Forms.Padding(4);
			this.metroButton2.Name = "metroButton2";
			this.metroButton2.Size = new System.Drawing.Size(88, 33);
			this.metroButton2.TabIndex = 87;
			this.metroButton2.Text = "选择文件";
			this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
			// 
			// metroLabel2
			// 
			this.metroLabel2.AutoSize = true;
			this.metroLabel2.Location = new System.Drawing.Point(12, 74);
			this.metroLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.metroLabel2.Name = "metroLabel2";
			this.metroLabel2.Size = new System.Drawing.Size(178, 19);
			this.metroLabel2.TabIndex = 90;
			this.metroLabel2.Text = "请选择新版本 local.dat 文件";
			// 
			// metroButton1
			// 
			this.metroButton1.Location = new System.Drawing.Point(492, 109);
			this.metroButton1.Margin = new System.Windows.Forms.Padding(4);
			this.metroButton1.Name = "metroButton1";
			this.metroButton1.Size = new System.Drawing.Size(88, 33);
			this.metroButton1.TabIndex = 88;
			this.metroButton1.Text = "选择文件";
			this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
			// 
			// Btn_OutLocal_2
			// 
			this.Btn_OutLocal_2.Location = new System.Drawing.Point(597, 109);
			this.Btn_OutLocal_2.Margin = new System.Windows.Forms.Padding(4);
			this.Btn_OutLocal_2.Name = "Btn_OutLocal_2";
			this.Btn_OutLocal_2.Size = new System.Drawing.Size(88, 33);
			this.Btn_OutLocal_2.TabIndex = 95;
			this.Btn_OutLocal_2.Text = "导出汉化";
			this.Btn_OutLocal_2.Click += new System.EventHandler(this.Btn_OutLocal_2_Click);
			// 
			// Path_Local2
			// 
			this.Path_Local2.Location = new System.Drawing.Point(12, 110);
			this.Path_Local2.Margin = new System.Windows.Forms.Padding(4);
			this.Path_Local2.Name = "Path_Local2";
			this.Path_Local2.Size = new System.Drawing.Size(473, 23);
			this.Path_Local2.TabIndex = 92;
			this.Path_Local2.TextChanged += new System.EventHandler(this.Path_Local2_TextChanged);
			// 
			// Btn_OutLocal_1
			// 
			this.Btn_OutLocal_1.Location = new System.Drawing.Point(597, 42);
			this.Btn_OutLocal_1.Margin = new System.Windows.Forms.Padding(4);
			this.Btn_OutLocal_1.Name = "Btn_OutLocal_1";
			this.Btn_OutLocal_1.Size = new System.Drawing.Size(88, 33);
			this.Btn_OutLocal_1.TabIndex = 94;
			this.Btn_OutLocal_1.Text = "导出汉化";
			this.Btn_OutLocal_1.Click += new System.EventHandler(this.Btn_OutLocal_1_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(768, 150);
			this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(46, 52);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 93;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
			// 
			// Open
			// 
			this.Open.FileOk += new System.ComponentModel.CancelEventHandler(this.Open_FileOk);
			// 
			// Btn_StartWithEnd
			// 
			this.Btn_StartWithEnd.BtnBackColor = System.Drawing.Color.Empty;
			this.Btn_StartWithEnd.BtnFont = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.Btn_StartWithEnd.BtnForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.Btn_StartWithEnd.BtnText = "开始";
			this.Btn_StartWithEnd.ConerRadius = 8;
			this.Btn_StartWithEnd.Cursor = System.Windows.Forms.Cursors.Hand;
			this.Btn_StartWithEnd.DialogResult = System.Windows.Forms.DialogResult.None;
			this.Btn_StartWithEnd.EnabledMouseEffect = false;
			this.Btn_StartWithEnd.FillColor = System.Drawing.Color.White;
			this.Btn_StartWithEnd.Font = new System.Drawing.Font("Microsoft YaHei UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.Btn_StartWithEnd.IsRadius = true;
			this.Btn_StartWithEnd.IsShowRect = true;
			this.Btn_StartWithEnd.IsShowTips = false;
			this.Btn_StartWithEnd.Location = new System.Drawing.Point(714, 68);
			this.Btn_StartWithEnd.Margin = new System.Windows.Forms.Padding(0);
			this.Btn_StartWithEnd.Name = "Btn_StartWithEnd";
			this.Btn_StartWithEnd.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.Btn_StartWithEnd.RectWidth = 1;
			this.Btn_StartWithEnd.Size = new System.Drawing.Size(100, 48);
			this.Btn_StartWithEnd.TabIndex = 101;
			this.Btn_StartWithEnd.TabStop = false;
			this.Btn_StartWithEnd.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
			this.Btn_StartWithEnd.TipsText = "";
			this.Btn_StartWithEnd.BtnClick += new System.EventHandler(this.Btn_End_BtnClick);
			// 
			// Step1
			// 
			this.Step1.BackColor = System.Drawing.Color.Transparent;
			this.Step1.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.Step1.ImgCompleted = ((System.Drawing.Image)(resources.GetObject("Step1.ImgCompleted")));
			this.Step1.LineWidth = 2;
			this.Step1.Location = new System.Drawing.Point(8, 246);
			this.Step1.Margin = new System.Windows.Forms.Padding(4);
			this.Step1.Name = "Step1";
			this.Step1.ReadOnly = true;
			this.Step1.Size = new System.Drawing.Size(805, 91);
			this.Step1.StepBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
			this.Step1.StepFontColor = System.Drawing.Color.White;
			this.Step1.StepForeColor = System.Drawing.Color.Pink;
			this.Step1.StepIndex = 0;
			this.Step1.Steps = new string[] {
        "准备",
        "解析",
        "执行",
        "结束"};
			this.Step1.StepWidth = 32;
			this.Step1.TabIndex = 102;
			// 
			// Chk_OnlyNew
			// 
			this.Chk_OnlyNew.BackColor = System.Drawing.Color.Transparent;
			this.Chk_OnlyNew.Checked = false;
			this.Chk_OnlyNew.FalseColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
			this.Chk_OnlyNew.FalseTextColr = System.Drawing.Color.White;
			this.Chk_OnlyNew.Location = new System.Drawing.Point(492, 163);
			this.Chk_OnlyNew.Margin = new System.Windows.Forms.Padding(4);
			this.Chk_OnlyNew.Name = "Chk_OnlyNew";
			this.Chk_OnlyNew.Size = new System.Drawing.Size(88, 40);
			this.Chk_OnlyNew.SwitchType = HZH_Controls.Controls.SwitchType.Ellipse;
			this.Chk_OnlyNew.TabIndex = 103;
			this.Chk_OnlyNew.Texts = new string[] {
        "解析",
        "原始"};
			this.Chk_OnlyNew.TrueColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			this.Chk_OnlyNew.TrueTextColr = System.Drawing.Color.Black;
			this.Chk_OnlyNew.Visible = false;
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Checked = true;
			this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.checkBox1.Location = new System.Drawing.Point(597, 163);
			this.checkBox1.Margin = new System.Windows.Forms.Padding(4);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(87, 21);
			this.checkBox1.TabIndex = 104;
			this.checkBox1.Text = "带编号模式";
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// MatchLocal
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.Chk_OnlyNew);
			this.Controls.Add(this.Step1);
			this.Controls.Add(this.Btn_StartWithEnd);
			this.Controls.Add(this.metroLabel1);
			this.Controls.Add(this.Path_Local1);
			this.Controls.Add(this.metroButton2);
			this.Controls.Add(this.metroLabel2);
			this.Controls.Add(this.metroButton1);
			this.Controls.Add(this.Btn_OutLocal_2);
			this.Controls.Add(this.Path_Local2);
			this.Controls.Add(this.Btn_OutLocal_1);
			this.Controls.Add(this.pictureBox1);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "MatchLocal";
			this.Size = new System.Drawing.Size(855, 442);
			this.Load += new System.EventHandler(this.MatchLocal_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.TextBox Path_Local1;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroButton Btn_OutLocal_2;
        private System.Windows.Forms.TextBox Path_Local2;
        private MetroFramework.Controls.MetroButton Btn_OutLocal_1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.OpenFileDialog Open;
        private System.Windows.Forms.SaveFileDialog Save;
        private HZH_Controls.Controls.UCBtnExt Btn_StartWithEnd;
        private HZH_Controls.Controls.UCStep Step1;
        private HZH_Controls.Controls.UCSwitch Chk_OnlyNew;
		private System.Windows.Forms.CheckBox checkBox1;
	}
}
