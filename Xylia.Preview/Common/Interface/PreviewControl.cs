using System.Windows.Forms;

namespace Xylia.Preview.Common.Interface
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