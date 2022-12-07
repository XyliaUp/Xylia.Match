using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

using Xylia.Match.Util.Writer;

// 有关程序集的一般信息由以下
// 控制。更改这些特性值可修改
// 与程序集关联的信息。
[assembly: AssemblyTitle("剑灵检索工具")]
[assembly: AssemblyProduct("Xylia.Match")]

[assembly: AssemblyDescription("Some useful tools for B&S.")]
[assembly: AssemblyConfiguration("版本")]
[assembly: AssemblyCompany("Xylia")]
[assembly: AssemblyCopyright("©2018-2023 Xylia, all rights reserved. Licensed to current user.")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// 将 ComVisible 设置为 false 会使此程序集中的类型
// 对 COM 组件不可见。如果从 COM 访问此程序集中的类型
// 请将此类型的 ComVisible 特性设置为 true。
[assembly: ComVisible(false)]

// 如果此项目向 COM 公开，则下列 GUID 用于类型库的 ID
[assembly: Guid("d6bc38a4-6f86-4c29-a754-339e3025eeb9")]


public static partial class Program
{
	[STAThread]
	static void Main(string[] args = null)
	{
		#region 进程载入初始化
		Application.EnableVisualStyles();
		Application.SetCompatibleTextRenderingDefault(false);
		Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
		AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
		AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
		#endregion

		try
		{
			//重写Writer方法
			new DebugWriter();

			#region 判断主进程等级
			if (new List<string>(args).Contains("-Test"))
			{
#if DEBUG
				//GetVerType = VerType.开发版本;
#endif
			}

			#endregion

			Logger.Write($"创建进程成功。");
			Console.WriteLine($"当前版本号{ Program.PublishVersion }");
		}
		catch (Exception ee)
		{
			MessageBox.Show("发生了以下问题：" + ee.Message, "资源读取失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}


		//var thread = new Thread(t =>
		//{

		//开始运行
		Application.Run(new Xylia.Match.Windows.MainForm() { });

		//});

		//thread.SetApartmentState(ApartmentState.STA);
		//thread.Start();
	}




	static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
	{
		Exception error = e.ExceptionObject as Exception;
		string strDateInfo = "出现应用程序未处理的异常：" + DateTime.Now.ToString() + "\n异常错误";

		string str;
		if (error == null) str = e.ToString();
		else str = $"{ strDateInfo }\n{ error.Message };\n堆栈信息:{ error.StackTrace }";

		Application_ExceptionHandle(error, str);
	}

	/// <summary>
	/// 应用程序线程错误
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
	{
		string strDateInfo = "出现应用程序未处理的异常：" + DateTime.Now.ToString() + "\n";
		var error = e.Exception;

		string str = string.Empty;
		if (error is null) str = string.Format("应用程序线程错误:{0}", e);
		else str = $"{ strDateInfo }异常类型：{ error.GetType().Name }\n异常消息：{ error.Message }\n异常信息：{ error.StackTrace }";

		Application_ExceptionHandle(error, str);
	}

	/// <summary>
	/// 应用程序错误处理
	/// </summary>
	/// <param name="error"></param>
	/// <param name="str"></param>
	static void Application_ExceptionHandle(Exception error, string str)
	{
		Logger.Write(str, MsgInfo.MsgLevel.崩溃);
		if (error is InvalidOperationException) return;
		if (error is CSCore.MmException) return;

		//HZH_Controls.Forms.FrmTips.ShowTipsError("发生致命错误，请立即暂停操作并及时联系开发者！");
		MessageBox.Show(str);
	}

	static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
	{
		string ArgName = new AssemblyName(args.Name).Name;

		var stream = GetResourceStream("Xylia.Match.RunTimes." + ArgName);
		if (stream != null)
		{
			byte[] assemblyData = new byte[stream.Length];
			stream.Read(assemblyData, 0, assemblyData.Length);

			stream.Close();
			stream.Dispose();

			if (!ArgName.Contains(".resources")) Logger.Write($"成功载入 { ArgName }.dll", MsgInfo.MsgLevel.调试);
			return Assembly.Load(assemblyData);
		}

		return null;
	}

	/// <summary>
	/// 获取资源文件流
	/// </summary>
	/// <param name="MainName"></param>
	/// <returns></returns>
	static Stream GetResourceStream(string MainName)
	{
		var Names = new List<string>
		{
			MainName + ".dll",
			MainName + ".exe"
		};

		foreach (var CurName in Names)
		{
			var Result = Assembly.GetEntryAssembly()?.GetManifestResourceStream(CurName);
			if (Result != null) return Result;
		};

		return null;
	}
}