using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Xylia.Preview.Common.Interface.RecordAttribute
{
	/// <summary>
	/// 对象属性集合
	/// </summary>
	public sealed class XElementData : IAttributeCollection
	{
		#region 构造
		private readonly XElement XElement;

		public XElementData(XElement XElement) => this.XElement = XElement;
		#endregion


		public IEnumerable<object> Attributes => XElement.Attributes();

		public string this[string param] => this.XElement.Attribute(param)?.Value;

		public bool ContainsName(string AttrName, out string AttrValue)
		{
			var result = XElement.Attribute(AttrName);

			AttrValue = result?.Value;
			return result is not null;
		}

		public override string ToString() => this.XElement.Value;
	}
}
