using System;
using System.ComponentModel;
using System.Drawing;

using Xylia.Preview.Common.Interface;
using Xylia.Preview.Data.Record;
using Xylia.Preview.Project.Controls.PanelEx;


namespace Xylia.Preview.Project.Core.Item
{
	public partial class EventTimePreview : TitlePanel
	{
		#region 构造
		public EventTimePreview()
		{
			InitializeComponent();
		}
		#endregion

		#region 过期时间
		private DateTime m_EventExpirationTime = Convert.ToDateTime("2010-01-01 08:00:00");

		[Category("Time"), Description("过期时间")]
		public DateTime EventExpirationTime
		{
			get => this.m_EventExpirationTime;
			set
			{
				this.m_EventExpirationTime = value;

				//判断是否过期
				if (value < DateTime.Now)
				{
					this.pictureBox1.Visible = false;
					this.EventTime_FixedDate.Location = new Point(7, this.EventTime_FixedDate.Location.Y);

					this.EventTime_FixedDate.Text = $"过期 ({ value:yyyy年M月d日} 截止)";
					this.EventTime_FixedDate.ForeColor = Color.FromArgb(255, 88, 66);
				}
				else
				{
					this.pictureBox1.Visible = true;
					this.EventTime_FixedDate.Location = new Point(30, this.EventTime_FixedDate.Location.Y);

					this.EventTime_FixedDate.Text = $"可在{ value:yyyy年M月d日}定期维护前使用";
					this.EventTime_FixedDate.ForeColor = Color.White;
				}
			}
		}

		[Category("Time"), Description("过期时间文本")]
		public string EventExpirationTime_Info
		{
			get => m_EventExpirationTime.ToString();
			set
			{
				if (value != null) 
					EventExpirationTime = Convert.ToDateTime(value);
			}
		}
		#endregion


		#region 方法
		public override void LoadData(IRecord record)
		{
			ItemEvent Record = record as ItemEvent;

			this.Title = Record.Name2.GetText();
			this.EventExpirationTime = Record.EventExpirationTime;
		}
		#endregion
	}
}