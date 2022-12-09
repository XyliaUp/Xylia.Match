using System.Collections.Generic;
using System.Drawing;
using System.Linq;

using Xylia.bns.Modules.GameData.Enums;

using Xylia.Drawing;
using Xylia.Extension;
using Xylia.Preview.Common.Enums;
using Xylia.Preview.Common.Interface;
using Xylia.Preview.Project.Core.Item.Preview.Reward;

namespace Xylia.Preview.Data.Record
{
	/// <summary>
	/// 物品信息
	/// </summary>
	public sealed partial class Item : IRecord, IName, IPicture
	{
		#region 字段
		public ItemType Type => this.Attributes["type"].ToEnum<ItemType>();
		public string Brand => this.Attributes["brand"];
		public RecycleGroup GlobalRecycleGroup => this.Attributes["global-recycle-group"].ToEnum<RecycleGroup>();
		public byte GlobalRecycleGroupID => (this.Attributes["global-recycle-group-id"]).ConvertToByte();
		public int GlobalRecycleGroupDuration => (this.Attributes["global-recycle-group-duration"]).ConvertToInt();
		public RecycleGroup RecycleGroup => this.Attributes["recycle-group"].ToEnum<RecycleGroup>();
		public byte RecycleGroupID => this.Attributes["recycle-group-id"].ConvertToByte();
		public int RecycleGroupDuration => (this.Attributes["recycle-group-duration"]).ConvertToInt();



		public bool AccountUsed => this.Attributes["account-used"].ToBool();
		public bool AcquireUsed => this.Attributes["acquire-used"].ToBool();
		public bool Auctionable => this.Attributes["auctionable"].ToBool();
		public bool CannotTrade => this.Attributes["cannot-trade"].ToBool();
		public bool EquipUsed => this.Attributes["equip-used"].ToBool();


		public byte ItemGrade => this.Attributes["item-grade"].ConvertToByte();


		public Race EquipRace => this.Attributes["equip-race"].ToEnum<Race>();
		public Sex EquipSex => this.Attributes["equip-sex"].ToEnum<Sex>();
		public EquipType EquipType => this.Attributes["equip-type"].ToEnum<EquipType>();
		#endregion

		#region 职业校验
		public Job EquipJobCheck1 => this.Attributes["equip-job-check-1"].ToEnum<Job>();
		public Job EquipJobCheck2 => this.Attributes["equip-job-check-2"].ToEnum<Job>();
		public Job EquipJobCheck3 => this.Attributes["equip-job-check-3"].ToEnum<Job>();
		public Job EquipJobCheck4 => this.Attributes["equip-job-check-4"].ToEnum<Job>();
		public Job EquipJobCheck5 => this.Attributes["equip-job-check-5"].ToEnum<Job>();

		public bool CheckEquipJob(Job MyJob)
		{
			//如果职业不存在
			if (MyJob == Job.JobNone) return true;

			//如果当前物品无职业限制
			if (EquipJobCheck1 == Job.JobNone) return true;


			//如果职业存在，且当前物品存在职业限制
			if (EquipJobCheck1 == MyJob) return true;
			else if (EquipJobCheck2 == MyJob) return true;
			else if (EquipJobCheck3 == MyJob) return true;
			else if (EquipJobCheck4 == MyJob) return true;
			else if (EquipJobCheck5 == MyJob) return true;

			return false;
		}

		/// <summary>
		/// 专属职业信息
		/// </summary>
		public string JobInfo
		{
			get
			{
				var tmp = new Job[] { EquipJobCheck1, EquipJobCheck2, EquipJobCheck3, EquipJobCheck4, EquipJobCheck5 }.Where(o => o != Job.JobNone);

				if (!tmp.Any()) return null;
				else return tmp.Select(t => t.GetDescription()).Aggregate((sum, now) => sum + "," + now);
			}
		}
		#endregion

		#region 属性
		public string ItemSoundMove => this.Attributes["item-sound-move"];

		public MainAbility MainAbility1 => this.Attributes["main-ability-1"].ToEnum<MainAbility>();
		public MainAbility MainAbility2 => this.Attributes["main-ability-2"].ToEnum<MainAbility>();
		#endregion

		#region	字段
		public GameCategory3Seq GameCategory3 => this.Attributes["game-category-3"].ToEnum<GameCategory3Seq>();

		public int UsableDuration => this.Attributes["usable-duration"].ToInt();
		public ItemEvent ItemEvent => FileCache.Data.ItemEvent.GetInfo(this.Attributes["event-info"]);


		public int ImproveId => this.Attributes["improve-id"].ToInt();
		public byte ImproveLevel => this.Attributes["improve-level"].ConvertToByte();
		public string ImproveNextItem => this.Attributes["improve-next-item"];
		public string ImprovePrevItem => this.Attributes["improve-prev-item"];

		public string ItemName => this.Attributes["name2"].GetText();
		public string MainInfo => this.Attributes["main-info"].GetText();
		public string SubInfo => this.Attributes["sub-info"].GetText();
		public string IdentifyMainInfo => this.Attributes["identify-main-info"].GetText();
		public string IdentifySubInfo => this.Attributes["identify-sub-info"].GetText();
		public string IdentifyDescription => this.Attributes["identify-description"].GetText();
		public string Description2 => this.Attributes["description2"].GetText();
		public string Description4Title => this.Attributes["description4-title"].GetText();
		public string Description5Title => this.Attributes["description5-title"].GetText();
		public string Description6Title => this.Attributes["description6-title"].GetText();
		public string Description4 => this.Attributes["description4"].GetText();
		public string Description5 => this.Attributes["description5"].GetText();
		public string Description6 => this.Attributes["description6"].GetText();
		public string Description7 => this.Attributes["description7"].GetText();
		public int ClosetGroupId => this.Attributes["closet-group-id"].ToInt();
		#endregion


		DecomposeInfo DecomposeInfo => new(this);


		#region 图标处理

		/// <summary>
		/// 获取标签图标
		/// </summary>
		public Bitmap TagIconGrade => this.Attributes["tag-icon-grade"].GetIcon();

		/// <summary>
		/// 获得不带有背景层的图标
		/// </summary>
		public Bitmap FrontIcon => this.Attributes["icon"].GetIcon();

		/// <summary>
		/// 获得带有背景层的图标
		/// </summary>
		public Bitmap Icon => this.Attributes["icon"].GetIconWithGrade(ItemGrade);

		/// <summary>
		/// 获得包含附加信息的图标
		/// </summary>
		public Bitmap IconExtra
		{
			get
			{
				var bmp = this.Icon;

				var SlotItem = this.SlotItem;
				if (bmp != null && SlotItem != null)
				{
					foreach (var Item in this.SlotItem) bmp = bmp?.ImageCombine(Item.Value, Item.Key);
				}

				return bmp;
			}
		}

		/// <summary>
		/// 状态图标
		/// </summary>
		public Dictionary<Compose.DrawLocation, Bitmap> SlotItem
		{
			get
			{
				var Result = new Dictionary<Compose.DrawLocation, Bitmap>();

				#region 处理左下角
				Bitmap BottomLeft;
				if (this.ItemEvent != null && this.ItemEvent.IsExpiration) BottomLeft = Properties.Resources.unuseable_olditem_3;   //判断是否过期			  
				else if (this.groceryType == GroceryType.Sealed) BottomLeft = Properties.Resources.Weapon_Lock_04;  //判断是否是封印状态
				else BottomLeft = this.DecomposeInfo.GetExtra();

				if (BottomLeft != null) Result.Add(Compose.DrawLocation.BottomLeft, BottomLeft);
				#endregion


				#region 处理右上角
				Bitmap TopRight = null;

				if (AccountUsed) TopRight = Properties.Resources.SlotItem_privateSale;
				else if (Auctionable) TopRight = Properties.Resources.SlotItem_marketBusiness;

				if (TopRight != null) Result.Add(Compose.DrawLocation.TopRight, TopRight);
				#endregion

				return Result;
			}
		}
		#endregion

		#region 接口方法
		public string NameText() => this.ItemName;

		public string ItemNameWithGrade => $"<font name=\"00008130.Program.Fontset_ItemGrade_{ ItemGrade }\">" + NameText() + "</font>";

		public Bitmap MainIcon() => this.Icon;
		#endregion
	}
}
