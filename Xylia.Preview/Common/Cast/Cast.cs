using System;
using System.Reflection;

using Xylia.bns.Modules.GameData.Enums;
using Xylia.Extension;
using Xylia.Preview.Common.Interface;
using Xylia.Preview.Data.Record;

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
			else if (SeqType == SeqType.KeyCommand) return CastSeq<KeyCommandSeq>(SeqValue);

			throw new Exception("未支持的枚举类型");
		}




		/// <summary>
		/// 获得对象
		/// </summary>
		/// <param name="ObjInfo"></param>
		/// <returns></returns>
		public static IRecord CastObject(this string ObjInfo)
		{
			if (string.IsNullOrWhiteSpace(ObjInfo)) return default;

			if (ObjInfo.Contains(':'))
			{
				var Temp = ObjInfo.Split(':');
				return CastObject(Temp[1], Temp[0]);
			}



			System.Diagnostics.Debug.WriteLine("Cast失败: " + ObjInfo);

			//返回无效值
			return default;
		}

		/// <summary>
		/// 获得信息
		/// </summary>
		/// <param name="DataKey"></param>
		/// <param name="DataTableName"></param>
		/// <returns></returns>
		private static IRecord CastObject(this string DataKey, string DataTableName)
		{
			if (string.IsNullOrWhiteSpace(DataKey)) return default;

			//特别的处理方法
			if (DataTableName.MyEquals("Skill")) return FileCache.Data.Skill3[DataKey];
			if (DataTableName.MyEquals("Tooltip")) return FileCache.Data.TextData.GetRecord(DataKey);
			if (DataTableName.MyEquals("Item")) return DataKey.GetItemInfo();


			//通过反射获取数据
			var DataTable = FileCache.Data.GetMemberVal(DataTableName, true);
			if (DataTable != null)
			{
				var record = DataTable.GetType()
					.GetMethod("get_Item", BindingFlags.Instance | BindingFlags.Public, new Type[] { typeof(string) })?
					.Invoke(DataTable, DataKey);

				return record is null ? default : record as IRecord;
			}

			System.Diagnostics.Debug.WriteLine($"尚未支持读取: {DataTableName}: {DataKey}");
			return default;
		}
	}
}