using System.Collections.Generic;
using System.Drawing;

using Xylia.Extension;
using Xylia.Preview.Data.Record;
using Xylia.Preview.Common.Interface;
using Xylia.Preview.Project.Controls.PanelEx;
using Xylia.Preview.Project.Core.Item.Cell;

namespace Xylia.Preview.Project.Core.Item
{
	public partial class SkillByEquipmentTooltip : TitlePanel, IPreview
	{
		#region 构造
		public SkillByEquipmentTooltip()
		{
			InitializeComponent();

			this.BackColor = Color.Transparent;
		}
		#endregion

		#region 字段
		List<SkillModifyCell> SkillModifyCells = new();
		#endregion

		#region 接口方法
		bool IPreview.INVALID() => false;

		public void LoadData(IRecord record)
		{
			var Record = record as SkillByEquipment;

			this.SkillModifyCells = new();
			this.SkillModifyCells.AddItem(CreateCell(Record.Skill3_ID_1, Record.TooltipText1, out var Skill));
			this.SkillModifyCells.AddItem(CreateCell(Record.Skill3_ID_2, Record.TooltipText2, out _));
			this.SkillModifyCells.AddItem(CreateCell(Record.Skill3_ID_3, Record.TooltipText3, out _));
			this.SkillModifyCells.AddItem(CreateCell(Record.Skill3_ID_4, Record.TooltipText4, out _));

			//显示首个技能的图标
			this.SkillIcon.Image = Skill?.MainIcon();

			this.Refresh();
		}

		/// <summary>
		/// 创建单元
		/// </summary>
		/// <param name="Skill3ID"></param>
		/// <param name="Tooltip"></param>
		/// <param name="Skill"></param>
		/// <returns></returns>
		private static SkillModifyCell CreateCell(int Skill3ID, string Tooltip, out Skill3 Skill)
		{
			Skill = FileCache.Data.Skill3[Skill3ID];
			if (Skill != null) return new SkillModifyCell()
			{
				SkillName = Skill.Attributes["name2"].GetText(),
				TooltipText = Tooltip.GetText(),
			};

			return null;
		}
		#endregion



		#region 重写方法
		public override void Refresh()
		{
			//清理元素
			this.Controls.Remove<SkillModifyCell>();

			//设置文本起始位置
			const int StartY = 25;
			int LocY = StartY;
			foreach (var SkillModifyCell in this.SkillModifyCells)
			{
				SkillModifyCell.Location = new Point(100, LocY);
				this.Controls.Add(SkillModifyCell);

				LocY = SkillModifyCell.Bottom + 1;
			}

			this.Height = LocY;

			//计算技能图标位置
			this.SkillIcon.Location = new Point(this.SkillIcon.Location.X, (StartY + LocY - this.SkillIcon.Height) / 2);
		}
		#endregion
	}
}
