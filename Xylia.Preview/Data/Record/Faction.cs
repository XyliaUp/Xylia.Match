using System.ComponentModel;
using System.Drawing;

using Xylia.Preview.Common.Interface;


namespace Xylia.Preview.Data.Record
{
	public sealed class Faction : IRecord, IName  ,IPicture
	{
		#region 属性字段
		public string Name2;

		[Description("tag-name")]
		public string TagName;

		public string Icon;

		public string Text;
		#endregion


		#region 接口字段
		public string NameText() => this.Name2.GetText();

		public Bitmap MainIcon() => this.Icon.GetIcon();
		#endregion
	}
}