using System.Windows.Forms;

using Xylia.Preview.Data.Record;

namespace Xylia.Preview.Project.Core.Skill
{
	public partial class TraitTierCell : UserControl
	{
		public TraitTierCell()
		{
			InitializeComponent();
		}


		private SkillTrait _skillTrait;

		public SkillTrait SkillTrait
		{
			get => this._skillTrait;
			set
			{
				this._skillTrait = value;
				if (value is null) return;

				this.contentPanel1.Text = value.Name2.GetText();
				this.pictureBox1.Image = value.Icon.GetIcon();
			}
		}
	}
}
