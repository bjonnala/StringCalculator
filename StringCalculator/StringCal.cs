using System;
using System.Text;

namespace StringCalculator
{
    public class StringCal : IStringCal
    {
        private readonly Utility _utility;
        public StringCal()
        {
            _utility = new Utility();
        }

        public int Operation(string operand, string input)
        {
            int output = 0;
            bool useDefaultDelimiter = true;
            if (string.IsNullOrWhiteSpace(input)) return output;
            string delimiter = ",";
            string[] delimiterChars = new string[input.Length];

            if (input.StartsWith("//"))
            {
                string[] tempstr = input.Split('\n');
                input = input.Substring(input.IndexOf("\n"));
                delimiter = tempstr[0][2].ToString();
            }
            else
            {
                string[] tempstr = input.Split(delimiter[0]);
                if (tempstr.Length > 1)
                {
                    for (int i = 1; i < tempstr.Length; i++)
                    {
                        if (string.IsNullOrWhiteSpace(tempstr[i]))
                        {
                            throw new ArgumentException("Invalid Input");
                        }
                    }
                }
                input = input.Replace("\n", delimiter);
            }
            if (useDefaultDelimiter)
            {
                if (input.IndexOf("\n") != -1)
                {
                    input = input.Replace("\n", delimiter);
                }
                string[] splitnumbers = input.Split(new[] { delimiter }, StringSplitOptions.None);
                output = Calculate(splitnumbers, operand);
            }
            else
            {
                string[] splitnumbers = input.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
                output = Calculate(splitnumbers, operand);

            }
            return output;
        }

        private int Calculate(string[] splitnumbers, string operand)
        {
            int output = 0;
            bool hasNegatives = false;
            StringBuilder sbnegativenos = new StringBuilder();
            for (int i = 0; i < splitnumbers.Length; i++)
            {
                int num = _utility.ConvertToNumber(splitnumbers[i].Replace("\n", ""));
                switch (operand)
                {
                    case "+":
                        output += num;
                        break;
                    case "-":
                        output -= num;
                        break;
                    case "*":
                        output *= num;
                        break;
                    case "/":
                        output /= num;
                        break;
                }
                if (num < 0)
                {
                    sbnegativenos.Append(splitnumbers[i] + ",");
                    hasNegatives = true;
                }
            }
            if (hasNegatives)
            {
                throw new ArgumentException("negatives not allowed " + sbnegativenos.ToString().TrimEnd(','));
            }
            return output;
        }

        

    }
}
