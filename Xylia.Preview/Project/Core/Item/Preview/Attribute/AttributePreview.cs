using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using Xylia.Extension;
using Xylia.Preview.Common.Interface;
using Xylia.Preview.Data.Record;
using Xylia.Preview.Project.Controls;
using Xylia.Preview.Project.Core.Item.Cell;

namespace Xylia.Preview.Project.Core.Item
{
	public partial class AttributePreview : PreviewControl
	{
		#region 构造
		public AttributePreview() => InitializeComponent();
		#endregion


		#region 接口方法
		public override void LoadData(IRecord record)
		{
			#region 读取属性
			//读取主属性
			var MainAbilityFixed = FileCache.Data.ItemRandomAbilitySlot[record.Attributes["main-ability-fixed"]];

			//读取子属性
			var SubAbilityFixed = FileCache.Data.ItemRandomAbilitySlot[record.Attributes["sub-ability-fixed"]];


			//获取随机子属性
			var SubAbilityRandomCount = record.Attributes["sub-ability-random-count"].ConvertToByte();
			var SubAbilityRandoms = new List<ItemRandomAbilitySlot>();
			for (int i = 1; i <= 5; i++)
			{
				if (record.ContainsAttribute("sub-ability-random-" + i, out string SubAbilityRandom))
					SubAbilityRandoms.AddItem(FileCache.Data.ItemRandomAbilitySlot[SubAbilityRandom]);
			}
			#endregion


			#region 处理前端
			int NextTop = 0;
			void AddAbilitySlot(ItemRandomAbilitySlot slot)
			{
				if (slot is null) return;
				AddControl(new AttributeInfoCell(slot));
			}
			void AddControl(Control c)
			{
				c.Location = new Point(0, NextTop);
				this.Controls.Add(c);

				NextTop = c.Bottom;
			}


			AddAbilitySlot(MainAbilityFixed);
			AddAbilitySlot(SubAbilityFixed);
			if (SubAbilityRandomCount > 0)
			{
				AddControl(new ContentPanel($"从以下属性中随机获得{SubAbilityRandomCount}个"));

				SubAbilityRandoms.ForEach(o => AddAbilitySlot(o));
			}


			this.Height = NextTop;
			this.Visible = NextTop != 0;
			#endregion
		}

		private void AttributePreview_Resize(object sender, EventArgs e)
		{
			foreach (var c in this.Controls.OfType<AttributeInfoCell>()) c.Width = this.Width;
		}
		#endregion
	}
}