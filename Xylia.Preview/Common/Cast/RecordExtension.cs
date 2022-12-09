
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
		public static string GetName(this string ObjInfo) => ObjInfo.GetObject()?.GetName() ?? ObjInfo;

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



		/// <summary>
		/// 获得对象
		/// </summary>
		/// <param name="ObjInfo"></param>
		/// <returns></returns>
		public static IRecord GetObject(this object ObjInfo)
		{
			//初始化
			var InfoText = ObjInfo?.ToString();
			if (string.IsNullOrWhiteSpace(InfoText)) return default;


			if (InfoText.Contains(':'))
			{
				var Temp = InfoText.Split(':');

				DataType Type = Temp[0].ToEnum<DataType>();
				if (Type != DataType.None && !int.TryParse(Temp[0], out _))
					return GetObject(Temp[1], Type);
			}

			//返回无效值
			return default;
		}

		/// <summary>
		/// 获得信息
		/// </summary>
		/// <param name="dataKey"></param>
		/// <param name="DataType"></param>
		/// <returns></returns>
		public static IRecord GetObject(this object dataKey, DataType DataType)
		{
			//初始化
			if (dataKey is null) return default;
			var DataKey = dataKey.ToString();
			if (string.IsNullOrWhiteSpace(DataKey)) return default;

			//特别的处理方法
			if (DataType == DataType.Tooltip) return FileCache.Data.TextData.GetRecord(DataKey);


			IRecord obj = DataType switch
			{
				DataType.Cave2 => FileCache.Data.Cave2[DataKey],
				DataType.Cave => FileCache.Data.Cave[DataKey],
				DataType.ClassicFieldZone => FileCache.Data.ClassicFieldZone[DataKey],

				DataType.Duel => FileCache.Data.Duel[DataKey],
				DataType.Dungeon => FileCache.Data.Dungeon[DataKey],
				DataType.FieldZone => FileCache.Data.FieldZone[DataKey],

				DataType.Item => DataKey.GetItemInfo(),
				DataType.ItemBrand => FileCache.Data.ItemBrand[DataKey],
				DataType.Npc => FileCache.Data.Npc[DataKey],

				DataType.PartyBattleFieldZone => FileCache.Data.PartyBattleFieldZone[DataKey],
				DataType.PublicRaid => FileCache.Data.PublicRaid[DataKey],

				DataType.RaidDungeon => FileCache.Data.RaidDungeon[DataKey],
				DataType.Skill => FileCache.Data.Skill3[DataKey],
				DataType.WorldAccountCard => FileCache.Data.WorldAccountCard[DataKey],
				DataType.ZoneEnv2 => FileCache.Data.ZoneEnv2[DataKey],

				_ => ShowDebugInfo(DataType),
			};

			IRecord ShowDebugInfo(DataType DataType)
			{
				System.Diagnostics.Debug.WriteLine($"尚未支持读取: {DataType}");
				return null;
			}

			return obj;
		}
	}
}
