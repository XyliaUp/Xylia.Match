
using Xylia.Attribute.Component;
using Xylia.Preview.Common.Interface;

namespace Xylia.Preview.Data.Record
{
	public sealed class RandomStoreDrawReward : IRecord
	{
		#region 字段
		/// <summary>
		/// 需要开启次数
		/// </summary>
		[Signal("required-draw-count")]
		public int RequiredDrawCount;

		public RandomStoreNumber RandomStoreNumber;
		#endregion
	}
}
