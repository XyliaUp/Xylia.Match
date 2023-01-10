using System.Windows.Forms;

namespace Xylia.Preview.Common.Interface
{
	public partial class PreviewControl : UserControl, IPreview
	{
		/// <summary>
		/// 指示是无效控件
		/// </summary>
		/// <returns></returns>
		public virtual bool INVALID() => !this.Visible;

		/// <summary>
		/// 加载数据
		/// </summary>
		/// <param name="record"></param>
		public virtual void LoadData(IRecord record)
		{

		}



		/// <summary>
		/// 通过 IRecord 对象加载组件
		/// </summary>
		/// <typeparam name="TRecord"></typeparam>
		/// <param name="Record"></param>
		/// <returns></returns>
		public PreviewControl LoadInfo<TRecord>(TRecord Record) where TRecord : IRecord, new()
		{
			if (Record is null) return null;

			//System.Diagnostics.Debug.WriteLine($"[{ Record.GetType() }] { Record.Alias }");

			//传递额外信息 (注意要在LoadData方法之前)
			this.LoadData(Record);

			//判断是否有效
			return this.INVALID() ? null : this;
		}
	}


	/// <summary>
	/// 预览组件统一接口
	/// </summary>
	public interface IPreview
	{
		///// <summary>
		///// 指示是无效控件
		///// </summary>
		///// <returns></returns>
		//bool INVALID();

		///// <summary>
		///// 加载数据
		///// </summary>
		///// <param name="record"></param>
		//void LoadData(IRecord record);
	}
}