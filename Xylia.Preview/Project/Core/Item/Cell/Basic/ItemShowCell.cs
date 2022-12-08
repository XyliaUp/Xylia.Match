using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Xylia.Preview.Data.Record;

using ItemData = Xylia.Preview.Data.Record.Item;


namespace Xylia.Preview.Project.Core.Item.Cell.Basic
{
	[Designer(typeof(Designer.FixedHeightDesigner))]
	public partial class ItemShowCell : UserControl
	{
		#region 构造
		public ItemShowCell()
		{
			InitializeComponent();
			this.BackColor = Color.Transparent;

			this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.Selectable | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
			this.Refresh();
		}

		public ItemShowCell(ItemData ItemData, bool UseExtra = false) : this() => LoadData(ItemData, UseExtra);


		public void LoadData(ItemData ItemData, bool UseExtra = false) => this.LoadData(ItemData, UseExtra ? ItemData.IconExtra : ItemData.Icon);

		public void LoadData(ItemData ItemData, Bitmap Icon = null)
		{
			this.ItemIcon = Icon;

			this.ItemData = ItemData;
			this.ItemName = ItemData.NameText();
			this.ItemGrade = ItemData.ItemGrade;
		}
		#endregion



		#region 字段
		public ItemData ItemData
		{
			get => (ItemData)this.IconCell.ObjectRef;
			set => this.IconCell.ObjectRef = value;
		}



		/// <summary>
		/// 指示在图标不存在的情况下，仍然保留图标的空间
		/// </summary>
		private bool m_ReserveIconSpace { get; set; } = true;

		private int m_HeightDiff { get; set; } = 0;



		[Category("Data"), Description("物品名称")]
		public string ItemName
		{
			get => this.ItemNameCell.Text;
			set => this.ItemNameCell.Text = value;
		}

		[Category("Data"), Description("物品品质")]
		public byte ItemGrade
		{
			get => this.ItemNameCell.ItemGrade;
			set => this.ItemNameCell.ItemGrade = value;
		}

		[Category("Data"), Description("是否使用标签")]
		public Bitmap TagImage
		{
			get => this.ItemNameCell.TagImage;
			set => this.ItemNameCell.TagImage = value;
		}


		[Category("Data"), Description("物品图标")]
		public Bitmap ItemIcon
		{
			get => this.IconCell.ItemIcon;
			set
			{
				this.IconCell.ItemIcon = value;
				this.Refresh();
			}
		}

		[Category("Data"), Description("物品图标尺寸")]
		public new int Scale
		{
			get => this.IconCell.Scale;
			set
			{
				this.IconCell.Scale = value;
				Refresh();
			}
		}

		/// <summary>
		/// 文本高度偏移
		/// </summary>
		[Category("Data"), Description("文本高度差")]
		public int HeightDiff
		{
			get => this.m_HeightDiff;
			set
			{
				this.m_HeightDiff = value;
				this.Refresh();
			}
		}

		/// <summary>
		/// 在图标不存在的情况下，仍然保留图标的空间
		/// </summary>
		[Category("Data"), Description("在图标不存在的情况下，仍然保留图标的空间")]
		public bool ReserveIconSpace
		{
			get => m_ReserveIconSpace;
			set => m_ReserveIconSpace = value;
		}
		#endregion

		#region 方法
		/// <summary>
		/// 获得中心Y位置
		/// </summary>
		private int GetCenterLoY => (this.Scale - this.ItemNameCell.Height) / 2;

		public override void Refresh()
		{
			//获得名称的Y坐标
			int NameLoY = GetCenterLoY + HeightDiff;

			if (!ReserveIconSpace && this.ItemIcon is null)
			{
				this.IconCell.Visible = false;
				this.ItemNameCell.Location = new Point(0, NameLoY);
			}
			else
			{
				this.IconCell.Visible = true;
				this.ItemNameCell.Location = new Point(this.IconCell.Scale + 2, NameLoY);
			}


			this.AutoSize = false;
			this.Width = this.ItemNameCell.Location.X + this.ItemNameCell.Width;
			this.Height = Math.Max(this.IconCell.Scale - 1, this.ItemNameCell.Location.Y + this.ItemNameCell.Height);
		}


		/// <summary>
		/// 名称改变时重新设置宽度
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ItemName_NameChanged(object sender, EventArgs e)
		{
			this.Width = this.ItemNameCell.Location.X + this.ItemNameCell.Width;
		}

		private void ItemName_DoubleClick(object sender, EventArgs e)
		{
			this.ItemData.PreviewShow();
		}
		#endregion
	}
}
