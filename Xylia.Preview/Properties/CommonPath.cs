
using System.Diagnostics;

using Xylia.Configure;
using Xylia.Extension;

namespace Xylia.Preview.Properties
{
	public static class CommonPath
	{
		/// <summary>
		/// 工作目录
		/// </summary>
		public static string WorkingDirectory { get; set; } = DataFiles;




		/// <summary>
		/// 输出文件夹
		/// </summary>
		public static string OutputFolder => Ini.ReadValue("Folder", "Output");

		/// <summary>
		/// 数据文件文件夹
		/// </summary>
		public static string DataFiles => Ini.ReadValue("Folder", "PreviewFiles") ?? (OutputFolder + @"\data\files");

		/// <summary>
		/// 游戏目录
		/// </summary>
		public static string GameFolder => Ini.ReadValue("Folder", "Game_Bns");

		public static string ResFolder => OutputFolder + @"\data\res";




		public static bool DataLoadMode => Ini.ReadValue("Preview", "LoadMode").ToBool();
	}
}
