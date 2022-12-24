using System.Collections.Generic;

using Xylia.Attribute.Component;
using Xylia.bns.Modules.GameData.Enums;
using Xylia.Preview.Common.Interface;

namespace Xylia.Preview.Data.Record
{
	public sealed class KeyCommand : IRecord
	{
		#region 属性字段
		[Signal("key-command")]
		public KeyCommandSeq keyCommand;

		[Signal("pc-job")]
		public JobSeq PcJob;



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
		/// <summary>
		/// 获取组合键
		/// </summary>
		/// <returns></returns>
		private KeyCap[] GetKeyCaps()
		{
			var result = new List<KeyCap>();

			#region 处理默认组合键
			if(this.DefaultKeycap != null)
			{
				//逗号分隔多个快捷键，实际未支持处理
				foreach (var o in this.DefaultKeycap.Split(','))
				{
					if (string.IsNullOrWhiteSpace(o) || o == "none") continue;

					if (o.StartsWith("^"))
					{
						result.Add(KeyCap.GetKeyCap(KeyCode.Control));
						result.Add(KeyCap.GetKeyCap(o[1..]));
					}
					else if (o.StartsWith("~"))
					{
						result.Add(KeyCap.GetKeyCap(KeyCode.Alt));
						result.Add(KeyCap.GetKeyCap(o[1..]));
					}
					else result.Add(KeyCap.GetKeyCap(o));
				}
			}
			#endregion

			return result.ToArray();
		}

		private KeyCap GetKey(int Index) => this.GetKeyCaps().Length >= Index + 1 ? this.GetKeyCaps()[Index] : null;
		public KeyCap Key1 => GetKey(0);
		public KeyCap Key2 => GetKey(1);
		#endregion
	}

	public static partial class Extension
	{
		public static KeyCommand GetKeyCommand(this KeyCommandSeq KeyCommand) => FileCache.Data.KeyCommand.Find(o => o.keyCommand == KeyCommand);

		public static string GetImage(this KeyCommand KeyCommand) => KeyCommand.Key1?.Image.GetText();
	}
}