using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Xylia.Preview.Project.Controls;


namespace Xylia.Preview.Project.Core.Skill
{
	public sealed class SkillTooltipPanel : Panel
	{
		public List<List<ContentPanel>> Tooltips = new();

		public override void Refresh()
		{
			this.Controls.Clear();

			int ContentX = 0, ContentY = 0;
			foreach (var line in this.Tooltips)
			{
				var LineBottom = 0;
				foreach (var o in line)
				{
					if (!this.Controls.Contains(o))
						this.Controls.Add(o);

					o.Location = new Point(ContentX, ContentY);
					o.Refresh();

					ContentX = o.Right + 1;
					LineBottom = Math.Max(LineBottom, o.Bottom);
				}

				ContentX = 0;
				ContentY = LineBottom + 5;
			}

			this.Height = ContentY;
		}
	}
}