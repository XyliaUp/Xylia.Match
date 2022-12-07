using System.Linq;

using Xylia.Extension;
using Xylia.Files.XmlEx;
using Xylia.Preview.Project.Common.Interface;  

namespace Xylia.Preview.Data.Record
{
	public sealed class RaidDungeon : IRecord , IName
	{
		#region 属性字段
		public string Name2;

		public byte Grade;
		#endregion


		#region 接口方法
		public string NameText() => this.Name2.GetText();
		#endregion
	}
}
