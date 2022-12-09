using Cherub.BNS;
using Cherub.Files;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
//using static 剑灵引导程序.Resources.GameRes;
using static Cherub.Match.lib.Read;
using static Cherub.Resources.BnsCommon;
using static Cherub.Resources.BnsTag;
using Cherub.GUI.Controls.lib;
using Cherub.Sys;

namespace Cherub.Match.lib
{
    public class Quest
    {
        public Quest.Collection QuestCollection = new Quest.Collection();
        public static Dictionary<string, string> FilePath = new Dictionary<string, string>();
        public static Dictionary<string, string> General = new Dictionary<string, string>();
        public static decimal QuestPrevious, QuestNext = new decimal();
        public static bool ExistPath = false;

        /// <summary>
        /// 任务读取 处理总函数
        /// </summary>
        /// <param name="doc"></param>
        public void QuestHandle(XmlDocument doc)
        {
            //判断是否有后续任务并显示控件
            GetMatch.Invoke(new Action(() => { GetMatch.Next.Visible = GetCompletion(doc.SelectNodes("*/*/completion"), out QuestNext); }));

            GetInfo(doc.SelectNodes("*/quest"));
            GetDemand(doc.SelectNodes("*/*/acquisition"));
            GetTransit(doc.SelectNodes("*/*/transit"));


            var MissonSteps = GetMissions(doc.SelectNodes("*/*/mission-step"));
            var Missons = GetMissions(doc.SelectNodes("*/*/mission-step/mission"));


            for (int i = 1; i <= MissonSteps.Count; i++)
            {
                //顶级内容
                XmlProperty XmlProperty = new XmlProperty(MissonSteps[i.ToString()]);

                string Temp = XmlProperty["giveup-warp-to-pcspawn"];
                Temp = XmlProperty["giveup-zone-1"];
                Temp = XmlProperty["giveup-zone-2"];
                Temp = XmlProperty["giveup-warp-to-pcspawn"];

                string Step_Type = XmlProperty["completion-type"];
                string Step_Desc = XmlProperty["desc"];

                //汉化赋值
                if (!string.IsNullOrEmpty(Sinicize(Step_Desc))) Step_Desc = Sinicize(Step_Desc);

                if (Step_Type != null || Step_Desc != null) GetMatch.Warning("[GetMission测试] " + Step_Type + Step_Desc + "\n");

                try
                {
                    //任务课题内容
                    GetMission(MissonSteps[i.ToString()].ChildNodes);
                    GetMatch.Warning(Cherub.Properties.Fixed.Separator1);
                }
                catch (Exception ee) { Console.WriteLine(ee); }
            }
        }

        /// <summary>获取任务各执行步骤的顺序号</summary>
        public static Dictionary<string, XmlNode> GetMissions(XmlNodeList xmlNodeList)
        {
            Dictionary<string, XmlNode> Dic = new Dictionary<string, XmlNode>();

            foreach (XmlNode xmlNode in xmlNodeList)
            {
                XmlProperty XmlProperty = new XmlProperty(xmlNode);

                if (XmlProperty["id"] != null) Dic.Add(XmlProperty["id"].ToString(), xmlNode);
            }
            return Dic;
        }


        public static string GetJob(XmlProperty xml)
        {
            string JOb = null;

            int i = 1;

            while (xml.GetAttribute("job-" + i) != null)
            {
                JOb += QuestType.Job_KR_To_CN(xml.GetAttribute("job-" + i)) + ",";
                i++;
            }

            return JOb;
        }


        public void ResolveTime(XmlNode xmlNode)
        {
            XmlProperty GetAttr = new XmlProperty(xmlNode);
            QuestType.ValidTime ValidTime = new QuestType.ValidTime();

            ValidTime.StartYear = GetAttr["valid-date-start-year"];
            ValidTime.EndYear = GetAttr["valid-date-end-year"];
            ValidTime.StartMonth = GetAttr["valid-date-start-month"];
            ValidTime.EndMonth = GetAttr["valid-date-end-month"];
            ValidTime.StartDay = GetAttr["valid-date-start-day"];
            ValidTime.EndDay = GetAttr["valid-date-end-day"];
            ValidTime.StartHour = GetAttr["valid-time-start-hour"];
            ValidTime.EndHour = GetAttr["valid-time-end-hour"];
            ValidTime.Monday = Cherub.Sys.Convert.BoolConvert(GetAttr["valid-dayofweek-mon"]);
            ValidTime.Tuesday = Cherub.Sys.Convert.BoolConvert(GetAttr["valid-dayofweek-tue"]);
            ValidTime.Wednesday = Cherub.Sys.Convert.BoolConvert(GetAttr["valid-dayofweek-wed"]);
            ValidTime.Thursday = Cherub.Sys.Convert.BoolConvert(GetAttr["valid-dayofweek-thu"]);
            ValidTime.Friday = Cherub.Sys.Convert.BoolConvert(GetAttr["valid-dayofweek-fri"]);
            ValidTime.Saturday = Cherub.Sys.Convert.BoolConvert(GetAttr["valid-dayofweek-sat"]);
            ValidTime.Sunday = Cherub.Sys.Convert.BoolConvert(GetAttr["valid-dayofweek-sun"]);


            if (ValidTime.StartYear != null)
            {
                GetMatch.Warning(string.Format("任务执行时间为 {0}年{1}月{2}日～{3}年{4}月{5}日",
                    ValidTime.StartYear, ValidTime.StartMonth, ValidTime.StartDay, ValidTime.EndYear, ValidTime.EndMonth, ValidTime.EndDay));
            }




            //此次偷懒
            if (ValidTime.Friday)
            {
                if (ValidTime.Monday && ValidTime.Tuesday && ValidTime.Wednesday && ValidTime.Thursday && !ValidTime.Saturday && !ValidTime.Sunday)
                    GetMatch.Warning("仅工作日可执行");
                else if (ValidTime.Saturday && ValidTime.Sunday)
                    GetMatch.Warning("仅五、六、日可执行");
                else
                    GetMatch.Warning("仅周五可执行");
            }
            else
            {
                //Warning("仅周末可执行");
            }


            if (ValidTime.StartHour != null)
            {
                GetMatch.Warning(string.Format("每日{0}时～{1}时\n", ValidTime.StartHour, ValidTime.EndHour));
            }
        }


        public static string GetName_NPC(string Object)
        {
            if (string.IsNullOrEmpty(Object)) return null;

            string Title = Sinicize(Object.ToLower().Replace("npc:", "npc.title2."));

            if (Title != null)
                Title += " ";

            string Result = string.Format("{0}{1}", Title, Sinicize(Object.ToLower().Replace("npc:", "npc.name2.")));

            if (string.IsNullOrEmpty(Result))
                return Object;
            else
                return Result;
        }

        public static string GetItemName(string Object)
        {
            if (string.IsNullOrEmpty(Object)) return null;

            string Result = string.Format("{0}", Sinicize("item.name2." + Object));

            if (string.IsNullOrEmpty(Result)) return Object;
            else return Result;
        }



        public Quest(Match_MainForm match)
        {
            GetMatch = match;
        }

        public Match_MainForm GetMatch = null;

        public struct Collection
        {
            public Color DefaultColor;
            public string DefaultTitle;
            public Color Default_QuestName;
            public Color Color_BG;
        }

        public static string ConvertTalk(string Str, bool Test = false)
        {
            if (Str == null)
                return null;

            Str = Str.Replace("&lt;", "<").Replace("&gt;", ">").Replace("&quot;", "\"").Replace("&apos;", "\'").Replace("<br/>", "\n");


            if (Test)
                return Regex.Replace(Str, @"<.*?>", "#");
            else
                return Str;
        }

        public static string QuestCut(string Str)
        {
            if (Str == null)
                return null;


            return Str.Replace("q_sub_", "").Replace("q_epic_", "").Replace("<image enablescale=\"true\" imagesetpath=", "").Replace(" scalerate=\"1.3\"", "").Replace(" scalerate=\"1.2", "").Replace(@"/>", "")
                .Replace("_", "").Replace("00015590.", "").Replace("\"", "").Replace("Tag", "").Replace("00010047.EventMarker", "")
                .Replace("Dungeon", "").Replace("common", "").Replace("Six", "").Replace("Four", "").Replace("Two", "")
                .Replace("Hero", "").Replace("Prime", "").Replace("Superior", "").Replace("Normal", "")
                .Replace("ContentsDaily", "").Replace("Party", "");
        }

        public static string GetMapGroup(string Info)
        {
            if (string.IsNullOrWhiteSpace(Info))
                return null;
            else if (Info == "anywhere")
                return Sinicize("任意地图");
            else if (Sinicize("Discovery.Name2." + Info) != null)
                return Sinicize("Discovery.Name2." + Info);
            else if (Sinicize(Info + ".Location.name") != null)
                return Sinicize(Info + ".Location.name");
            else
                return MapConvert(Info);
        }




        public static string MapConvert(string Str)
        {
            if (Str.ToLower().Contains("suwal"))
                return "水月平原";
            else if (Str.ToLower().Contains("startzone"))
                return "无日峰";
            else if (Str.ToLower().Contains("cheonmyunggung"))
                return "天命宫";
            else if (Str.ToLower().Contains("duel"))
                return "比武场";
            else
                return Str;
        }

        public void Initialize()
        {
            if (GetMatch == null)
                return;

            GetMatch.richTextBox2.Clear();
            GetMatch.Dungeon_Name.ForeColor = Color.Black;
            GetMatch.Dungeon_Grade.Image = GetMatch.Reset_Type.Image = GetMatch.Quest_ICON.Image = null;
            GetMatch.Event.Visible = GetMatch.Dungeon_Grade.Visible = GetMatch.Dungeon_Type.Visible = GetMatch.Dungeon_Name.Visible = GetMatch.Dungeon_ICON.Visible = false;
            GetMatch.Dungeon_Name.Text = "副本名称";
            GetMatch.Quest_Group.Text = "";
            GetMatch.Quest_Name.ForeColor = GetMatch.Quest_Group.ForeColor;
            GetMatch.Quest_Name.Text = "";
            GetMatch.level.Text = "要求等级：";
            GetMatch.RecommendedLevel.Text = "推荐等级：";
            GetMatch.Reset_Type.Visible = GetMatch.Previous.Visible = GetMatch.Next.Visible = false;
            QuestPrevious = 0;
        }




        public static void ChangeQuestState(string Path, int Value, bool Enabled)
        {
            XmlDocument doc = new XmlDocument();

            XmlNodeList xmlNodeList = doc.SelectNodes("*/quest");
            XmlElement Node = (XmlElement)xmlNodeList[0];
            Node.SetAttribute("retired", Enabled ? "n" : "y");//设置该节点displayNum属性


            byte[] data;
            using (MemoryStream ms = new MemoryStream())
            {
                XmlDocument xmlDoc = new XmlDocument();
                doc.Save(ms);
                data = ms.ToArray();
            }

            //  var addinv2 = System.Text.Encoding.UTF8.GetBytes(richOut.Text);

            Dictionary<string, byte[]> newdatatosave = new Dictionary<string, byte[]>();
            newdatatosave.Add(@"quest\questdata." + Value + ".xml", data);

            new BNSDat().CompressFiles(Path, newdatatosave, Path.Contains("64"));

            //dictionary.Clear();
        }


        #region 解析任务对话内容

        /// <summary>
        /// 解析对话内容
        /// </summary>
        /// <param name="Sign">标识号</param>
        /// <returns></returns>
        public static string GetQrsp(string Sign)
        {
            string Result = null;


            if (!string.IsNullOrEmpty(Sinicize(string.Format("q_{0}_indi_1_text", Sign))))
                Result += "靠近时说：" + Sinicize(string.Format("q_{0}_indi_1_text", Sign)) + "\n";

            int i = 1;


            string QusetText = null;


            while (!string.IsNullOrEmpty(QusetText = Sinicize(string.Format("q_{0}_text_{1}", Sign, i))))
            {
                Result += QusetText + "\n";


                string NextBtn = Sinicize(string.Format("q_{0}_nextbutton_{1}", Sign, i));

                if (!string.IsNullOrEmpty(NextBtn))
                    Result += "我：" + NextBtn + "\n";



                Result += "\n";

                i++;

            }

            string EndokText = Sinicize(string.Format("q_{0}_endok_text", Sign));


            if (!string.IsNullOrEmpty(EndokText))
                Result += "对话结束时：" + EndokText + "\n";

            return Result;
        }
        #endregion


        /// <summary>
        /// 读取任务完成后信息(后续任务等)
        /// </summary>
        /// <param name="xmlNode"></param>
        public static bool GetCompletion(XmlNodeList xmlNodeList, out decimal NextQuest)
        {
            NextQuest = -1;

            try
            {
                if (xmlNodeList.Count == 0)
                    return false;

                foreach (XmlNode SubNode in xmlNodeList[0].ChildNodes)
                {
                    XmlProperty GetAttr = new XmlProperty(SubNode);

                    NextQuest = int.Parse(QuestCut(GetAttr["quest"]));
                    return true;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("GetCompletion" + ee.Message);
                return false;
            }


            return false;
        }


        public void GetTransit(XmlNodeList xmlNodeList)
        {
            if (xmlNodeList.Count == 0)
                return;


            try
            {
                XmlProperty GetAttr = new XmlProperty(xmlNodeList[0]);
            }
            catch
            {

            }
        }

        /// <summary>
        /// 读取任务内容
        /// </summary>
        /// <param name="xmlNode"></param>
        public void GetMission(XmlNodeList xmlNodes)
        {
            #region 读取Mission子节点
            List<string> vs = new List<string>();

            foreach (XmlNode SubNode in xmlNodes)
            {
                XmlProperty GetSubAttr = new XmlProperty(SubNode);
                if (SubNode.ChildNodes.Count != 0)
                {
                    string Mission = string.Format("第{0}步  {1}", GetSubAttr["id"], Sinicize(GetSubAttr["name2"]));
                    string Value = GetSubAttr["required-register-value"];
                    string ResetTeleport = GetSubAttr["reset-teleport-recycle-time"];

                    #region 读取Variation
                    QuestType.Variation GetVariation = new QuestType.Variation();
                    GetVariation.Field_PlayPoint = GetSubAttr["variation-required-field-play-point-1"];
                    GetVariation.PlayPoint_Reward = GetSubAttr["variation-reward-field-play-point-1"];
                    GetVariation.Register_Value = GetSubAttr["variation-required-register-value-1"];
                    GetVariation.RewardScore = GetSubAttr["variation-reward-tendency-score-1"];
                    #endregion


                    #region 解析道具
                    foreach (XmlProperty item in Cherub.Files.XML_BNS.CreatArray(Mission))
                    {
                        string Signal = item["p"].Replace("id:", null) + "." + item["id"].Replace("skill:", null);

                        if (Sinicize(Signal) == null) Console.WriteLine(Signal);
                        else Console.WriteLine(Sinicize(Signal));

                    }



                    //Regex regex = new Regex(@"<arg .*?>");
                    //MatchCollection matchs = regex.Matches(Mission);

                    //string Str = Mission;

                    //if (matchs.Count == 0) GetMatch.Warning(Str + "\n");
                    //else
                    //{
                    //    for (int i = 0; i < matchs.Count; i++)
                    //    {
                    //        string Temp = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n" + matchs[i].Value;
                    //        XmlDocument xmlDocument = new XmlDocument();
                    //        try
                    //        {
                    //            xmlDocument.LoadXml(Temp);
                    //            XmlProperty GetItem = new XmlProperty(xmlDocument.DocumentElement);

                    //            string ID = GetItem.GetAttribute("id").Split(':')[1], Prefix = GetItem.GetAttribute("p").Split(':')[1];
                    //            string Combine = Prefix + "." + ID;

                    //            string Target = Sinicize(Combine) == null ? string.Format("$<{0}>", Combine) : string.Format("${0}", Sinicize(Combine));

                    //            if (Combine.Contains("current-short-cut-key"))
                    //                Target = "";

                    //            Regex r = new Regex(@"<.*?>");
                    //            Str = r.Replace(Str, Target, 1);
                    //        }
                    //        catch
                    //        {

                    //        }
                    //    }

                    //    string[] Array = Str.Split('$');

                    //    for (int i = 0; i < Array.Length; i++)
                    //    {
                    //        if (i % 2 == 0) GetMatch.richTextBox2.AppendText(Array[i]);
                    //        else
                    //        {
                    //            GetMatch.richTextBox2.SelectionColor = Color.Blue;
                    //            GetMatch.richTextBox2.AppendText(Array[i]);
                    //            GetMatch.richTextBox2.SelectionColor = Color.Black;
                    //        }
                    //    }

                    //    GetMatch.richTextBox2.AppendText("\n");
                    //}
                    #endregion

                    if (!string.IsNullOrEmpty(Value) && Value != "1") GetMatch.Warning(string.Format("#实际任务要求#完成以下目标中的 {0} 个", Value));

                    if (Sys.Convert.BoolConvert(ResetTeleport)) GetMatch.Warning("完成此步重置遁地冷却时间");

                    try
                    {
                        foreach (XmlNode Case in SubNode.ChildNodes)
                        {
                            XmlProperty CaseAttr = new XmlProperty(Case);
                            string CaseType = CaseAttr["type"];
                            string Object = CaseAttr["object"];

                            if (string.IsNullOrWhiteSpace(Object)) Object = CaseAttr["object2"];

                            string ObjectName = GetName_NPC(Object);


                            switch (CaseType)
                            {
                                case "complete-quest":
                                    string Complete = CaseAttr["complete-quest"];
                                    GetMatch.Warning("完成 " + Sinicize(Complete.Replace("q_sub_", "quest.name2.")));
                                    break;
                                case "killed":
                                    string TargetNpc = CaseAttr["object2"];
                                    int i = 1;

                                    if (TargetNpc == null)
                                    {
                                        GetMatch.Warning("击杀多个目标:\n");

                                        while (!string.IsNullOrEmpty(CaseAttr["multi-object-" + i]))
                                        {
                                            GetMatch.Warning(string.Format("{0}\n", CaseAttr["multi-object-" + i]));
                                            i++;
                                        }
                                    }
                                    else
                                    {
                                        GetMatch.Warning(string.Format("击杀 {0}", GetName_NPC(TargetNpc) + (Value == "1" && SubNode.ChildNodes.Count != 1 ? "（任选一个）" : null)));
                                    }




                                    break;
                                case "talk-to-self":
                                    //  Warning("[项目测试，此处可能会出现异常]\n");
                                    GetMatch.Warning("书信对话" + GetMatch.Test_Qrsp(CaseAttr.GetAttribute("msg")) + "\n");


                                    string Msg = CaseAttr.GetAttribute("msg") + "_text_";
                                    i = 1;

                                    while (Sinicization.ContainsKey(Msg + i)) GetMatch.Warning(Sinicization[Msg + i++]);

                                    break;
                                case "approach":
                                    if (!string.IsNullOrEmpty(ObjectName)) GetMatch.Warning(string.Format("靠近 {0}", ObjectName));
                                    else GetMatch.Warning("靠近绿色范围圈");
                                    break;
                                case "npc-manipulate":
                                    GetMatch.Warning(string.Format("对 {0} 进行操作", GetName_NPC(Object)));
                                    break;

                                case "window-open":  //打开窗口
                                    GetMatch.Warning(string.Format("打开 窗口"));
                                    break;

                                case "equip-item":   //装备物品
                                    GetMatch.Warning(string.Format("装备 {0}", GetItemName(CaseAttr.GetAttribute("item"))));
                                    break;

                                case "manipulate":
                                    //string NpcName = Sinicize(Object.ToLower().Replace("npc:", "npc.name2."));


                                    GetMatch.Warning(string.Format("操作 {0}", Object));
                                    break;
                                case "talk":
                                    if (CaseAttr["required-item-loss"] == "y")
                                    {
                                        string Item = CaseAttr.GetAttribute("grocery");
                                        string Item_Name = Sinicize("Item.Name2." + Item);
                                        string Item_Count = CaseAttr.GetAttribute("grocery-count");

                                        GetMatch.Warning(string.Format("与 {2} 对话并提交{0} {1}个\n", Item_Name, Item_Count == null ? "1" : Item_Count, ObjectName));
                                    }
                                    else
                                    {
                                        string Response = CaseAttr.GetAttribute("npc-response");
                                        if (!vs.Contains(Response))
                                        {
                                            GetMatch.Warning(string.Format("与 {0} 对话", RichOutLib.Combine(ObjectName)));
                                            vs.Add(Response);
                                        }
                                    }

                                    GetMatch.Warning("对话内容" + GetMatch.Test_Qrsp(CaseAttr.GetAttribute("npc-response"), CaseAttr["completion-count-op"]));

                                    break;
                                case "loot":  //任务道具类解析

                                    Object = CaseAttr.GetAttribute("object2");

                                    if (string.IsNullOrEmpty(Object))
                                    {
                                        string Probably = CaseAttr.GetAttribute("quest-symbol-drop-prob");
                                        i = 1;

                                        while (!string.IsNullOrEmpty(CaseAttr.GetAttribute("mapunit-" + i)))
                                        {
                                            GetMatch.Warning(string.Format("区域{0}\n{1}\n\n", CaseAttr.GetAttribute("mapunit-" + i), CaseAttr.GetAttribute("multi-object-" + i)));
                                            i++;
                                        }
                                    }
                                    else
                                    {
                                        string Loot = "QLooting.name2_" + CaseAttr.GetAttribute("looting").Replace("q_", "").Replace("_icon", "");

                                        GetMatch.Warning(string.Format("从{0} 处获得任务道具 {1}", GetName_NPC(Object), Sinicize(Loot)));
                                    }

                                    break;

                                case "enter-zone":
                                    Object = CaseAttr.GetAttribute("object");
                                    GetMatch.Warning("进入 " + Object);
                                    break;
                            }
                        }

                    }
                    catch
                    {
                        throw;
                    }

                    int h = 1;

                    while (!string.IsNullOrEmpty(GetSubAttr.GetAttribute("reward-" + h)))
                    {
                        GetMatch.Warning(string.Format("可选奖励{0}：{1} [暂时无法解析]", h, GetSubAttr.GetAttribute("reward-" + h)));
                        h++;
                    }

                    if (!string.IsNullOrWhiteSpace(GetVariation.RewardScore)) GetMatch.Warning(string.Format("获得龙果{0}个", GetVariation.RewardScore));
                }
                else
                {
                    string Back = GetSubAttr.GetAttribute("rollback-step-id");

                    if (Back != null) GetMatch.Warning(string.Format(" (失败将回滚第{0}步) ", Back));
                }
            }
            #endregion
            //}
        }


        public void GetInfo(XmlNodeList xmlNodeList)
        {
            if (xmlNodeList.Count == 0) return;

            XmlNode xmlNode = xmlNodeList[0];

            XmlProperty GetAttr = new XmlProperty(xmlNode);

            GetMatch.Quest_Group.Text = Sinicize(GetAttr["group2"]);

            #region 读取任务文件信息
            QuestType.QuestInfo Info = new QuestType.QuestInfo();
            Info.Name = Sinicize(GetAttr["name2"]);
            Info.ResetType = GetAttr["reset-type"];
            Info.ContentType = GetAttr["content-type"];
            Info.Category = GetAttr["category"];
            Info.Faction = GetAttr["main-faction"];
            Info.MapGroup = GetAttr["map-group-1-1"];
            Info.Time = GetAttr["day-of-week"];
            Info.Attraction = GetAttr["attraction-info"];
            Info.Repeat = GetAttr["max-repeat"];
            Info.Dungeon = GetAttr["dungeon"];
            Info.Desc = GetAttr["desc"];
            Info.Completed = Sinicize(GetAttr["completed-desc"]);

            Info.Broadcast = Sinicize(GetAttr["broadcast-category"]);
            #endregion



            try { ResolveTime(xmlNode); }
            catch { }


            //判定是否可以重置
            if (Sys.Convert.BoolConvert(GetAttr["reset-enable"]) && GetAttr["reset-item-1"] != "null")
                GetMatch.Warning(string.Format("重置要求：需要{0} {1}个", Sinicize("Item.Name2." + GetAttr["reset-item-1"]), GetAttr["reset-item-count-1"]));

            //显示回忆信息
            if (GetMatch.Show_Completed.Checked && Info.Completed != null)
                GetMatch.richTextBox2.Output(RichOutLib.Combine(string.Format("● 红尘往事\n{0}\n{1}\n", Info.Completed, Cherub.Properties.Fixed.Separator1), Color.Orange, 11));


            GetMatch.Invoke(new Action(() =>
            {
                //教程标志
                if (GetAttr["show-tutorial-tag"] == "y")
                {
                    GetMatch.Dungeon_Grade.Visible = true;
                    GetMatch.Dungeon_Grade.Image = Tag_022;
                }

                if (Info.Attraction != null && Info.Attraction.ToLower().Contains("raid"))
                    GetMatch.Dungeon_Name.ForeColor = Color.OrangeRed;

                GetMatch.Quest_Name.Text = QuestCut(Info.Name) != null ? QuestCut(Info.Name) : string.Format("{0} [丢失]", QuestCut(GetAttr["name2"]));

                GetMatch.Text = QuestCollection.DefaultTitle + "ID " + GetMatch.Num.Value;

                #region 解析任务名称
                if (!string.IsNullOrWhiteSpace(Info.Name))
                {
                    if (Info.Name.Contains(new string[] { "Superior", "Prime", "Hero" }))
                    {
                        GetMatch.Dungeon_Grade.Visible = true;

                        if (Info.Name.Contains("Superior"))
                        {
                            GetMatch.Dungeon_Name.ForeColor = Color.Green;
                            GetMatch.Dungeon_Grade.Image = Tag_137;
                        }
                        else if (Info.Name.Contains("Prime"))
                        {
                            GetMatch.Dungeon_Name.ForeColor = Color.Blue;
                            GetMatch.Dungeon_Grade.Image = Tag_138;
                        }
                        else if (Info.Name.Contains("Hero"))
                        {
                            GetMatch.Dungeon_Name.ForeColor = Color.Purple;
                            GetMatch.Dungeon_Grade.Image = Tag_139;
                        }
                    }
                    if (Info.Name.Contains(new string[] { "Two", "Four", "Six" }))
                    {
                        GetMatch.Dungeon_Type.Visible = true;
                        if (Info.Name.Contains("Two")) GetMatch.Dungeon_Type.Image = Tag_164;
                        else if (Info.Name.Contains("Four")) GetMatch.Dungeon_Type.Image = Tag_166;
                        else if (Info.Name.Contains("Six")) GetMatch.Dungeon_Type.Image = Tag_165;
                    }
                    if (Info.Name.Contains("EventMarker")) GetMatch.Event.Visible = true;
                }
                #endregion

                #region 判定是否为无法执行状态
                if (GetMatch.metroCheckBox1.Checked = Cherub.Sys.Convert.BoolConvert(GetAttr["retired"]))
                {
                    //  Tip.SetToolTip(Quest_Name, "此任务当前无法被执行！");
                    GetMatch.Quest_Name.ForeColor = Color.Red;
                    GetMatch.Quest_Name.Text = GetMatch.Quest_Name.Text + " [无法执行]";
                }
                #endregion


                //确认副本等级          
                GetMatch.Dungeon_ICON.Image = Map_Unit_PartyCamp;


                if (Info.ContentType == "party-battle" || !string.IsNullOrWhiteSpace(Info.Faction))
                {
                    GetMatch.Dungeon_ICON.Image = Quest_BattleField;

                    if (Info.ContentType == "party-battle")
                    {
                        GetMatch.Dungeon_Grade.Image = Tag_146;
                        GetMatch.Dungeon_Grade.Visible = true;
                        GetMatch.Dungeon_Grade.Location = new Point(GetMatch.Quest_Name.Location.X + GetMatch.Quest_Name.Width + 10, GetMatch.Location_Y);
                    }

                    //追加显示势力
                    if (Info.Faction == "factionmain1") GetMatch.Quest_Group.Text += " [武林盟]";
                    else if (Info.Faction == "factionmain2") GetMatch.Quest_Group.Text += " [浑天教]";
                }


                //获得任务图标
               // GetMatch.Quest_ICON.Image = QuestSelect.GetQuestICON(Info);


                if (Info.Dungeon != null && Sinicize("Dungeon.Name2." + Info.Dungeon) != null)
                {
                    GetMatch.Dungeon_Name.Text = QuestCut(Sinicize("Dungeon.Name2." + Info.Dungeon));
                }
                else
                {
                    try
                    {
                        GetMatch.Dungeon_Name.Text = QuestCut(Sinicize(Info.Attraction.Replace("duel-bot-challenge:", "AQ.DuelBotChallenge.")
                            .Replace("raid-", "").Replace("-", "").Replace("zone", "").Replace(":", ".name2.")));
                    }
                    catch { }
                }


                GetMatch.richTextBox2.Output(RichOutLib.Combine("● 任务内容\n", Color.Orange, 11));



                #region 获得执行地图区域
                string MapGroup = GetMapGroup(Info.MapGroup);
                if (!string.IsNullOrWhiteSpace(MapGroup)) GetMatch.richTextBox2.Output("所属地图：" + MapGroup + "\n\n");
                #endregion



                try
                {
                    GetMatch.richTextBox2.Output(Sinicize(Info.Desc) + "\n");
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                }

                GetMatch.Event.Location = GetMatch.Dungeon_Grade.Location = new Point(GetMatch.Quest_Name.Location.X + GetMatch.Quest_Name.Width + 10, GetMatch.Location_Y);
                GetMatch.Dungeon_Type.Location = new Point(GetMatch.Quest_Name.Location.X + GetMatch.Quest_Name.Width + 15 + GetMatch.Dungeon_Grade.Width, GetMatch.Location_Y);

                try
                {
                    int HasImage = GetMatch.Quest_Name.Location.X + GetMatch.Quest_Name.Width + 98;
                    int NoImage = GetMatch.Quest_Name.Location.X + GetMatch.Quest_Name.Width + 10;

                    if (Info.Time == "daily" || Info.Time == "weekly")
                    {
                        GetMatch.Reset_Type.Visible = true;
                        GetMatch.Reset_Type.Location = new Point(GetMatch.Dungeon_Grade.Image == null ? NoImage : HasImage, GetMatch.Location_Y);


                        if (Info.Time == "daily") GetMatch.Reset_Type.Image = Tag_024;
                        else if (Info.Time == "weekly") GetMatch.Reset_Type.Image = Tag_025;
                    }
                }
                catch { }

            }));
        }


        /// <summary>
        /// 获得任务接取要求（职业、等级、势力等）
        /// </summary>
        /// <param name="xmlNode"></param>
        public void GetDemand(XmlNodeList xmlNodeList)
        {
            if (xmlNodeList.Count == 0) return;

            XmlProperty XPPY = new XmlProperty(xmlNodeList[0]);

            List<XmlProperty> Acquisitions = new List<XmlProperty>();
            List<string> Responses = new List<string>();


            foreach (XmlNode SubNode in xmlNodeList[0].ChildNodes)
            {
                XmlProperty GetSubAttr = new XmlProperty(SubNode);
                if (Responses.Contains(GetSubAttr["npc-response"])) continue;

                Responses.Add(GetSubAttr["npc-response"]);
                Acquisitions.Add(GetSubAttr);
            }


            GetMatch.richTextBox2.AppendText("\n");

            foreach (XmlProperty Acquisition in Acquisitions)
            {
                string Type = Acquisition["type"];
                string Response = Acquisition["npc-response"];
                string Completion = Acquisition["completion-count-op"];

                switch (Type)
                {
                    case "talk-to-self":
                        GetMatch.richTextBox2.AppendText("接取方式：书信对话" + Response + "\n");
                        break;


                    case "talk":
                        string Object = Acquisition["object"];

                        string ObjectName = GetName_NPC(Object);
                        if (ObjectName == null) ObjectName = Object;


                        GetMatch.Warning(string.Format("接取方式：与 {0} 对话\n{1}\n", RichOutLib.Combine(ObjectName), GetMatch.Test_Qrsp(Response, Completion)));
                        break;

                    case "talk-to-item":
                        string Required = Acquisition["required-item-loss"];

                        Object = Acquisition["required-item-1"];
                        ObjectName = Sinicize("Item.Name2." + Object);

                        GetMatch.richTextBox2.AppendText(string.Format("接取方式：阅读任务道具 " + Response));
                        GetMatch.Warning(ObjectName == null ? Object : ObjectName);

                        break;
                }

                GetMatch.Warning(Cherub.Properties.Fixed.Separator1);
            }

            GetMatch.Invoke(new Action(() =>
            {
                GetMatch.level.Text = string.Format("要求等级：{0}{1}", XPPY["level"], XPPY["mastery-level"] != null ? " 洪门" + XPPY["mastery-level"] + "星级" : null);


                GetMatch.RecommendedLevel.Text = "推荐等级：" + XPPY["recommended-level"];

                if (GetMatch.Quest_Name.ForeColor != Color.Red)
                {
                    if (int.TryParse(XPPY["recommended-level"].ToString(), out int Result) && 60 - Result >= 10)
                        GetMatch.Quest_Name.ForeColor = GetMatch.Quest_Group.ForeColor;
                    else
                        GetMatch.Quest_Name.ForeColor = Color.Green;
                }

                if (XPPY["preceding-quest-1"] != null)
                {
                    QuestPrevious = int.Parse(QuestCut(XPPY["preceding-quest-1"].ToString()));
                    GetMatch.Previous.Visible = true;
                }


                if (GetJob(XPPY) != null) GetMatch.Quest_Group.Text += " [" + GetJob(XPPY) + "]";
            }));
        }



        public static string MapSort()
        {
            if (!GetMapName(out Dictionary<string, string> Map))
                return "加载失败";


            string Str = null;

            for (int h = 1; h < Map.Count; h++)
            {
                bool Exist = false;

                foreach (var ID in Map)
                {
                    if (ID.Key == h.ToString())
                    {
                        Exist = true;
                        Str += h + "\t\t" + ID.Value + "\n";
                        break;
                    }
                }

                if (!Exist)
                {
                    Str += h + "\t\tNull\n";
                }
            }


            if (Str == null) return "检索无结果";
            else return Str;
        }

        public static string MapSort2()
        {
            string Str = null;

            Dictionary<string, string> Discoverys = GetDiscoveryName();

            if (Discoverys == null) return "加载失败";

            foreach (var Discovery in Discoverys)
            {
                Str += Discovery.Key.Replace("discovery.name2.", null) + "\t\t" + Discovery.Value + "\n";
            }

            return Str;
        }

        public static Dictionary<string, string> GetDiscoveryName()
        {
            Dictionary<string, string> Discovery = new Dictionary<string, string>();


            if (!CheckSinicization()) return null;


            foreach (var ID in Sinicization)
            {
                if (ID.Key.Contains("discovery.name2."))
                {
                    Discovery.Add(ID.Key, ID.Value);
                }
            }

            return Discovery;
        }

        public static void ReadPath(string name, string path)
        {
            if (File.Exists(path))
            {
                if (FilePath.ContainsKey(name))
                    FilePath.Remove(name);

                FilePath.Add(name, path);
            }
            else
            {
                ExistPath = false;
            }
        }

        public static void Load_Sinicization(bool is64)
        {
            Sys.Menu menu = new Sys.Menu();

            menu.GetDat();

            List<string> Local_Pathes = menu.GetDatPath(is64 ? Cherub.Sys.Menu.DatType.local64 : Cherub.Sys.Menu.DatType.local);

            Sinicization = new Cherub.BNS.lib.Cherubns().DatToMemory_General(Local_Pathes[0], true);
        }



        public static bool CheckSinicization()
        {
            if (Sinicization.Count == 0)
            {
                try
                {
                    Load_Sinicization(false);
                    return true;
                }
                catch (Exception ee)
                {
                    Console.WriteLine(ee);
                    return false;
                }
            }
            else
                return true;
        }


        public static bool GetMapName(out Dictionary<string, string> Dic)
        {
            Dictionary<string, string> Map = new Dictionary<string, string>();


            if (!CheckSinicization()) Dic = null;


            foreach (var ID in Sinicization)
            {
                if (ID.Key.Contains("map_") && ID.Key.Contains("_name")) Map.Add(ID.Key.Replace("map_", "").Replace("_name", ""), ID.Value);
            }


            Dic = Map;
            return true;
        }

        public static string UnknownMapList()
        {
            string Content = null;


            Dictionary<string, string> Discoverys = GetDiscoveryName();

            GetMapName(out Dictionary<string, string> Map);



            if (Discoverys == null || Map == null)
                return "加载失败";


            foreach (var Discovery in Discoverys)
            {
                if (Map.ContainsValue(Discovery.Value))
                    continue;
                else
                    Content += string.Format("{0}\t({1})\n", Discovery.Value, Discovery.Key.Replace("discovery.name2.", null));
            }

            return Content;
        }
    }


}
