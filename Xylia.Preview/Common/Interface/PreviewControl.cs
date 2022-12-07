﻿using System.Collections.Generic;
using System.Windows.Forms;

using Xylia.bns.Modules.GameData.Enums;

namespace Xylia.Preview.Project.Common.Interface
{
	public partial class PreviewControl : UserControl
	{
		
	}

	/// <summary>
	/// 预览组件统一接口
	/// </summary>
	public interface IPreview
	{
		/// <summary>
		/// 加载数据
		/// </summary>
		/// <param name="record"></param>
		void LoadData(IRecord record);

		/// <summary>
		/// 指示是无效控件
		/// </summary>
		/// <returns></returns>
		bool INVALID();
	}
}
