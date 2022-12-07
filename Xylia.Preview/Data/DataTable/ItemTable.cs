using System;

using Xylia.Preview.Data.Record;
using Xylia.Preview.Properties.AnalyseSection;

namespace Xylia.Preview.Data
{
	/// <summary>
	/// 物品数据
	/// </summary>
	public sealed class ItemTable : DataTable<Item>
	{
		public override bool PublicSet => false;

		protected override bool LoadFromGame => true;

		protected override string ConfigContent => DataRes.ItemData_v39;
	}
}