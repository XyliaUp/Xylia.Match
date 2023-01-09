namespace Xylia.Match.Windows.Panel
{
	partial class MatchProp
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MatchProp));
			this.TabControl = new System.Windows.Forms.TabControl();
			this.MainPage = new MetroFramework.Controls.MetroTabPage();
			this.Online_Searcher = new HZH_Controls.Controls.UCBtnFillet();
			this.lbl_Region = new System.Windows.Forms.Label();
			this.TimeInfo = new System.Windows.Forms.Label();
			this.Step1 = new HZH_Controls.Controls.UCStep();
			this.Chv_Path = new System.Windows.Forms.TextBox();
			this.Note_GRoot = new MetroFramework.Controls.MetroLabel();
			this.Btn_StartMatch = new HZH_Controls.Controls.UCBtnExt();
			this.GRoot_Path = new System.Windows.Forms.TextBox();
			this.Note_Chv = new MetroFramework.Controls.MetroLabel();
			this.Chk_OnlyNew = new HZH_Controls.Controls.UCSwitch();
			this.Switch_64Bit = new HZH_Controls.Controls.UCSwitch();
			this.File_Searcher = new HZH_Controls.Controls.UCBtnFillet();
			this.ucBtnFillet1 = new HZH_Controls.Controls.UCBtnFillet();
			this.PreviewPage_Item = new MetroFramework.Controls.MetroTabPage();
			this.Switch_Mode = new HZH_Controls.Controls.UCSwitch();
			this.ucBtnExt19 = new HZH_Controls.Controls.UCBtnExt();
			this.ItemPreview_Search = new HZH_Controls.Controls.UCTextBoxEx();
			this.ucBtnExt7 = new HZH_Controls.Controls.UCBtnExt();
			this.label4 = new System.Windows.Forms.Label();
			this.ucBtnExt5 = new HZH_Controls.Controls.UCBtnExt();
			this.ucBtnExt4 = new HZH_Controls.Controls.UCBtnExt();
			this.label1 = new System.Windows.Forms.Label();
			this.StateInfo = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.ucBtnExt3 = new HZH_Controls.Controls.UCBtnExt();
			this.PreviewPage_Else = new MetroFramework.Controls.MetroTabPage();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.ucBtnExt11 = new HZH_Controls.Controls.UCBtnExt();
			this.ucBtnExt1 = new HZH_Controls.Controls.UCBtnExt();
			this.ucBtnExt20 = new HZH_Controls.Controls.UCBtnExt();
			this.ucBtnExt9 = new HZH_Controls.Controls.UCBtnExt();
			this.ucBtnExt8 = new HZH_Controls.Controls.UCBtnExt();
			this.ucBtnExt13 = new HZH_Controls.Controls.UCBtnExt();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.ucBtnExt10 = new HZH_Controls.Controls.UCBtnExt();
			this.ucBtnExt18 = new HZH_Controls.Controls.UCBtnExt();
			this.ucBtnExt12 = new HZH_Controls.Controls.UCBtnExt();
			this.ucBtnExt14 = new HZH_Controls.Controls.UCBtnExt();
			this.ucBtnExt16 = new HZH_Controls.Controls.UCBtnExt();
			this.Timer = new System.Windows.Forms.Timer(this.components);
			this.Open = new System.Windows.Forms.OpenFileDialog();
			this.label3 = new System.Windows.Forms.Label();
			this.TabControl.SuspendLayout();
			this.MainPage.SuspendLayout();
			this.PreviewPage_Item.SuspendLayout();
			this.PreviewPage_Else.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// TabControl
			// 
			this.TabControl.Controls.Add(this.MainPage);
			this.TabControl.Controls.Add(this.PreviewPage_Item);
			this.TabControl.Controls.Add(this.PreviewPage_Else);
			this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TabControl.Location = new System.Drawing.Point(0, 0);
			this.TabControl.Margin = new System.Windows.Forms.Padding(4);
			this.TabControl.Name = "TabControl";
			this.TabControl.Padding = new System.Drawing.Point(6, 8);
			this.TabControl.SelectedIndex = 0;
			this.TabControl.Size = new System.Drawing.Size(854, 493);
			this.TabControl.TabIndex = 106;
			this.TabControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TabControl_KeyDown);
			// 
			// MainPage
			// 
			this.MainPage.Controls.Add(this.Online_Searcher);
			this.MainPage.Controls.Add(this.lbl_Region);
			this.MainPage.Controls.Add(this.TimeInfo);
			this.MainPage.Controls.Add(this.Step1);
			this.MainPage.Controls.Add(this.Chv_Path);
			this.MainPage.Controls.Add(this.Note_GRoot);
			this.MainPage.Controls.Add(this.Btn_StartMatch);
			this.MainPage.Controls.Add(this.GRoot_Path);
			this.MainPage.Controls.Add(this.Note_Chv);
			this.MainPage.Controls.Add(this.Chk_OnlyNew);
			this.MainPage.Controls.Add(this.Switch_64Bit);
			this.MainPage.Controls.Add(this.File_Searcher);
			this.MainPage.Controls.Add(this.ucBtnFillet1);
			this.MainPage.HorizontalScrollbarBarColor = true;
			this.MainPage.HorizontalScrollbarSize = 14;
			this.MainPage.Location = new System.Drawing.Point(4, 36);
			this.MainPage.Margin = new System.Windows.Forms.Padding(4);
			this.MainPage.Name = "MainPage";
			this.MainPage.Size = new System.Drawing.Size(846, 453);
			this.MainPage.TabIndex = 0;
			this.MainPage.Text = "物品数据";
			this.MainPage.VerticalScrollbarBarColor = true;
			this.MainPage.VerticalScrollbarSize = 12;
			this.MainPage.Visible = false;
			// 
			// Online_Searcher
			// 
			this.Online_Searcher.BackColor = System.Drawing.Color.Transparent;
			this.Online_Searcher.BtnFont = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.Online_Searcher.BtnImage = ((System.Drawing.Image)(resources.GetObject("Online_Searcher.BtnImage")));
			this.Online_Searcher.BtnText = "云端";
			this.Online_Searcher.ConerRadius = 10;
			this.Online_Searcher.FillColor = System.Drawing.Color.Transparent;
			this.Online_Searcher.Font = new System.Drawing.Font("Microsoft YaHei UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.Online_Searcher.IsRadius = true;
			this.Online_Searcher.IsShowRect = true;
			this.Online_Searcher.Location = new System.Drawing.Point(445, 108);
			this.Online_Searcher.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
			this.Online_Searcher.Name = "Online_Searcher";
			this.Online_Searcher.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
			this.Online_Searcher.RectWidth = 1;
			this.Online_Searcher.Size = new System.Drawing.Size(94, 37);
			this.Online_Searcher.TabIndex = 92;
			this.Online_Searcher.Visible = false;
			this.Online_Searcher.BtnClick += new System.EventHandler(this.Online_Searcher_BtnClick);
			this.Online_Searcher.BtnMouseEnter += new System.EventHandler(this.Online_Searcher_BtnMouseEnter);
			this.Online_Searcher.BtnMouseLeave += new System.EventHandler(this.CloseTip);
			this.Online_Searcher.MouseLeave += new System.EventHandler(this.CloseTip);
			// 
			// lbl_Region
			// 
			this.lbl_Region.AutoSize = true;
			this.lbl_Region.BackColor = System.Drawing.Color.Transparent;
			this.lbl_Region.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.lbl_Region.Location = new System.Drawing.Point(391, 48);
			this.lbl_Region.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbl_Region.Name = "lbl_Region";
			this.lbl_Region.Size = new System.Drawing.Size(48, 19);
			this.lbl_Region.TabIndex = 91;
			this.lbl_Region.Text = "地区：";
			// 
			// TimeInfo
			// 
			this.TimeInfo.AutoSize = true;
			this.TimeInfo.BackColor = System.Drawing.SystemColors.Window;
			this.TimeInfo.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.TimeInfo.Location = new System.Drawing.Point(13, 347);
			this.TimeInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.TimeInfo.Name = "TimeInfo";
			this.TimeInfo.Size = new System.Drawing.Size(78, 21);
			this.TimeInfo.TabIndex = 105;
			this.TimeInfo.Text = "TimeInfo";
			this.TimeInfo.Visible = false;
			this.TimeInfo.TextChanged += new System.EventHandler(this.TimeInfo_TextChanged);
			// 
			// Step1
			// 
			this.Step1.BackColor = System.Drawing.Color.Transparent;
			this.Step1.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.Step1.ImgCompleted = ((System.Drawing.Image)(resources.GetObject("Step1.ImgCompleted")));
			this.Step1.LineWidth = 2;
			this.Step1.Location = new System.Drawing.Point(13, 252);
			this.Step1.Margin = new System.Windows.Forms.Padding(4);
			this.Step1.Name = "Step1";
			this.Step1.ReadOnly = true;
			this.Step1.Size = new System.Drawing.Size(805, 91);
			this.Step1.StepBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
			this.Step1.StepFontColor = System.Drawing.Color.White;
			this.Step1.StepForeColor = System.Drawing.Color.Pink;
			this.Step1.StepIndex = 0;
			this.Step1.Steps = new string[] {
        "准备开始",
        "解析资源",
        "执行输出",
        "结束操作"};
			this.Step1.StepWidth = 32;
			this.Step1.TabIndex = 96;
			// 
			// Chv_Path
			// 
			this.Chv_Path.Location = new System.Drawing.Point(18, 111);
			this.Chv_Path.Margin = new System.Windows.Forms.Padding(4);
			this.Chv_Path.Name = "Chv_Path";
			this.Chv_Path.Size = new System.Drawing.Size(521, 23);
			this.Chv_Path.TabIndex = 102;
			// 
			// Note_GRoot
			// 
			this.Note_GRoot.AutoSize = true;
			this.Note_GRoot.BackColor = System.Drawing.Color.Transparent;
			this.Note_GRoot.Location = new System.Drawing.Point(18, 17);
			this.Note_GRoot.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.Note_GRoot.Name = "Note_GRoot";
			this.Note_GRoot.Size = new System.Drawing.Size(79, 19);
			this.Note_GRoot.TabIndex = 89;
			this.Note_GRoot.Text = "游戏根目录";
			// 
			// Btn_StartMatch
			// 
			this.Btn_StartMatch.BtnBackColor = System.Drawing.Color.Empty;
			this.Btn_StartMatch.BtnFont = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.Btn_StartMatch.BtnForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.Btn_StartMatch.BtnText = "生成数据";
			this.Btn_StartMatch.ConerRadius = 8;
			this.Btn_StartMatch.Cursor = System.Windows.Forms.Cursors.Hand;
			this.Btn_StartMatch.DialogResult = System.Windows.Forms.DialogResult.None;
			this.Btn_StartMatch.EnabledMouseEffect = false;
			this.Btn_StartMatch.FillColor = System.Drawing.Color.White;
			this.Btn_StartMatch.Font = new System.Drawing.Font("Microsoft YaHei UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.Btn_StartMatch.IsRadius = true;
			this.Btn_StartMatch.IsShowRect = true;
			this.Btn_StartMatch.IsShowTips = false;
			this.Btn_StartMatch.Location = new System.Drawing.Point(676, 71);
			this.Btn_StartMatch.Margin = new System.Windows.Forms.Padding(0);
			this.Btn_StartMatch.Name = "Btn_StartMatch";
			this.Btn_StartMatch.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.Btn_StartMatch.RectWidth = 1;
			this.Btn_StartMatch.Size = new System.Drawing.Size(108, 48);
			this.Btn_StartMatch.TabIndex = 99;
			this.Btn_StartMatch.TabStop = false;
			this.Btn_StartMatch.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
			this.Btn_StartMatch.TipsText = "";
			this.Btn_StartMatch.BtnClick += new System.EventHandler(this.Btn_StartMatch_BtnClick);
			// 
			// GRoot_Path
			// 
			this.GRoot_Path.Location = new System.Drawing.Point(16, 46);
			this.GRoot_Path.Margin = new System.Windows.Forms.Padding(4);
			this.GRoot_Path.Name = "GRoot_Path";
			this.GRoot_Path.Size = new System.Drawing.Size(523, 23);
			this.GRoot_Path.TabIndex = 87;
			this.GRoot_Path.TextChanged += new System.EventHandler(this.GRoot_Path_TextChanged);
			// 
			// Note_Chv
			// 
			this.Note_Chv.AutoSize = true;
			this.Note_Chv.BackColor = System.Drawing.Color.Transparent;
			this.Note_Chv.Location = new System.Drawing.Point(18, 88);
			this.Note_Chv.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.Note_Chv.Name = "Note_Chv";
			this.Note_Chv.Size = new System.Drawing.Size(283, 19);
			this.Note_Chv.TabIndex = 90;
			this.Note_Chv.Text = "请选择.chv文件 （若无请取消勾选“仅更新”）";
			// 
			// Chk_OnlyNew
			// 
			this.Chk_OnlyNew.BackColor = System.Drawing.Color.Transparent;
			this.Chk_OnlyNew.Checked = true;
			this.Chk_OnlyNew.FalseColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
			this.Chk_OnlyNew.FalseTextColr = System.Drawing.Color.White;
			this.Chk_OnlyNew.Location = new System.Drawing.Point(18, 152);
			this.Chk_OnlyNew.Margin = new System.Windows.Forms.Padding(4);
			this.Chk_OnlyNew.Name = "Chk_OnlyNew";
			this.Chk_OnlyNew.Size = new System.Drawing.Size(100, 44);
			this.Chk_OnlyNew.SwitchType = HZH_Controls.Controls.SwitchType.Ellipse;
			this.Chk_OnlyNew.TabIndex = 98;
			this.Chk_OnlyNew.Texts = new string[] {
        "仅更新 ",
        "全部   "};
			this.Chk_OnlyNew.TrueColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			this.Chk_OnlyNew.TrueTextColr = System.Drawing.Color.Black;
			this.Chk_OnlyNew.CheckedChanged += new System.EventHandler(this.Chk_OnlyNew_CheckedChanged);
			// 
			// Switch_64Bit
			// 
			this.Switch_64Bit.BackColor = System.Drawing.Color.Transparent;
			this.Switch_64Bit.Checked = false;
			this.Switch_64Bit.FalseColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
			this.Switch_64Bit.FalseTextColr = System.Drawing.Color.White;
			this.Switch_64Bit.Location = new System.Drawing.Point(153, 152);
			this.Switch_64Bit.Margin = new System.Windows.Forms.Padding(4);
			this.Switch_64Bit.Name = "Switch_64Bit";
			this.Switch_64Bit.Size = new System.Drawing.Size(100, 44);
			this.Switch_64Bit.SwitchType = HZH_Controls.Controls.SwitchType.Ellipse;
			this.Switch_64Bit.TabIndex = 97;
			this.Switch_64Bit.Texts = new string[] {
        "64位   ",
        "32位   "};
			this.Switch_64Bit.TrueColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			this.Switch_64Bit.TrueTextColr = System.Drawing.Color.Black;
			// 
			// File_Searcher
			// 
			this.File_Searcher.BackColor = System.Drawing.Color.Transparent;
			this.File_Searcher.BtnFont = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.File_Searcher.BtnImage = ((System.Drawing.Image)(resources.GetObject("File_Searcher.BtnImage")));
			this.File_Searcher.BtnText = "本地";
			this.File_Searcher.ConerRadius = 10;
			this.File_Searcher.FillColor = System.Drawing.Color.Transparent;
			this.File_Searcher.Font = new System.Drawing.Font("Microsoft YaHei UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.File_Searcher.IsRadius = true;
			this.File_Searcher.IsShowRect = true;
			this.File_Searcher.Location = new System.Drawing.Point(554, 108);
			this.File_Searcher.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
			this.File_Searcher.Name = "File_Searcher";
			this.File_Searcher.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
			this.File_Searcher.RectWidth = 1;
			this.File_Searcher.Size = new System.Drawing.Size(96, 37);
			this.File_Searcher.TabIndex = 93;
			this.File_Searcher.BtnClick += new System.EventHandler(this.File_Searcher_BtnClick);
			this.File_Searcher.BtnMouseEnter += new System.EventHandler(this.File_Searcher_MouseEnter);
			this.File_Searcher.BtnMouseLeave += new System.EventHandler(this.CloseTip);
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
			this.ucBtnFillet1.Location = new System.Drawing.Point(554, 44);
			this.ucBtnFillet1.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
			this.ucBtnFillet1.Name = "ucBtnFillet1";
			this.ucBtnFillet1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
			this.ucBtnFillet1.RectWidth = 1;
			this.ucBtnFillet1.Size = new System.Drawing.Size(94, 37);
			this.ucBtnFillet1.TabIndex = 94;
			this.ucBtnFillet1.BtnClick += new System.EventHandler(this.ucBtnFillet1_BtnClick);
			// 
			// PreviewPage_Item
			// 
			this.PreviewPage_Item.BackColor = System.Drawing.Color.Transparent;
			this.PreviewPage_Item.Controls.Add(this.Switch_Mode);
			this.PreviewPage_Item.Controls.Add(this.ucBtnExt19);
			this.PreviewPage_Item.Controls.Add(this.ItemPreview_Search);
			this.PreviewPage_Item.Controls.Add(this.ucBtnExt7);
			this.PreviewPage_Item.Controls.Add(this.label4);
			this.PreviewPage_Item.Controls.Add(this.ucBtnExt5);
			this.PreviewPage_Item.Controls.Add(this.ucBtnExt4);
			this.PreviewPage_Item.Controls.Add(this.label1);
			this.PreviewPage_Item.Controls.Add(this.StateInfo);
			this.PreviewPage_Item.Controls.Add(this.label2);
			this.PreviewPage_Item.Controls.Add(this.ucBtnExt3);
			this.PreviewPage_Item.HorizontalScrollbarBarColor = true;
			this.PreviewPage_Item.HorizontalScrollbarSize = 14;
			this.PreviewPage_Item.Location = new System.Drawing.Point(4, 36);
			this.PreviewPage_Item.Margin = new System.Windows.Forms.Padding(4);
			this.PreviewPage_Item.Name = "PreviewPage_Item";
			this.PreviewPage_Item.Size = new System.Drawing.Size(846, 453);
			this.PreviewPage_Item.TabIndex = 1;
			this.PreviewPage_Item.Text = "物品预览";
			this.PreviewPage_Item.VerticalScrollbarBarColor = true;
			this.PreviewPage_Item.VerticalScrollbarSize = 12;
			this.PreviewPage_Item.Visible = false;
			// 
			// Switch_Mode
			// 
			this.Switch_Mode.BackColor = System.Drawing.Color.Transparent;
			this.Switch_Mode.Checked = true;
			this.Switch_Mode.FalseColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
			this.Switch_Mode.FalseTextColr = System.Drawing.Color.White;
			this.Switch_Mode.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.Switch_Mode.Location = new System.Drawing.Point(18, 14);
			this.Switch_Mode.Name = "Switch_Mode";
			this.Switch_Mode.Size = new System.Drawing.Size(120, 48);
			this.Switch_Mode.SwitchType = HZH_Controls.Controls.SwitchType.Ellipse;
			this.Switch_Mode.TabIndex = 126;
			this.Switch_Mode.Texts = new string[] {
        "实时读取",
        "外部读取"};
			this.Switch_Mode.TrueColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			this.Switch_Mode.TrueTextColr = System.Drawing.Color.Black;
			this.Switch_Mode.Visible = false;
			this.Switch_Mode.CheckedChanged += new System.EventHandler(this.Switch_Mode_CheckedChanged);
			// 
			// ucBtnExt19
			// 
			this.ucBtnExt19.BtnBackColor = System.Drawing.Color.Empty;
			this.ucBtnExt19.BtnFont = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.ucBtnExt19.BtnForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.ucBtnExt19.BtnText = "生成汉化";
			this.ucBtnExt19.ConerRadius = 8;
			this.ucBtnExt19.Cursor = System.Windows.Forms.Cursors.Hand;
			this.ucBtnExt19.DialogResult = System.Windows.Forms.DialogResult.None;
			this.ucBtnExt19.EnabledMouseEffect = false;
			this.ucBtnExt19.FillColor = System.Drawing.Color.White;
			this.ucBtnExt19.Font = new System.Drawing.Font("Microsoft YaHei UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.ucBtnExt19.IsRadius = true;
			this.ucBtnExt19.IsShowRect = true;
			this.ucBtnExt19.IsShowTips = false;
			this.ucBtnExt19.Location = new System.Drawing.Point(141, 126);
			this.ucBtnExt19.Margin = new System.Windows.Forms.Padding(0);
			this.ucBtnExt19.Name = "ucBtnExt19";
			this.ucBtnExt19.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.ucBtnExt19.RectWidth = 1;
			this.ucBtnExt19.Size = new System.Drawing.Size(102, 50);
			this.ucBtnExt19.TabIndex = 125;
			this.ucBtnExt19.TabStop = false;
			this.ucBtnExt19.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
			this.ucBtnExt19.TipsText = "";
			this.ucBtnExt19.BtnClick += new System.EventHandler(this.ucBtnExt19_BtnClick);
			// 
			// ItemPreview_Search
			// 
			this.ItemPreview_Search.BackColor = System.Drawing.Color.Transparent;
			this.ItemPreview_Search.ConerRadius = 5;
			this.ItemPreview_Search.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.ItemPreview_Search.DecLength = 2;
			this.ItemPreview_Search.FillColor = System.Drawing.Color.Empty;
			this.ItemPreview_Search.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
			this.ItemPreview_Search.Font = new System.Drawing.Font("Microsoft YaHei UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.ItemPreview_Search.InputText = "";
			this.ItemPreview_Search.InputType = HZH_Controls.TextInputType.NotControl;
			this.ItemPreview_Search.IsFocusColor = true;
			this.ItemPreview_Search.IsRadius = true;
			this.ItemPreview_Search.IsShowClearBtn = true;
			this.ItemPreview_Search.IsShowKeyboard = false;
			this.ItemPreview_Search.IsShowRect = true;
			this.ItemPreview_Search.IsShowSearchBtn = true;
			this.ItemPreview_Search.KeyBoardType = HZH_Controls.Controls.KeyBoardType.Null;
			this.ItemPreview_Search.Location = new System.Drawing.Point(382, 51);
			this.ItemPreview_Search.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
			this.ItemPreview_Search.MaxValue = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.ItemPreview_Search.MinValue = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
			this.ItemPreview_Search.Name = "ItemPreview_Search";
			this.ItemPreview_Search.Padding = new System.Windows.Forms.Padding(6, 7, 6, 7);
			this.ItemPreview_Search.PromptColor = System.Drawing.Color.Gray;
			this.ItemPreview_Search.PromptFont = new System.Drawing.Font("Microsoft YaHei UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.ItemPreview_Search.PromptText = "请输入物品信息  (ID/别名/名称)";
			this.ItemPreview_Search.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
			this.ItemPreview_Search.RectWidth = 1;
			this.ItemPreview_Search.RegexPattern = "";
			this.ItemPreview_Search.Size = new System.Drawing.Size(426, 55);
			this.ItemPreview_Search.TabIndex = 115;
			this.ItemPreview_Search.SearchClick += new System.EventHandler(this.ItemPreview_Search_SearchClick);
			this.ItemPreview_Search.TextChanged += new System.EventHandler(this.ItemPreview_Search_TextChanged);
			// 
			// ucBtnExt7
			// 
			this.ucBtnExt7.BtnBackColor = System.Drawing.Color.Empty;
			this.ucBtnExt7.BtnFont = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.ucBtnExt7.BtnForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.ucBtnExt7.BtnText = "变更";
			this.ucBtnExt7.ConerRadius = 8;
			this.ucBtnExt7.Cursor = System.Windows.Forms.Cursors.Hand;
			this.ucBtnExt7.DialogResult = System.Windows.Forms.DialogResult.None;
			this.ucBtnExt7.EnabledMouseEffect = false;
			this.ucBtnExt7.FillColor = System.Drawing.Color.White;
			this.ucBtnExt7.Font = new System.Drawing.Font("Microsoft YaHei UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.ucBtnExt7.IsRadius = true;
			this.ucBtnExt7.IsShowRect = true;
			this.ucBtnExt7.IsShowTips = false;
			this.ucBtnExt7.Location = new System.Drawing.Point(19, 251);
			this.ucBtnExt7.Margin = new System.Windows.Forms.Padding(0);
			this.ucBtnExt7.Name = "ucBtnExt7";
			this.ucBtnExt7.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.ucBtnExt7.RectWidth = 1;
			this.ucBtnExt7.Size = new System.Drawing.Size(98, 44);
			this.ucBtnExt7.TabIndex = 113;
			this.ucBtnExt7.TabStop = false;
			this.ucBtnExt7.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
			this.ucBtnExt7.TipsText = "";
			this.ucBtnExt7.BtnClick += new System.EventHandler(this.ucBtnExt7_BtnClick);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.label4.Location = new System.Drawing.Point(10, 221);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(138, 21);
			this.label4.TabIndex = 112;
			this.label4.Text = "工作目录：未设置";
			this.label4.DoubleClick += new System.EventHandler(this.label4_DoubleClick);
			// 
			// ucBtnExt5
			// 
			this.ucBtnExt5.BtnBackColor = System.Drawing.Color.Empty;
			this.ucBtnExt5.BtnFont = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.ucBtnExt5.BtnForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.ucBtnExt5.BtnText = "刷新缓存";
			this.ucBtnExt5.ConerRadius = 8;
			this.ucBtnExt5.Cursor = System.Windows.Forms.Cursors.Hand;
			this.ucBtnExt5.DialogResult = System.Windows.Forms.DialogResult.None;
			this.ucBtnExt5.EnabledMouseEffect = false;
			this.ucBtnExt5.FillColor = System.Drawing.Color.White;
			this.ucBtnExt5.Font = new System.Drawing.Font("Microsoft YaHei UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.ucBtnExt5.IsRadius = true;
			this.ucBtnExt5.IsShowRect = true;
			this.ucBtnExt5.IsShowTips = false;
			this.ucBtnExt5.Location = new System.Drawing.Point(579, 356);
			this.ucBtnExt5.Margin = new System.Windows.Forms.Padding(0);
			this.ucBtnExt5.Name = "ucBtnExt5";
			this.ucBtnExt5.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.ucBtnExt5.RectWidth = 1;
			this.ucBtnExt5.Size = new System.Drawing.Size(102, 50);
			this.ucBtnExt5.TabIndex = 109;
			this.ucBtnExt5.TabStop = false;
			this.ucBtnExt5.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
			this.ucBtnExt5.TipsText = "";
			this.ucBtnExt5.BtnClick += new System.EventHandler(this.ucBtnExt5_BtnClick);
			this.ucBtnExt5.MouseEnter += new System.EventHandler(this.ucBtnExt5_MouseEnter);
			this.ucBtnExt5.MouseLeave += new System.EventHandler(this.CloseTip);
			// 
			// ucBtnExt4
			// 
			this.ucBtnExt4.BtnBackColor = System.Drawing.Color.Empty;
			this.ucBtnExt4.BtnFont = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.ucBtnExt4.BtnForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.ucBtnExt4.BtnText = "帮助信息";
			this.ucBtnExt4.ConerRadius = 8;
			this.ucBtnExt4.Cursor = System.Windows.Forms.Cursors.Hand;
			this.ucBtnExt4.DialogResult = System.Windows.Forms.DialogResult.None;
			this.ucBtnExt4.EnabledMouseEffect = false;
			this.ucBtnExt4.FillColor = System.Drawing.Color.White;
			this.ucBtnExt4.Font = new System.Drawing.Font("Microsoft YaHei UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.ucBtnExt4.IsRadius = true;
			this.ucBtnExt4.IsShowRect = true;
			this.ucBtnExt4.IsShowTips = false;
			this.ucBtnExt4.Location = new System.Drawing.Point(708, 356);
			this.ucBtnExt4.Margin = new System.Windows.Forms.Padding(0);
			this.ucBtnExt4.Name = "ucBtnExt4";
			this.ucBtnExt4.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.ucBtnExt4.RectWidth = 1;
			this.ucBtnExt4.Size = new System.Drawing.Size(102, 50);
			this.ucBtnExt4.TabIndex = 108;
			this.ucBtnExt4.TabStop = false;
			this.ucBtnExt4.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
			this.ucBtnExt4.TipsText = "";
			this.ucBtnExt4.BtnClick += new System.EventHandler(this.ucBtnExt4_BtnClick);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.label1.Location = new System.Drawing.Point(384, 14);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(249, 21);
			this.label1.TabIndex = 107;
			this.label1.Text = "搜索条件 (多个条件使用逗号分隔)";
			// 
			// StateInfo
			// 
			this.StateInfo.AutoSize = true;
			this.StateInfo.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.StateInfo.Location = new System.Drawing.Point(10, 324);
			this.StateInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.StateInfo.Name = "StateInfo";
			this.StateInfo.Size = new System.Drawing.Size(119, 63);
			this.StateInfo.TabIndex = 106;
			this.StateInfo.Text = "状态信息 Line1\r\nLine2\r\nLine3";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.label2.Location = new System.Drawing.Point(9, 85);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(186, 21);
			this.label2.TabIndex = 104;
			this.label2.Text = "路径请在设置中进行设置";
			// 
			// ucBtnExt3
			// 
			this.ucBtnExt3.BtnBackColor = System.Drawing.Color.Empty;
			this.ucBtnExt3.BtnFont = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.ucBtnExt3.BtnForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.ucBtnExt3.BtnText = "生成主数据";
			this.ucBtnExt3.ConerRadius = 8;
			this.ucBtnExt3.Cursor = System.Windows.Forms.Cursors.Hand;
			this.ucBtnExt3.DialogResult = System.Windows.Forms.DialogResult.None;
			this.ucBtnExt3.EnabledMouseEffect = false;
			this.ucBtnExt3.FillColor = System.Drawing.Color.White;
			this.ucBtnExt3.Font = new System.Drawing.Font("Microsoft YaHei UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.ucBtnExt3.IsRadius = true;
			this.ucBtnExt3.IsShowRect = true;
			this.ucBtnExt3.IsShowTips = false;
			this.ucBtnExt3.Location = new System.Drawing.Point(18, 126);
			this.ucBtnExt3.Margin = new System.Windows.Forms.Padding(0);
			this.ucBtnExt3.Name = "ucBtnExt3";
			this.ucBtnExt3.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.ucBtnExt3.RectWidth = 1;
			this.ucBtnExt3.Size = new System.Drawing.Size(102, 50);
			this.ucBtnExt3.TabIndex = 103;
			this.ucBtnExt3.TabStop = false;
			this.ucBtnExt3.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
			this.ucBtnExt3.TipsText = "";
			this.ucBtnExt3.BtnClick += new System.EventHandler(this.ucBtnExt3_BtnClick);
			// 
			// PreviewPage_Else
			// 
			this.PreviewPage_Else.Controls.Add(this.groupBox2);
			this.PreviewPage_Else.Controls.Add(this.groupBox1);
			this.PreviewPage_Else.HorizontalScrollbarBarColor = true;
			this.PreviewPage_Else.HorizontalScrollbarSize = 14;
			this.PreviewPage_Else.Location = new System.Drawing.Point(4, 36);
			this.PreviewPage_Else.Margin = new System.Windows.Forms.Padding(4);
			this.PreviewPage_Else.Name = "PreviewPage_Else";
			this.PreviewPage_Else.Size = new System.Drawing.Size(846, 453);
			this.PreviewPage_Else.TabIndex = 2;
			this.PreviewPage_Else.Text = "其他预览";
			this.PreviewPage_Else.VerticalScrollbarBarColor = true;
			this.PreviewPage_Else.VerticalScrollbarSize = 12;
			// 
			// groupBox2
			// 
			this.groupBox2.BackColor = System.Drawing.Color.Transparent;
			this.groupBox2.Controls.Add(this.ucBtnExt11);
			this.groupBox2.Controls.Add(this.ucBtnExt1);
			this.groupBox2.Controls.Add(this.ucBtnExt20);
			this.groupBox2.Controls.Add(this.ucBtnExt9);
			this.groupBox2.Controls.Add(this.ucBtnExt8);
			this.groupBox2.Controls.Add(this.ucBtnExt13);
			this.groupBox2.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.groupBox2.Location = new System.Drawing.Point(4, 14);
			this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
			this.groupBox2.Size = new System.Drawing.Size(337, 319);
			this.groupBox2.TabIndex = 125;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "预览界面";
			// 
			// ucBtnExt11
			// 
			this.ucBtnExt11.BtnBackColor = System.Drawing.Color.Empty;
			this.ucBtnExt11.BtnFont = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.ucBtnExt11.BtnForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.ucBtnExt11.BtnText = "商店";
			this.ucBtnExt11.ConerRadius = 8;
			this.ucBtnExt11.Cursor = System.Windows.Forms.Cursors.Hand;
			this.ucBtnExt11.DialogResult = System.Windows.Forms.DialogResult.None;
			this.ucBtnExt11.EnabledMouseEffect = false;
			this.ucBtnExt11.FillColor = System.Drawing.Color.White;
			this.ucBtnExt11.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.ucBtnExt11.IsRadius = true;
			this.ucBtnExt11.IsShowRect = true;
			this.ucBtnExt11.IsShowTips = false;
			this.ucBtnExt11.Location = new System.Drawing.Point(16, 45);
			this.ucBtnExt11.Margin = new System.Windows.Forms.Padding(0);
			this.ucBtnExt11.Name = "ucBtnExt11";
			this.ucBtnExt11.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.ucBtnExt11.RectWidth = 1;
			this.ucBtnExt11.Size = new System.Drawing.Size(112, 48);
			this.ucBtnExt11.TabIndex = 112;
			this.ucBtnExt11.TabStop = false;
			this.ucBtnExt11.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
			this.ucBtnExt11.TipsText = "";
			this.ucBtnExt11.BtnClick += new System.EventHandler(this.ucBtnExt11_BtnClick);
			// 
			// ucBtnExt1
			// 
			this.ucBtnExt1.BtnBackColor = System.Drawing.Color.Empty;
			this.ucBtnExt1.BtnFont = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.ucBtnExt1.BtnForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.ucBtnExt1.BtnText = "聚灵阁奖励";
			this.ucBtnExt1.ConerRadius = 8;
			this.ucBtnExt1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.ucBtnExt1.DialogResult = System.Windows.Forms.DialogResult.None;
			this.ucBtnExt1.EnabledMouseEffect = false;
			this.ucBtnExt1.FillColor = System.Drawing.Color.White;
			this.ucBtnExt1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.ucBtnExt1.IsRadius = true;
			this.ucBtnExt1.IsShowRect = true;
			this.ucBtnExt1.IsShowTips = false;
			this.ucBtnExt1.Location = new System.Drawing.Point(16, 109);
			this.ucBtnExt1.Margin = new System.Windows.Forms.Padding(0);
			this.ucBtnExt1.Name = "ucBtnExt1";
			this.ucBtnExt1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.ucBtnExt1.RectWidth = 1;
			this.ucBtnExt1.Size = new System.Drawing.Size(112, 48);
			this.ucBtnExt1.TabIndex = 113;
			this.ucBtnExt1.TabStop = false;
			this.ucBtnExt1.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
			this.ucBtnExt1.TipsText = "";
			this.ucBtnExt1.BtnClick += new System.EventHandler(this.ucBtnExt1_BtnClick);
			// 
			// ucBtnExt20
			// 
			this.ucBtnExt20.BtnBackColor = System.Drawing.Color.Empty;
			this.ucBtnExt20.BtnFont = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.ucBtnExt20.BtnForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.ucBtnExt20.BtnText = "技能";
			this.ucBtnExt20.ConerRadius = 8;
			this.ucBtnExt20.Cursor = System.Windows.Forms.Cursors.Hand;
			this.ucBtnExt20.DialogResult = System.Windows.Forms.DialogResult.None;
			this.ucBtnExt20.EnabledMouseEffect = false;
			this.ucBtnExt20.FillColor = System.Drawing.Color.White;
			this.ucBtnExt20.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.ucBtnExt20.IsRadius = true;
			this.ucBtnExt20.IsShowRect = true;
			this.ucBtnExt20.IsShowTips = false;
			this.ucBtnExt20.Location = new System.Drawing.Point(16, 237);
			this.ucBtnExt20.Margin = new System.Windows.Forms.Padding(0);
			this.ucBtnExt20.Name = "ucBtnExt20";
			this.ucBtnExt20.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.ucBtnExt20.RectWidth = 1;
			this.ucBtnExt20.Size = new System.Drawing.Size(112, 48);
			this.ucBtnExt20.TabIndex = 126;
			this.ucBtnExt20.TabStop = false;
			this.ucBtnExt20.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
			this.ucBtnExt20.TipsText = "";
			this.ucBtnExt20.BtnClick += new System.EventHandler(this.ucBtnExt20_BtnClick);
			// 
			// ucBtnExt9
			// 
			this.ucBtnExt9.BtnBackColor = System.Drawing.Color.Empty;
			this.ucBtnExt9.BtnFont = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.ucBtnExt9.BtnForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.ucBtnExt9.BtnText = "挑战";
			this.ucBtnExt9.ConerRadius = 8;
			this.ucBtnExt9.Cursor = System.Windows.Forms.Cursors.Hand;
			this.ucBtnExt9.DialogResult = System.Windows.Forms.DialogResult.None;
			this.ucBtnExt9.EnabledMouseEffect = false;
			this.ucBtnExt9.FillColor = System.Drawing.Color.White;
			this.ucBtnExt9.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.ucBtnExt9.IsRadius = true;
			this.ucBtnExt9.IsShowRect = true;
			this.ucBtnExt9.IsShowTips = false;
			this.ucBtnExt9.Location = new System.Drawing.Point(153, 173);
			this.ucBtnExt9.Margin = new System.Windows.Forms.Padding(0);
			this.ucBtnExt9.Name = "ucBtnExt9";
			this.ucBtnExt9.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.ucBtnExt9.RectWidth = 1;
			this.ucBtnExt9.Size = new System.Drawing.Size(112, 48);
			this.ucBtnExt9.TabIndex = 123;
			this.ucBtnExt9.TabStop = false;
			this.ucBtnExt9.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
			this.ucBtnExt9.TipsText = "";
			this.ucBtnExt9.BtnClick += new System.EventHandler(this.ucBtnExt9_BtnClick);
			// 
			// ucBtnExt8
			// 
			this.ucBtnExt8.BtnBackColor = System.Drawing.Color.Empty;
			this.ucBtnExt8.BtnFont = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.ucBtnExt8.BtnForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.ucBtnExt8.BtnText = "聚灵阁组合";
			this.ucBtnExt8.ConerRadius = 8;
			this.ucBtnExt8.Cursor = System.Windows.Forms.Cursors.Hand;
			this.ucBtnExt8.DialogResult = System.Windows.Forms.DialogResult.None;
			this.ucBtnExt8.EnabledMouseEffect = false;
			this.ucBtnExt8.FillColor = System.Drawing.Color.White;
			this.ucBtnExt8.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.ucBtnExt8.IsRadius = true;
			this.ucBtnExt8.IsShowRect = true;
			this.ucBtnExt8.IsShowTips = false;
			this.ucBtnExt8.Location = new System.Drawing.Point(153, 109);
			this.ucBtnExt8.Margin = new System.Windows.Forms.Padding(0);
			this.ucBtnExt8.Name = "ucBtnExt8";
			this.ucBtnExt8.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.ucBtnExt8.RectWidth = 1;
			this.ucBtnExt8.Size = new System.Drawing.Size(112, 48);
			this.ucBtnExt8.TabIndex = 114;
			this.ucBtnExt8.TabStop = false;
			this.ucBtnExt8.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
			this.ucBtnExt8.TipsText = "";
			this.ucBtnExt8.BtnClick += new System.EventHandler(this.ucBtnExt8_BtnClick);
			// 
			// ucBtnExt13
			// 
			this.ucBtnExt13.BtnBackColor = System.Drawing.Color.Empty;
			this.ucBtnExt13.BtnFont = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.ucBtnExt13.BtnForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.ucBtnExt13.BtnText = "地图";
			this.ucBtnExt13.ConerRadius = 8;
			this.ucBtnExt13.Cursor = System.Windows.Forms.Cursors.Hand;
			this.ucBtnExt13.DialogResult = System.Windows.Forms.DialogResult.None;
			this.ucBtnExt13.EnabledMouseEffect = false;
			this.ucBtnExt13.FillColor = System.Drawing.Color.White;
			this.ucBtnExt13.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.ucBtnExt13.IsRadius = true;
			this.ucBtnExt13.IsShowRect = true;
			this.ucBtnExt13.IsShowTips = false;
			this.ucBtnExt13.Location = new System.Drawing.Point(16, 173);
			this.ucBtnExt13.Margin = new System.Windows.Forms.Padding(0);
			this.ucBtnExt13.Name = "ucBtnExt13";
			this.ucBtnExt13.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.ucBtnExt13.RectWidth = 1;
			this.ucBtnExt13.Size = new System.Drawing.Size(112, 48);
			this.ucBtnExt13.TabIndex = 119;
			this.ucBtnExt13.TabStop = false;
			this.ucBtnExt13.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
			this.ucBtnExt13.TipsText = "";
			this.ucBtnExt13.BtnClick += new System.EventHandler(this.ucBtnExt13_BtnClick);
			// 
			// groupBox1
			// 
			this.groupBox1.BackColor = System.Drawing.Color.Transparent;
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.ucBtnExt10);
			this.groupBox1.Controls.Add(this.ucBtnExt18);
			this.groupBox1.Controls.Add(this.ucBtnExt12);
			this.groupBox1.Controls.Add(this.ucBtnExt14);
			this.groupBox1.Controls.Add(this.ucBtnExt16);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.groupBox1.Location = new System.Drawing.Point(384, 14);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
			this.groupBox1.Size = new System.Drawing.Size(330, 319);
			this.groupBox1.TabIndex = 124;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "输出数据";
			// 
			// ucBtnExt10
			// 
			this.ucBtnExt10.BtnBackColor = System.Drawing.Color.Empty;
			this.ucBtnExt10.BtnFont = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.ucBtnExt10.BtnForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.ucBtnExt10.BtnText = "探险日志";
			this.ucBtnExt10.ConerRadius = 8;
			this.ucBtnExt10.Cursor = System.Windows.Forms.Cursors.Hand;
			this.ucBtnExt10.DialogResult = System.Windows.Forms.DialogResult.None;
			this.ucBtnExt10.EnabledMouseEffect = false;
			this.ucBtnExt10.FillColor = System.Drawing.Color.White;
			this.ucBtnExt10.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.ucBtnExt10.IsRadius = true;
			this.ucBtnExt10.IsShowRect = true;
			this.ucBtnExt10.IsShowTips = false;
			this.ucBtnExt10.Location = new System.Drawing.Point(151, 45);
			this.ucBtnExt10.Margin = new System.Windows.Forms.Padding(0);
			this.ucBtnExt10.Name = "ucBtnExt10";
			this.ucBtnExt10.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.ucBtnExt10.RectWidth = 1;
			this.ucBtnExt10.Size = new System.Drawing.Size(112, 48);
			this.ucBtnExt10.TabIndex = 127;
			this.ucBtnExt10.TabStop = false;
			this.ucBtnExt10.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
			this.ucBtnExt10.TipsText = "";
			this.ucBtnExt10.BtnClick += new System.EventHandler(this.ucBtnExt10_BtnClick);
			// 
			// ucBtnExt18
			// 
			this.ucBtnExt18.BtnBackColor = System.Drawing.Color.Empty;
			this.ucBtnExt18.BtnFont = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.ucBtnExt18.BtnForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.ucBtnExt18.BtnText = "衣柜_按类型";
			this.ucBtnExt18.ConerRadius = 8;
			this.ucBtnExt18.Cursor = System.Windows.Forms.Cursors.Hand;
			this.ucBtnExt18.DialogResult = System.Windows.Forms.DialogResult.None;
			this.ucBtnExt18.EnabledMouseEffect = false;
			this.ucBtnExt18.FillColor = System.Drawing.Color.White;
			this.ucBtnExt18.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.ucBtnExt18.IsRadius = true;
			this.ucBtnExt18.IsShowRect = true;
			this.ucBtnExt18.IsShowTips = false;
			this.ucBtnExt18.Location = new System.Drawing.Point(151, 222);
			this.ucBtnExt18.Margin = new System.Windows.Forms.Padding(0);
			this.ucBtnExt18.Name = "ucBtnExt18";
			this.ucBtnExt18.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.ucBtnExt18.RectWidth = 1;
			this.ucBtnExt18.Size = new System.Drawing.Size(112, 48);
			this.ucBtnExt18.TabIndex = 126;
			this.ucBtnExt18.TabStop = false;
			this.ucBtnExt18.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
			this.ucBtnExt18.TipsText = "";
			this.ucBtnExt18.BtnClick += new System.EventHandler(this.ucBtnExt18_BtnClick);
			// 
			// ucBtnExt12
			// 
			this.ucBtnExt12.BtnBackColor = System.Drawing.Color.Empty;
			this.ucBtnExt12.BtnFont = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.ucBtnExt12.BtnForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.ucBtnExt12.BtnText = "衣柜 (不推荐)";
			this.ucBtnExt12.ConerRadius = 8;
			this.ucBtnExt12.Cursor = System.Windows.Forms.Cursors.Hand;
			this.ucBtnExt12.DialogResult = System.Windows.Forms.DialogResult.None;
			this.ucBtnExt12.EnabledMouseEffect = false;
			this.ucBtnExt12.FillColor = System.Drawing.Color.White;
			this.ucBtnExt12.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.ucBtnExt12.IsRadius = true;
			this.ucBtnExt12.IsShowRect = true;
			this.ucBtnExt12.IsShowTips = false;
			this.ucBtnExt12.Location = new System.Drawing.Point(15, 222);
			this.ucBtnExt12.Margin = new System.Windows.Forms.Padding(0);
			this.ucBtnExt12.Name = "ucBtnExt12";
			this.ucBtnExt12.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.ucBtnExt12.RectWidth = 1;
			this.ucBtnExt12.Size = new System.Drawing.Size(112, 48);
			this.ucBtnExt12.TabIndex = 121;
			this.ucBtnExt12.TabStop = false;
			this.ucBtnExt12.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
			this.ucBtnExt12.TipsText = "";
			this.ucBtnExt12.BtnClick += new System.EventHandler(this.ucBtnExt12_BtnClick);
			// 
			// ucBtnExt14
			// 
			this.ucBtnExt14.BtnBackColor = System.Drawing.Color.Empty;
			this.ucBtnExt14.BtnFont = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.ucBtnExt14.BtnForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.ucBtnExt14.BtnText = "物品售价";
			this.ucBtnExt14.ConerRadius = 8;
			this.ucBtnExt14.Cursor = System.Windows.Forms.Cursors.Hand;
			this.ucBtnExt14.DialogResult = System.Windows.Forms.DialogResult.None;
			this.ucBtnExt14.EnabledMouseEffect = false;
			this.ucBtnExt14.FillColor = System.Drawing.Color.White;
			this.ucBtnExt14.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.ucBtnExt14.IsRadius = true;
			this.ucBtnExt14.IsShowRect = true;
			this.ucBtnExt14.IsShowTips = false;
			this.ucBtnExt14.Location = new System.Drawing.Point(15, 45);
			this.ucBtnExt14.Margin = new System.Windows.Forms.Padding(0);
			this.ucBtnExt14.Name = "ucBtnExt14";
			this.ucBtnExt14.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.ucBtnExt14.RectWidth = 1;
			this.ucBtnExt14.Size = new System.Drawing.Size(112, 48);
			this.ucBtnExt14.TabIndex = 120;
			this.ucBtnExt14.TabStop = false;
			this.ucBtnExt14.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
			this.ucBtnExt14.TipsText = "";
			this.ucBtnExt14.BtnClick += new System.EventHandler(this.ucBtnExt14_BtnClick);
			// 
			// ucBtnExt16
			// 
			this.ucBtnExt16.BtnBackColor = System.Drawing.Color.Empty;
			this.ucBtnExt16.BtnFont = null;
			this.ucBtnExt16.BtnForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.ucBtnExt16.BtnText = "成长路径";
			this.ucBtnExt16.ConerRadius = 8;
			this.ucBtnExt16.Cursor = System.Windows.Forms.Cursors.Hand;
			this.ucBtnExt16.DialogResult = System.Windows.Forms.DialogResult.None;
			this.ucBtnExt16.EnabledMouseEffect = false;
			this.ucBtnExt16.FillColor = System.Drawing.Color.White;
			this.ucBtnExt16.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.ucBtnExt16.IsRadius = true;
			this.ucBtnExt16.IsShowRect = true;
			this.ucBtnExt16.IsShowTips = false;
			this.ucBtnExt16.Location = new System.Drawing.Point(15, 162);
			this.ucBtnExt16.Margin = new System.Windows.Forms.Padding(0);
			this.ucBtnExt16.Name = "ucBtnExt16";
			this.ucBtnExt16.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.ucBtnExt16.RectWidth = 1;
			this.ucBtnExt16.Size = new System.Drawing.Size(112, 48);
			this.ucBtnExt16.TabIndex = 122;
			this.ucBtnExt16.TabStop = false;
			this.ucBtnExt16.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
			this.ucBtnExt16.TipsText = "";
			this.ucBtnExt16.BtnClick += new System.EventHandler(this.ucBtnExt16_BtnClick);
			// 
			// Timer
			// 
			this.Timer.Interval = 500;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.label3.Location = new System.Drawing.Point(15, 123);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(260, 34);
			this.label3.TabIndex = 128;
			this.label3.Text = "由于涉及读取大量物品数据，以下功能处理缓慢\r\n后续版本将会优化此问题";
			// 
			// MatchProp
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Transparent;
			this.Controls.Add(this.TabControl);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "MatchProp";
			this.Size = new System.Drawing.Size(854, 493);
			this.Load += new System.EventHandler(this.MatchProp_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TabControl_KeyDown);
			this.TabControl.ResumeLayout(false);
			this.MainPage.ResumeLayout(false);
			this.MainPage.PerformLayout();
			this.PreviewPage_Item.ResumeLayout(false);
			this.PreviewPage_Item.PerformLayout();
			this.PreviewPage_Else.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private HZH_Controls.Controls.UCSwitch Chk_OnlyNew;
        private HZH_Controls.Controls.UCSwitch Switch_64Bit;
        private HZH_Controls.Controls.UCStep Step1;
        private HZH_Controls.Controls.UCBtnFillet ucBtnFillet1;
        private HZH_Controls.Controls.UCBtnFillet File_Searcher;
        private HZH_Controls.Controls.UCBtnFillet Online_Searcher;
        private System.Windows.Forms.Label lbl_Region;
        private MetroFramework.Controls.MetroLabel Note_Chv;
        private MetroFramework.Controls.MetroLabel Note_GRoot;
        private HZH_Controls.Controls.UCBtnExt Btn_StartMatch;
        private System.Windows.Forms.TextBox Chv_Path;
		private System.Windows.Forms.Label TimeInfo;
		public System.Windows.Forms.TextBox GRoot_Path;
		private System.Windows.Forms.TabControl TabControl;
		private MetroFramework.Controls.MetroTabPage MainPage;
		private MetroFramework.Controls.MetroTabPage PreviewPage_Item;
		private HZH_Controls.Controls.UCBtnExt ucBtnExt3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label StateInfo;
		private HZH_Controls.Controls.UCBtnExt ucBtnExt4;
		private System.Windows.Forms.Label label1;
		private HZH_Controls.Controls.UCBtnExt ucBtnExt5;
		private MetroFramework.Controls.MetroTabPage PreviewPage_Else;
		private HZH_Controls.Controls.UCBtnExt ucBtnExt11;
		private System.Windows.Forms.Label label4;
		private HZH_Controls.Controls.UCBtnExt ucBtnExt7;
		private HZH_Controls.Controls.UCTextBoxEx ItemPreview_Search;
		private HZH_Controls.Controls.UCBtnExt ucBtnExt1;
		private HZH_Controls.Controls.UCBtnExt ucBtnExt8;
		private HZH_Controls.Controls.UCBtnExt ucBtnExt13;
		private HZH_Controls.Controls.UCBtnExt ucBtnExt14;
		private HZH_Controls.Controls.UCBtnExt ucBtnExt16;
		private HZH_Controls.Controls.UCBtnExt ucBtnExt9;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox1;
		private HZH_Controls.Controls.UCBtnExt ucBtnExt12;
		private HZH_Controls.Controls.UCBtnExt ucBtnExt18;
		private System.Windows.Forms.Timer Timer;
		private System.Windows.Forms.OpenFileDialog Open;
		private HZH_Controls.Controls.UCBtnExt ucBtnExt19;
		private HZH_Controls.Controls.UCBtnExt ucBtnExt10;
		private HZH_Controls.Controls.UCBtnExt ucBtnExt20;
		private HZH_Controls.Controls.UCSwitch Switch_Mode;
		private System.Windows.Forms.Label label3;
	}
}
