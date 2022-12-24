using Xylia.Preview.Common.Interface;


namespace Xylia.Preview.Data.Record
{
	public sealed class SetItem : IRecord ,IName
	{
		#region 字段
		public string Name2;
		#endregion

		#region 接口字段
		public string NameText() => this.Name2.GetText();
		#endregion
	}
}