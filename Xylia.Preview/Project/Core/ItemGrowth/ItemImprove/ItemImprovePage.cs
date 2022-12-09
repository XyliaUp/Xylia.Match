﻿using System;
using System.Drawing;
using System.Linq;

using Xylia.Extension;
using Xylia.Preview.Data.Record;
using Xylia.Preview.Project.Core.ItemGrowth.Preview;


namespace Xylia.Preview.Project.Core.ItemGrowth.Page
{
	public partial class ItemImprovePage : ItemGrowth2Page
	{
		#region 构造
		public ItemImprovePage()
		{
			InitializeComponent();
		}
		#endregion

		#region 方法
		public void SetData(ItemImprove ItemImprove, string ImprovePrevItem, string ImproveNextItem)
		{
			if (ItemImprove is null) throw new Exception("没有成长路径");

			//目标物品
			this.ResultWeaponPreview.SetData(ItemImprove, ImproveNextItem);

			//获取强化效果
			if (ItemImprove.SuccessOptionListId != 0)
			{
				var Optionlist = FileCache.Data.ItemImproveOptionList[ItemImprove.SuccessOptionListId];
				System.Diagnostics.Debug.WriteLine($"{ItemImprove.Level} 强化成功时追加强化效果 ↓↓↓   重置钱币: {Optionlist.DrawCostMoney1} {Optionlist.DrawCostMainItem1}");

				for (int idx = 1; idx <= 100; idx++)
				{
					var Option = FileCache.Data.ItemImproveOption[Optionlist.Attributes["option-" + idx]];
					if (Option is null) break;

					var option = FileCache.Data.ItemImproveOption[Option.ID, ItemImprove.Level + 1];
					System.Diagnostics.Debug.WriteLine(option.ToString());
				}
			}
		}


		/// <summary>
		/// 目标物品改变
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected override void ResultWeaponPreview_ResultItemChanged(ResultItemChangedEventArgs e)
		{
			this.SubIngredientPreview.SetData(e.ItemImprove);
			this.SubIngredientPreview.Location = new Point((this.Width - this.SubIngredientPreview.Width) / 2, this.SubIngredientPreview.Location.Y);
		}

		/// <summary>
		/// 主要祭品改变
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected override void SubIngredientPreview_RecipeChanged(RecipeChangedEventArgs e)
		{
			//更新固定祭品信息
			this.FixedIngredientPreview.LoadData(e.ItemImprove, e.Index);
			this.FixedIngredientPreview.Location = new Point((this.Width - this.FixedIngredientPreview.Width) / 2, this.FixedIngredientPreview.Location.Y);

			//更新手续费信息
			this.MoneyCostPreview.MoneyCost = e.ItemImprove.Attributes[$"cost-money-{e.Index}"].ToInt();

			//获取特殊说明
			var UseSuccessProbability = e.ItemImprove.Attributes[$"use-success-probability-{e.Index}"].ToBool();
			var FailDiff = e.ItemImprove.Attributes[$"fail-level-diff-{e.Index}"].ConvertToByte();

			if (UseSuccessProbability)
			{
				if (FailDiff != 0) this.WarningPreview.Text = $"有一定概率强化失败。失败时，强化阶段<font name=\"00008130.UI.Vital_red\">下降</font>{FailDiff}阶段。";
				else this.WarningPreview.Text = $"有一定概率强化失败。";

				this.WarningPreview.Location = new Point((this.Width - this.WarningPreview.Width) / 2, this.WarningPreview.Location.Y);
			}
		}
		#endregion
	}
}