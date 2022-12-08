using System.Collections;
using System.Collections.Generic;

using Xylia.Extension;
using Xylia.Preview.Data;
using Xylia.Preview.Common.Interface;

using static Xylia.Extension.String;

using ItemData = Xylia.Preview.Data.Record.Item;


namespace Xylia.Preview.Project.Core.Item.Util
{
	public static class Preview
	{
		public static void MyAddRange(this IList source, IEnumerable<object> collection)
		{
			if (collection is null) return;

			foreach (var o in collection) source.Add(o);
		}




		/// <summary>
		/// 通过 IRecord 别名加载组件
		/// </summary>
		/// <typeparam name="TPreview"></typeparam>
		/// <typeparam name="T1"></typeparam>
		/// <param name="AttrName"></param>
		/// <param name="FileInfo"></param>
		/// <param name="Preview">用于传递 Preview 组件参数</param>
		/// <param name="ItemInfo"></param>
		public static TPreview LoadInfo<TPreview, T1>(this TPreview Preview, string AttrName, DataTable<T1> FileInfo, ItemData ItemInfo = null)
			where T1 : IRecord, new()
			where TPreview : PreviewControl, IPreview, new()
		{
			if (ItemInfo?.Attributes is null || !ItemInfo.ContainsAttribute(AttrName, out string AttrVal) || AttrVal.IsNull()) return null;

			//类型校验
			if (FileInfo.GetType().HasImplementedRawGeneric(typeof(DataTable<>))) 
				return LoadInfo(Preview, FileInfo[AttrVal], ItemInfo);

			return null;
		}

		/// <summary>
		/// 通过 IRecord 对象加载组件
		/// </summary>
		/// <typeparam name="TPreview"></typeparam>
		/// <typeparam name="T1"></typeparam>
		/// <param name="Preview"></param>
		/// <param name="Record"></param>
		/// <param name="ItemInfo"></param>
		/// <returns></returns>
		public static TPreview LoadInfo<TPreview, T1>(this TPreview Preview, T1 Record = default, ItemData ItemInfo = null)
			where T1 : IRecord, new()
			where TPreview : PreviewControl, IPreview, new()
		{
			if (Record != null && !Record.INVALID)
			{
				System.Diagnostics.Debug.WriteLine($"[{ Record.GetType() }] { Record.Alias }   对象有效性: { !Record?.INVALID }");

				//传递额外信息 (注意要在LoadData方法之前)
				Preview.LoadData(Record);

				return Preview.INVALID() ? null : Preview;  //判断是否有效
			}

			return null;
		}


		public static TPreview LoadInfo<TPreview>(this TPreview Preview, ItemData ItemInfo) where TPreview : PreviewControl, IPreview, new()
		{
			Preview.LoadData(ItemInfo);
			if (Preview.INVALID()) return null;  //判断是否有效

			return Preview;
		}
	}
}
