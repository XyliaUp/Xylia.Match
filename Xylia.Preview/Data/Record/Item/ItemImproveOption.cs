using System.Collections.Generic;
using System.Linq;

using Xylia.Attribute.Component;
using Xylia.Extension;
using Xylia.Preview.Common.Enums;
using Xylia.Preview.Common.Interface;
using Xylia.Preview.Common.Extension;


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
			if (!string.IsNullOrWhiteSpace(this.EffectDescription)) return this.EffectDescription.GetText() + AdditionalText;

			//获取属性加成部分提示
			if (this.Ability != MainAbility.None) return this.Ability.GetDescription() + " " + AbilityEx.ToString(this.AbilityValue, this.Ability) + AdditionalText;


			//获取武功加成部分提示
			List<string> ResultInfo = new();
			//ResultInfo.AddItem(FileCacheData.Data.SkillModifyInfoGroup[this.SkillModifyInfoGroup1]?.ToString());
			//ResultInfo.AddItem(FileCacheData.Data.SkillModifyInfoGroup[this.SkillModifyInfoGroup2]?.ToString());
			//ResultInfo.AddItem(FileCacheData.Data.SkillModifyInfoGroup[this.SkillModifyInfoGroup3]?.ToString());
			//ResultInfo.AddItem(FileCacheData.Data.SkillModifyInfoGroup[this.SkillModifyInfoGroup4]?.ToString());
			//ResultInfo.AddItem(FileCacheData.Data.SkillModifyInfoGroup[this.SkillModifyInfoGroup5]?.ToString());
			ResultInfo.AddItem(FileCache.Data.SkillModifyInfoGroup[this.SkillModifyInfoGroup6]?.ToString());
			ResultInfo.AddItem(FileCache.Data.SkillModifyInfoGroup[this.SkillModifyInfoGroup7]?.ToString());
			ResultInfo.AddItem(FileCache.Data.SkillModifyInfoGroup[this.SkillModifyInfoGroup8]?.ToString());
			ResultInfo.AddItem(FileCache.Data.SkillModifyInfoGroup[this.SkillModifyInfoGroup9]?.ToString());
			ResultInfo.AddItem(FileCache.Data.SkillModifyInfoGroup[this.SkillModifyInfoGroup10]?.ToString());


			if (!ResultInfo.Any()) return null;
			return ResultInfo.Aggregate((sum, now) => sum + "<br/>" + now);
		}
		#endregion
	}
}
