using System.ComponentModel;
using System.Linq;

using Xylia.Extension;
using Xylia.Files.XmlEx;
using Xylia.Preview.Project.Common.Enums;
using Xylia.Preview.Project.Common.Interface;

namespace Xylia.Preview.Data.Record
{
	public sealed class WorldAccountExpedition : IRecord
	{
		#region 字段
		public byte Step;

		[Description("can-not-used")]
		public bool CanNotUsed;

		public byte Category;

		public bool Unknown;

		public AttachAbility Ability1;
		public AttachAbility Ability2;
		public AttachAbility Ability3;
		public AttachAbility Ability4;
		public AttachAbility Ability5;

		public int AbilityValue1;
		public int AbilityValue2;
		public int AbilityValue3;
		public int AbilityValue4;
		public int AbilityValue5;


		public string Name2;
		public string Description2;
		public string Story;

		public string Icon1;
		public string Icon2;
		public string Icon3;
		public string Icon4;
		public string Icon5;

		public string Tooltip1;
		public string Tooltip2;
		public string Tooltip3;
		public string Tooltip4;
		public string Tooltip5;
		#endregion
	}
}
