
using Xylia.Extension;

namespace Xylia.Preview.Common.Extension
{
	public static class Ability
	{
		/// <summary>
		/// 获取值文本
		/// </summary>
		/// <param name="Value"></param>
		/// <param name="AbiltyName"></param>
		/// <returns></returns>
		public static string ToString(this long Value, object AbiltyName) => AbiltyName != null && AbiltyName.ToString().MyEndsWith("percent") ?
			(Value / 10).ToString("0.0") + "%" :
			Value.ToString();
	}
}
