using System.Collections.Generic;

using NPOI.SS.UserModel;

using Xylia.bns.Modules.GameData.Enums;
using Xylia.Extension;
using Xylia.Files;
using Xylia.Preview.Common.Cast;
using Xylia.Preview.Data.Helper;
using Xylia.Preview.Project.RunForm;

namespace Xylia.Preview.Third.Content
{
	public sealed class ChallengeList : OutBase
	{
		public override string SheetName => "今日挑战";

		public override void CreateData()
		{
			#region 配置标题
			for (int idx = 0; idx <= 6; idx++) ExcelInfo.sheet.SetColumnWidth(idx, 30 * 256);

			var Rows = new List<IRow>();
			for (int idx = 0; idx <= 50; idx++) Rows.Add(this.ExcelInfo.CreateRow(idx));
			#endregion

			#region 输出内容
			int CellIdx = -1;
			foreach (var ChallengeType in ChallengeListFrm.TodayChallengeType)
			{
				#region 初始化
				//插入标题行
				Rows[0].AddCell(ChallengeType.Value);

				CellIdx++;
				int RowIdx = 1;

				var challengeList = FileCache.Data.ChallengeList.Find(o => o.ChallengeType == ChallengeType.Key);
				if (challengeList is null) continue;
				#endregion


				#region 加载任务课题
				for (int Idx = 1; Idx <= 20; Idx++)
				{
					var ChallengeQuestBasic = challengeList.Attributes["challenge-quest-basic-" + Idx];
					var ChallengeQuestExpansion = challengeList.Attributes["challenge-quest-expansion-" + Idx];

					if (ChallengeQuestBasic is null) break;

					var Info = ReadQuestData.GetQuestData(ChallengeQuestBasic).Name2.GetText();
					this.ExcelInfo.CreateCell(Rows[RowIdx++], CellIdx).SetCellValue(Info);
				}
				#endregion

				#region 加载击杀课题
				for (int Idx = 1; Idx <= 20; Idx++)
				{
					var ChallengeNpcDifficulty = challengeList.Attributes["challenge-npc-difficulty-" + Idx].ToEnum<DifficultyType>();
					var ChallengeNpcKill = challengeList.Attributes["challenge-npc-kill-" + Idx];
					var ChallengeNpcAttraction = challengeList.Attributes["challenge-npc-attraction-" + Idx];

					var KillNpc = FileCache.Data.Npc[ChallengeNpcKill];
					if (KillNpc is null) break;

					var AttractionInfo = ChallengeNpcAttraction.CastObject().GetName();
					var Info = $"[{ ChallengeNpcDifficulty.GetDescription() }] { AttractionInfo } - { KillNpc.NameText() }";
					this.ExcelInfo.CreateCell(Rows[RowIdx++], CellIdx).SetCellValue(Info);
				}
				#endregion
			}
			#endregion
		}
	}
}