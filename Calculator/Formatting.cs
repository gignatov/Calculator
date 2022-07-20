using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Formatting
    {
        public static void AddSpacing(System.Windows.Controls.TextBox box)
        {
            if (box.Text.Length > 3 && !box.Text.Contains('E'))
            {
                if (Validator.HasDot(box.Text))
                {
                    string tempStart = box.Text.Substring(0, box.Text.IndexOf(','));
                    string tempEnd = box.Text.Substring(box.Text.IndexOf(','));
                    for (int i = tempStart.Length - 3; i > 0; i -= 3)
                    {
                        tempStart = tempStart.Substring(0, i) + ' ' + tempStart.Substring(i);
                    }
                    box.Text = tempStart + tempEnd;
                }
                else
                {
                    for (int i = box.Text.Length - 3; i > 0; i -= 3)
                    {
                        if (box.Text[i] != ' ')
                        {
                            box.Text = box.Text.Substring(0, i) + ' ' + box.Text.Substring(i);
                        }
                    }
                }
                if (box.Text[0] == '-' && box.Text[1] == ' ')
                    box.Text = box.Text.Remove(1, 1);
            }
        }
        public static void ChangeFontSize(System.Windows.Controls.TextBox box)
        {           
            if (box.Text.Length == 13)
                box.FontSize = 45;
            if (box.Text.Length == 14)
                box.FontSize = 42;
            if (box.Text.Length == 15)
                box.FontSize = 39;
            if (box.Text.Length == 16)
                box.FontSize = 36;
            if (box.Text.Length == 17)
                box.FontSize = 34;
            if (box.Text.Length == 18)
                box.FontSize = 32;           
            if (box.Text.Length > 18)
                box.FontSize = 29;
            if (box.Text.Length > 20)
                box.FontSize = 26;
            if (box.Text.Count(x => x == ' ') > 1)
                box.FontSize += 3;
            if (box.Text.Length < 13)
                box.FontSize = 48;
        }       
    }
}
