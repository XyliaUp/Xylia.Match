using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

using HZH_Controls.Forms;

using NPOI.SS.Formula.Functions;

using Xylia.Extension;
using Xylia.Files.XmlEx;
using Xylia.Match.Properties;


namespace Xylia.Match.Windows
{
	public partial class OnlineFileSelect : FrmBack
	{
		#region 构造
		public OnlineFileSelect()
		{
			InitializeComponent();
		}
		#endregion

		#region 字段
		Dictionary<string, string> DownPath = new Dictionary<string, string>();
		public string SelectedName = null;
		public string SelectedPath = null;
		#endregion



		#region 控件方法
		private void OnlineFileSelect_Load(object sender, EventArgs e)
		{
			new Thread((ThreadStart)delegate
			{
				try
				{
					StartLoad();
				}
				catch (Exception ee)
				{
					if (!this.IsDisposed)
					{
						Invoke(new Action(() =>
						{
							FrmTips.ShowTipsError( ee.Message);
							this.Hide();
						}));
					}
				}
			}).Start();
		}

		private void OnlineFileSelect_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Enter: treeViewEx3_DoubleClick(null, null); break;
			}
		}

		private void treeViewEx3_DoubleClick(object sender, EventArgs e)
		{
			if (treeViewEx3.SelectedNode == null || treeViewEx3.SelectedNode.Nodes.Count != 0)
			{
				FrmTips.ShowTipsSuccess("请先选择详细选项");
				return;
			}

			string Item = treeViewEx3.SelectedNode.Text;

			#region 加载失败提示
			if (!DownPath.ContainsKey(Item))
			{
				FrmTips.ShowTipsError( "该资源已下架，请选择其他资源。");
				return;
			}
			#endregion

			FrmTips.ShowTipsSuccess("正在校验资源有效性，请稍等片刻");

			new Thread((ThreadStart)delegate
			{
				try
				{
					var data = new HttpClient().GetByteArrayAsync(DownPath[Item]).Result;

					SelectedName = @"云端资源:\\Chv文件\" + Item;
					SelectedPath = DownPath[Item];

					if (!this.IsDisposed)
					{
						Invoke(new Action(() =>
						{
							FrmTips.ClearTips();
							FrmTips.ShowTipsSuccess("资源校验成功，可以开始执行！");
							this.Close();
						}));
					}
				}
				catch
				{
					FrmTips.ShowTipsError( "资源校验失败，请重新选择其他资源。");
					return;
				}
			}).Start();
		}
		#endregion

		#region 处理方法
		private void StartLoad()
		{
			XmlDocument xmlDocument = new XmlDocument();

			try { xmlDocument.Load(Url.PublicConfig); }
			catch { throw new Exception("通信发生异常，请检查网络设置。"); }

			StartRead(xmlDocument);

			if (!this.IsDisposed) this.treeViewEx3.ExpandAll();
		}

		private void StartRead(XmlDocument xmlDocument)
		{
			foreach (XmlNode xmlNode in xmlDocument.SelectNodes("//Group"))
			{
				if (xmlNode.Property().Attributes["Ext"] == "chv")
				{
					this.GetLastNode(xmlNode, null, true);
				}
			}
		}

		public void GetLastNode(XmlNode XNode, TreeNode TreeNode, bool isRoot = false)
		{
			XmlProperty Property = new(XNode);

			string Name = Property.Attributes["Name"];

			// 判断是否应该跳过
			if (string.IsNullOrWhiteSpace(Name) || Name.ToLower() == "null") return;

			string ID = Property.Attributes["ID"];
			string Key = Property.Attributes["Key"];
			string Path = Xylia.Net.Youdao.NoteShare.UrlCombine(ID, Key);


			if (XNode.HasChildNodes)
			{
				TreeNode ParentNode = null;

				if (!isRoot)
				{
					Invoke(new Action(() =>
					{
						if (TreeNode == null) ParentNode = treeViewEx3.Nodes.Add(Name);
						else ParentNode = TreeNode.Nodes.Add(Name);
					}));
				}

				foreach (XmlNode xmlNode in XNode.ChildNodes) GetLastNode(xmlNode, ParentNode);
			}
			else
			{
				string Item = null;

				try
				{
					Item = $"{  Name } ({ GetCount(Path) }条记录)";
					DownPath.Add(Item, Xylia.Net.Youdao.NoteShare.UrlCombine(ID, Key));
				}
				catch
				{
					Item = $"{ Name } (已下线)";
				}

				if (!isRoot) Invoke(new Action(() => { TreeNode.Nodes.Add(Item); }));
			}
		}


		/// <summary>
		/// 获取数据总数
		/// </summary>
		/// <param name="Path"></param>
		/// <returns></returns>
		public int GetCount(string Path)
		{
			HttpClient client = new();
			string list = Encoding.UTF8.GetString(client.GetByteArrayAsync(Path).Result)
				.Replace("\"", "");

			return new List<string>(list.Split(new[] { "\r\n" }, StringSplitOptions.None)).Count;
		}
		#endregion
	}
}
