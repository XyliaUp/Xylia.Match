using System;
using System.Collections.Generic;
using System.Linq;

using Xylia.Attribute.Component;
using Xylia.Extension;
using Xylia.Preview.Common.Interface;

using static Xylia.Extension.String;

namespace Xylia.Preview.Data.Record
{
	public sealed class SkillModifyInfo : IRecord
	{
		#region 属性字段
		public Type type;

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


		public int? parent_skill3_id_1;
		public int? parent_skill3_id_2;
		public int? parent_skill3_id_3;
		public int? parent_skill3_id_4;
		#endregion

		#region 枚举
		private enum SignType
		{
			Common,
			Sp,
			Drain,
		}

		public enum Type
		{
			normal,
			skill,

			SkillSystematization,
		}
		#endregion


		#region 其他字段
		/// <summary>
		/// 所属组
		/// </summary>
		public SkillModifyInfoGroup OwnerGroup = null;
		#endregion

		#region 处理信息
		/// <summary>
		/// 描述中的技能部分
		/// </summary>
		private string SkillPart
		{
			get
			{
				if (this.type == Type.normal) return null;
				else
				{
					var skills = new List<int?>()
					{
						parent_skill3_id_1,
						parent_skill3_id_2,
						parent_skill3_id_3,
						parent_skill3_id_4,
					};

					string Result = null;
					foreach (var skill in skills.Where(a => a != null))
					{
						//获取技能文本
						var SearchResult = FileCache.Data.Skill3.Find(info => info.ID == skill.Value);
						if (SearchResult != null) Result += SearchResult.NameText() + "，";
					}

					if (Result.IsNull()) return null;
					return "<font name=\"00008130.UI.Vital_LightBlue\">" + Result.RemoveSuffixString("，") + "</font>";
				}
			}
		}


		/// <summary>
		/// 生成信息
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			//获取描述中的技能部分
			string Result = null, SkillPart = this.SkillPart;


			//冷却时间
			if (this.RecycleDurationModifyPercent != 0) Result += SkillPart + $" 冷却时间 { Sign((float)this.RecycleDurationModifyPercent / 10) }%\n";
			if (this.RecycleDurationModifyDiff != 0) Result += SkillPart + $" 冷却时间 { Sign((float)this.RecycleDurationModifyDiff / 1000) }秒\n";
	
			//伤害变更
			if (this.DamagePowerPercentModifyPercent != 0) Result += SkillPart + $" 伤害 { Sign((float)this.DamagePowerPercentModifyPercent / 10) }%\n";
			if (this.DamagePowerPercentModifyDiff != 0) Result += SkillPart + $" 伤害 { Sign(this.DamagePowerPercentModifyDiff) }\n";

			//内力回复
			if (this.SpConsumeModifyDiff1 != 0) Result += SkillPart + $" { Sign(this.SpConsumeModifyDiff1, SignType.Sp) }点内力\n";
			if (this.SpConsumeModifyDiff2 != 0) Result += SkillPart + $" { Sign(this.SpConsumeModifyDiff2, SignType.Sp) }点内力\n";

			//生命吸收
			if (this.HpDrainPercentModifyPercent != 0) Result += SkillPart + $" 生命吸收{ (float)this.HpDrainPercentModifyPercent / 10 }%\n";
			if (this.HpDrainPercentModifyDiff != 0) Result += SkillPart + $" 生命吸收{ this.HpDrainPercentModifyDiff }\n";

			//生命恢复
			if (this.HealPercentModifyPercent != 0) Result += SkillPart + $" 生命恢复{ (float)this.HealPercentModifyPercent / 10 }%\n";
			if (this.HealPercentModifyDiff != 0) Result += SkillPart + $" 生命恢复{ (int)this.HealPercentModifyDiff }\n";



			#region 返回结果
			if (string.IsNullOrWhiteSpace(Result)) return null;

			//获取对应的派系名称
			string StyleName = null;
			if (OwnerGroup != null)
			{
				var tmp = OwnerGroup.StyleName;
				if (tmp != null) StyleName = $"({ tmp }) ";
			}

			return StyleName + Result.RemoveSuffixString("\n");
			#endregion
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
		#endregion
	}
}
