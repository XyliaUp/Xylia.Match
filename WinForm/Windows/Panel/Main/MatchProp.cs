using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

using HZH_Controls.Forms;

using Xylia.bns.Modules.DataFormat.Analyse;
using Xylia.bns.Modules.DataFormat.Analyse.DeSerialize;
using Xylia.bns.Read.Util;
using Xylia.Configure;
using Xylia.CustomException.User;
using Xylia.Extension;
using Xylia.Match.Util.ItemList;
using Xylia.Preview.Common.Extension;
using Xylia.Preview.Data.Record;
using Xylia.Preview.Project.Core.Map.Scene;
using Xylia.Preview.Project.Core.Skill;
using Xylia.Preview.Project.Core.Store.Store2;
using Xylia.Preview.Properties;
using Xylia.Preview.Properties.AnalyseSection;

using static Xylia.Tip;

using Output = Xylia.Preview.Third.Content;


namespace Xylia.Match.Windows.Panel
{
	public partial class MatchProp : UserControl
	{
		#region 构造
		readonly bool IsInitialization = true;

		public MatchProp()
		{
			InitializeComponent();
			this.TabControl.SelectedIndex = 0;


			this.Switch_Mode.Checked = CommonPath.DataLoadMode;
			this.GRoot_Path.Text = MySet.Core.Folder_Game_Bns;
			this.ItemPreview_Search.InputText = Ini.ReadValue("Preview", "item#searchrule");

			//Logger.Write($"启用物品数据模块");
			IsInitialization = false;
		}
		#endregion


		#region 物品预览功能
		private static string DataFolder => MySet.Core.Folder_Output + @"\data\files";


		/// <summary>
		/// 指示正在分析过程中
		/// </summary>
		bool AnalyseIsProcessing { get; set; }

		/// <summary>
		/// 公共信息路径
		/// </summary>
		static string PublicInfoPath => MySet.Core.Folder_Output + @"\data\info.conf";


		/// <summary>
		/// 工作信息路径
		/// </summary>
		string WorkInfoPath => this.CurDataFolder is null ? PublicInfoPath : this.CurDataFolder.FullName + @"\update.conf";


		private void ucBtnExt3_BtnClick(object sender, EventArgs e)
		{
			if (AnalyseIsProcessing) return;

			try
			{
				DebugSwitch.CreatAliasGroup = DebugSwitch.DataWrite = false;


				using var getDataPath = new Xylia.bns.Read.GetDataPath(MySet.Core.Folder_Game_Bns);
				AnalyseIsProcessing = true;

				#region 获取非汉化类型的配置文件
				var resourceSet = DataRes.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
				if (resourceSet is null) throw new Exception("当前区域下的配置文件获取失败");

				var ConfigRes = new List<ConfigFileInfo>();
				foreach (DictionaryEntry entry in resourceSet)
				{
					string Name = entry.Key.ToString();

					//不获取文本数据
					if (Name.MyEquals(nameof(DataRes.TextData))) continue;

					var Resource = entry.Value as string;
					ConfigRes.Add(new ConfigFileInfo(Name, Resource));
				}
				#endregion


				//提示已经开始
				SendMessage("数据分析所需时间一般为3~10分钟，请耐心等待", false, 8000);

				//如需增加输出数据，请修改DataRes下的配置信息
				Analyse(getDataPath.TargetXml, getDataPath.TargetLocal, 0, ConfigRes.ToArray());
			}
			catch (ExitException)
			{
				FrmTips.ShowTipsWarning("操作已取消");
			}
			catch (Exception ee)
			{
				//异常提醒
				SendMessage(ee, true);

				Tip.Message("分析时异常。\n\n" + ee, "发生系统错误");
			}
		}

		private void ucBtnExt19_BtnClick(object sender, EventArgs e)
		{
			//反序列化文本数据
			using var getDataPath = new Xylia.bns.Read.GetDataPath(MySet.Core.Folder_Game_Bns);
			Analyse(getDataPath.TargetXml, getDataPath.TargetLocal, 1, DataRes.TextData);
		}



		private void Analyse(string DataPath, string LocalDataPath, byte Type, params ConfigFileInfo[] ConfigFile) => Analyse(DataPath, LocalDataPath, Type, LoadConfig.Load(null, ConfigFile));

		/// <summary>
		/// 分析数据入口
		/// </summary>
		/// <param name="XmlContents"></param>
		/// <param name="DataPath"></param>
		/// <param name="Type"></param>
		/// <param name="LocalDataPath">汉化文件路径（可以设置为Null）</param>
		private void Analyse(string DataPath, string LocalDataPath, byte Type, params string[] XmlContents) => Analyse(DataPath, LocalDataPath, Type, LoadConfig.LoadByXml(null, XmlContents));

		private void Analyse(string DataPath, string LocalDataPath, byte Type, List<TableInfo> Tables)
		{
			new Thread((ThreadStart)delegate
			{
				try
				{
					#region 初始化
					//执行反序列化
					var ds = new DeSerializer()
					{
						OutAsXml = true,
						OutFolderPath = this.m_CurDataFolder.FullName,
					};

					ds.Execute(DataPath, LocalDataPath, Tables, new());
					#endregion

					//执行完成事件
					Invoke(new Action(() =>
					{
						if (Type == 0)
						{
							SendMessage("数据文件的分析已完成，现在开始可以预览");
							AnalyseIsProcessing = false;

							Ini.WriteValue("info", "data", DateTime.Now, this.WorkInfoPath);
							Ini.WriteValue("update_data", null, DateTime.Now, this.WorkInfoPath);
						}
						else if (Type == 1)
						{
							SendMessage("汉化文件的分析已完成，请等待数据文件分析完成");

							Ini.WriteValue("info", "local", DateTime.Now, this.WorkInfoPath);
							Ini.WriteValue("update_local", null, DateTime.Now, this.WorkInfoPath);
						}


						this.RefreshInfo();
					}));
				}
				catch (Exception ee)
				{
					AnalyseIsProcessing = false;

					//抛出错误
					if (ee is not ThreadAbortException) throw;
				}

				GC.Collect();

			}).Start();
		}
		#endregion

		#region Refresh
		readonly FileSystemWatcher watcher = new();

		/// <summary>
		/// 文件监听
		/// </summary>
		private void FileListen()
		{
			string WatchPath = WorkInfoPath;

			if (Directory.Exists(WatchPath))
			{
				//设置监听路径
				watcher.Path = WatchPath;

				//只监听这一个文件，当礼品目录修改完毕后对此文件进行修改，由此触发监听事件 
				watcher.Filter = "*.xml";

				//启用监听，如果不设置则不会触发事件
				watcher.EnableRaisingEvents = true;

				//设置监听触发事件
				watcher.Changed += new FileSystemEventHandler(watcher_Changed);
			}

			//初始刷新
			this.RefreshInfo();
		}

		private void watcher_Changed(object sender, FileSystemEventArgs e) => this.RefreshInfo();

		/// <summary>
		/// 刷新显示信息
		/// </summary>
		void RefreshInfo()
		{
			if (Switch_Mode.Checked)
			{

			}

			string Version_Data = Ini.ReadValue("info", "data", this.WorkInfoPath);
			string Version_Local = Ini.ReadValue("info", "local", this.WorkInfoPath);

			this?.Invoke(() => StateInfo.Text = $"汉化数据更新于 {Version_Local}\n资源数据更新于 {Version_Data}");
		}
		#endregion

		#region 工作目录变更
		private DirectoryInfo m_CurDataFolder = null;

		private string CurDataFolderShow => this.CurDataFolder?.FullName?.Replace(DataFolder, @"..\files");

		private DirectoryInfo CurDataFolder
		{
			get => this.m_CurDataFolder;
			set
			{
				this.m_CurDataFolder = value;
				this.label4.Text = "工作目录：" + CurDataFolderShow;

				//变更监听路径
				this.FileListen();

				CommonPath.WorkingDirectory = value.FullName;
				MySet.Core.Folder_PreviewFiles = value.ToString();
			}
		}

		private void ucBtnExt7_BtnClick(object sender, EventArgs e)
		{
			var FolderBrowser = new FolderBrowserDialog
			{
				SelectedPath = this.CurDataFolder?.FullName ?? MySet.Core.Folder_Output + @"\data\files"
			};

			if (FolderBrowser.ShowDialog() == DialogResult.OK)
			{
				this.CurDataFolder = new DirectoryInfo(FolderBrowser.SelectedPath);

				this.RefreshInfo();
				ClearCache();
			}
		}


		private void label4_DoubleClick(object sender, EventArgs e)
		{
			Process.Start("explorer", this.CurDataFolder?.FullName ?? MySet.Core.Folder_Output + @"\data\files");
		}

		/// <summary>
		/// 清理缓存信息
		/// </summary>
		public static void ClearCache()
		{
			FileCache.Data.ClearAll();

			MySet.ClearMemory();
		}
		#endregion




		#region 控件方法
		private void ToEnd(bool UseError = false)
		{
			Timer.Stop();

			Step1.StepIndex = 4;

			//if (UseError) richOut.Output(Xylia.Match.Windows.Forms.Controls.lib.RichOutLib.Combine("由于用户操作，本次执行未完成。\n\n", Color.Orange, 13));
			//  Program.Taskbar.SetProgressState(TaskbarProgressBarState.Paused, this.Handle);

			Btn_StartMatch.Enabled = Online_Searcher.Enabled = ucBtnFillet1.Enabled = File_Searcher.Enabled = GRoot_Path.Enabled = Chv_Path.Enabled = Chk_OnlyNew.Enabled = true;

			GC.Collect();
			//MySet.ClearMemory();
		}


		private void MatchProp_Load(object sender, EventArgs e)
		{
			if (!MySet.Core.Folder_PreviewFiles.IsNull())
			{
				if (Directory.Exists(MySet.Core.Folder_PreviewFiles))
					this.CurDataFolder = new DirectoryInfo(MySet.Core.Folder_PreviewFiles);
			}

			//** 设置工作路径
			if (!CommonPath.OutputFolder.IsNull())
			{
				if (this.CurDataFolder is null) this.CurDataFolder = new DirectoryInfo(CommonPath.WorkingDirectory);
			}

			//ResourceManager rm = new ResourceManager("Images", Assembly.GetExecutingAssembly());
		}

		private void GRoot_Path_TextChanged(object sender, EventArgs e)
		{
			if (!GRoot_Path.Text.IsNull())
			{
				MySet.Core.Folder_Game_Bns = GRoot_Path.Text;
			}

			lbl_Region.Text = "地区：" + DataPathes.GetRegion(MySet.Core.Folder_Game_Bns);
		}

		private void ucBtnFillet1_BtnClick(object sender, EventArgs e)
		{
			Forms.PublicSet Set = new(Info => { GRoot_Path.Text = Info; });

			if (Set.ShowDialog() == DialogResult.OK)
				this.GRoot_Path.Text = MySet.Core.Folder_Game_Bns;
		}

		private void Online_Searcher_BtnClick(object sender, EventArgs e)
		{
			OnlineFileSelect Select = new();
			Select.ShowDialog();

			if (!string.IsNullOrEmpty(Select.SelectedName)) Ini.WriteValue("Match", "Chv_Name", Chv_Path.Text = Select.SelectedName);
			if (!string.IsNullOrEmpty(Select.SelectedPath)) Ini.WriteValue("Match", "Chv_Path", Select.SelectedPath);
		}

		private void File_Searcher_BtnClick(object sender, EventArgs e)
		{
			Open.Filter = @"转储文件|*.chv|所有文件|*.*";
			Open.RestoreDirectory = false;

			if (Open.ShowDialog() == DialogResult.OK)
			{
				Chv_Path.Text = Path.GetFullPath(Open.FileName);
				Ini.WriteValue("Match", "Chv_Path", Chv_Path.Text);
			}
		}



		DateTime StartTime = DateTime.Now;

		private void Btn_StartMatch_BtnClick(object sender, EventArgs e)
		{
			#region 初始化
			if (!Directory.Exists(GRoot_Path.Text))
			{
				FrmTips.ShowTipsWarning("请先设置游戏目录");
				return;
			}
			else if (!Directory.Exists(MySet.Core.Folder_Output))
			{
				FrmTips.ShowTipsWarning("请先设置输出目录");
				ucBtnFillet1_BtnClick(null, null);
				return;
			}
			else if (Chk_OnlyNew.Checked && !Chv_Path.Text.Contains("云端资源") && !File.Exists(Chv_Path.Text))
			{
				FrmTips.ShowTipsWarning(".Chv配置文件未选择或不存在\n如无配置文件，请使用云资源或者取消下方\"仅更新\"勾选");
				return;
			}

			Btn_StartMatch.Enabled = File_Searcher.Enabled = Online_Searcher.Enabled = GRoot_Path.Enabled = Chv_Path.Enabled = Chk_OnlyNew.Enabled = false;
			// Program.Taskbar.SetProgressState(TaskbarProgressBarState.Indeterminate, this.Handle);
			#endregion

			#region 选择生成模式
			ModeSelect select2 = new();
			select2.ShowDialog();

			if (select2.Result == ModeSelect.State.None)
			{
				ToEnd(true);
				return;
			}
			#endregion


			this.StartTime = DateTime.Now;
			this.Timer.Start();

			var thread = new Thread(act =>
			{
				void SendMessage(string Msg, bool IsError = false) => this.Invoke(new(() => Tip.SendMessage(Msg, IsError)));

				#region 准备开始
				var match = new ItemMatch(Str => SendMessage(Str))
				{
					UseExcel = select2.Result == ModeSelect.State.Xlsx,
					Folder_Output = MySet.Core.Folder_Output,

					Chk_OnlyNew = this.Chk_OnlyNew.Checked,
				};
				this.Step1.StepIndex = 1;
				#endregion

				#region 加载资源
				//Switch_64Bit.Checked
				match.LoadCache(Ini.ReadValue("Match", "Chv_Path"));
				match.GetData();
				if (!match.ItemDatas.Any())
				{
					SendMessage("已激活仅新增道具功能，对比后无新增。");
					ToEnd();
					return;
				}
				Step1.StepIndex = 2;
				#endregion

				#region 执行输出
				Step1.StepIndex = 3;
				match.StartMatch(this.StartTime);
				match = null;
				#endregion

				this.ToEnd();
			});

			thread.SetApartmentState(ApartmentState.STA);
			thread.Start();
		}


		private void Chk_OnlyNew_CheckedChanged(object sender, EventArgs e) => Note_Chv.Visible = Chv_Path.Visible = /*Online_Searcher.Visible = */File_Searcher.Visible = Chk_OnlyNew.Checked;

		private void File_Searcher_MouseEnter(object sender, EventArgs e) => FrmAnchorTips.ShowTips(File_Searcher, "选择本地文件\n\n如无，请选择云端资源。", AnchorTipsLocation.BOTTOM, Color.MediumOrchid, Color.FloralWhite, null, 12, 3500, false);

		private void Online_Searcher_BtnMouseEnter(object sender, EventArgs e) => FrmAnchorTips.ShowTips(Online_Searcher, "选择云端资源\n\n云端资源可能不会及时更新。", AnchorTipsLocation.BOTTOM, Color.MediumOrchid, Color.FloralWhite, null, 12, 3500, false);

		/// <summary>
		/// 清理提示
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CloseTip(object sender, EventArgs e) => FrmAnchorTips.CloseLastTip();

		private void TabControl_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Enter:
				{
					var SelectdPage = this.TabControl.SelectedTab;

					if (SelectdPage == this.PreviewPage_Item) ItemPreview_Search_SearchClick(null, null);
					else if (SelectdPage == this.PreviewPage_Else) ucBtnExt11_BtnClick(null, null);
					else Debug.WriteLine("当前页面未定义回车事件：" + SelectdPage);
				}
				break;

				case Keys.Up:
				{
					if (int.TryParse(ItemPreview_Search.InputText, out int r)) ItemPreview_Search.InputText = (++r).ToString();
				}
				break;

				case Keys.Down:
				{
					if (int.TryParse(ItemPreview_Search.InputText, out int r)) ItemPreview_Search.InputText = (--r).ToString();
				}
				break;
			}
		}

		private void TimeInfo_TextChanged(object sender, EventArgs e)
		{
			if (TimeInfo.Text == "TimeInfo") TimeInfo.Visible = false;
			else if (!TimeInfo.Visible) TimeInfo.Visible = true;
		}

		/// <summary>
		/// 打开物品预览
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ItemPreview_Search_SearchClick(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(ItemPreview_Search.InputText))
			{
				Tip.Message("搜索条件不能为空");
				return;
			}

			//显示物品预览
			ItemPreview_Search.InputText.PreviewShow((m, s) => this.Invoke(() => SendMessage(m, s)));
		}


		private void ucBtnExt5_MouseEnter(object sender, EventArgs e)
		{
			FrmAnchorTips.ShowTips((Control)sender, "在已经读取了数据后，需要重新加载时使用", AnchorTipsLocation.BOTTOM, Color.MediumOrchid, Color.FloralWhite, null, 12, 3500, false);
		}

		private void ucBtnExt5_BtnClick(object sender, EventArgs e)
		{
			new Thread((ThreadStart)delegate
			{
				try
				{
					ClearCache();

					this.Invoke(new Action(() => SendMessage("刷新完成")));
				}
				catch (Exception ee)
				{
					this.Invoke(new Action(() => SendMessage(ee.Message, true, 8000)));

					Logger.Write(ee, MsgInfo.MsgLevel.错误);
					Console.WriteLine(ee);
				}

			}).Start();
		}



		private void ItemPreview_Search_TextChanged(object sender, EventArgs e) => Ini.WriteValue("Preview", "item#searchrule", this.ItemPreview_Search.InputText);

		private void Switch_Mode_CheckedChanged(object sender, EventArgs e)
		{
			this.Switch_Mode.Visible = this.StateInfo.Visible = this.label2.Visible = ucBtnExt3.Visible = 
				ucBtnExt19.Visible = this.label4.Visible = this.ucBtnExt7.Visible = !Switch_Mode.Checked;

			if (IsInitialization) return;


			Ini.WriteValue("Preview", "LoadMode", Switch_Mode.Checked);

			FrmAnchorTips.ShowTips(Switch_Mode, "* 刷新缓存后生效", AnchorTipsLocation.BOTTOM, Color.MediumOrchid, Color.FloralWhite, null, 12, 800, false);


			//this.RefreshInfo();
		}


		private void ucBtnExt1_BtnClick(object sender, EventArgs e) => Execute.MyShowDialog<Xylia.Preview.Project.RunForm.RandomStoreExhibitionScene>();
		private void ucBtnExt4_BtnClick(object sender, EventArgs e) => Execute.MyShowDialog<Xylia.Preview.Project.Core.Item.Helper>();
	
		private void ucBtnExt8_BtnClick(object sender, EventArgs e) => Execute.MyShowDialog<Xylia.Preview.Project.Core.Store.RandomStore.RandomStoreListScene>();
		private void ucBtnExt9_BtnClick(object sender, EventArgs e) => Execute.MyShowDialog<Xylia.Preview.Project.RunForm.ChallengeListFrm>();
		private void ucBtnExt11_BtnClick(object sender, EventArgs e) => Execute.MyShowDialog<Store2Scene>();
		private void ucBtnExt13_BtnClick(object sender, EventArgs e) => Execute.MyShowDialog<MapInfoScene>();
		private void ucBtnExt20_BtnClick(object sender, EventArgs e) => Execute.MyShowDialog<SkillTraitPreview>();


		private void ucBtnExt10_BtnClick(object sender, EventArgs e) => Execute.ThirdStart<Output.Expedition>();
		private void ucBtnExt12_BtnClick(object sender, EventArgs e) => Execute.ThirdStart<Output.ItemCloset_Main>();
		private void ucBtnExt14_BtnClick(object sender, EventArgs e) => Execute.ThirdStart<Output.ItemBuyPrice>();
		private void ucBtnExt16_BtnClick(object sender, EventArgs e) => Execute.ThirdStart<Output.ItemTransformRecipe>();
		private void ucBtnExt18_BtnClick(object sender, EventArgs e) => Execute.ThirdStart<Output.ItemCloset_Type>();
		#endregion
	}
}