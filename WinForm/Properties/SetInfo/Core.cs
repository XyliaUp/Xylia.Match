using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;

using Xylia.Extension;


namespace Xylia.Match.Properties.SetInfo
{
	/// <summary>
	/// 请注意：发布设置中请勿勾选代码优化，否则会获取不到对应堆栈
	/// </summary>
	public class Core : Set.ISetInfo
	{
		/// <summary>
		/// 输出文件夹目录
		/// </summary>
		public string Folder_Output { get => LoadInfo(); set => SaveInfo(value); }

		public string Icon_ResultPath { get => LoadInfo(); set => SaveInfo(value); }

		public string Icon_Chv { get => LoadInfo(); set => SaveInfo(value); }


		/// <summary>
		/// 物品预览功能工作路径
		/// </summary>
		public string Folder_PreviewFiles { get => LoadInfo(); set => SaveInfo(value); }

		public string Folder_Game_Bns { get => LoadInfo(); set => SaveInfo(value); }

		public string Loading_File { get => LoadInfo(); set => SaveInfo(value); }

		public string Local_SourcePath { get => LoadInfo(); set => SaveInfo(value); }







		public string UpkExtract_Folder { get => LoadInfo(); set => SaveInfo(value); }

		public string UpkExtract_Output { get => LoadInfo(); set => SaveInfo(value); }

		public string Sound_ResultPath { get => LoadInfo(); set => SaveInfo(value); }

		public int? Icon_FilterIndex1
		{
			get => LoadInfo_Int();
			set => SaveInfo(value);
		}

		public int? Quest_Select
		{
			get => LoadInfo_Int();
			set => SaveInfo(value);
		}
	}
}