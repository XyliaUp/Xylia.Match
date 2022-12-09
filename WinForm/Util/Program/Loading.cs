using System;
using System.Net;
using System.Text;
using System.Xml;

using Xylia.Files.XmlEx;
using Xylia.Extension;
using Xylia.Match.Properties;
using System.IO;
using System.Net.Http;
using Xylia.Windows.Forms;

namespace Xylia.Match
{
	/// <summary>
	/// 加载时类
	/// </summary>
	public static class Loading
    {
        /// <summary>
        /// 加载服务器公告
        /// </summary>
        public static void GetNotice()
        {
            try
            {
                XmlDocument xmlDocument = new();
                xmlDocument.Load(Url.GetUpdate);

                XmlNode xmlNode = xmlDocument.SelectSingleNode($"//Group[@Name='Announcement']//Type[@Name='{ Program.Name }']");
                if (xmlNode != null)
                {
                    XmlProperty xmlProperty = new(xmlNode);

                    //如果时间相同，直接返回
                    string CurDate = Xylia.Configure.Ini.ReadValue(Program.Name, "Announcement");
                    if (!CurDate.IsNull() && xmlProperty.Attributes["Date"] == CurDate) return;


                    #region 下载数据
                    string Address = xmlProperty.Attributes["Address"];
                    if (Address.IsNull()) throw new Exception("公告路径未设置");

                    byte[] buffer = new HttpClient().GetByteArrayAsync(Address).Result;
                    Configure.Ini.WriteValue(Program.Name, "Announcement", xmlProperty.Attributes["Date"]);

                    if (Encoding.UTF8.GetString(buffer).IsNull()) return;
                    else if (buffer.Length <= 8) return;
                    else new Announcement(Encoding.UTF8.GetString(buffer)).ShowDialog();
                    #endregion
                }
                else Console.WriteLine("读取公告时失败，因为节点不存在");
            }
            catch (Exception ee)
            {
                Console.WriteLine("读取公告时失败，因为" + ee.Message);
            }
        }
    }
}
