using System;

using Xylia.Preview.Project.Common.Interface;


namespace Xylia.Preview.Data.Record
{
	public sealed class ItemRandomAbilitySection : IRecord
	{
		#region 属性字段
		public string alias;

		public int VariationValueMin;
		public int VariationValueMax;
		public int VariationValueWithSpecialItemMin;
		public int VariationValueWithSpecialItemMax;
		#endregion
	}
}
