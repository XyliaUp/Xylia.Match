
using Xylia.Attribute.Component;
using Xylia.bns.Modules.GameData.Enums;
using Xylia.Preview.Common.Interface;

namespace Xylia.Preview.Data.Record
{
	public sealed class QuestBonusRewardSetting : IRecord
	{
		#region 属性字段
		public TypeSeq Type;

		public enum TypeSeq
		{
			[Signal("sealed-level")]
			SealedLevel,

			[Signal("difficulty-type")]
			DifficultyType,

			[Signal("ignore-difficulty")]
			IgnoreDifficulty,
		}




		public string Quest;

		public string Reward;

		[Signal("basic-quota")]
		public string BasicQuota;

		[Signal("contents-reset-1")]
		public string ContentsReset1;

		[Signal("contents-reset-2")]
		public string ContentsReset2;

		[Signal("contents-reset-3")]
		public string ContentsReset3;

		[Signal("contents-reset-4")]
		public string ContentsReset4;

		[Signal("contents-reset-5")]
		public string ContentsReset5;

		[Signal("contents-reset-6")]
		public string ContentsReset6;

		[Signal("contents-reset-7")]
		public string ContentsReset7;

		[Signal("contents-reset-8")]
		public string ContentsReset8;

		[Signal("contents-reset-9")]
		public string ContentsReset9;

		[Signal("contents-reset-10")]
		public string ContentsReset10;




		[Signal("sealed-level")]
		public byte SealedLevel;

		[Signal("difficulty-type")]
		public DifficultyType DifficultyType;
		#endregion
	}
}