
using Xylia.bns.Modules.GameData.Enums;
using Xylia.Extension;
using Xylia.Preview.Common.Interface.RecordAttribute;
using Xylia.Preview.Data.Record;


namespace Xylia.Preview.Project.Core.Quest.Preview.Reward
{
	/// <summary>
	/// 任务奖励组
	/// </summary>
	public sealed class RewardGroup
	{
		#region 构造
		public RewardGroup(IAttributeCollection Attributes, string Group)
		{
			this.Faction = Attributes[Group + "-faction"];
			this.DifficultyType = Attributes[Group + "-difficulty-type"].ToEnum<DifficultyType>();

			this.Slot1 = Attributes[Group + "-slot-1"];
			this.Slot2 = Attributes[Group + "-slot-2"];
			this.Slot3 = Attributes[Group + "-slot-3"];
			this.Slot4 = Attributes[Group + "-slot-4"];

			byte.TryParse(Attributes[Group + "-item-count-1"], out this.ItemCount1);
			byte.TryParse(Attributes[Group + "-item-count-2"], out this.ItemCount2);
			byte.TryParse(Attributes[Group + "-item-count-3"], out this.ItemCount3);
			byte.TryParse(Attributes[Group + "-item-count-4"], out this.ItemCount4);

			byte.TryParse(Attributes[Group + "-skill-var-idx-1"], out this.SkillVarIdx1);
			byte.TryParse(Attributes[Group + "-skill-var-idx-2"], out this.SkillVarIdx2);
			byte.TryParse(Attributes[Group + "-skill-var-idx-3"], out this.SkillVarIdx3);
			byte.TryParse(Attributes[Group + "-skill-var-idx-4"], out this.SkillVarIdx4);


			this.GroupKey = Group;
			this.GroupName = GetGroupName(Attributes);
		}
		#endregion


		#region 属性字段
		public string Faction;
		public DifficultyType DifficultyType;

		public string Slot1;
		public string Slot2;
		public string Slot3;
		public string Slot4;

		public byte ItemCount1;
		public byte ItemCount2;
		public byte ItemCount3;
		public byte ItemCount4;

		//optional组没有这个
		public byte SkillVarIdx1;
		public byte SkillVarIdx2;
		public byte SkillVarIdx3;
		public byte SkillVarIdx4;
		#endregion

		#region 方法
		/// <summary>
		/// 归属组
		/// </summary>
		public string GroupKey;

		public string GroupName;

		/// <summary>
		/// 获取组名称
		/// </summary>
		/// <returns></returns>
		private string GetGroupName(IAttributeCollection Attributes)
		{
			string groupName = null;

			#region 获取难度信息
			if (this.DifficultyType == DifficultyType.Easy) groupName = "入门";
			else if (this.DifficultyType == DifficultyType.Normal) groupName = "普通";
			else if (this.DifficultyType == DifficultyType.Hard) groupName = "熟练";
			#endregion

			#region 获取势力信息
			if(this.Faction != null)
			{
				var faction = FileCache.Data.Faction[this.Faction];
				groupName += faction?.NameText() ?? this.Faction;
			}
			#endregion

			#region 获取职业信息
			for (int i = 1; i <= 20; i++)
			{
				if (!Attributes.ContainsName($"{this.GroupKey}-job-{i}", out string job)) break;

				var CurJob = job.ToEnum<JobSeq>();
				groupName += CurJob.GetDescription();
			}
			#endregion

			#region 获取性别种族信息
			for (int i = 1; i <= 4; i++)
			{
				if (!Attributes.ContainsName($"{this.GroupKey}-sex-{i}", out string sex)) break;

				groupName += sex.ToEnum<Sex>().GetDescription();
			}

			for (int i = 1; i <= 4; i++)
			{
				if (!Attributes.ContainsName($"{this.GroupKey}-race-{i}", out string race)) break;

				groupName += race.ToEnum<Race>().GetDescription();
			}
			#endregion

			return groupName;
		}
		#endregion
	}


	public class RewardGroupSet
	{
		public RewardGroup Fixed;

		public RewardGroup Optional;



		public QuestSealedDungeonReward QuestSealedDungeonReward;
	}
}