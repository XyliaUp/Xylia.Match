using System.Collections.Generic;

using Xylia.Attribute.Component;
using Xylia.Extension;
using Xylia.Preview.Common.Interface;

using GameSeq = Xylia.bns.Modules.GameData.Enums;

namespace Xylia.Preview.Data.Record
{
	//KeyCommond >> KEYCAP 组合 >> 按键图片
	public sealed class KeyCommand : IRecord
	{
		#region 属性字段
		[Signal("key-command")]
		public GameSeq.KeyCommand keyCommand;

		[Signal("pc-job")]
		public GameSeq.Job PcJob;



		//public Seq Category;

		//[Signal("joypad-category")]
		//public Seq JoypadCategory;

		public string Name;

		[Signal("default-keycap")]
		public string DefaultKeycap;

		[Signal("modifier-enabled")]
		public bool ModifierEnabled;

		[Signal("sort-no")]
		public byte SortNo;

		public byte Layer;

		[Signal("option-sort-no")]
		public short OptionSortNo;

		//[Signal("usable-joypad-mode")]
		//public Seq UsableJoypadMode;

		[Signal("joypad-customize-enabled")]
		public bool JoypadCustomizeEnabled;
		#endregion



		#region 方法
		private KeyCap GetKeyCap(KeyCode KeyCode) => FileCache.Data.KeyCap.Find(o => o.KeyCode == KeyCode);

		/// <summary>
		/// 获取组合键
		/// </summary>
		/// <returns></returns>
		private KeyCap[] GetKeyCaps()
		{
			var result = new List<KeyCap>();

			#region 处理默认组合键
			//逗号分隔多个快捷键，实际未支持处理
			foreach (var o in this.DefaultKeycap.Split(','))
			{
				if (string.IsNullOrWhiteSpace(o) || o == "none") continue;

				if (o.StartsWith("^"))
				{
					result.Add(GetKeyCap(KeyCode.Control));
					result.Add(GetKeyCap(o[1..].ToEnum<KeyCode>()));
				}
				else if (o.StartsWith("~"))
				{
					result.Add(GetKeyCap(KeyCode.Alt));
					result.Add(GetKeyCap(o[1..].ToEnum<KeyCode>()));
				}
				else result.Add(GetKeyCap(o.ToEnum<KeyCode>()));
			}
			#endregion

			return result.ToArray();
		}


		public KeyCap Key1 => this.GetKeyCaps()[0];
		#endregion
	}
}
