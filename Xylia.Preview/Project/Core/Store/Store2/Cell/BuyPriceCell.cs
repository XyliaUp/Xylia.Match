using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

using Xylia.bns.Modules.GameData.Enums;

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
		public BuyPriceCell() => InitializeComponent();
		#endregion

		#region 字段
		/// <summary>
		/// 图片规格
		/// </summary>
		private new int Scale { get; set; } = 28;
		#endregion


		#region 方法
		public void LoadData(ItemBuyPrice ItemBuyPrice)
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

			#region 生成兑换所需物品
			int LoX = 0;
			LoY += 5;

			ItemCtls.AddItem(this.CreteItemBrandCell(ItemBuyPrice.RequiredItembrand, ItemBuyPrice.RequiredItembrandConditionType, ref LoX, LoY));
			ItemCtls.AddItem(this.CreteItemCell(ItemBuyPrice.RequiredItem1, ItemBuyPrice.RequiredItemCount1, ref LoX, LoY));
			ItemCtls.AddItem(this.CreteItemCell(ItemBuyPrice.RequiredItem2, ItemBuyPrice.RequiredItemCount2, ref LoX, LoY));
			ItemCtls.AddItem(this.CreteItemCell(ItemBuyPrice.RequiredItem3, ItemBuyPrice.RequiredItemCount3, ref LoX, LoY));
			ItemCtls.AddItem(this.CreteItemCell(ItemBuyPrice.RequiredItem4, ItemBuyPrice.RequiredItemCount4, ref LoX, LoY));
			#endregion


			#region 计算位置
			int MaxWidth = 0;
			foreach (var o in PriceCtls)
			{
				MaxWidth = Math.Max(MaxWidth, o.Width);
				this.Controls.Add(o);
			}


			if (ItemCtls.Count == 0) this.Height = LoY;
			else
			{
				int TempWidth = 0;
				foreach (var o in ItemCtls)
				{
					MaxWidth = Math.Max(MaxWidth, TempWidth += o.Width + 4);

					this.Controls.Add(o);
				}

				this.Height = LoY + this.Scale + 5;
			}

			this.Width = MaxWidth += 2;
			#endregion



			#region 重新设定位置
			PriceCtls.ForEach(c => c.Location = new Point(this.Width - c.Width, c.Location.Y));

			//计算出物品图标的起始点
			int StartLoX = this.Width;
			ItemCtls.ForEach(c => StartLoX -= c.Width + 4);
			ItemCtls.ForEach(c => c.Location = new Point(StartLoX + c.Location.X, c.Location.Y));
			#endregion
		}


		/// <summary>
		/// 创建兑换价格元素
		/// </summary>
		/// <param name="Type"></param>
		/// <param name="CurrencyCount"></param>
		/// <param name="LoY"></param>
		private static Control CretePriceCell(CurrencyType Type, int CurrencyCount, ref int LoY)
		{
			if (CurrencyCount == 0) return null;

			var PriceCell = new Controls.PriceCell()
			{
				CurrencyCount = CurrencyCount,
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
		/// <param name="Itembrand"></param>
		/// <param name="ConditionType"></param>
		/// <param name="LoX"></param>
		/// <param name="LoY"></param>
		/// <returns></returns>
		private Control CreteItemBrandCell(string Itembrand, ConditionType ConditionType, ref int LoX, int LoY)
		{
			//获取对应的 组ID
			var ItemBrand = FileCache.Data.ItemBrand[Itembrand];
			if (ItemBrand is null) return null;

			//搜索对象
			var ItemBrandTooltip = FileCache.Data.ItemBrandTooltip[ItemBrand.ID, (byte)ConditionType];
			if (ItemBrandTooltip is null) Trace.WriteLine($"[CreteItemBrandCell] { ItemBrand.ID } => { ConditionType } 不存在");

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
	}
}