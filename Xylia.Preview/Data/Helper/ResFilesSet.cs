
using System.Diagnostics;

using Xylia.Extension;
using Xylia.Preview.Properties;

/// <summary>
/// 资源文件路径配置
/// </summary>
public static class ResFilesSet
{
	/// <summary>
	/// 工作文件夹
	/// </summary>
	public static string WorkingDirectory { get; set; } = CommonPath.DataFiles;

	/// <summary>
	/// 走这个方法可能会被代码优化掉，一定要注意调用环境
	/// </summary>
	public static string GetMethod => new StackTrace().GetFrame(2).GetMethod().Name.RemovePrefixString("get_");
}