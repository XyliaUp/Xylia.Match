
using Xylia.Configure;


namespace Xylia.Preview.Properties
{
	public static class CommonPath
	{
		/// <summary>
		/// 输出文件夹
		/// </summary>
		public static string OutputFolder => Ini.ReadValue("Folder", "Output");

		/// <summary>
		/// 数据文件文件夹
		/// </summary>
		public static string DataFiles => Ini.ReadValue("Folder", "PreviewFiles") ?? (OutputFolder + @"\data\files");


		public static string GameFolder => Ini.ReadValue("Folder", "Game_Bns");

		public static string ResFolder => OutputFolder + @"\data\res";
	}
}
