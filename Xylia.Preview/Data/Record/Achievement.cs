using Xylia.Attribute.Component;
using Xylia.bns.Modules.GameData.Enums;
using Xylia.Preview.Project.Common.Interface;

namespace Xylia.Preview.Data.Record
{
	/// <summary>
	/// 成就
	/// </summary>
	public sealed class Achievement : IRecord ,IName
	{
		#region 属性字段
		public short Step;

		public Job Job;


		public bool Deprecated;



		[Signal("map-group-1")]
		public string MapGroup1;

		public string Picture;

		public string Name;

		public string Description2;

		[Signal("title-name")]
		public string TitleName;

		[Signal("title-image-text")]
		public string TitleImageText;

		[Signal("title-thumbnail-icon-text")]
		public string TitleThumbnailIconText;

		[Signal("sort-no")]
		public short SortNo;

		[Signal("completed-game-message")]
		public string CompletedGameMessage;

		[Signal("talk-social")]
		public string TalkSocial;

		[Signal("title-chat-ui-icon")]
		public string TitleChatUiIcon;

		[Signal("title-thumbnail-frame-fx")]
		public string TitleThumbnailFrameFx;

		[Signal("title-grade")]
		public byte TitleGrade;
		#endregion

		#region 接口方法
		public string NameText() => this.Name.GetText();
		#endregion
	}
}
