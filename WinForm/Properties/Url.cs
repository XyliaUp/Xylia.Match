using System.IO;
using System.Net;

using Xylia.Net.Youdao;

namespace Xylia.Match.Properties
{
	public static class Url
	{
		#region 定义Url
		/// <summary>
		/// 服务端描述文件（正式版本）路径
		/// </summary>
		static string Update { get; set; } = NoteShare.UrlCombine("0BC18EB2C0324765899B28B0CF10E756", "8249959c80dcfe0767cbd44ff24591e8");

		/// <summary>
		/// 服务端描述文件（体验版本）路径
		/// </summary>
		static string Update_Exp { get; set; } = NoteShare.UrlCombine("460F45DF993B45E1A7A0CB3023520EF7", "823ae65988ad8ff2308409e9e487c45d");

		/// <summary>
		/// 服务端描述文件（测试版本）路径
		/// </summary>
		public static string Update_Test { get; set; } = @"file://C:\Users\Xylia\Desktop/Update.xml";


		public static string PublicConfig { get; set; } = NoteShare.UrlCombine("DDE6ACC65FF647C99B9D846FDAFBFB4B", "741857554343170134b88971a717c941");
		#endregion


		/// <summary>
		/// 获得更新路径
		/// </summary>
		/// <returns></returns>
		public static string GetUpdate
		{
			get
			{
				try
				{
					var Myrq = (HttpWebRequest)WebRequest.Create("http://note.youdao.com/yws/api/personal/file/B1F5326DD4B042ADA139E004BB91F7FE?method=download&inline=true&shareKey=b418248a78c82d48b02ba6d0ad2b0ca7");
					Myrq.UserAgent = null;
					Myrq.UseDefaultCredentials = false;

					var resStream = Myrq.GetResponse().GetResponseStream();
					var sr = new StreamReader(resStream, System.Text.Encoding.Default);

					foreach(var line in (sr.ReadToEnd() + "\n").Split('\n'))
					{
						if (line.Contains("="))
						{
							var Info = line.Split('=');
							if (Info.Length >= 2)
							{
								string Name = Info[0];
								string Key = Info[1];

								string Key1 = null, Key2 = null;

								if (Key.Contains(","))
								{
									Key1 = Key.Split(',')[0];
									Key2 = Key.Split(',')[1];
								}

								if (Name == "public") PublicConfig = string.IsNullOrWhiteSpace(Key1) ? Key : NoteShare.UrlCombine(Key1, Key2);
								if (Name == "update") Update = string.IsNullOrWhiteSpace(Key1) ? Key : NoteShare.UrlCombine(Key1, Key2);
								if (Name == "test") Update_Exp = string.IsNullOrWhiteSpace(Key1) ? Key : NoteShare.UrlCombine(Key1, Key2);
							}
						}
					}

					resStream.Close();
					sr.Close();
				}
				catch
				{

				}

				return Update;
			}
		}
	}
}
