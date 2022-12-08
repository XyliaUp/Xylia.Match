
using Xylia.Attribute.Component;
using Xylia.Preview.Common.Interface;

namespace Xylia.Preview.Data.Record
{
	/// <summary>
	/// 刻印书
	/// </summary>
	public sealed class Store2 : IRecord, IName
	{
		#region 属性字段
		public string Name2;

		public string Icon;

		[Signal("none-selected-icon")]
		public string NoneSelectedIcon;

		public string Faction;
		#endregion


		#region 接口方法
		public string NameText() => this.Name2.GetText();
		#endregion
	}
}
