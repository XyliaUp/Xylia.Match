using System.Collections.Concurrent;

using Xylia.Match.Util.ItemMatch.Util;

namespace Xylia.Match.Util.Game.ItemData.Util
{
	public class FilePath
	{
		/// <summary>备份文件导出路径（在当前版本中即 Chv 格式文件）</summary>
		public string Backup;

		/// <summary>匹配失败文件导出路径</summary>
		public string Failure;

		/// <summary>文件目录路径</summary>
		public string Directory;

		/// <summary>
		/// 失败对象
		/// </summary>
		public BlockingCollection<ItemDataInfo> Failures = new BlockingCollection<ItemDataInfo>();

		public string PlainTXT;
	}
}
