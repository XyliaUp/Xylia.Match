using Xylia.Preview.Project.Common.Interface;
using Xylia.Extension;


namespace Xylia.Preview.Project.Common.Attribute.ArgTest
{
	public class Integer : IArgParam
	{
		public int Value { get; set; } = 500;

		public string FloatDot0 => $"#{Value} FloatDot0";

		public string FloatDot1 => $"#{Value} FloatDot1";

		public string FloatDot2 => $"#{Value} FloatDot2";

		public string Dategmtime24 => $"#{Value} dategmtime24";

		public string Money => $"#{Value} Money";

		public string MoneyDefault => $"#{Value} MoneyDefault";

		public string MoneyNonTooltip => $"#{Value} MoneyNonTooltip";

		public string Time => $"#{Value}Time 时间";

		public string Timedate => $"#{Value}Timedhm 时间";

		public string Timedhm => $"#{Value}Timedhm 时间";

		public string Timehm => $"#{Value}Timehm 时间";

		public string Timeymd => $"#{Value}Timeymd 时间";

		public string TimeRoundDown => $"#{Value}TimeRoundDown 倒数时间";


		#region 接口字段
		object IArgParam.ParamTarget(string ParamName) => this.GetMemberVal(ParamName, true);
		#endregion
	}
}
