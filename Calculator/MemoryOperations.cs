using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class MemoryOperations
    {
        public static string MemoryAdd(string currentMemory, string input)
        {
            input = input.Replace(" ", "");
            return Operations.DoOperation(1, Convert.ToDouble(currentMemory), Convert.ToDouble(input)).ToString();
        }
        public static string MemorySubtract(string currentMemory, string input)
        {
            input = input.Replace(" ", "");
            return Operations.DoOperation(2, Convert.ToDouble(currentMemory), Convert.ToDouble(input)).ToString();
        }
        public static string MemoryClear()
        {
            return "0";
        }
        public static string MemoryStore(string input)
        {
            input = input.Replace(" ", "");
            return input;
        }
        public static string MemoryRecall(string currentMemory)
        {
            return currentMemory;
        }
    }
}
