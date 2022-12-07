namespace Xylia.Match.Windows.Panel
{
    partial class QuestMatch
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuestMatch));
			this.padding = new System.Windows.Forms.Panel();
			this.Btn_QusetEpic = new HZH_Controls.Controls.UCBtnFillet();
			this.Btn_QuestList = new HZH_Controls.Controls.UCBtnFillet();
			this.metroButton1 = new MetroFramework.Controls.MetroButton();
			this.Num = new HZH_Controls.Controls.UCNumTextBox();
			this.QuestMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.Output_QuestList = new System.Windows.Forms.ToolStripMenuItem();
			this.Output_EpicList = new System.Windows.Forms.ToolStripMenuItem();
			this.QuestMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// padding
			// 
			this.padding.BackColor = System.Drawing.Color.Transparent;
			this.padding.Dock = System.Windows.Forms.DockStyle.Left;
			this.padding.Location = new System.Drawing.Point(0, 0);
			this.padding.Margin = new System.Windows.Forms.Padding(4);
			this.padding.Name = "padding";
			this.padding.Size = new System.Drawing.Size(13, 263);
			this.padding.TabIndex = 19;
			// 
			// Btn_QusetEpic
			// 
			this.Btn_QusetEpic.BackColor = System.Drawing.Color.Transparent;
			this.Btn_QusetEpic.BtnFont = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.Btn_QusetEpic.BtnImage = ((System.Drawing.Image)(resources.GetObject("Btn_QusetEpic.BtnImage")));
			this.Btn_QusetEpic.BtnText = "红尘往事";
			this.Btn_QusetEpic.ConerRadius = 10;
			this.Btn_QusetEpic.FillColor = System.Drawing.Color.Transparent;
			this.Btn_QusetEpic.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.Btn_QusetEpic.IsRadius = true;
			this.Btn_QusetEpic.IsShowRect = true;
			this.Btn_QusetEpic.Location = new System.Drawing.Point(463, 7);
			this.Btn_QusetEpic.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
			this.Btn_QusetEpic.Name = "Btn_QusetEpic";
			this.Btn_QusetEpic.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
			this.Btn_QusetEpic.RectWidth = 1;
			this.Btn_QusetEpic.Size = new System.Drawing.Size(117, 38);
			this.Btn_QusetEpic.TabIndex = 113;
			this.Btn_QusetEpic.BtnClick += new System.EventHandler(this.Btn_QusetEpic_Click);
			// 
			// Btn_QuestList
			// 
			this.Btn_QuestList.BackColor = System.Drawing.Color.Transparent;
			this.Btn_QuestList.BtnFont = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.Btn_QuestList.BtnImage = ((System.Drawing.Image)(resources.GetObject("Btn_QuestList.BtnImage")));
			this.Btn_QuestList.BtnText = "任务列表";
			this.Btn_QuestList.ConerRadius = 10;
			this.Btn_QuestList.FillColor = System.Drawing.Color.Transparent;
			this.Btn_QuestList.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point);
			this.Btn_QuestList.IsRadius = true;
			this.Btn_QuestList.IsShowRect = true;
			this.Btn_QuestList.Location = new System.Drawing.Point(463, 59);
			this.Btn_QuestList.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
			this.Btn_QuestList.Name = "Btn_QuestList";
			this.Btn_QuestList.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
			this.Btn_QuestList.RectWidth = 1;
			this.Btn_QuestList.Size = new System.Drawing.Size(117, 38);
			this.Btn_QuestList.TabIndex = 112;
			this.Btn_QuestList.BtnClick += new System.EventHandler(this.Btn_QuestList_Click);
			// 
			// metroButton1
			// 
			this.metroButton1.Location = new System.Drawing.Point(211, 4);
			this.metroButton1.Margin = new System.Windows.Forms.Padding(4);
			this.metroButton1.Name = "metroButton1";
			this.metroButton1.Size = new System.Drawing.Size(69, 33);
			this.metroButton1.TabIndex = 40;
			this.metroButton1.Text = "加载";
			this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
			// 
			// Num
			// 
			this.Num.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.Num.InputType = HZH_Controls.TextInputType.Number;
			this.Num.IsNumCanInput = true;
			this.Num.KeyBoardType = HZH_Controls.Controls.KeyBoardType.UCKeyBorderNum;
			this.Num.Location = new System.Drawing.Point(21, 0);
			this.Num.Margin = new System.Windows.Forms.Padding(4);
			this.Num.MaxValue = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.Num.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
			this.Num.Name = "Num";
			this.Num.Num = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.Num.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.Num.Size = new System.Drawing.Size(158, 39);
			this.Num.TabIndex = 39;
			this.Num.NumChanged += new System.EventHandler(this.Num_NumChanged);
			// 
			// QuestMenu
			// 
			this.QuestMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Output_QuestList,
            this.Output_EpicList});
			this.QuestMenu.Name = "Right";
			this.QuestMenu.Size = new System.Drawing.Size(149, 48);
			// 
			// Output_QuestList
			// 
			this.Output_QuestList.Name = "Output_QuestList";
			this.Output_QuestList.Size = new System.Drawing.Size(148, 22);
			this.Output_QuestList.Text = "输出任务列表";
			this.Output_QuestList.Click += new System.EventHandler(this.Output_QuestList_Click);
			// 
			// Output_EpicList
			// 
			this.Output_EpicList.Name = "Output_EpicList";
			this.Output_EpicList.Size = new System.Drawing.Size(148, 22);
			this.Output_EpicList.Text = "输出主线列表";
			this.Output_EpicList.Click += new System.EventHandler(this.Output_EpicList_Click);
			// 
			// QuestMatch
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ContextMenuStrip = this.QuestMenu;
			this.Controls.Add(this.Btn_QuestList);
			this.Controls.Add(this.padding);
			this.Controls.Add(this.Btn_QusetEpic);
			this.Controls.Add(this.Num);
			this.Controls.Add(this.metroButton1);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "QuestMatch";
			this.Size = new System.Drawing.Size(682, 263);
			this.QuestMenu.ResumeLayout(false);
			this.ResumeLayout(false);

        }

                #endregion
                public System.Windows.Forms.Panel padding;
        private HZH_Controls.Controls.UCNumTextBox Num;
        private System.Windows.Forms.ContextMenuStrip QuestMenu;
        public MetroFramework.Controls.MetroButton metroButton1;
        private HZH_Controls.Controls.UCBtnFillet Btn_QusetEpic;
        private HZH_Controls.Controls.UCBtnFillet Btn_QuestList;
		private System.Windows.Forms.ToolStripMenuItem Output_QuestList;
		private System.Windows.Forms.ToolStripMenuItem Output_EpicList;
	}
}
