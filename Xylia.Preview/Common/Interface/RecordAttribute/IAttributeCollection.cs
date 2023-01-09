using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;

using Xylia.bns.Modules.DataFormat.Analyse.Output;

namespace Xylia.Preview.Common.Interface.RecordAttribute
{
	public interface IAttributeCollection : IEnumerable
	{
		/// <summary>
		/// 获取所有字段
		/// </summary>
		IEnumerable<object> Attributes { get; }

		void SetAttribute(string Name,string Value) => throw new NotImplementedException();



		string this[string param] { get; }

		bool ContainsName(string AttrName, out string AttrValue);

		new IEnumerator<KeyValuePair<string, string>> GetEnumerator()
		{
			foreach (var attribute in this.Attributes)
			{
				if (attribute is XAttribute Attr) yield return new KeyValuePair<string, string>(Attr.Name.LocalName, Attr.Value);
				else if (attribute is OutputCell output) yield return new KeyValuePair<string, string>(output.Alias, output.OutputVal);
			}

			//结束迭代
			yield break;
		}

		IEnumerator IEnumerable.GetEnumerator() => throw new NotImplementedException();
	}
}
