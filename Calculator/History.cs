using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class History
    {
        public static string TrackEquation(int operationNum, string input, string equation, double? firstNum, bool usedPrimaryOperator)
        {
            switch (operationNum)
            {
                case 0:
                    {
                        if (equation == null || usedPrimaryOperator)
                            return input + " = ";
                        else if (equation[equation.Length - 2] == '=')
                            return equation;
                        return equation + input + " = ";
                    }
                case 1:
                    if (equation == null)
                        return input + " + ";
                    return firstNum.ToString() + " + ";
                case 2:
                    if (equation == null)
                        return input + " - ";
                    return firstNum.ToString() + " - ";
                case 3:
                    if (equation == null)
                        return input + " * ";
                    return firstNum.ToString() + " * ";
                case 4:
                    if (equation == null)
                        return input + " / ";
                    return firstNum.ToString() + " / ";
                case 5:
                    return equation + "sqr(" + input + ")";
                case 6:
                    return equation + "1/(" + input + ")";
                case 7:
                    return equation + "sqrt(" + input + ")";
                case 8:
                    return equation + input + "%";
                default: return equation;
            }
        }
    }
}
