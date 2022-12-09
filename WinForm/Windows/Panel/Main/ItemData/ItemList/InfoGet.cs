using System.Collections.Generic;
using System.Text.RegularExpressions;

using Xylia.bns.Modules.DataFormat.Bin;
using Xylia.Extension;
using Xylia.Match.Util.ItemList;
using Xylia.Preview.Third;


namespace Xylia.Match.Util
{
	/// <summary>
	/// 信息读取
	/// </summary>
	public static class InfoGet
	{
		public static Dictionary<string, string> Special = null;


		#region 加载方法
		/// <summary>
		/// 返回物品汉化名称
		/// </summary>
		/// <param name="Local"></param>
		/// <param name="ItemAlias"></param>
		/// <param name="ItemId"></param>
		/// <param name="Result"></param>
		/// <returns></returns>
		public static bool GetName2(this TextBinData Local, string ItemAlias, int ItemId, out string Result)
		{
			//模糊获取名称
			string NameText = Local.GetText("Item.Name2." + ItemAlias);

			#region 名称获取异常状态替换规则
			if (NameText is null)
			{
				if (Special is null) Special = Read.GetSpecial();

				if (Special.ContainsKey(ItemAlias)) NameText = Special[ItemAlias];
				else if (Special.ContainsKey(ItemId.ToString())) NameText = Special[ItemId.ToString()];
			}
			#endregion

			#region 返回结果
			Result = NameText + BnSConvert.GetEquipGem(ItemAlias);
			return NameText != null;
			#endregion
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


		public static string BNS_Cut(string Str)
		{
			if (Str.IsNull()) return null;

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
		#endregion
	}
}
