using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Xylia.Preview.Data.Package
{
	public interface IPackage
	{
		/// <summary>
		/// 获取指定名称的文件数据
		/// </summary>
		/// <param name="FileName"></param>
		/// <returns></returns>
		byte[] GetData(string FileName);

		Bitmap GetImage(string FileName);


		bool Contains(string FileName);
	}
}
