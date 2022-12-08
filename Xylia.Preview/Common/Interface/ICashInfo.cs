using System.Collections.Generic;
using System.Collections.Concurrent;
using System;
using Xylia.Extension;


namespace Xylia.Preview.Common.Interface
{
	/// <summary>
	/// 数据缓存器构造
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class ICacheInfo<T>
	{
		#region 构造
		/// <summary>
		/// 构造
		/// </summary>
		/// <param name="IgnoreCase">字段忽略大小写</param>
		public ICacheInfo(bool IgnoreCase = true)
		{
			if(IgnoreCase) this.Cache = new ConcurrentDictionary<string, T>(StringComparer.OrdinalIgnoreCase);
			else this.Cache = new ConcurrentDictionary<string, T>();
		}
		#endregion

		#region 字段
		/// <summary>
		/// 缓存字典
		/// </summary>
		private readonly ConcurrentDictionary<string, T> Cache;
		#endregion

		#region 获得元素
		public T GetVal(string Alias)
		{
			if (!Alias.IsNull() && Cache.ContainsKey(Alias)) return Cache[Alias];
			return default;
		}

		public T this[string Alias] => GetVal(Alias);
		#endregion


		/// <summary>
		/// 增加缓存数据
		/// </summary>
		/// <param name="Key"></param>
		/// <param name="Val"></param>
		public void Add(string Key, T Val)
		{
			if (Key.IsNull()) return;
			if (!this.Cache.ContainsKey(Key)) this.Cache.GetOrAdd(Key, Val);
		}

		/// <summary>
		/// 是否包含元素
		/// </summary>
		/// <param name="Key"></param>
		/// <returns></returns>
		public bool Contains(string Key)
		{
			if (!Key.IsNull()) return this.Cache.ContainsKey(Key);

			return false;
		}

		/// <summary>
		/// 清除缓存
		/// </summary>
		public void Clear()
		{
			this.Cache.Clear();
		}
	}
}
