
using Xylia.Preview.Project.Controls;

namespace Xylia.Preview.Project.Core.ChallengeList.Cell
{
	partial class ChallengeCell
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChallengeCell));
			this.AttractionInfo = new System.Windows.Forms.Label();
			this.ChallengeIcon = new System.Windows.Forms.PictureBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.ChallengeDifficultyType = new System.Windows.Forms.Label();
			this.ChallengeName = new Xylia.Preview.Project.Controls.ContentPanel();
			((System.ComponentModel.ISupportInitialize)(this.ChallengeIcon)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// AttractionInfo
			// 
			this.AttractionInfo.AutoSize = true;
			this.AttractionInfo.Font = new System.Drawing.Font("Microsoft YaHei UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.AttractionInfo.Location = new System.Drawing.Point(86, 65);
			this.AttractionInfo.Name = "AttractionInfo";
			this.AttractionInfo.Size = new System.Drawing.Size(83, 20);
			this.AttractionInfo.TabIndex = 8;
			this.AttractionInfo.Text = "Attraction";
			// 
			// ChallengeIcon
			// 
			this.ChallengeIcon.Image = ((System.Drawing.Image)(resources.GetObject("ChallengeIcon.Image")));
			this.ChallengeIcon.Location = new System.Drawing.Point(2, 0);
			this.ChallengeIcon.Name = "ChallengeIcon";
			this.ChallengeIcon.Size = new System.Drawing.Size(32, 32);
			this.ChallengeIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.ChallengeIcon.TabIndex = 9;
			this.ChallengeIcon.TabStop = false;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(49, 60);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(32, 32);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 10;
			this.pictureBox1.TabStop = false;
			// 
			// ChallengeDifficultyType
			// 
			this.ChallengeDifficultyType.AutoSize = true;
			this.ChallengeDifficultyType.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.ChallengeDifficultyType.Location = new System.Drawing.Point(3, 35);
			this.ChallengeDifficultyType.Name = "ChallengeDifficultyType";
			this.ChallengeDifficultyType.Size = new System.Drawing.Size(102, 20);
			this.ChallengeDifficultyType.TabIndex = 12;
			this.ChallengeDifficultyType.Text = "DifficultyType";
			// 
			// ChallengeName
			// 
			this.ChallengeName.BackColor = System.Drawing.Color.Transparent;
			//this.ChallengeName.BasicLineHeight = 20;
			this.ChallengeName.Font = new System.Drawing.Font("Microsoft YaHei UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.ChallengeName.ForeColor = System.Drawing.Color.White;
			this.ChallengeName.Location = new System.Drawing.Point(40, 0);
			this.ChallengeName.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
			this.ChallengeName.Name = "ChallengeName";
			this.ChallengeName.TabIndex = 13;
			this.ChallengeName.Text = "课题名称";
			// 
			// ChallengeCell
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.BackColor = System.Drawing.Color.Transparent;
			this.Controls.Add(this.ChallengeName);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.AttractionInfo);
			this.Controls.Add(this.ChallengeDifficultyType);
			this.Controls.Add(this.ChallengeIcon);
			this.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.ForeColor = System.Drawing.Color.White;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "ChallengeCell";
			this.Size = new System.Drawing.Size(535, 95);
			((System.ComponentModel.ISupportInitialize)(this.ChallengeIcon)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label AttractionInfo;
		private System.Windows.Forms.PictureBox ChallengeIcon;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label ChallengeDifficultyType;
		private ContentPanel ChallengeName;
	}
}
