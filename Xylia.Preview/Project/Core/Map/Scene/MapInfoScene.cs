using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

using Xylia.Preview.Common.Cast;
using Xylia.Preview.Common.Extension;
using Xylia.Preview.Data.Package.Pak;
using Xylia.Preview.Data.Record;

namespace Xylia.Preview.Project.Core.Map.Scene
{
	public partial class MapInfoScene : Form
	{
		#region 构造
		public MapInfoScene() : this("World") { }

		public MapInfoScene(string Rule)
		{
			InitializeComponent();

			LoadData(Rule);
		}
		#endregion

		#region 方法
		public void LoadData(string Rule)
		{
			var MapInfo = FileCache.Data.MapInfo[Rule];
			if (MapInfo is null) return;

			var MapGroup1 = FileCache.Data.MapGroup1[MapInfo.MapGroup1];
			var MapGroup2 = FileCache.Data.MapGroup2[MapInfo.MapGroup2];


			if (MapInfo.ParentMapinfo != null)
			{
				this.OpenParentMap.Visible = true;
				this.OpenParentMap.Click += new EventHandler((o, e) => Execute.MyShowDialog(new MapInfoScene(MapInfo.ParentMapinfo)));
			}


			Trace.WriteLine(MapInfo.Attributes);

			this.Text = $"[{MapInfo.Name2.GetText()}]";
			this.pictureBox1.Image = MapInfo.Imageset.GetImageset();

			foreach (var mapunit in FileCache.Data.MapUnit.Where(d => d.Mapid == MapInfo.ID))
			{
				if (mapunit.Type == MapUnit.TypeSeq.Quest) continue;

				var res = mapunit.Imageset.GetImageset();
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

					Location = GetPoint(mapunit.PositionX, mapunit.PositionY, MapInfo),
				};

				string Tooltip = mapunit.Name2.GetText();
				if (mapunit.Type == MapUnit.TypeSeq.Attraction) Tooltip = mapunit.Attributes["attraction"].GetObject().GetName();
				else if (mapunit.Type == MapUnit.TypeSeq.Npc) Tooltip = mapunit.Attributes["npc"].GetObject(DataType.Npc).GetName();
				else if (mapunit.Type == MapUnit.TypeSeq.Boss) Tooltip = mapunit.Attributes["npc"].GetObject(DataType.Npc).GetName();

				temp.SetToolTip(Tooltip);
				temp.Click += new EventHandler((sender, e) =>
				{
					var o = (Control)sender;

					if (mapunit.Type == MapUnit.TypeSeq.Link) Execute.MyShowDialog(new MapInfoScene(mapunit.Attributes["link-mapid"]));

					Debug.WriteLine(mapunit.Attributes);
				});

				this.pictureBox1.Controls.Add(temp);
			}
		}


		/// <summary>
		/// 转换为当前坐标点
		/// </summary>
		/// <param name="PositionX"></param>
		/// <param name="PositionY"></param>
		/// <param name="MapInfo"></param>
		/// <returns></returns>
		public static Point GetPoint(float PositionX, float PositionY, MapInfo MapInfo)
		{
			float PointX = MapInfo.ImageSize * (0 + (PositionY - MapInfo.LocalAxisY) / (MapInfo.Scale * MapInfo.ImageSize));     //1050
			float PointY = MapInfo.ImageSize * (1 - (PositionX - MapInfo.LocalAxisX) / (MapInfo.Scale * MapInfo.ImageSize));     //1000

			return new Point((int)PointX, (int)PointY);
		}

		private void pictureBox1_DoubleClick(object sender, EventArgs e)
		{
			var me = e as MouseEventArgs;

			Debug.WriteLine(me.X + "  " + me.Y);
		}
		#endregion
	}
}
