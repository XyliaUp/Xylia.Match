using System.Collections.Generic;

using Xylia.Attribute.Component;
using Xylia.bns.Modules.GameData.Enums;
using Xylia.Extension;
using Xylia.Preview.Common.Interface;

namespace Xylia.Preview.Data.Record
{
	public sealed class ItemCombat : IRecord
	{
		#region 属性字段
		[Signal("job-style")]
		public JobStyleSeq JobStyle;


		[Signal("item-skill-1")]
		public string ItemSkill1;

		[Signal("item-skill-2")]
		public string ItemSkill2;

		[Signal("item-skill-3")]
		public string ItemSkill3;

		[Signal("item-skill-4")]
		public string ItemSkill4;

		[Signal("item-skill-5")]
		public string ItemSkill5;

		[Signal("item-skill-6")]
		public string ItemSkill6;

		[Signal("item-skill-7")]
		public string ItemSkill7;

		[Signal("item-skill-8")]
		public string ItemSkill8;

		[Signal("item-skill-9")]
		public string ItemSkill9;

		[Signal("item-skill-10")]
		public string ItemSkill10;

		[Signal("item-skill-11")]
		public string ItemSkill11;

		[Signal("item-skill-12")]
		public string ItemSkill12;

		[Signal("item-skill-13")]
		public string ItemSkill13;

		[Signal("item-skill-14")]
		public string ItemSkill14;

		[Signal("item-skill-15")]
		public string ItemSkill15;

		[Signal("item-skill-16")]
		public string ItemSkill16;



		[Signal("item-skill-second-1")]
		public string ItemSkillSecond1;

		[Signal("item-skill-second-2")]
		public string ItemSkillSecond2;

		[Signal("item-skill-second-3")]
		public string ItemSkillSecond3;

		[Signal("item-skill-second-4")]
		public string ItemSkillSecond4;

		[Signal("item-skill-second-5")]
		public string ItemSkillSecond5;

		[Signal("item-skill-second-6")]
		public string ItemSkillSecond6;

		[Signal("item-skill-second-7")]
		public string ItemSkillSecond7;

		[Signal("item-skill-second-8")]
		public string ItemSkillSecond8;

		[Signal("item-skill-second-9")]
		public string ItemSkillSecond9;

		[Signal("item-skill-second-10")]
		public string ItemSkillSecond10;

		[Signal("item-skill-second-11")]
		public string ItemSkillSecond11;

		[Signal("item-skill-second-12")]
		public string ItemSkillSecond12;

		[Signal("item-skill-second-13")]
		public string ItemSkillSecond13;

		[Signal("item-skill-second-14")]
		public string ItemSkillSecond14;

		[Signal("item-skill-second-15")]
		public string ItemSkillSecond15;

		[Signal("item-skill-second-16")]
		public string ItemSkillSecond16;


		[Signal("item-skill-third-1")]
		public string ItemSkillThird1;

		[Signal("item-skill-third-2")]
		public string ItemSkillThird2;

		[Signal("item-skill-third-3")]
		public string ItemSkillThird3;

		[Signal("item-skill-third-4")]
		public string ItemSkillThird4;

		[Signal("item-skill-third-5")]
		public string ItemSkillThird5;

		[Signal("item-skill-third-6")]
		public string ItemSkillThird6;

		[Signal("item-skill-third-7")]
		public string ItemSkillThird7;

		[Signal("item-skill-third-8")]
		public string ItemSkillThird8;

		[Signal("item-skill-third-9")]
		public string ItemSkillThird9;

		[Signal("item-skill-third-10")]
		public string ItemSkillThird10;

		[Signal("item-skill-third-11")]
		public string ItemSkillThird11;

		[Signal("item-skill-third-12")]
		public string ItemSkillThird12;

		[Signal("item-skill-third-13")]
		public string ItemSkillThird13;

		[Signal("item-skill-third-14")]
		public string ItemSkillThird14;

		[Signal("item-skill-third-15")]
		public string ItemSkillThird15;

		[Signal("item-skill-third-16")]
		public string ItemSkillThird16;



		[Signal("skill-build-up-parent-skill3-id-1")]
		public int SkillBuildUpParentSkill3Id1;

		[Signal("skill-build-up-parent-skill3-id-2")]
		public int SkillBuildUpParentSkill3Id2;

		[Signal("skill-build-up-parent-skill3-id-3")]
		public int SkillBuildUpParentSkill3Id3;

		[Signal("skill-build-up-level-1")]
		public byte SkillBuildUpLevel1;

		[Signal("skill-build-up-level-2")]
		public byte SkillBuildUpLevel2;

		[Signal("skill-build-up-level-3")]
		public byte SkillBuildUpLevel3;

		[Signal("skill-modify-info-group")]
		public string SkillModifyInfoGroup;
		#endregion


		#region 方法
		public List<ItemSkill> ItemSkills
		{
			get
			{
				var result = new List<ItemSkill>();
				// **********************************************
				result.AddItem(FileCache.Data.ItemSkill[this.ItemSkill1]);
				result.AddItem(FileCache.Data.ItemSkill[this.ItemSkill2]);
				result.AddItem(FileCache.Data.ItemSkill[this.ItemSkill3]);
				result.AddItem(FileCache.Data.ItemSkill[this.ItemSkill4]);
				result.AddItem(FileCache.Data.ItemSkill[this.ItemSkill5]);
				result.AddItem(FileCache.Data.ItemSkill[this.ItemSkill6]);
				result.AddItem(FileCache.Data.ItemSkill[this.ItemSkill7]);
				result.AddItem(FileCache.Data.ItemSkill[this.ItemSkill8]);
				result.AddItem(FileCache.Data.ItemSkill[this.ItemSkill9]);
				result.AddItem(FileCache.Data.ItemSkill[this.ItemSkill10]);
				result.AddItem(FileCache.Data.ItemSkill[this.ItemSkill11]);
				result.AddItem(FileCache.Data.ItemSkill[this.ItemSkill12]);
				result.AddItem(FileCache.Data.ItemSkill[this.ItemSkill13]);
				result.AddItem(FileCache.Data.ItemSkill[this.ItemSkill14]);
				result.AddItem(FileCache.Data.ItemSkill[this.ItemSkill15]);
				result.AddItem(FileCache.Data.ItemSkill[this.ItemSkill16]);
				// **********************************************
				result.AddItem(FileCache.Data.ItemSkill[this.ItemSkillSecond1]);
				result.AddItem(FileCache.Data.ItemSkill[this.ItemSkillSecond2]);
				result.AddItem(FileCache.Data.ItemSkill[this.ItemSkillSecond3]);
				result.AddItem(FileCache.Data.ItemSkill[this.ItemSkillSecond4]);
				result.AddItem(FileCache.Data.ItemSkill[this.ItemSkillSecond5]);
				result.AddItem(FileCache.Data.ItemSkill[this.ItemSkillSecond6]);
				result.AddItem(FileCache.Data.ItemSkill[this.ItemSkillSecond7]);
				result.AddItem(FileCache.Data.ItemSkill[this.ItemSkillSecond8]);
				result.AddItem(FileCache.Data.ItemSkill[this.ItemSkillSecond9]);
				result.AddItem(FileCache.Data.ItemSkill[this.ItemSkillSecond10]);
				result.AddItem(FileCache.Data.ItemSkill[this.ItemSkillSecond11]);
				result.AddItem(FileCache.Data.ItemSkill[this.ItemSkillSecond12]);
				result.AddItem(FileCache.Data.ItemSkill[this.ItemSkillSecond13]);
				result.AddItem(FileCache.Data.ItemSkill[this.ItemSkillSecond14]);
				result.AddItem(FileCache.Data.ItemSkill[this.ItemSkillSecond15]);
				result.AddItem(FileCache.Data.ItemSkill[this.ItemSkillSecond16]);
				// **********************************************
				result.AddItem(FileCache.Data.ItemSkill[this.ItemSkillThird1]);
				result.AddItem(FileCache.Data.ItemSkill[this.ItemSkillThird2]);
				result.AddItem(FileCache.Data.ItemSkill[this.ItemSkillThird3]);
				result.AddItem(FileCache.Data.ItemSkill[this.ItemSkillThird4]);
				result.AddItem(FileCache.Data.ItemSkill[this.ItemSkillThird5]);
				result.AddItem(FileCache.Data.ItemSkill[this.ItemSkillThird6]);
				result.AddItem(FileCache.Data.ItemSkill[this.ItemSkillThird7]);
				result.AddItem(FileCache.Data.ItemSkill[this.ItemSkillThird8]);
				result.AddItem(FileCache.Data.ItemSkill[this.ItemSkillThird9]);
				result.AddItem(FileCache.Data.ItemSkill[this.ItemSkillThird10]);
				result.AddItem(FileCache.Data.ItemSkill[this.ItemSkillThird11]);
				result.AddItem(FileCache.Data.ItemSkill[this.ItemSkillThird12]);
				result.AddItem(FileCache.Data.ItemSkill[this.ItemSkillThird13]);
				result.AddItem(FileCache.Data.ItemSkill[this.ItemSkillThird14]);
				result.AddItem(FileCache.Data.ItemSkill[this.ItemSkillThird15]);
				result.AddItem(FileCache.Data.ItemSkill[this.ItemSkillThird16]);

				return result;
			}
		}
		#endregion
	}
}
