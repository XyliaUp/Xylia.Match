using System.Drawing;

using Xylia.Preview.Project.Core.Item.Cell.Basic;

namespace Xylia.Preview.Project.Core.ItemGrowth.Cell
{
	public sealed class FeedItemIconCell : ItemIconCell
	{
		#region 构造
		public override Bitmap FrameImage => Properties.Resources.FeedItem;
		#endregion
	}
}