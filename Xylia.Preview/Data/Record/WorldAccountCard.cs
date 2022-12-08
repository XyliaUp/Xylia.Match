using System.ComponentModel;

using Xylia.Preview.Common.Interface;
using Xylia.Preview.Common.Enums;
using Xylia.Preview.Common.Cast;

namespace Xylia.Preview.Data.Record
{
	public sealed class WorldAccountCard : IRecord, IName
	{
		#region 字段
		public string Item;

		public bool Disabled;

		[Description("sort-no")]
		public short SortNo;

		[Description("card-image")]
		public string CardImage;


		[Description("card-original-image-1")] public string CardOriginalImage1;
		[Description("card-original-image-2")] public string CardOriginalImage2;
		[Description("card-original-image-3")] public string CardOriginalImage3;
		[Description("card-original-image-4")] public string CardOriginalImage4;
		[Description("card-original-image-desc-1")] public string CardOriginalImageDesc1;
		[Description("card-original-image-desc-2")] public string CardOriginalImageDesc2;
		[Description("card-original-image-desc-3")] public string CardOriginalImageDesc3;
		[Description("card-original-image-desc-4")] public string CardOriginalImageDesc4;

		[Description("set-card-original-image")]
		public bool SetCardOriginalImage;
		#endregion


		#region 接口方法
		public string NameText() => this.Item.GetObject(DataType.Item).GetName();
		#endregion
	}
}
