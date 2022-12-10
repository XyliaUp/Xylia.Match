using System.ComponentModel;
using System.Drawing;

using Xylia.Attribute.Component;
using Xylia.Preview.Common.Interface;
using Xylia.Preview.Data.Package.Pak;
using Xylia.Preview.Data.Record;

namespace Xylia.Preview.Data.Record
{
	[Signal("icon-texture")]
	public sealed class IconTexture : IRecord
	{
		#region 属性字段
		[Description("icon-texture")]
		public string iconTexture;

		[Description("icon-height")]
		public short IconHeight;

		[Description("icon-width")]
		public short IconWidth;

		[Description("texture-height")]
		public short TextureHeight;

		[Description("texture-width")]
		public short TextureWidth;
		#endregion
	}
}


public static class IconTextureExt
{
	/// <summary>
	/// 缓存数据
	/// </summary>
	private static readonly ICacheInfo<Bitmap> Data = new();

	public static PakData PakData = new();



	#region 方法
	public static void Clear() => Data.Clear();


	public static Bitmap GetTextureData(this IconTexture IconTexture)
	{
		if (IconTexture.Alias != null && Data.Contains(IconTexture.Alias)) return Data[IconTexture.Alias];

		var TextureData = IconTexture?.iconTexture.GetImage();
		if (TextureData != null)
		{
			if (IconTexture.Alias != null) Data.Add(IconTexture.Alias, TextureData);
			return TextureData;
		}

		System.Diagnostics.Debug.WriteLine($"读取失败: " + IconTexture.Alias);
		return null;
	}


	/// <summary>
	/// 获得图标信息
	/// </summary>
	/// <param name="v"></param>
	/// <returns></returns>
	public static Bitmap GetIcon(this string IconInfo)
	{
		//判断有效性
		if (string.IsNullOrWhiteSpace(IconInfo)) return null;

		#region 获取图标序号
		if (IconInfo.Contains(','))
		{
			var IconSplit = IconInfo.Split(',');

			if (short.TryParse(IconSplit[1], out var idx)) return GetIcon(IconSplit[0], idx);
			throw new System.Exception("获取序号失败: " + IconInfo);
		}
		#endregion

		return GetIcon(IconInfo, 1);
	}

	public static Bitmap GetIcon(this string TextureAlias, short IconIndex)
	{
		//获取贴图数据
		var IconTexture = FileCache.Data.IconTexture[TextureAlias];
		if (IconTexture is null) return null;

		return GetIcon(IconTexture, IconIndex);
	}

	public static Bitmap GetIcon(this IconTexture IconTexture, short IconIndex)
	{
		Bitmap TextureData = GetTextureData(IconTexture);
		if (TextureData is null) return null;

		#region 裁剪内容
		if (IconTexture.TextureWidth == IconTexture.IconWidth && IconTexture.TextureHeight == IconTexture.IconHeight) 
			return TextureData;


		//获取行数与列数
		int AmountRow = IconTexture.TextureWidth / IconTexture.IconWidth;

		int RowID = IconIndex % AmountRow;
		int ColID = IconIndex / AmountRow;

		//计算行列索引
		//整除表示是最后一个对象
		if (RowID == 0) RowID = AmountRow;
		else ColID += 1;

		System.Diagnostics.Debug.WriteLine($"{IconIndex} => {ColID} - {RowID}");

		//锁定对象，防止异步异常
		lock (TextureData)
		{
			//返回裁剪结果
			return TextureData.Clone(new Rectangle(
				(RowID - 1) * IconTexture.IconWidth,
				(ColID - 1) * IconTexture.IconHeight,
				IconTexture.IconWidth, IconTexture.IconHeight), TextureData.PixelFormat);
		}
		#endregion
	}
	#endregion
}
