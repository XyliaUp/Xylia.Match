using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

using Xylia.bns.Modules.DataFormat.Bin;


namespace Xylia.Match.Util.Paks.Textures
{
	/// <summary>
	/// 物品图标
	/// </summary>
	public sealed class ItemIcon : IconOutBase
	{
		#region 实例属性
		/// <summary>
		/// 指示是否有背景
		/// </summary>
		public bool UseBackground = false;

		/// <summary>
		/// 指示白名单模式
		/// </summary>
		public bool isWhiteList = false;

		/// <summary>
		/// 缓存文件路径
		/// </summary>
		public string ChvPath = null;
		#endregion

		#region 方法
		public ItemIcon(Action<string> action, string GameFolder = null) : base(action, GameFolder) { }

		internal override void AnalyseSourceData()
		{
			#region 读取物品数据
			Action("正在分析物品数据...");

			var localization = new TextBinData(Path_Local);

			//设置并发线程数量
			var pOptions = new ParallelOptions()
			{
				//MaxDegreeOfParallelism = 6,
			};


			#region 读取外部文件	 
			HashSet<int> CacheList = new();
			if (!string.IsNullOrWhiteSpace(ChvPath) && File.Exists(ChvPath))  //校验
			{
				var rd = File.OpenText(ChvPath);

				string line;
				while ((line = rd.ReadLine()) != null)
				{
					if (int.TryParse(line.Replace("\"", ""), out int @int)) CacheList.Add(@int);
				}

				rd.Close();  // 关闭文件
			}
			#endregion

			//读取物品数据
			var ItemTable = this.GameData["item"];
			Parallel.ForEach(ItemTable.CellDatas(), pOptions, (field) =>
			{
				int MainId = field.FID;
				if (!isWhiteList || CacheList.Contains(MainId))
				{
					#region 获取数据
					var Data = field.Field.Data;

					int IconId = BitConverter.ToInt32(Data, LocDefine.IconId);
					short IconIdx = BitConverter.ToInt16(Data, LocDefine.IconId + 8);

					byte Grade = Data[LocDefine.Grade];
					string Name2 = localization.GetText(BitConverter.ToInt32(Data, LocDefine.Name2));

					//获取 GroceryType
					byte GroceryType = 0;
					if (field.FType.Value == 2) GroceryType = Data[LocDefine.GroceryType];
					#endregion


					this.QuoteInfos.Add(new ItemQuoteInfo()
					{
						MainId = MainId,
						Alias = field.Alias,
						Name = Name2,

						IconTextureId = IconId,
						IconIndex = IconIdx,

						Grade = Grade,
						GroceryType = GroceryType,
						NoBG = !this.UseBackground,
					});
				}
			});
			#endregion

			localization = null;
		}
		#endregion
	}
}
