using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;

using Xylia.Match.Properties.SetInfo;

//自动产生编译号
[assembly: AssemblyVersion("2.9.*")]

public static partial class Program
{
	/// <summary>
	/// 发布版本号
	/// </summary>
	public static Version PublishVersion => new(2, 6, 0, 1);

	/// <summary>
	/// 编译版本号（自动)
	/// </summary>
	public static Version BuilderVersion => Assembly.GetExecutingAssembly().GetName().Version;

	/// <summary>
	/// 指定程序名称
	/// </summary>
	public static string Name => Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyProductAttribute>().Product;

	/// <summary>
	/// 指定标题名称
	/// </summary>
	public static string Title => Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyTitleAttribute>().Title;  

	/// <summary>
	/// 公共版本类型
	/// </summary>
	public static VerType GetVerType = VerType.正式版本;
}


/// <summary>
/// 版本类型枚举
/// </summary>
public enum VerType
{
	Undefine = 0,

	开发版本,
	测试版本,

	正式版本,
	特殊版本,
}



/// <summary>
/// 获取配置信息
/// </summary>
public static class MySet
{
	public static Core Core = new Core();


	#region 公共的内存回收机制
	[DllImport("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize")]
	public static extern int SetProcessWorkingSetSize(IntPtr process, int minSize, int maxSize);

	/// <summary>
	/// 释放内存
	/// </summary>
	public static void ClearMemory()
	{
		GC.Collect();
		GC.WaitForPendingFinalizers();

		if (Environment.OSVersion.Platform == PlatformID.Win32NT)
		{
			SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);
		}
	}
	#endregion
}