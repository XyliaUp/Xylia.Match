
using Xylia.Attribute.Component;
using Xylia.bns.Modules.GameData.Enums;
using Xylia.Preview.Common.Interface;



namespace Xylia.Preview.Data.Record
{
	public sealed class SkillTrainCategory : IRecord
	{
		#region 数据字段
		public JobSeq Job;

		[Signal("view-skill-id")]
		public int ViewSkillId;

		[Signal("tree-id")]
		public int TreeId;

		[Signal("pc-level")]
		public short PcLevel;

		[Signal("pc-mastery-level")]
		public short PcMasteryLevel;

		[Signal("complete-quest")]
		public string CompleteQuest;

		[Signal("jumping-pc-complete-quest")]
		public string JumpingPcCompleteQuest;

		[Signal("consumed-tp")]
		public int ConsumedTp;

		[Signal("sort-id")]
		public byte SortId;

		[Signal("ui-invisible")]
		public bool UiInvisible;

		[Signal("context-lock-disable")]
		public bool ContextLockDisable;
		#endregion
	}
}
