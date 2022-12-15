
using Xylia.Attribute.Component;
using Xylia.Preview.Common.Interface;


namespace Xylia.Preview.Data.Record
{
	public sealed class FactionLevel : IRecord
	{
		#region 属性字段
		public short Level;

		public int Reputation;

		[Signal("grade-name-1")]
		public string GradeName1;

		[Signal("grade-name-2")]
		public string GradeName2;

		[Signal("max-faction-score")]
		public int MaxFactionScore;
		#endregion
	}
}
