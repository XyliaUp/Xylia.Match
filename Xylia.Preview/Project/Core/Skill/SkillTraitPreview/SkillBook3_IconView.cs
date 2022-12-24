using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using Xylia.bns.Modules.GameData.Enums;
using Xylia.Extension;
using Xylia.Preview.Data.Record;
using Xylia.Preview.Project.Controls;
using Xylia.Preview.Project.Core.Item.Cell.Basic;

namespace Xylia.Preview.Project.Core.Skill
{
	public partial class SkillBook3_IconView : Form
	{
		public SkillBook3_IconView(List<Skill3> Skills)
		{
			InitializeComponent();
			this.LoadData(Skills);
		}

		public void LoadData(List<Skill3> data)
		{
			#region 获取数据
			Dictionary<KeyCommandSeq, List<Skill3>> skills = new();
			foreach (var skill in data)
			{
				var ShortCutKey = skill.ShortCutKey;
				 if (!skills.ContainsKey(ShortCutKey)) skills.Add(ShortCutKey, new());

				skills[ShortCutKey].Add(skill);
			}
			#endregion


			int LoX = 0;
			int LoY = 0;

			foreach(var pair in skills.OrderBy(o => o.Key))
			{
				#region	加载标题
				ContentPanel Title = new()
				{
					Text = pair.Key.GetKeyCommand().GetImage() ?? "无",

					AutoSize = true,
					ForeColor = Color.White,
					Location = new Point(LoX, LoY),
				};

				LoY = Title.Bottom;
				this.Controls.Add(Title);
				#endregion

				#region 加载技能
				foreach (var skill in pair.Value)
				{
					ItemIconCell ItemIconCell = new()
					{
						Scale = 64,
						ObjectRef = skill,

						Image = skill.MainIcon(),
						Location = new Point(LoX, LoY),
					};

					LoY = ItemIconCell.Bottom;
					this.Controls.Add(ItemIconCell);
				}
				#endregion

				LoX += 70;
				LoY = 0;
			}
		}
	}
}