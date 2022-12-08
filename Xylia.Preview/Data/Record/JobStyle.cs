using System.ComponentModel;

using Xylia.Attribute.Component;
using Xylia.bns.Modules.GameData.Enums;
using Xylia.Preview.Common.Interface;

namespace Xylia.Preview.Data.Record
{
	public sealed class JobStyleData : IRecord
	{
		#region	属性字段
		public Job Job;

		public JobStyle JobStyle;

		[Signal("introduce-job-style-icon")]
		public string IntroduceJobStyleIcon;

		[Signal("introduce-job-style-name")]
		public string IntroduceJobStyleName;

		[Signal("introduce-job-style-play-desc")]
		public string IntroduceJobStylePlayDesc;

		[Signal("introduce-job-style-specialization-1")]
		public string IntroduceJobStyleSpecialization1;

		[Signal("introduce-job-style-specialization-2")]
		public string IntroduceJobStyleSpecialization2;

		[Signal("introduce-job-style-specialization-3")]
		public string IntroduceJobStyleSpecialization3;

		[Signal("introduce-job-style-specialization-4")]
		public string IntroduceJobStyleSpecialization4;

		[Signal("introduce-job-style-specialization-5")]
		public string IntroduceJobStyleSpecialization5;
		#endregion
	}
}
