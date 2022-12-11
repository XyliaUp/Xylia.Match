
using Xylia.Extension;
using Xylia.Preview.Common.Interface;
using Xylia.Preview.Data.Record;

namespace Xylia.Preview.Common.Cast
{
	/// <summary>
	/// 实例化扩展
	/// </summary>
	public static class RecordExtension
	{
		/// <summary>
		/// 获得对象名称
		/// </summary>
		/// <param name="ObjInfo"></param>
		/// <returns></returns>
		public static string GetName(this string ObjInfo) => ObjInfo.CastObject()?.GetName() ?? ObjInfo;

		/// <summary>
		/// 获得对象名称
		/// </summary>
		/// <param name="Obj"></param>
		/// <returns></returns>
		public static string GetName(this IRecord Obj)
		{
			if (Obj is null) return null;
			else if (Obj is IName IName) return IName.NameText();
			else return Obj.Alias;
		}
	}
}
