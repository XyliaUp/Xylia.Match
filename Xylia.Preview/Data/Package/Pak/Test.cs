using System;
using System.Drawing;

using CUE4Parse.UE4.Assets.Exports;
using CUE4Parse.UE4.Assets.Exports.Sound;
using CUE4Parse.UE4.Assets.Exports.Texture;
using CUE4Parse.UE4.Assets.Objects;
using CUE4Parse.UE4.Objects.Core.Math;
using CUE4Parse.UE4.Objects.UObject;

using CUE4Parse_Conversion.Sounds;
using CUE4Parse_Conversion.Textures;

using SkiaSharp;

using Xylia.Extension;
using Xylia.Preview.Common.Struct;

namespace Xylia.Preview.Data.Package.Pak
{
	public static class Test
	{
		public static void Scene()
		{
			void Output(string Name, FStructFallback ImageProperty)
			{
				if (ImageProperty is null) return;

				var BaseImageTexture = ImageProperty.GetOrDefault<UObject>("BaseImageTexture");
				var ImageUV = ImageProperty.GetOrDefault<FVector2D>("ImageUV");
				var ImageUVSize = ImageProperty.GetOrDefault<FVector2D>("ImageUVSize");

				BaseImageTexture.GetUObject()?.GetImage()?.
					Clone(new Rectangle((int)ImageUV.X, (int)ImageUV.Y, (int)ImageUVSize.X, (int)ImageUVSize.Y)).
					Save($@"C:\Users\Xylia\Desktop\新建文件夹\{Name}.png");
			}


			PakData PakData = new();
			PakData.Initialize();
			foreach (var o in PakData.GetAssetExports("BNSR/Content/Art/UI/GameUI/Scene/Game_Museum/Game_MuseumScene/MuseumCardPanel"))
			{
				if (o.TryGetValue(out FStructFallback BaseImageProperty, "BaseImageProperty")) Output(o.Name, BaseImageProperty);

				if (o.TryGetValue(out FStructFallback NormalImageProperty, "NormalImageProperty")) Output(o.Name, NormalImageProperty);



				//if (o.TryGetValue(out UScriptArray ExpansionComponentList, "ExpansionComponentList"))
				//{
				//	foreach (var p in ExpansionComponentList.Properties)
				//	{
				//		if (p is StructProperty s && s.Value.StructType is FStructFallback fallback)
				//		{
				//			Output(o.Name, fallback.GetOrDefault<FStructFallback>("ImageProperty"));
				//		}
				//	}
				//}
			}
		}
	}
}