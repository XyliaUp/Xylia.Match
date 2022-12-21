
using Xylia.bns.Modules.DataFormat.Analyse.Output;
using Xylia.Extension;
using Xylia.Preview.Common.Interface.RecordAttribute;

namespace Xylia.Preview.Common.Interface
{
	/// <summary>
	/// 通用化配置文件接口
	/// </summary>
	public class IRecord : IArgParam
	{
		#region 设定字段
		public IAttributeCollection Attributes;

		public bool ContainsAttribute(string AttrName, out string AttrValue) => this.Attributes.ContainsName(AttrName, out AttrValue);


		public void SetAttribute(ObjectOutput o, bool SetMember, bool ShowDebugInfo)
		{
			this.Attributes = new OutputData(o);

			//向成员赋值
			if (SetMember)
			{
				foreach (var Attr in o.Cells)
					this.SetMember(Attr.Alias, Attr.OutputVal, true, ShowDebugInfo ? null : true);
			}
		}
		#endregion




		#region 属性字段
		/// <summary>
		/// 序号
		/// </summary>
		public int Index;

		/// <summary>
		/// 编号
		/// </summary>
		public virtual int ID => int.TryParse(this.Attributes?["id"], out int @int) ? @int : (this.Index + 1);


		/// <summary>
		/// IconOut 需要使用字段
		/// </summary>
		public string alias;

		/// <summary>
		/// 别名
		/// </summary>
		public virtual string Alias => alias ?? this.Attributes?["alias"];
		#endregion


		#region 接口字段
		public override string ToString() => this.GetType().Name + ":" + (this.Alias ?? this.ID.ToString());

		public virtual object ParamTarget(string ParamName)
		{
			//返回自身
			if (ParamName == this.GetType().Name) return this;

			//返回对象名称
			if (ParamName == "name2" && this is IName @name) return name.NameText();


			//返回实例数值
			var Member = this.GetMemberInfo(ParamName, true);
			if (Member != null) return Member.GetValue(this);

			//如果仍然没有结果，直接返回对应的参数信息
			return this.Attributes[ParamName];
		}
		#endregion
	}
}
