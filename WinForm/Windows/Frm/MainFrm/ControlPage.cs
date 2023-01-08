using System.Windows.Forms;

namespace Xylia.Match.Windows
{
	public class ControlPage
	{
		public ControlPage(string Text,Control Content)
		{
			this.Text = Text;
			this.Content = Content;

			this.Key = this.Content.GetType().Name;
		}


		public string Key;
		public string Text;
		public Control Content;
	}
}