using Xylia.Preview.Project.Common.Interface;

namespace Xylia.Preview.Data.Record
{
	public sealed class Effect : IRecord , IName
	{
		#region 属性字段
		public string Name2;

		public string Name3;

		public string Description2;

		public string Description3;
		#endregion

		#region 接口字段
		public string NameText() => this.Name2.GetText();
		#endregion
	}
}
