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
	public partial class ItemPreviewCell : UserControl
	{
		#region 构造
		public ItemPreviewCell()
		{
			InitializeComponent();

			this.BackColor = Color.Transparent;
			this.Refresh();

			this.itemNameCell1.Click += new EventHandler((o, e) => this.OnClick(e));
			this.feedItemIconCell1.Click += new EventHandler((o, e) => this.OnClick(e));
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

				this.itemNameCell1.ItemAlias = this.feedItemIconCell1.ItemAlias = value.Alias;
			}
		}


		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[Category("Apperance"), Description("名称")]
		public override string Text
		{
			get => this.itemNameCell1.Text;
			set
			{
				this.itemNameCell1.Text = value;
				this.Refresh();
			}
		}

		[Category("Apperance"), Description("等级")]
		public byte Grade { get => this.itemNameCell1.ItemGrade; set => this.itemNameCell1.ItemGrade = value; }

		[Category("Apperance"), Description("图标")]
		public Image Icon { get => this.feedItemIconCell1.Image; set => this.feedItemIconCell1.Image = value; }

		[Category("Apperance"), Description("框架图标")]
		public Bitmap FrameImage { get => this.feedItemIconCell1.FrameImage; set => this.feedItemIconCell1.FrameImage = value; }

		[Category("Apperance"), Description("显示框架图标")]
		public bool ShowFrameImage { get => this.feedItemIconCell1.ShowFrameImage; set => this.feedItemIconCell1.ShowFrameImage = value; }

		[Category("Apperance"), Description("")]
		public bool ShowStackCount { get => this.feedItemIconCell1.ShowStackCount; set => this.feedItemIconCell1.ShowStackCount = value; }
		#endregion


		#region 方法
		private void ItemPreviewCell_SizeChanged(object sender, EventArgs e)
		{

		}

		public static ItemGrowth2Page Test;


		private void ItemPreviewCell_Click(object sender, EventArgs e)
		{
			//由于创建目标物品时，会调用click方法。所以必须注意进行状态判断。
			if (Page.ItemGrowth2Page.LastKey == Keys.ShiftKey)
			{
				var thread = new Thread(act =>
				{
					var ItemInfo = feedItemIconCell1.ItemAlias.GetItemInfo();
					if (ItemInfo != null)
					{
						var Recipes = ItemTransformRecipe.QueryRecipe(ItemInfo);
						Test.Invoke(new Action(() => 
						{
							Test.MyWeapon = ItemInfo;
							Test.SetData(Recipes);
						}));
					}
				});

				thread.SetApartmentState(ApartmentState.STA);
				thread.Start();
			}
		}


		public override void Refresh()
		{
			this.itemNameCell1.MaximumSize = new Size(this.Width, 99999999);
			this.itemNameCell1.Location = new Point(this.feedItemIconCell1.Left + (this.feedItemIconCell1.Width - this.itemNameCell1.Width) / 2, this.itemNameCell1.Top);
		}
		#endregion
	}
}
