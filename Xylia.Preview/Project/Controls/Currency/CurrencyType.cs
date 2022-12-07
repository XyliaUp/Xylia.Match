using System.Drawing;

using Xylia.Resources;


namespace Xylia.Preview.Project.Controls.Enums
{
	/// <summary>
	/// 货币类型
	/// </summary>
	public enum CurrencyType
	{
		/// <summary>
		/// 钱币
		/// </summary>
		Money,

		/// <summary>
		/// 神石
		/// </summary>
		GoodsStone,

		/// <summary>
		/// 绑定神石
		/// </summary>
		GoodsStone2,

		/// <summary>
		/// 珍珠
		/// </summary>
		Pearl,

		/// <summary>
		/// 龙果
		/// </summary>
		PartyBattlePoint,

		/// <summary>
		/// 仙桃
		/// </summary>
		FieldPlayPoint,

		/// <summary>
		/// 仙豆
		/// </summary>
		DuelPoint,

		/// <summary>
		/// 灵气
		/// </summary>
		FactionScore,
	}

	/// <summary>
	/// 货币支持
	/// </summary>
	public static class CurrencyUtil
	{
		public static Bitmap GetCurrencyIcon(this CurrencyType Type) => Type switch
		{
			CurrencyType.DuelPoint => BnsCommon_Old.duel,
			CurrencyType.FactionScore => BnsCommon_Old.coin_grade_2_zero,
			CurrencyType.FieldPlayPoint => BnsCommon_Old.fieldplay,
			CurrencyType.GoodsStone => BnsCommon_Old.goodsstone,
			CurrencyType.GoodsStone2 => BnsCommon_Old.goodsstone_002,
			CurrencyType.PartyBattlePoint => BnsCommon_Old.partybattle,
			CurrencyType.Pearl => BnsCommon_Old.pearl,

			_ => null,
		};
	}
}
