using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AAMaster
{
    public class DiceLabel : System.Windows.Forms.Label
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            Font alt = new Font(this.Font.FontFamily, 42);

            string[] lines = Split(Text, (x => x > 255));
            this.Height = (lines.Length * 46) + 64;
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i][0] > 255)
                {
                    g.DrawString(lines[i][0].ToString(), alt, new SolidBrush(ForeColor), 1, 46 * i - 20);
                    g.DrawString(lines[i].Substring(1), this.Font, new SolidBrush(ForeColor), 46, 46 * i);
                }
                else
                {
                    g.DrawString(lines[i], this.Font, new SolidBrush(ForeColor), 1, 46 * i);
                }
                
            }
        }   

        private string[] Split(string s, Func<char, bool> predicate)
        {
            StringBuilder sb = new StringBuilder();
            List<string> list = new List<string>();
            for (int i = 0; i < s.Length; i++)
            {
                if (predicate(s[i]))
                {
                    list.Add(sb.ToString());
                    sb.Clear();
                    sb.Append(s[i]);
                }
                else
                {
                    sb.Append(s[i]);
                }
                
            }

            if (sb.Length > 0)
            {
                list.Add(sb.ToString());
            }

            return list.ToArray();
        }
    }
}
