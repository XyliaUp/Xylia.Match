using System;
using System.Collections.Generic;
using System.Linq;

using Xylia.Attribute.Component;
using Xylia.Preview.Common.Interface;

namespace Xylia.Preview.Data.Record
{
	public sealed class SkillModifyInfo : IRecord
	{
		#region 属性字段
		public TypeSeq Type;
		public enum TypeSeq
		{
			Normal,
			Skill,
			SkillSystematization,
		}


		[Signal("recycle-duration-modify-percent")]
		public short RecycleDurationModifyPercent;

		[Signal("recycle-duration-modify-diff")]
		public int RecycleDurationModifyDiff;

		[Signal("sp-consume-modify-diff-1")]
		public short SpConsumeModifyDiff1;

		[Signal("sp-consume-modify-diff-2")]
		public short SpConsumeModifyDiff2;

		[Signal("damage-power-percent-modify-percent")]
		public int DamagePowerPercentModifyPercent;

		[Signal("damage-power-percent-modify-diff")]
		public int DamagePowerPercentModifyDiff;

		[Signal("hp-drain-percent-modify-percent")]
		public int HpDrainPercentModifyPercent;

		[Signal("hp-drain-percent-modify-diff")]
		public int HpDrainPercentModifyDiff;

		[Signal("heal-percent-modify-percent")]
		public int HealPercentModifyPercent;

		[Signal("heal-percent-modify-diff")]
		public int HealPercentModifyDiff;

		public string Description;



		[Signal("parent-skill3-id-1")]
		public int ParentSkill3Id1;

		[Signal("parent-skill3-id-2")]
		public int ParentSkill3Id2;

		[Signal("parent-skill3-id-3")]
		public int ParentSkill3Id3;

		[Signal("parent-skill3-id-4")]
		public int ParentSkill3Id4;

		public string Systematization;
		#endregion


		#region 处理信息
		/// <summary>
		/// 描述中的技能部分
		/// </summary>
		private string SkillPart
		{
			get
			{
				if (this.Type != TypeSeq.Skill) return null;


				var Skill = new List<int>() { ParentSkill3Id1, ParentSkill3Id2, ParentSkill3Id3, ParentSkill3Id4 }.Where(a => a != 0)
					.Select(skill => FileCache.Data.Skill3[skill, 1]?.NameText())
					.Aggregate((sum, now) => sum + "，" + now);

				if (string.IsNullOrEmpty(Skill)) return null;
				return $"<font name=\"00008130.UI.Vital_LightBlue\">{Skill}</font> ";
			}
		}

		/// <summary>
		/// 生成信息
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			#region 获取信息
			//冷却时间
			List<string> Text = new();
			if (this.RecycleDurationModifyPercent != 0) Text.Add($"冷却时间 { Sign((float)this.RecycleDurationModifyPercent / 10) }%");
			if (this.RecycleDurationModifyDiff != 0) Text.Add($"冷却时间 { Sign((float)this.RecycleDurationModifyDiff / 1000) }秒");

			//伤害变更
			if (this.DamagePowerPercentModifyPercent != 0) Text.Add($"伤害 { Sign((float)this.DamagePowerPercentModifyPercent / 10) }%");
			if (this.DamagePowerPercentModifyDiff != 0) Text.Add($"伤害 { Sign(this.DamagePowerPercentModifyDiff) }");

			//内力回复
			if (this.SpConsumeModifyDiff1 != 0) Text.Add($"{ Sign(this.SpConsumeModifyDiff1, SignType.Sp) }点内力");
			if (this.SpConsumeModifyDiff2 != 0) Text.Add($"{ Sign(this.SpConsumeModifyDiff2, SignType.Sp) }点内力");

			//生命吸收
			if (this.HpDrainPercentModifyPercent != 0) Text.Add($"生命吸收{ (float)this.HpDrainPercentModifyPercent / 10 }%");
			if (this.HpDrainPercentModifyDiff != 0) Text.Add($"生命吸收{ this.HpDrainPercentModifyDiff }");

			//生命恢复
			if (this.HealPercentModifyPercent != 0) Text.Add($"生命恢复{ (float)this.HealPercentModifyPercent / 10 }%");
			if (this.HealPercentModifyDiff != 0) Text.Add($"生命恢复{ (int)this.HealPercentModifyDiff }");


			if (!Text.Any()) return null;
			#endregion

			var SkillPart = this.SkillPart;
			return Text.Select(o => $"{SkillPart}<font name=\"00008130.Program.Fontset_ItemGrade_3\">{o}</font>").Aggregate((sum, now) => sum + "<br/>" + now);
		}

		/// <summary>
		/// 生成标记
		/// </summary>
		/// <param name="Val"></param>
		/// <param name="Type"></param>
		/// <returns></returns>
		private static string Sign(float? Val, SignType Type = SignType.Common)
		{
			if (Val is null) return null;

			//标志文本
			string SignTxt;
			switch (Type)
			{
				case SignType.Sp: SignTxt = Val > 0 ? "消耗" : "回复"; break;
				default: SignTxt = Val > 0 ? "增加" : "减少"; break;
			}

			return SignTxt + Math.Abs((float)Val);
		}

		private enum SignType
		{
			Common,
			Sp,
			Drain,
		}
		#endregion
	}
}
