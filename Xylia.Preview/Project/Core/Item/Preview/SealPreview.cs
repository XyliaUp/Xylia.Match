using System.Collections.Generic;
using System.Linq;

using Xylia.Extension;
using Xylia.Preview.Data.Record;
using Xylia.Preview.Common.Interface;
using Xylia.Preview.Project.Controls.PanelEx;
using Xylia.Preview.Project.Core.Item.Preview.Reward;

using ItemData = Xylia.Preview.Data.Record.Item;


namespace Xylia.Preview.Project.Core.Item
{
	/// <summary>
	/// 封印解印提示工具
	/// </summary>
	public partial class SealPreview : TitleContentPanel, IPreview
	{
		#region 构造
		public SealPreview() : base()
		{
			InitializeComponent();
		}
		#endregion

		#region 接口方法
		bool INVALID;
		bool IPreview.INVALID() => this.INVALID;

		void IPreview.LoadData(IRecord Record)
		{
			#region 封印数据
			//新封印方法
			var SealRenewalAuctionable = Record.Attributes["seal-renewal-auctionable"].ToBool();
			var SealConsumeItem1 = Record.Attributes["seal-consume-item-1"];
			var SealConsumeItem2 = Record.Attributes["seal-consume-item-2"];
			var SealConsumeItemCount1 = (short)Record.Attributes["seal-consume-item-count-1"].ConvertToInt();
			var SealConsumeItemCount2 = (short)Record.Attributes["seal-consume-item-count-2"].ConvertToInt();
			var SealAcquireItem = Record.Attributes["seal-acquire-item"];
			var UnsealResultPreviewItem = Record.Attributes["unseal-result-preview-item"];
			#endregion

			#region 解印数据
			List<string> UnsealAcquireItem = new();
			List<DecomposeByItem2> UnsealConsumeItem2 = new();

			for (int i = 0; i <= 20; i++)
			{
				var item = Record.Attributes[$"unseal-acquire-item-{i}"];
				if (item != null) UnsealAcquireItem.Add(item);
			}

			for (int i = 0; i <= 4; i++)
			{
				var item = new DecomposeByItem2(
					Record.Attributes[$"unseal-consume-item2-{i}"], 
					Record.Attributes[$"unseal-consume-item2-stack-count-{i}"].ConvertToInt());

				if (!item.INVALID) UnsealConsumeItem2.Add(item);
			}
			#endregion


			#region 加载信息
			string Info = null;

			//封印信息
			if (SealRenewalAuctionable || SealAcquireItem != null)
			{
				this.Title = "封印";

				if (SealConsumeItem1 != null)
				{
					var ConsumeItem = SealConsumeItem1.GetItemInfo();
					Info = $"{ SealConsumeItemCount1 }个{ ConsumeItem.ItemNameWithGrade }";
				}
				if (SealConsumeItem2 != null)
				{
					var ConsumeItem = SealConsumeItem2.GetItemInfo();
					Info += $"或者 { SealConsumeItemCount2 }个{ ConsumeItem.ItemNameWithGrade }";
				}

				//显示封印信息
				if (SealRenewalAuctionable) Info = $"可通过{ Info }进行封印，封印后保留强化效果";
				else Info = $"可通过{ Info }重新封印为{ SealAcquireItem?.GetItemInfo()?.ItemNameWithGrade }";
			}

			//解印信息
			else if (UnsealResultPreviewItem != null || UnsealAcquireItem.Any())
			{
				this.Title = "解印";

				//获取可使用的解印符
				if (UnsealConsumeItem2.Any())
				{
					var CurItemInfo = UnsealConsumeItem2.First();
					var ConsumeItem = CurItemInfo.Item.GetItemInfo();
					Info += $"{ CurItemInfo.StackCount }个{ ConsumeItem.ItemNameWithGrade }";
				}

				#region 获取解印获得道具
				ItemData UnsealResultItem = null;

				if (UnsealResultPreviewItem != null) UnsealResultItem = UnsealResultPreviewItem.GetItemInfo();
				else if (UnsealAcquireItem.Any()) UnsealResultItem = UnsealAcquireItem.First().GetItemInfo();

				if (UnsealResultItem != null) Info = $"可通过{ Info } 解印为 { UnsealResultItem.ItemNameWithGrade }";
				#endregion
			}
			#endregion


			this.INVALID = Info is null;
			this.Content = Info;
		}
		#endregion
	}
}
