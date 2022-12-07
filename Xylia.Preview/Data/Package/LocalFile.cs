using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Xylia.Preview.Data.Package
{
	public class LocalFile : IPackage
	{
		/// <summary>
		/// 获取文件信息
		/// </summary>
		/// <param name="SearchRule"></param>
		/// <param name="DirectoryInfo"></param>
		/// <returns></returns>
		public static List<FileInfo> GetFileInfo(string SearchRule, params DirectoryInfo[] DirectoryInfo)
		{
			var Result = new List<FileInfo>();
			foreach (var DirInfo in DirectoryInfo)
				Result.AddRange(DirInfo.GetFiles(SearchRule));

			return Result;
		}


		#region 构造
		public LocalFile(string FullFilePath)
		{
			this.FullFilePath = FullFilePath;
		}
		#endregion


		#region 字段
		public string FullFilePath;
		#endregion


		#region 接口方法
		public byte[] GetData(string FileName)
		{
			return this.Contains(FullFilePath) ? File.ReadAllBytes(FullFilePath) : null;
		}

		public Bitmap GetImage(string FileName)
		{
			if(File.Exists(FullFilePath)) return new Bitmap(FullFilePath);

			System.Diagnostics.Debug.WriteLine(FileName + " 不存在");
			return null;
		}

		public bool Contains(string FileName)
		{
			return File.Exists(FullFilePath);
		}
		#endregion
	}
}
