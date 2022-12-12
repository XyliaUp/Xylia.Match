using System.Drawing;

using Xylia.Preview.Project.Core.Item.Cell.Basic;
using Xylia.Preview.Resources;

namespace Xylia.Preview.Project.Core.ItemGrowth.ItemGrowth2.Preview
{
	public sealed class FeedItemIconCell : ItemIconCell
	{
		public override Bitmap FrameImage => Resource_Common.FeedItem;


		/// <summary>
		/// ResultWeaponPreview	绑定控件
		/// </summary>

		public ItemNameCell BindName;
	}
}