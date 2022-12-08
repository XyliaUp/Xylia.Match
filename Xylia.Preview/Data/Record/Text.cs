using Xylia.Preview.Common.Interface.RecordAttribute;
using Xylia.Preview.Common.Interface;

namespace Xylia.Preview.Data.Record
{
	public sealed class Text : IRecord
	{
		public string GetText() => this.Attributes is XElementData ? this.Attributes.ToString() : (this.Attributes["text"] ?? "");
	}
}