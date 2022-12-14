using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

using HZH_Controls.Util;


using Xylia.Extension;
using Xylia.Preview.Common.Cast;
using Xylia.Preview.Common.Extension;
using Xylia.Preview.Data.Package.Pak;
using Xylia.Preview.Data.Record;

using static Xylia.Preview.Data.Record.MapUnit;


namespace Xylia.Preview.Project.Core.Map.Scene
{
	public partial class MapInfoScene : Form
	{
		#region 构造
		public MapInfoScene() : this("World") { }

		public MapInfoScene(string Rule)
		{
			InitializeComponent();

			this.LoadData(Rule);
		}
		#endregion


		#region 方法
		private MapInfo OpenedMapInfo;

		public void LoadData(string Rule)
		{
			var MapInfo = this.OpenedMapInfo = FileCache.Data.MapInfo[Rule];
			if (MapInfo is null) return;

			if (MapInfo.ParentMapinfo != null)
			{
				this.OpenParentMap.Visible = true;
				this.OpenParentMap.Click += new EventHandler((o, e) => Execute.MyShowDialog(new MapInfoScene(MapInfo.ParentMapinfo)));
			}

			var MapGroup1 = FileCache.Data.MapGroup1[MapInfo.MapGroup1];
			var MapGroup2 = FileCache.Data.MapGroup2[MapInfo.MapGroup2];


			//获取当前查看的地图的深度
			this.OpenedMapInfo._MapDepth = MapInfo.GetMapDepth(this.OpenedMapInfo);


			Trace.WriteLine(MapInfo.Attributes);

			this.Text = $"[{MapInfo.Name2.GetText()}]";
			this.pictureBox1.Image = MapInfo.Imageset.GetUObject().GetImage();

			this.LoadMapUint(MapInfo);
		}

		private void LoadMapUint(MapInfo MapInfo, List<MapInfo> MapTree = null)
		{
			MapTree ??= new();
			MapTree.Add(MapInfo);

			this.GetMapUnit(MapInfo, MapTree);


			if (MapInfo.Alias == "World") return;
			FileCache.Data.MapInfo.Where(o => o.ParentMapinfo == MapInfo.Alias).ForEach(o => this.LoadMapUint(o, new(MapTree)));
		}

		/// <summary>
		/// 获取指定地图的单元
		/// </summary>
		/// <param name="CurMapInfo"></param>
		/// <param name="MapTree"></param>
		private void GetMapUnit(MapInfo CurMapInfo, List<MapInfo> MapTree)
		{
			var MapUnits = FileCache.Data.MapUnit.Where(o => o.Mapid == CurMapInfo.ID && o.MapDepth <= this.OpenedMapInfo._MapDepth);
			foreach (var mapunit in MapUnits)
			{
				if (mapunit.Type == TypeSeq.Quest) continue;
				if (mapunit.Type == TypeSeq.Npc) continue;    //该类型按接取的任务进行显示


				var res = mapunit.Imageset.GetUObject().GetImage();
				if (res is null) continue;

				var temp = new PictureBox()
				{
					Name = mapunit.Alias,
					Image = res.GetThumbnailImage(
						mapunit.SizeX == 0 ? res.Width : mapunit.SizeX,
						mapunit.SizeY == 0 ? res.Height : mapunit.SizeY,
						null, IntPtr.Zero),

					BackColor = Color.Transparent,
					SizeMode = PictureBoxSizeMode.AutoSize,
				};


				#region Get Pos
				//如果地形一致，不用转换 pos
				var Pos = GetPoint(mapunit.PositionX, mapunit.PositionY, this.OpenedMapInfo).ToPoint();
				if (MapTree.Count > 1)
				{
					for (int idx = MapTree.Count; idx > 1; idx--)
					{
						var Map = MapTree[idx - 1];
						if (Map.UsePosInParent) Pos = new Point((int)Map.PosInParentX, (int)Map.PosInParentY);
					}
				}

				temp.Location = Pos;
				#endregion



				this.pictureBox1.Controls.Add(temp);

				#region 设置提示内容
				string Tooltip = mapunit.Name2.GetText();
				if (mapunit.Type == TypeSeq.Attraction)
				{
					var Attraction = mapunit.Attributes["attraction"].CastObject();
					if (Attraction != null) Tooltip = $"{Attraction.GetType().Name}: " + Attraction.GetName();
				}
				else if (mapunit.Type == TypeSeq.Npc || mapunit.Type == TypeSeq.Boss) Tooltip = mapunit.Attributes["npc"].CastObject(nameof(FileCache.Data.Npc)).GetName();

				ToolTip.SetToolTip(temp, Tooltip);
				#endregion

				temp.Click += new EventHandler((sender, e) =>
				{
					if (mapunit.Type == TypeSeq.Link) Execute.MyShowDialog(new MapInfoScene(mapunit.Attributes["link-mapid"]));

					Debug.WriteLine(mapunit.Attributes);
				});
			}
		}



		/// <summary>
		/// 转换为当前坐标点
		/// </summary>
		/// <param name="PositionX"></param>
		/// <param name="PositionY"></param>
		/// <param name="ParentMapInfo"></param>
		/// <returns></returns>
		public static PointF GetPoint(float PositionX, float PositionY, MapInfo ParentMapInfo)
		{
			float PointX = (PositionX - ParentMapInfo.LocalAxisX) / (ParentMapInfo.Scale);     //1050
			float PointY = (PositionY - ParentMapInfo.LocalAxisY) / (ParentMapInfo.Scale);     //1000

			//转换为当前坐标轴的位置
			return new PointF(PointY, ParentMapInfo.ImageSize - PointX);
		}

		private void pictureBox1_DoubleClick(object sender, EventArgs e)
		{
			var me = e as MouseEventArgs;

			Debug.WriteLine(me.X + "  " + me.Y);
		}
		#endregion
	}
}