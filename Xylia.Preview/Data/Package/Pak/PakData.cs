using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using System.Linq;

using CUE4Parse.Encryption.Aes;
using CUE4Parse.FileProvider;
using CUE4Parse.UE4.AssetRegistry;
using CUE4Parse.UE4.AssetRegistry.Objects;
using CUE4Parse.UE4.Assets.Exports;
using CUE4Parse.UE4.Objects.Core.Misc;

using Xylia.Preview.Properties;

namespace Xylia.Preview.Data.Package.Pak
{
	public sealed class PakData
	{
		#region 获取虚拟文件系统
		/// <summary>
		/// 虚拟文件系统解析提供器
		/// </summary>
		public DefaultFileProvider _provider;

		/// <summary>
		/// 文件映射数据
		/// </summary>

		private readonly ConcurrentDictionary<string, string> ObjectRef = new(StringComparer.OrdinalIgnoreCase);


		public void Initialize(string GameDirectory = null)
		{
			if (this._provider != null) return;
			if (GameDirectory is null) GameDirectory = CommonPath.GameFolder;

			lock (this._provider = new DefaultFileProvider(GameDirectory, SearchOption.AllDirectories, true))
			{
				DateTime dt = DateTime.Now;

				this._provider.Initialize();
				this._provider.UnloadAllVfs();
				//GC.Collect();

				//提交密钥
				this._provider.SubmitKey(new FGuid(), new FAesKey("d2e5f7f94e625efe2726b5360c1039ce7cb9abb760a94f37bb15a6dc08741656"));

				Debug.WriteLine($"[Debug] 初始化文件处理器，耗时 { (DateTime.Now - dt).Seconds }s");
			}
		}

		/// <summary>
		/// 读取资源注册表
		/// </summary>
		public void LoadAssetRegistry()
		{
			DateTime dt = DateTime.Now;

			//Pak0-UFS_A-WindowsNoEditor
			if (_provider.TryCreateReader("BNSR/AssetRegistry.bin", out var archive))
			{
				var AssetRegistry = new FAssetRegistryState_Bns(archive);
				foreach (FAssetData_Bns asset in AssetRegistry.PreallocatedAssetDataBuffers)
				{
					ObjectRef[asset.ObjectPath2] = asset.ObjectPath.Text;
				}
			}

			System.Diagnostics.Debug.WriteLine($"[Debug] 初始化资产注册表，耗时 { (DateTime.Now - dt).Seconds }s");
		}
		#endregion



		#region 方法
		/// <summary>
		/// 将抽象对象读取为实例对象
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public UObject GetObject(UObject obj) => obj is null ? null : GetObject(obj.GetPathName_Bns());

		public UObject GetObject(string filePath)
		{
			if (string.IsNullOrWhiteSpace(filePath)) return null;
			this.Initialize();


			#region 获取路径信息
			string Ue4Path = null;
			bool OldPath = false;

			//实际资产路径
			if (filePath.StartsWith("BNSR/Content")) Ue4Path = filePath;

			//虚拟对象路径
			else if (filePath.StartsWith("/Game")) Ue4Path = "BNSR/Content" + filePath[5..];

			//处理旧版路径
			else
			{
				OldPath = true;

				//string DirPath = Path.GetDirectoryName(filePath);
				//string FileName = Path.GetFileName(filePath);

				//设定常用替换关系
				//实际通过资源注册表关联，但载入资源注册表十分耗时
				if (filePath.StartsWith("00008758")) Ue4Path = "BNSR/Content/Art/UI/GameUI/Resource/GameUI_Icon/" + filePath[9..];
				else if (filePath.StartsWith("00021326")) Ue4Path = "BNSR/Content/Art/UI/GameUI/Resource/GameUI_Icon2nd/" + filePath[9..];
				else if (filePath.StartsWith("00052219")) Ue4Path = "BNSR/Content/Art/UI/GameUI/Resource/GameUI_Icon3rd/" + filePath[9..];
				else if (filePath.StartsWith("00078990")) Ue4Path = "BNSR/Content/Art/UI/GameUI/Resource/GameUI_Icon4th/" + filePath[9..];
				else if (filePath.StartsWith("00033689")) Ue4Path = "BNSR/Content/Art/UI/GameUI/Resource/GameUI_KeyKap/" + filePath[9..];
				else if (filePath.StartsWith("00008130")) Ue4Path = "BNSR/Content/Art/UI/GameUI_BNSR/Resource/GameUI_FontSet_R/" + filePath[9..];
				else if (filePath.StartsWith("00009076")) Ue4Path = "BNSR/Content/Art/UI/GameUI/Resource/GameUI_Window/" + filePath[9..];
				else if (filePath.StartsWith("00009499")) Ue4Path = "BNSR/Content/Art/UI/GameUI/Resource/GameUI_Map_Indicator/" + filePath[9..];
				else if (filePath.StartsWith("00015590")) Ue4Path = "BNSR/Content/Art/UI/GameUI/Resource/GameUI_Tag/" + filePath[9..];
				else if (filePath.StartsWith("00027918")) Ue4Path = "BNSR/Content/Art/UI/GameUI/Resource/GameUI_Portrait/" + filePath[9..];
				else if (filePath.StartsWith("00043230")) Ue4Path = "BNSR/Content/Art/UI/GameUI/Resource/GameUI_SkillBookImage/" + filePath[9..];
				else if (filePath.StartsWith("00064443")) Ue4Path = "BNSR/Content/Art/UI/GameUI/Resource/GameUI_FishIcon/" + filePath[9..];
				else if (filePath.StartsWith("MiniMap_", StringComparison.OrdinalIgnoreCase)) Ue4Path = "BNSR/Content/bns/Package/World/GameDesign/commonpackage/" + filePath;
				else
				{
					//使用公共处理
					if (ObjectRef.IsEmpty && true) lock (this.ObjectRef) LoadAssetRegistry();

					if (this.ObjectRef.ContainsKey(filePath)) return GetObject(this.ObjectRef[filePath]);


					System.Diagnostics.Debug.WriteLine("无法读取的路径: " + filePath);
					return null;
				}

				//对于旧版路径，冒号代表文件夹
				Ue4Path = Ue4Path.Replace('.', '/');
			}
			#endregion

			//System.Diagnostics.Debug.WriteLine(Ue4Path);


			#region 返回数据
			//先获取资产文件路径，再判断 ExpertMap
			string AssetPath = Ue4Path.Split('.')[0];
			if (this._provider.TryFindGameFile(AssetPath, out var file))
			{
				var exports = _provider.LoadObjectExports(file.Path);
				if (exports != null && exports.Any())
				{
					//获取资产文件内 uobject 对象
					if (OldPath) return exports.First();

					//判断ExpertMap
					return exports.FirstOrDefault(o => o.Name.Equals(Ue4Path.Split('.')[1], StringComparison.OrdinalIgnoreCase));
				}
			}

			return null;
			#endregion
		}
		#endregion
	}
}
