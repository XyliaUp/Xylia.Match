using System.Drawing;

using Xylia.Attribute.Component;
using Xylia.Preview.Project.Common.Enums;
using Xylia.Preview.Project.Common.Interface;

using GameSeq = Xylia.bns.Modules.GameData.Enums;

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
		public GameSeq.KeyCommand ShortCutKey;

		[Signal("short-cut-key-classic")]
		public GameSeq.KeyCommand ShortCutKeyClassic;

		[Signal("short-cut-key-simple-context")]
		public GameSeq.KeyCommand ShortCutKeySimpleContext;



		[Signal("icon-texture")]
		public string IconTexture;

		[Signal("icon-index")]
		public short IconIndex;
		#endregion





		#region 结构字段
		/// <summary>
		/// 当前快捷键
		/// </summary>
		public GameSeq.KeyCommand CurrentShortCutKey => this.ShortCutKey;
		#endregion

		#region 接口方法
		public string NameText() => this.Name2.GetText();

		public Bitmap MainIcon() => this.IconTexture.GetIcon(this.IconIndex);
		#endregion
	}




	public static partial class ItemExtension
	{
		/// <summary>
		/// 获得技能目标范围
		/// </summary>
		/// <param name="Skill"></param>
		/// <returns></returns>
		public static string GetSkillRange(this Skill3 Skill)
		{
			//类型
			var GatherType = Skill.ExecGatherType1;

			//GatherRange控制范围信息，但是距离和范围形状由技能本身控制
			var GatherRange = FileCacheData.Data.SkillGatherRange3.GetInfo(Skill.GatherRange);


			//Console.WriteLine(GatherRange?.XElement);

			var CurFlowType = Skill.flowType switch
			{
				Skill3.FlowType.KeepMainslot => "原地",
				_ => GatherRange.RangeCastMax.ToMetre() + $"m ({ Skill.flowType })",
			};


			return CurFlowType + "   " + GatherType switch
			{
				GatherType.Target => $"单一目标",
				GatherType.Target360 => GatherRange.GatherRadiusMax1.ToMetre() + $"m 内圆形目标",
				GatherType.TargetFront180 => GatherRange.GatherRadiusMax1.ToMetre() + $"m 内半圆形前方目标",
				GatherType.TargetBack180 => GatherRange.GatherRadiusMax1.ToMetre() + $"m 内半圆形后方目标",
				GatherType.TargetFront90 => GatherRange.GatherRadiusMax1.ToMetre() + $"m 内1/4圆形前方目标",
				GatherType.TargetBack90 => GatherRange.GatherRadiusMax1.ToMetre() + $"m 内1/4圆形后方目标",

				_ => GatherRange.GatherRadiusMax1.ToMetre() + "m 内 " + GatherType,
			};
		}
	}
}
