using Xylia.bns.Modules.GameData.Enums;
using Xylia.Preview.Common.Interface;


namespace Xylia.Preview.Data.Record
{
	public sealed class JobData : IRecord
	{
		#region 属性字段
		public byte job;
		public string name;
		public string image;
		public string desc;

		public string ItemMapJobIcon;
		public string ItemMapJobIconStyle1;
		public string ItemMapJobIconStyle2;
		public string ItemMapJobIconStyle3;

		public string JobStyleName1;
		public string JobStyleName2;
		public string JobStyleName3;
		public string JobStyleName4;
		public string JobStyleName5;
		#endregion


		/// <summary>
		/// 获得派系名称
		/// </summary>
		/// <param name="Job"></param>
		/// <param name="JobStyle"></param>
		/// <returns></returns>
		public static string GetStyleName(Job Job, JobStyle JobStyle)
		{
			if (Job == Job.JobNone) return null;

			var o = FileCache.Data.JobStyle.Find(o => o.Job == Job && o.JobStyle == JobStyle);
			if (o != null) return o.IntroduceJobStyleName.GetText();

			return null;
		}
	}
}
