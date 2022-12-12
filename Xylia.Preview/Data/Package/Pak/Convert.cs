﻿using System;
using System.Drawing;

using CUE4Parse.UE4.Assets.Exports;
using CUE4Parse.UE4.Assets.Exports.Sound;
using CUE4Parse.UE4.Assets.Exports.Texture;
using CUE4Parse.UE4.Objects.Core.Math;
using CUE4Parse.UE4.Objects.UObject;

using CUE4Parse_Conversion.Sounds;
using CUE4Parse_Conversion.Textures;

using SkiaSharp;

using Xylia.Extension;
using Xylia.Preview.Common.Struct;

namespace Xylia.Preview.Data.Package.Pak
{
	public static class Convert
	{
		public static UObject GetUObject(this string Path) => IconTextureExt.PakData.GetObject(Path);

		public static UObject GetUObject(this FSoftObjectPath Path) => IconTextureExt.PakData.GetObject(Path.ToString());


		public static UObject GetUObject(this UObject obj) => IconTextureExt.PakData.GetObject(obj);





		//File.WriteAllText(path + "." + export.ExportType, JsonConvert.SerializeObject(Object, Formatting.Indented));
		public static Bitmap GetImage(this UTexture2D texture)
		{
			var bNearest = false;
			if (texture.TryGetValue(out FName trigger, "LODGroup", "Filter") && !trigger.IsNone)
				bNearest = trigger.Text.EndsWith("TEXTUREGROUP_Pixels2D", StringComparison.OrdinalIgnoreCase) ||
						   trigger.Text.EndsWith("TF_Nearest", StringComparison.OrdinalIgnoreCase);


			var SKImage = texture.Decode(bNearest);
			return new Bitmap(SKImage.Encode().AsStream());
		}

		public static Bitmap GetImage(this string Path)
		{
			var Object = Path.GetUObject();
			if (Object != null)
			{
				if (Object is UTexture2D texture) return texture.GetImage();

				//imageset处理

			}

			return null;
		}

		public static Bitmap GetImageset(this string ImagesetPath)
		{
			var Object = ImagesetPath.GetUObject();
			if (Object != null)
			{
				//获取到的可能是 Import 中的 抽象UObject，仍需要去获取完整的 UObject
				if (!Object.TryGetValue(out UObject o, "Image")) return null;

				var U = (int)Object.GetOrDefault<float>("U");
				var V = (int)Object.GetOrDefault<float>("V");
				var UL = (int)Object.GetOrDefault<float>("UL");
				var VL = (int)Object.GetOrDefault<float>("VL");

				var Image = IconTextureExt.PakData.GetObject(o.GetPathName());
				if (Image != null && Image is UTexture2D image) return image.GetImage().Clone(new Rectangle(U, V, UL, VL));
			}

			return null;
		}


		public static FontSet GetFont(this string Path)
		{
			var fontset = Path.GetUObject();
			if (fontset is null) return null;

			var result = new FontSet();

			fontset.TryGetValue(out UObject BNSFontFace, "FontFace");
			fontset.TryGetValue(out UObject FontAttribute, "FontAttribute");
			fontset.TryGetValue(out UObject FontColors, "FontColors");


			BNSFontFace = IconTextureExt.PakData.GetObject(BNSFontFace);
			if (BNSFontFace != null)
			{
				BNSFontFace.TryGetValue(out float Height, "Height");
				result.Height = Height;
			}

			FontAttribute = IconTextureExt.PakData.GetObject(FontAttribute);
			if (FontAttribute != null)
			{

			}

			FontColors = IconTextureExt.PakData.GetObject(FontColors);
			if (FontColors != null)
			{
				FontColors.TryGetValue(out FLinearColor FontColor, "FontColor");
				result.Color = Color.FromArgb((byte)Math.Round(FontColor.A * 255),
					(byte)Math.Round(FontColor.R * 255),
					(byte)Math.Round(FontColor.G * 255),
					(byte)Math.Round(FontColor.B * 255));
			}

			return result;
		}





		public static byte[] GetWave(this UObject Object, int ReferenceIdx = 0)
		{
			if (Object is null) return null;
			else if (Object is USoundWave)
			{
				Object.Decode(true, out var audioFormat, out var data);
				return data;
			}
			else if (Object.ExportType == "SoundCue")
			{
				var FirstNode = Object.GetOrDefault<UObject>("FirstNode").GetUObject();
				var ChildNodes = FirstNode.GetOrDefault<UObject[]>("ChildNodes");
				foreach (var ChildNode in ChildNodes)
				{
					var SoundWaveAssetPtr = ChildNode.GetUObject().GetOrDefault<FSoftObjectPath>("SoundWaveAssetPtr");
					return SoundWaveAssetPtr.GetUObject().GetWave();
				}
			}
			else if (Object.ExportType == "ShowSoundKey") return Object.GetOrDefault<UObject>("SoundCue").GetUObject().GetWave();

			else if (Object.ExportType == "ShowFaceFxKey") return Object.GetOrDefault<string>("FaceFXAnimSetName").GetUObject().GetWave(ReferenceIdx);
			else if (Object.ExportType == "LegacyFaceFXAnimSet") return Object.GetOrDefault<UObject[]>("ReferencedSoundCues")[ReferenceIdx].GetUObject().GetWave();

			else if (Object.ExportType == "ShowFaceFxUE4Key") return Object.GetOrDefault<FSoftObjectPath>("FaceFXAnimObj").GetUObject().GetWave();
			else if (Object.ExportType == "FaceFXAnim") return Object.GetOrDefault<FSoftObjectPath>("SoundCue").GetUObject().GetWave();
			else if (Object.ExportType == "ShowObject")
			{
				var EventKeys = Object.GetOrDefault<UObject[]>("EventKeys");
				if (EventKeys is null) return null;

				foreach (var _eventKey in EventKeys)
				{
					if (_eventKey.ExportType == "ShowSoundKey") return _eventKey.GetUObject().GetWave();
					else if (_eventKey.ExportType == "ShowFaceFxUE4Key") return _eventKey.GetUObject().GetWave();
					else if (_eventKey.ExportType == "ShowFaceFxKey") return _eventKey.GetUObject().GetWave(ReferenceIdx);
				}
			}

			return null;
		}
	}
}
