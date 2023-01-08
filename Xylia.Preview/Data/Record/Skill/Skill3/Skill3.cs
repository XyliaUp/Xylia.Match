using System.Drawing;

using Xylia.Attribute.Component;
using Xylia.bns.Modules.GameData.Enums;
using Xylia.Preview.Common.Interface;

namespace Xylia.Preview.Data.Record
{
	public sealed partial class Skill3 : IRecord, IName, IPicture
	{
		#region 数据字段
		[Signal("variation-id")]
		public byte VariationId = 1;


		[Signal("revised-effect-equip-probability-in-exec-1")] public short RevisedEffectEquipProbabilityInExec1;
		[Signal("revised-effect-equip-probability-in-exec-2")] public short RevisedEffectEquipProbabilityInExec2;
		[Signal("revised-effect-equip-probability-in-exec-3")] public short RevisedEffectEquipProbabilityInExec3;
		[Signal("revised-effect-equip-probability-in-exec-4")] public short RevisedEffectEquipProbabilityInExec4;
		[Signal("revised-effect-equip-probability-in-exec-5")] public short RevisedEffectEquipProbabilityInExec5;


		[Signal("damage-rate-pvp")]
		public short DamageRatePvp = 1000;

		[Signal("damage-rate-standard-stats")]
		public short DamageRateStandardStats = 1000;


		public string Name;

		public string Name2;

		[Signal("short-cut-key")]
		public KeyCommandSeq ShortCutKey;

		[Signal("short-cut-key-classic")]
		public KeyCommandSeq ShortCutKeyClassic;

		[Signal("short-cut-key-simple-context")]
		public KeyCommandSeq ShortCutKeySimpleContext;



		[Signal("icon-texture")]
		public string IconTexture;

		[Signal("icon-index")]
		public short IconIndex;
		#endregion

		#region 结构字段
		/// <summary>
		/// 当前快捷键
		/// </summary>
		public KeyCommand CurrentShortCutKey => this.ShortCutKey.GetKeyCommand();
		#endregion


		#region 接口方法
		public string NameText() => this.Name2.GetText();

		public Bitmap MainIcon() => this.IconTexture.GetIcon(this.IconIndex);
		#endregion
	}
}