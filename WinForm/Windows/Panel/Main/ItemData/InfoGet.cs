using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Xml;

using Xylia.bns.Modules.DataFormat.Bin;
using Xylia.Extension;
using Xylia.Match.Properties.Resx;


namespace Xylia.Match.Util
{
	/// <summary>
	/// 信息读取
	/// </summary>
	public static class InfoGet
	{
		#region 加载方法
		/// <summary>
		/// 返回物品汉化名称
		/// </summary>
		/// <param name="Local"></param>
		/// <param name="ItemAlias"></param>
		/// <returns></returns>
		public static string GetName2(this TextBinData Local, string ItemAlias)
		{
			//模糊获取名称
			string NameText = Local.GetText("Item.Name2." + ItemAlias);

			//名称获取异常状态替换规则
			if (NameText is null)
			{
				if (Special != null && Special.ContainsKey(ItemAlias)) NameText = Special[ItemAlias];
			}
	
			//返回结果
			return NameText is null ? null : NameText + GetEquipGem(ItemAlias);
		}

		/// <summary>
		/// 返回物品描述信息
		/// </summary>
		/// <param name="Name">填入物品标识/内部名称</param>
		/// <returns></returns>
		public static string GetDesc(this TextBinData Local, string Name)
		{
			string Desc = null;

			Desc += Local.GetText("Item.Desc2." + Name);
			Desc += Local.GetText("Item.Desc5." + Name);

			return BNS_Cut(Desc);
		}

		/// <summary>
		/// 返回物品相关信息
		/// </summary>
		/// <param name="Name">填入物品标识/内部名称</param>
		/// <returns></returns>
		public static string GetInfo(this TextBinData Local, string Name)
		{
			string Info = null;

			Info += Local.GetText("Item.MainInfo." + Name);
			Info += Local.GetText("Item.IdentifySub." + Name);
			Info += Local.GetText("Item.IdentifyMain." + Name);

			return BNS_Cut(Info);
		}
		#endregion


		#region Special
		public static Dictionary<string, string> Special;

		/// <summary>
		/// 获取特殊文件
		/// </summary>
		/// <returns></returns>
		public static Dictionary<string, string> GetSpecial()
		{
			var dictionary = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

			var xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(Progrm.Game);

			foreach (XmlNode xmlNode in xmlDocument.SelectNodes("Game/General"))
			{
				string Alias = xmlNode.Attributes["Alias"]?.Value;
				string Text = xmlNode.Attributes["Name2"]?.Value;

				if (Text != null && Alias != null) dictionary[Alias] = Text;
			}

			return dictionary;
		}
		#endregion


		#region BnSConvert
		public static string BNS_Cut(string Str)
		{
			if (string.IsNullOrWhiteSpace(Str)) return null;

			#region 替换标识符部分
			Regex Replace_Tag1 = new(@"<image.*?\.", RegexOptions.IgnoreCase);
			Regex Replace_Tag2 = new("scalerate=.*?/>", RegexOptions.IgnoreCase);


			string Tag = Replace_Tag1.Replace(Replace_Tag2.Replace(Str, ""), "")
				.Replace("Tag_", "").Replace("Tooltip_", "")
				.Replace("GetWhere", "[兑换]").Replace("Warning", "[提醒]").Replace("Random", "[随机]").Replace("GuildProduction", "[门派制作]").Replace("Job_", "")
				.Replace("FildDrop", "[区域]").Replace("GrowthExp", "[成长经验]").Replace("NormalKey", "[钥匙]").Replace("Roulette", "[转盘]").Replace("process", "加工")
				.Replace("CampfireName", "龙柱").Replace("Portrait_Alert", "[提示]").Replace("Map_Unit_PartyCamp", "[队伍]").Replace("Production_", "[")
				.Replace("Growth", "[成长]").Replace("Party", "[副本]").Replace("PowerBook", "[百科]").Replace("RankStar", "[关心任务]")
				.Replace("SpecialKey", "[钥匙]").Replace("Epic_start", "[主线]").Replace("side_episode_start", "[外传]").Replace("GemDecompose", "[分解]")
				.Replace("Faction_start", "[势力任务]").Replace("Faction", "[势力]").Replace("Normal_start", "[支线任务]").Replace("Repeat_start", "[每日任务]")
				.Replace("DoGiBang", "陶瓷坊]").Replace("ChulMuBang", "铁匠坊]").Replace("YackJeSa", "药王院]").Replace("SungDunDang", "圣君堂]")
				.Replace("Daeeobang", "大鱼坊]").Replace("ManGumDang", "万金堂]").Replace("BulMockDang", "木作坊]").Replace("SukGongBang", "石工坊]")
				.Replace("PungNyeonHoe", "丰年会]")
				.Replace("SuRyeopDang", "百猎庄]").Replace("YackChoBang", "药草坊]").Replace("IlMiMun", "风味门]").Replace("CheGulDang", "冶金庄]")
				.Replace("CharInfo_", null)
				.Replace("HP", "（生命）").Replace("Defend", "（防御）").Replace("BossAttackPower", "（降魔攻击力）")
				.Replace('"'.ToString(), "");


			Regex replace1 = new Regex(@"<.*?>", RegexOptions.IgnoreCase);
			string New = replace1.Replace(Tag, "");
			#endregion

			//执行引号替换
			return New.Replace("&quot;", '"'.ToString().Replace('”', '"')).Replace("enablescale=true", "");
		}

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
		#endregion
	}
}