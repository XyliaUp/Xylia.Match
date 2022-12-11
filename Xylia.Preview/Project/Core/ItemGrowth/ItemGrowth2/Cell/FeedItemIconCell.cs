using System.Drawing;

using Xylia.Preview.Project.Core.Item.Cell.Basic;
using Xylia.Preview.Resources;

namespace Xylia.Preview.Project.Core.ItemGrowth.Cell
{
	public sealed class FeedItemIconCell : ItemIconCell
	{
		#region 构造
		public override Bitmap FrameImage => Resource_Common.FeedItem;
		#endregion
	}
}