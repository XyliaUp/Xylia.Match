using System.Linq;

using Xylia.Attribute.Component;
using Xylia.Extension;
using Xylia.Files.XmlEx;
using Xylia.Preview.Common.Interface;  

namespace Xylia.Preview.Data.Record
{
	public sealed class Duel : IRecord, IName
	{
		#region 属性字段
		[Signal("duel-name2")]
		public string DuelName2;

		[Signal("duel-desc")]
		public string DuelDesc;

		[Signal("reward-summary")]
		public string RewardSummary;
		#endregion

		#region 接口方法
		public string NameText() => this.DuelName2.GetText();
		#endregion
	}
}
