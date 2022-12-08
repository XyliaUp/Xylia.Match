using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xylia.Preview.Common.Interface
{



	/// <summary>
	/// 变量参数 (p字段)
	/// </summary>
	public interface IArgParam
	{
		/// <summary>
		/// 获取参数名称对应的目标
		/// </summary>
		/// <param name="ParamName">参数名</param>
		/// <returns></returns>
		object ParamTarget(string ParamName);
	}
}
