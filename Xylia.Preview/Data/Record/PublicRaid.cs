
using Xylia.Attribute.Component;
using Xylia.Preview.Common.Interface;

namespace Xylia.Preview.Data.Record
{
	public sealed class PublicRaid : IRecord , IName
	{
		#region 属性字段
		[Signal("publicraid-name2")]
		public string PublicraidName2;

		[Signal("publicraid-desc")]
		public string PublicraidDesc;

		[Signal("reward-summary")]
		public string RewardSummary;

		[Signal("publicraid-icon")]
		public string PublicraidIcon;

		[Signal("publicraid-image")]
		public string PublicraidImage;
		#endregion

		#region 接口方法
		public string NameText() => this.PublicraidName2.GetText();
		#endregion
	}
}