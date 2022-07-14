using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Calculator
{
    public class Validator
    {
        public static void ChangeFontSize(System.Windows.Controls.TextBox box)
        {
            if (box.Text.Length < 12)
                box.FontSize = 48;
            if (box.Text.Length >= 12 && box.Text.Length <= 17)
                box.FontSize = 34;
            if (box.Text.Length > 17)
                box.FontSize = 24;
        }
        public static void SetFocus(System.Windows.Controls.TextBox box)
        {
            box.Focus();
            box.Select(box.Text.Length, 0);
        }
        public static bool ZeroIsValid(string input)
        {
            if (input == "0")
                return false;
            return true;
        }
        public static bool HasDot(string input)
        {
            foreach (char ch in input)
            {
                if (ch == ',')
                    return true;
            }
            return false;
        }
        public static string InsertElement(string input, char? ch, bool usedOperator)
        {
            if (usedOperator)
            {
                input = "";
            }
            if (input.Length == 1 && input[0] == '0' && ch != ',')
                input = input.Remove(0, 1);
            if (input.Length < 17)
                input += ch;
            return input;
        }
        public static double? CheckOperation(int operationNum, string input, double? firstNum, bool usedOperator)
        {
            if (input != "")
            {
                if (firstNum == null)
                {
                    if (operationNum == 5)
                        input = Operations.DoOperation(operationNum, Convert.ToDouble(input), 0).ToString();
                    firstNum = Convert.ToDouble(input);
                }
                else
                    firstNum = Operations.DoOperation(operationNum, firstNum, Convert.ToDouble(input));
                return firstNum;
            }
            return null;
        }
    }
}
