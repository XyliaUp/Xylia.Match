using System.Linq;

using Xylia.Attribute.Component;
using Xylia.Extension;
using Xylia.Files.XmlEx;
using Xylia.Preview.Common.Interface;  

namespace Xylia.Preview.Data.Record
{
	public sealed class TendencyField : IRecord , IName
	{
		#region 属性字段
		[Signal("tendency-field-name2")]
		public string TendencyFieldName2;

		[Signal("tendency-field-desc")]
		public string TendencyFieldDesc;

		[Signal("reward-summary")]
		public string RewardSummary;

		[Signal("ui-text-grade")]
		public byte UiTextGrade;
		#endregion


		#region 接口方法
		public string NameText() => this.TendencyFieldName2.GetText();
		#endregion
	}
}