using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Xylia.bns.Modules.DataFormat.Dat;
using Xylia.bns.Modules.GameData.Enums;
using Xylia.Files.Xml;
using Xylia.Preview.Properties;

using QuestData = Xylia.bns.Modules.Quest.Entities.Quest;

namespace Xylia.Preview.Data.Helper
{
	public static class ReadQuestData
	{
		static bool InLoading;


		public static QuestData GetQuestData(this string QuestAlias)
		{
			return GetQuestData(int.Parse(QuestAlias.Replace("q_sub_", null)));
		}

		public static QuestData GetQuestData(this int QuestID)
		{
			while (InLoading) Thread.Sleep(100);

			if (FileCacheData.Data.Quest is null)
			{
				InLoading = true;
				FileCacheData.Data.Quest = GetQuests();
				InLoading = false;
			}


			return FileCacheData.Data.Quest.ContainsKey(QuestID) ? FileCacheData.Data.Quest[QuestID] : null;
		}

		/// <summary>
		/// 获取任务列表
		/// </summary>
		/// <returns></returns>
		public static ConcurrentDictionary<int, QuestData> GetQuests()
		{
			ConcurrentDictionary<int, QuestData> temp = new();

			var TempData = new BNSDat().ExportFile(CommonPath.GameFolder.GetXmlPath());
			Parallel.ForEach(TempData, item =>
			{
				if (!item.RelativePath.Contains(@"quest\")) return;

				var QuestData = item.XmlDocument.ReadFile<QuestData>().FirstOrDefault();
				temp.GetOrAdd(QuestData.id, QuestData);
			});

			return temp;
		}



		#region 处理方法
		public static void GetEpicInfo(Action<QuestData> act, Job TargetJob = Job.소환사) => GetEpicInfo(221, act, TargetJob);

		public static void GetEpicInfo(this int QuestID, Action<QuestData> act, Job TargetJob = Job.소환사)
		{
			var QuestData = ReadQuestData.GetQuestData(QuestID);
			if (QuestData is null) return;

			//执行活动
			act(QuestData);

			#region 获取下一任务信息
			if (QuestData.Completion.Value is null) return;
			foreach (var NextQuest in QuestData.Completion.Value.NextQuests)
			{
				if (NextQuest.Job1 == Job.JobNone || NextQuest.Job1 == TargetJob)
					GetEpicInfo(NextQuest.GetQuestID, act, TargetJob);
			}
			#endregion
		}
		#endregion
	}
}
