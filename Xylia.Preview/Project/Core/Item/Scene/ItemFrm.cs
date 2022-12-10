using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

using Xylia.Configure;
using Xylia.Drawing;
using Xylia.Extension;
using Xylia.Framework.Enum;
using Xylia.Preview.Project.Controls;
using Xylia.Preview.Project.Core.Item.Util;

using static Xylia.Preview.Properties.Resources;

using ItemData = Xylia.Preview.Data.Record.Item;

namespace Xylia.Preview.Project.Core.Item.Scene
{
	public partial class ItemFrm : Form
	{
		#region 构造 
		public readonly ItemData ItemInfo;

		private bool Loading;

		public ItemFrm(ItemData ItemInfo)
		{
			#region 初始化
			Loading = true;

			InitializeComponent();
			CheckForIllegalCrossThreadCalls = false;

			this.ItemInfo = ItemInfo;

			//初始化可配置内容
			if (bool.TryParse(Ini.ReadValue("Preview", "item#option_UseUserOperPanel"), out bool f1))
				this.MenuItem_SwitchUserOperPanel.Checked = f1;

			if (bool.TryParse(Ini.ReadValue("Preview", "item#option_ShowCategory3"), out bool f2))
				this.lbl_Category.Visible = f2;

			Loading = false;
			#endregion


			#region 实例化操作按钮
			this.UserOperScene = new UserOperPanel(this);

			//当前窗体关闭
			this.FormClosing += new FormClosingEventHandler((s, o) => this.UserOperScene.Close());

			//当前窗体移动
			this.Move += new EventHandler((s, o) =>
			{
				var ScreenPoint = this.PointToScreen(new Point(0, 0));

				//必须等开始加载了才能进行定位
				UserOperScene.Left = ScreenPoint.X - UserOperScene.Width;
				UserOperScene.Top = ScreenPoint.Y;
			});

			//当前窗体获得焦点
			//不使用多线程，无法退出主窗体
			this.Activated += new EventHandler((s, o) => new Thread(t => this.UserOperScene?.BringToFront()).Start());
			#endregion

			#region 实例化额外控件
			this.AttributePreview = new AttributePreview()
			{
				Visible = false,
			};
			#endregion
		}

		private void Preview_Load(object sender, EventArgs e)
		{
			this.PreviewList.Clear();
			if (this.ItemInfo is null) return;

			try
			{
				this.LoadData();
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex);
				throw;
			}

			foreach (var c in this.Controls.OfType<ContentPanel>())
				c.Params = Params;

			this.Refresh();   //刷新必须放置在最后面，否则会异常
		}

		protected override void WndProc(ref Message m)
		{
			if ((wMsg)m.Msg == wMsg.WM_EXITSIZEMOVE)
			{
				if (this.UserOperScene != null) this.UserOperScene.TopMost = false;
			}

			base.WndProc(ref m);
		}
		#endregion

		#region 界面交互
		private void ItemFrm_Shown(object sender, EventArgs e)
		{
			//初始化显示状态
			this.UserOperScene.Refresh();
			if (this.UserOperScene.BtnCount == 0) this.MenuItem_SwitchUserOperPanel.Visible = false;
			else this.UserOperScene.Visible = this.MenuItem_SwitchUserOperPanel.Checked;


			#region 操作按钮
			if (this.UserOperScene != null && UserOperScene.Visible)
			{
				this.UserOperScene.Show();
			}
			#endregion
		}

		private void MainFrm_FormClosing(object sender, FormClosingEventArgs e)
		{
			this.Hide();
		}

		private void Preview_SizeChanged(object sender, EventArgs e)
		{
			if (this.WindowState != FormWindowState.Minimized)
			{
				base.Refresh();
			}
		}


		/// <summary>
		/// 目录保持右浮动
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void lbl_Category_TextChanged(object sender, EventArgs e)
		{
			lbl_Category.Location = new Point(this.Width - lbl_Category.Width - 90, lbl_Category.Location.Y);
		}

		private void ItemNameCell_DoubleClick(object sender, EventArgs e)
		{
			sender.SetClipboard();
		}

		/// <summary>
		/// 存储图标
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MenuItem_IconSaveAs_Click(object sender, EventArgs e)
		{
			this.ItemInfo?.Icon.SaveDialog(this.ItemName == null ?
				$"{this.ItemInfo.Alias}_{this.ItemInfo.ID}" :
				$"{this.ItemName}_{this.ItemInfo.ID}");
		}

		private void MenuItem_SaveAsImage_Click(object sender, EventArgs e)
		{
			//设置默认保存名称
			this.DrawMeToBitmap(true, new ControlSort()).SaveDialog(this.ItemInfo.Alias + "_ScreenShot");
		}

		/// <summary>
		/// 启用用户操作板
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MenuItem_SwitchUserOperPanel_CheckedChanged(object sender, EventArgs e)
		{
			if (this.UserOperScene != null)
			{
				this.UserOperScene.Visible = this.MenuItem_SwitchUserOperPanel.Checked;

				//保证焦点不会转移
				this.Activate();

				Ini.WriteValue("Preview", "item#option_UseUserOperPanel", this.MenuItem_SwitchUserOperPanel.Checked);
			}
		}

		private void lbl_Category_VisibleChanged(object sender, EventArgs e)
		{
			if (Loading) return;

			Ini.WriteValue("Preview", "item#option_ShowCategory3", this.lbl_Category.Visible);
		}


		private int m_nametype;

		/// <summary>
		/// 界面快捷键设置
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Preview_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Modifiers == Keys.Control)      // Ctrl + 
			{
				switch (e.KeyCode)
				{
					//保存图片快捷键
					case Keys.A: MenuItem_IconSaveAs_Click(null, null); break;

					//打开字体设置快捷键
					case Keys.D:
					{
						Tip.Message("功能未完成");
					}
					break;

					//快速切换物品名称与物品别名
					case Keys.F:
					{
						m_nametype++;

						switch (m_nametype)
						{
							case 1: this.ItemName = this.ItemInfo.Alias; break;
							case 2: this.ItemName = this.ItemInfo.ID.ToString(); break;
							default:
							{
								m_nametype = 0;
								this.ItemName = this.ItemInfo.NameText();
							}
							break;
						}
					}
					break;

					//是否显示用户操作板
					case Keys.G: this.MenuItem_SwitchUserOperPanel.Checked = !this.MenuItem_SwitchUserOperPanel.Checked; break;

					//保存物品信息快捷键
					case Keys.S:
					{
						Tip.Message("功能未完成");
					}
					break;

					//隐藏/显示奖励额外信息 快捷键
					case Keys.X:
					{
						foreach (var c in PreviewList.OfType<RewardPreview>())
						{
							c.ShowGroup = !c.ShowGroup;
							c.ShowJob = !c.ShowJob;

							c.ExecuteExtra();
						}
					}
					break;

					//是否显示目录
					case Keys.Z:
					{
						this.lbl_Category.Visible = !this.lbl_Category.Visible;
					}
					break;

				}
			}

			else
			{
				switch (e.KeyCode)
				{
					case Keys.Escape: MainFrm_FormClosing(null, null); break;
				}
			}
		}
		#endregion



		#region 数据处理
		public List<object> Params => new(ContentPanel.defaultParams)
		{
			ItemInfo,  //第二个参数是物品数据 
		};

		/// <summary>
		/// 刷新数据
		/// </summary>
		public override void Refresh()
		{
			base.Refresh();

			#region Attribute Section
			int Info_Top = 30;
			if (AttributePreview.Visible)
			{
				if (!this.Controls.Contains(AttributePreview)) this.Controls.Add(AttributePreview);

				this.AttributePreview.Location = new Point(this.lbl_SubInfo.Left, Info_Top);
				this.AttributePreview.Width = this.Width - this.AttributePreview.Left - 20;

				Info_Top = this.AttributePreview.Bottom;
			}
			#endregion

			#region 获取物品属性
			List<MyInfo> ValidMainInfo = new(this.MainInfo);
			List<MyInfo> ValidSubInfo = new(this.SubInfo);

			foreach (var o in this.ItemAbility)
			{
				if (o.Value == 0) continue;

				var key = o.Key;
				string value = key.ToString().MyEndsWith("percent") ? 
					(o.Value / 10).ToString("0.0") + "%" : 
					o.Value.ToString();


				//this.ItemInfo.MainAbility1
				ValidSubInfo.Add(new($"{key.GetDescription()} {value}"));
			}
			#endregion

			#region 处理信息节
			ValidMainInfo = ValidMainInfo.Where(Info => !Info.INVALID).ToList();
			if (!ValidMainInfo.Any()) this.lbl_MainInfo.Visible = false;
			else
			{
				this.lbl_MainInfo.Location = new Point(this.lbl_MainInfo.Left, Info_Top);
				this.lbl_MainInfo.Text = ValidMainInfo.Select(Info => Info.Text).Aggregate((sum, now) => sum + "<br/>" + now);
				this.lbl_MainInfo.Visible = true;
				this.lbl_MainInfo.Refresh();

				Info_Top = this.lbl_MainInfo.Bottom + 2;
			}

			ValidSubInfo = ValidSubInfo.Where(Info => !Info.INVALID).ToList();
			if (!ValidSubInfo.Any()) this.lbl_SubInfo.Visible = false;
			else
			{
				this.lbl_SubInfo.Visible = true;
				this.lbl_SubInfo.Location = new Point(this.lbl_SubInfo.Left, Info_Top);
				this.lbl_SubInfo.Text = ValidSubInfo.Select(Info => Info.Text).Aggregate((sum, now) => sum + "<br/>" + now);
				this.lbl_SubInfo.Refresh();

				Info_Top = this.lbl_SubInfo.Bottom;
			}
			#endregion



			this.lbl_Category.Location = new Point(this.Width - this.lbl_Category.Width - 15, this.lbl_Category.Location.Y);


			#region 加载控件列表
			//请注意，按照预定的控件纵向顺序执行
			int PosY = Math.Max(ItemIcon.Bottom, Info_Top);

			foreach (var c in PreviewList)
			{
				if (!c.Visible) continue;

				//如果控件组中不包含当前控件，则进行追加操作
				if (!this.Controls.Contains(c)) this.Controls.Add(c);

				//根据不同的类型分配不同的起始位置
				c.Location = new Point(c is ContentPanel ? 5 : 0, PosY);
				c.Refresh();

				PosY = c.Bottom + 2;
			}
			#endregion

			#region 底部信息
			if (lbl_JobLimit.Visible)
			{
				lbl_JobLimit.Location = new Point(lbl_JobLimit.Location.X, PosY);
				PosY = lbl_JobLimit.Bottom;
			}

			foreach (var c in BottomControl)
			{
				if (!this.Controls.Contains(c)) this.Controls.Add(c);

				c.Location = new Point(2, PosY);
				PosY = c.Bottom;
			}

			if (lbl_Trade_Account.Visible)
			{
				lbl_Trade_Account.Location = new Point(lbl_Trade_Account.Location.X, PosY);
				PosY = lbl_Trade_Account.Bottom;
			}


			//这里设置结束高度
			int EndPadding = 90;
			this.PricePreview.Location = new Point(this.Width - this.PricePreview.Width - 12, PosY + EndPadding - 68);

			//设置窗体高度
			this.Height = PosY + EndPadding;
			#endregion


			this.RefreshBackgroundImage();
		}

		/// <summary>
		/// 刷新背景图
		/// </summary>
		private void RefreshBackgroundImage()
		{
			#region 计算背景大小
			var bmp = new Bitmap(this.Width, this.Height);
			var g = Graphics.FromImage(bmp);

			if (this.ItemGrade >= 7)
			{
				int BgHeight = legend_cn.Height * this.Width / legend_cn.Width;
				g.DrawImage(legend_cn, new Rectangle(0, 0, bmp.Width, BgHeight));

				this.BackgroundImage = bmp;
			}
			#endregion
		}
		#endregion
	}
}