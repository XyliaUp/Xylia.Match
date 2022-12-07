using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xylia.Preview.Project.Core.Item.Util
{
	/// <summary>
	/// 自定义信息
	/// </summary>
	public class MyInfo
	{
		public MyInfo(string Text, string Tag = null)
		{
			this.Text = Text;
			this.Tag = Tag;
		}


		public string Text;

		public string Tag;


		public bool INVALID => string.IsNullOrWhiteSpace(this.Text);
	}
}
