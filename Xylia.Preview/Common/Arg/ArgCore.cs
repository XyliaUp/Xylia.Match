using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

using Xylia.Attribute;
using Xylia.Extension;
using Xylia.Preview.Common.Cast;
using Xylia.Preview.Data.Record;
using Xylia.Preview.Common.Interface;
using Xylia.Preview.Project.Controls;

using GameSeq = Xylia.bns.Modules.GameData.Enums;

namespace Xylia.Preview.Public.Attribute.arg
{
	/// <summary>
	/// 参数核心类
	/// </summary>
	public static class ArgCore
	{
		/// <summary>
		/// 处理数据
		/// 处理失败应返回 Null
		/// </summary>
		/// <param name="Attrs">属性</param>
		/// <param name="Params">所有参数</param>
		public static object Handle(StringAttributeCollection Attrs, List<object> Params)
		{
			#region 初始化
			//获取p参数
			string p = Attrs["p"];
			if (!p.Contains(':')) return null;

			var ps = p.Split(':');   //拆分目标
			var CurParamInfo = ps[0];        //当前处理对象名称
			#endregion

			#region 获取执行对象
			object ExecObj; 

			//指向特定对象
			if (CurParamInfo == "id")
			{
				ExecObj = Attrs["id"].CastObject();
				if (ExecObj is null)
				{
					Debug.WriteLine("获取对象失败");
					return null;
				}
			}

			//指向枚举
			else if (CurParamInfo == "seq")
			{
				var SeqName = Attrs["seq"].Split(':')[0];
				var SeqValue = Attrs["seq"].Split(':')[1];

				ExecObj = SeqValue.CastSeq(SeqName);
				if (ExecObj is null)
				{
					Debug.WriteLine($"Cast Failed {SeqName} > {SeqValue}");
					return null;
				}
			}

			//指向动态对象
			else
			{
				if (!byte.TryParse(CurParamInfo, out var CurParamIdx))  //获取参数编号
				{
					Debug.WriteLine("非法Params参数，应为数值类型: " + CurParamInfo);
					return null;
				}
				else if (Params is null)
				{
					Debug.WriteLine("Params不存在!!");
					return null;
				}
				else if (Params.Count >= CurParamIdx) ExecObj = Params[CurParamIdx - 1];
				else
				{
					Debug.WriteLine("Params数量不足!!!");
					return null;
				}
			}
			#endregion



			#region 创建目标树结构
			var TargetTree = new List<string>(); //目标树

			//解析树 （点号表示子对象，冒号表示转换）
			//但由于处理函数同时支持，故而不进行差异化执行
			if (!ps[1].Contains('.')) TargetTree.Add(ps[1]);
			else foreach (var t in ps[1].Split('.')) TargetTree.Add(t);

			//处理冒号部分多余数据 
			for (int i = 2; i < ps.Length; i++) TargetTree.Add(ps[i]?.Trim());
			#endregion

			#region 根据目标树逐级处理
			try
			{
				//逐级处理信息
				string ParentTarget = null;

				//参数0 是之前获取到的执行对象
				for (int x = 1; x < TargetTree.Count; x++)
				{
					//获取当前层级对象信息
					var CurObj = GetInfo(ExecObj, ParentTarget, TargetTree[x]);

					//传递下一次处理时的上级对象
					ParentTarget = TargetTree[x];

					//判断当前对象状态
					if (CurObj is null) break;
					else ExecObj = CurObj;
				}

				return ExecObj;
			}
			catch (Exception ee)
			{
				Debug.WriteLine(ee);
			}
			#endregion


			return null;
		}

		/// <summary>
		/// 获取信息
		/// </summary>
		/// <param name="param">参数</param>
		/// <param name="ParentTarget">上级目标</param>
		/// <param name="target">目标</param>
		/// <returns></returns>
		private static object GetInfo(this object param, string ParentTarget, string target)
		{
			//返回基础对象
			if (target == "string") return param;
			else if (target == "integer") return int.Parse(param.ToString());
			

			//验证数据
			if (param is null) return null;
			//处理接口信息
			else if (param is IArgParam @ArgParam)
			{
				var result = ArgParam.ParamTarget(target);
				if (result != null) return result;
			}
			//处理图片数据
			else if (param is Bitmap @bitmap)
			{
				if (target == "joypad-ui-toggle") return param;
				if (target == "scale") return param;

				if (ParentTarget == "scale")
				{
					int Scale = int.Parse(target);

					//图片缩放到比例
					return new Bitmap(bitmap, new Size(Scale, Scale));
				}
			}

			else if (param is int @Integer)
			{
				if (target == "money") return new MoneyConvert(Integer);
			}
			//处理枚举信息
			else if (param is Enum @enum)
			{
				if (param is GameSeq.KeyCommand keyCommond) return FileCache.Data.KeyCommand.Find(o => o.keyCommand == keyCommond)?.GetInfo(ParentTarget, target);
				else if (param is KeyCode keyCode) return FileCache.Data.KeyCap.Find(o => o.KeyCode == keyCode)?.GetInfo(ParentTarget, target);

				return $"[{ @enum.GetDescription() }]";    //实际处理比这个复杂的多
			}
			//处理实例数据
			else
			{
				var result = param.GetMemberVal(target, true);
				if (result != null) return result;
			}


			Debug.WriteLine($"未支持 { param } ({ param.GetType().Name }) => 当前参数: { target }");
			return null;
		}
	}
}
