using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using CSCore.SoundOut;

using Xylia.bns.Modules.GameData.Enums;
using Xylia.bns.Modules.Quest.Entities;

namespace Xylia.Preview.Project.Core.Quest.Preview.SubGroup
{
	/// <summary>
	/// 课题组
	/// </summary>
	public partial class MissionStepPanel : UserControl
	{
		#region 构造
		public MissionStepPanel()
		{
			InitializeComponent();

			this.MissionDemand.Visible = true;
			this.Refresh();
		}
		#endregion


		#region 字段
		public void LoadData(MissionStep MissionStep, WaveOut SoundOut)
		{
			this.Content_StepID.Text = "● ";
			this.MissionDemand.Text = null;


			#region 黄字描述部分
			bool HasDesc = !string.IsNullOrWhiteSpace(MissionStep.Desc);
			this.Panel_TaskDesc.Visible = HasDesc;
			if (HasDesc) this.Panel_TaskDesc.Text = MissionStep.Desc.GetText();
			#endregion

			#region 进度需求信息
			if (this.MissionDemand.Visible = MissionStep.Missions.Count > 1)
			{
				if (MissionStep.CompletionType == Op2.or) this.MissionDemand.Text += $"完成下列任一课题";
				else if (MissionStep.CompletionType == Op2.and)
				{
					this.MissionDemand.Text += $"完成下列所有课题";
					this.MissionDemand.SetToolTip("对于同步骤中的不同课题，进度同时计算");
				}
			}
			#endregion

			#region 遍历课题集合
			foreach (var Mission in MissionStep.Missions)
			{
				var MissionPanel = new MissionPanel();
				MissionPanel.LoadData(Mission, SoundOut);

				this.Controls.Add(MissionPanel);
			}
			#endregion

			this.Refresh();
		}
		#endregion


		#region 方法
		public override void Refresh()
		{
			#region 初始化
			base.Refresh();
			int LocY = 0;

			if (this.MissionDemand.Visible)
			{
				LocY = this.MissionDemand.Bottom;
			}
			#endregion

			#region 计算课题内容位置
			foreach (var MissionCtl in this.Controls.OfType<MissionPanel>().OrderBy(c => (byte)c.Tag))
			{
				MissionCtl.Location = new Point(15, LocY);
				LocY = MissionCtl.Bottom;
			}
			#endregion

			if (this.Panel_TaskDesc.Visible)
			{
				this.Panel_TaskDesc.Location = new Point(0, LocY);
				LocY = this.Panel_TaskDesc.Bottom;
			}

			//设置整体高度
			this.Height = LocY + 5;
		}
		#endregion
	}
}
