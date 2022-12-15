using System.Collections.Concurrent;
using System.Data;
using System.Linq;
using System.Reflection;

using Xylia.bns.Modules.DataFormat.Bin;
using Xylia.bns.Read;
using Xylia.Extension;
using Xylia.Preview.Data.Record;
using Xylia.Preview.Properties;

using QuestData = Xylia.bns.Modules.Quest.Entities.Quest;

namespace Xylia.Preview.Data.Helper
{
	/// <summary>
	/// 缓存数据
	/// </summary>
	public sealed class DataTableSet
	{
		BinData _GameData;

		BinData _LocalData;

		public BinData GameData
		{
			get
			{
				if (_GameData is null)
				{
					var getDataPath = new GetDataPath(CommonPath.GameFolder, true);

					_GameData = new BinData(getDataPath.TargetXml);
					if (_LocalData is null) _LocalData = new(getDataPath.TargetLocal);
				}

				return _GameData;
			}
		}

		public BinData LocalData
		{
			get
			{
				if (_LocalData is null) _LocalData = new BinData(new GetDataPath(CommonPath.GameFolder, true).TargetLocal);
				return _LocalData;
			}
		}




		public DataTable<AccountPostCharge> AccountPostCharge { get; } = new();

		public DataTable<Achievement> Achievement { get; } = new();



		public DataTable<BossChallenge> BossChallenge { get; } = new();
		public DataTable<Collecting> Collecting { get; } = new();
		public DataTable<ChallengeList> ChallengeList { get; } = new();
		public DataTable<ChallengeListReward> ChallengeListReward { get; } = new();
		public DataTable<ClosetGroup> ClosetGroup { get; } = new();
		public DataTable<ContentsReset> ContentsReset { get; } = new();
		public DataTable<ContentQuota> ContentQuota { get; } = new();

		public DataTable<Cave2> Cave2 { get; } = new();
		public DataTable<Cave> Cave { get; } = new();
		public DataTable<ClassicFieldZone> ClassicFieldZone { get; } = new();

		public DataTable<Duel> Duel { get; } = new();
		public DataTable<Dungeon> Dungeon { get; } = new();

		public DataTable<Effect> Effect { get; } = new();

		
		public DataTable<FactionBattleFieldZone> FactionBattleFieldZone { get; } = new();
		public DataTable<Faction> Faction { get; } = new();
		public DataTable<FactionLevel> FactionLevel { get; } = new();



		public DataTable<FieldZone> FieldZone { get; } = new();
		public DataTable<GuildBattleFieldZone> GuildBattleFieldZone { get; } = new();


		public DataTable<IconTexture> IconTexture { get; } = new();


		public ItemTable Item { get; } = new();




		public DataTable<ItemBrand> ItemBrand { get; } = new();
		public DataTable<ItemBrandTooltip> ItemBrandTooltip { get; } = new();
		public DataTable<ItemBuyPrice> ItemBuyPrice { get; } = new();
		public DataTable<ItemCombat> ItemCombat { get; } = new();
		public DataTable<ItemEvent> ItemEvent { get; } = new();
		public DataTable<ItemExchange> ItemExchange { get; } = new();

		public DataTable<ItemImprove> ItemImprove { get; } = new();
		public DataTable<ItemImproveOption> ItemImproveOption { get; } = new();
		public DataTable<ItemImproveOptionList> ItemImproveOptionList { get; } = new();


		public DataTable<ItemRandomAbilitySection> ItemRandomAbilitySection { get; } = new();
		public DataTable<ItemRandomAbilitySlot> ItemRandomAbilitySlot { get; } = new();
		public DataTable<ItemSkill> ItemSkill { get; } = new();
		public DataTable<ItemSpirit> ItemSpirit { get; } = new();


		public DataTable<ItemTransformRecipe> ItemTransformRecipe { get; } = new();


		public DataTable<JobData> Job { get; } = new();
		public DataTable<JobStyleData> JobStyle { get; } = new();



		public DataTable<KeyCap> KeyCap { get; } = new();
		public DataTable<KeyCommand> KeyCommand { get; } = new();



		public DataTable<MapInfo> MapInfo { get; } = new();

		public DataTable<MapGroup1> MapGroup1 { get; } = new();

		public DataTable<MapGroup1Expedition> MapGroup1Expedition { get; } = new();

		public DataTable<MapGroup2> MapGroup2 { get; } = new();




		public DataTable<MapUnit> MapUnit { get; } = new();

		public DataTable<Npc> Npc { get; } = new();

		public DataTable<NpcResponse> NpcResponse { get; } = new();

		public DataTable<NpcTalkMessage> NpcTalkMessage { get; } = new();


		public DataTable<PartyBattleFieldZone> PartyBattleFieldZone { get; } = new();
		public DataTable<PublicRaid> PublicRaid { get; } = new();



		public ConcurrentDictionary<int, QuestData> Quest { get; set; }




		public DataTable<QuestBonusReward> QuestBonusReward { get; } = new();
		public DataTable<QuestBonusRewardSetting> QuestBonusRewardSetting { get; } = new();
		public DataTable<QuestReward> QuestReward { get; } = new() { PublicSet = false };
		public DataTable<QuestSealedDungeonReward> QuestSealedDungeonReward { get; } = new();



		public DataTable<RaidDungeon> RaidDungeon { get; } = new();



		public DataTable<RandomStore> RandomStore { get; } = new();
		public DataTable<RandomStoreDrawReward> RandomStoreDrawReward { get; } = new();
		public DataTable<RandomStoreItem> RandomStoreItem { get; } = new();
		public DataTable<RandomStoreItemDisplay> RandomStoreItemDisplay { get; } = new();



		public DataTable<Reward> Reward { get; } = new();


		public DataTable<SetItem> SetItem { get; } = new();

		public DataTable<Skill3> Skill3 { get; } = new();


		public DataTable<SkillByEquipment> SkillByEquipment { get; } = new();
		public DataTable<SkillCastCondition3> SkillCastCondition3 { get; } = new();
		public DataTable<SkillGatherRange3> SkillGatherRange3 { get; } = new();
		public DataTable<SkillModifyInfo> SkillModifyInfo { get; } = new();
		public DataTable<SkillModifyInfoGroup> SkillModifyInfoGroup { get; } = new();
		public DataTable<SkillTooltip> SkillTooltip { get; } = new();
		public DataTable<SkillTooltipAttribute> SkillTooltipAttribute { get; } = new();
		public DataTable<SkillTrainCategory> SkillTrainCategory { get; } = new();
		public DataTable<SkillTrait> SkillTrait { get; } = new();

		public DataTable<SlateScroll> SlateScroll { get; } = new();
		public DataTable<SlateScrollStone> SlateScrollStone { get; } = new();
		public DataTable<SlateStone> SlateStone { get; } = new();


		public DataTable<Store2> Store2 { get; } = new();


		public DataTable<TendencyField> TendencyField { get; } = new();

		public TextTable TextData { get; } = new();

		public DataTable<UnlocatedStore> UnlocatedStore { get; } = new();

		public DataTable<WantedMission> WantedMission { get; } = new();
		public DataTable<WorldAccountCard> WorldAccountCard { get; } = new();
		public DataTable<WorldAccountExpedition> WorldAccountExpedition { get; } = new();
		public DataTable<WorldAccountMuseum> WorldAccountMuseum { get; } = new();

		public DataTable<ZoneEnv2> ZoneEnv2 { get; } = new();




		/// <summary>
		/// 清理所有缓存数据
		/// </summary>
		public void ClearAll()
		{
			Quest?.Clear();
			IconTexture?.Clear();


			//自动判断并清理
			foreach (var finfo in this.GetType().GetMembers(ClassExtension.Flags).Where(m => m is FieldInfo || m is PropertyInfo))
			{
				//类型校验后清理数据
				if (finfo.HasImplementedRawGeneric(typeof(DataTable<>)))
				{
					var DataTable = finfo.GetValue(this);
					DataTable.GetType().GetMethod("Clear", ClassExtension.Flags).Invoke(DataTable);
				}
			}
		}
	}
}
