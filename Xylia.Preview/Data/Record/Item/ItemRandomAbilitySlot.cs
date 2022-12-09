using System;

using Xylia.Preview.Common.Interface;
using Xylia.Preview.Common.Enums;

namespace Xylia.Preview.Data.Record
{
	public sealed class ItemRandomAbilitySlot : IRecord
	{
		#region 属性字段
		public MainAbility ability;
		public int ValueMin;
		public int ValueMax;
		public int InitialValueMax;
		public byte ItemAbilitySectionPercent1;
		public byte ItemAbilitySectionPercent2; 
		public byte ItemAbilitySectionPercent3;

		public string ItemAbilitySection1;
		public string ItemAbilitySection2;
		public string ItemAbilitySection3;
		#endregion


		public override string ToString() => $"{this.ability} => {this.ValueMin}~{this.ValueMax} [{this.InitialValueMax}]";
	}
}
