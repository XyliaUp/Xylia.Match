using System.Windows.Forms;

namespace Xylia.Preview.Common.Interface
{
	public partial class PreviewControl : UserControl, IPreview
	{
		public virtual bool INVALID() => !this.Visible;

		public virtual void LoadData(IRecord record)
		{

		}
	}


	/// <summary>
	/// 预览组件统一接口
	/// </summary>
	public interface IPreview
	{
		/// <summary>
		/// 指示是无效控件
		/// </summary>
		/// <returns></returns>
		bool INVALID();

		/// <summary>
		/// 加载数据
		/// </summary>
		/// <param name="record"></param>
		void LoadData(IRecord record);
	}
}