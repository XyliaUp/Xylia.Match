using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;

namespace Xylia.Match.Util.Game.ItemData.Util
{
	/// <summary>
	/// 配置文件特殊结构
	/// </summary>
	public struct ChvInfo
	{
		public string Title;

		public string Verison;

		public string Publish;
	}


	public class ChvLoad
	{
		/// <summary>
		/// 读取旧数据
		/// </summary>
		/// <param name="Show"></param>
		/// <returns></returns>
		public static HashSet<int> LoadData(string ChvPath, Action<string> action)
		{
			if (string.IsNullOrWhiteSpace(ChvPath)) return null;


			var vs = new HashSet<int>();

			//本地文件
			if (File.Exists(ChvPath))
			{
				var rd = File.OpenText(ChvPath);

				string line;
				while ((line = rd.ReadLine()) != null)
				{
					if (int.TryParse(line.Replace("\"", ""), out int @int)) vs.Add(@int);
				}

				rd.Close();  // 关闭文件
			}

			//网络文件
			else
			{
				ChvInfo ChvInfo = new();


				action?.Invoke("正在尝试下载并解析云端配置文件");


				string list = Encoding.UTF8.GetString(new HttpClient().GetByteArrayAsync(ChvPath).Result).Replace("\"", "");
				foreach (var Str in new List<string>(list.Split(new[] { "\r\n" }, StringSplitOptions.None)))
				{
					if (Str.Contains('='))
					{
						ChvInfo_Creat(ChvInfo, Str);
						continue;
					}

					if (int.TryParse(Str, out int @int)) vs.Add(@int);
				}

				string Msg = null;
				if (!string.IsNullOrEmpty(ChvInfo.Title)) Msg += $"目前加载的是「{ ChvInfo.Title }」";
				if (!string.IsNullOrEmpty(ChvInfo.Verison)) Msg += $"（版本{ ChvInfo.Verison + ChvInfo.Publish ?? "，发布于" + ChvInfo.Publish }）\n";
				if (!string.IsNullOrEmpty(Msg)) action?.Invoke(Msg);
			}



			if (vs.Count == 0) return null;

			action?.Invoke($"共加载到{ vs.Count }个历史版本道具，将会自动跳过");
			return vs;
		}

		private static void ChvInfo_Creat(ChvInfo ChvInfo, string Str)
		{
			if (Str.Contains("Verison")) ChvInfo.Verison = Str.Replace("Verison", null).Replace("=", null).Replace(" ", null);
			else if (Str.Contains("Publish")) ChvInfo.Publish = Str.Replace("Publish", null).Replace("=", null).Replace(" ", null);
			else if (Str.Contains("Title")) ChvInfo.Title = Str.Replace("Title", null).Replace("=", null).Replace(" ", null);
		}
	}
}