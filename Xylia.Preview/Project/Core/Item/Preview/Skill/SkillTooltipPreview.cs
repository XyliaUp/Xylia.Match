using System.Collections.Generic;
using System.Linq;

using Xylia.bns.Modules.GameData.Enums;
using Xylia.Extension;
using Xylia.Preview.Data.Record;
using Xylia.Preview.Common.Interface;
using Xylia.Preview.Project.Core.Item.Preview;

using static Xylia.Extension.String;

using ItemData = Xylia.Preview.Data.Record.Item;

namespace Xylia.Preview.Project.Core.Item
{
	public partial class SkillTooltipPreview : PreviewControl, IPreview
	{
		#region 构造
		public SkillTooltipPreview()
		{
			InitializeComponent();

			this.ContentPanel.ForeColor = Xylia.Drawing.Font.Util.GetFontStruct("UI.Label_Green03_12").Color;
			this.JobStyleSelect.JobStyleChanged += new JobStyleSelect.JobStyleChangedHandle((o, e) => SelectStyle(e.JobStyle));
		}
		#endregion


		#region 字段
		readonly Dictionary<byte, ItemCombat> ItemCombat = new();
		#endregion





		#region 接口方法
		bool IPreview.INVALID() => false;

		void IPreview.LoadData(IRecord record)
		{
			#region 初始化
			var Item = record as ItemData;
			for (byte idx = 1; idx <= 10; idx++) ItemCombat[idx] = FileCache.Data.ItemCombat[Item.Attributes["item-combat-" + idx]];

			this.JobStyleSelect.LoadStyleIcon(Item.EquipJobCheck1);
			#endregion

			//验证 Advanced1 的有效性
			if (ItemCombat[6] != null)
			{
				SelectStyle();
				this.Visible = true;

				return;
			}

			this.Visible = false;
		}
		#endregion



		#region 界面处理
		/// <summary>
		/// 选择派系
		/// </summary>
		/// <param name="JobStyle"></param>
		private void SelectStyle(JobStyle JobStyle = JobStyle.Advanced1)
		{
			#region 初始化
			var ItemCombat = this.ItemCombat[(byte)(1 + (byte)JobStyle)];
			if (ItemCombat is null)
			{
				this.ContentPanel.Text = null;
				return;
			}
			#endregion

			#region 获取信息
			string Txt = null;

			var SkillModifyInfoGroup = FileCache.Data.SkillModifyInfoGroup[ItemCombat.SkillModifyInfoGroup];
			if (SkillModifyInfoGroup != null) Txt = SkillModifyInfoGroup.ToString();

			var ItemSkills = ItemCombat.ItemSkills;
			if (ItemSkills != null)
			{
				foreach (var vc in ItemSkills.Where(v => !v.Describe2.IsNull()))
				{
					Txt = Txt.JudgeLineFeed(JudegeLineType.NoEmpty) + LocalText.GetText(vc.Describe2);
				}
			}
			#endregion

			this.ContentPanel.Text = Txt;
			this.Parent?.Refresh();
		}
		#endregion
	}
}
