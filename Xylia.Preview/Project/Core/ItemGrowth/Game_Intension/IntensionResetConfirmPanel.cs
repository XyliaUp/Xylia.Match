
using System.Collections.Generic;

using Xylia.Extension;
using Xylia.Preview.Data.Record;
using Xylia.Preview.Project.Core.ItemGrowth.ItemGrowth2.Preview;

namespace Xylia.Preview.Project.Core.ItemGrowth.Page
{
	public partial class IntensionResetConfirmPanel : EquipmentGuidePage
	{
		public IntensionResetConfirmPanel() => InitializeComponent();




		private byte ImproveLevel;

		private List<ItemImproveOptionList> OptionLists = new();

		public void SetData(int ImproveId, byte ImproveLevel)
		{
			this.OptionLists = new();
			this.ImproveLevel = ImproveLevel;

			foreach (var o in FileCache.Data.ItemImprove.Where(o => o.ID == ImproveId && o.SuccessOptionListId != 0))
			{
				var OptionList = FileCache.Data.ItemImproveOptionList[o.SuccessOptionListId];
				if (OptionList is null)
				{
					System.Diagnostics.Debug.WriteLine($"无效的效果组 {o.SuccessOptionListId}");
					continue;
				}

				OptionLists.Add(OptionList);
				CurrentOptionList.Add($"强化至 {o.Level + 1} 阶段时追加强化效果");
			}

			CurrentOptionList.RefreshList();
		}

		private void IntensionResetConfirmPanel_Load(object sender, System.EventArgs e) => CurrentOptionList.Controls[0]?.CallEvent("OnClick");

		private void CurrentOptionList_SelectedItemChanged(object sender, System.EventArgs e)
		{
			var OptionList = OptionLists[CurrentOptionList.SelectedIndex];
			this.SubIngredientPreview.SetData(OptionList);

			#region 获取强化效果列表
			AcquirableOptionList.Clear();
			for (int idx = 1; idx <= 50; idx++)
			{
				var Option = FileCache.Data.ItemImproveOption[OptionList.Attributes["option-" + idx]];
				if (Option is null) break;

				if (Option.Level > ImproveLevel) AcquirableOptionList.Add(Option.ToString());
				else AcquirableOptionList.Add((FileCache.Data.ItemImproveOption[Option.ID, ImproveLevel] ?? Option).ToString());
			}

			AcquirableOptionList.RefreshList();
			#endregion
		}

		protected override void SubIngredientPreview_RecipeChanged(RecipeChangedEventArgs e)
		{
			this.FixedIngredientPreview.SetData(e.ItemImproveOptionList, e.Index);
			this.MoneyCostPreview.MoneyCost = e.ItemImproveOptionList.Attributes[$"draw-cost-money-{e.Index}"].ToInt();
		}
	}
}