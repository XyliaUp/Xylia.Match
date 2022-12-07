using System;
using System.Collections.Generic;
using System.Diagnostics;

using Xylia.Extension;

namespace Xylia.Match.Properties.Set
{
	/// <summary>
	/// 公共配置接口
	/// </summary>
	public abstract class ISetInfo
	{
		/// <summary>
		/// 存储配置信息
		/// </summary>
		/// <param name="Val"></param>
		public static void SaveInfo(object Val)
		{
			if (Val != null) Xylia.Configure.Ini.WriteValue(GetSectionAndKey(), Val);
		}

		/// <summary>
		/// 加载配置信息
		/// </summary>
		/// <param name="IsDebug"></param>
		/// <returns></returns>
		public static string LoadInfo(bool IsDebug = false)
		{
			return Xylia.Configure.Ini.ReadValue(GetSectionAndKey(IsDebug));
		}

		public static int? LoadInfo_Int()
		{
			string Info = Xylia.Configure.Ini.ReadValue(GetSectionAndKey());

			if (!Info.IsNull() && int.TryParse(Info, out int r)) return r;
			else return null;
		}

		/// <summary>
		/// 获得模块名和键名
		/// </summary>
		/// <returns></returns>
		public static KeyValuePair<object, object> GetSectionAndKey(bool IsDebug = false)
		{
			if (IsDebug) Console.WriteLine(new StackTrace());

			string KeyName = new StackTrace().GetFrame(2).GetMethod().Name.RemovePrefixString("get_").RemovePrefixString("set_");
			string CurSection = "option", CurKey = KeyName;

			if (KeyName.Contains("_"))
			{
				var group = KeyName.Split('_');

				CurSection = group[0];
				CurKey = KeyName.RemovePrefixString(CurSection + "_");
			}

			return new KeyValuePair<object, object>(CurSection, CurKey);
		}
	}
}
