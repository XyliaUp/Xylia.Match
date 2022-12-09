using System;
using System.Threading;
using System.Windows.Forms;

using HZH_Controls.Forms;

using Xylia.Extension;

namespace Xylia.Match.Util.Paks
{
	public sealed class IconTextureMatch
	{
		#region 字段
		/// <summary>
		/// 起始时活动
		/// </summary>
		public EventHandler Start;

		/// <summary>
		/// 结束时活动
		/// </summary>
		public EventHandler Finish;


		public bool CheckFormat = true;

		/// <summary>
		/// 格式选择器
		/// </summary>
		public string FormatSelect;
		#endregion

		#region 方法
		public void StartMatch(Textures.IconOutBase IconOutBase, ref Thread RunThread, Action<string> action)
		{
			#region 初始化
			//清理tip
			FrmTips.ClearTips();
			if (RunThread != null)
			{
				if (new FrmWithOKCancel1() { Content = "是否确认强制结束？" }.ShowDialog() != DialogResult.OK) return;

				try
				{
					RunThread.Interrupt();
					RunThread = null;

					action($"任务已强制结束");
				}
				catch
				{

				}

				return;
			}

			if (CheckFormat && (FormatSelect.IsNull() || !FormatSelect.Contains("[")))
			{
				Xylia.Tip.Message("输出格式必须至少包含一个特殊规则");
				return;
			}
			#endregion

			#region 执行
			RunThread = new Thread((ThreadStart)delegate
			{
				//触发开始事件
				Start?.Invoke(null, null);

				try
				{
					DateTime d1 = DateTime.Now;

					using (IconOutBase)
					{
						//初始化
						IconOutBase.StartInit();

						//核心方法 - 存储图标
						IconOutBase.SaveAsPicture(FormatSelect);
					}

					TimeSpan Ts = DateTime.Now - d1;
					action($"任务已经全部结束！ 共计 { Ts.Hours }小时 { Ts.Minutes }分 { Ts.Seconds }秒。");
				}
				catch (ThreadAbortException) { return; }
				catch (Exception ee)
				{
					action("由于发生了错误，进程已提前结束。");

					Xylia.Tip.Stop(ee.ToString());
					Console.WriteLine(ee);
				}
				finally
				{
					//结束事件
					Finish?.Invoke(null, null);
					MySet.ClearMemory();
				}
			});
			#endregion

			RunThread.Start();
		}
		#endregion
	}
}
