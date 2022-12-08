using System.Linq;

using Xylia.Attribute.Component;
using Xylia.Extension;
using Xylia.Files.XmlEx;
using Xylia.Preview.Common.Interface;  

namespace Xylia.Preview.Data.Record
{
	public sealed class Cave2 : IRecord , IName
	{
		#region 属性字段
		[Signal("ui-text-grade")]
		public byte UiTextGrade;

		[Signal("cave2-name2")]
		public string Cave2Name2;

		[Signal("cave2-desc")]
		public string Cave2Desc;

		[Signal("arena-entrance-zone")]
		public string ArenaEntranceZone;

		[Signal("arena-minimap")]
		public string ArenaMinimap;

		[Signal("arena-disable-zone-phase")]
		public bool ArenaDisableZonePhase;

		[Signal("required-level")]
		public byte RequiredLevel;

		[Signal("required-mastery-level")]
		public byte RequiredMasteryLevel;

		[Signal("quest-for-ignoring-required-level")]
		public string QuestForIgnoringRequiredLevel;
		#endregion



		#region 接口字段
		public string NameText() => this.Cave2Name2.GetText();
		#endregion
	}
}
