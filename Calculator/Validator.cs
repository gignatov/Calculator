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
        public static bool ZeroIsValid(string input)
        {
            if (input == "0")
                return false;
            return true;
        }
        public static bool HasDot(string input)
        {
            if (input.Contains(','))
                return true;
            return false;
        }
        public static string InsertElement(string input, char? ch, bool usedOperator)
        {
            if (usedOperator)
            {
                input = "";
            }
            input = input.Replace(" ", "");
            if (input.Length == 1 && input[0] == '0' && ch != ',')
                input = input.Remove(0, 1);
            if (input.Length < 16)
                input += ch;
            return input;
        }
        public static double? CheckOperation(int operationNum, string input, double? firstNum, bool usedOperator)
        {
            input = input.Replace(" ", "");
            if (input == "")
                return null;
            if (usedOperator == true && operationNum == 5)
                return Operations.DoOperation(operationNum, Convert.ToDouble(input), 0);
            if (usedOperator != true)
            {
                if (operationNum == 5)
                    return Operations.DoOperation(operationNum, Convert.ToDouble(input), 0);
                else if (firstNum == null)
                    return Operations.DoOperation(operationNum, Convert.ToDouble(input), 0);
                else
                    return Operations.DoOperation(operationNum, firstNum, Convert.ToDouble(input));
            }
            return Convert.ToDouble(input);
        }
    }
}
