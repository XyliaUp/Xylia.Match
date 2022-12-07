using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

using Xylia.Extension;
using Xylia.Preview.Project.Common.Extension;
using Xylia.Preview.Project.Common.Interface;
using Xylia.Preview.Project.Controls.PanelEx;
using Xylia.Preview.Project.Core.Item.Cell;
using Xylia.Preview.Data.Record;

namespace Xylia.Preview.Project.Core.Item
{
	public partial class SlateScrollTooltip : TitlePanel, IPreview
	{
		#region 构造
		public SlateScrollTooltip()
		{
			InitializeComponent();
		}
		#endregion

		#region 方法
		private void SlateScrollTooltip_SizeChanged(object sender, EventArgs e)
		{
			foreach (var Cell in this.Controls.OfType<SlateScrollCell>())
			{
				Cell.Width = this.Width - 12;
			}
		}
		#endregion


		#region 接口方法
		bool IPreview.INVALID() => false;

		void IPreview.LoadData(IRecord record)
		{
			#region 筛选出刻印书与血石的对应信息
			//执行排序：将推荐血石排序到前面，同时抽取部分非推荐血石
			var ScrollStones = FileCache.Data.SlateScrollStone.Where(info => info.scroll.MyEquals(record.Alias)).ToList();
			ScrollStones.Sort(new SlateScrollStoneSort(){ SortByGrade = false });

			//然后取出前N个对象，不足时则不执行
			if (ScrollStones.Count > 20) ScrollStones = ScrollStones.Take(20).ToList();
			ScrollStones.Sort(new SlateScrollStoneSort() { SortByGrade = true });
			#endregion


			#region 处理血石信息并生成控件
			//显示血石信息
			var SlateScrollCells = new List<SlateScrollCell>();
			foreach (var Stone in ScrollStones.Select(s => FileCache.Data.SlateStone[s.stone]))
			{
				#region 生成属性信息
				char SplitChar = '，';   //设置分隔符号
				string AbilityInfo = null;

				void GetAbility(Common.Enums.AttachAbility ability, int max_ability_value)
				{
					if (ability != 0) AbilityInfo += ability.GetDescription() + " " + max_ability_value + SplitChar;
				}

				GetAbility(Stone.ModifyAbility1, Stone.MaxAbilityValue1);
				GetAbility(Stone.ModifyAbility2, Stone.MaxAbilityValue2);
				GetAbility(Stone.ModifyAbility3, Stone.MaxAbilityValue3);
				GetAbility(Stone.ModifyAbility4, Stone.MaxAbilityValue4);

				AbilityInfo = AbilityInfo?.RemoveSuffixString(SplitChar);
				#endregion

				#region 生成新的血石单元
				SlateScrollCells.Add(new SlateScrollCell()
				{
					Icon = Stone.Icon.GetIcon(),
					Text = Stone.NameText(),
					Grade = Stone.Grade,

					AbilityInfo = AbilityInfo,
				});
				#endregion
			}
			#endregion

			#region 界面显示控制
			int LoY = 21 + 8;
			foreach (var Cell in SlateScrollCells)
			{
				Cell.Location = new Point(0, LoY - 8);
				Cell.Width = this.Width - 12;
				this.Controls.Add(Cell);

				Cell.BringToFront();
				LoY = Cell.Bottom;
			}

			//渲染底部提示
			this.Guide.BringToFront();
			this.Guide.Location = new Point(this.Guide.Location.X, LoY);

			this.Height = this.Guide.Bottom;
			#endregion
		}
		#endregion
	}



	public class SlateScrollStoneSort : IComparer<SlateScrollStone>
	{
		/// <summary>
		/// 按品级排序
		/// </summary>
		public bool SortByGrade = false;

		public int Compare(SlateScrollStone x, SlateScrollStone y)
		{
			if (x is null || y is null) return 0;

			if (SortByGrade)
			{
				var Grade1 = FileCache.Data.SlateStone[x.stone]?.Grade ?? 0;
				var Grade2 = FileCache.Data.SlateStone[y.stone]?.Grade ?? 0;

				return  Grade2 - Grade1;
			}

			//判断顺序（小的在前）
			if (x.recommend && y.recommend) return x.ID - y.ID;

			//将推荐血石排序到前面
			else if (!x.recommend && y.recommend) return 1;
			else if (x.recommend && !y.recommend) return -1;

			//随机排序非推荐血石	  
			return MyRandom.RandomStream[0].Next(-1, 2);
		}
	}
}
