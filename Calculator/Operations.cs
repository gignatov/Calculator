using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Operations
    {
        public static double? DoOperation(int operatorNum, double? firstNum, double? secondNum)
        {
            switch (operatorNum)
            {
                case 0:
                    return (firstNum);
                case 1:
                    return (firstNum + secondNum);
                case 2:
                    return (firstNum - secondNum);
                case 3:
                    return (firstNum * secondNum);
                case 4:
                    return (firstNum / secondNum);
                case 5:
                    return (firstNum * firstNum);
                default: throw new Exception("Invalid operator!");
            }
        }
    }
}
