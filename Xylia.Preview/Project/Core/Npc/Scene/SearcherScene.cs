using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using Xylia.Extension;
using Xylia.Preview.Common.Interface;
using Xylia.Preview.Project.Controls.PanelEx;
using Xylia.Preview.Project.Core.Npc.Cell;

namespace Xylia.Preview.Project.Core.Npc.Scene
{
	public partial class SearcherScene : Form
	{
		#region 构造
		public SearcherScene(IEnumerable<IRecord> Npcs)
		{
			InitializeComponent();
			this.ShowInfo(Npcs);
		}

		/// <summary>
		/// 显示信息
		/// </summary>
		/// <param name="Npcs"></param>
		private void ShowInfo(IEnumerable<IRecord> Npcs)
		{
			var StoreItems = new List<ListCell>();
			foreach (var Record in Npcs)
			{
				#region 初始化
				var StoreItemCell = new InfoCell();

				string NpcAlias = Record.Alias;
				string NpcInfo = Record.Attributes["name2"].GetText() + $" ({ NpcAlias })";
				#endregion

				//查询地图信息
				var MapUnit = FileCache.Data.MapUnit.Where(Info => Info.Alias.MyContains(NpcAlias)).FirstOrDefault();
				if (MapUnit != null)
				{
					StoreItemCell.ShowRightText = true;
					StoreItemCell.RightText = FileCache.Data.MapInfo[MapUnit.Mapid]?.NameText();
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
		/// <param name="SearchResult"></param>
		/// <returns></returns>
		public static IEnumerable<IRecord> GetRelativeNpc(string Store2Alias)
		{
			return FileCache.Data.Npc.Where(info =>
			  info.Attributes["store2-1"].MyEquals(Store2Alias) ||
			  info.Attributes["store2-2"].MyEquals(Store2Alias) ||
			  info.Attributes["store2-3"].MyEquals(Store2Alias) ||
			  info.Attributes["store2-4"].MyEquals(Store2Alias) ||
			  info.Attributes["store2-5"].MyEquals(Store2Alias) ||
			  info.Attributes["store2-6"].MyEquals(Store2Alias));
		}
		#endregion
	}
}
