using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xylia.Preview.Common.Enums
{
	/// <summary>
	/// 循环组
	/// </summary>
	public enum RecycleGroup
	{
		None,

		[Description("class")]
		Class,

		[Description("item-1")]
		Item1,

		[Description("item-2")]
		Item2,

		[Description("class-2")]
		Class2,

		[Description("db")]
		DB,

		[Description("gadget")]
		Gadget,
	}
}
