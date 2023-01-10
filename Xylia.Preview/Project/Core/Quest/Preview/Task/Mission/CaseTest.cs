using System.Collections.Generic;
using System.Windows.Forms;

using Xylia.bns.Modules.Quest.Entities;
using Xylia.bns.Modules.Quest.Entities.Case;
using Xylia.bns.Modules.GameData.Enums;
using Xylia.Preview.Common.Cast;

namespace Xylia.Preview.Project.Core.Quest.Preview.Task
{
	public class CaseTest
	{
		public CaseTest(ICase Case)
		{
			this.Data = Case;
			this.Controls = new();
		}


		public readonly ICase Data;

		public override string ToString()
		{
			if (Data is CaseBase @case)
			{
				string CompletionInfo = null;
				if (@case.CompletionCount == 0 && @case.CompletionCountOp == Op.eq) CompletionInfo = "首次 ";
				else if (@case.CompletionCount == 1 && @case.CompletionCountOp == Op.lt) CompletionInfo = "首次 ";
				else if (@case.CompletionCount > 1) CompletionInfo = @case.CompletionCount + "  " + @case.CompletionCountOp + " ";


				string MainInfo = null;
				if (Data is TalkToSelf talktoself) MainInfo = $"书信对话";
				else if (Data is NpcTalkBase talk) MainInfo = $"和{ talk.Object.GetName() }对话";

				return CompletionInfo + MainInfo;
			}


			return null;
		}


		public readonly List<Control> Controls;
	}
}