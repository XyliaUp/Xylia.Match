using System;
using System.ComponentModel;

using Xylia.Preview.Common.Interface;


namespace Xylia.Preview.Data.Record
{
	/// <summary>
	/// 内容限制
	/// </summary>
	public sealed class ContentQuota : IRecord
	{
		#region 属性字段
		public int MaxValue;
		public int MinValue;
		public short Version;

		public TargetTypeSeq TargetType;
		public enum TargetTypeSeq
		{
			Character,

			Account,
		}


		public DateTime ExpirationTime;
		public Xylia.bns.Modules.GameData.Enums.ResetType ChargeInterval;
		public Xylia.bns.Modules.GameData.Enums.DayOfWeek ChargeDayOfWeek;
		
		public int ChargeTime;
		public int ChargeMinuteOfTime;
		public int ChargeAmountPerInterval;
		public bool ConsumeKeyRecord;
		#endregion
	}
}