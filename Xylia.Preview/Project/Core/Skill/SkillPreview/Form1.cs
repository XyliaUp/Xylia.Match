using System;
using System.Windows.Forms;

using Xylia.Configure;
using Xylia.Preview.Data.Record;

namespace Xylia.Preview.Project.Core.Skill
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			this.textBox1.Text = Ini.ReadValue("Option", "SkillPreview_Rule");

			this.Controls.Add(this.SkillPreview);
			this.SkillPreview.Refresh();
		}

		public Form1(Skill3 Skill) 
		{
			InitializeComponent();
			this.Controls.Add(this.SkillPreview);
			this.textBox1.Visible = true;

			this.LoadData(Skill);
		}	  


		public SkillPreview SkillPreview = new();

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			Ini.WriteValue("Option", "SkillPreview_Rule", this.textBox1.Text);
			this.LoadData(FileCache.Data.Skill3[this.textBox1.Text]);
		}


		public void LoadData(Skill3 Skill)
		{
			this.Text = "查看技能 " + Skill.Alias;

			this.SkillPreview.LoadData(Skill);
			this.SkillPreview.Refresh();
		}
	}
}