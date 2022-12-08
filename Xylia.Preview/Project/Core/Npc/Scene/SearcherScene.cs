using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using Xylia.Extension;
using Xylia.Preview.Common.Interface;
using Xylia.Preview.Project.Controls.PanelEx;


namespace Xylia.Preview.Project.Core.Npc.Scene
{
	public partial class SearcherScene : Form
	{
		#region 构造
		public SearcherScene()
		{
			InitializeComponent();
		}
		#endregion

		#region 方法
		/// <summary>
		/// 显示信息
		/// </summary>
		/// <param name="Npcs"></param>
		public void ShowInfo(IEnumerable<IRecord> Npcs)
		{
			var StoreItems = new List<ListCell>();
			foreach (var Record in Npcs)
			{
				#region 初始化
				var StoreItemCell = new Cell.InfoCell();

				string NpcAlias = Record.Alias;
				string NpcInfo = Record.Attributes["name2"].GetText() + $" ({ NpcAlias })";
				#endregion

				 //查询地图信息
				var MapUnit = FileCache.Data.MapUnit.Find(Info => Info.Alias.Contains(NpcAlias));
				if (MapUnit != null)
				{
					string MapId = MapUnit.Attributes["map-id"];
					string MapName = FileCache.Data.MapInfo.GetInfo(MapId)?.Attributes["name"].GetText();

					StoreItemCell.ShowRightText = true;
					StoreItemCell.RightText = MapName;
				}

				StoreItemCell.LeftText = NpcInfo;
				StoreItems.Add(StoreItemCell);
			};

			this.storeListPreview1.Cells = StoreItems;
		}
		#endregion

		#region 静态方法
		/// <summary>
		/// 是否存在关联Npc
		/// </summary>
		/// <param name="Store2Alias"></param>
		/// <returns></returns>
		public static bool HasRelativeNpc(string Store2Alias)
		{
			return HasRelativeNpc(Store2Alias, out _);
		}

		/// <summary>
		/// 是否存在关联Npc
		/// </summary>
		/// <param name="Store2Alias"></param>
		/// <param name="SearchResult"></param>
		/// <returns></returns>
		public static bool HasRelativeNpc(string Store2Alias, out IEnumerable<IRecord> SearchResult)
		{
			SearchResult = FileCache.Data.Npc.Where(info =>
			  info.Attributes["store2-1"].MyEquals(Store2Alias) ||
			  info.Attributes["store2-2"].MyEquals(Store2Alias) ||
			  info.Attributes["store2-3"].MyEquals(Store2Alias) ||
			  info.Attributes["store2-4"].MyEquals(Store2Alias) ||
			  info.Attributes["store2-5"].MyEquals(Store2Alias) ||
			  info.Attributes["store2-6"].MyEquals(Store2Alias));

			return SearchResult.Any();
		}
		#endregion

		private void SearcherScene_Load(object sender, EventArgs e)
		{

		}
	}
}
