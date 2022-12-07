using System.Drawing;

using Xylia.Drawing;
using Xylia.Preview.Data.Record;


namespace Xylia.Match.Util.Paks.Textures
{
	/// <summary>
	/// 追加内容
	/// </summary>
	public sealed class ItemQuoteInfo : QuoteInfo
	{
		#region 实例字段
		/// <summary>
		/// 指示是否有背景
		/// </summary>
		public bool NoBG = false;

		public byte Grade;

		public byte GroceryType;
		#endregion

		public override Bitmap ProcessImage(Bitmap bitmap)
		{
			if (bitmap is null) return null;

			//如果需要背景
			if (!NoBG)
			{
				//获取物品等级背景
				var Background = Grade.GetBackGround();
				bitmap = Background.ImageCombine(bitmap, Compose.DrawLocation.Centre);
			}


			//处理封印图标
			if ((Item.GroceryType)GroceryType == Item.GroceryType.Sealed)
			{
				bitmap = bitmap.ImageCombine(Xylia.Resources.BnsCommon.Weapon_Lock_04, Compose.DrawLocation.BottomLeft);
			}

			return bitmap;
		}
	}
}
