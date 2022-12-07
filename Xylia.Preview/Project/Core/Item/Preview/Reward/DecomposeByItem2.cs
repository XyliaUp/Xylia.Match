namespace Xylia.Preview.Project.Core.Item.Preview.Reward
{
	/// <summary>
	/// 开启所需物品信息
	/// </summary>
	public class DecomposeByItem2
	{
		public DecomposeByItem2(string Item,int StackCount)
		{
			this.Item = Item;
			this.StackCount = StackCount;
		}


		/// <summary>
		/// 物品别名
		/// </summary>
		public string Item;

		/// <summary>
		/// 需要数量
		/// </summary>
		public int StackCount = 0;


		/// <summary>
		/// 无效数据
		/// </summary>
		public bool INVALID => string.IsNullOrWhiteSpace(Item);
	}
}