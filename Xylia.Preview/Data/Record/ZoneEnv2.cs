using System.ComponentModel;

using Xylia.Preview.Common.Interface;


namespace Xylia.Preview.Data.Record
{
	public sealed class ZoneEnv2 : IRecord, IName
	{
		#region 字段
		public string Name2;

		[Description("action-name2")]
		public string ActionName2;

		[Description("action-desc2")]
		public string ActionDesc2;
		#endregion


		#region 接口方法
		public string NameText() => Name2.GetText();
		#endregion
	}
}