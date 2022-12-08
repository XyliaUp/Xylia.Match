using System.ComponentModel;

using Xylia.Preview.Common.Interface;


namespace Xylia.Preview.Data.Record
{
	public sealed class Reward : IRecord
	{
		#region 固定组
		public string FixedItem1;
		public string FixedItem2;
		public string FixedItem3;
		public string FixedItem4;
		public string FixedItem5;
		public string FixedItem6;
		public string FixedItem7;
		public string FixedItem8;

		public int FixedItemMin1;
		public int FixedItemMin2;
		public int FixedItemMin3;
		public int FixedItemMin4;
		public int FixedItemMin5;
		public int FixedItemMin6;
		public int FixedItemMin7;
		public int FixedItemMin8;
		public int FixedItemMax1;
		public int FixedItemMax2;
		public int FixedItemMax3;
		public int FixedItemMax4;
		public int FixedItemMax5;
		public int FixedItemMax6;
		public int FixedItemMax7;
		public int FixedItemMax8;


		public string FixedItemInfo1
		{
			get
			{
				if (string.IsNullOrWhiteSpace(FixedItem1)) return null;

				if (FixedItemMin1 == FixedItemMax1) return FixedItem1.GetItemInfo().NameText() + $" {FixedItemMin1}个";
				else return FixedItem1.GetItemInfo().NameText() + $" {FixedItemMin1}~{FixedItemMax1}个";
			}
		}

		public string FixedItemInfo2
		{
			get
			{
				if (string.IsNullOrWhiteSpace(FixedItem2)) return null;

				if (FixedItemMin2 == FixedItemMax2) return FixedItem2.GetItemInfo().NameText() + $" {FixedItemMin2}个";
				else return FixedItem2.GetItemInfo().NameText() + $" {FixedItemMin2}~{FixedItemMax2}个";
			}
		}

		public string FixedItemInfo3
		{
			get
			{
				if (string.IsNullOrWhiteSpace(FixedItem3)) return null;

				if (FixedItemMin3 == FixedItemMax3) return FixedItem3.GetItemInfo().NameText() + $" {FixedItemMin3}个";
				else return FixedItem3.GetItemInfo().NameText() + $" {FixedItemMin3}~{FixedItemMax3}个";
			}
		}

		public string FixedItemInfo4
		{
			get
			{
				if (string.IsNullOrWhiteSpace(FixedItem4)) return null;

				if (FixedItemMin4 == FixedItemMax4) return FixedItem4.GetItemInfo().NameText() + $" {FixedItemMin4}个";
				else return FixedItem4.GetItemInfo().NameText() + $" {FixedItemMin4}~{FixedItemMax4}个";
			}
		}

		public string FixedItemInfo5
		{
			get
			{
				if (string.IsNullOrWhiteSpace(FixedItem5)) return null;

				if (FixedItemMin5 == FixedItemMax5) return FixedItem5.GetItemInfo().NameText() + $" {FixedItemMin5}个";
				else return FixedItem5.GetItemInfo().NameText() + $" {FixedItemMin5}~{FixedItemMax5}个";
			}
		}

		public string FixedItemInfo6
		{
			get
			{
				if (string.IsNullOrWhiteSpace(FixedItem6)) return null;

				if (FixedItemMin6 == FixedItemMax6) return FixedItem6.GetItemInfo().NameText() + $" {FixedItemMin6}个";
				else return FixedItem6.GetItemInfo().NameText() + $" {FixedItemMin6}~{FixedItemMax6}个";
			}
		}

		public string FixedItemInfo7
		{
			get
			{
				if (string.IsNullOrWhiteSpace(FixedItem7)) return null;

				if (FixedItemMin7 == FixedItemMax7) return FixedItem7.GetItemInfo().NameText() + $" {FixedItemMin7}个";
				else return FixedItem7.GetItemInfo().NameText() + $" {FixedItemMin7}~{FixedItemMax7}个";
			}
		}

		public string FixedItemInfo8
		{
			get
			{
				if (string.IsNullOrWhiteSpace(FixedItem8)) return null;

				if (FixedItemMin8 == FixedItemMax8) return FixedItem8.GetItemInfo().NameText() + $" {FixedItemMin8}个";
				else return FixedItem8.GetItemInfo().NameText() + $" {FixedItemMin8}~{FixedItemMax8}个";
			}
		}
		#endregion




		#region 数据字段
		[Description("selected-item-assured-count")]
		public int SelectedItemAssuredCount;
		#endregion
	}
}
