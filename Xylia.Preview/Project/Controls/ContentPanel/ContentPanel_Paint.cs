using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Xylia.Attribute;
using Xylia.Drawing;
using Xylia.Extension;
using Xylia.Preview.Common.Cast;
using Xylia.Preview.Common.Interface;
using Xylia.Preview.Data.Package.Pak;
using Xylia.Preview.Data.Record;
using Xylia.Preview.Public.Attribute.arg;

namespace Xylia.Preview.Project.Controls
{
	public partial class ContentPanel
	{
		#region 宽度控制
		/// <summary>
		/// 允许的最大宽度
		/// </summary>
		int MaxWidth = 0;

		public bool UseMaxWidth = false;


		float ExpectWidth;

		void TryExtendWidth(float Width) => this.ExpectWidth = Math.Max(this.ExpectWidth, Width);

		/// <summary>
		/// 计算最大宽度
		/// </summary>
		private int GetMaxWidth(Control o, int Padding = 0)
		{
			int MaxWidth = 0;

			//无需自动调整大小的情况
			if (!o.AutoSize)
			{
				if (MaxWidth == 0) MaxWidth = o.Width;
			}

			//获取已设置的限制宽度
			else if (o.MaximumSize.Width != 0) MaxWidth = o.MaximumSize.Width;

			//计算与母容器关系
			else if (o.Parent != null)
			{
				var e = o.Parent;
				if (e is IPreview) return GetMaxWidth(e, o.Left);


				var autoSize = false;
				var autoSizeMode = AutoSizeMode.GrowOnly;
				if (e is UserControl userControl)
				{
					autoSize = userControl.AutoSize;
					autoSizeMode = userControl.AutoSizeMode;
				}
				else if (e is Form form)
				{
					autoSize = form.AutoSize;
					autoSizeMode = form.AutoSizeMode;
				}

				//如果上级控件启用缩放，会导致大量计算。因此此时不应进行宽度处理
				if (!autoSize || autoSizeMode != AutoSizeMode.GrowAndShrink)
				{
					if (autoSize && e.MaximumSize.Width != 0) MaxWidth = e.MaximumSize.Width;
					else MaxWidth = e.Width;


					//扣减其他大小
					Padding += o.Left + 5;
					if (e is Form frm) Padding += 10 + (frm.AutoScroll ? 25 : 0);    //滚动条 20
				}
			}

			return Math.Max(0, MaxWidth - Padding);
		}
		#endregion


		private void PanelContent_Paint(object sender, PaintEventArgs e)
		{
			//初始化
			this.MaxWidth = GetMaxWidth(this);
			this.ExpectWidth = UseMaxWidth ? this.MaxWidth : 0;


			#region 执行绘制
			float LocX = 0, LocY = 0;

			this.Execute(new()
			{
				g = e.Graphics,
				Font = this.Font,
				ForeColor = this.ForeColor,
			},
			this.Text?.Replace("\n", "<br/>"),
			ref LocX, ref LocY, true);
			#endregion


			//变更大小
			if (this.AutoSize)
			{
				this.Width = (int)Math.Ceiling(ExpectWidth + 4.0f);
				this.Height = (int)Math.Floor(LocY);
			}
		}

		/// <summary>
		/// 执行绘制
		/// </summary>
		/// <param name="param"></param>
		/// <param name="InfoHtml"></param>
		/// <param name="LocX"></param>
		/// <param name="LocY"></param>
		/// <param name="Status">是否由主入口方法调用</param>
		/// <returns></returns>
		private void Execute(ExecuteParam param, string InfoHtml, ref float LocX, ref float LocY, bool Status = false)
		{
			int CurLineHeight = param.Font.Height;

			#region 初始化
			var doc = new HtmlAgilityPack.HtmlDocument();
			doc.LoadHtml(InfoHtml);

			#region 移除开头的连续空行
			var Idx = new List<int>();
			for (int i = 0; i < doc.DocumentNode.ChildNodes.Count; i++)
			{
				if (doc.DocumentNode.ChildNodes[i].Name.MyEquals("br")) Idx.Add(i);
				else break;
			}

			//倒序执行
			Idx.Reverse();
			Idx.ForEach(i => doc.DocumentNode.ChildNodes.RemoveAt(i));
			#endregion

			#region 移除最后的连续空行
			for (int i = doc.DocumentNode.ChildNodes.Count - 1; i >= 0; i--)
			{
				if (doc.DocumentNode.ChildNodes[i].Name.MyEquals("br")) doc.DocumentNode.ChildNodes.RemoveAt(i);
				else break;
			}
			#endregion
			#endregion

			#region 绘制图标
			if (Status && this.Icon != null)
			{
				ContentPanel.DrawImage(param.g, this.Icon, ref CurLineHeight, ref LocX, ref LocY);
				LocX += 5;
			}
			#endregion


			#region 处理内容
			foreach (var Node in doc.DocumentNode.ChildNodes)
			{
				if (string.IsNullOrWhiteSpace(Node.Name)) continue;

				var Attribute = Node.CreateAttributeCollection();
				switch (Node.Name.ToLower())
				{
					case "ga": break;

					//绘制去除转义字符的文本
					case "#text": this.DrawString(param, Node.InnerText.Decode(), ref LocX, ref LocY); break;

					//处理换行
					case "br":
					{
						TryExtendWidth(LocX);

						//增加对应的行高并重置为基本行高
						LocX = 0;
						LocY += CurLineHeight + this.HeightPadding;
					}
					break;

					case "p":
					{
						var Justification = Attribute["justification"].ToBool();
						var JustificationType = Attribute["justificationtype"].ToEnum<JustificationType>();

						var BottomMargin = Attribute["bottommargin"];

						var Bullets = Attribute["bullets"];
						var BulletsFontset = Attribute["bulletsfontset"];

						var HorizontalAlignment = Attribute["horizontalalignment"].ToEnum<HorizontalAlignment>();
						param.HorizontalAlignment = HorizontalAlignment;

						//绘制符号图标
						if (Bullets != null)
						{
							this.DrawString(GetFont(param, BulletsFontset), Bullets, ref LocX, ref LocY);
							LocX += 2;
						}

						//绘制文本内容
						this.Execute(param, Node.InnerHtml, ref LocX, ref LocY);

						//创建新行
						LocX = 0;
						LocY += CurLineHeight;
					}
					break;

					case "arg":
					{
						try
						{
							var result = ArgCore.Handle(Attribute, this.Params);
							if (result is Bitmap b) ContentPanel.DrawImage(param.g, b, ref CurLineHeight, ref LocX, ref LocY);
							else if (result != null)
							{
								//数值类型追加千位分隔符
								string TextInfo = result.ToString();
								if (result is int @value || int.TryParse(TextInfo, out @value)) TextInfo = @value.ToString("N0");

								this.Execute(param, TextInfo, ref LocX, ref LocY);
							}
						}
						catch (Exception ex)
						{
							Debug.WriteLine($"处理失败: {Node.OuterHtml}  => {ex.Message}");
							this.Execute(param, "???", ref LocX, ref LocY);
						}
					}
					break;

					//处理字体
					case "font":
					{
						//转到 text 节点进行处理
						var param2 = GetFont(param, Attribute["name"]);
						CurLineHeight = param2.Font.Height;

						this.Execute(param2, Node.InnerHtml, ref LocX, ref LocY);
					}
					break;

					//处理图片
					case "image":
					{
						if (DesignMode) break;

						#region	获取图标
						Bitmap bitmap = null;
						if (Attribute.ContainsName("imagesetpath", out string ImagesetPath))
						{
							bitmap = ImagesetPath.GetUObject().GetImage();
						}

						if (Attribute.ContainsName("path", out string Path))
						{
							bitmap = Path.GetUObject().GetImage();

							string u = Attribute["u"];
							string ul = Attribute["ul"];
							string v = Attribute["v"];
							string vl = Attribute["vl"];
							string Width = Attribute["width"];
							string Height = Attribute["height"];

							//bitmap = bitmap.Clone(new Rectangle(U, V, UL, VL));
						}


						if (bitmap is null)
						{
							LocX += 10;
							Trace.WriteLine($"未知图标: { Node.OuterHtml }");

							break;
						}
						#endregion

						#region 获取缩放设置
						bool EnableScale = Attribute["enablescale"].ToBool();
						if (!EnableScale || !float.TryParse(Attribute["scalerate"], out float ScaleRate)) ScaleRate = 1.0F;
						#endregion


						DrawImage(param.g, bitmap, ref CurLineHeight, ref LocX, ref LocY, EnableScale, ScaleRate);
					}
					break;

					case "link":
					{
						var IgnoreInput = Attribute["ignoreinput"].ToBool();

						var id = Attribute["id"];
						if (id == "none") break;

						//achievement:291_event_SoulEvent_Extreme_0004_step1:123.3.0.1.1.1.626f57f5.1.0.0.0.1
						//item-name:3d0a04.1.270F
						//skill:SRK_B1_DollQueen_AirBomb


						var obj = id.CastObject();
						if (obj is Text @text) this.SetToolTip(text.GetText());
						else obj.PreviewShow();
					}
					break;

					default: Debug.WriteLine("未知标签: " + Node.Name); break;
				}
			}
			#endregion


			//如果由主入口函数调用，增加最后一行对应的行高
			if (Status) LocY += CurLineHeight + this.HeightPadding;

			//处理普通标签的最终宽度
			TryExtendWidth(LocX);
		}


		#region 绘制方法 
		private void DrawString(ExecuteParam param, string Text, ref float LocX, ref float LocY)
		{
			var flag = DrawString(param, Text, ref LocX, ref LocY, this.MaxWidth);
			if (flag) TryExtendWidth(this.MaxWidth);
		}

		private static bool DrawString(ExecuteParam param, string Text, ref float LocX, ref float LocY, int MaxWidth = 0)
		{
			if (string.IsNullOrWhiteSpace(Text)) return false;

			//判断是否需要分行
			var lines = SplitMultiLine(Text, MaxWidth, param.Font, ref LocX, ref LocY);
			lines.ForEach(l => param.g?.DrawString(l.Text, param.Font, new SolidBrush(param.ForeColor), l.Location));

			return lines.Count > 1;
		}

		/// <summary>
		/// 绘制图片
		/// </summary>
		/// <param name="g"></param>
		/// <param name="bitmap"></param>
		/// <param name="CurLineHeight">设置当前行高度</param>
		/// <param name="LocX"></param>
		/// <param name="LocY"></param>
		/// <param name="EnableScale">适应行高</param>
		/// <param name="ScaleRate"></param>
		private static void DrawImage(Graphics g, Bitmap bitmap, ref int CurLineHeight, ref float LocX, ref float LocY, bool EnableScale = true, float ScaleRate = 1.0F)
		{
			if (bitmap is null) return;

			//自适应行高度
			float ScaleRatio = EnableScale ? ((float)CurLineHeight / bitmap.Height) : 1;

			//计算图片比率
			var ratio = ScaleRate * ScaleRatio;
			var CurWidth = (int)(bitmap.Width * ratio);
			var CurHeight = (int)(bitmap.Height * ratio);

			//绘制图像
			g?.DrawImage(bitmap, new Rectangle((int)Math.Ceiling(LocX), (int)Math.Ceiling(LocY - 2), CurWidth, CurHeight));


			//计算新的位置
			LocX += CurWidth;
			CurLineHeight = Math.Max(CurLineHeight, CurHeight);

			//LocY += CurHeight;
		}

		/// <summary>
		/// 根据最大宽度拆分文本行
		/// </summary>
		/// <param name="Txt"></param>
		/// <param name="MaxWidth"></param>
		/// <param name="Font"></param>
		/// <param name="LocX"></param>
		/// <param name="LocY"></param>
		/// <returns></returns>
		public static List<DrawInfo> SplitMultiLine(string Txt, int MaxWidth, Font Font, ref float LocX, ref float LocY)
		{
			var LineTxts = new List<DrawInfo>();

			//起始坐标，用于处理绘制位置
			float StartLocX = LocX;
			float StartLocY = LocY;

			#region 判断数据
			//判断文本总长度是否大于最大宽度
			if (MaxWidth != 0 && (LocX + Txt.MeasureString(Font, false).Width > MaxWidth))
			{
				//当前行的总和宽度（初始需要计算当前的LoX数值）
				var CurTxt = new StringBuilder();

				//逐字符计算信息
				for (int i = 0; i < Txt.Length; i++)
				{
					//计算当前字符宽度
					var CharSize = Txt[i].ToString().MeasureString(Font, false);

					//如果超过最大宽度
					if (LocX + CharSize.Width > MaxWidth)
					{
						//截断之前的文本
						LineTxts.Add(new DrawInfo()
						{
							Text = CurTxt.ToString(),
							Location = new PointF(StartLocX, StartLocY),
						});

						//初始化文本生成器
						CurTxt.Clear();

						//获取换行之后的新的位置信息
						LocX = StartLocX = 0;
						LocY += CharSize.Height;
						StartLocY = LocY;
					}

					//累积信息
					LocX += CharSize.Width;
					CurTxt.Append(Txt[i]);
				}

				//判断是否有剩余的文本
				if (CurTxt.Length != 0 && !string.IsNullOrWhiteSpace(CurTxt.ToString()))
				{
					LineTxts.Add(new DrawInfo()
					{
						Text = CurTxt.ToString(),
						Location = new PointF(StartLocX, StartLocY),
					});
				}

				return LineTxts;
			}
			#endregion



			var size = Txt.MeasureString(Font, false);
			LineTxts.Add(new DrawInfo()
			{
				Text = Txt,
				Location = new PointF(StartLocX, StartLocY),
			});

			//获取下一个绘制起始点
			LocX += size.Width;

			return LineTxts;
		}

		/// <summary>
		/// 获取字体信息
		/// </summary>
		/// <param name="LastParam"></param>
		/// <param name="FontName"></param>
		/// <returns></returns>
		private static ExecuteParam GetFont(ExecuteParam LastParam, string FontName)
		{
			if (FontName is null) return LastParam;

			var Param = (ExecuteParam)LastParam.Clone();

			//提高处理速度
			if (FontName.StartsWith("00008130.Program.Fontset_ItemGrade_"))
			{
				Param.ForeColor = byte.Parse(FontName.Replace("00008130.Program.Fontset_ItemGrade_", null)).ItemGrade();
			}
			else
			{
				var BnsFont = FontName.GetFont();
				if (BnsFont?.Color != null) Param.ForeColor = BnsFont.Color.Value;
				if (BnsFont?.Height != null) Param.Font = new Font(LastParam.Font.FontFamily, BnsFont.Height.Value);
			}

			return Param;
		}
		#endregion
	}


	/// <summary>
	/// 绘制信息结构
	/// </summary>
	public class DrawInfo
	{
		public string Text;

		public PointF Location;
	}
}