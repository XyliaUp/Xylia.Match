using Xylia.Preview.Common.Interface;

namespace Xylia.Preview.Data.Record
{
	public sealed class UnlocatedStore : IRecord
	{
		#region 字段
		public string Store2;

		public Type UnlocatedStoreType;
		#endregion


		#region 枚举
		/// <summary>
		/// 非固定商店分类
		/// </summary>
		public enum Type
		{
			UnlocatedNone = 0,
			UnlocatedStore,
			AccountStore,

			SoulBoostStore1,
			SoulBoostStore2,
			SoulBoostStore3,
			SoulBoostStore4,
			SoulBoostStore5,
			SoulBoostStore6,
		}
		#endregion
	}
}
