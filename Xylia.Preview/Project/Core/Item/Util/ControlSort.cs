using System.Collections.Generic;
using System.Windows.Forms;

using Xylia.Preview.Project.Controls;


namespace Xylia.Preview.Project.Core.Item.Util
{
	/// <summary>
	/// 用于截图重排序
	/// </summary>
	public class ControlSort : IComparer<Control>
	{
		/// <summary>
		/// 排序，1表示 A在后，-1表示 A在前
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		public int Compare(Control x, Control y)
		{
			if (x is PictureBox || x is PriceCell) return -1;
			else if (y is PictureBox || y is PriceCell) return 1;
			else return 0;
		}
	}
}
