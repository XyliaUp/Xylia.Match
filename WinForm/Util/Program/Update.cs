using System.Windows.Forms;
using System;
using Xylia.Extension;
using System.Xml;
using Xylia.Match.Properties;
using Xylia.Windows.Forms;

namespace Xylia.Match.Util
{
	public class Update
	{
		private Xylia.Sys.Update m_UpdateInfo = null;

		public Xylia.Sys.Update UpdateInfo
		{
			get
			{
				if (this.m_UpdateInfo is null)
				{
					this.m_UpdateInfo = new Xylia.Sys.Update(Url.GetUpdate, "Match", Program.PublishVersion);
				}

				return this.m_UpdateInfo;
			}
		}


		public bool Compare(bool Show = true)
		{
			try
			{
				string DownUri = UpdateInfo.result.downPath;
				if (!DownUri.IsNull())
				{
					Public.ExistNewVer = true;

					//如果要求强制更新
					if (UpdateInfo.result.ForceUpdate)
					{
						Xylia.Update.Updater.ReleaseUpdater(DownUri, Application.ExecutablePath, UpdateInfo.result.Content, UpdateInfo.result.ForceName, true, true);
					}
					else
					{
						if (MessageBox.Show("发现新版本更新。是否查看更新内容？", "提示消息", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
						{
							var announcement = new Announcement(UpdateInfo.result.Content ?? "暂无说明");
							announcement.OkClicked += (o, a) =>
							{
								Xylia.Update.Updater.ReleaseUpdater(DownUri, Application.ExecutablePath, UpdateInfo.result.Content, UpdateInfo.result.ForceName, false, true);
							};

							announcement.OkText = "开始更新";
							announcement.TilteText = "更新内容简介";
							announcement.ShowDialog();
						}
					}
					return true;
				}
				else return false;
			}
			catch (Exception ee)
			{
				Console.WriteLine(ee);

				if (Show)
				{
					Tip.Message($"检测更新失败。\n\n错误原因:  {ee.Message}");
				}
			}

			return false;
		}
	}


	public static class Public
	{
		/// <summary>
		/// 存在新版本
		/// </summary>
		public static bool ExistNewVer = false;
	}
}
