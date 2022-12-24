using System.Drawing;
using System.Linq;

using Xylia.Attribute.Component;
using Xylia.bns.Modules.GameData.Enums;

using Xylia.Drawing;
using Xylia.Extension;
using Xylia.Preview.Common.Enums;
using Xylia.Preview.Common.Interface;
using Xylia.Preview.Project.Core.Item.Preview.Reward;
using Xylia.Preview.Resources;



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
		public int Price => this.Attributes["price"].ConvertToInt();
		public int BaseFee => this.Attributes["base-fee"].ConvertToInt();


		public GameCategory3Seq GameCategory3 => this.Attributes["game-category-3"].ToEnum<GameCategory3Seq>();



		public bool AccountUsed => this.Attributes["account-used"].ToBool();
		public bool AcquireUsed => this.Attributes["acquire-used"].ToBool();
		public bool Auctionable => this.Attributes["auctionable"].ToBool();
		public bool CannotTrade => this.Attributes["cannot-trade"].ToBool();
		public bool EquipUsed => this.Attributes["equip-used"].ToBool();



		public JobSeq EquipJobCheck1 => this.Attributes["equip-job-check-1"].ToEnum<JobSeq>();
		public JobSeq EquipJobCheck2 => this.Attributes["equip-job-check-2"].ToEnum<JobSeq>();
		public JobSeq EquipJobCheck3 => this.Attributes["equip-job-check-3"].ToEnum<JobSeq>();
		public JobSeq EquipJobCheck4 => this.Attributes["equip-job-check-4"].ToEnum<JobSeq>();
		public JobSeq EquipJobCheck5 => this.Attributes["equip-job-check-5"].ToEnum<JobSeq>();
		
		public bool CheckEquipJob(JobSeq MyJob)
		{
			//如果职业不存在
			if (MyJob == JobSeq.JobNone) return true;

			//如果当前物品无职业限制
			if (EquipJobCheck1 == JobSeq.JobNone) return true;


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
				var tmp = new JobSeq[] { EquipJobCheck1, EquipJobCheck2, EquipJobCheck3, EquipJobCheck4, EquipJobCheck5 }.Where(o => o != JobSeq.JobNone);

				if (!tmp.Any()) return null;
				else return tmp.Select(t => t.GetDescription()).Aggregate((sum, now) => sum + "," + now);
			}
		}




		public Sex EquipSex => this.Attributes["equip-sex"].ToEnum<Sex>();
		public Race EquipRace => this.Attributes["equip-race"].ToEnum<Race>();
		public EquipType EquipType => this.Attributes["equip-type"].ToEnum<EquipType>();



		public byte ItemGrade => this.Attributes["item-grade"].ConvertToByte();

		public LegendGradeBackgroundParticleTypeSeq LegendGradeBackgroundParticleType => this.Attributes["legend-grade-background-particle-type"].ToEnum<LegendGradeBackgroundParticleTypeSeq>();
		public enum LegendGradeBackgroundParticleTypeSeq
		{
			Default,

			[Signal("type-gold")]
			TypeGold,

			[Signal("type-redup")]
			TypeRedup,

			[Signal("type-goldup")]
			TypeGoldup,
		}



		public RecycleGroup UseGlobalRecycleGroup => this.Attributes["use-global-recycle-group"].ToEnum<RecycleGroup>();
		public byte UseGlobalRecycleGroupID => (this.Attributes["use-global-recycle-group-id"]).ConvertToByte();
		public int UseGlobalRecycleGroupDuration => (this.Attributes["use-global-recycle-group-duration"]).ConvertToInt();
		public RecycleGroup UseRecycleGroup => this.Attributes["use-recycle-group"].ToEnum<RecycleGroup>();
		public byte UseRecycleGroupID => this.Attributes["use-recycle-group-id"].ConvertToByte();
		public int UseRecycleGroupDuration => (this.Attributes["use-recycle-group-duration"]).ConvertToInt();


		public DecomposeInfo DecomposeInfo => new(this);






		public string ItemSoundMove => this.Attributes["item-sound-move"];

		public MainAbility MainAbility1 => this.Attributes["main-ability-1"].ToEnum<MainAbility>();
		public MainAbility MainAbility2 => this.Attributes["main-ability-2"].ToEnum<MainAbility>();
	



		public int UsableDuration => this.Attributes["usable-duration"].ToInt();
		public ItemEvent EventInfo => FileCache.Data.ItemEvent[this.Attributes["event-info"]];
		public bool ShowRewardPreview => this.Attributes["show-reward-preview"].ToBool();
		public AccountPostCharge AccountPostCharge => FileCache.Data.AccountPostCharge[this.Attributes["account-post-charge"]];






		public int ImproveId => this.Attributes["improve-id"].ToInt();
		public byte ImproveLevel => this.Attributes["improve-level"].ConvertToByte();
		public string ImproveNextItem => this.Attributes["improve-next-item"];
		public string ImprovePrevItem => this.Attributes["improve-prev-item"];

		public string ItemName => this.Attributes["name2"].GetText();
		public string ItemNameWithGrade => $"<font name=\"00008130.Program.Fontset_ItemGrade_{ this.ItemGrade }\">" + this.ItemName + "</font>";

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
		public Bitmap Icon => GetIconWithGrade(this.Attributes["icon"], this.ItemGrade);


		/// <summary>
		/// 获得包含附加信息的图标
		/// </summary>
		public Bitmap IconExtra
		{
			get
			{
				var bmp = this.Icon;
				if (bmp is null) return null;


				#region 处理左上角
				Bitmap TopLeft = null;
				if (this.CustomDressDesignState == CustomDressDesignStateSeq.Disabled) TopLeft = Resource_Common.Sewing;
				else if (this.CustomDressDesignState == CustomDressDesignStateSeq.Activated) TopLeft = Resource_Common.Sewing2;

				if (TopLeft != null) bmp = bmp.ImageCombine(TopLeft, Compose.DrawLocation.TopLeft, false);
				#endregion

				#region 处理右上角
				Bitmap TopRight = null;

				if (AccountUsed) TopRight = Resource_BNSR.SlotItem_privateSale;
				else if (Auctionable) TopRight = Resource_BNSR.SlotItem_marketBusiness;

				if (TopRight != null) bmp = bmp.ImageCombine(TopRight, Compose.DrawLocation.TopRight);
				#endregion

				#region 处理左下角
				Bitmap BottomLeft;
				if (this.EventInfo != null && this.EventInfo.IsExpiration) BottomLeft = Resource_BNSR.unuseable_olditem_3;   //判断是否过期			  
				else if (this.GroceryType == GroceryTypeSeq.Sealed) BottomLeft = Resource_BNSR.Weapon_Lock_04;  //判断是否是封印状态
				else BottomLeft = this.DecomposeInfo.GetExtra();

				if (BottomLeft != null) bmp = bmp.ImageCombine(BottomLeft, Compose.DrawLocation.BottomLeft);
				#endregion

				return bmp;
			}
		}

		/// <summary>
		/// 获得图标信息（包含品质）
		/// </summary>
		/// <param name="IconAlias"></param>
		/// <param name="ItemGrade"></param>
		/// <returns></returns>
		public static Bitmap GetIconWithGrade(string IconInfo, byte ItemGrade)
		{
			if (string.IsNullOrWhiteSpace(IconInfo))
			{
				System.Diagnostics.Debug.WriteLine($"未设置图标");
				return null;
			}

			//获取底图
			var BackGroundImage = ItemGrade.GetBackGround(true);

			//返回结果数据
			Bitmap Raw = IconInfo.GetIcon();
			return Raw is null ? BackGroundImage : BackGroundImage.ImageCombine(Raw);
		}
		#endregion

		#region 接口方法
		public string NameText() => this.ItemName;

		public Bitmap MainIcon() => this.IconExtra;
		#endregion
	}
}