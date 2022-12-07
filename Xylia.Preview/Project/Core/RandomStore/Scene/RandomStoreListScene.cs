using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using Xylia.Extension;
using Xylia.Preview.Data.Record;
using Xylia.Preview.Project.Controls.PanelEx;
using Xylia.Preview.Project.Core.Store.Store2;

using ItemData = Xylia.Preview.Data.Record.Item;


namespace Xylia.Preview.Project.Core.Store.RandomStore
{
	public sealed partial class RandomStoreListScene : StoreScene
	{
		#region 字段
		private readonly Dictionary<string, Dictionary<int, RandomStoreItem>> RandomStoreItemGroups = new();

		private readonly Dictionary<GroupType, TreeNode> MainNode = new();
		#endregion

		#region 构造
		public RandomStoreListScene() : base()
		{
			this.ListPreview.MainMenu.Items.Add("设置当前组合概率");
			this.ListPreview.MainMenu.Items.Add("新增聚灵阁组合");


			this.TreeView.Nodes.Clear();
			this.MainNode.Clear();

			foreach (int code in Enum.GetValues(typeof(GroupType)))
			{
				var item = (GroupType)code;

				var TreeNode = new TreeNode(item.GetDescription());
				this.TreeView.Nodes.Add(TreeNode);

				MainNode.Add(item, TreeNode);
			}

			this.InitializeComponent();
		}
		#endregion


		#region 方法
		public override void LoadData()
		{
			//先进行分组
			foreach (var Record in FileCache.Data.RandomStoreItem)
			{
				if (Record.Alias.RegexMatch("[0-9]*$", out string Result))
				{
					int Idx = int.Parse(Result);
					string GroupAlias = Record.Alias.RegexReplace("_[0-9]*$");

					if (!RandomStoreItemGroups.ContainsKey(GroupAlias))
					{
						RandomStoreItemGroups.Add(GroupAlias, new Dictionary<int, RandomStoreItem>());

						//显示的文本名称
						GroupType CurGroupType;

						#region 判断应该追加到哪个母节点
						if (GroupAlias.MyContains("gold"))
						{
							if (GroupAlias.MyContains("rare")) CurGroupType = GroupType.GoldRare;
							else CurGroupType = GroupType.GoldNormal;
						}
						else
						{
							if (GroupAlias.MyContains("awesome")) CurGroupType = GroupType.Awesome;
							else if (GroupAlias.MyContains("rare")) CurGroupType = GroupType.Rare;
							else CurGroupType = GroupType.Normal;
						}

						TreeNode ParentNode = this.MainNode[CurGroupType];
						#endregion

						var Node = ParentNode.Nodes.Add(GroupAlias);
						this.TreeNodeInfo.Add(Node, new NodeInfo(GroupAlias, Node));
					}

					RandomStoreItemGroups[GroupAlias].Add(Idx, Record);
				}
			}

			this.MainNode[GroupType.Rare].ExpandAll();
		}

		public override void ShowStoreContent(string GroupAlias)
		{
			#region 初始化数据
			if (InLoading) return;
			else if (!RandomStoreItemGroups.ContainsKey(GroupAlias)) return;
			else InLoading = true;

			this.ListPreview.StoreAlias = GroupAlias;
			var CurRandomStoreItems = this.RandomStoreItemGroups[GroupAlias];
			#endregion

			#region 显示内容
			var Cells = new List<ListCell>();
			foreach (var RandomStoreItem in CurRandomStoreItems.Values)
			{
				#region 加载实例数据
				var ItemInfo = RandomStoreItem.Item.GetItemInfo();

				//加载物品购买价格（聚灵阁只有 金币 & 第一个物品)
				var BuyPrice = new ItemBuyPrice()
				{
					RequiredItem1 = RandomStoreItem.ItemPriceItem,
					RequiredItemCount1 = RandomStoreItem.ItemPriceItemAmount,

					Money = RandomStoreItem.ItemPriceMoney,
				};
				#endregion

				//保证控件不会跨线程调用
				this.ListPreview.Invoke(new Action(() =>
				{
					var Store2ItemCell = new Store2ItemCell(ItemInfo, BuyPrice)
					{
						StoreBundleCount = RandomStoreItem.ItemCount,
					};

					Cells.Add(Store2ItemCell);
				}));
			}

			this.ListPreview.Invoke(new Action(() => this.ListPreview.Cells = Cells));
			InLoading = false;
			#endregion
		}

		public override bool FilterNode(NodeInfo NodeInfo, object FilterRule)
		{
			//如果搜索条件是物品信息，那么再搜索可购买物品
			if (FilterRule is ItemData FilterItem)
			{
				//遍历可购买物品字段
				foreach (var ItemGroup in this.RandomStoreItemGroups[NodeInfo.AliasText].Values)
				{
					var ItemInfo = ItemGroup.Item.GetItemInfo();
					if (ItemInfo != null && ItemInfo.Alias == FilterItem.Alias) return true;
				}
			}

			return false;
		}
		#endregion
	}




	/// <summary>
	/// 组类型
	/// </summary>
	public enum GroupType
	{
		[Description("聚灵阁 稀有")]
		Rare,

		[Description("聚灵阁 一般")]
		Normal,

		[Description("聚灵阁 鸿运")]
		Awesome,

		[Description("金币聚灵阁 稀有")]
		GoldRare,

		[Description("金币聚灵阁 一般")]
		GoldNormal,
	}
}
