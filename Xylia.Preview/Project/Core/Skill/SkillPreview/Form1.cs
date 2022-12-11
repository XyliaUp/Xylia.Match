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

		public Form1(Skill3 SkillData) 
		{
			InitializeComponent();
			this.SkillPreview.LoadData(SkillData);

			this.textBox1.Visible = true;

			this.Controls.Add(this.SkillPreview);
			this.SkillPreview.Refresh();

			this.Text = "查看技能 " + SkillData.Alias;
		}	  


		public SkillPreview SkillPreview = new();

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			this.Text = "查看技能 " + this.textBox1.Text;

			this.SkillPreview.LoadData(this.textBox1.Text);
			Ini.WriteValue("Option", "SkillPreview_Rule", this.textBox1.Text);
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}
	}
}