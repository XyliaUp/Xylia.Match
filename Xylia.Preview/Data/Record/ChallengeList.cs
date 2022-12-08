using System;

using Xylia.Attribute.Component;
using Xylia.Preview.Common.Interface;
using System.ComponentModel;

namespace Xylia.Preview.Data.Record
{
	/// <summary>
	/// 挑战
	/// </summary>
	public sealed class ChallengeList : IRecord
	{
		#region 枚举
		public enum TypeSeq : byte
		{
			dayofweek,
			week,
		}

		public enum ChallengeTypeSeq
		{
			None,

			[Description("周日")]
			sun,

			[Description("周一")]
			mon,

			[Description("周二")]
			tue,

			[Description("周三")]
			wed,

			[Description("周四")]
			thu,

			[Description("周五")]
			fri,

			[Description("周六")]
			sat,

			week1,
			week2,
			week3,
			week4,
			week5,
			week6,
			week7,
			week8,
			week9,
			week10,
		}



		public enum Grade : byte
		{
			None,
			Grade1,
			Grade2,
			Grade3,
		}
		#endregion


		#region 属性字段
		public TypeSeq Type;

		public ChallengeTypeSeq ChallengeType;


		[Signal("required-level")]
		public byte RequiredLevel;

		[Signal("required-mastery-level")]
		public byte RequiredMasteryLevel;




		[Signal("challenge-quest-complete-count")]
		public byte ChallengeQuestCompleteCount;

		[Signal("challenge-quest-count")]
		public byte ChallengeQuestCount;


		[Signal("challenge-npc-total-count")]
		public byte ChallengeNpcTotalCount;

		[Signal("challenge-reward-total-count")]
		public byte ChallengeRewardTotalCount;



		[Signal("week-start-date-time")]
		public DateTime WeekStartDateTime;
		#endregion
	}
}