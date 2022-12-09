﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

using HZH_Controls.Forms;

using Xylia.Configure;
using Xylia.Drawing;
using Xylia.Extension;
using Xylia.Match.Util.Paks;
using Xylia.Preview.Project.Core.Item.Cell;
using Xylia.Windows.Forms;

using static Xylia.Drawing.Compose;
using static Xylia.Preview.Properties.Resources;



namespace Xylia.Match.Windows.Panel
{
	public partial class IconOperator : UserControl
	{
		#region 构造
		public IconOperator()
		{
			IsInitialization = true;

			//Logger.Write($"启用图标匹配模块");

			InitializeComponent();

			this.DoubleBuffered = true;
			CheckForIllegalCrossThreadCalls = false;

			this.tabControl1.SelectedIndex = 0;


			#region 初始化道具属性选择框
			foreach (var Item in CombineOption.Grade_Bitmap) metroComboBox1.Items.Add(Item.Name);
			foreach (var Item in CombineOption.Attach_Bitmap) metroComboBox2.Items.Add(Item.Name);
			foreach (var Item in CombineOption.Trade_Bitmap) metroComboBox3.Items.Add(Item.Key.ToString());

			MetroButton3_Click_1(null, null);
			#endregion


			SetStyle(ControlStyles.UserPaint, true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
			SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲
		}
		#endregion

		#region 字段
		private Thread Thread_ItemIcon;

		private Thread Thread_GoodIcon;

		CombineOption.Prop GetProp = new();

		bool IsInitialization = false;

		private string IconPath;
		#endregion



		#region 控件方法
		private void UPK_Load(object sender, EventArgs e)
		{
			//初始化文本框路径
			//this.ReadConfig(this.GetType().Name);

			Path_ResultPath.Text = MySet.Core.Icon_ResultPath;
			Path_GameFolder.Text = MySet.Core.Folder_Game_Bns;
			metroTextBox1.Text = MySet.Core.Icon_Chv;


			#region  读取输出格式设置
			string FormatSel = Xylia.Configure.Ini.ReadValue("Match_ICON", "FormatSel");

			if (FormatSel.IsNull() || !FormatSel.Contains('[')) FormatSelect.Text = FormatSelect.Source.First().ToString();
			else FormatSelect.TextValue = FormatSel;
			#endregion


			if (bool.TryParse(Ini.ReadValue("Match_ICON", "Mode"), out bool Result)) Switch_Mode.Checked = Result;
			if (bool.TryParse(Ini.ReadValue("Match_ICON", "HasBG"), out Result)) checkBox1.Checked = Result;
			if (bool.TryParse(Ini.ReadValue("Match_ICON", "WriteLog"), out Result)) checkBox2.Checked = Result;

		}

		private void FormatSelect_MouseEnter(object sender, EventArgs e)
		{
			string Msg = "*可自定义输出格式  特殊规则为 [id]、[name/名称]、[alias/别名]\n（建议使用英文，英文不区分大小写)";
			FrmAnchorTips.ShowTips(FormatSelect, Msg, AnchorTipsLocation.BOTTOM, Color.MediumOrchid, Color.FloralWhite, null, 12, 0, false);
		}

		private void FormatSelect_TextChanged(object sender, EventArgs e)
		{
			string SaveTxt = FormatSelect.TextValue;
			Xylia.Configure.Ini.WriteValue("Match_ICON", "FormatSel", SaveTxt);
		}

		private void Path_ResultPath_TextChanged(object sender, EventArgs e)
		{
			MySet.Core.Icon_ResultPath = ((Control)sender).Text;
		}

		private static bool GetBitmap(List<string> Files, string Key, out Bitmap Bitmap)
		{
			var fs = Files.Where(f => Path.GetFileNameWithoutExtension(f).ToLower().Contains(Key.ToLower()));
			if (fs.Any())
			{
				Bitmap = SetImage.Load(fs.First());
				return true;
			}

			Bitmap = null;
			return false;
		}



		private void GemPage_DragDrop(object sender, DragEventArgs e)
		{
			var Files = ((string[])e.Data.GetData(DataFormats.FileDrop)).ToList();
			if (Files.Count >= 2)
			{
				if (GetBitmap(Files, "pos1", out Bitmap temp)) GemCircle.Meta1 = temp;
				if (GetBitmap(Files, "pos2", out temp)) GemCircle.Meta2 = temp;
				if (GetBitmap(Files, "pos3", out temp)) GemCircle.Meta3 = temp;
				if (GetBitmap(Files, "pos4", out temp)) GemCircle.Meta4 = temp;
				if (GetBitmap(Files, "pos5", out temp)) GemCircle.Meta5 = temp;
				if (GetBitmap(Files, "pos6", out temp)) GemCircle.Meta6 = temp;
				if (GetBitmap(Files, "pos7", out temp)) GemCircle.Meta7 = temp;
				if (GetBitmap(Files, "pos8", out temp)) GemCircle.Meta8 = temp;
			}
			else if (Files.Count != 0)
			{
				Bitmap bitmap = SetImage.Load(Files.First());

				switch (GemCircle.PartSel)
				{
					case GemCircle.PartSection.Part1: GemCircle.Meta1 = bitmap; break;
					case GemCircle.PartSection.Part2: GemCircle.Meta2 = bitmap; break;
					case GemCircle.PartSection.Part3: GemCircle.Meta3 = bitmap; break;
					case GemCircle.PartSection.Part4: GemCircle.Meta4 = bitmap; break;
					case GemCircle.PartSection.Part5: GemCircle.Meta5 = bitmap; break;
					case GemCircle.PartSection.Part6: GemCircle.Meta6 = bitmap; break;
					case GemCircle.PartSection.Part7: GemCircle.Meta7 = bitmap; break;
					case GemCircle.PartSection.Part8: GemCircle.Meta8 = bitmap; break;

					default:
					{
						Xylia.Tip.Message("请先通过鼠标选择一个八卦牌部位");
						Console.WriteLine("暂不支持类型：" + GemCircle.PartSel);
					}
					break;
				}
			}
		}

		private void GemPage_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true) e.Effect = DragDropEffects.All;
		}

		private void GemPage_Click(object sender, EventArgs e)
		{
			this.GemCircle.PartSel = GemCircle.PartSection.Init;
		}

		private void metroButton6_Click(object sender, EventArgs e)
		{
			SaveFileDialog.Filter = "PNG格式|*.png|GIF格式|*.gif|JPEG格式|*.jpg|位图格式|*.bmp|ICO格式|*.ico";
			SaveFileDialog.FileName = "ItemSet_Compose";


			if (SaveFileDialog.ShowDialog() == DialogResult.OK)
			{
				ImageFormat Format = ImageFormat.Png;

				switch (SaveFileDialog.DefaultExt)
				{
					case ".png": Format = ImageFormat.Png; break;
					case ".gif": Format = ImageFormat.Gif; break;
					case ".jpg": Format = ImageFormat.Jpeg; break;
					case ".bmp": Format = ImageFormat.Bmp; break;
					case ".ico": Format = ImageFormat.Icon; break;
				}

				GemCircle.Image.Save(SaveFileDialog.FileName, Format);
			}
		}

		private void metroButton7_Click(object sender, EventArgs e)
		{
			this.GemCircle.Clear();
			this.GemCircle.PartSel = GemCircle.PartSection.Part1;
		}

		private void GemCircle_SelectPartChanged(object sender, EventArgs e)
		{
			string PartName = GemCircle.PartConvert.ContainsKey(this.GemCircle.PartSel) ? GemCircle.PartConvert[this.GemCircle.PartSel] : this.GemCircle.PartSel.ToString();

			metroLabel6.Text = $"需要更改部位时，请点击对应的区域\n\n当前选择：{ PartName }";
		}

		private void ucSwitch1_CheckedChanged(object sender, EventArgs e)
		{
			this.GemCircle.Transparent = !this.GemCircle.Transparent;
		}

		private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

	



	
		private void MetroButton3_Click(object sender, EventArgs e)
		{
			if (Folder.ShowDialog() == DialogResult.OK) Path_GameFolder.Text = Folder.SelectedPath;
		}

		private void Btn_Search_2_Click(object sender, EventArgs e)
		{
			if (Folder.ShowDialog() == DialogResult.OK) Path_ResultPath.Text = Folder.SelectedPath;
		}

		private void Match_ICON_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true) e.Effect = DragDropEffects.All;
		}

		private void Match_ICON_DragDrop(object sender, DragEventArgs e)
		{
			string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
			if (files.Length == 0) return;

			this.IconPath = Path.GetFileNameWithoutExtension(files[0]);

			byte[] ByteArray = null;

			Stream stream = new FileStream(files[0], FileMode.Open);

			if (stream != null && stream.Length > 0)
			{
				stream.Position = 0;

				using BinaryReader br = new(stream);
				ByteArray = br.ReadBytes((int)stream.Length);
			}


			GetProp.Icon = ByteArray;

			//配置默认另存选项
			if (SetImage.Load(GetProp.Icon).Width > 64) Radio_128px.Checked = true;
			else Radio_64px.Checked = true;

			RenderPropImg();
		}


		/// <summary>
		/// 图层重绘
		/// </summary>
		public void RenderPropImg()
		{
			pictureBox1.Image = GetProp.DrawICON();
			pictureBox4.Image = GetProp.DrawICON(2);
		}

		private void Path_GameFolder_TextChanged(object sender, EventArgs e)
		{
			if (Directory.Exists(Path_GameFolder.Text))
			{
				MySet.Core.Folder_Game_Bns = ((Control)sender).Text;
			}
		}

		private void 清除临时文件ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Announcement announcement = new("即将进行资源清理操作，是否确认？")
			{
				ExitText = "退出",
				OkText = "确认"
			};

			if (announcement.ShowDialog() == DialogResult.OK)
			{
				return;
			}
		}

		private void Btn_Search_3_Click(object sender, EventArgs e)
		{
			Open.Filter = "数据配置文件|*.chv|所有文件|*.*";

			if (int.TryParse(Xylia.Configure.Ini.ReadValue("Match_ICON", "Filter1"), out int Result)) Open.FilterIndex = Result;

			if (Open.ShowDialog() == DialogResult.OK)
			{
				metroTextBox1.Text = Open.FileName;
				Xylia.Configure.Ini.WriteValue("Match_ICON", "Filter1", Open.FilterIndex);
			}
		}

		private void MetroTextBox1_TextChanged(object sender, EventArgs e)
		{
			MySet.Core.Icon_Chv = ((Control)sender).Text;
		}

		private void MetroButton1_Click(object sender, EventArgs e)
		{
			SaveFileDialog.FileName = "配置文件";
			SaveFileDialog.Filter = "Xylia Value 配置文件|*.chv";

			if (SaveFileDialog.ShowDialog() == DialogResult.OK)
			{
				Thread thread = new((ThreadStart)delegate
				{
					int Count = 1;

					using (StreamWriter sw = new(SaveFileDialog.FileName))
					{
						string FolderPath = this.Path_ResultPath.Text + @"\物品";
						if (!Directory.Exists(FolderPath))
						{
							FolderPath = Path_ResultPath.Text;
							this.Invoke(new Action(() => Xylia.Tip.SendMessage("由于不存在目标子文件夹，已变更为扫描所选的<输出目录>")));
						}

						var Files = new DirectoryInfo(FolderPath).GetFiles();
						foreach (FileInfo fileInfo in Files)
						{
							this.Invoke(new Action(() => Footer.Text = $"正在生成配置文件  { 100 * Count++ / Files.Length  }%"));

							if (fileInfo.Name.Contains('_'))
							{
								string[] Temp = fileInfo.Name.Split('_');

								foreach (var T in Temp) if (int.TryParse(T.Replace(".png", null), out int Result)) sw.WriteLine(Result);
							}
							else if (int.TryParse(fileInfo.Name.Replace(".png", null), out int ItemID))
							{
								sw.WriteLine(ItemID);
							}
						}
					}

					this.Invoke(new Action(() =>
					{
						Footer.Text = $"输出配置文件已完成";
						Xylia.Tip.SendMessage("输出配置文件已完成！");
					}));
				});

				thread.SetApartmentState(ApartmentState.STA);
				thread.Start();
			}
		}

		private void MetroComboBox1_TextChanged(object sender, EventArgs e)
		{
			if (IsInitialization) return;

			foreach (var Item in CombineOption.Grade_Bitmap)
			{
				if (Item.Name == metroComboBox1.Text)
				{
					GetProp.GradeImage = Xylia.Preview.Data.Record.ItemExtension.GetBackGround(Item.ItemGrade, ucCheckBox1.Checked);
					break;
				}
			}

			RenderPropImg();
		}

		private void MetroComboBox2_TextChanged(object sender, EventArgs e)
		{
			if (IsInitialization) return;
			foreach (var Item in CombineOption.Attach_Bitmap)
			{
				if (Item.Name == metroComboBox2.Text)
				{
					GetProp.Attach = Item.px64;
					GetProp.Attach128 = Item.px128;
					break;
				}
			}

			RenderPropImg();
		}

		private void MetroComboBox3_TextChanged(object sender, EventArgs e)
		{
			if (IsInitialization) return;
			foreach (var Item in CombineOption.Trade_Bitmap)
			{
				if (Item.Key.ToString() == metroComboBox3.Text)
				{
					GetProp.Trade = Item.Value;
					break;
				}
			}

			RenderPropImg();
		}

		private void MetroButton4_Click(object sender, EventArgs e)
		{
			string ItemName = "道具名称";

			#region 获取道具名称
			if (!this.IconPath.IsNull())
			{
				foreach (var Item in CombineOption.Grade_Bitmap)
				{
					if (Item.Name == metroComboBox1.Text)
					{
						ItemName = this.IconPath + "_" + Item.ItemGrade;
						break;
					}
				}
			}
			#endregion

			SaveFileDialog.FileName = ItemName;
			SaveFileDialog.Filter = "PNG格式|*.png|GIF格式|*.gif|JPEG格式|*.jpg|位图格式|*.bmp|ICO格式|*.ico";

			if (SaveFileDialog.ShowDialog() == DialogResult.OK)
			{
				ImageFormat Format = ImageFormat.Png;

				switch (SaveFileDialog.DefaultExt)
				{
					case ".png": Format = ImageFormat.Png; break;
					case ".gif": Format = ImageFormat.Gif; break;
					case ".jpg": Format = ImageFormat.Jpeg; break;
					case ".bmp": Format = ImageFormat.Bmp; break;
					case ".ico": Format = ImageFormat.Icon; break;
				}


				if (Radio_64px.Checked)
				{
					pictureBox1.Image.Save(SaveFileDialog.FileName, Format);
				}
				else
				{
					pictureBox4.Image.Save(SaveFileDialog.FileName, Format);
				}
			}
		}

		private void MetroButton3_Click_1(object sender, EventArgs e)
		{
			if (metroComboBox1.Items.Count > 7) metroComboBox1.Text = metroComboBox1.Items[7].ToString();
			if (metroComboBox2.Items.Count != 0) metroComboBox2.Text = metroComboBox2.Items[0].ToString();
			if (metroComboBox3.Items.Count != 0) metroComboBox3.Text = metroComboBox3.Items[0].ToString();

			GetProp = new CombineOption.Prop();

			pictureBox1.Image = ItemIcon_Bg_Grade_7;
			pictureBox4.Image = ItemIcon_Bg_Grade_7.ImageThumbnail(2);
		}

		private void tabPage1_DragDrop(object sender, DragEventArgs e)
		{
			string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
			if (files.Length == 0) return;


			try
			{
				Stream stream = new FileStream(files[0], FileMode.Open);
				if (stream != null && stream.Length > 0)
				{
					stream.Position = 0;

					using BinaryReader br = new(stream);
					byte[] ByteArray = br.ReadBytes((int)stream.Length);
				}
			}
			catch
			{

			}
		}

		private void tabPage1_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
				e.Effect = DragDropEffects.All;
		}

		private void ucCheckBox1_CheckedChangeEvent(object sender, EventArgs e)
		{
			MetroComboBox1_TextChanged(null, null);
			RenderPropImg();
		}


		private void Switch_HasBG_MouseEnter(object sender, EventArgs e)
		{
			string Msg = checkBox1.Checked ? "生成道具图标时\n会附带道具品级" : "只生成出道具的\n透明背景图标";
			FrmAnchorTips.ShowTips(checkBox1, Msg, AnchorTipsLocation.BOTTOM, Color.MediumOrchid, Color.FloralWhite, null, 12, 3500, false);
		}

		private void Switch_HasBG_MouseLeave(object sender, EventArgs e)
		{
			FrmAnchorTips.CloseLastTip();
		}


		private void Switch_Mode_MouseEnter(object sender, EventArgs e)
		{
			string Msg = Switch_Mode.Checked ? "跳过配置文件中\n所记录的道具" : "导出配置文件中\n所记录的道具";
			FrmAnchorTips.ShowTips(Switch_Mode, Msg, AnchorTipsLocation.BOTTOM, Color.MediumOrchid, Color.FloralWhite, null, 12, 3500, false);
		}

		private void Switch_Mode_CheckedChanged(object sender, EventArgs e)
		{
			if (IsInitialization) return;

			Ini.WriteValue("Match_ICON", "Mode", Switch_Mode.Checked);
			FrmAnchorTips.CloseLastTip();
			Switch_Mode_MouseEnter(null, null);
		}

		private void Match_ICON_Enter(object sender, EventArgs e)
		{
			IsInitialization = false;
		}

		private void metroButton1_MouseEnter(object sender, EventArgs e)
		{
			FrmAnchorTips.ShowTips(metroButton1, "按照已生成的图标生成配置列表，便于版本更新\n\n注意：如果修改了输出文件夹的名字（即\"生成\"文件夹）\n\n输出栏 直接选择新文件夹，点击按钮即可", AnchorTipsLocation.BOTTOM, Color.MediumOrchid, Color.FloralWhite, null, 12, 3500, false);
		}

		private void metroButton1_MouseLeave(object sender, EventArgs e)
		{
			FrmAnchorTips.CloseLastTip();
		}


		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			if (IsInitialization) return;

			Xylia.Configure.Ini.WriteValue("Match_ICON", "HasBG", checkBox1.Checked);

			FrmAnchorTips.CloseLastTip();
			Switch_HasBG_MouseEnter(null, null);
		}

		private void checkBox2_CheckedChanged(object sender, EventArgs e)
		{
			Xylia.Configure.Ini.WriteValue("Match_ICON", "WriteLog", checkBox2.Checked);
		}
		#endregion




		#region 输出图标
		private void MetroButton2_Click(object sender, EventArgs e)
		{
			string ChvPath = metroTextBox1.Text;

			try
			{
				#region 初始化
				if (!ChvPath.IsNull() && !File.Exists(ChvPath)) throw new ArgumentException("Chv文件路径错误或不存在，请重新确认！");
				if (!this.Switch_Mode.Checked && !File.Exists(metroTextBox1.Text)) throw new ArgumentException("选择白名单模式时，必须选择配置文件!");
				#endregion


				#region 执行	 
				var IconTextureMatch = new IconTextureMatch()
				{
					FormatSelect = this.FormatSelect.TextValue,
					CheckFormat = true,

					//起始执行
					Start = (r, t) =>
					{
						metroButton2.Text = "终止";
						this.FormatSelect.Enabled = this.checkBox1.Enabled = this.checkBox2.Enabled = this.Switch_Mode.Enabled = this.pictureBox1.Enabled = false;
					},

					//结束执行
					Finish = (r, t) =>
					{
						//委托要求关闭线程
						this.Invoke((Action)(() => Thread_ItemIcon = null));

						this.FormatSelect.Enabled = this.checkBox1.Enabled = this.checkBox2.Enabled = this.Switch_Mode.Enabled = this.pictureBox1.Enabled = true;
						metroButton2.Text = "输出物品图标";
					},
				};


				IconTextureMatch.StartMatch(new Util.Paks.Textures.ItemIcon(act => Footer.Text = act, Path_GameFolder.Text)
				{
					// UE4 临时支持
					//ResourceFolder = ResourceFolder,

					OutputDirectory = this.Path_ResultPath.Text + @"\物品",
					ChvPath = metroTextBox1.Text,
					UseBackground = this.checkBox1.Checked,
					isWhiteList = !Switch_Mode.Checked,
					ShowLog_CreateInfo = this.checkBox2.Checked,

				}, ref Thread_ItemIcon,
				act => this.Invoke(new Action(() => Footer.Text = act)));
				#endregion
			}
			catch (ArgumentException ee)
			{
				Xylia.Tip.Message(ee.Message);
				return;
			}
			catch (Exception ee)
			{
				Xylia.Tip.Message(ee.Message);
				return;
			}
		}



		private void metroButton9_Click(object sender, EventArgs e)
		{
			var IconTextureMatch = new IconTextureMatch()
			{
				FormatSelect = null,
				CheckFormat = false,

				Start = (r, t) =>
				{
					metroButton9.Text = "终止";
				},

				Finish = (r, t) =>
				{
					metroButton9.Text = "输出商品图标";
				},
			};


			IconTextureMatch.StartMatch(new Util.Paks.Textures.GoodIcon(act => Footer.Text = act, Path_GameFolder.Text)
			{
				OutputDirectory = this.Path_ResultPath.Text + @"\商品",

			}, ref Thread_GoodIcon,

			act => this.Invoke(new Action(() => Footer.Text = act)));
		}
		#endregion

		private void metroLabel1_Click(object sender, EventArgs e)
		{

		}
	}
}