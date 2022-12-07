using System;
using System.Drawing;
using System.Windows.Forms;

namespace Xylia.Preview.Project.Controls
{
	/// <summary>
	/// 绘制参数
	/// </summary>
	public class ExecuteParam : ICloneable
	{
		public Graphics g;


		/// <summary>
		/// 字体
		/// </summary>
		public Font Font;

		/// <summary>
		/// 前景色
		/// </summary>
		public Color ForeColor;

		/// <summary>
		/// 对齐方式
		/// </summary>
		public HorizontalAlignment HorizontalAlignment;



		#region ICloneable
		public object Clone() => this.MemberwiseClone();
		#endregion
	}
}
