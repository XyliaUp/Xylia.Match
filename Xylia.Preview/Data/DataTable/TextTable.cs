using System.Text.RegularExpressions;

using Xylia.Extension;
using Xylia.Preview.Data.Record;
using Xylia.Preview.Properties.AnalyseSection;

namespace Xylia.Preview.Data
{
	public class TextTable : DataTable<Text>
	{
		protected override string ConfigContent => DataRes.TextData;


		private bool HasMessage = false;

		/// <summary>
		/// 获取文本
		/// </summary>
		/// <param name="Alias"></param>
		/// <returns></returns>
		public Text GetRecord(string Alias)
		{
			#region 初始化
			if (string.IsNullOrWhiteSpace(Alias)) return null;
			if (!this.HasData) this.Load();

			//如果仍然没有，则说明读取失败
			if (!this.HasData)
			{
				if (!HasMessage)
				{
					HasMessage = true;
					Tip.SendMessage("没有载入文本数据", true);
				}

				return null;
			}
			#endregion

			if (int.TryParse(Alias, out int MainID)) return this[MainID];
			else return this[Alias];
		}
	}
}



/// <summary>
/// 提供获取文本扩展方法
/// </summary>
public static class LocalText
{
	/// <summary>
	/// 获取对应汉化文本
	/// </summary>
	/// <param name="Alias"></param>
	/// <returns></returns>
	public static string GetText(this string Alias)
	{
		//快速DEBUG模式,阻止因汉化读取导致的久耗时
		if (false) return Alias;

		return FileCache.Data.TextData.GetRecord(Alias)?.GetText() ?? Alias;
	}

	/// <summary>
	/// 剪切文本
	/// </summary>
	/// <param name="Text"></param>
	/// <returns></returns>
	public static string CutText(this string Text)
	{
		if (Text is null) return null;

		var CopyTxt = new Regex("<font .*?>").Replace(Text, "");
		CopyTxt = new Regex("<image .*?>").Replace(CopyTxt, "");
		CopyTxt = CopyTxt.Replace("</font>", null).Decode();
		CopyTxt = new Regex(@"<\s*br\s*/\s*>").Replace(CopyTxt, "\n");

		//去除所有标签
		return new Regex(@"<.*?>").Replace(CopyTxt, "");
	}
}