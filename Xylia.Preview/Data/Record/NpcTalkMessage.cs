using System.ComponentModel;

using Xylia.Preview.Common.Interface;

using CommonTable = Xylia.bns.Modules.GameData.CommonTable;

namespace Xylia.Preview.Data.Record
{
	public sealed class NpcTalkMessage : IRecord, IName
	{
		#region 属性字段
		public string Name2;

		[Description("required-faction")]
		public CommonTable.Faction RequiredFaction;

		[Description("required-complete-quest")]
		public string RequiredCompleteQuest;



		[Description("function-step")]
		public byte FunctionStep;

		[Description("end-talk-socia")]
		public CommonTable.Social EndTalkSocial;

		[Description("end-talk-sound")]
		public string EndTalkSound;
		#endregion


		#region 方法
		public string GetStepShow(int index) => this.Attributes["step-show-" + index];
		#endregion

		#region 接口方法
		public string NameText() => this.Name2.GetText();
		#endregion
	}
}
