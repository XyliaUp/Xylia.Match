using System;
using System.Collections.Generic;
using System.Drawing;

using Xylia.Drawing;

using Xylia.Preview.Properties;

using static Xylia.Drawing.Compose;
using static Xylia.Preview.Properties.Resources;

namespace Xylia.Match.Windows.Panel
{
	/// <summary>
	/// 合成选项
	/// </summary>
	public class CombineOption
	{
		#region 物品品级
		public class Grade
		{
			public Grade(byte ItemGrade, string Name)
			{
				this.Name = Name;
				this.ItemGrade = ItemGrade;
			}


			public string Name;

			public byte ItemGrade = 1;
		}


		public static List<Grade> Grade_Bitmap = new()
		{
			{ new Grade(1, "粗糙级") },
			{ new Grade(2, "凡品级") },
			{ new Grade(3, "奇巧级") },
			{ new Grade(4, "精粹级") },
			{ new Grade(5, "至尊级") },
			{ new Grade(6, "进化级") },
			{ new Grade(7, "传说级") },
			{ new Grade(8, "古代级") },
			{ new Grade(9, "神话级") },
		};
		#endregion




		public static List<Attach> Attach_Bitmap = new()
		{
			{ new Attach() { Name = "无附加属性", px128 = null, px64 = null } },

			{ new Attach() { Name = "封印", px128 = Weapon_Lock_04_128, px64 = Weapon_Lock_04 } },
			{ new Attach() { Name = "旧物", px128 = Weapon_Lock_05_128, px64 = Weapon_Lock_05 } },
			{ new Attach() { Name = "蓝色锁", px128 = unuseable_lock_128, px64 = unuseable_lock } },
			{ new Attach() { Name = "绿色锁", px128 = unuseable_lock_2_128, px64 = unuseable_lock_2 } },
			{ new Attach() { Name = "绿色锁", px128 = Weapon_Lock_03_128, px64 = Weapon_Lock_03 } },
			{ new Attach() { Name = "橘色锁", px128 = Weapon_Lock_06_128, px64 = Weapon_Lock_06 } },
			{ new Attach() { Name = "禁止使用", px128 = Weapon_Lock_01_128, px64 = Weapon_Lock_01 } },
			{ new Attach() { Name = "无法使用", px128 = Weapon_Lock_02_128, px64 = Weapon_Lock_02 } },
		};

		public static Dictionary<string, Bitmap> Trade_Bitmap = new()
		{
			{ "无交易属性", null },
			{ "拍卖行交易", SlotItem_marketBusiness },
			{ "账号通用", SlotItem_privateSale },
		};


		public class Attach
		{
			public string Name;

			public Bitmap px64;
			public Bitmap px128;
		}




		public class Prop
		{
			public Bitmap GradeImage = ItemIcon_Bg_Grade_7;

			public Bitmap Attach;
			public Bitmap Attach128;

			public Bitmap Trade;
			public byte[] Icon;

			public Bitmap DrawICON(double? Ratio = null)
			{
				Bitmap Temp = new(GradeImage);

				//比例缩放
				if (Ratio != null) Temp = Temp.ImageThumbnail((double)Ratio);

				try
				{
					if (Icon != null)
					{
						Temp = Temp.ImageCombine(SetImage.Load(Icon), Compose.DrawLocation.Centre);
					}

					if (Attach != null)
					{
						if (Ratio != null)
						{
							var tmp = new Bitmap(Attach128 ?? Attach.ImageThumbnail((double)Ratio));

							Temp = Temp.ImageCombine(tmp, Compose.DrawLocation.BottomLeft);
						}
						else
						{
							Temp = Temp.ImageCombine(Attach, Compose.DrawLocation.BottomLeft);
						}
					}

					if (Trade != null)
					{
						int Width = 23;
						int Height = 20;

						if (Ratio != null)
						{
							Width = (int)(Width * Ratio);
							Height = (int)(Height * Ratio);
						}


						Temp = Temp.ImageCombine(new Bitmap(Trade, Width, Height), Compose.DrawLocation.TopRight);
					}
				}
				catch (Exception ee)
				{
					Console.WriteLine(ee);
				}

				return Temp;
			}
		}
	}
}
