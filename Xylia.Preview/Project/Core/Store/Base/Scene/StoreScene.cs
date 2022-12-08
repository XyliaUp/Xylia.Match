using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

using Xylia.Extension;
using Xylia.Preview.Common.Interface;
using Xylia.Preview.Data.Record;

namespace Xylia.Preview.Project.Core.Store
{
	public partial class StoreScene : Form
	{
		#region 构造
		public StoreScene()
		{
			InitializeComponent();

			CheckForIllegalCrossThreadCalls = false;
			this.Frm_SizeChanged(null, null);
		}
		#endregion

		#region 字段
		/// <summary>
		/// 指示正在加载
		/// </summary>
		internal bool InLoading = false;

		/// <summary>
		/// 缓存
		/// </summary>
		internal Dictionary<TreeNode, NodeInfo> TreeNodeInfo = new ();

		/// <summary>
		/// 线程
		/// </summary>
		private Thread thread;

		/// <summary>
		/// 筛选信息
		/// </summary>
		public readonly FilterList Filter = new();
		#endregion


		#region 方法
		/// <summary>
		/// 载入数据
		/// </summary>
		public virtual void LoadData()
		{

		}

		/// <summary>
		/// 展示指定商店内容
		/// </summary>
		public virtual void ShowStoreContent(string StoreAlias)
		{

		}

		/// <summary>
		/// 切换显示商店列表
		/// </summary>
		/// <param name="FilterRule"></param>
		internal void ShowStoreList(string FilterRule = null)
		{
			//清理节点内容
			foreach (TreeNode CurNode in this.TreeView.Nodes) CurNode.Nodes.Clear();

			//尝试获取记录器对象
			IRecord RecordEntity = null;

			if (this.Filter.Contains(FilterTag.Item))
			{
				if (!FilterRule.IsNull()) RecordEntity = FilterRule.GetItemInfo(null, false);
			}

			//恢复符合规则的子节点
			foreach (var Node in this.TreeNodeInfo)
			{
				if (FilterRule.IsNull() ||
					Node.Key.Text.MyContains(FilterRule) ||   //判断节点文本
					this.FilterNode(Node.Value, RecordEntity ?? (object)FilterRule))  //特殊规则判断
				{
					Node.Value.ParentNode.Nodes.Add(Node.Key);
				}
			}

			this.TreeView.ExpandAll();
		}

		/// <summary>
		/// 在筛选时，指示此节点是否符合条件
		/// </summary>
		/// <param name="NodeInfo"></param>
		/// <param name="FilterRule">搜索规则，可以为文本或者实例对象</param>
		/// <returns></returns>
		public virtual bool FilterNode(NodeInfo NodeInfo, object FilterRule)
		{
			return false;
		}
		#endregion

		#region 控件方法
		private void Store2Frm_Load(object sender, EventArgs e)
		{
			this.LoadData();
		}

		public void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
		{
			thread = new Thread((ThreadStart)delegate
			{
				//筛选对象
				if (TreeView.SelectedNode != null && TreeNodeInfo.ContainsKey(TreeView.SelectedNode))
				{
					this.ShowStoreContent(TreeNodeInfo[TreeView.SelectedNode].AliasText);
				}
			});

			thread.SetApartmentState(ApartmentState.STA);
			thread.Start();
		}


		public void Frm_SizeChanged(object sender, EventArgs e)
		{
			int TempWidth = this.Width - this.TreeView.Width - 30;
			this.ListPreview.Width = Math.Max(TempWidth, 315);
		}

		private void Store2Frm_FormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				if (thread != null) thread.Abort();
			}
			catch
			{

			}
		}


		/// <summary>
		/// 筛选内容
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ModifyFilterRule_Click(object sender, EventArgs e)
		{
			var Searcher = new Searcher(Filter?.FilterInfo);
			if (Searcher.ShowDialog() == DialogResult.OK)
			{
				string SearchRule = Searcher.textBox1.Text;
				this.ShowStoreList(SearchRule);
			}
		}

		private void CancelFilter_Click(object sender, EventArgs e)
		{
			this.ShowStoreList();
		}
		#endregion
	}


	/// <summary>
	/// 节点信息
	/// </summary>
	public class NodeInfo
	{
		public NodeInfo(string AliasText, TreeNode TreeNode)
		{
			this.AliasText = AliasText;
			this.TreeNode = TreeNode;
			this.ParentNode = TreeNode.Parent;
		}

		/// <summary>
		/// 母节点，用于筛选时
		/// </summary>
		public TreeNode ParentNode;

		/// <summary>
		/// 节点
		/// </summary>
		public TreeNode TreeNode;

		/// <summary>
		/// 文本
		/// </summary>
		public string AliasText;
	}
}
