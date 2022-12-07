using System;

using Xylia.Preview.Project.Common.Interface;


namespace Xylia.Preview.Data.Record
{
	public sealed class ItemEvent : IRecord	
	{
		#region 属性字段
		public string Name2;

		public DateTime EventExpirationTime;
		#endregion


		#region 方法字段
		/// <summary>
		/// 指示是否已经过期
		/// </summary>
		public bool IsExpiration => this.EventExpirationTime < DateTime.Now;
		#endregion
	}
}
