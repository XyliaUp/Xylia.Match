using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

// 有关程序集的一般信息由以下
// 控制。更改这些特性值可修改
// 与程序集关联的信息。
[assembly: AssemblyTitle("预览工具")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Xylia")]
[assembly: AssemblyProduct("Xylia.Preview")]
[assembly: AssemblyCopyright("Copyright ©  2021")]
[assembly: AssemblyTrademark("")]

// 将 ComVisible 设置为 false 会使此程序集中的类型
//对 COM 组件不可见。如果需要从 COM 访问此程序集中的类型
//请将此类型的 ComVisible 特性设置为 true。
[assembly: ComVisible(false)]

// 如果此项目向 COM 公开，则下列 GUID 用于类型库的 ID
[assembly: Guid("a4a1e1f1-9bf8-494d-bdc3-fcca2a09d5f9")]
[assembly: AssemblyVersion("1.10142.*")]



namespace Xylia.Preview
{
	public static class Program
    {
        /// <summary>
        /// 编译版本号（自动)
        /// </summary>
        public static Version BuilderVersion => Assembly.GetExecutingAssembly().GetName().Version;


        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new DebugFrm());
            //Application.Run(new SkillTraitPreview());
        }
    }
}