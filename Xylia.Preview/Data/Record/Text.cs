using Xylia.Preview.Common.Interface.RecordAttribute;
using Xylia.Preview.Common.Interface;

namespace Xylia.Preview.Data.Record
{
	public sealed class Text : IRecord
	{
<<<<<<< HEAD
		public string GetText() => this.Attributes is XElementData ? this.Attributes.ToString() : (this.Attributes["text"] ?? "");
=======
		public string GetText() => this.Attributes["text"] ?? this.Attributes.ToString();
>>>>>>> 87a0768aaf48150c6d7df46e4e5bad42ef854068
	}
}