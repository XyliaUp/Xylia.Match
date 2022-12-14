using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

using Xylia.Extension;
using Xylia.Preview.Project.Core.Skill;

namespace Xylia.Preview
{
	public partial class DebugFrm : Form
	{
		public DebugFrm()
		{
			InitializeComponent();
		}

		private void DebugFrm_Load(object sender, EventArgs e)
		{
			//this.contentPanel1.Text = "<p justification=\"true\" justificationtype=\"linefeedbywidgetarea\"><link id=\"none\"/> </p><p horizontalalignment=\"center\"><br/><image enablescale=\"false\" imagesetpath=\"00027918.InterD_ChungGakjiBu\"/><br/><image enablescale=\"true\" imagesetpath=\"00009499.Field_Boss\" scalerate=\"1.4\"/>铁傀王<br/><br/>中原的海盗组织——冲角团的平南舰队支部。<br/>支部长是啸四海。</p>";

			Debug.WriteLine(SkillPreview.GetDamageInfo(16000));
			//Debug.WriteLine(FileCache.Data.Effect["Constellation_Effect_StarSong"].Attributes);


			this.pictureBox2.Image = Project.Core.Item.Scene.ItemFrm.LoadCardImage(Resources.Resource_BNSR.CollectionCard_3D_214_Img, 7);
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			//var data = "/Game/FaceFXImporter/220622/q_2209_2_voice_1_show.q_2209_2_voice_1_show".GetUObject().GetWave();
			//if (data is null) return;
			//var _waveSource = new CustomCodecFactory().GetCodec(data, "ogg");
			//var _soundOut = new WaveOut() { Latency = 100 };
			//_soundOut.Initialize(_waveSource);
			//_soundOut.Play();



			//this.Controls.Remove<CaseInfoPanel>();
			//int height = 25;
			//var cs = MissionPanel.LoadTalkMessage(new Xylia.bns.Modules.GameData.CommonTable.NpcResponse(this.textBox1.Text), new WaveOut());

			//foreach (var o in cs)
			//{
			//	if (!this.Controls.Contains(o)) this.Controls.Add(o);

			//	o.Location = new Point(GroupBase.ContentStartX + 10, height);
			//	height = o.Bottom;
			//}
		}

		private void pictureBox2_Click(object sender, EventArgs e)
		{

		}
	}
}