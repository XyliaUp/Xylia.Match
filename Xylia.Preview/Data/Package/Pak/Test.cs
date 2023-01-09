using System.Drawing;

using CUE4Parse.UE4.Assets.Exports;
using CUE4Parse.UE4.Assets.Objects;
using CUE4Parse.UE4.Objects.Core.Math;

using Xylia.Extension;

namespace Xylia.Preview.Data.Package.Pak
{
	public static class Test
	{
		public static void Scene()
		{
			var AssetPath = "BNSR/Content/Art/UI/GameUI/Scene/Game_ToolTip/Game_ToolTipScene.uasset";
			void Output(string Name, FStructFallback ImageProperty)
			{
				if (ImageProperty is null) return;

				var BaseImageTexture = ImageProperty.GetOrDefault<UObject>("BaseImageTexture");
				var ImageUV = ImageProperty.GetOrDefault<FVector2D>("ImageUV");
				var ImageUVSize = ImageProperty.GetOrDefault<FVector2D>("ImageUVSize");


				string DirPath = $@"C:\Users\Xylia\Desktop\新建文件夹\{System.IO.Path.GetFileNameWithoutExtension(AssetPath)}";
				System.IO.Directory.CreateDirectory(DirPath);

				BaseImageTexture.GetUObject()?.GetImage()?.
						 Clone(new Rectangle((int)ImageUV.X, (int)ImageUV.Y, (int)ImageUVSize.X, (int)ImageUVSize.Y)).
						 Save(DirPath + $"\\{Name}.png");
			}


			PakData PakData = new();
			PakData.Initialize();
			foreach (var o in PakData.GetAssetExports(AssetPath))
			{
				if (o.TryGetValue(out FStructFallback BaseImageProperty, "BaseImageProperty")) Output(o.Name, BaseImageProperty);

				else if (o.TryGetValue(out FStructFallback NormalImageProperty, "NormalImageProperty")) Output(o.Name, NormalImageProperty);


				else if (o.TryGetValue(out UScriptArray ExpansionComponentList, "ExpansionComponentList"))
				{
					foreach (var p in ExpansionComponentList.Properties)
					{
						if (p is StructProperty s && s.Value.StructType is FStructFallback fallback)
						{
							Output(o.Name, fallback.GetOrDefault<FStructFallback>("ImageProperty"));
						}
					}
				}
			}
		}
	}
}