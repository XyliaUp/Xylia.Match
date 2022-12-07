using System;
using System.Collections.Generic;
using System.Xml;

using Xylia.Extension;
using Xylia.Files.XmlEx;

namespace Xylia.Match.Util
{
	/// <summary>
	/// 轮播Tip
	/// </summary>
	public class TipMessage
    {
        /// <summary>
        /// 获得下一个提示
        /// </summary>
        public string GetNextTip
        {
            get
            {
                int random = new Random().Next(0, TotalWeight);
                int TempWeight = 0;

                foreach (var Tip in CacheTips)
                {
                    if (random < TempWeight) return Tip.Value.Text;
                    else TempWeight += Tip.Key;
                }

                throw new Exception("轮播Tip获取异常");
            }
        }



        /// <summary>
        /// 获取预先设置的提示消息
        /// </summary>
        private List<TipInfo> GetTips()
        {
            var vs = new List<TipInfo>();

            var Temp = new XmlDocument();
            Temp.LoadXml(Properties.Resx.Progrm.Tips);

            foreach (XmlNode item in Temp.SelectNodes("*/record"))
            {
                XmlProperty xml = item.Property();

                string Text = xml.Attributes["text"];
                if (!Text.IsNull())
                {
                    vs.Add(new TipInfo()
                    {
                        Text = Text,

                        Proweight = xml.Attributes["proweight"].ToIntWithNull(),
                        Type = Enum.TryParse(xml.Attributes["module"], true, out TipInfo.type type) ? type : TipInfo.type.None,
                    });
                }
            }
            return vs;
        }

        private Dictionary<int, TipInfo> m_CacheTips { get; set; }

        private Dictionary<int, TipInfo> CacheTips
        {
            get
            {
                //如果缓存信息不存在，则新建
                if (this.m_CacheTips is null || this.m_CacheTips.Count == 0)
                {
                    this.m_CacheTips = new Dictionary<int, TipInfo>();

                    TotalWeight = 0;
                    this.GetTips().ForEach(tip =>
                    {
                        int Proweight = tip.Proweight ?? 1;
                        this.m_CacheTips.Add(TotalWeight, tip);

                        TotalWeight += Proweight;
                    });
                }

                return this.m_CacheTips;
            }
        }

        /// <summary>
        /// 总权重信息
        /// </summary>
        private int TotalWeight { get; set; }
    }


    public class TipInfo
    {
        public string Text;
        public int? Proweight;
        public type Type;

        public enum type
        {
            None,

            /// <summary>道具</summary>
            Prop,

            /// <summary>任务</summary>
            Quest,
        }
    }
}
