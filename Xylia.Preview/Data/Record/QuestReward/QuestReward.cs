using System.Collections.Generic;

using Xylia.Extension;
using Xylia.Preview.Common.Interface;

namespace Xylia.Preview.Data.Record
{
	public sealed class QuestReward : IRecord
	{
		#region 属性字段
		public bool QuestFirstProgress => this.Attributes["quest-first-progress"]?.ToBool() ?? false;
		public int BasicProductionExp => this.Attributes["basic-production-exp"].ToIntWithNull() ?? 0;
		public int BasicFactionReputation => this.Attributes["basic-faction-reputation"].ToIntWithNull() ?? 0;
		public int BasicMoney => this.Attributes["basic-money"].ToIntWithNull() ?? 0;
		public int BasicExp => this.Attributes["basic-exp"].ToIntWithNull() ?? 0;
		public int BasicAccountExp => this.Attributes["basic-account-exp"].ToIntWithNull() ?? 0;
		public int BasicDuelPoint => this.Attributes["basic-duel-point"].ToIntWithNull() ?? 0;
		public int BasicPartyBattlePoint => this.Attributes["basic-party-battle-point"].ToIntWithNull() ?? 0;
		public int BasicFieldPlayPoint => this.Attributes["basic-field-play-point"].ToIntWithNull() ?? 0;

		public string FixedSkill3_1 => this.Attributes["fixed-skill3-1"];
		public string FixedSkill3_2 => this.Attributes["fixed-skill3-2"];
		public string FixedSkill3_3 => this.Attributes["fixed-skill3-3"];
		public string FixedSkill3_4 => this.Attributes["fixed-skill3-4"];
		#endregion


		#region 结构字段
		public bool FinalReward = true;
		public byte Step = 0;

		/// <summary>
		/// 固定奖励
		/// </summary>
		public List<QuestRewardGroup> Fixeds
		{
			get
			{
				var Result = new List<QuestRewardGroup>();
				for (int i = 1; i <= 15; i++)
				{
					if (!this.ContainsAttribute($"fixed-{i}-slot-1", out _)) break;
					 Result.Add(new QuestRewardGroup(this.Attributes, $"fixed-{i}"));
				}

				return Result;
			}
		}

		/// <summary>
		/// 可选奖励
		/// </summary>
		public List<QuestRewardGroup> Optionals
		{
			get
			{
				var Result = new List<QuestRewardGroup>();
				for (int i = 1; i <= 15; i++)
				{
					if (!this.ContainsAttribute($"optional-{i}-slot-1", out _)) break;
					 Result.Add(new QuestRewardGroup(this.Attributes, $"fixed-{i}"));
				}

				return Result;
			}
		}
		#endregion
	}
}
