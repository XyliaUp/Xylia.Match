using Xylia.Preview.Common.Interface;

namespace Xylia.Preview.Data.Record
{
	public sealed class SkillGatherRange3 : IRecord
	{
		#region 字段	
		public string CastDirCaster;
		public string CastDirTarget;

		public int GatherLaserBackDistanceMax1;
		public int GatherLaserBackDistanceMax2;
		public int GatherLaserBackDistanceMax3;
		public int GatherLaserBackDistanceMax4;
		public int GatherLaserBackDistanceMax5;
		public int GatherLaserBackDistanceMin1;
		public int GatherLaserBackDistanceMin2;
		public int GatherLaserBackDistanceMin3;
		public int GatherLaserBackDistanceMin4;
		public int GatherLaserBackDistanceMin5;

		public int GatherLaserFrontDistanceMax1;
		public int GatherLaserFrontDistanceMax2;
		public int GatherLaserFrontDistanceMax3;
		public int GatherLaserFrontDistanceMax4;
		public int GatherLaserFrontDistanceMax5;
		public int GatherLaserFrontDistanceMin1;
		public int GatherLaserFrontDistanceMin2;
		public int GatherLaserFrontDistanceMin3;
		public int GatherLaserFrontDistanceMin4;
		public int GatherLaserFrontDistanceMin5;


		public int GatherLaserWidthMax1; 
		public int GatherLaserWidthMax2;
		public int GatherLaserWidthMax3;
		public int GatherLaserWidthMax4;
		public int GatherLaserWidthMax5;
		public int GatherLaserWidthMin1;
		public int GatherLaserWidthMin2;
		public int GatherLaserWidthMin3;
		public int GatherLaserWidthMin4;
		public int GatherLaserWidthMin5;


		public int GatherRadiusMax1;
		public int GatherRadiusMax2;
		public int GatherRadiusMax3;
		public int GatherRadiusMax4;
		public int GatherRadiusMax5;
		public int GatherRadiusMin1;
		public int GatherRadiusMin2;
		public int GatherRadiusMin3;
		public int GatherRadiusMin4;
		public int GatherRadiusMin5;


		public int RangeCastDepth;
		public int RangeCastHeight;

		/// <summary>
		/// 最大施展范围
		/// </summary>
		public int RangeCastMax;

		public int RangeCastMin;


		public int ShiftingLaserDepth;
		public int ShiftingLaserDistanceMax; 
		public int ShiftingLaserHeight;
		public int ShiftingLaserOffset;
		public int ShiftingLaserWidthMax;

		public int TargetZ1;
		public int TargetZ2;
		public int TargetZ3;
		public int TargetZ4;
		public int TargetZ5;
		#endregion



		#region 测试
		public int Radius => this.GatherRadiusMax1 * 8;

		public int Distance => this.RangeCastMax * 8;
		#endregion

	}

	public static partial class ItemExtension
	{
		public static int ToMetre(this int RadiusCM)
		{
			return (RadiusCM * 2) / 100;
		}
	}
}
