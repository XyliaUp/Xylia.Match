﻿using Xylia.Extension;

namespace Xylia.Preview.Third
{
	/// <summary>
	/// 转换类库
	/// </summary>
	public static class BnSConvert
	{
		/// <summary>
		/// 获取职业信息 (简易方法)
		/// </summary>
		/// <param Alias="Alias"></param>
		/// <returns></returns>
		public static string GetJob(this string Alias)
		{
			if (string.IsNullOrEmpty(Alias)) return null;


			#region 根据包含名称判断
			if (Alias.MyContains("RynSword") || Alias.Contains("SW")) return "灵剑";
			else if (Alias.MyContains("GreatSword") || Alias.Contains("WA")) return "斗士";
			else if (Alias.MyContains("SoulGauntlet") || Alias.Contains("SF")) return "气宗";
			else if (Alias.MyContains("WarDagger") || Alias.Contains("WL")) return "咒术";
			else if (Alias.MyContains("_sw_") || Alias.MyContains("Sword") || Alias.Contains("BM_")) return "剑士";
			else if (Alias.MyContains("_gt_") || Alias.MyContains("Gauntlet") || Alias.Contains("KF")) return "拳师";
			else if (Alias.MyContains("_st_") || Alias.MyContains("Staff") || Alias.Contains("SU")) return "召唤";
			else if (Alias.MyContains("_ab_") || Alias.MyContains("Aura-bangle") || Alias.Contains("FM")) return "气功";
			else if (Alias.MyContains("_ta_") || Alias.MyContains("Axe") || Alias.Contains("DE")) return "力士";
			else if (Alias.MyContains("_dg_") || Alias.MyContains("Dagger") || Alias.Contains("AS")) return "刺客";
			else if (Alias.MyContains("Gun_") || Alias.Contains("PT")) return "枪手";
			else if (Alias.MyContains("LongBow") || Alias.Contains("AR")) return "弓手";
			else if (Alias.MyContains("Orb")) return "星术师";
			else if (Alias.MyContains("DualBlade")) return "双剑";
			else if (Alias.MyContains("Harp")) return "乐师";
			else if (Alias.MyContains("Spear")) return "矛手";
			#endregion

			return null;
		}

		public static string GetEquipGem(this string Alias)
		{
			if (Alias.MyContains("Gam1")) return " ☵1";
			else if (Alias.MyContains("Gan2")) return " ☳2";
			else if (Alias.MyContains("Gin3")) return " ☶3";
			else if (Alias.MyContains("Son4")) return " ☱4";
			else if (Alias.MyContains("Lee5")) return " ☲5";
			else if (Alias.MyContains("Gon6")) return " ☷6";
			else if (Alias.MyContains("Tae7")) return " ☴7";
			else if (Alias.MyContains("Gun8")) return " ☰8";
			else if (Alias.MyContains("EquipGem_None")) return " ☰8";

			return null;
		}
	}
}