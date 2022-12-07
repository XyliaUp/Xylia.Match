using System.Linq;

using Xylia.Extension;
using Xylia.Files.XmlEx;
using Xylia.Preview.Project.Common.Interface;
using Xylia.Preview.Project.Common.Enums;
using Xylia.bns.Modules.GameData.Enums; 


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
	}


	/// <summary>
	/// 扩展方法
	/// </summary>
	public static partial class ItemExtension
	{
		/// <summary>
		/// 获得派系名称
		/// </summary>
		/// <param name="Job"></param>
		/// <param name="JobStyle"></param>
		/// <returns></returns>
		public static string GetStyleName(this Job Job, JobStyle JobStyle)
		{
			var Info = FileCacheData.Data.Job.Find(t => t.job == (byte)Job);
			if (Info != null) return JobStyle switch
			{
				JobStyle.Base1 => Info.JobStyleName1.GetText(),
				JobStyle.Base2 => Info.JobStyleName2.GetText(),
				JobStyle.Base3 => Info.JobStyleName3.GetText(),
				JobStyle.Base4 => Info.JobStyleName4.GetText(),
				JobStyle.Base5 => Info.JobStyleName5.GetText(),

				JobStyle.Advanced1 => Info.JobStyleName1.GetText(),
				JobStyle.Advanced2 => Info.JobStyleName2.GetText(),
				JobStyle.Advanced3 => Info.JobStyleName3.GetText(),
				JobStyle.Advanced4 => Info.JobStyleName4.GetText(),
				JobStyle.Advanced5 => Info.JobStyleName5.GetText(),

				_ => JobStyle.ToString(),
			};

			return JobStyle.ToString();
		}
	}
}
