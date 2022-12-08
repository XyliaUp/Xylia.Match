using System.ComponentModel;

using Xylia.Preview.Common.Interface;

using CommonTable = Xylia.bns.Modules.GameData.CommonTable;

namespace Xylia.Preview.Data.Record
{
	public sealed class NpcResponse : IRecord
	{
		#region 属性字段
		public string alias;

		[Description("faction-check-type")]
		public FactionCheckType factionCheckType;

		[Description("faction-1")]
		public CommonTable.Faction Faction1;

		[Description("faction-2")]
		public CommonTable.Faction Faction2;

		[Description("required-complete-quest")]
		public string RequiredCompleteQuest;

		[Description("faction-level-check-type")]
		public FactionLevelCheckType factionLevelCheckType;

		[Description("talk-message")]
		public string TalkMessage;

		[Description("indicator-social")]
		public CommonTable.IndicatorSocial IndicatorSocial;

		[Description("approach-social")]
		public CommonTable.Social ApproachSocial;

		[Description("idle")]
		public CommonTable.IndicatorSocial Idle;

		[Description("idle-visible")]
		public bool IdleVisible;

		[Description("idle-start")]
		public CommonTable.Social IdleStart;

		[Description("idle-end")]
		public CommonTable.Social IdleEnd;
		#endregion


		#region 枚举
		public enum FactionCheckType : byte
		{
			[Description("is")]
			Is,

			[Description("is-not")]
			IsNot,

			[Description("is-none")]
			IsNone,
		}

		public enum FactionLevelCheckType : byte
		{
			None,

			[Description("check-for-success")]
			CheckForSuccess,

			[Description("check-for-fail")]
			CheckForFail,
		}
		#endregion
	}
}
