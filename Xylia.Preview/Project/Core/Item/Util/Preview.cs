using Xylia.Preview.Common.Interface;
using Xylia.Preview.Data;

using ItemData = Xylia.Preview.Data.Record.Item;


namespace Xylia.Preview.Project.Core.Item.Util
{
	public static class Preview
	{
		/// <summary>
		/// 通过 IRecord 别名加载组件
		/// </summary>
		/// <typeparam name="TPreview"></typeparam>
		/// <typeparam name="TRecord"></typeparam>
		/// <param name="AttrName"></param>
		/// <param name="FileInfo"></param>
		/// <param name="Preview">用于传递 Preview 组件参数</param>
		/// <param name="ItemInfo"></param>
		public static TPreview LoadInfo<TPreview, TRecord>(this TPreview Preview, string AttrName, DataTable<TRecord> FileInfo, ItemData ItemInfo)
			where TPreview : PreviewControl, IPreview, new()
			where TRecord : IRecord, new()
		{
			if (ItemInfo?.Attributes is null || !ItemInfo.ContainsAttribute(AttrName, out string AttrVal) || AttrVal is null) return null;

			return LoadInfo(Preview, FileInfo[AttrVal]);
		}

		/// <summary>
		/// 通过 IRecord 对象加载组件
		/// </summary>
		/// <typeparam name="TPreview"></typeparam>
		/// <typeparam name="TRecord"></typeparam>
		/// <param name="Preview"></param>
		/// <param name="Record"></param>
		/// <returns></returns>
		public static TPreview LoadInfo<TPreview, TRecord>(this TPreview Preview, TRecord Record)
			where TPreview : PreviewControl, IPreview, new()
			where TRecord : IRecord, new()
		{
			if (Record is null) return null;

			//System.Diagnostics.Debug.WriteLine($"[{ Record.GetType() }] { Record.Alias }");

			//传递额外信息 (注意要在LoadData方法之前)
			Preview.LoadData(Record);

			//判断是否有效
			return Preview.INVALID() ? null : Preview;  
		}
	}
}