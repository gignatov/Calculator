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
                case 6:
                    return (1 / firstNum);
                case 7:
                    if (firstNum > 0)
                    {
                        double? root = firstNum / 3;
                        for (int i = 0; i < 32; i++)
                            root = (root + firstNum / root) / 2;
                        return root;
                    }
                    return double.NaN;
                case 8:
                    return (firstNum * secondNum / 100);
                default: throw new Exception("Invalid operator!");
            }
        }
    }
}
