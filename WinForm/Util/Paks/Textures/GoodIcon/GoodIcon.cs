using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

using Xylia.bns.Util;
using Xylia.bns.Modules.DataFormat.BinData.Handle;
using Xylia.Preview.Data.Record;
using Xylia.bns.Modules.DataFormat.BinData;

namespace Xylia.Match.Util.Paks.Textures
{
	public sealed class GoodIcon : IconOutBase
	{
		#region 构造
		public GoodIcon(Action<string> action, string GameFolder = null) : base(action, GameFolder) 
		{
		
		}
		#endregion


		#region 方法
		internal override void AnalyseSourceData(ConcurrentDictionary<int, IconTexture> IconPath)
		{
			var NameKey = HandleData.BinHandle.Field.Result.NameKey_Convert;
			if (!NameKey.ContainsKey("goodsicon")) throw new Exception("无效的图标数据");


			//读取物品数据
			Parallel.ForEach(this.HandleData.BinHandle.ExtractData(NameKey["goodsicon"]), field =>
			{
				if (field is null || !field.HasData) return;

				try
				{
					int MainId = field.FID;
					int IconId = BitConverter.ToInt32(field.Field.Data, 4);
					short Idx = BitConverter.ToInt16(field.Field.Data, 4 + 8);


					this.QuoteInfos.Add(new QuoteInfo()
					{
						MainId = MainId,

						IconTextureId = IconId,	  
						IconIndex = Idx,
					});
				}
				catch (Exception ee)
				{
					Console.WriteLine(ee);
				}
			});
		}
		#endregion
	}
}
