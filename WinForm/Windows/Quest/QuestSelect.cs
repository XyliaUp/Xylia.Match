using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

using Xylia.Extension;
using Xylia.Preview.Data.Helper;
using Xylia.Preview.Project.Core.Quest.Preview;
using Xylia.Preview.Resources;
using Xylia.Windows.Forms;

using QuestData = Xylia.bns.Modules.Quest.Entities.Quest;

namespace Xylia.Match.Windows
{
	public partial class QuestSelect : MetroFramework.Forms.MetroForm
	{
		#region 构造
		public QuestSelect()
		{
			InitializeComponent();

			//加载数据
			this.LoadData();
		}
		#endregion


		#region 控件方法
		private void ListBox1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			QuestData SelItem;
			if (listBox1.SelectedItem != null) SelItem = listBox1.SelectedItem as QuestData;
			else
			{
				Announcement.Show("请选择一个任务选项");
				return;
			}


			MySet.Core.Quest_Select = SelItem.id;

			var thread = new Thread(act => new QuestPreview(SelItem).ShowDialog());
			thread.SetApartmentState(ApartmentState.STA);
			thread.Start();
		}

		private void ListBox1_DrawItem(object sender, DrawItemEventArgs e)
		{
			#region 初始化
			//防止渲染时异常
			if (e.Index == -1 || e.Index >= listBox1.Items.Count) return;
			if (listBox1.Items[e.Index] is not QuestData CurInfo) return;


			Brush myBrush;
			if ((e.State & DrawItemState.Selected) == DrawItemState.Selected) myBrush = new SolidBrush(Color.DeepSkyBlue);
			else if (e.Index % 2 == 0) myBrush = new SolidBrush(Color.White);
			else myBrush = new SolidBrush(Color.White);

			e.Graphics.FillRectangle(myBrush, e.Bounds);

			//焦点框 
			e.DrawFocusRectangle();
			#endregion

			#region 绘制图标
			Graphics g = e.Graphics;
			Rectangle bounds = e.Bounds;
			Rectangle imageRect = new(bounds.X, bounds.Y, bounds.Height, bounds.Height);

			Image image = CurInfo.Icon;
			if (image != null) g.DrawImage(image, imageRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel);
			#endregion

			#region 绘制文本
			//如果颜色未赋值，则使用前景色
			Color StrColor = CurInfo.ForeColor;
			if (StrColor == Color.Empty) StrColor = this.ForeColor;

			//获取任务名称
			string SourceText = CurInfo.Name2.GetText();
			string QuestName = $"[{ CurInfo.id }] " + SourceText.CutText();
			var Font = new Font(e.Font.FontFamily, e.Font.Size, FontStyle.Bold);

			Rectangle textRect = new(imageRect.Right, bounds.Y, bounds.Width - imageRect.Right, bounds.Height);
			e.Graphics.DrawString(QuestName, Font, new SolidBrush(StrColor), textRect, new StringFormat
			{
				LineAlignment = StringAlignment.Center
			});
			#endregion


			#region 绘制额外附加图标
			if (SourceText is null) return;

			List<Image> ExtraImage = new();

			if (SourceText.Contains("\"00015590.Tag_Contents_Daily\"")) ExtraImage.Add(Resource_BNSR.Tag_024);

			if (SourceText.Contains("_Superior")) ExtraImage.Add(Resource_BNSR.Tag_138);
			if (SourceText.Contains("_Prime")) ExtraImage.Add(Resource_BNSR.Tag_138);
			if (SourceText.Contains("_Hero")) ExtraImage.Add(Resource_BNSR.Tag_139);

			if (SourceText.Contains("\"00015590.Tag_Dungeon_Two\"")) ExtraImage.Add(Resource_BNSR.Tag_164);
			if (SourceText.Contains("\"00015590.Tag_Dungeon_Six\"")) ExtraImage.Add(Resource_BNSR.Tag_165);
			if (SourceText.Contains("\"00015590.Tag_Dungeon_Four\"")) ExtraImage.Add(Resource_BNSR.Tag_166);
			//if (SourceText.Contains("EventMarker")) ExtraImage.Add(BnsCommon.EventMarker);

			if (ExtraImage.Any())
			{
				int StartX = textRect.Left + (int)QuestName.MeasureString(Font).Width;
				foreach (var eg in ExtraImage)
				{
					Rectangle rect = new(StartX += eg.Width, bounds.Y, eg.Width, eg.Height);
					g.DrawImage(eg, rect, 0, 0, eg.Width, eg.Height, GraphicsUnit.Pixel);
				}
			}

			ExtraImage.Clear();
			#endregion
		}

		private void QuestSelect_TextChanged(object sender, EventArgs e)
		{
			this.Refresh();
		}



		bool inprogress = false;

		public static string LastSearchRule { get; set; }

		private void textBoxEx1_TextChanged(object sender, EventArgs e)
		{
			if (inprogress) return;
			inprogress = true;


			LastSearchRule = textBoxEx1.Text;
			this.listBox1.Items.Clear();


			foreach (var info in FileCache.Data.Quest.Values.Where(info => info.Name2.GetText()?.Contains(textBoxEx1.Text) ?? false))
			{
				listBox1.Items.Add(info);
			}

			inprogress = false;
		}
		#endregion

		#region 处理方法
		/// <summary>
		/// 加载数据
		/// </summary>
		public void LoadData()
		{
			FileCache.Data.TextData.TryLoad();

			ReadQuestData.GetQuests();
			this.RefreshList();
		}

		/// <summary>
		/// 显示到控件 (包括退出后)
		/// </summary>
		public void RefreshList()
		{
			//向列表增加元素
			this.listBox1.Items.Clear();
			this.listBox1.Items.AddRange(FileCache.Data.Quest.Values.OrderBy(info => info.id).ToArray());

			this.textBoxEx1.Visible = true;
			this.textBoxEx1.Text = LastSearchRule;

			//恢复上次选择任务的位置
			if (MySet.Core.Quest_Select != null && FileCache.Data.Quest.ContainsKey(MySet.Core.Quest_Select.Value))
			{
				for (int idx = 0; idx < this.listBox1.Items.Count; idx++)
				{
					var tmp = this.listBox1.Items[idx] as QuestData;
					if (tmp.id == MySet.Core.Quest_Select.Value)
					{
						this.listBox1.SelectedIndex = idx;
						break;
					}
				}
			}
		}
		#endregion
	}
}