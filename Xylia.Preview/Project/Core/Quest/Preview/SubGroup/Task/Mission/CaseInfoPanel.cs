﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

using CSCore;
using CSCore.SoundOut;

using FModel.Views.Resources.Controls.Aup;
using System.Linq;
using Xylia.Preview.Data.Package.Pak;
using Xylia.Preview.Data.Record;
using NPOI.POIFS.Crypt.Dsig;

namespace Xylia.Preview.Project.Core.Quest.Preview.SubGroup
{
	public partial class CaseInfoPanel : UserControl
	{
		public CaseInfoPanel()
		{
			InitializeComponent();
		}


		#region 字段
		public WaveOut SoundOut;

		public NpcTalkMessage NpcTalkMessage;

		public int StepIdx;

		public override string Text { get => contentPanel1.Text; set => contentPanel1.Text = value; }
		#endregion


		#region 方法
		private void CaseInfoPanel_Load(object sender, EventArgs e)
		{
			if (NpcTalkMessage.GetStepShow(StepIdx) != null)
				this.pictureBox1.Visible = true;
		}


		Thread thread;

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			thread?.Interrupt();
			thread = new Thread(t =>
			{
				//单独播放
				if (StepIdx > 1)
				{
					var data = GetWave(NpcTalkMessage.GetStepShow(StepIdx));
					if (data is null) this.pictureBox1.Enabled = false;
					else Play(data);
				}

				//全部播放
				else
				{
					List<byte[]> datas = new();
					for (int i = 1; i <= 30; i++)
					{
						var StepShow = NpcTalkMessage.GetStepShow(i);
						if (StepShow is null) break;

						datas.Add(GetWave(StepShow));
					}


					var Valid = datas.Where(data => data != null);
					if (!Valid.Any()) this.pictureBox1.Enabled = false;
					else
					{
						foreach (var data in Valid)
						{
							Thread.Sleep(Play(data));
							Thread.Sleep(1000);
						}
					}
				}
			});

			thread.Start();
		}

		public byte[] GetWave(string StepShow) => StepShow.GetUObject().GetWave(this.StepIdx - 1);


		/// <summary>
		/// 播放音频
		/// </summary>
		/// <param name="data"></param>
		public TimeSpan Play(byte[] data)
		{
			if (this.SoundOut.PlaybackState != PlaybackState.Stopped)
				this.SoundOut.Stop();

			var _waveSource = new CustomCodecFactory().GetCodec(data, "ogg");
			this.SoundOut.Initialize(_waveSource);
			this.SoundOut.Play();

			return this.SoundOut.WaveSource.GetLength();
		}
		#endregion
	}
}
