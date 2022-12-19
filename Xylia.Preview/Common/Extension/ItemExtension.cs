using System;
using System.Collections.Concurrent;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using Xylia.Extension;
using Xylia.Preview.Common.Interface;
using Xylia.Preview.Project.Core.Item.Scene;
using Xylia.Preview.Project.Core.Skill;
using Xylia.Preview.Resources;

namespace Xylia.Preview.Data.Record
{
	public static partial class ItemExtension
	{
		#region 物品品级
		/// <summary>
		/// 返回品级对应的背景框
		/// </summary>
		/// <param name="Grade">物品品级</param>
		/// <param name="IsUE4"></param>
		/// <returns></returns>
		public static Bitmap GetBackGround(this byte Grade, bool IsUE4 = true) => Grade switch
		{
			2 => IsUE4 ? Resource_BNSR.ItemIcon_Bg_Grade_2 : Resource_Common.ItemIcon_Bg_Grade_2,
			3 => IsUE4 ? Resource_BNSR.ItemIcon_Bg_Grade_3 : Resource_Common.ItemIcon_Bg_Grade_3,
			4 => IsUE4 ? Resource_BNSR.ItemIcon_Bg_Grade_4 : Resource_Common.ItemIcon_Bg_Grade_4,
			5 => IsUE4 ? Resource_BNSR.ItemIcon_Bg_Grade_5 : Resource_Common.ItemIcon_Bg_Grade_5,
			6 => IsUE4 ? Resource_BNSR.ItemIcon_Bg_Grade_6 : Resource_Common.ItemIcon_Bg_Grade_6,
			7 => IsUE4 ? Resource_BNSR.ItemIcon_Bg_Grade_7 : Resource_Common.ItemIcon_Bg_Grade_7,
			8 => IsUE4 ? Resource_BNSR.ItemIcon_Bg_Grade_8 : Resource_Common.ItemIcon_Bg_Grade_9,
			9 => IsUE4 ? Resource_BNSR.ItemIcon_Bg_Grade_9 : Resource_Common.ItemIcon_Bg_Grade_8,

			1 or _ => IsUE4 ? Resource_BNSR.ItemIcon_Bg_Grade_1 : Resource_Common.ItemIcon_Bg_Grade_1,
		};
		#endregion


		#region 物品处理
		public static Item GetItemInfo(this string _alias, bool IgnoreError = true)
		{
			var Info = FileCache.Data.Item[_alias];
			if (Info is null && !IgnoreError) throw new Exception($"物品查询无效 ({ _alias })");

			return Info;
		}

		public static Item GetItemInfo(this string rule, Action<string, bool> Act, bool ShowList = true)
		{
			if (string.IsNullOrWhiteSpace(rule)) throw new Exception("搜索规则为空");
			rule = rule.Trim();  //去除前后空格

			//尝试获取道具信息，搜索失败则进行模糊搜索
			var Record = FileCache.Data.Item[rule];
			if (false && Record is null && !int.TryParse(rule, out _))
			{
				BlockingCollection<Item> lst = new();

				Parallel.ForEach(FileCache.Data.Item, Info =>
				{
					string ItemName = Info.Attributes["name2"].GetText();
					if (ItemName != null)
					{
						if (ShowList)
						{
							if (ItemName.IndexOf(rule, StringComparison.OrdinalIgnoreCase) < 0) return;
						}
						else if (ItemName != rule) return;

						lst.Add(Info);
					}

					return;
				});


				#region 处理最终结果
				var ResultCount = lst.Count;
				if (ResultCount != 0)
				{
					if (ResultCount == 1) Record = lst.First();
					else if (ShowList)
					{
						Console.WriteLine("结果数量：" + ResultCount);

						//计划增加翻页系统
						if (true && ResultCount > 800)
						{
							Act?.Invoke($"共搜索到{ ResultCount }条，因数量过多无法显示\n请增加限制条件以缩小搜索范围", true);
							return null;
						}
						else
						{
							var Searcher = new SearcherScene();

							//进行排序		
							Searcher.ShowItemList(lst.OrderBy(s => s.ID));
							Searcher.ShowDialog();
							return null;
						}
					}
				}
				#endregion
			}

			if (Record is null) Act?.Invoke("所查找的道具不存在", true);
			return Record;
		}
		#endregion


		private static Form GetPreview(this string rule, Action<string, bool> Act = null) => GetPreview(GetItemInfo(rule, Act));

		private static Form GetPreview(this IRecord obj)
		{
			if (obj is null) return null;
			else if (obj is Item ItemData) return new ItemFrm(ItemData);
			else if (obj is Skill3 Skill) return new Form1(Skill);

			return null;
		}

		public static void PreviewShow(this string rule, Action<string, bool> Act = null, IWin32Window window = null)
		{
			var thread = new Thread(() => GetPreview(rule, Act)?.PreviewShow(window));
			thread.SetApartmentState(ApartmentState.STA);
			thread.Start();
		}

		public static void PreviewShow(this IRecord obj, IWin32Window window = null)
		{
			if (obj is null) return;

			var thread = new Thread(() =>
			{
				var ResultFrm = GetPreview(obj);
				if (ResultFrm is null) Console.WriteLine($"窗体无效 ({ obj })");
				else ResultFrm.PreviewShow(window);
			});

			thread.SetApartmentState(ApartmentState.STA);
			thread.Start();
		}

		public static void PreviewShow(this Form ResultFrm, IWin32Window window = null)
		{
			if (window is null) ResultFrm.ShowDialog();
			else ResultFrm.ShowDialog(window);
		}
	}
}
