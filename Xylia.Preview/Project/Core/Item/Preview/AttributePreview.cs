using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

using Xylia.Extension;
using Xylia.Preview.Project.Common.Interface;
using Xylia.Preview.Project.Core.Item.Cell;

namespace Xylia.Preview.Project.Core.Item
{
	public partial class AttributePreview : PreviewControl, IPreview
	{
		#region 构造
		public AttributePreview()
		{
			InitializeComponent();

			this.BackColor = Color.Transparent;
		}
		#endregion


		#region 接口方法
		bool IPreview.INVALID() => false;

		void IPreview.LoadData(IRecord record)
		{
			var InfoCells = new List<AttributeInfoCell>();

			//读取主属性
			var MainAbilityFixed = FileCache.Data.ItemRandomAbilitySlot.GetInfo(record.Attributes["main-ability-fixed"]);
			if (MainAbilityFixed != null) InfoCells.Add(new AttributeInfoCell(MainAbilityFixed));


			#region 读取子属性
			var SubAbilityFixed = FileCache.Data.ItemRandomAbilitySlot.GetInfo(record.Attributes["sub-ability-fixed"]);
			if (SubAbilityFixed != null) InfoCells.Add(new AttributeInfoCell(SubAbilityFixed));


			//获取随机子属性数量
			if (record.ContainsAttribute("sub-ability-random-count", out string Value) && byte.TryParse(Value.ToString(), out byte SubAbilityRandomCount))
			{

			}

			for (int i = 1; i <= 5; i++)
			{
				if (record.ContainsAttribute("sub-ability-random-" + i, out string SubAbilityRandomAlias))
				{
					var SubAbilityRandom = FileCache.Data.ItemRandomAbilitySlot.GetInfo(SubAbilityRandomAlias);
					if(SubAbilityRandom != null) InfoCells.Add(new AttributeInfoCell(SubAbilityRandom));
				}
			}
			#endregion

			#region 处理前端
			this.Visible = InfoCells.Any();
			if (this.Visible)
			{
				this.SuspendLayout();
				int NextTop = 0;

				foreach (var cell in InfoCells)
				{
					if (!this.Controls.Contains(cell)) this.Controls.Add(cell);

					cell.Location = new Point(0, NextTop);
					cell.Width = this.Width;
					cell.Refresh();

					NextTop = cell.Bottom;
				}

				this.Height = NextTop;
				this.ResumeLayout();
			}
			#endregion
		}
		#endregion

		private void AttributePreview_Resize(object sender, EventArgs e)
		{
			foreach (var c in this.Controls.OfType<AttributeInfoCell>())
				c.Width = this.Width;
		}
	}
}
