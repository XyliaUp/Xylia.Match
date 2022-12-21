using System.Collections.Generic;
using System.Linq;

using Xylia.bns.Modules.GameData.Enums;
using Xylia.Extension;
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

			var o = FileCache.Data.JobStyle.Find(o => o.job == Job && o.jobStyle == JobStyle);
			if (o != null) return o.IntroduceJobStyleName.GetText();

			return null;
		}

		public static List<string> GetPcJob() => typeof(JobSeq).GetFields()
				.Where(f => f.FieldType.IsEnum && (JobSeq)f.GetValue() > JobSeq.JobNone && (JobSeq)f.GetValue() < JobSeq.PcMax)
				.Select(f => f.GetDescription() ?? f.Name).ToList();

		public static JobSeq GetJob(string Text) => typeof(JobSeq).GetFields().ToList().Find(f => Text == (f.GetDescription() ?? f.Name))?.Name.ToEnum<JobSeq>() ?? JobSeq.JobNone;



	   public KeyCommand CurrentActionKey => FileCache.Data.KeyCommand.Find(o => o.keyCommand == KeyCommandSeq.Action3);
		#endregion
	}
}