using System;
using System.ComponentModel;

using Xylia.Extension;
using Xylia.Preview.Common.Interface;


namespace Xylia.Preview.Data.Record
{
	/// <summary>
	/// 内容限制
	/// 更新时间：2021年4月20日18:06:04
	/// </summary>
	public sealed class ContentQuota : IRecord
	{
		#region 属性字段
		public int MaxValue;
		public int MinValue;
		public short Version;
		public TargetType TargetType = TargetType.Character;
		public DateTime ExpirationTime;

		public ResetType ChargeInterval = ResetType.None;
		public ResetDay ChargeDayOfWeek = ResetDay.None;
		public int ChargeTime;
		public int ChargeMinuteOfTime;
		public int ChargeAmountPerInterval;

		public bool ConsumeKeyRecord;
		#endregion


		/// <summary>
		/// 合并信息
		/// </summary>
		public string Info
		{
			get
			{
				//读取重置周期信息
				string LimitInfo = null;
				if (ChargeInterval != ResetType.None)
					LimitInfo += ChargeInterval.GetDescription() + " ";

				return $"{ TargetType.GetDescription() } { LimitInfo }{ MaxValue }个";
			}
		}

		/// <summary>
		/// 初始化信息
		/// </summary>
		public string ResetInfo
		{
			get
			{
				//读取重置周期信息
				string ResetInfo = null;
				switch (ChargeInterval)
				{
					case ResetType.Daily:
					{
						ResetInfo = $"每日{ ChargeTime }时";
					}
					break;

					case ResetType.Weekly:
					{
						ResetInfo = $"每{ ChargeDayOfWeek.GetDescription() } { ChargeTime }时";
					}
					break;
				}

				if (!ResetInfo.IsNull()) return $"{ ResetInfo }";
				else return null;
			}
		}
	}


	public enum TargetType
	{
		[Description("角色")]
		Character = 0,

		[Description("账号")]
		Account = 1,
	}

	/// <summary>
	/// 重置类型
	/// </summary>
	public enum ResetType
	{
		None = 0,

		[Description("每小时")]
		Hourly = 1,

		[Description("每日")]
		Daily,

		[Description("每周")]
		Weekly,

		[Description("每月")]
		Monthly,
	}

	public enum ResetDay
	{
		None = 0,

		[Description("周一")]
		mon = 1,

		[Description("周二")]
		tue = 2,

		[Description("周三")]
		wed = 3,

		[Description("周四")]
		thu = 4,

		[Description("周五")]
		fri = 5,

		[Description("周六")]
		sat = 6,

		[Description("周日")]
		sun = 7,
	}
}
