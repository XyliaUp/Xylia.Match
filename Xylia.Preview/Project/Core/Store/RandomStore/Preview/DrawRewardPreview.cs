using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using Xylia.Preview.Data.Record;


namespace Xylia.Preview.Project.Core.RandomStore
{
	/// <summary>
	/// 聚灵阁次数奖励
	/// </summary>
	public partial class DrawRewardPreview : UserControl
	{
		#region 构造
		public DrawRewardPreview()
		{
			InitializeComponent();
		}
		#endregion

		#region 方法
		private void DrawRewardPreview_Load(object sender, System.EventArgs e)
		{
			this.LoadData();
		}

		/// <summary>
		/// 载入数据
		/// </summary>
		public void LoadData()
		{
<<<<<<< HEAD:Xylia.Preview/Project/Core/Store/RandomStore/Preview/DrawRewardPreview.cs
			if (this.DesignMode) return;


=======
>>>>>>> 87a0768aaf48150c6d7df46e4e5bad42ef854068:Xylia.Preview/Project/Core/RandomStore/Preview/DrawRewardPreview.cs
			var RandomStore = FileCache.Data.RandomStore.Find(a => a.RandomStoreNumber == RandomStoreNumber.RandomStore1);

			this.PromotionName.Text = "UI.RandomStore.PromotionName".GetText();
			this.label3.Text += $"（可以获得{ RandomStore?.AcquireDrawRewardSetRepeatCount }轮）";

			int LocY = 185;
			foreach (var Info in FileCache.Data.RandomStoreDrawReward.OrderBy(a => a.RequiredDrawCount))
			{
				var DrawRewardCell = new Cell.DrawRewardCell();

				DrawRewardCell.LoadData(Info);
				DrawRewardCell.Location = new Point(0, LocY);

				this.Controls.Add(DrawRewardCell);
				LocY = DrawRewardCell.Bottom + 20;
			}
		}
		#endregion
	}
}
