using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

using Xylia.Preview.Data.Record;
using Xylia.Preview.Project.Core.ItemGrowth.Page;

using ItemData = Xylia.Preview.Data.Record.Item;


namespace Xylia.Preview.Project.Core.ItemGrowth.Cell
{
	/// <summary>
	/// 成长目标物品
	/// </summary>
	public partial class ItemPreviewCell : UserControl
	{
		#region 构造
		public ItemPreviewCell()
		{
			InitializeComponent();

			this.BackColor = Color.Transparent;
			this.Refresh();

			this.ItemName.Click += new EventHandler((o, e) => this.OnClick(e));
			this.ItemIcon.Click += new EventHandler((o, e) => this.OnClick(e));
		}
		#endregion



		#region 字段
		private ItemData _ItemInfo;
		
		public ItemData ItemInfo
		{
			get => this._ItemInfo;
			set
			{
				_ItemInfo = value;
				if (value is null) return;

				this.Grade = value.ItemGrade;
				this.Text = value.NameText();
				this.Icon = value.IconExtra;

				this.ItemName.ItemAlias = this.ItemIcon.ItemAlias = value.Alias;
			}
		}


		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[Category("Apperance"), Description("名称")]
		public override string Text
		{
			get => this.ItemName.Text;
			set
			{
				this.ItemName.Text = value;
				this.Refresh();
			}
		}

		[Category("Apperance"), Description("等级")]
		public byte Grade { get => this.ItemName.ItemGrade; set => this.ItemName.ItemGrade = value; }

		[Category("Apperance"), Description("图标")]
		public Image Icon { get => this.ItemIcon.Image; set => this.ItemIcon.Image = value; }

		[Category("Apperance"), Description("框架图标")]
		public Bitmap FrameImage { get => this.ItemIcon.FrameImage; set => this.ItemIcon.FrameImage = value; }

		[Category("Apperance"), Description("显示框架图标")]
		public bool ShowFrameImage { get => this.ItemIcon.ShowFrameImage; set => this.ItemIcon.ShowFrameImage = value; }

		[Category("Apperance"), Description("")]
		public bool ShowStackCount { get => this.ItemIcon.ShowStackCount; set => this.ItemIcon.ShowStackCount = value; }
		#endregion



		#region 方法
		public override void Refresh()
		{
			this.ItemName.MaximumSize = new Size(this.Width, 99999999);
			this.ItemName.Location = new Point(this.ItemIcon.Left + (this.ItemIcon.Width - this.ItemName.Width) / 2, this.ItemName.Top);
		}
		#endregion
	}
}
