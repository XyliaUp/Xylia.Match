using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

using Xylia.Extension;
using Xylia.Preview.Data.Record;

namespace Xylia.Preview.Project.Core.Skill.Util
{
	public class TestFunc
	{
		//天启 - 原地 - 50米
		//StartTest("Summoner_G3_Bomb_Lv1");

		////超神 - 原地 - 50米
		//StartTest("Warlock_G1_Summoned_Active_SoulMask");

		////畏缩 - 30米 - 单一目标
		//StartTest("Summoner_G3_Crouch_Lv1");

		////狗尾草 - 50米 - 范围3米
		//StartTest("Summoner_G3_Foxtail_Alternative_Lv1");

		////下段斩 - 原地 - 半前方5米
		//StartTest("SwordMaster_G1_Sword_turning_strike");

		////破天剑轮 - 原地 - 正方形2x8
		//StartTest("SwordMaster_MasterSkill_G3_1");

		//StartTest("7500013");

		//SkillCompare("Summoner_G3_ThrowSoap_Lv1", "");





		/// <summary>
		/// 开始测试
		/// </summary>
		/// <param name="SkillAlias"></param>
		public void StartTest(string SkillAlias)
		{
			var Skill3 = FileCacheData.Data.Skill3.GetInfo(SkillAlias);
			var CastCondition = FileCacheData.Data.SkillCastCondition3.GetInfo(Skill3.CastCondition);


			Console.WriteLine();
			foreach (var a in CastCondition.Attributes)
			{
				Console.WriteLine(a.Key + "  =>  " + a.Value);
			}


			//Console.WriteLine(CastCondition.RequiredWeaponType + "   " + CastCondition.XElement);

			Console.WriteLine($"[{ Skill3.Alias }]     { Skill3.RecycleGroupDuration / 1000 }s    " + Skill3.GetSkillRange());
		}

		public void SkillCompare(string MainSkillAlias, string ComparedSkillAlias)
		{
			var MainSkill = FileCacheData.Data.Skill3.GetInfo(MainSkillAlias);
			var ComparedSkill = FileCacheData.Data.Skill3.GetInfo(ComparedSkillAlias);


			foreach (var MainSkillAttr in MainSkill.Attributes)
			{
				if (ComparedSkill.ContainsAttribute(MainSkillAttr.Key, out string AttrValue))
				{
					if (!MainSkillAttr.Value.ToString().MyEquals(AttrValue))
						Console.WriteLine($"属性差异：{  MainSkillAttr.Key } => { MainSkillAttr.Value } - { AttrValue }");

				}
				else Console.WriteLine($"属性缺失：{ MainSkillAttr.Key }   ({ MainSkillAttr.Value })");
			}


			foreach (var ComareSkillAttr in ComparedSkill.Attributes)
			{
				if (!MainSkill.ContainsAttribute(ComareSkillAttr.Key, out string AttrValue))
				{
					Console.WriteLine($"属性额外：{ ComareSkillAttr.Key }   ({ ComareSkillAttr.Value })");
				}
			}
		}
	}
}
