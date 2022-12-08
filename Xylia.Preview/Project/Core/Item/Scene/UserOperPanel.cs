using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

using HZH_Controls.Controls;

using Xylia.Preview.Data.Record;
using Xylia.Preview.Project.Core.ItemGrowth.Scene;
using Xylia.Preview.Properties.AnalyseSection;


namespace Xylia.Preview.Project.Core.Item.Scene
{
	public partial class UserOperPanel : Form
	{
		#region 字段
		public ItemFrm MyParentForm;

		/// <summary>
		/// 显示更多信息
		/// </summary>
		public bool MoreInformation = true;

		public int BtnCount = 0;
		#endregion

		#region 构造
		public UserOperPanel(ItemFrm ParentForm = null)
		{
			InitializeComponent();

			this.MyParentForm = ParentForm;
		}
		#endregion


		#region 方法
		private void UserOperScene_Load(object sender, EventArgs e)
		{
			this.Width = 50;
		}

		private void UserOperPanel_VisibleChanged(object sender, EventArgs e)
		{
			this.RefreshLoc();
		}

		public override void Refresh()
		{
			base.Refresh();

			#region 创建操作按钮
			var OperBtns = new List<Control>();

			if (this.MoreInformation) OperBtns.Add(this.pictureBox2);
			if (true || this.HasItemTransform) OperBtns.Add(this.pictureBox1);

			BtnCount = OperBtns.Count;
			#endregion

			#region 处理控件
			if (!OperBtns.Any()) this.Visible = false;
			else
			{
				#region 设置位置
				int LocY = 7;
				foreach (Control OperBtn in OperBtns)
				{
					OperBtn.Visible = true;
					OperBtn.Location = new Point(8, LocY);

					LocY = OperBtn.Bottom + 8;
				}

				this.Height = LocY - (8 - 7);
				#endregion
			}
			#endregion
		}

		/// <summary>
		/// 刷新位置
		/// </summary>
		public void RefreshLoc()
		{
			if (this.Visible)
			{
				var ScreenPoint = this.MyParentForm.PointToScreen(new Point(0, 0));

				//必须等开始加载了才能进行定位
				this.Left = ScreenPoint.X - this.Width;
				this.Top = ScreenPoint.Y;
			}
		}
		#endregion


		#region 无效内容
		//this.MouseDown += new MouseEventHandler(this.Form1_MouseDown);
		//this.MouseLeave += new EventHandler(this.ImageShow_MouseLeave);
		//this.MouseMove += new MouseEventHandler(this.Form1_MouseMove);

		#region 无边框移动窗体
		const int Band = 5;
		const int MinWidth = 10;
		const int MinHeight = 10;
		private EnumMousePointPosition m_MousePointPosition;
		private Point p, p1;

		private void Form1_MouseDown(object sender, MouseEventArgs e)
		{
			p.X = e.X;
			p.Y = e.Y;
			p1.X = e.X;
			p1.Y = e.Y;
		}

		private void Form1_MouseMove(object sender, MouseEventArgs e)
		{
			Control lCtrl = this;

			if (e.Button == MouseButtons.Left)
			{
				switch (m_MousePointPosition)
				{
					case EnumMousePointPosition.MouseDrag:
						lCtrl.Left = lCtrl.Left + e.X - p.X;
						lCtrl.Top = lCtrl.Top + e.Y - p.Y;
						break;
					case EnumMousePointPosition.MouseSizeBottom:
						lCtrl.Height = lCtrl.Height + e.Y - p1.Y;
						p1.X = e.X;
						p1.Y = e.Y; //'记录光标拖动的当前点  
						break;
					case EnumMousePointPosition.MouseSizeBottomRight:
						lCtrl.Width = lCtrl.Width + e.X - p1.X;
						lCtrl.Height = lCtrl.Height + e.Y - p1.Y;
						p1.X = e.X;
						p1.Y = e.Y; //'记录光标拖动的当前点  
						break;
					case EnumMousePointPosition.MouseSizeRight:
						lCtrl.Width = lCtrl.Width + e.X - p1.X;
						lCtrl.Height = lCtrl.Height + e.Y - p1.Y;
						p1.X = e.X;
						p1.Y = e.Y; //'记录光标拖动的当前点  
						break;
					case EnumMousePointPosition.MouseSizeTop:
						lCtrl.Top += (e.Y - p.Y);
						lCtrl.Height -= (e.Y - p.Y);
						break;
					case EnumMousePointPosition.MouseSizeLeft:
						lCtrl.Left = lCtrl.Left + e.X - p.X;
						lCtrl.Width -= (e.X - p.X);
						break;
					case EnumMousePointPosition.MouseSizeBottomLeft:
						lCtrl.Left = lCtrl.Left + e.X - p.X;
						lCtrl.Width -= (e.X - p.X);
						lCtrl.Height = lCtrl.Height + e.Y - p1.Y;
						p1.X = e.X;
						p1.Y = e.Y; //'记录光标拖动的当前点  
						break;
					case EnumMousePointPosition.MouseSizeTopRight:
						lCtrl.Top += (e.Y - p.Y);
						lCtrl.Width += (e.X - p1.X);
						lCtrl.Height -= (e.Y - p.Y);
						p1.X = e.X;
						p1.Y = e.Y; //'记录光标拖动的当前点  
						break;
					case EnumMousePointPosition.MouseSizeTopLeft:
						lCtrl.Left = lCtrl.Left + e.X - p.X;
						lCtrl.Top += (e.Y - p.Y);
						lCtrl.Width -= (e.X - p.X);
						lCtrl.Height -= (e.Y - p.Y);
						break;
					default:
						break;
				}


				if (lCtrl.Width < MinWidth) lCtrl.Width = MinWidth;
				if (lCtrl.Height < MinHeight) lCtrl.Height = MinHeight;
			}
			else
			{
				m_MousePointPosition = MousePointPosition(lCtrl.Size, e);  //'判断光标的位置状态  
				switch (m_MousePointPosition)  //'改变光标  
				{
					case EnumMousePointPosition.MouseSizeNone:
						this.Cursor = Cursors.Arrow;    //'箭头  
						break;
					case EnumMousePointPosition.MouseDrag:
						this.Cursor = Cursors.SizeAll;   //'四方向  
						break;
					case EnumMousePointPosition.MouseSizeBottom:
						this.Cursor = Cursors.SizeNS;    //'南北  
						break;
					case EnumMousePointPosition.MouseSizeTop:
						this.Cursor = Cursors.SizeNS;    //'南北  
						break;
					case EnumMousePointPosition.MouseSizeLeft:
						this.Cursor = Cursors.SizeWE;    //'东西  
						break;
					case EnumMousePointPosition.MouseSizeRight:
						this.Cursor = Cursors.SizeWE;    //'东西  
						break;
					case EnumMousePointPosition.MouseSizeBottomLeft:
						this.Cursor = Cursors.SizeNESW;   //'东北到南西  
						break;
					case EnumMousePointPosition.MouseSizeBottomRight:
						this.Cursor = Cursors.SizeNWSE;   //'东南到西北  
						break;
					case EnumMousePointPosition.MouseSizeTopLeft:
						this.Cursor = Cursors.SizeNWSE;   //'东南到西北  
						break;
					case EnumMousePointPosition.MouseSizeTopRight:
						this.Cursor = Cursors.SizeNESW;   //'东北到南西  
						break;
					default:
						break;
				}
			}
		}

		private void ImageShow_MouseLeave(object sender, EventArgs e)
		{
			m_MousePointPosition = EnumMousePointPosition.MouseSizeNone;
			this.Cursor = Cursors.Arrow;
		}

		private enum EnumMousePointPosition
		{
			MouseSizeNone = 0, //'无  
			MouseSizeRight = 1, //'拉伸右边框  
			MouseSizeLeft = 2, //'拉伸左边框  
			MouseSizeBottom = 3, //'拉伸下边框  
			MouseSizeTop = 4, //'拉伸上边框  
			MouseSizeTopLeft = 5, //'拉伸左上角  
			MouseSizeTopRight = 6, //'拉伸右上角  
			MouseSizeBottomLeft = 7, //'拉伸左下角  
			MouseSizeBottomRight = 8, //'拉伸右下角  
			MouseDrag = 9  // '鼠标拖动  
		}


		private EnumMousePointPosition MousePointPosition(Size size, MouseEventArgs e)
		{
			if ((e.X >= -1 * Band) | (e.X <= size.Width) | (e.Y >= -1 * Band) | (e.Y <= size.Height))
			{
				if (e.X < Band)
				{
					if (e.Y < Band) return EnumMousePointPosition.MouseSizeTopLeft;
					else
					{
						if (e.Y > -1 * Band + size.Height) return EnumMousePointPosition.MouseSizeBottomLeft;
						else return EnumMousePointPosition.MouseSizeLeft;
					}
				}
				else
				{
					if (e.X > -1 * Band + size.Width)
					{
						if (e.Y < Band) return EnumMousePointPosition.MouseSizeTopRight;
						else
						{
							if (e.Y > -1 * Band + size.Height) return EnumMousePointPosition.MouseSizeBottomRight;
							else return EnumMousePointPosition.MouseSizeRight;
						}
					}
					else
					{
						if (e.Y < Band) return EnumMousePointPosition.MouseSizeTop;
						else
						{
							if (e.Y > -1 * Band + size.Height) return EnumMousePointPosition.MouseSizeBottom;
							else return EnumMousePointPosition.MouseDrag;
						}
					}
				}
			}
			else return EnumMousePointPosition.MouseSizeNone;
		}
		#endregion
		#endregion




		#region 查看字段
		private void pictureBox2_Click(object sender, EventArgs e)
		{
			var thread = new Thread(act =>
			{
				var Preview = new DataGridScene(MyParentForm?.ItemInfo.Attributes.Attributes, ParamTable);
				if (Preview != null)
				{
					Preview.Text = $"查看字段 { MyParentForm?.ItemInfo?.NameText() }";
					Preview.ShowDialog();
				}
			});

			thread.SetApartmentState(ApartmentState.STA);
			thread.Start();
		}


		private static ParamTable m_ParamTable;

		public static ParamTable ParamTable
		{
			get
			{
				if (m_ParamTable is null)
				{
					#region 获取参数对应关系
					m_ParamTable = new ParamTable();

					var XmlDoc = new XmlDocument();

					var res = DataRes.ItemData_v39;
					if (res is null) return null;

					XmlDoc.LoadXml(res);
					foreach (XmlNode test in XmlDoc.SelectNodes("//list//record[@alias!=''][@name!='']"))
					{
						string Alias = test.Attributes["alias"]?.Value;
						string Name = test.Attributes["name"]?.Value;

						if (!m_ParamTable.ParamRelative.ContainsKey(Alias))
							m_ParamTable.ParamRelative.Add(Alias, Name);
					}
					#endregion
				}

				return m_ParamTable;
			}
		}
		#endregion

		#region 查看提炼
		/// <summary>
		/// 拥有物品进化信息
		/// </summary>
		public bool HasItemTransform => this.ItemTransformRecipes != null && this.ItemTransformRecipes.Any();


		public IEnumerable<ItemTransformRecipe> ItemTransformRecipes { get; set; }

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			var thread = new Thread(act =>
			{
				var Preview = new ItemGrowthScene();
				Preview.ShowItemGrowth2(MyParentForm?.ItemInfo, ItemTransformRecipes);

				if (Preview != null) Preview.ShowDialog();
			});

			thread.SetApartmentState(ApartmentState.STA);
			thread.Start();
		}
		#endregion
	}
}
