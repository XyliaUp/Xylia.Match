
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

using Xylia.Extension;
using Xylia.Match.Windows.Controls;
using Xylia.Preview.Data.Helper;

using QuestData = Xylia.bns.Modules.Quest.Entities.Quest;

namespace Xylia.Match.GUI
{
	public partial class Epic : MetroFramework.Forms.MetroForm
	{
		#region 构造
		Thread thread = null;

		/// <summary>
		/// 临时数据
		/// </summary>
		Dictionary<TreeNode, QuestData> temp = new();


		public Epic()
		{
			CheckForIllegalCrossThreadCalls = false;
			InitializeComponent();
			richTextBox1.MouseWheel += new MouseEventHandler(richTextBox1_MouseWheel);
		}
		#endregion



		#region 控件方法
		private void Epic_Load(object sender, EventArgs e)
		{
			thread = new Thread((ThreadStart)delegate
			{
				try
				{
					//获取任务数据
					ReadQuestData.GetEpicInfo(data =>
					{
						string Group2 = data.Group2.GetText();
						string QuestName = data.Name2.GetText();

						TreeNode GroupNode = null;  //组节点
						foreach (TreeNode node in TreeView.Nodes)
						{
							if (node.Text == Group2)
							{
								GroupNode = node;
								break;
							}
						}

						//创建任务节点
						if (this.InvokeRequired) this.Invoke(() =>
						{
							if (GroupNode is null) GroupNode = TreeView.Nodes.Add(Group2);

							var QuestNode = GroupNode.Nodes.Add(QuestName);
							temp.Add(QuestNode, data);
						});
					});
				}
				catch (Exception ee)
				{
					if (ee.Message.Contains("abort") || ee.Message.Contains("中止")) return;
					Tip.Message(ee.Message);
				}
			});

			thread.Start();
		}



		bool UseControl = false;

		public void richTextBox1_MouseWheel(object sender, MouseEventArgs e)
		{
			if (!UseControl) return;

			float Num = (float)0.1;

			if (e.Delta > 0)  //上滚
				richTextBox1.ZoomFactor += Num;
			else              //下滚
				richTextBox1.ZoomFactor -= Num;

			richTextBox1.Refresh();
		}

		private void Epic_KeyDown(object sender, KeyEventArgs e)
		{
			UseControl = false;

			switch (e.KeyCode)
			{
				#region 控制快捷键
				case Keys.Control:
					UseControl = true;
					break;

				case Keys.Space:
					if (this.TreeView.SelectedNode == null)
						return;

					this.TreeView.SelectedNode.Expand();
					break;

				case Keys.Enter:
					if (this.TreeView.SelectedNode == null)
						return;

					this.TreeView.SelectedNode.Expand();

					break;
				#endregion

				#region 键盘上下
				case Keys.Up:
					if (this.TreeView.SelectedNode == null || sender == TreeView)
						return;

					var Node = this.TreeView.SelectedNode.PrevNode;

					if (Node != null)
						this.TreeView.SelectedNode = Node;
					break;

				case Keys.Down:
					if (this.TreeView.SelectedNode == null || sender == TreeView)
						return;

					Node = this.TreeView.SelectedNode.NextNode;

					if (Node != null)
						this.TreeView.SelectedNode = Node;
					break;
					#endregion
			}
		}

		private void Epic_SizeChanged(object sender, EventArgs e)
		{
			richTextBox1.Width = this.Width - TreeView.Width - 50;
		}

		private void Epic_TextChanged(object sender, EventArgs e)
		{
			this.Refresh();
		}

		private void Epic_FormClosing(object sender, FormClosingEventArgs e)
		{
			thread = null;
		}

		private void Epic_Shown(object sender, EventArgs e)
		{
			this.richTextBox1.ContextMenuStrip = UserOperator.contextMenu;
		}

		private void TreeView2_AfterSelect_1(object sender, TreeViewEventArgs e)
		{
			if (!temp.ContainsKey(TreeView.SelectedNode)) return;
			var QuestData = temp[TreeView.SelectedNode];

			//获得前世红尘的内容
			richTextBox1.Text = QuestData.CompletedDesc.GetText()?.Decode()?
				.Replace("<br/>", "\n");

			//标题提示
			this.Text = $"[{QuestData.id}] { QuestData.Name2.GetText() }";
		}
		#endregion
	}
}