using System;

using Xylia.Extension;
using Xylia.Preview.Data.Record;

using GameSeq = Xylia.bns.Modules.GameData.Enums;

namespace Xylia.Preview.Common.Cast
{
	public static class Cast
	{
		public static T CastSeq<T>(this string SeqValue) where T : Enum => SeqValue.ToEnum<T>();

		/// <summary>
		/// 转换为枚举
		/// </summary>
		/// <param name="SeqValue"></param>
		/// <param name="SeqName"></param>
		/// <returns></returns>
		/// <exception cref="Exception"></exception>
		public static object CastSeq(this string SeqValue, string SeqName)
		{
			if (!SeqName.TryParseToEnum<SeqType>(out var SeqType)) return null;

			else if (SeqType == SeqType.KeyCap) return CastSeq<KeyCode>(SeqValue);
			else if (SeqType == SeqType.KeyCommand) return CastSeq<GameSeq.KeyCommand>(SeqValue);

			throw new Exception("未支持的枚举类型");
		}
	}
}
