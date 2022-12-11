using System.Linq;

using Xylia.Attribute.Component;
using Xylia.Extension;
using Xylia.Files.XmlEx;
using Xylia.Preview.Common.Interface;  

namespace Xylia.Preview.Data.Record
{
	public sealed class PartyBattleFieldZone : IRecord, IName
	{
		#region 属性字段
		public string Group;

		[Signal("zone-name2")]
		public string ZoneName2;

		[Signal("zone-desc")]
		public string ZoneDesc;

		[Signal("arena-minimap")]
		public string ArenaMinimap;
		#endregion


		#region 接口方法
		public string NameText() => this.ZoneName2.GetText();
		#endregion
	}
}
