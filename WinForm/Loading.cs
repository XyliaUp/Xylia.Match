using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Net;
using Cherub.Files;

namespace Cherub.Match
{
    public static class Load
    {
        /// <summary>加载测试版本首次启动的公告提示</summary>
        public static void GetNotice_ExpFirst()
        {
            if (Program.isExp && Config.IniReadValue("Program", "Tip_Test") != true.ToString())
            {
                Cherub.GUI.Announcement announcement = new Cherub.GUI.Announcement(Properties.Res.Tip_Start_Test);

                announcement.OkText = "已经了解";


                announcement.CancelClicked += (a, o) =>
                {
                    Cherub.Tip.Message("请重新下载普通版本客户端");
                };

                announcement.OkClicked += (a, o) =>
                {
                    Cherub.Config.IniWriteValue("Program", "Tip_Test", true);
                    announcement.Hide();
                    announcement.Close();
                };


                announcement.ShowDialog();
            }
        }

        /// <summary>加载服务器公告</summary>
        public static void GetNotice(bool isExp = false)
        {
            try
            {
                XmlDocument xmlDocument = new XmlDocument();

                xmlDocument.Load(lib.Url.GetUpdate());

                XmlNodeList xmlNodeList = xmlDocument.SelectNodes("*/Group/Type");

                foreach (XmlNode xmlNode in xmlNodeList)
                {
                    Files.XmlProperty xmlProperty = new Files.XmlProperty(xmlNode);

                    if (xmlProperty["Name"] != "Match")  continue;

                    WebClient client = new WebClient();

                    string Date = Cherub.Config.IniReadValue("Match", "Notice");
                    if(!string.IsNullOrEmpty(Date) && Date.ToLower() != "null")
                    {
                        if (xmlProperty["Date"] == Cherub.Config.IniReadValue("Match", "Notice")) return;
                    }

                    byte[] buffer = client.DownloadData(Cherub.Files.XmlProperty.GetAttribute(xmlNode, "Address"));

                    Cherub.Config.IniWriteValue("Match", "Notice", xmlProperty["Date"]);

                    new Cherub.GUI.Announcement(UTF8Encoding.UTF8.GetString(buffer)).ShowDialog();
                }
            }
            catch(Exception ee)
            {
                Console.WriteLine("[警告] 程序读取公告时失败，由于" + ee.Message);
            }
        }


        public static List<string> Test = new List<string>();

        public static void GetTips()
        {
            var Temp = new XmlDocument();

            Temp.LoadXml(Properties.Res.Tips); ;

            XmlNodeList xmlNodeList = Temp.SelectNodes("*/record");

            foreach (XmlNode item in xmlNodeList)
            {
                XmlProperty xml = new XmlProperty(item);

                string Text = xml.GetAttribute("Text");

                if (!string.IsNullOrWhiteSpace(Text))  Test.Add(Text);
            }
        }
    }
}
