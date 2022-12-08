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
		public JobStyle JobStyle;

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
		public Job SpecificJob;

		/// <summary>
		/// 获得职业派系描述
		/// </summary>
		public string StyleName
		{
			get
			{
				return null;

				//不显示Base派系（其实我也不是很清楚Base、Advanced派系有什么区别）
				if ((int)this.JobStyle > 4)
				{
					if (this.SpecificJob != 0) return this.SpecificJob.GetStyleName(this.JobStyle);
					else if (true) this.JobStyle.ToString();
				}

				return null;
			}
		}


		public string CreateInfo()
		{
			#region 采集信息
			var TextList = new List<string>
			{
				FileCache.Data.SkillModifyInfo[this.SkillModifyInfo1]?.ToString(),
				FileCache.Data.SkillModifyInfo[this.SkillModifyInfo2]?.ToString(),
				FileCache.Data.SkillModifyInfo[this.SkillModifyInfo3]?.ToString(),
				FileCache.Data.SkillModifyInfo[this.SkillModifyInfo4]?.ToString(),
			};
			#endregion

			var tempList = TextList.Where(a => !string.IsNullOrWhiteSpace(a));

			if (!tempList.Any()) return null;
			return tempList.Aggregate((sum, now) => sum + "<br/>" + now);
		}
		#endregion
	}
}
