﻿using System;
using System.Windows.Forms;

using Xylia.Extension;

using static Xylia.Preview.Data.Record.MapUnit;

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

			int AttackPower = 1593;
			int DamageValue = 16000;
			double AttackAttributePercent = 2.2203 * 0.97;

			var result = AttackPower * (DamageValue * 0.01) * AttackAttributePercent;

			System.Diagnostics.Debug.WriteLine(0.985 * result);
			System.Diagnostics.Debug.WriteLine(1.015 * result);

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
	}
}
