using System.Collections.Generic;
using System.Linq;

using Xylia.Attribute.Component;
using Xylia.Extension;
using Xylia.Preview.Common.Enums;
using Xylia.Preview.Common.Interface;

namespace Xylia.Preview.Data.Record
{
	public sealed class ItemImproveOption : IRecord
	{
		#region 属性字段
		public byte Level;

		public MainAbility Ability;

		public int AbilityValue;

		public string Effect;

		[Signal("effect-description")]
		public string EffectDescription;


		public string SkillModifyInfoGroup1;
		public string SkillModifyInfoGroup2;
		public string SkillModifyInfoGroup3;
		public string SkillModifyInfoGroup4;
		public string SkillModifyInfoGroup5;
		public string SkillModifyInfoGroup6;
		public string SkillModifyInfoGroup7;
		public string SkillModifyInfoGroup8;
		public string SkillModifyInfoGroup9;
		public string SkillModifyInfoGroup10;

		public string Additional;

		[Signal("draw-option-icon")]
		public string DrawOptionIcon;
		#endregion




		#region 方法
		/// <summary>
		/// 获取显示文本
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			string AdditionalText = Additional.GetText();

			//获取效果类型部分提示
			if (!string.IsNullOrWhiteSpace(this.EffectDescription)) return AdditionalText + this.EffectDescription.GetText();

			//获取属性加成部分提示
			if (this.Ability != MainAbility.None) return AdditionalText + this.Ability.GetDescription() + " " + this.AbilityValue;


			List<string> ResultInfo = new();

			//获取武功加成部分提示
			//ResultInfo.Add(FileCacheData.Data.SkillModifyInfoGroup.GetInfo(this.SkillModifyInfoGroup1)?.CreateInfo());
			//ResultInfo.Add(FileCacheData.Data.SkillModifyInfoGroup.GetInfo(this.SkillModifyInfoGroup2)?.CreateInfo());
			//ResultInfo.Add(FileCacheData.Data.SkillModifyInfoGroup.GetInfo(this.SkillModifyInfoGroup3)?.CreateInfo());
			//ResultInfo.Add(FileCacheData.Data.SkillModifyInfoGroup.GetInfo(this.SkillModifyInfoGroup4)?.CreateInfo());
			//ResultInfo.Add(FileCacheData.Data.SkillModifyInfoGroup.GetInfo(this.SkillModifyInfoGroup5)?.CreateInfo());
			ResultInfo.Add(FileCache.Data.SkillModifyInfoGroup.GetInfo(this.SkillModifyInfoGroup6)?.CreateInfo());
			ResultInfo.Add(FileCache.Data.SkillModifyInfoGroup.GetInfo(this.SkillModifyInfoGroup7)?.CreateInfo());
			ResultInfo.Add(FileCache.Data.SkillModifyInfoGroup.GetInfo(this.SkillModifyInfoGroup8)?.CreateInfo());
			ResultInfo.Add(FileCache.Data.SkillModifyInfoGroup.GetInfo(this.SkillModifyInfoGroup9)?.CreateInfo());
			ResultInfo.Add(FileCache.Data.SkillModifyInfoGroup.GetInfo(this.SkillModifyInfoGroup10)?.CreateInfo());


			//去除空白文本与Html文本语言
			var tempList = ResultInfo.Where(a => !string.IsNullOrWhiteSpace(a));

			if (!tempList.Any()) return null;
			return tempList.Aggregate((sum, now) => sum + "<br/>" + now);
		}
		#endregion
	}
}
