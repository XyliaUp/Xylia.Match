using Xylia.bns.Modules.GameData.Enums;
using Xylia.Preview.Common.Interface;

namespace Xylia.Preview.Data.Record
{
	public sealed class Job : IRecord
	{
		#region 属性字段
		public JobSeq job;


		public string Name2;

		public string Icon;

		public string Desc;
		#endregion


		#region 方法
		/// <summary>
		/// 获得派系名称
		/// </summary>
		/// <param name="Job"></param>
		/// <param name="JobStyle"></param>
		/// <returns></returns>
		public static string GetStyleName(JobSeq Job, JobStyleSeq JobStyle)
		{
			if (Job == JobSeq.JobNone) return null;

			var o = FileCache.Data.JobStyle.Find(o => o.Job == Job && o.jobStyle == JobStyle);
			if (o != null) return o.IntroduceJobStyleName.GetText();

			return null;
		}

		public KeyCommand CurrentActionKey => FileCache.Data.KeyCommand.Find(o => o.keyCommand == KeyCommandSeq.Action3);
		#endregion
	}
}