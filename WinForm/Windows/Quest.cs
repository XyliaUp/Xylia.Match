using Cherub;
using Cherub.BNS;
using Cherub.Files;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
//using static 剑灵引导程序.Resources.GameRes;
using Cherub.Sys;
using Cherub.BNS.lib;
using static Cherub.Resources.BnsCommon;


namespace 剑灵引导程序.HUD2
{
    public partial class Quest : MetroFramework.Forms.MetroForm
    {
        public static Dictionary<string, byte[]> dictionary = new Dictionary<string, byte[]>();
        public static Dictionary<string, string> Sinicization = new Dictionary<string, string>();
        public static Dictionary<string, string> FilePath = new Dictionary<string, string>(), General = new Dictionary<string, string>();
        public static decimal ID_Previous , ID_Next = new decimal();
        public static bool ExistPath = false,State_XML,State_Sinicization = false;
        public static string  DefaultTitle;
        public static Color DefaultColor, Default_QuestName;


        int Location_Y = new int();

        private void Check_Sinicization()
        {
            if(State_Sinicization)
            {
                Num.Enabled = true;
            }
        }


        public Quest()
        {            
            InitializeComponent();
            DefaultColor = RichOut.SelectionColor;
            DefaultTitle = this.Text;
            Default_QuestName = Quest_Name.ForeColor;

            ReadChecked(Show_ID_Input,"Num_Display");
            ReadChecked(Cancel_Error_Message, "Cancel_ErrorMes");

            Location_Y = Quest_Name.Location.Y + (Quest_Name.Height - Dungeon_Grade.Height) / 2;
        }

        private void ReadChecked(ToolStripMenuItem Item,string Key)
        {
            try{ Item.Checked = Boolean.Parse(Config.IniReadValue("Packing", Key));}
            catch{  }
        }

        private void Quest_Load(object sender, EventArgs e)
        {
            Num.Enabled = false;

            new Background().RunWithWorker(((o, args) =>
            {
                Read();

                if(ExistPath)
                {
                    Sinicization_Load();
                }                 
            }));        
        }

        Cherub.Sys.Menu menu = new Cherub.Sys.Menu();

        string Path = null;

        private void Read()
        {
            string GRoot = Config.IniReadValue("Game", "GRoot_Path");
            if (Directory.Exists(GRoot))
            {
                ExistPath = true;
                menu.GetDat();

                List<string> Xml_Pathes = menu.Temp(checkBox1.Checked ? Cherub.Sys.Menu.DatType.xml64 : Cherub.Sys.Menu.DatType.xml);
                List<string> Local_Pathes = menu.Temp(checkBox1.Checked ? Cherub.Sys.Menu.DatType.local64 : Cherub.Sys.Menu.DatType.local);


                RichOut.AppendText(Xml_Pathes.Count.ToString() + Local_Pathes.Count.ToString());

                ReadPath("local.dat", Local_Pathes[0]);
                ReadPath("xml.dat", Path = Xml_Pathes[0]);
            }
            else
            {
                Invoke(new Action(() =>
                {
                    this.Close();
                    Cherub.Tip.Message(Cherub.Type.MessageType.Unpack, 1);                    
                    Cherub.GUI.PublicSet.Index = 2;
                    Cherub.Sys.lib.OpenForm(new Cherub.GUI.PublicSet());
                }));

                ExistPath = false;
                //Retry.Visible = true;
            }
        }

        private void ReadPath(string name, string path)
        {
            if (File.Exists(path))
            {
                if (FilePath.ContainsKey(name))
                {
                    FilePath.Remove(name);
                }
                FilePath.Add(name, path);
                //Note.Text = "初始化路径完成";
            }
            else
            {
                ExistPath = false;
                //Retry.Visible = true;
                //Note.Text = "初始化路径失败";
            }
        }
       
        public static string Sinicize(string Text)
        {
            try
            {
                if (Sinicization.ContainsKey(Text.ToLower()))
                {
                    try {  return Sinicization[Text.ToLower()];}
                    catch { return null; }
                }
                else { return null; }            
            }
            catch  { return null; }
           
        }

        private void Num_ValueChanged(object sender, EventArgs e)
        {          
            if(Num.Value != 0)
            {
                Config.IniWriteValue("Packing", "Quest_LastID", Num.Value.ToString());
         
                Quest_Read(@"quest\questdata." + Num.Value + ".xml");
            }            
        }

        XmlDocument doc = new XmlDocument();

        public void Warning(string Str,bool LineFeed = true)
        {
            if (string.IsNullOrEmpty(Str))
                return;


            if(ShowDesc.Checked)
            {
                RichOut.SelectionColor = Color.Red;
                RichOut.AppendText(Str + (LineFeed ? "\n":null));
                RichOut.SelectionColor = DefaultColor;
            } 
        }

        public static  bool BoolConvert(string Str)
        {
            if (string.IsNullOrEmpty(Str))
                return false;


            List<string> vs = new List<string> { "y", "year", "t", "true" };

            if (vs.Contains(Str.ToLower()))
                return true;
            else
                return false;
        }


        public void ResolveTime(XmlNode xmlNode)
        {
            Xml GetAttr = new Xml(xmlNode);
            GUI.Program.QuestType.ValidTime ValidTime = new GUI.Program.QuestType.ValidTime();

            ValidTime.StartYear = GetAttr.GetAttribute("valid-date-start-year");
            ValidTime.EndYear = GetAttr.GetAttribute("valid-date-end-year");
            ValidTime.StartMonth = GetAttr.GetAttribute("valid-date-start-month");
            ValidTime.EndMonth = GetAttr.GetAttribute("valid-date-end-month");
            ValidTime.StartDay = GetAttr.GetAttribute("valid-date-start-day");
            ValidTime.EndDay = GetAttr.GetAttribute("valid-date-end-day");
            ValidTime.StartHour = GetAttr.GetAttribute("valid-time-start-hour");
            ValidTime.EndHour = GetAttr.GetAttribute("valid-time-end-hour");
            ValidTime.Monday = BoolConvert(GetAttr.GetAttribute("valid-dayofweek-mon"));
            ValidTime.Tuesday = BoolConvert(GetAttr.GetAttribute("valid-dayofweek-tue"));
            ValidTime.Wednesday = BoolConvert(GetAttr.GetAttribute("valid-dayofweek-wed"));
            ValidTime.Thursday = BoolConvert(GetAttr.GetAttribute("valid-dayofweek-thu"));
            ValidTime.Friday = BoolConvert(GetAttr.GetAttribute("valid-dayofweek-fri"));
            ValidTime.Saturday = BoolConvert(GetAttr.GetAttribute("valid-dayofweek-sat"));
            ValidTime.Sunday = BoolConvert(GetAttr.GetAttribute("valid-dayofweek-sun"));


            if (ValidTime.StartYear != null)
            {
                Warning(string.Format("任务执行时间为 {0}年{1}月{2}日～{3}年{4}月{5}日",
                    ValidTime.StartYear, ValidTime.StartMonth, ValidTime.StartDay, ValidTime.EndYear, ValidTime.EndMonth, ValidTime.EndDay));
            }




            //此次偷懒
            if(ValidTime.Friday)
            {
                if(ValidTime.Monday && ValidTime.Tuesday && ValidTime.Wednesday && ValidTime.Thursday && !ValidTime.Saturday && !ValidTime.Sunday)
                    Warning("仅工作日可执行");
                else if(ValidTime.Saturday && ValidTime.Sunday)
                    Warning("仅五、六、日可执行");
                else
                    Warning("仅周五可执行");
            }
            else
            {
                //Warning("仅周末可执行");
            }


            if (ValidTime.StartHour != null)
            {
                Warning(string.Format("每日{0}时～{1}时\n", ValidTime.StartHour, ValidTime.EndHour));
            }
        }


        bool isLoaading = false;

        /// <summary>
        /// 获得主要信息（名称、类型等）
        /// </summary>
        /// <param name="xmlNode"></param>
        public void GetInfo(XmlNodeList xmlNodeList)
        {
            if (xmlNodeList.Count == 0)
                return;


            XmlNode xmlNode = xmlNodeList[0];

            Xml GetAttr = new Xml(xmlNode); 

            Quest_Group.Text = Sinicize(GetAttr.GetAttribute("group2"));
            string QuestName = Sinicize(GetAttr.GetAttribute("name2"));
            string ResetType = GetAttr.GetAttribute("reset-type");
            string ContentType = GetAttr.GetAttribute("content-type");
            string Category = GetAttr.GetAttribute("category");
            string Faction = GetAttr.GetAttribute("main-faction");
            string MapGroup = GetAttr.GetAttribute("map-group-1-1");
            string Time = GetAttr.GetAttribute("day-of-week");
            string Attraction = GetAttr.GetAttribute("attraction-info");
            string Repeat = GetAttr.GetAttribute("max-repeat");
            string Dungeon = GetAttr.GetAttribute("dungeon");
            string Desc = GetAttr.GetAttribute("desc");
            string Completed = Sinicize(GetAttr.GetAttribute("completed-desc"));

            try { ResolveTime(xmlNode);}
            catch { }



            //判定是否可以重置
            if (BoolConvert(GetAttr.GetAttribute("reset-enable")) && GetAttr.GetAttribute("reset-item-1") != "null")
                Warning(string.Format("重置要求：需要{0} {1}个", Sinicize("Item.Name2." + GetAttr.GetAttribute("reset-item-1")), GetAttr.GetAttribute("reset-item-count-1")));


            if (Completed != null)
                Warning(ConvertTalk(Completed));


                   
            Invoke(new Action(() => {


                //教程标志
                if (GetAttr.GetAttribute("show-tutorial-tag") == "y")
                {
                    Dungeon_Grade.Visible = true;
                    Dungeon_Grade.Image = Tag_022;
                }

                if (Attraction!=null && Attraction.ToLower().Contains("raid"))
                    Dungeon_Name.ForeColor = Color.OrangeRed;

                Quest_Name.Text = Cut(QuestName) != null ? Cut(QuestName) : string.Format("{0} [丢失]", Cut(GetAttr.GetAttribute("name2"))) ;

                this.Text = DefaultTitle + "ID " + Num.Value;

                if(QuestName!=null)
                {
                    if (QuestName.Contains("Superior"))
                    {
                        Dungeon_Name.ForeColor = Color.Green;
                        Dungeon_Grade.Visible = true;
                        Dungeon_Grade.Image = Tag_137;
                    }
                    else if (QuestName.Contains("Prime"))
                    {
                        Dungeon_Name.ForeColor = Color.Blue;
                        Dungeon_Grade.Visible = true;
                        Dungeon_Grade.Image = Tag_138;

                    }
                    else if (QuestName.Contains("Hero"))
                    {
                        Dungeon_Name.ForeColor = Color.Purple;
                        Dungeon_Grade.Visible = true;
                        Dungeon_Grade.Image =Tag_139;
                    }





                    //确认副本类型
                    if (QuestName.Contains("Two"))
                    {
                        Dungeon_Type.Visible = true;
                        Dungeon_Type.Image = Tag_164;
                    }
                    else if (QuestName.Contains("Four"))
                    {
                        Dungeon_Type.Visible = true;
                        Dungeon_Type.Image = Tag_166;
                    }
                    else if (QuestName.Contains("Six"))
                    {
                        Dungeon_Type.Visible = true;
                        Dungeon_Type.Image = Tag_165;
                    }                  
                    else if (QuestName.Contains("EventMarker"))
                    {
                        Event.Visible = true;
                    }
                }

                   
                if (Xml.GetAttribute(xmlNode, "retired") == "y")
                {
                    Quest_Name.ForeColor = Color.Red;
                    Quest_Name.Text = Quest_Name.Text + " [无法执行]";

                    Tip.SetToolTip(Quest_Name, "此任务当前无法被执行！");

                    metroCheckBox1.Checked = false;
                }
                else
                {
                    metroCheckBox1.Checked = true;
                }


                //确认副本等级          
                Dungeon_ICON.Image = Map_Unit_PartyCamp;

                if (Xml.GetAttribute(xmlNode, "content-type") == "festival")
                {
                    if (Category == "attraction")
                    {
                        //活动斩首任务
                        Quest_ICON.Image = Map_attraction_start;
                        Tip.SetToolTip(Quest_ICON, "活动副本斩首任务");
                    }
                    else if(Category == "dungeon")
                    {
                        Quest_ICON.Image = Tag_073;
                        Tip.SetToolTip(Quest_ICON, "面板P的进度显示");
                    }
                    else if (ResetType == "daily" || ResetType == "weekly")
                    {
                        //活动每日任务
                        Quest_ICON.Image = Map_Festival_daily_repeat_start;
                        Tip.SetToolTip(Quest_ICON, "每日活动任务");
                    }
                    else
                    {
                        //活动支线任务
                        Quest_ICON.Image = Map_Festival_start;
                        Tip.SetToolTip(Quest_ICON, "支线活动任务");
                    }
                }
                else if (ContentType == "side-episode")
                {
                    Quest_ICON.Image = Map_Skil_start;
                    Tip.SetToolTip(Quest_ICON, "外传任务");
                }
                else if (ContentType == "party-battle" || Faction != null)
                {
                    Dungeon_ICON.Image = Quest_BattleField;
                    if (ResetType == "daily")
                    {
                        Quest_ICON.Image = Map_Faction_repeat_start;
                        Tip.SetToolTip(Quest_ICON, "势力/战场每日任务");
                    }
                    else if (ResetType == "weekly")
                    {
                        Quest_ICON.Image = Map_Faction_repeat_start;
                        Tip.SetToolTip(Quest_ICON, "势力/战场每周任务");
                    }
                    else
                    {

                        Quest_ICON.Image = Map_Faction_start;
                        Tip.SetToolTip(Quest_ICON, "势力/战场任务");
                    }

                    if (ContentType == "party-battle")
                    {
                        Dungeon_Grade.Image = Tag_146;
                        Dungeon_Grade.Visible = true;
                        Dungeon_Grade.Location = new Point(Quest_Name.Location.X + Quest_Name.Width + 10, Location_Y);
                    }

                    if (Faction == "factionmain1")
                    {
                        Quest_Group.Text = Quest_Group.Text + " [武林盟]";
                    }
                    else if (Faction == "factionmain2")
                    {
                        Quest_Group.Text = Quest_Group.Text + " [浑天教]";
                    }
                }
                else
                {
                    if (Category == "epic")
                    {
                        //RichOut.AppendText("[主线]");
                        Quest_ICON.Image = Map_Epic_Start;
                    }
                    else if (Category == "normal")
                    {
                        if (Repeat == "-1")
                        {
                            //RichOut.AppendText("[支线(无限完成)]");
                            Quest_ICON.Image = Map_Normal_Start;
                        }
                        else if (Repeat == "1")
                        {
                            if (ResetType == "daily" || ResetType == "weekly")
                            {
                                Quest_ICON.Image = Map_Repeat_start;
                            }
                            else
                            {
                                //RichOut.AppendText("[支线]");
                                Quest_ICON.Image = Map_Normal_Start;
                            }
                        }
                    }
                    else if (Category == "attraction")
                    {
                        Tip.SetToolTip(Quest_ICON, "斩首任务");
                        Quest_ICON.Image = Map_attraction_start;
                    }
                    else if (Category == "dungeon")
                    {
                        Tip.SetToolTip(Quest_ICON, "副本进度（绑定）");
                        Quest_ICON.Image = Lock;

                       
                    }
                    else if (Category == "job")
                    {
                        Quest_ICON.Image = Map_Job_Start;

                        Warning("查看此类任务时，详细描述可能会出现异常情况。");
                    }


                }

                
                if (Dungeon != null && Sinicize("Dungeon.Name2." + Dungeon) != null)
                {
                    Dungeon_Name.Text = Cut(Sinicize("Dungeon.Name2." + Dungeon));
                }
                else
                {
                    try
                    {
                        Dungeon_Name.Text = Cut(Sinicize(Attraction.Replace("duel-bot-challenge:", "AQ.DuelBotChallenge.")
                            .Replace("raid-", "").Replace("-", "").Replace("zone", "").Replace(":", ".name2.")));
                    }
                    catch { }
                }


                if (Dungeon_Name.Text != "副本名称")
                {
                    Dungeon_Name.Visible = Dungeon_ICON.Visible = true;
                    Dungeon_ICON.Location = new Point(Quest_Pnl.Width - Dungeon_Name.Width - Dungeon_ICON.Width, Location_Y);
                    Dungeon_Name.Location = new Point(Quest_Pnl.Width - Dungeon_Name.Width, Location_Y + 3);
                }


                string MapName = MapGroup;
                if (MapGroup == "anywhere")
                    MapName = Sinicize("任意地图");
                else if (Sinicize("Discovery.Name2." + MapGroup) != null)
                    MapName = Sinicize("Discovery.Name2." + MapGroup);
                else if (Sinicize(MapGroup + ".Location.name") != null)
                    MapName = Sinicize(MapGroup + ".Location.name");
                else
                    MapName = MapConvert(MapGroup);

                if (MapName !=null)
                    RichOut.AppendText("所属地图：" + MapName + "\n\n");


                Cherub.Text Text = new Text(RichOut);

                try
                {
                    Text.Temp(Sinicize(Desc) + "\n");
                }
                catch(Exception ee)
                {
                    MessageBox.Show(ee.Message);
                }

               // RichOut.AppendText(Out_Sentence((Sinicize(Desc))) + "\n\n");


                Event.Location = Dungeon_Grade.Location = new Point(Quest_Name.Location.X + Quest_Name.Width + 10, Location_Y);
                Dungeon_Type.Location = new Point(Quest_Name.Location.X + Quest_Name.Width + 15 + Dungeon_Grade.Width, Location_Y);

                try
                {
                    int HasImage = Quest_Name.Location.X + Quest_Name.Width + 98;
                    int NoImage = Quest_Name.Location.X + Quest_Name.Width + 10;

                    if (Time == "daily")
                    {
                        Reset_Type.Image = Tag_024;
                        Tip.SetToolTip(Reset_Type, "日常任务");
                        Reset_Type.Visible = true;

                        if (Dungeon_Grade.Image == null)
                            Reset_Type.Location = new Point(NoImage, Location_Y);
                        else
                            Reset_Type.Location = new Point(HasImage, Location_Y);

                    }
                    else if (Time == "weekly")
                    {
                        Reset_Type.Image = Tag_025;
                        Tip.SetToolTip(Reset_Type, "周常任务");

                        

                        Reset_Type.Visible = true;
                        if (Dungeon_Grade.Image == null)
                            Reset_Type.Location = new Point(NoImage, Location_Y);
                        else
                            Reset_Type.Location = new Point(HasImage, Location_Y);
                    }
                }
                catch { }

            }));
        }

        private string MapConvert(string Str)
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


        public string GetName_NPC(string NPC)
        {
            string Title = Sinicize(NPC.Replace("npc:", "npc.title2."));

            if (Title != null)
                Title += " ";

            return string.Format("{0}{1}", Title, Sinicize(NPC.Replace("npc:", "npc.name2.")));
        }


        /// <summary>
        /// 获得任务接取要求（职业、等级、势力等）
        /// </summary>
        /// <param name="xmlNode"></param>
        public void GetDemand(XmlNodeList xmlNodeList)
        {
            if (xmlNodeList.Count == 0)
                return;

            Xml GetAttr = new Xml(xmlNodeList[0]);
            string Level = GetAttr.GetAttribute("level") ;
            string MasteryLevel = GetAttr.GetAttribute("mastery-level");

            string Recommend = GetAttr.GetAttribute("recommended-level");
            
            string Preceding = GetAttr.GetAttribute("preceding-quest-1");

            foreach (XmlNode SubNode in xmlNodeList[0].ChildNodes)
            {
                Xml GetSubAttr = new Xml(SubNode);
                string Type = GetSubAttr.GetAttribute("type");
                string Response = GetSubAttr.GetAttribute("npc-response");
                string Completion = GetSubAttr.GetAttribute("completion-count-op");

                switch (Type)
                {
                    case "talk-to-self":
                        RichOut.AppendText("接取方式：书信对话" + Response + "\n");
                        break;


                    case "talk":
                        string Object = GetSubAttr.GetAttribute("object").ToLower();


                        RichOut.AppendText("接取方式：与 ");
                        RichOut.SelectionColor = Color.Red;
                        RichOut.AppendText(GetName_NPC(Object) == null ? Object : GetName_NPC(Object));
                        RichOut.SelectionColor = DefaultColor;
                        RichOut.AppendText(" 对话"+ Response + (Completion == "lt" ? "[首次]" :"[重复]") + "\n");

                        break;


                    case "talk-to-item":
                        string Required = GetSubAttr.GetAttribute("required-item-loss");

                        Object = GetSubAttr.GetAttribute("required-item-1").ToLower();
                        string ObjectName = Sinicize("Item.Name2." + Object);


                        RichOut.AppendText(string.Format("接取方式：阅读任务道具 " + Response));
                        Warning(ObjectName == null ? Object : ObjectName);

                        break;
                }

            
            }

            RichOut.AppendText(" \n");


            Invoke(new Action(() =>
            {
                level.Text = string.Format("要求等级：{0}{1}", Level, MasteryLevel !=null ? " 洪门" + MasteryLevel + "星级"  :null);


                RecommendedLevel.Text = "推荐等级：" + Recommend;

                if (Quest_Name.ForeColor != Color.Red)
                {
                    if (int.TryParse(Recommend,out int Result)  &&   60 - Result >= 10)
                        Quest_Name.ForeColor = Quest_Group.ForeColor;
                    else
                        Quest_Name.ForeColor = Color.Green;
                }

                if (Preceding != null)
                {
                    ID_Previous = int.Parse(Cut(Preceding));
                    Previous.Visible = true;
                }


                if (GetJob(GetAttr) != null)
                    Quest_Group.Text += " [" + GetJob(GetAttr) + "]";
            }));
        }

        private string GetJob(Xml xml)
        {
            string JOb = null;

            int i = 1;

            while(xml.GetAttribute("job-"+ i) !=null)
            {
                JOb += GUI.Program.QuestType.Job_KR_To_CN(xml.GetAttribute("job-" + i)) + ",";
                i++;
            }

            return JOb;
        }





      
        /// <summary>
        /// 读取任务内容
        /// </summary>
        /// <param name="xmlNode"></param>
        public void GetMission(XmlNodeList xmlNodes)
        {
            foreach (XmlNode xmlNode in xmlNodes)
            {
                Xml GetAttr = new Xml(xmlNode);

                string Step_Type = GetAttr.GetAttribute("completion-type");
                string Step_Desc = GetAttr.GetAttribute("desc");

                if (Step_Desc != null && Sinicization.ContainsKey(Step_Desc))
                    Step_Desc = Sinicization[Step_Desc];


                if (Step_Desc !=null || Step_Desc !=null)
                    RichOut.AppendText("[GetMission测试] " + Step_Type + Step_Desc + "\n");


                #region 读取Mission子节点

                List<string> vs = new List<string>();

                foreach (XmlNode SubNode in xmlNode.ChildNodes)
                {
                    Xml GetSubAttr = new Xml(SubNode);
                    if (SubNode.ChildNodes.Count != 0)
                    {
                        string Mission = string.Format("第{0}步  {1}", GetSubAttr.GetAttribute("id"),Sinicize(GetSubAttr.GetAttribute("name2")));
                        string Value = GetSubAttr.GetAttribute("required-register-value");
                        string ResetTeleport = GetSubAttr.GetAttribute("reset-teleport-recycle-time");

                        


                        #region 解析道具
                        Regex regex = new Regex(@"<.*?>");
                        MatchCollection matchs = regex.Matches(Mission);

                        string Str = Mission;

                        if (matchs.Count == 0)
                            RichOut.AppendText(Str + "\n");
                        else
                        {
                            for(int i=0;i<matchs.Count;i++)
                            {
                                string Temp = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n" + matchs[i].Value;
                                XmlDocument xmlDocument = new XmlDocument();
                                try
                                {
                                    xmlDocument.LoadXml(Temp);
                                    Xml GetItem = new Xml(xmlDocument.DocumentElement);

                                    string ID = GetItem.GetAttribute("id").Split(':')[1], Prefix = GetItem.GetAttribute("p").Split(':')[1];
                                    string Combine = Prefix + "." + ID;

                                    string Target = Sinicize(Combine) == null ? string.Format("$<{0}>", Combine) : string.Format("${0}", Sinicize(Combine));

                                    if (Combine.Contains("current-short-cut-key"))
                                        Target = "";

                                    Regex r = new Regex(@"<.*?>");
                                    Str = r.Replace(Str, Target, 1);                                                                   
                                }
                                catch
                                {

                                }
                            }

                            string[] Array = Str.Split('$');

                            for(int i=0;i< Array.Length;i++)
                            {
                                if(i%2 == 0)
                                    RichOut.AppendText(Array[i]);
                                else
                                {
                                    RichOut.SelectionColor = Color.Blue;
                                    RichOut.AppendText(Array[i]);
                                    RichOut.SelectionColor = Color.Black;
                                }
                            }
                            RichOut.AppendText("\n");
                        }
                        #endregion

                        if (Value != null && Value != "1")
                            Warning(string.Format("#实际任务要求#完成以下目标中的 {0} 个", Value));

                        if(BoolConvert(ResetTeleport))
                            Warning("完成此步重置遁地冷却时间");
                        
                        try
                        {
                            foreach (XmlNode Case in SubNode.ChildNodes)
                            {
                                Xml CaseAttr = new Xml(Case);
                                string CaseType = CaseAttr.GetAttribute("type");

                                string Object = null;

                                switch (CaseAttr.GetAttribute("type"))
                                {

                                    case "complete-quest":
                                        string Complete = CaseAttr.GetAttribute("complete-quest");
                                        Warning("完成 " + Sinicize(Complete.Replace("q_sub_", "quest.name2.")));
                                        break;
                                    case "killed":
                                        string TargetNpc = CaseAttr.GetAttribute("object2");
                                        int i = 1;

                                        if (TargetNpc == null)
                                        {
                                            Warning("击杀多个目标:\n");

                                            while (!string.IsNullOrEmpty(CaseAttr.GetAttribute("multi-object-" + i)))
                                            {
                                                Warning(string.Format("{0}\n", CaseAttr.GetAttribute("multi-object-" + i)));
                                                i++;
                                            }
                                        }
                                        else
                                        {

                                            string Title = Sinicize(TargetNpc.Replace("npc:", "npc.title2."));

                                            if (!string.IsNullOrEmpty(Title))
                                                Title += " ";

                                            string TargetName = Sinicize(TargetNpc.ToLower().Replace("npc:", "npc.name2."));

                                            Warning(string.Format("击杀 {0}{1}", Title, TargetName + (Value == "1" && SubNode.ChildNodes.Count != 1 ? "（任选一个）" : null)));
                                        }
                                        



                                        break;
                                    case "talk-to-self":
                                        Warning("[项目测试，此处可能会出现异常]\n");
                                        Warning("书信对话【系统标识" + CaseAttr.GetAttribute("msg") + "】");


                                        string Msg = CaseAttr.GetAttribute("msg")+ "_text_" ;
                                          i = 1;

                                        while (Sinicization.ContainsKey(Msg + i))
                                        {
                                            Warning(ConvertTalk(Sinicization[Msg + i++]));
                                        }


                                        
                                        break;
                                    case "approach":
                                        Warning("靠近绿色范围圈");
                                        break;
                                    case "npc-manipulate":
                                        Object = CaseAttr.GetAttribute("object");
                                        Warning(string.Format("对 {0} 进行操作", GetName_NPC(Object)));
                                        break;
                                    case "manipulate":
                                        Object = CaseAttr.GetAttribute("object2");
                                        //string NpcName = Sinicize(Object.ToLower().Replace("npc:", "npc.name2."));


                                        Warning(string.Format("操作 {0}", Object));
                                        break;
                                    case "talk":

                                        Object = CaseAttr.GetAttribute("object").ToLower();
                                        string ObjectName = GetName_NPC(Object);

                                        string Required = CaseAttr.GetAttribute("required-item-loss");

                                        if (Required == "y")
                                        {
                                            string Item = CaseAttr.GetAttribute("grocery");
                                            string Item_Name = Sinicize("Item.Name2." + Item);
                                            string Item_Count = CaseAttr.GetAttribute("grocery-count");

                                            Warning(string.Format("与 {2} 对话并提交{0} {1}个\n", Item_Name, Item_Count == null ? "1" : Item_Count, ObjectName));
                                        }
                                        else
                                        {
                                            string Response = CaseAttr.GetAttribute("npc-response");
                                            if (!vs.Contains(Response))
                                            {
                                                Warning(string.Format("与 {0} 对话", ObjectName));
                                                vs.Add(Response);
                                            }
                                        }

                                        Warning("对话内容" + CaseAttr.GetAttribute("npc-response") + "[暂时无法解析]\n");

                                        break;
                                    case "loot":  //任务道具类解析

                                        Object = CaseAttr.GetAttribute("object2");

                                        if (string.IsNullOrEmpty(Object))
                                        {
                                            string Probably = CaseAttr.GetAttribute("quest-symbol-drop-prob");
                                             i = 1;

                                            while(!string.IsNullOrEmpty(CaseAttr.GetAttribute("mapunit-" + i)))
                                            {
                                                Warning(string.Format("区域{0}\n{1}\n\n", CaseAttr.GetAttribute("mapunit-" + i), CaseAttr.GetAttribute("multi-object-" + i)));
                                                i++;
                                            }

                                        }
                                        else
                                        {
                                            Object = Object.ToLower();
                                            string Loot_Name = Sinicize("QLooting.name2_" + Num.Value + "_1");
                                            Warning(string.Format("从{0} 处获得任务道具 {1}", GetName_NPC(Object), Loot_Name));
                                        }    
                                        
                                        break;

                                    case "enter-zone":
                                        Object = CaseAttr.GetAttribute("object");
                                        Warning("进入 " + Object);
                                        break;
                                }
                            }
                           
                        }
                        catch(Exception ee)
                        {
                            MessageBox.Show("GetMission" + ee.Message);
                        }

                        int h = 1;

                        while(!string.IsNullOrEmpty(GetSubAttr.GetAttribute("reward-"+ h)))
                        {
                            Warning(string.Format("可选奖励{0}：{1} [暂时无法解析]",h, GetSubAttr.GetAttribute("reward-" + h)));
                            h++;
                        }
                    }
                    else
                    {
                        string Back = GetSubAttr.GetAttribute("rollback-step-id");

                        if (Back != null)
                            Warning(string.Format(" (失败将回滚第{0}步) " , Back));
                    }                
                }
                #endregion
            }
        }

        /// <summary>
        /// 读取任务完成后信息(后续任务等)
        /// </summary>
        /// <param name="xmlNode"></param>
        public void GetCompletion(XmlNodeList xmlNodeList)
        {
            try
            {
                if (xmlNodeList.Count == 0)
                return;

                foreach (XmlNode SubNode in xmlNodeList[0].ChildNodes)
                {
                    Xml GetAttr = new Xml(SubNode);

                    ID_Next = int.Parse(Cut(GetAttr.GetAttribute("quest")));
                    Next.Invoke(new Action(() => { Next.Visible = true; }));

                }
            }
            catch(Exception ee)
            {
                MessageBox.Show("GetCompletion" + ee.Message);
                Next.Invoke(new Action(() => { Next.Visible = false; }));
            }
        }
        /// <summary>
        /// 读取Transit节点信息
        /// </summary>
        /// <param name="xmlNode"></param>
        public void GetTransit(XmlNodeList xmlNodeList)
        {
            if (xmlNodeList.Count == 0)
                return;

            
            try
            {
                Xml GetAttr = new Xml(xmlNodeList[0]);
            }
            catch
            {

            }
          


        }


        public void Quest_Read(string Target)
        {
            isLoaading = true;

            new Cherub.Sys.Background().RunWithWorker(((o, args) =>
            {
                Initialize();
                try
                {
                    if (State_Sinicization)
                    {
                        RichOut.Clear();
                        dictionary.Clear();


                        dictionary = new BNSDat().ExtractFile(FilePath["xml.dat"], new List<string> { Target }, checkBox1.Checked);
                       
                        if (dictionary.ContainsKey(Target))
                        {
                            #region Quest_DataToControl
                                                
                            doc.LoadXml(Encoding.UTF8.GetString(dictionary[Target]).Remove(0, 1).Replace("???", ""));
                            dictionary.Clear();

                            //try
                            //{
                                
                            //}
                            //catch(Exception ee)
                            //{
                            //    MessageBox.Show(ee.Message);
                            //}
                            GetInfo(doc.SelectNodes("*/quest"));
                            GetDemand(doc.SelectNodes("*/*/acquisition"));

                            GetCompletion(doc.SelectNodes("*/*/completion"));


                            GetTransit(doc.SelectNodes("*/*/transit"));
                            GetMission(doc.SelectNodes("*/*/mission-step"));
                         



                           

                            #endregion
                        }
                        else
                        {
                            string ErrorMes = string.Format("检索失败，可能原因为指定任务({0})不存在。", Target);

                            if (!Cancel_Error_Message.Checked)  {  MessageBox.Show(ErrorMes, "错误", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);  }
                            else {  RichOut.AppendText(ErrorMes + "\n");  }
                        }

                        
                    }
                    else
                    {                      
                        if( MessageBox.Show(Cherub.Tip.TipContent(Cherub.Type.MessageType.Unpack,3), "错误", MessageBoxButtons.RetryCancel, MessageBoxIcon.Asterisk) == DialogResult.Retry)
                        {
                            Sinicization_Load();
                        }
                    }
                }
                catch (Exception ee)
                {
                   // RichOut.AppendText("读取错误（函数 Quest_Read）" + ee.Message + "\n");
                }

                isLoaading = false;
            }));

          
        }

        public void Sinicization_Load()
        {
            new Background().RunWithWorker(((o, args) =>
            {
                try
                {
                    RichOut.AppendText("正在初始化汉化资源......\n");
                    this.Text = DefaultTitle + "  正在初始化汉化资源";

                    Sinicization = new Cherubns().DatToMemory_General(FilePath["local.dat"],true);
                  

                    State_Sinicization = true;
                    Check_Sinicization();
                    RichOut.AppendText("初始化汉化资源完成！\n");
                    this.Text = DefaultTitle + "  初始化汉化资源完成";
                    try { Num.Value = decimal.Parse(Config.IniReadValue("Packing", "Quest_LastID")); }
                    catch{ }                                      
                }
                catch(Exception ee)
                {
                    RichOut.AppendText("初始化汉化资源失败，请稍候重试！\n");
                }
            }));
        }

        public void XML_Load()
        {
           
            new Cherub.Sys.Background().RunWithWorker(((o, args) =>
            {
                if(!State_XML)
                {
                    State_XML = true;
                    try
                    {
                        RichOut.AppendText("\n正在初始化XML资源......\n");
                        this.Text = DefaultTitle + "  正在初始化XML资源";

                        General = new Cherubns().DatToMemory_XML(FilePath["xml.dat"]);
                        
                        State_XML = true;
                        RichOut.AppendText("初始化XML资源完成！\n");
                        this.Text = DefaultTitle + "  初始化XML资源完成";
                    }
                    catch(Exception ee)
                    {
                        State_XML = false;
                        RichOut.AppendText("初始化XML资源失败，请稍候重试！\n" + ee.Message);
                    }
                }
            }));
        }


        private void Quest_FormClosing(object sender, FormClosingEventArgs e)
        {
            Sinicization.Clear();
            dictionary.Clear();
            try
            {
                this.Dispose();
            }
            catch
            {

            }
            
        }

        public static string Cut(string Str)
        {
            if(Str ==null)
                return null;


            return Str.Replace("q_sub_", "").Replace("q_epic_", "").Replace("<image enablescale=\"true\" imagesetpath=", "").Replace(" scalerate=\"1.3\"", "").Replace(" scalerate=\"1.2", "").Replace(@"/>", "")
                .Replace("_", "").Replace("00015590.", "").Replace("\"","").Replace("Tag", "").Replace("00010047.EventMarker", "")
                .Replace("Dungeon", "").Replace("common", "").Replace("Six","").Replace("Four", "").Replace("Two", "")
                .Replace("Hero", "").Replace("Prime", "").Replace("Superior", "").Replace("Normal", "")
                .Replace("ContentsDaily", "").Replace("Party", "");
        }

        public static string ConvertTalk(string Str)
        {
            if (Str == null)
                return null;


            return Str.Replace("&lt;", "<").Replace("&gt;", ">").Replace("&quot;", "\"").Replace("&apos;", "\'").Replace("<br/>", "\n");
        }



        public void Initialize()
        {
            //

            Dungeon_Name.ForeColor = Color.Black;
            Dungeon_Grade.Image = Reset_Type.Image = Quest_ICON.Image = null;
            Event.Visible = Dungeon_Grade.Visible = Dungeon_Type.Visible = Dungeon_Name.Visible = Dungeon_ICON.Visible = false;
            Dungeon_Name.Text = "副本名称";
            Quest_Group.Text = "";
            Quest_Name.ForeColor = Quest_Group.ForeColor;
            Quest_Name.Text = "";
            level.Text = "要求等级：";
            RecommendedLevel.Text = "推荐等级：";
            Reset_Type.Visible = Previous.Visible = Next.Visible = false;
            ID_Next = 0;
        }

        private void Next_Click(object sender, EventArgs e)
        {
            if(ID_Next != 0)
            {
                Num.Value = ID_Next;
            }
            
            ID_Next = 0;
        }

        private void Quest_KeyDown(object sender, KeyEventArgs e)
        {
            if(tabControl1.SelectedIndex == 0)
            {
                switch (e.KeyCode)
                {
                    case Keys.Right:
                        Next_Click(null, null);
                        break;
                    case Keys.Left:
                        Previous_Click(null, null);
                        break;
                    case Keys.Up:
                        if (this.ActiveControl != Num)                       
                            Num.Value++;                        
                        break;
                    case Keys.Down:
                        if (this.ActiveControl != Num)
                            Num.Value--;
                        break;
                }             
            }       
        }

        private void Show_ID_Input_Click(object sender, EventArgs e)
        {
            Config.IniWriteValue("Packing", "Num_Display", (Num.Visible = Show_ID_Input.Checked).ToString());        
        }

        private void Cancel_Error_Message_Click(object sender, EventArgs e)
        {
            Config.IniWriteValue("Packing", "Cancel_ErrorMes", Cancel_Error_Message.Checked.ToString());
        }

        private void tabControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                e.Handled = true;
            }
        }

        private void Previous_Click(object sender, EventArgs e)
        {
            if (ID_Previous != 0)
            {
                Num.Value = ID_Previous;
            }
            ID_Previous = 0;
        }

       
        private void sortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> Map = new Dictionary<string, string>();
            RichOut.Clear();
            Map.Clear();

            foreach (var ID in Sinicization)
            {
                if (ID.Key.Contains("map_") && ID.Key.Contains("_name"))
                {
                    Map.Add(ID.Key.Replace("map_", "").Replace("_name", ""), ID.Value);
                }
            }
            
            for (int h = 1; h < Map.Count; h++)
            {
                bool Exist = false;
               
                foreach (var ID in Map)
                {
                    if (ID.Key == h.ToString())
                    {
                        Exist = true;
                        RichOut.AppendText(h + "\t\t" + ID.Value +"\n");
                        break;
                    }
                }

                if (!Exist)
                {
                    RichOut.AppendText(h + "\t\tNull\n");
                }
            }
        }

        private void Quest_Pnl_Paint(object sender, PaintEventArgs e)
        {

        }


        #region Page3

        private void Check()
        {
            if (State_XML & State_Sinicization)
            {               
                //richOut.AppendText("所需资源全部加载完成！\n");
                this.Text = DefaultTitle + "初始化完成";
            }
            else
            {
                this.Text = DefaultTitle + "正在初始化资源文件";
                // richOut.AppendText("请耐心等待另一资源文件初始化完成！\n");
            }
        }

        private void MetroCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (isLoaading)
                return;

            ChangeQuestEnabled(metroCheckBox1.Checked);

            Quest_Read(@"quest\questdata." + Num.Value + ".xml");

        }

        private void ChangeQuestEnabled(bool Enabled)
        {
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
            newdatatosave.Add(@"quest\questdata." + Num.Value + ".xml", data);

            new BNSDat().CompressFiles(Path, newdatatosave, Path.Contains("64"));

            dictionary.Clear();
        }

        private void Quest_TextChanged(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if ( !FilePath.ContainsKey("xml.dat")|| string.IsNullOrEmpty(FilePath["xml.dat"]) || !File.Exists(FilePath["xml.dat"]))
                return;

           // new Cherub.Match.GUI.Epic(FilePath["xml.dat"]).Show();
        }

        private void ShowDesc_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            QuestSelect();
        }

       // GUI.Program.QuestSelect select = null;

        private void QuestSelect()
        {
            if (!FilePath.ContainsKey("xml.dat") || !File.Exists(FilePath["xml.dat"]))
                return;

            GUI.Program.QuestSelect select = new GUI.Program.QuestSelect(FilePath["xml.dat"]);

            if (select.ShowDialog() == DialogResult.OK)
            {
                Num.Value = int.Parse(select.Result);
            }
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Read();

            

            if (ExistPath)
            {
                Sinicization_Load();
            }
        }

        private void Reload_Click(object sender, EventArgs e)
        {
            if (ExistPath)
            {
                Sinicization_Load();
            }
        }

        #endregion
    }
}
