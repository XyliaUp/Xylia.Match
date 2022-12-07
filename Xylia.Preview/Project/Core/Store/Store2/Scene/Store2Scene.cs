using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

using Xylia.bns.Modules.GameData.Enums;
using Xylia.Extension;
using Xylia.Preview.Data.Record;
using Xylia.Preview.Project.Common.Interface;
using Xylia.Preview.Project.Controls.PanelEx;
using Xylia.Preview.Project.Core.Store.Store2.Util;

using ItemData = Xylia.Preview.Data.Record.Item;


namespace Xylia.Preview.Project.Core.Store.Store2
{
	/// <summary>
	/// 商店预览
	/// </summary>
	public sealed partial class Store2Scene : StoreScene
	{
		#region 字段
		/// <summary>
		/// 商店类型与主要节点对应关系
		/// </summary>
		public Dictionary<Store2Type, TreeNode> Nodes = new();

		/// <summary>
		/// 关联NPC临时缓存信息
		/// </summary>
		private IEnumerable<IRecord> Records = new List<IRecord>();
		#endregion


		#region 构造
		public Store2Scene() : base()
		{
			this.InitializeComponent();

			#region 设置商店分组
			this.TreeView.Nodes.Clear();

			Nodes.Add(Store2Type.UnlocatedStore, this.TreeView.Nodes.Add("飞龙工商"));
			Nodes.Add(Store2Type.AccountStore, this.TreeView.Nodes.Add("侠义团商店"));
			Nodes.Add(Store2Type.SoulBoostStore, this.TreeView.Nodes.Add("成长加速礼商店"));
			Nodes.Add(Store2Type.Normal, this.TreeView.Nodes.Add("普通商店"));
			#endregion

			#region 获取职业信息
			var Source = typeof(Job).GetFields()
				.Where(f => f.FieldType.IsEnum && (Job)f.GetValue() > Job.JobNone && (Job)f.GetValue() < Job.PcMax)
				.Select(f => f.GetDescription() ?? f.Name).ToList();

			Source.Insert(0, "全部");

			this.JobSelector.Source = Source;

			var LastJobSelect = Xylia.Configure.Ini.ReadValue(this.Name, "JobFilter");
			this.JobSelector.TextValue = Source.Contains(LastJobSelect) ? LastJobSelect : this.JobSelector.Source.FirstOrDefault();
			#endregion


			#region 设置筛选内容
			this.Filter.Add(new FilterInfo(FilterTag.Text, "商店名", true));
			this.Filter.Add(new FilterInfo(FilterTag.Item, "出售物品", true));
			#endregion
		}
		#endregion



		#region 处理方法
		/// <summary>
		/// 加载数据
		/// </summary>
		public override void LoadData()
		{
			#region 读取数据
			var StoreInfoList = new List<StoreInfo>();
			FileCache.Data.Store2.ForEach(Store2 =>
			{
				#region 初始化
				var Store2Alias = Store2.Alias;
				var StoreType = Store2Type.Normal;

				string CurName = Store2Alias;
				string Name2 = Store2.NameText();
				if (!Name2.IsNull()) CurName = $"[{ Name2 }] " + CurName;

				int? Order = null;

				//远程商店设定
				var UnlocatedStore = FileCache.Data.UnlocatedStore.Find(o => o.Store2 == Store2Alias);
				if (UnlocatedStore != null)
				{
					#region 判断商店类型
					if (UnlocatedStore.UnlocatedStoreType == UnlocatedStore.Type.AccountStore) StoreType = Store2Type.AccountStore;

					else if (
					UnlocatedStore.UnlocatedStoreType == UnlocatedStore.Type.SoulBoostStore1 ||
					UnlocatedStore.UnlocatedStoreType == UnlocatedStore.Type.SoulBoostStore2 ||
					UnlocatedStore.UnlocatedStoreType == UnlocatedStore.Type.SoulBoostStore3 ||
					UnlocatedStore.UnlocatedStoreType == UnlocatedStore.Type.SoulBoostStore4 ||
					UnlocatedStore.UnlocatedStoreType == UnlocatedStore.Type.SoulBoostStore5 ||
					UnlocatedStore.UnlocatedStoreType == UnlocatedStore.Type.SoulBoostStore6) StoreType = Store2Type.SoulBoostStore;

					else StoreType = Store2Type.UnlocatedStore;
					#endregion

					//读取顺序编号
					Order = UnlocatedStore.ID;
				}
				#endregion

				#region 生成控件
				StoreInfoList.Add(new StoreInfo()
				{
					Alias = Store2Alias,
					Name = CurName,

					//节点顺序
					Order = Order ?? Store2.ID,
					StoreType = StoreType,
				});
				#endregion
			});
			#endregion

			#region 插入节点
			foreach (var Info in StoreInfoList.OrderBy(a => a.Order))
			{
				if (Nodes.ContainsKey(Info.StoreType))
				{
					var CurNode = Nodes[Info.StoreType].Nodes.Add(Info.Name);
					this.TreeNodeInfo.Add(CurNode, new NodeInfo(Info.Alias, CurNode));
				}
				//不显示SoulBoost商店
				else if (Info.StoreType != Store2Type.SoulBoostStore)
				{
					Console.WriteLine("不支持的商店类型：" + Info.StoreType);
				}
			}
			#endregion

			TreeView.Nodes[0].ExpandAll();
		}

		/// <summary>
		/// 展示商店内容
		/// </summary>
		/// <param name="StoreAlias"></param>
		public override void ShowStoreContent(string StoreAlias)
		{
			#region 初始化数据
			if (InLoading) return;

			var Store2 = FileCache.Data.Store2[StoreAlias];
			if (Store2 is null)
			{
				InLoading = false;
				return;
			}

			InLoading = true;


			//获取是否存在出售NPC
			var HasRelativeNpc = Npc.Scene.SearcherScene.HasRelativeNpc(StoreAlias, out Records);
			this.Invoke(new Action(() => this.ucBtnExt1.Visible = HasRelativeNpc));

			var ItemCells = new List<ListCell>();
			this.ListPreview.StoreAlias = Store2.Alias;
			#endregion

			#region 读取数据
			//获取当前选择的职业
			var temp = typeof(Job).GetFields().ToList().Find(f => this.JobSelector.TextValue == (f.GetDescription() ?? f.Name));
			Job SelectedJob = temp?.Name.ToEnum<Job>() ?? Job.JobNone;

			int MaxIndex = 120;
			for (int i = 1; i <= MaxIndex; i++)
			{
				this.Text = $"商店 { Store2.NameText() } ，加载数据中：{ (i - 1) * 100 / 120 }%";
				string ItemAlias = Store2.Attributes["item-" + i];
				string BuyPrice = Store2.Attributes["buy-price-" + i];

				if (ItemAlias is null) break;

				//获取物品信息
				var ItemInfo = ItemAlias.GetItemInfo();
				if (ItemInfo is null) continue;

				//获取物品职业限制，如果未通过筛选则不进行下一操作
				if (!ItemInfo.CheckEquipJob(SelectedJob)) continue;

				var ItemBuyPrice = FileCache.Data.ItemBuyPrice[BuyPrice];
				this.ListPreview.Invoke(new Action(() => ItemCells.Add(new Store2ItemCell(ItemInfo, ItemBuyPrice))));   //保证控件不会跨线程调用
			}

			this.Text = $"商店 { Store2.NameText() } ，共计 { ItemCells.Count }个兑换内容";

			this.ListPreview.Invoke(() =>
			{
				Clipboard.SetText(this.ListPreview.StoreAlias);
				this.ListPreview.Cells = ItemCells;
			});
			#endregion

			InLoading = false;
		}

		/// <summary>
		/// 筛选节点
		/// </summary>
		/// <param name="NodeInfo"></param>
		/// <param name="FilterRule"></param>
		/// <returns></returns>
		public override bool FilterNode(NodeInfo NodeInfo, object FilterRule)
		{
			//如果搜索条件是物品信息，那么再搜索可购买物品
			if (FilterRule is ItemData FilterItem && this.Filter.Contains(FilterTag.Item))
			{
				var Store2 = FileCache.Data.Store2.GetInfo(NodeInfo.AliasText);
				if (Store2 is null) return false;

				//遍历可购买物品字段
				foreach (var a in Store2.Attributes)
				{
					if (!a.Key.StartsWith("item-")) continue;

					var ItemInfo = a.Value.GetItemInfo();
					if (ItemInfo != null && ItemInfo.Alias == FilterItem.Alias) return true;
				}
			}

			return false;
		}
		#endregion



		#region 界面方法
		private void Store2Scene_Load(object sender, EventArgs e)
		{
			Store2Scene_SizeChanged(null, null);
		}

		/// <summary>
		/// 显示关联Npc列表
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ucBtnExt1_BtnClick(object sender, EventArgs e)
		{
			var thread = new Thread((ThreadStart)delegate
			{
				//显示搜索界面
				var preview = new Npc.Scene.SearcherScene();

				preview.ShowInfo(this.Records);
				preview.ShowDialog();
			});

			thread.SetApartmentState(ApartmentState.STA);
			thread.Start();
		}

		private void Store2Scene_SizeChanged(object sender, EventArgs e)
		{
			this.ListPreview.Height = this.Height - this.ControlPanel.Bottom - 55;
		}

		private void JobSelector_SelectedChangedEvent(object sender, EventArgs e)
		{
			Xylia.Configure.Ini.WriteValue(this.Name, "JobFilter", this.JobSelector.TextValue);
			this.TreeView_AfterSelect(null, null);
		}
		#endregion
	}
}
