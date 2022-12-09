using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Cherub.Match.Lib
{
    public class Test
    {
        public Test(RichTextBox richOut)
        {
            RichOut = richOut;
        }

        RichTextBox RichOut = null;

        public static string OutHandle(string Str)
        {
            if (Str.Contains("<br/>") || Str.Contains("</p>"))
                Str =  "\n" + Str;

            return Str + "\n";
        }

        public void OutputWithColor(string Str)
        {
            string Pattern = @"<font name=.*?>";
            Regex Regex = new Regex(Pattern, RegexOptions.IgnoreCase);
            MatchCollection matches = Regex.Matches(Str);
            
            #region 分段获得字体颜色并存储
            Dictionary<int, Color> list = new Dictionary<int, Color>();
            int h = 1;

            foreach (System.Text.RegularExpressions.Match match in matches)
            {
                list.Add(h, GetColor(match.Value));
                h = h + 2;
            }
            #endregion


            #region 从存储中读取颜色并导出
            if (Regex.IsMatch(Str, Pattern))
            {
                string[] Array = Regex.Replace(Str, Pattern, "*").Replace("</font>", "*").Split('*');

                for (int i = 0; i < Array.Length; i++)
                {
                    try   { RichOut.SelectionColor = list[i]; }
                    catch { RichOut.SelectionColor = Color.Black; }
                        
                    RichOut.AppendText(ConvertContent(Array[i]));
                }
            }
            else
            {
                RichOut.SelectionColor = Color.Black;
                RichOut.AppendText(ConvertContent(Str));
            }
            #endregion
        }

        public string ConvertContent(string Str)
        {
            return Str.Replace("<br/>", "\n").Replace("<p bottommargin=\"10\" bullets=\"●\" bulletsfontset=\"00008130.UI.Normal_12\">", "●")

               .Replace("<p bottommargin=\"4\">", "").Replace("</p>", "\n")

               .Replace("&quot;", "\"").Replace("&apos;", "\'").Replace("&gt;", ">").Replace("&lt;", "<").Replace("&amp;", "&");
        }

        public static string Combine(string Str,string FontName = "Red")
        {
            return string.Format("<font name={1}>{0}</font>", Str, FontName);
        }

        public Color GetColor(string Str)
        {
            Color Default = Color.LightPink;

            if (Str.Contains("Vital_LightBlue"))
                Default = Color.Blue;
            else if (Str.Contains("Green03"))
                Default = Color.LightGreen;
            else if (Str.Contains("LightYellow"))
                Default = Color.OrangeRed;
            else if (Str.Contains("UI.Normal"))
                Default = Color.DeepPink;
            else if (Str.Contains("Red"))
                Default = Color.Red;

            return Default;
        }
    }
}
