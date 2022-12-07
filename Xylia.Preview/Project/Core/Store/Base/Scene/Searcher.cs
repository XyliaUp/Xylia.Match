using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using MetroFramework.Controls;
using MetroFramework.Forms;

namespace Xylia.Preview.Project.Core.Store
{
	public partial class Searcher : MetroForm
	{
		public Searcher(List<FilterInfo> FilterInfo = null)
		{
			InitializeComponent();

			this.FilterInfo = FilterInfo;
		}

		#region 字段
		/// <summary>
		/// 筛选信息
		/// </summary>
		public List<FilterInfo> FilterInfo;
		#endregion

		#region 方法
		private void Searcher_Load(object sender, EventArgs e)
		{
			int LocX = 30, LocY = this.Btn_StartMatch.Bottom + 5;

			//判断是否存在预设的筛选分类
			if (this.FilterInfo?.Count != 0)
			{
				foreach (var Filter in this.FilterInfo)
				{
					var c = new MetroCheckBox
					{
						Text = Filter.Text,
						Checked = Filter.Checked,

						Location = new Point(LocX, LocY),
					};

					this.Controls.Add(c);

					bool FeedLine = this.Width < (LocX + 20);
					if (!FeedLine) LocX += c.Width;
					else
					{
						LocX = 30;
						LocY = c.Bottom + 2;
					}
				}
			}

			this.Height = LocY + 35;
		}

		private void Btn_StartMatch_BtnClick(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
		}

		private void Searcher_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				this.Btn_StartMatch_BtnClick(null, null);
			}
		}
		#endregion
	}



	/// <summary>
	/// 筛选集合
	/// </summary>
	public class FilterList
	{
		public readonly List<FilterInfo> FilterInfo = new();

		public bool Contains(FilterTag Tag)
		{
			return FilterInfo.Find(f => f.Tag == Tag) != null;
		}

		public void Add(FilterInfo item)
		{
			this.FilterInfo.Add(item);
		}
	}

	/// <summary>
	/// 筛选类型
	/// </summary>
	public class FilterInfo
	{
		#region 构造
		public FilterInfo()
		{

		}

		public FilterInfo(FilterTag Tag, string Text, bool Checked = true)
		{
			this.Tag = Tag;
			this.Text = Text;
			this.Checked = Checked;
		}
		#endregion


		/// <summary>
		/// 标签
		/// </summary>
		public FilterTag Tag;

		/// <summary>
		/// 文本
		/// </summary>
		public string Text;

		public bool Checked = true;
	}

	/// <summary>
	/// 筛选标签
	/// </summary>
	public enum FilterTag
	{
		Text,
		Item,
	}
}
