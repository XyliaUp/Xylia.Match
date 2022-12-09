using System.Collections.Generic;
using System.Linq;

using NPOI.SS.Formula.Functions;

using Xylia.bns.Modules.DataFormat.Analyse.Output;

namespace Xylia.Preview.Common.Interface.RecordAttribute
{
	/// <summary>
	/// 对象属性集合
	/// </summary>
	public sealed class OutputData : IAttributeCollection
	{
		#region 构造
		public readonly ObjectOutput Object;

		public OutputData(ObjectOutput output) => this.Object = output;
		#endregion



		OutputCellCollection OutputCells => this.Object.Cells;

		public IEnumerable<object> Attributes => this.OutputCells;

		public string this[string param] => this.OutputCells[param]?.OutputVal;

		public bool ContainsName(string AttrName, out string AttrValue)
		{
			var result = this.OutputCells[AttrName];

			AttrValue = result?.OutputVal;
			return result is not null;
		}

		public override string ToString() => this.OutputCells.Aggregate("<record ", (sum, now) => sum + $"{now.Alias}=\"{now.OutputVal}\" ", result => result + "/>");
	}
}
