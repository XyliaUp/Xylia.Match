using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml;

using HtmlAgilityPack;

using Xylia.Attribute;
using Xylia.bns.Modules.DataFormat.Bin;
using Xylia.bns.Modules.DataFormat.Bin.Handle.Local;
using Xylia.Extension;
using Xylia.Match.Util.HtmlSupport;


namespace Xylia.Match.Util
{
	public class Function
	{
		public Function(Action<object> action)
		{
			GetAction = action;
		}

		public static Action<object> GetAction;

		/// <summary>
		/// 输出汉化
		/// </summary>
		/// <param name="SourcePath"></param>
		/// <param name="OutPath"></param>
		/// <param name="step"></param>
		/// <param name="IsTest"></param>
		public void OutLocal(string SourcePath, string OutPath, Action<int> step, bool IsTest = false)
		{
			#region 初始化
			step(2);
			var Local = new TextBinData(SourcePath).data;
			step(3);

			if (!Local.Any())
			{
				Tip.Message("解析文件失败");
				return;
			}
			#endregion



			#region 输出内容
			if (Path.GetExtension(OutPath) == ".html")
			{
				StreamWriter sw = streamWriter(OutPath);

				int i = 0, index = 1;

				foreach (var item in Local)
				{
					i++;

					if (i >= 30000)
					{
						sw.Close();
						sw.Dispose();
						sw = streamWriter(OutPath.Replace(".html", null) + $"_{ index++ }.html");
						i = 0;
					}

					sw.Write(HtmlConvert($"<div class=\"Content\">" +

																   $"<div class=\"Content_Title\">" +
																		   $"<span class=\"Sign\" >特征值：</span>" +
																		   $"<span class=\"Text\" >{ item.Alias }</span>" +
																   $"</div>" +

																   $"<div class=\"Content_New\" >" +
																			 $"<span class=\"Sign\" >文本：</span>" +
																			 $"<span class=\"Text\" >{ ToHTML(item.Text) }</span>" +
																	$"</div>" +

																   $"<div class=\"Separator\" >{  Line  }</div>" +

														$"</div>"));
				}

				sw.Close();
				sw.Dispose();
			}
			else
			{
				using StreamWriter Out_Main = new(OutPath);
				foreach (var item in Local)
				{
					if (IsTest)
					{
						Out_Main.WriteLine($"    <case handle=\"add\">");
						Out_Main.WriteLine($"      <word Index=\"0\">{ item.Alias }</word>");
						Out_Main.WriteLine($"      <word Index=\"1\"><![CDATA[{ item.Text }]]></word>");
						Out_Main.WriteLine($"    </case>");
					}
					else
					{
						Out_Main.WriteLine($"[{ item.id }]" + item.Alias);
						Out_Main.WriteLine(string.Empty);
						Out_Main.WriteLine($"{item.Text }\n" + Line);
					}
				}
			}
			#endregion

			step(4);
			Local.Clear();
			Local = null;

			GetAction?.Invoke("输出汉化内容完成\n");
			Console.WriteLine("输出汉化内容完成");
		}


		static string Line => "﹋﹊﹋﹊﹋﹊﹋﹊﹋﹊﹋﹊﹋﹊﹋﹊﹋﹊﹋﹊﹋﹊﹋﹊﹋﹊﹋﹊﹋﹊﹋﹊﹋﹊﹋﹊";

		public static StreamWriter streamWriter(string outPath)
		{
			StreamWriter sw = File.AppendText(outPath);
			sw.CreatCss();

			return sw;
		}



		private static List<LocalInfo> GetLocalInfo(string FilePath)
		{
			if (Path.GetExtension(FilePath) == ".xml")
			{
				var result = new List<LocalInfo>();

				XmlDocument XmlDoc = new();
				XmlDoc.Load(FilePath);

				result.AddRange(from XmlNode reccord in XmlDoc.SelectNodes("table/record")
								let Alias = reccord.Attributes["alias"]?.Value
								let Text = reccord.Attributes["text"]?.Value ?? reccord.InnerText
								select new LocalInfo(0, Alias, Text));

				return result;
			}
			
			return new TextBinData(FilePath).data;
		}



		/// <summary>
		/// 文本比较
		/// </summary>
		/// <param name="Path1"></param>
		/// <param name="Path2"></param>
		/// <param name="outPath"></param>
		/// <param name="action"></param>
		/// <returns></returns>
		public static bool Compare(string Path1, string Path2, string outPath, Action<int> action)
		{
			#region 初始化
			if (!Directory.Exists(Path.GetDirectoryName(outPath)))
				Directory.CreateDirectory(Path.GetDirectoryName(outPath));


			action(2);

			var sw = streamWriter(outPath);

			var Sin_Old = new Dictionary<string, LocalInfo>();  //旧汉化文件
			var Sin_New = new Dictionary<string, LocalInfo>();  //新汉化文件

			foreach (var a in GetLocalInfo(Path1).Where(info => !string.IsNullOrWhiteSpace(info.Alias)))
			{
				if (!Sin_Old.ContainsKey(a.Alias)) Sin_Old.Add(a.Alias, a);

			}

			foreach (var a in GetLocalInfo(Path2).Where(info => !string.IsNullOrWhiteSpace(info.Alias)))
			{
				if (!Sin_New.ContainsKey(a.Alias)) Sin_New.Add(a.Alias, a);

			}
			#endregion




			#region 进行比对
			action(3);
			bool HasChanged = false;


			foreach (var Item in Sin_New)
			{
				//如果旧汉化中没有，判断为新增
				if (!Sin_Old.ContainsKey(Item.Key))
				{
					HasChanged = true;

					sw.Write(HtmlConvert($"<div class=\"Content\">" +
											$"<div class=\"Content_Title\">" +
											$"<span class=\"Sign\" >[新增] 特征值：</span>" +
											$"<span class=\"Text\" >{ Item.Value.Alias }</span>" +
										 $"</div>" +
										 $"<div class=\"Content_New\" >" +
											$"<span class=\"Sign\" >文本：</span>" +
											$"<span class=\"Text\" >{ ToHTML(Item.Value.Text) }</span>" +
										 $"</div>" +

										 $"<div class=\"Separator\" >{  Line  }</div>" +
										 $"</div>"));


					//Debug.WriteLine(Item.Value.Alias + "$" + Item.Value.Text);
				}


				//如果旧汉化中有，但是不相同
				else
				{
					if (Sin_Old[Item.Key].Text == Item.Value.Text) continue;

					HasChanged = true;

					string Txt1 = ToHTML(Sin_Old[Item.Key].Text, out bool IsMultiLine1);
					string Txt2 = ToHTML(Item.Value.Text, out bool IsMultiLine2);


					sw.Write(HtmlConvert($"<div class=\"Content\">" +
											$"<div class=\"Content_Title\">" +
											$"<span class=\"Sign\" >[修改] 特征值：</span>" +
											$"<span class=\"Text\" >{ Item.Key }</span>" +
										$"</div>" +

										$"<div class=\"Content_Old\" >" +
											$"<span class=\"Sign\" >旧版本：</span>" +
											$"<span class=\"Text\" >{ Txt1 }</span>" +
										$"</div>" +

										//当文本信息大于单行时进行换行显示
										(IsMultiLine1 || IsMultiLine2 ? "<br/>" : null) +

										$"<div class=\"Content_New\">" +
											$"<span class=\"Sign\" >新版本：</span>" +
											$"<span class=\"Text\" >{ Txt2 }</span>" +
										$"</div>" +

										$"<div class=\"Separator\" >{ Line }</div>" +

										$"</div>"));
				}
			}

			//遍历旧汉化文件并与新文件比对值
			foreach (var Item in Sin_Old)
			{
				if (!Sin_New.ContainsKey(Item.Key))
				{
					HasChanged = true;

					sw.Write(HtmlConvert($"<div class=\"Content\">" +
											$"<div class=\"Content_Title\">" +
											$"<span class=\"Sign\" >[删除] 特征值：</span>" +
											$"<span class=\"Text\" >{ Item.Key }</span>" +
										 $"</div>" +

										 $"<div class=\"Content_Old\" >" +
											$"<span class=\"Sign\" >文本：</span>" +
											$"<span class=\"Text\" >{ ToHTML(Item.Value.Text) }</span>" +
										 $"</div>" +

										 $"<div class=\"Separator\" >{  Line  }</div>" +
										 $"</div>"));
				}
			}
			#endregion

			#region 最后处理
			action(4);
			Sin_Old.Clear();
			Sin_New.Clear();


			sw.Flush();
			sw.Close();
			sw.Dispose();
			GC.Collect();
			#endregion

			return HasChanged;
		}


		/// <summary>
		/// Html处理
		/// </summary>
		/// <param name="Text"></param>
		/// <returns></returns>
		public static string HtmlConvert(string Text)
		{
			return Text.Replace("\n", "<br/>\n");
		}


		/// <summary>
		/// 游戏专用Xml信息转换为Html信息
		/// </summary>
		/// <param name="Text"></param>
		/// <returns></returns>
		public static string ToHTML(string Text)
		{
			return ToHTML(Text, out _);
		}

		public static string ToHTML(string Text, out bool IsMultiLine)
		{
			IsMultiLine = false;
			if (Text.IsNull()) return null;

			try
			{

				HtmlDocument doc = new();
				doc.LoadHtml(Text);


				string Result = null;
				foreach (var Node in doc.DocumentNode.ChildNodes.ToList().Where(Node => !Node.Name.IsNull()))
				{
					Result += HandleProperty(Node);
				}

				IsMultiLine = Regex.IsMatch(Result, @"<\s*" + "br" + @"\s*/" + @"\s*>", RegexOptions.IgnoreCase);
				return (IsMultiLine ? "\n" : null) + Result;
			}
			catch (Exception ee)
			{
				Debug.WriteLine("[ToHTML]" + ee.Message);
				return Text;
			}
		}

		public static string HandleProperty(HtmlNode Node)
		{
			var HtmlAttr = Node.CreateAttributeCollection();
			switch (Node.Name.ToLower())
			{
				//文本
				case "#text": return Node.InnerText;

				case "p":
				{
					return $@"<p style='text-align:{  HtmlAttr["horizontalalignment"] }; '>";
				}

				case "arg":
				{
					#region 初始化
					var p = HtmlAttr["p"];
					var id = HtmlAttr["id"];
					var link = HtmlAttr["link"];

					string Content = null;
					#endregion

					#region 处理
					if (!p.IsNull() && p.MyContains("id"))
					{
						var Temp = id.Split(':');
						Content = p.Replace("id:", null) + "." + Temp[1] ?? Temp[0];
					}

					return $@"<span>{ Content }</span>";
					#endregion
				}


				//图片处理
				case "image":
				{
					#region	初始化
					var EnablesScale = HtmlAttr["enablescale"].ToBool();
					var Imagesetpath = HtmlAttr["imagesetpath"];
					var Path = HtmlAttr["path"];

					float.TryParse(HtmlAttr["scalerate"], out float result);
					#endregion

					#region 处理
					if (EnablesScale)
					{
						//width={ img.ScaleRate *100  }% height={ img.ScaleRate * 100 }%
					}

					string IMG_Path = Imagesetpath ?? Path;
					string[] Temp = IMG_Path.Split('.');

					if (Temp.Length >= 2)
					{
						string FileName = Temp[0] + @"\" + Temp[1] + ".png";

						return $@"<img src='file://{  Xylia.Configure.PathDefine.MainFolder }Resources\Package\{ FileName }'>";
					}
					#endregion
				}
				break;


				//字体处理
				case "font":
				{
					//获得字体名称
					string FontName = HtmlAttr["name"];

					//用于提示颜色异常
					//Color? CurColor = null;

					//仅读取颜色信息
					if (!FontName.IsNull())
					{
						//去除掉包名
						if (FontName.Contains(".")) FontName = FontName.Replace(FontName.Split('.')[0] + ".", null);
					}

					return $"<span class=\"{ FontName?.Replace(".", "_") }\">{  Node.InnerText }</span>";
				}
			}

			return Node.OuterHtml;
		}
	}
}
