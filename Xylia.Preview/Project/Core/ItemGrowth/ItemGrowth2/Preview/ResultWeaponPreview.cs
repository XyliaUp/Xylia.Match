using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using Xylia.Extension;
using Xylia.Preview.Data.Record;
using Xylia.Preview.Project.Core.ItemGrowth.Cell;


namespace Xylia.Preview.Project.Core.ItemGrowth.Preview
{
	[Designer(typeof(Designer.FixedHeightDesigner))]
	public partial class ResultWeaponPreview : UserControl
	{
		#region 构造
		public ResultWeaponPreview()
		{
			InitializeComponent();
		}
		#endregion

		#region 事件与委托
		//定义委托
		public delegate void ResultItemChangedHandle(ResultItemChangedEventArgs e);

		//定义事件
		public event ResultItemChangedHandle ResultItemChanged;
		#endregion

		#region 字段
		/// <summary>
		/// 单页最大目标数量
		/// </summary>
		const int MaxCellNum = 5;
		#endregion


		#region 方法
		public void SetData(IEnumerable<ItemTransformRecipe> Recipes)
		{
			//获得成长目标信息
			var PreviewResult = Recipes.Select(r => r.TitleItem).Distinct();
			this.SetData(item => this.ResultItemChanged?.Invoke(new ResultItemChangedEventArgs(Recipes.Where(o => o.TitleItem == item))), PreviewResult.ToArray());
		}

		public void SetData(ItemImprove ItemImprove, string ImproveNextItem)
		{
			//获得成长目标信息
			this.SetData(item => this.ResultItemChanged?.Invoke(new ResultItemChangedEventArgs(ItemImprove)), ImproveNextItem);
		}

		public void SetData(Action<string> test, params string[] NextItem)
		{
			#region 初始化
			this.Controls.Remove<ItemPreviewCell>();
			#endregion

			#region 创建目标物品控件
			int LocX = 50;
			foreach (var TitleItem in NextItem)
			{
				#region 创建控件对象
				ItemPreviewCell ItemPreviewCell = new()
				{
					Location = new Point(LocX, 0),

					ItemInfo = TitleItem.GetItemInfo(),
					ShowStackCount = false,
				};

				this.Controls.Add(ItemPreviewCell);
				LocX = ItemPreviewCell.Right;
				#endregion

				#region 委托绑定事件
				ItemPreviewCell.Click += new EventHandler((s, e) =>
				{
					//将其他对象的选择状态取消
					this.Controls.OfType<ItemPreviewCell>().ForEach(c => c.ShowFrameImage = false);
					ItemPreviewCell.ShowFrameImage = true;

					test(TitleItem);
				});
				#endregion
			}
			#endregion

			this.Controls.OfType<ItemPreviewCell>().FirstOrDefault()?.CallEvent("OnClick");
		}
		#endregion
	}


	/// <summary>
	/// 目标物品变更事件
	/// </summary>
	public class ResultItemChangedEventArgs : EventArgs
	{
		public IEnumerable<ItemTransformRecipe> Recipes { get; set; }
		public ResultItemChangedEventArgs(IEnumerable<ItemTransformRecipe> Recipes) => this.Recipes = Recipes;
		

		public ItemImprove ItemImprove;
		public ResultItemChangedEventArgs(ItemImprove ItemImprove) => this.ItemImprove = ItemImprove;
	}
}
