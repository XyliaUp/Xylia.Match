using Xylia.Preview.Project.Common.Interface;

namespace Xylia.Preview.Data.Record
{
	public sealed class Text : IRecord
	{
		public string GetText() => this.Attributes["text"] ?? this.Attributes.ToString();
	}
}