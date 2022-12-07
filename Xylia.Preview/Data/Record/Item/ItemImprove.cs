using Xylia.Attribute.Component;
using Xylia.Preview.Project.Common.Interface;

namespace Xylia.Preview.Data.Record
{
	public sealed class ItemImprove : IRecord
	{
		#region 属性字段
		public byte Level;

		[Signal("success-option-list-id")]
		public int SuccessOptionListId;
		#endregion
	}
}
