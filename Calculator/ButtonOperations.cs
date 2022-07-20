using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class ButtonOperations
    {
        public static string ChangeSign(string input)
        {
            input = input.Replace(" ", "");
            if (input.Length > 0 && Convert.ToDouble(input) != 0)
            {
                if (input[0] == '-')
                    input = input.Remove(0, 1);
                else input = '-' + input;
            }
            return input;
        }
        public static string AddDot(string input, bool usedOperator, bool usedMemory)
        {
            input = input.Replace(" ", "");
            if (!Validator.HasDot(input))
            {
                input = Validator.InsertElement(input, ',', usedOperator, usedMemory);
                if (input.Length != 0 && input[0] == ',')
                    input = "0" + input;
            }
            return input;
        }
        public static string Backspace(string input, System.Windows.Controls.TextBox box)
        {
            if (input.Length > 0)
            {
                input = input.Replace(" ", "");
                input = input.Remove(input.Length - 1, 1);
                if (input == "")
                    input = "0";
            }                          
            return input;
        }
    }
}
