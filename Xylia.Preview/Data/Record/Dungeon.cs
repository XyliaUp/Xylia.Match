using System.Linq;

using Xylia.Extension;
using Xylia.Files.XmlEx;
using Xylia.Preview.Common.Interface;  

namespace Xylia.Preview.Data.Record
{
	public sealed class Dungeon : IRecord , IName
	{
		#region 属性字段
		public string DungeonName2;
		public byte Grade;

		public string DisplayQuests1;
		#endregion



		#region 接口字段
		public string NameText() => this.DungeonName2.GetText();
		#endregion
	}
}
