namespace 剑灵引导程序.HUD2
{
    partial class Quest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Quest));
            this.Open = new System.Windows.Forms.OpenFileDialog();
            this.RichOut = new System.Windows.Forms.RichTextBox();
            this.level = new System.Windows.Forms.Label();
            this.RecommendedLevel = new System.Windows.Forms.Label();
            this.tabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.Quest_ = new MetroFramework.Controls.MetroTabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.metroCheckBox1 = new MetroFramework.Controls.MetroCheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.Previous = new System.Windows.Forms.PictureBox();
            this.Num = new System.Windows.Forms.NumericUpDown();
            this.Next = new System.Windows.Forms.PictureBox();
            this.Quest_Pnl = new System.Windows.Forms.Panel();
            this.Dungeon_Name = new System.Windows.Forms.Label();
            this.Event = new System.Windows.Forms.PictureBox();
            this.Dungeon_ICON = new System.Windows.Forms.PictureBox();
            this.Quest_Group = new System.Windows.Forms.Label();
            this.Dungeon_Grade = new System.Windows.Forms.PictureBox();
            this.Dungeon_Type = new System.Windows.Forms.PictureBox();
            this.Quest_ICON = new System.Windows.Forms.PictureBox();
            this.Quest_Name = new System.Windows.Forms.Label();
            this.Reset_Type = new System.Windows.Forms.PictureBox();
            this.Right = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Show_ID_Input = new System.Windows.Forms.ToolStripMenuItem();
            this.Cancel_Error_Message = new System.Windows.Forms.ToolStripMenuItem();
            this.地图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Reload = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowDesc = new System.Windows.Forms.ToolStripMenuItem();
            this.Tip = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl1.SuspendLayout();
            this.Quest_.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Previous)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Next)).BeginInit();
            this.Quest_Pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Event)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dungeon_ICON)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dungeon_Grade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dungeon_Type)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Quest_ICON)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Reset_Type)).BeginInit();
            this.Right.SuspendLayout();
            this.SuspendLayout();
            // 
            // RichOut
            // 
            this.RichOut.AutoWordSelection = true;
            this.RichOut.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.RichOut.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RichOut.Location = new System.Drawing.Point(4, 73);
            this.RichOut.Name = "RichOut";
            this.RichOut.ReadOnly = true;
            this.RichOut.Size = new System.Drawing.Size(629, 381);
            this.RichOut.TabIndex = 3;
            this.RichOut.Text = "";
            this.RichOut.ZoomFactor = 2F;
            // 
            // level
            // 
            this.level.AutoSize = true;
            this.level.Location = new System.Drawing.Point(648, 180);
            this.level.Name = "level";
            this.level.Size = new System.Drawing.Size(89, 12);
            this.level.TabIndex = 7;
            this.level.Text = "要求等级：null";
            // 
            // RecommendedLevel
            // 
            this.RecommendedLevel.AutoSize = true;
            this.RecommendedLevel.Location = new System.Drawing.Point(648, 207);
            this.RecommendedLevel.Name = "RecommendedLevel";
            this.RecommendedLevel.Size = new System.Drawing.Size(89, 12);
            this.RecommendedLevel.TabIndex = 8;
            this.RecommendedLevel.Text = "推荐等级：null";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Quest_);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.HotTrack = true;
            this.tabControl1.Location = new System.Drawing.Point(20, 60);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(808, 488);
            this.tabControl1.TabIndex = 17;
            this.tabControl1.UseSelectable = true;
            this.tabControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tabControl1_KeyDown);
            // 
            // Quest_
            // 
            this.Quest_.Controls.Add(this.button2);
            this.Quest_.Controls.Add(this.metroCheckBox1);
            this.Quest_.Controls.Add(this.button1);
            this.Quest_.Controls.Add(this.checkBox1);
            this.Quest_.Controls.Add(this.Previous);
            this.Quest_.Controls.Add(this.Num);
            this.Quest_.Controls.Add(this.Next);
            this.Quest_.Controls.Add(this.Quest_Pnl);
            this.Quest_.Controls.Add(this.RecommendedLevel);
            this.Quest_.Controls.Add(this.level);
            this.Quest_.HorizontalScrollbarBarColor = true;
            this.Quest_.HorizontalScrollbarHighlightOnWheel = false;
            this.Quest_.HorizontalScrollbarSize = 10;
            this.Quest_.Location = new System.Drawing.Point(4, 38);
            this.Quest_.Name = "Quest_";
            this.Quest_.Padding = new System.Windows.Forms.Padding(3);
            this.Quest_.Size = new System.Drawing.Size(800, 446);
            this.Quest_.TabIndex = 0;
            this.Quest_.Text = "任务检索";
            this.Quest_.UseVisualStyleBackColor = true;
            this.Quest_.VerticalScrollbarBarColor = true;
            this.Quest_.VerticalScrollbarHighlightOnWheel = false;
            this.Quest_.VerticalScrollbarSize = 10;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(677, 67);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 26;
            this.button2.Text = "红尘往事";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // metroCheckBox1
            // 
            this.metroCheckBox1.AutoSize = true;
            this.metroCheckBox1.Checked = true;
            this.metroCheckBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.metroCheckBox1.Location = new System.Drawing.Point(650, 246);
            this.metroCheckBox1.Name = "metroCheckBox1";
            this.metroCheckBox1.Size = new System.Drawing.Size(75, 15);
            this.metroCheckBox1.TabIndex = 25;
            this.metroCheckBox1.Text = "激活状态";
            this.metroCheckBox1.UseSelectable = true;
            this.metroCheckBox1.Visible = false;
            this.metroCheckBox1.CheckedChanged += new System.EventHandler(this.MetroCheckBox1_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(677, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 24;
            this.button1.Text = "Demo列表";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(648, 139);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(84, 16);
            this.checkBox1.TabIndex = 13;
            this.checkBox1.Text = "Use 64 BIT";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Previous
            // 
            this.Previous.Image = ((System.Drawing.Image)(resources.GetObject("Previous.Image")));
            this.Previous.Location = new System.Drawing.Point(677, 381);
            this.Previous.Name = "Previous";
            this.Previous.Size = new System.Drawing.Size(16, 16);
            this.Previous.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Previous.TabIndex = 23;
            this.Previous.TabStop = false;
            this.Tip.SetToolTip(this.Previous, "前置任务");
            this.Previous.Visible = false;
            this.Previous.Click += new System.EventHandler(this.Previous_Click);
            // 
            // Num
            // 
            this.Num.Location = new System.Drawing.Point(677, 5);
            this.Num.Maximum = new decimal(new int[] {
            -1981284353,
            -1966660860,
            0,
            0});
            this.Num.Name = "Num";
            this.Num.Size = new System.Drawing.Size(60, 21);
            this.Num.TabIndex = 22;
            this.Num.ValueChanged += new System.EventHandler(this.Num_ValueChanged);
            // 
            // Next
            // 
            this.Next.Image = ((System.Drawing.Image)(resources.GetObject("Next.Image")));
            this.Next.Location = new System.Drawing.Point(710, 381);
            this.Next.Name = "Next";
            this.Next.Size = new System.Drawing.Size(16, 16);
            this.Next.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Next.TabIndex = 18;
            this.Next.TabStop = false;
            this.Tip.SetToolTip(this.Next, "后续任务");
            this.Next.Visible = false;
            this.Next.Click += new System.EventHandler(this.Next_Click);
            // 
            // Quest_Pnl
            // 
            this.Quest_Pnl.Controls.Add(this.RichOut);
            this.Quest_Pnl.Controls.Add(this.Dungeon_Name);
            this.Quest_Pnl.Controls.Add(this.Event);
            this.Quest_Pnl.Controls.Add(this.Dungeon_ICON);
            this.Quest_Pnl.Controls.Add(this.Quest_Group);
            this.Quest_Pnl.Controls.Add(this.Dungeon_Grade);
            this.Quest_Pnl.Controls.Add(this.Dungeon_Type);
            this.Quest_Pnl.Controls.Add(this.Quest_ICON);
            this.Quest_Pnl.Controls.Add(this.Quest_Name);
            this.Quest_Pnl.Controls.Add(this.Reset_Type);
            this.Quest_Pnl.Location = new System.Drawing.Point(6, 3);
            this.Quest_Pnl.Name = "Quest_Pnl";
            this.Quest_Pnl.Size = new System.Drawing.Size(636, 464);
            this.Quest_Pnl.TabIndex = 17;
            this.Quest_Pnl.Paint += new System.Windows.Forms.PaintEventHandler(this.Quest_Pnl_Paint);
            // 
            // Dungeon_Name
            // 
            this.Dungeon_Name.AutoSize = true;
            this.Dungeon_Name.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Dungeon_Name.Location = new System.Drawing.Point(538, 6);
            this.Dungeon_Name.Name = "Dungeon_Name";
            this.Dungeon_Name.Size = new System.Drawing.Size(88, 26);
            this.Dungeon_Name.TabIndex = 8;
            this.Dungeon_Name.Text = "副本名称";
            this.Dungeon_Name.Visible = false;
            // 
            // Event
            // 
            this.Event.Image = ((System.Drawing.Image)(resources.GetObject("Event.Image")));
            this.Event.Location = new System.Drawing.Point(419, 2);
            this.Event.Name = "Event";
            this.Event.Size = new System.Drawing.Size(32, 32);
            this.Event.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Event.TabIndex = 11;
            this.Event.TabStop = false;
            this.Event.Visible = false;
            this.Event.WaitOnLoad = true;
            // 
            // Dungeon_ICON
            // 
            this.Dungeon_ICON.Image = ((System.Drawing.Image)(resources.GetObject("Dungeon_ICON.Image")));
            this.Dungeon_ICON.Location = new System.Drawing.Point(457, 4);
            this.Dungeon_ICON.Name = "Dungeon_ICON";
            this.Dungeon_ICON.Size = new System.Drawing.Size(32, 32);
            this.Dungeon_ICON.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Dungeon_ICON.TabIndex = 7;
            this.Dungeon_ICON.TabStop = false;
            this.Dungeon_ICON.Visible = false;
            // 
            // Quest_Group
            // 
            this.Quest_Group.AutoSize = true;
            this.Quest_Group.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Quest_Group.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.Quest_Group.Location = new System.Drawing.Point(4, 5);
            this.Quest_Group.Name = "Quest_Group";
            this.Quest_Group.Size = new System.Drawing.Size(44, 12);
            this.Quest_Group.TabIndex = 6;
            this.Quest_Group.Text = "组名称";
            // 
            // Dungeon_Grade
            // 
            this.Dungeon_Grade.Image = ((System.Drawing.Image)(resources.GetObject("Dungeon_Grade.Image")));
            this.Dungeon_Grade.Location = new System.Drawing.Point(457, 35);
            this.Dungeon_Grade.Name = "Dungeon_Grade";
            this.Dungeon_Grade.Size = new System.Drawing.Size(64, 32);
            this.Dungeon_Grade.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Dungeon_Grade.TabIndex = 10;
            this.Dungeon_Grade.TabStop = false;
            this.Dungeon_Grade.Visible = false;
            this.Dungeon_Grade.WaitOnLoad = true;
            // 
            // Dungeon_Type
            // 
            this.Dungeon_Type.Image = ((System.Drawing.Image)(resources.GetObject("Dungeon_Type.Image")));
            this.Dungeon_Type.Location = new System.Drawing.Point(531, 35);
            this.Dungeon_Type.Name = "Dungeon_Type";
            this.Dungeon_Type.Size = new System.Drawing.Size(64, 32);
            this.Dungeon_Type.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Dungeon_Type.TabIndex = 9;
            this.Dungeon_Type.TabStop = false;
            this.Dungeon_Type.Visible = false;
            this.Dungeon_Type.WaitOnLoad = true;
            // 
            // Quest_ICON
            // 
            this.Quest_ICON.Image = ((System.Drawing.Image)(resources.GetObject("Quest_ICON.Image")));
            this.Quest_ICON.Location = new System.Drawing.Point(4, 23);
            this.Quest_ICON.Name = "Quest_ICON";
            this.Quest_ICON.Size = new System.Drawing.Size(32, 32);
            this.Quest_ICON.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Quest_ICON.TabIndex = 5;
            this.Quest_ICON.TabStop = false;
            // 
            // Quest_Name
            // 
            this.Quest_Name.AutoSize = true;
            this.Quest_Name.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Quest_Name.Location = new System.Drawing.Point(42, 29);
            this.Quest_Name.Name = "Quest_Name";
            this.Quest_Name.Size = new System.Drawing.Size(88, 26);
            this.Quest_Name.TabIndex = 4;
            this.Quest_Name.Text = "任务名称";
            // 
            // Reset_Type
            // 
            this.Reset_Type.Image = ((System.Drawing.Image)(resources.GetObject("Reset_Type.Image")));
            this.Reset_Type.Location = new System.Drawing.Point(495, 5);
            this.Reset_Type.Name = "Reset_Type";
            this.Reset_Type.Size = new System.Drawing.Size(30, 30);
            this.Reset_Type.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Reset_Type.TabIndex = 12;
            this.Reset_Type.TabStop = false;
            this.Tip.SetToolTip(this.Reset_Type, "日常任务");
            this.Reset_Type.Visible = false;
            this.Reset_Type.WaitOnLoad = true;
            // 
            // Right
            // 
            this.Right.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Show_ID_Input,
            this.Cancel_Error_Message,
            this.地图ToolStripMenuItem,
            this.Reload,
            this.ShowDesc});
            this.Right.Name = "Right";
            this.Right.Size = new System.Drawing.Size(149, 114);
            // 
            // Show_ID_Input
            // 
            this.Show_ID_Input.Checked = true;
            this.Show_ID_Input.CheckOnClick = true;
            this.Show_ID_Input.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Show_ID_Input.Name = "Show_ID_Input";
            this.Show_ID_Input.Size = new System.Drawing.Size(148, 22);
            this.Show_ID_Input.Text = "显示ID输入";
            this.Show_ID_Input.Click += new System.EventHandler(this.Show_ID_Input_Click);
            // 
            // Cancel_Error_Message
            // 
            this.Cancel_Error_Message.CheckOnClick = true;
            this.Cancel_Error_Message.Name = "Cancel_Error_Message";
            this.Cancel_Error_Message.Size = new System.Drawing.Size(148, 22);
            this.Cancel_Error_Message.Text = "取消报错弹窗";
            this.Cancel_Error_Message.Click += new System.EventHandler(this.Cancel_Error_Message_Click);
            // 
            // 地图ToolStripMenuItem
            // 
            this.地图ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sortToolStripMenuItem});
            this.地图ToolStripMenuItem.Name = "地图ToolStripMenuItem";
            this.地图ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.地图ToolStripMenuItem.Text = "地图";
            // 
            // sortToolStripMenuItem
            // 
            this.sortToolStripMenuItem.Name = "sortToolStripMenuItem";
            this.sortToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.sortToolStripMenuItem.Text = "排列";
            this.sortToolStripMenuItem.Click += new System.EventHandler(this.sortToolStripMenuItem_Click);
            // 
            // Reload
            // 
            this.Reload.Name = "Reload";
            this.Reload.Size = new System.Drawing.Size(148, 22);
            this.Reload.Text = "重载汉化文件";
            this.Reload.Click += new System.EventHandler(this.Reload_Click);
            // 
            // ShowDesc
            // 
            this.ShowDesc.Checked = true;
            this.ShowDesc.CheckOnClick = true;
            this.ShowDesc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ShowDesc.Name = "ShowDesc";
            this.ShowDesc.Size = new System.Drawing.Size(148, 22);
            this.ShowDesc.Text = "显示详细信息";
            this.ShowDesc.Click += new System.EventHandler(this.ShowDesc_Click);
            // 
            // Tip
            // 
            this.Tip.AutoPopDelay = 5000;
            this.Tip.InitialDelay = 500;
            this.Tip.IsBalloon = true;
            this.Tip.ReshowDelay = 0;
            this.Tip.ShowAlways = true;
            // 
            // Quest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 568);
            this.ContextMenuStrip = this.Right;
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Quest";
            this.Resizable = false;
            this.Text = "任务检索 0822";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Quest_FormClosing);
            this.Load += new System.EventHandler(this.Quest_Load);
            this.TextChanged += new System.EventHandler(this.Quest_TextChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Quest_KeyDown);
            this.tabControl1.ResumeLayout(false);
            this.Quest_.ResumeLayout(false);
            this.Quest_.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Previous)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Next)).EndInit();
            this.Quest_Pnl.ResumeLayout(false);
            this.Quest_Pnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Event)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dungeon_ICON)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dungeon_Grade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dungeon_Type)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Quest_ICON)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Reset_Type)).EndInit();
            this.Right.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog Open;
        private System.Windows.Forms.RichTextBox RichOut;
        private System.Windows.Forms.Label level;
        private System.Windows.Forms.Label RecommendedLevel;
        private MetroFramework.Controls.MetroTabControl tabControl1;
        private MetroFramework.Controls.MetroTabPage Quest_;
        private System.Windows.Forms.Panel Quest_Pnl;
        private System.Windows.Forms.PictureBox Quest_ICON;
        private System.Windows.Forms.Label Quest_Name;
        private System.Windows.Forms.Label Quest_Group;
        private System.Windows.Forms.PictureBox Dungeon_ICON;
        private System.Windows.Forms.Label Dungeon_Name;
        private System.Windows.Forms.PictureBox Dungeon_Type;
        private System.Windows.Forms.PictureBox Dungeon_Grade;
        private System.Windows.Forms.PictureBox Event;
        private System.Windows.Forms.PictureBox Next;
        private System.Windows.Forms.NumericUpDown Num;
        private System.Windows.Forms.ContextMenuStrip Right;
        private System.Windows.Forms.ToolStripMenuItem Show_ID_Input;
        private System.Windows.Forms.ToolStripMenuItem Cancel_Error_Message;
        private System.Windows.Forms.PictureBox Previous;
        private System.Windows.Forms.PictureBox Reset_Type;
        private System.Windows.Forms.ToolStripMenuItem 地图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sortToolStripMenuItem;
        private System.Windows.Forms.ToolTip Tip;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ToolStripMenuItem Reload;
        private System.Windows.Forms.ToolStripMenuItem ShowDesc;
        private System.Windows.Forms.Button button1;
        private MetroFramework.Controls.MetroCheckBox metroCheckBox1;
        private System.Windows.Forms.Button button2;
    }
}