using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

using Xylia.Extension;
using Xylia.Preview.Data.Record;
using Xylia.Preview.Project.Controls.Currency;
using Xylia.Preview.Project.Core.Item.Cell.Basic;
using Xylia.Preview.Resources;

namespace Xylia.Preview.Project.Core.Store.Cell
{
	/// <summary>
	/// 购买价格单元
	/// </summary>
	public partial class BuyPriceCell : Panel
	{
		#region 构造
		public BuyPriceCell()
		{
			InitializeComponent();
			this.AutoSize = false;
		}
		#endregion

		#region 字段
		/// <summary>
		/// 图片规格
		/// </summary>
		private new int Scale { get; set; } = 28;

		/// <summary>
		/// 母控件高度
		/// </summary>
		public int? ParentHeight = 55;

		/// <summary>
		/// 控件高度
		/// </summary>
		public int MyHeight = 0;


		/// <summary>
		/// 物品购买字段
		/// </summary>
		private ItemBuyPrice m_ItemBuyPrice = null;

		/// <summary>
		/// 设置物品购买价格
		/// </summary>
		public ItemBuyPrice ItemBuyPrice
		{
			get => this.m_ItemBuyPrice;
			set
			{
				this.m_ItemBuyPrice = value;

				//如果购买信息不为空则通知刷新
				if (value != null) this.CreateMyControl(value);
			}
		}
		#endregion


		#region 方法

		#region 创建兑换预览
		/// <summary>
		/// 创建兑换价格元素
		/// </summary>
		/// <param name="Type"></param>
		/// <param name="Count"></param>
		/// <param name="LoY"></param>
		private static Control CretePriceCell(CurrencyType Type, int Count, ref int LoY)
		{
			if (Count == 0) return null;

			var PriceCell = new Controls.PriceCell()
			{
				CurrencyCount = Count,
				CurrencyType = Type,
				AutoSize = false,
			};

			PriceCell.Location = new Point(0, LoY);
			LoY += PriceCell.Height;

			return PriceCell;
		}

		/// <summary>
		/// 创建兑换物品组元素
		/// </summary>
		/// <param name="LoX"></param>
		/// <param name="LoY"></param>
		private Control CreteItemBrandCell(ItemBuyPrice ItemBuyPrice, ref int LoX, int LoY)
		{
			//获取对应的 组ID
			var ItemBrand = FileCache.Data.ItemBrand[ItemBuyPrice.RequiredItembrand];
			if (ItemBrand is null) return null;

			//搜索对象
			var ItemBrandTooltip = FileCache.Data.ItemBrandTooltip.Find(info => info.BrandID == ItemBrand.ID && info.ItemConditionType == this.ItemBuyPrice.RequiredItembrandConditionType);
			if (ItemBrandTooltip is null) Trace.WriteLine($"[CreteItemBrandCell] { ItemBrand.ID } => { this.ItemBuyPrice.RequiredItembrandConditionType } 不存在");

			int ExtraScale = 10;
			var FrameIconCell = new ItemIconCell()
			{
				Scale = this.Scale + ExtraScale,
				FrameImage = Resource_Common.FrameImg1,

				Image = ItemBrandTooltip?.MainIcon(),
				ShowStackCount = false,
			};

			FrameIconCell.Location = new Point(LoX, LoY - ExtraScale / 2);

			//设置信息，告知用户ItemBrand名称
			FrameIconCell.SetToolTip(ItemBrandTooltip?.NameText());
			FrameIconCell.BringToFront();

			//设置X坐标
			LoX = (this.Scale + ExtraScale) + 4;

			return FrameIconCell;
		}

		/// <summary>
		/// 创建兑换物品预览
		/// </summary>
		/// <param name="ItemAlias"></param>
		/// <param name="Count"></param>
		/// <param name="LoX">X坐标</param>
		/// <param name="LoY">Y坐标</param>  
		private Control CreteItemCell(string ItemAlias, short Count, ref int LoX, int LoY)
		{
			var ItemData = ItemAlias.GetItemInfo();
			if (ItemData is null) return null;

			var ItemIconCell = new ItemIconCell()
			{
				Scale = this.Scale,
				Image = ItemData.IconExtra,

				StackCount = Count,
				ShowStackCount = true,
				ShowStackCountOnlyOne = true,

				Location = new Point(LoX, LoY),
				ObjectRef = ItemData,
			};

			//设置信息，告知用户物品名称
			ItemIconCell.SetToolTip(ItemData.NameText() + (Count == 1 ? null : $" -{ Count}"));
			ItemIconCell.BringToFront();

			//设置X坐标
			LoX += ItemIconCell.Scale + 4;
			return ItemIconCell;
		}
		#endregion


		/// <summary>
		/// 重绘控件
		/// </summary>
		public void CreateMyControl(ItemBuyPrice ItemBuyPrice)
		{
			#region 初始化
			if (ItemBuyPrice is null)
			{
				Debug.WriteLine("兑换价格为空");
				return;
			}

			int LoY = 0;
			var PriceCtls = new List<Control>();   //价格控件
			var ItemCtls = new List<Control>();    //物品控件
			#endregion


			#region 生成一般兑换货币部分
			PriceCtls.AddItem(CretePriceCell(CurrencyType.FactionScore, ItemBuyPrice.RequiredFactionScore, ref LoY));
			PriceCtls.AddItem(CretePriceCell(CurrencyType.DuelPoint, ItemBuyPrice.RequiredDuelPoint, ref LoY));
			PriceCtls.AddItem(CretePriceCell(CurrencyType.PartyBattlePoint, ItemBuyPrice.RequiredPartyBattlePoint, ref LoY));
			PriceCtls.AddItem(CretePriceCell(CurrencyType.Pearl, ItemBuyPrice.RequiredLifeContentsPoint, ref LoY));
			PriceCtls.AddItem(CretePriceCell(CurrencyType.FieldPlayPoint, ItemBuyPrice.RequiredFieldPlayPoint, ref LoY));
			PriceCtls.AddItem(CretePriceCell(CurrencyType.Money, ItemBuyPrice.Money, ref LoY));
			#endregion


			//生成坐标(X,Y)信息
			int LoX = 0;
			LoY += 5;

			//设置兑换物品组
			ItemCtls.AddItem(this.CreteItemBrandCell(ItemBuyPrice, ref LoX, LoY));

			//设置兑换物品
			ItemCtls.AddItem(this.CreteItemCell(ItemBuyPrice.RequiredItem1, ItemBuyPrice.RequiredItemCount1, ref LoX, LoY));
			ItemCtls.AddItem(this.CreteItemCell(ItemBuyPrice.RequiredItem2, ItemBuyPrice.RequiredItemCount2, ref LoX, LoY));
			ItemCtls.AddItem(this.CreteItemCell(ItemBuyPrice.RequiredItem3, ItemBuyPrice.RequiredItemCount3, ref LoX, LoY));
			ItemCtls.AddItem(this.CreteItemCell(ItemBuyPrice.RequiredItem4, ItemBuyPrice.RequiredItemCount4, ref LoX, LoY));

			//追加控件
			PriceCtls.ForEach(c => this.Controls.Add(c));
			ItemCtls.ForEach(c => this.Controls.Add(c));


			this.MyHeight = LoY + (ItemCtls.Count == 0 ? 0 : this.Scale);

			//判断高度位置
			if (this.ParentHeight != null && this.ParentHeight > this.MyHeight)
			{
				//在无货币价格设置时将物品显示在中间
				if (PriceCtls.Count == 0)
				{
					ItemCtls.ForEach(c => c.Location = new Point(c.Location.X, 0 + ((int)this.ParentHeight - c.Height) / 2));
				}
				//必须判断是否只有一个价格控件，不然会发生重叠
				else if (ItemCtls.Count == 0 && PriceCtls.Count == 1)
				{
					PriceCtls.ForEach(c => c.Location = new Point(c.Location.X, ((int)this.ParentHeight - c.Height) / 2));
				}
			}

			#region 重新计算信息位置
			//计算最大需要宽度
			int MaxWidth = 0, TempWidth = 0;
			PriceCtls.ForEach(c => MaxWidth = Math.Max(MaxWidth, c.Width));
			ItemCtls.ForEach(c => MaxWidth = Math.Max(MaxWidth, TempWidth += c.Width + 4));


			this.Width = MaxWidth += 2;

			PriceCtls.ForEach(c => c.Location = new Point(this.Width - c.Width, c.Location.Y));

			//计算出物品图标的起始点
			int StartLoX = this.Width;
			ItemCtls.ForEach(c => StartLoX -= c.Width + 4);
			ItemCtls.ForEach(c =>
			{
				c.Location = new Point(StartLoX + c.Location.X, c.Location.Y);
			});
			#endregion

			this.Refresh();
		}
		#endregion
	}
}