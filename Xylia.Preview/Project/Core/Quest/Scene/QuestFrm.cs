using System.Windows.Forms;

using Xylia.Preview.Project.Core.Quest.Preview;

using QuestData = Xylia.bns.Modules.Quest.Entities.Quest;

namespace Xylia.Preview
{
	public partial class QuestFrm : Form
	{
		public QuestFrm()
		{
			InitializeComponent();

			this.QuestPreview = new QuestPreview();
			this.Controls.Add(this.QuestPreview);
		}

		public QuestFrm(QuestData QuestData) : this()
{
			this.QuestPreview.Data = QuestData;
		}
	}
}
