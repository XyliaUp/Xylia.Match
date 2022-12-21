using System.Collections.Generic;
using System.Linq;

using Xylia.Attribute.Component;
using Xylia.bns.Modules.GameData.Enums;
using Xylia.Preview.Common.Interface;



namespace Xylia.Preview.Data.Record
{
	public sealed class SkillModifyInfoGroup : IRecord
	{
		#region 属性字段
		/// <summary>
		/// 职业派系
		/// </summary>
		[Signal("job-style")]
		public JobStyleSeq JobStyle;

		[Signal("skill-modify-info-1")]
		public string SkillModifyInfo1;

		[Signal("skill-modify-info-2")]
		public string SkillModifyInfo2;

		[Signal("skill-modify-info-3")]
		public string SkillModifyInfo3;

		[Signal("skill-modify-info-4")]
		public string SkillModifyInfo4;
		#endregion


		#region 方法
		public JobSeq SpecificJob;

		public override string ToString()
		{
			var SkillModifyInfos = new List<string>
			{
				FileCache.Data.SkillModifyInfo[this.SkillModifyInfo1]?.ToString(),
				FileCache.Data.SkillModifyInfo[this.SkillModifyInfo2]?.ToString(),
				FileCache.Data.SkillModifyInfo[this.SkillModifyInfo3]?.ToString(),
				FileCache.Data.SkillModifyInfo[this.SkillModifyInfo4]?.ToString()

			}.Where(a => !string.IsNullOrWhiteSpace(a));


			if (!SkillModifyInfos.Any()) return null;
			return Job.GetStyleName(this.SpecificJob, this.JobStyle) + SkillModifyInfos.Aggregate((sum, now) => sum + "<br/>" + now);
		}
		#endregion
	}
}