
using Xylia.Attribute.Component;
using Xylia.Preview.Project.Common.Enums;

namespace Xylia.Preview.Data.Record
{
	public sealed partial class Skill3
	{
		public enum FlowType
		{
			KeepMainslot,
			LeaveCaster,
			TransferSimslot,
			DirectlySimslot,
		}

		public FlowType flowType;



		[Signal("dash-attribute")]
		public string DashAttribute;




		[Signal("target-filter")]
		public string TargetFilter;

		[Signal("gather-range")]
		public string GatherRange;




		[Signal("cast-condition")]
		public string CastCondition;

		[Signal("cast-duration")]
		public int CastDuration;

		[Signal("cast-effect-1")]
		public string CastEffect1;

		[Signal("cast-effect-2")]
		public string CastEffect2;

		[Signal("cast-effect-3")]
		public string CastEffect3;

		[Signal("cast-effect-4")]
		public string CastEffect4;

		[Signal("cast-effect-5")]
		public string CastEffect5;

		[Signal("cast-effect-6")]
		public string CastEffect6;

		[Signal("cast-effect-to-my-summoned-summoner-1")]
		public string CastEffectToMySummonedSummoner1;

		[Signal("cast-effect-to-my-summoned-summoner-2")]
		public string CastEffectToMySummonedSummoner2;

		[Signal("cast-effect-to-my-summoned-summoner-3")]
		public string CastEffectToMySummonedSummoner3;

		[Signal("cast-effect-to-my-summoned-summoner-4")]
		public string CastEffectToMySummonedSummoner4;

		[Signal("cast-effect-to-my-summoned-summoner-distance")]
		public int CastEffectToMySummonedSummonerDistance;

		[Signal("throw-link-target")]
		public bool ThrowLinkTarget;

		[Signal("casting-delay")]
		public bool CastingDelay = true;

		[Signal("fire-miss")]
		public bool FireMiss;

		[Signal("global-recycle-group")]
		public byte GlobalRecycleGroup;

		[Signal("global-recycle-group-duration")]
		public int GlobalRecycleGroupDuration;

		[Signal("recycle-group")]
		public RecycleGroup RecycleGroup;

		[Signal("recycle-group-id")]
		public byte RecycleGroupId;

		[Signal("recycle-group-duration")]
		public int RecycleGroupDuration;

		[Signal("bound-recycle-group")]
		public RecycleGroup BoundRecycleGroup;

		[Signal("bound-recycle-group-id")]
		public byte BoundRecycleGroupId;










		[Signal("exec-gather-type-1")] 
		public GatherType ExecGatherType1;

		[Signal("exec-gather-type-2")] 
		public GatherType ExecGatherType2;

		[Signal("exec-gather-type-3")] 
		public GatherType ExecGatherType3;

		[Signal("exec-gather-type-4")] 
		public GatherType ExecGatherType4;

		[Signal("exec-gather-type-5")] 
		public GatherType ExecGatherType5;
	}
}
