using Xylia.Preview.Common.Interface;

namespace Xylia.Preview.Data.Record
{
	public sealed class Npc : IRecord, IName
	{
		public string Animset;


		public string Name2;
		public string Title2;

		#region 接口方法
		public string NameText() => this.Name2.GetText();
		#endregion
	}
}
