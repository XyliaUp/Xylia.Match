using System;
using System.Drawing;
using System.IO;
namespace Xylia.Match.Util.HtmlSupport
{
	/// <summary>
	/// 创建css信息
	/// </summary>
	public static class HtmlExtension
	{	
		/// <summary>
		/// 创建字体风格css
		/// </summary>
		/// <param name="sw"></param>
		public static void CreatCss(this StreamWriter sw)
		{
			sw.WriteLine($"<style>" +
								   //设置标题颜色
								   ".Content_Title .Sign {\n" +
								   "    color:#33FF66;\n" +
								   "    font-size:;\n" +
								   "}\n" +

								   //设置标题文本颜色
								   ".Content_Title .Text {\n" +
								   "    color:#33FF66;\n" +
								   "    font-size: ;\n" +
								   "}\n" +

								   //设置旧版本颜色
								   ".Content_Old .Sign {\n" +
								   "    color:#FF0066;\n" +
								   "    font-size: ;\n" +
								   "}\n" +

								   //设置新版本颜色
								   ".Content_New .Sign {\n" +
								   "    color:#FF0066;\n" +
								   "    font-size: ;\n" +
								   "}\n" + 


								    FontCreat() +


								   //为突出Font，未设置时显示为灰色
								   ".Text {\n" +
								   "    color:#C3916A;\n" +
								   "    font-size: ;\n" +
								   "}\n" +

								   "span {\n" +
								   "    color:#D3D3D3;\n" +
								   "}\n" +

								   "body {\n" +
								   "    padding: 0 0 0 50;\n" +
								   "    background: #161615;\n" +
								   "}\n" +


								   ".Separator {\n" +
								   "    color:#8CF0FE\n" +
								   "}\n" +

			$"</style>");
		}



		/// <summary>
		/// 创建字体
		/// </summary>
		/// <returns></returns>
		public static string FontCreat()
		{
			string result = null;

			foreach (var Font in Xylia.Drawing.Font.Util.Fonts)
			{
				// 默认字体大小是游戏内字体的1.5倍
				result += "." + Font.Name?.Replace(".", "_") + " {\n" +

					   "    color:" + ColorTranslator.ToHtml(Font.Color) + ";\n" +

					    //保留一位小数
						(Font.Size == null ? null : "\n\tfont-size: " + (Math.Ceiling((float)Font.Size * 10) * 0.1f).ToString("0.0") + ";") +

					   "\n}\n";
			}

			return result;
		}
	}
}
