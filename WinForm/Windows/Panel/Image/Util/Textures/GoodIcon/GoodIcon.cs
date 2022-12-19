using System;
using System.Threading.Tasks;

namespace Xylia.Match.Util.Paks.Textures
{
	public sealed class GoodIcon : IconOutBase
	{
		#region 方法
		public GoodIcon(string GameFolder = null) : base(GameFolder) { }

		internal override void AnalyseSourceData()
		{
			var Table = this.GameData["goodsicon"];
			Parallel.ForEach(Table.CellDatas(), field =>
			{
				if (field is null || !field.HasData) return;

				try
				{
					int MainId = field.FID;
					int IconId = BitConverter.ToInt32(field.Field.Data, 4);
					short Idx = BitConverter.ToInt16(field.Field.Data, 4 + 8);


					this.QuoteInfos.Add(new QuoteInfo()
					{
						MainId = MainId,

						IconTextureId = IconId,
						IconIndex = Idx,
					});
				}
				catch (Exception ee)
				{
					Console.WriteLine(ee);
				}
			});
		}
		#endregion
	}
}
