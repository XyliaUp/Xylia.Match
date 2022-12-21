using System;
using System.Drawing;
using System.Windows.Forms;

using Xylia.bns.Modules.GameData.Enums;
using Xylia.Preview.Data.Package.Pak;

namespace Xylia.Preview.Project.Core.Item.Preview
{
	public partial class JobStyleSelect : UserControl
	{
		public JobStyleSelect()
		{
			InitializeComponent();
		}


		#region 委托 
		//定义委托
		public delegate void JobStyleChangedHandle(object sender, JobStyleChangedEvent e);

		/// <summary>
		/// 奖励组选择事件
		/// </summary>
		public event JobStyleChangedHandle JobStyleChanged;
		#endregion


		#region 方法
		/// <summary>
		/// 加载派系图标
		/// </summary>
		/// <param name="job"></param>
		public void LoadStyleIcon(JobSeq job)
		{
			if (job == JobSeq.JobNone) return;

			foreach (var o in FileCache.Data.JobStyle.Where(o => o.Job == job))
			{
				var icon = o.IntroduceJobStyleIcon.GetUObject().GetImage();
				if (icon is null) continue;

				switch (o.jobStyle)
				{
					case JobStyleSeq.Advanced1: SetImage(this.JobStyle6, icon); break;
					case JobStyleSeq.Advanced2: SetImage(this.JobStyle7, icon); break;
					case JobStyleSeq.Advanced3: SetImage(this.JobStyle8, icon); break;
					case JobStyleSeq.Advanced4: SetImage(this.JobStyle9, icon); break;
					case JobStyleSeq.Advanced5: SetImage(this.JobStyle10, icon); break;
				}
			}
		}

		private void SetImage(PictureBox pictureBox, Bitmap bitmap)
		{
			pictureBox.Image = bitmap;
			pictureBox.Visible = true;
		}



		public void SelectDefault() => JobStyleChanged?.Invoke(null, new(JobStyleSeq.Advanced1));

		private void JobStyle6_Click(object sender, EventArgs e) => JobStyleChanged?.Invoke(sender, new(JobStyleSeq.Advanced1));
		private void JobStyle7_Click(object sender, EventArgs e) => JobStyleChanged?.Invoke(sender, new(JobStyleSeq.Advanced2));
		private void JobStyle8_Click(object sender, EventArgs e) => JobStyleChanged?.Invoke(sender, new(JobStyleSeq.Advanced3));
		private void JobStyle9_Click(object sender, EventArgs e) => JobStyleChanged?.Invoke(sender, new(JobStyleSeq.Advanced4));
		private void JobStyle10_Click(object sender, EventArgs e) => JobStyleChanged?.Invoke(sender, new(JobStyleSeq.Advanced5));
		#endregion
	}





	/// <summary>
	/// 职业派系变更事件
	/// </summary>
	public class JobStyleChangedEvent : EventArgs
	{
		public JobStyleChangedEvent(byte JobStyle)
		{
			this.JobStyle = (JobStyleSeq)JobStyle;
		}

		public JobStyleChangedEvent(JobStyleSeq JobStyle)
		{
			this.JobStyle = JobStyle;
		}

		public JobStyleSeq JobStyle;
	}
}
