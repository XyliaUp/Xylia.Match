using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;
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

			//Debug.WriteLine(FileCache.Data.Npc["CH_PB_WantedCoinShop_0001_Exchange_01"]?.Attributes);
			//Debug.WriteLine(FileCache.Data.Npc.Where(o => o.Attributes["store2-1"] == "CH_BoardGacha_Grocery", true).FirstOrDefault());

			Debug.WriteLine(SkillPreview.GetDuration(8000));


			//Xylia.Preview.Data.Package.Pak.Test.Scene();
			//Debug.WriteLine(FileCache.Data.GameData.BNSDat.FileTableList.Find(o => o.FilePath == "attractiontimeeffectdata.xml").XmlDocument.OuterXml);
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			Debug.WriteLine(FileCache.Data.TextData[this.textBox1.Text]);


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
	}
}