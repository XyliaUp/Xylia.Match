using System.ComponentModel;
using System.Drawing;

using Xylia.Attribute.Component;
using Xylia.Drawing;
using Xylia.Preview.Data.Package.Pak;
using Xylia.Preview.Data.Record;
<<<<<<< HEAD
using Xylia.Preview.Common.Interface;
=======
using Xylia.Preview.Project.Common.Interface;
>>>>>>> 87a0768aaf48150c6d7df46e4e5bad42ef854068

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
			return GetIcon(IconSplit[0], IconSplit[1]);
		}
		#endregion

		return GetIcon(IconInfo, 1);
	}

	public static Bitmap GetIcon(this string TextureAlias, string IconIndex)
	{
		if (short.TryParse(IconIndex, out var idx)) return GetIcon(TextureAlias, idx);

		throw new System.Exception("获取序号失败: " + TextureAlias);
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
		//获取每行与每列的数量
		int AmountRow = IconTexture.TextureWidth / IconTexture.IconWidth;

		int Row = IconIndex % AmountRow;
		int Column = IconIndex / AmountRow;

		//计算行列索引
		//整除表示是最后一个对象
		if (Row == 0) Row = AmountRow;
		else Column += 1;

		if (false && IconIndex != 1)
			System.Diagnostics.Debug.WriteLine($"{IconIndex} => {Column} - {Row}");

		//锁定对象，防止异步异常
		lock (TextureData)
		{
			//返回裁剪结果
			return TextureData.Clone(new Rectangle(
				(Row - 1) * IconTexture.IconWidth,
				(Column - 1) * IconTexture.IconHeight,
				IconTexture.IconWidth, IconTexture.IconHeight), TextureData.PixelFormat);
		}
		#endregion
	}


	/// <summary>
	/// 获得图标信息（包含品质）
	/// </summary>
	/// <param name="IconAlias"></param>
	/// <param name="ItemGrade"></param>
	/// <returns></returns>
	public static Bitmap GetIconWithGrade(this string IconInfo, byte ItemGrade)
	{
		//获取底图
		var BackGroundImage = ItemGrade.GetBackGround(true);

		//这个方法用于物品主图标，所以可以提供调试提示
		if (string.IsNullOrWhiteSpace(IconInfo))
		{
			System.Diagnostics.Debug.WriteLine($"未设置图标");
			return BackGroundImage;
		}

		//返回结果数据
		Bitmap Raw = IconInfo.GetIcon();
		return Raw is null ? BackGroundImage : BackGroundImage.ImageCombine(Raw);
	}

	public static void Clear() => Data.Clear();
	#endregion
}
