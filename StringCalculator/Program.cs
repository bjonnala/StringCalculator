using System;

namespace StringCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            IStringCal stringCal = new StringCal();
            //string input = "";
            //string input = "1\n2,3";
            string operand = "+";
            //string input = "2,1001";
            //string input = "//#\n1#2";
            //string input = "1,\n"; 
            //string input = "1";
            //string input = "1,2";
            //string input = "1,34,4,2";
            string input = "-1,3";
            //string input = "//[***]\n1***2***3"; // should return 6
            //string input = "//[***][%%%]\n1***2%%%3"; // should return 6;
            Console.WriteLine(stringCal.Operation(operand, input.Trim()));

        }
    }
}
