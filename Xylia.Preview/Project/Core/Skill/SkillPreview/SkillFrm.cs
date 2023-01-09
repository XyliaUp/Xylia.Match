using System;
using System.Windows.Forms;

using Xylia.Configure;
using Xylia.Preview.Data.Record;

namespace Xylia.Preview.Project.Core.Skill
{
	public partial class SkillFrm : Form
	{
		public SkillFrm()
		{
			InitializeComponent();
			this.textBox1.Text = Ini.ReadValue("Preview", "skill#searchrule");

			this.Controls.Add(this.SkillPreview);
			this.SkillPreview.Refresh();
		}

		public SkillFrm(Skill3 Skill) 
		{
			InitializeComponent();
			this.Controls.Add(this.SkillPreview);
			this.textBox1.Visible = true;

			this.LoadData(Skill);
		}	  




		public SkillPreview SkillPreview = new();

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			Ini.WriteValue("Preview", "skill#searchrule", this.textBox1.Text);
			this.LoadData(FileCache.Data.Skill3[this.textBox1.Text]);
		}

		public void LoadData(Skill3 Skill)
		{
			this.Text = "查看技能 " + Skill?.Alias;

			this.SkillPreview.LoadData(Skill);
			this.SkillPreview.Refresh();
		}
	}
}