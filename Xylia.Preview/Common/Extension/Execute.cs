using System.Threading;
using System.Windows.Forms;

using Xylia.Preview.Third.Content;

namespace Xylia.Preview.Common.Extension
{
	public static class Execute
	{
		/// <summary>
		/// 显示窗体
		/// </summary>
		/// <typeparam name="T"></typeparam>
		public static void MyShowDialog<T>() where T : Form, new()
		{
			//方法不能合并，否则会发生线程错误
			var thread = new Thread(act => new T().ShowDialog());
			thread.SetApartmentState(ApartmentState.STA);
			thread.Start();
		}

		/// <summary>
		/// 由于在其他进程创建对象，需要注意控件所在线程
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="Frm"></param>
		public static void MyShowDialog<T>(this T Frm) where T : Form, new()
		{
			var thread = new Thread(act => Frm.ShowDialog());

			thread.SetApartmentState(ApartmentState.STA);
			thread.Start();
		}



		/// <summary>
		/// 输出表格
		/// </summary>
		/// <typeparam name="T"></typeparam>
		public static void ThirdStart<T>() where T : OutBase, new()
		{
			var thread = new Thread(act => new T());

			thread.SetApartmentState(ApartmentState.STA);
			thread.Start();
		}
	}
}
