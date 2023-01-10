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
			this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
			this.Path_Local2 = new System.Windows.Forms.TextBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.Open = new System.Windows.Forms.OpenFileDialog();
			this.Save = new System.Windows.Forms.SaveFileDialog();
			this.Btn_StartWithEnd = new HZH_Controls.Controls.UCBtnExt();
			this.Step1 = new HZH_Controls.Controls.UCStep();
			this.Chk_OnlyNew = new HZH_Controls.Controls.UCSwitch();
			this.ucBtnFillet2 = new HZH_Controls.Controls.UCBtnFillet();
			this.ucBtnFillet1 = new HZH_Controls.Controls.UCBtnFillet();
			this.ucBtnFillet3 = new HZH_Controls.Controls.UCBtnFillet();
			this.ucBtnFillet4 = new HZH_Controls.Controls.UCBtnFillet();
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
			// Path_Local2
			// 
			this.Path_Local2.Location = new System.Drawing.Point(12, 110);
			this.Path_Local2.Margin = new System.Windows.Forms.Padding(4);
			this.Path_Local2.Name = "Path_Local2";
			this.Path_Local2.Size = new System.Drawing.Size(473, 23);
			this.Path_Local2.TabIndex = 92;
			this.Path_Local2.TextChanged += new System.EventHandler(this.Path_Local2_TextChanged);
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
			// ucBtnFillet2
			// 
			this.ucBtnFillet2.BackColor = System.Drawing.Color.Transparent;
			this.ucBtnFillet2.BtnFont = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.ucBtnFillet2.BtnImage = ((System.Drawing.Image)(resources.GetObject("ucBtnFillet2.BtnImage")));
			this.ucBtnFillet2.BtnText = "输出";
			this.ucBtnFillet2.ConerRadius = 10;
			this.ucBtnFillet2.FillColor = System.Drawing.Color.Transparent;
			this.ucBtnFillet2.Font = new System.Drawing.Font("Microsoft YaHei UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.ucBtnFillet2.IsRadius = true;
			this.ucBtnFillet2.IsShowRect = true;
			this.ucBtnFillet2.Location = new System.Drawing.Point(598, 37);
			this.ucBtnFillet2.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
			this.ucBtnFillet2.Name = "ucBtnFillet2";
			this.ucBtnFillet2.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
			this.ucBtnFillet2.RectWidth = 1;
			this.ucBtnFillet2.Size = new System.Drawing.Size(94, 30);
			this.ucBtnFillet2.TabIndex = 112;
			this.ucBtnFillet2.BtnClick += new System.EventHandler(this.Btn_OutLocal_1_Click);
			// 
			// ucBtnFillet1
			// 
			this.ucBtnFillet1.BackColor = System.Drawing.Color.Transparent;
			this.ucBtnFillet1.BtnFont = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.ucBtnFillet1.BtnImage = ((System.Drawing.Image)(resources.GetObject("ucBtnFillet1.BtnImage")));
			this.ucBtnFillet1.BtnText = "选择";
			this.ucBtnFillet1.ConerRadius = 10;
			this.ucBtnFillet1.FillColor = System.Drawing.Color.Transparent;
			this.ucBtnFillet1.Font = new System.Drawing.Font("Microsoft YaHei UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.ucBtnFillet1.IsRadius = true;
			this.ucBtnFillet1.IsShowRect = true;
			this.ucBtnFillet1.Location = new System.Drawing.Point(494, 37);
			this.ucBtnFillet1.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
			this.ucBtnFillet1.Name = "ucBtnFillet1";
			this.ucBtnFillet1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
			this.ucBtnFillet1.RectWidth = 1;
			this.ucBtnFillet1.Size = new System.Drawing.Size(94, 30);
			this.ucBtnFillet1.TabIndex = 111;
			this.ucBtnFillet1.BtnClick += new System.EventHandler(this.metroButton2_Click);
			// 
			// ucBtnFillet3
			// 
			this.ucBtnFillet3.BackColor = System.Drawing.Color.Transparent;
			this.ucBtnFillet3.BtnFont = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.ucBtnFillet3.BtnImage = ((System.Drawing.Image)(resources.GetObject("ucBtnFillet3.BtnImage")));
			this.ucBtnFillet3.BtnText = "输出";
			this.ucBtnFillet3.ConerRadius = 10;
			this.ucBtnFillet3.FillColor = System.Drawing.Color.Transparent;
			this.ucBtnFillet3.Font = new System.Drawing.Font("Microsoft YaHei UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.ucBtnFillet3.IsRadius = true;
			this.ucBtnFillet3.IsShowRect = true;
			this.ucBtnFillet3.Location = new System.Drawing.Point(598, 108);
			this.ucBtnFillet3.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
			this.ucBtnFillet3.Name = "ucBtnFillet3";
			this.ucBtnFillet3.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
			this.ucBtnFillet3.RectWidth = 1;
			this.ucBtnFillet3.Size = new System.Drawing.Size(94, 30);
			this.ucBtnFillet3.TabIndex = 114;
			this.ucBtnFillet3.BtnClick += new System.EventHandler(this.Btn_OutLocal_2_Click);
			// 
			// ucBtnFillet4
			// 
			this.ucBtnFillet4.BackColor = System.Drawing.Color.Transparent;
			this.ucBtnFillet4.BtnFont = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.ucBtnFillet4.BtnImage = ((System.Drawing.Image)(resources.GetObject("ucBtnFillet4.BtnImage")));
			this.ucBtnFillet4.BtnText = "选择";
			this.ucBtnFillet4.ConerRadius = 10;
			this.ucBtnFillet4.FillColor = System.Drawing.Color.Transparent;
			this.ucBtnFillet4.Font = new System.Drawing.Font("Microsoft YaHei UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.ucBtnFillet4.IsRadius = true;
			this.ucBtnFillet4.IsShowRect = true;
			this.ucBtnFillet4.Location = new System.Drawing.Point(494, 108);
			this.ucBtnFillet4.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
			this.ucBtnFillet4.Name = "ucBtnFillet4";
			this.ucBtnFillet4.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
			this.ucBtnFillet4.RectWidth = 1;
			this.ucBtnFillet4.Size = new System.Drawing.Size(94, 30);
			this.ucBtnFillet4.TabIndex = 113;
			this.ucBtnFillet4.BtnClick += new System.EventHandler(this.metroButton1_Click);
			// 
			// MatchLocal
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.ucBtnFillet3);
			this.Controls.Add(this.ucBtnFillet4);
			this.Controls.Add(this.ucBtnFillet2);
			this.Controls.Add(this.ucBtnFillet1);
			this.Controls.Add(this.Chk_OnlyNew);
			this.Controls.Add(this.Step1);
			this.Controls.Add(this.Btn_StartWithEnd);
			this.Controls.Add(this.metroLabel1);
			this.Controls.Add(this.Path_Local1);
			this.Controls.Add(this.metroLabel2);
			this.Controls.Add(this.Path_Local2);
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
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private System.Windows.Forms.TextBox Path_Local2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.OpenFileDialog Open;
        private System.Windows.Forms.SaveFileDialog Save;
        private HZH_Controls.Controls.UCBtnExt Btn_StartWithEnd;
        private HZH_Controls.Controls.UCStep Step1;
        private HZH_Controls.Controls.UCSwitch Chk_OnlyNew;
		private HZH_Controls.Controls.UCBtnFillet ucBtnFillet2;
		private HZH_Controls.Controls.UCBtnFillet ucBtnFillet1;
		private HZH_Controls.Controls.UCBtnFillet ucBtnFillet3;
		private HZH_Controls.Controls.UCBtnFillet ucBtnFillet4;
	}
}
