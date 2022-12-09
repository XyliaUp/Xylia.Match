using System.Drawing;

namespace Xylia.Match.Util.Paks.Textures
{
	/// <summary>
	/// 图标关联信息
	/// </summary>
	public class QuoteInfo
	{
		#region 存储名称时字段
		/// <summary>
		/// 对象编号
		/// </summary>
		public int MainId;

		/// <summary>
		/// 对象名称
		/// </summary>
		public string Name;

		/// <summary>
		/// 对象别名
		/// </summary>
		public string Alias;
		#endregion

		#region 图标信息
		/// <summary>
		/// 图标编号
		/// </summary>
		public int IconTextureId;

		/// <summary>
		/// 图标索引
		/// </summary>
		public short IconIndex;
		#endregion



		/// <summary>
		/// 加工图片
		/// </summary>
		public virtual Bitmap ProcessImage(Bitmap bitmap) => bitmap;
	}
}
