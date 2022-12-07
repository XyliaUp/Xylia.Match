using System;

namespace Xylia.Match
{
	public partial class Select3 : HZH_Controls.Forms.FrmBack
	{
		#region 构造
		public Select3()
		{
			InitializeComponent();
			this.AllowTransparency = true;
		}

		public enum State
		{
			isText = -1,
			isXlsx,
			None,
		}
		#endregion

		#region 字段
		public State Result = State.None;
		#endregion

		#region 方法

		#region 控件方法

		private void Select_Load(object sender, EventArgs e)
		{
			pictureBox1.MouseEnter += ((s, o) => { pictureBox1.BackColor = System.Drawing.Color.FromArgb(255, 224, 192); });
			pictureBox2.MouseEnter += ((s, o) => { pictureBox2.BackColor = System.Drawing.Color.FromArgb(255, 224, 192); });

			pictureBox1.MouseLeave += ((s, o) => { pictureBox1.BackColor = System.Drawing.Color.FromArgb(247, 247, 247); });
			pictureBox2.MouseLeave += ((s, o) => { pictureBox2.BackColor = System.Drawing.Color.FromArgb(247, 247, 247); });

		}

		private void PictureBox1_Click(object sender, EventArgs e)
		{
			Result = State.isText;
			this.Close();
		}

		private void PictureBox2_Click(object sender, EventArgs e)
		{
			Result = State.isXlsx;
			this.Close();
		}

		private void Select3_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
		{

		}

		#endregion

		#region 处理函数
		#endregion

		#endregion


	}
}
