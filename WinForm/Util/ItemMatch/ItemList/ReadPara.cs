namespace Xylia.Match.Util.ItemList
{
	/// <summary>
	/// 参数构造
	/// </summary>
	public class ReadPara
	{
		public PathEntity Path = new PathEntity();

		public bool OnlyNew;
	}

	public struct PathEntity
	{
		public string Chv;
	}
}
