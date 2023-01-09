using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

using CSCore;
using CSCore.SoundOut;

using FModel.Views.Resources.Controls.Aup;

using Xylia.Preview.Data.Package.Pak;
using Xylia.Preview.Data.Record;
using Xylia.Preview.Resources;

namespace Xylia.Preview.Project.Core.Quest.Preview.SubGroup
{
	public partial class CaseInfoPanel : UserControl
	{
		#region 构造
		public CaseInfoPanel()
		{
			InitializeComponent();
		}
		#endregion

		#region 字段
		public WaveOut SoundOut;

		public NpcTalkMessage NpcTalkMessage;

		public int StepIdx;

		public override string Text { get => ContentPanel.Text; set => ContentPanel.Text = value; }
		#endregion


		#region 方法
		private void CaseInfoPanel_Load(object sender, EventArgs e)
		{
			if (NpcTalkMessage.GetStepShow(StepIdx) != null)
				this.pictureBox1.Visible = true;
		}



		private static Thread thread;

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			thread?.Interrupt();
			thread = new Thread(t =>
			{
				try
				{
					//单独播放
					if (StepIdx > 1)
					{
						var data = GetWave(NpcTalkMessage.GetStepShow(StepIdx), StepIdx);
						if (data is null) DisableBtn();
						else Play(data);
					}

					//全部播放
					else
					{
						List<byte[]> datas = new();
						for (int idx = 1; idx <= 30; idx++)
						{
							var StepShow = NpcTalkMessage.GetStepShow(idx);
							if (StepShow is null) break;

							datas.Add(GetWave(StepShow, idx));
						}


						var Valid = datas.Where(data => data != null);
						if (!Valid.Any()) DisableBtn();

						foreach (var data in Valid)
						{
							Thread.Sleep(Play(data));
							Thread.Sleep(800);
						}
					}
				}
				catch
				{

				}
			});

			thread.Start();
		}

		private void DisableBtn()
		{
			this.pictureBox1.Enabled = false;
			this.pictureBox1.Image = Resource_Common.Image2;
		}

		/// <summary>
		/// 获取音频数据
		/// </summary>
		/// <param name="StepShow"></param>
		/// <param name="StepIdx"></param>
		/// <returns></returns>
		public static byte[] GetWave(string StepShow, int StepIdx) => StepShow.GetUObject().GetWave(StepIdx - 1);

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
