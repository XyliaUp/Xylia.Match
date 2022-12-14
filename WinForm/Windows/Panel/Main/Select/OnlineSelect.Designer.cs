namespace Xylia.Match.Windows
{
    partial class OnlineFileSelect
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
                        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OnlineFileSelect));
                        this.treeViewEx3 = new HZH_Controls.Controls.TreeViewEx();
                        this.SuspendLayout();
                        // 
                        // treeViewEx3
                        // 
                        this.treeViewEx3.BackColor = System.Drawing.Color.Linen;
                        this.treeViewEx3.BorderStyle = System.Windows.Forms.BorderStyle.None;
                        this.treeViewEx3.Dock = System.Windows.Forms.DockStyle.Bottom;
                        this.treeViewEx3.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
                        this.treeViewEx3.ForeColor = System.Drawing.Color.White;
                        this.treeViewEx3.FullRowSelect = true;
                        this.treeViewEx3.HideSelection = false;
                        this.treeViewEx3.IsShowByCustomModel = true;
                        this.treeViewEx3.IsShowTip = false;
                        this.treeViewEx3.ItemHeight = 50;
                        this.treeViewEx3.LineColor = System.Drawing.Color.Azure;
                        this.treeViewEx3.Location = new System.Drawing.Point(0, 60);
                        this.treeViewEx3.LstTips = ((System.Collections.Generic.Dictionary<string, string>)(resources.GetObject("treeViewEx3.LstTips")));
                        this.treeViewEx3.Name = "treeViewEx3";
                        this.treeViewEx3.NodeBackgroundColor = System.Drawing.Color.Linen;
                        this.treeViewEx3.NodeDownPic = ((System.Drawing.Image)(resources.GetObject("treeViewEx3.NodeDownPic")));
                        this.treeViewEx3.NodeForeColor = System.Drawing.Color.Black;
                        this.treeViewEx3.NodeHeight = 50;
                        this.treeViewEx3.NodeIsShowSplitLine = false;
                        this.treeViewEx3.NodeSelectedColor = System.Drawing.Color.NavajoWhite;
                        this.treeViewEx3.NodeSelectedForeColor = System.Drawing.Color.Black;
                        this.treeViewEx3.NodeSplitLineColor = System.Drawing.Color.LightSalmon;
                        this.treeViewEx3.NodeUpPic = ((System.Drawing.Image)(resources.GetObject("treeViewEx3.NodeUpPic")));
                        this.treeViewEx3.ParentNodeCanSelect = true;
                        this.treeViewEx3.ShowLines = false;
                        this.treeViewEx3.ShowPlusMinus = false;
                        this.treeViewEx3.ShowRootLines = false;
                        this.treeViewEx3.Size = new System.Drawing.Size(535, 290);
                        this.treeViewEx3.TabIndex = 5;
                        this.treeViewEx3.TipFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
                        this.treeViewEx3.TipImage = ((System.Drawing.Image)(resources.GetObject("treeViewEx3.TipImage")));
                  //      this.treeViewEx3.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewEx3_AfterSelect);
                        this.treeViewEx3.DoubleClick += new System.EventHandler(this.treeViewEx3_DoubleClick);
                        // 
                        // OnlineFileSelect
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.ClientSize = new System.Drawing.Size(535, 350);
                        this.Controls.Add(this.treeViewEx3);
                        this.FrmTitle = "资源选择";
                        this.IsFullSize = false;
                        this.KeyPreview = true;
                        this.Name = "OnlineFileSelect";
                        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                        this.Text = "云端资源选择";
                        this.Load += new System.EventHandler(this.OnlineFileSelect_Load);
                        this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnlineFileSelect_KeyDown);
                        this.Controls.SetChildIndex(this.treeViewEx3, 0);
                        this.ResumeLayout(false);

        }

        #endregion
        private HZH_Controls.Controls.TreeViewEx treeViewEx3;
    }
}