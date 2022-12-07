using Xylia.Preview.Project.Common.Interface;


namespace Xylia.Preview.Data.Record
{
	public sealed class AccountPostCharge : IRecord
	{
		#region 属性字段
		public string ChargeItem1;
		public string ChargeItem2;

		public int ChargeItemAmount1;
		public int ChargeItemAmount2;
		#endregion
	}
}
