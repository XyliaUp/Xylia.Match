﻿namespace Xylia.Match.Windows.Panel
{
    partial class PakExtract
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PakExtract));
			this.Btn_Output = new HZH_Controls.Controls.UCBtnExt();
			this.Select = new HZH_Controls.Controls.UCCombox();
			this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
			this.Path_OutDir = new System.Windows.Forms.TextBox();
			this.ucBtnFillet1 = new HZH_Controls.Controls.UCBtnFillet();
			this.SuspendLayout();
			// 
			// Btn_Output
			// 
			this.Btn_Output.BtnBackColor = System.Drawing.Color.Empty;
			this.Btn_Output.BtnFont = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.Btn_Output.BtnForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.Btn_Output.BtnText = "输出";
			this.Btn_Output.ConerRadius = 8;
			this.Btn_Output.Cursor = System.Windows.Forms.Cursors.Hand;
			this.Btn_Output.DialogResult = System.Windows.Forms.DialogResult.None;
			this.Btn_Output.EnabledMouseEffect = false;
			this.Btn_Output.FillColor = System.Drawing.Color.White;
			this.Btn_Output.Font = new System.Drawing.Font("Microsoft YaHei UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.Btn_Output.IsRadius = true;
			this.Btn_Output.IsShowRect = true;
			this.Btn_Output.IsShowTips = false;
			this.Btn_Output.Location = new System.Drawing.Point(520, 97);
			this.Btn_Output.Margin = new System.Windows.Forms.Padding(0);
			this.Btn_Output.Name = "Btn_Output";
			this.Btn_Output.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.Btn_Output.RectWidth = 1;
			this.Btn_Output.Size = new System.Drawing.Size(85, 38);
			this.Btn_Output.TabIndex = 102;
			this.Btn_Output.TabStop = false;
			this.Btn_Output.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
			this.Btn_Output.TipsText = "";
			this.Btn_Output.BtnClick += new System.EventHandler(this.Btn_Output_BtnClick);
			// 
			// Select
			// 
			this.Select.BackColor = System.Drawing.Color.RosyBrown;
			this.Select.BoxStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.Select.ConerRadius = 10;
			this.Select.DropPanelHeight = -1;
			this.Select.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.Select.ForeColor = System.Drawing.Color.White;
			this.Select.IsRadius = true;
			this.Select.IsShowRect = true;
			this.Select.ItemWidth = 30;
			this.Select.Location = new System.Drawing.Point(306, 97);
			this.Select.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
			this.Select.Name = "Select";
			this.Select.RectColor = System.Drawing.Color.RosyBrown;
			this.Select.RectWidth = 1;
			this.Select.SelectedIndex = -1;
			this.Select.Size = new System.Drawing.Size(179, 38);
			this.Select.Source.Add("GameUI_Icon");
			this.Select.Source.Add("GameUI_Icon2nd");
			this.Select.Source.Add("GameUI_Icon3rd");
			this.Select.Source.Add("GameUI_Icon4th");
			this.Select.Source.Add("GameUI_Icon5th");
			this.Select.Source.Add("GameUI_Icon6th");
			this.Select.Source.Add("GameUI_Icon7th");
			this.Select.Source.Add("GameUI_Icon8th");
			this.Select.Source.Add("GameUI_Icon9th");
			this.Select.TabIndex = 110;
			this.Select.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.Select.TextValue = "GameUI_Icon";
			this.Select.TriangleColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			// 
			// metroLabel1
			// 
			this.metroLabel1.AutoSize = true;
			this.metroLabel1.BackColor = System.Drawing.Color.Transparent;
			this.metroLabel1.Location = new System.Drawing.Point(12, 12);
			this.metroLabel1.Name = "metroLabel1";
			this.metroLabel1.Size = new System.Drawing.Size(107, 19);
			this.metroLabel1.TabIndex = 112;
			this.metroLabel1.Text = "请选择输出目录";
			// 
			// Path_OutDir
			// 
			this.Path_OutDir.Location = new System.Drawing.Point(12, 37);
			this.Path_OutDir.Name = "Path_OutDir";
			this.Path_OutDir.Size = new System.Drawing.Size(566, 23);
			this.Path_OutDir.TabIndex = 111;
			this.Path_OutDir.TextChanged += new System.EventHandler(this.Path_OutDir_TextChanged);
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
			this.ucBtnFillet1.Location = new System.Drawing.Point(596, 32);
			this.ucBtnFillet1.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
			this.ucBtnFillet1.Name = "ucBtnFillet1";
			this.ucBtnFillet1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
			this.ucBtnFillet1.RectWidth = 1;
			this.ucBtnFillet1.Size = new System.Drawing.Size(94, 37);
			this.ucBtnFillet1.TabIndex = 113;
			this.ucBtnFillet1.BtnClick += new System.EventHandler(this.ucBtnFillet1_BtnClick);
			// 
			// PakExtract
			// 
			this.AllowDrop = true;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.ucBtnFillet1);
			this.Controls.Add(this.metroLabel1);
			this.Controls.Add(this.Path_OutDir);
			this.Controls.Add(this.Select);
			this.Controls.Add(this.Btn_Output);
			this.Name = "PakExtract";
			this.Size = new System.Drawing.Size(725, 390);
			this.Load += new System.EventHandler(this.PakExtract_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
		private HZH_Controls.Controls.UCBtnExt Btn_Output;
		private HZH_Controls.Controls.UCCombox Select;
		private MetroFramework.Controls.MetroLabel metroLabel1;
		private System.Windows.Forms.TextBox Path_OutDir;
		private HZH_Controls.Controls.UCBtnFillet ucBtnFillet1;
	}
}