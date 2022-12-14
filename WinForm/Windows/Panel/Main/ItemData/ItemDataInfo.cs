using System.Collections.Generic;

namespace Xylia.Match.Util.ItemMatch.Util
{
	public class ItemDataInfo
	{
		public int id;

		public string Alias;

		public string Name2;

		public string Desc;

		public string Info;


		public string Job;
	}


	public class ItemDataSort : IComparer<ItemDataInfo>
	{
		public int Compare(ItemDataInfo x, ItemDataInfo y)
		{
			return x.id - y.id;
		}
	}
}