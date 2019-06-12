using System;
using System.Text;

namespace StringCalculator
{
    // StringCal concrete class implements IStringCal interface
    public class StringCal : IStringCal
    {
        private readonly Utility _utilityMethods;
        public StringCal()
        {
            _utilityMethods = new Utility();
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
                useDefaultDelimiter = SupportDifferentSingleAndMultipleDelimiters(ref input, delimiterChars);
            }
            else
            {
                useDefaultDelimiter = SupportCommaDelimiter(ref input, delimiter);
            }

            if (useDefaultDelimiter)
            {
                if (input.IndexOf("\n") != -1)
                {
                    input = input.Replace("\n", delimiter);
                }
                string[] splitstr = input.Split(new[] { delimiter }, StringSplitOptions.None);
                output = Calculate(splitstr, operand);
            }
            else
            {
                string[] splitstr = input.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
                output = Calculate(splitstr, operand);
            }
            return output;
        }

        private bool SupportCommaDelimiter(ref string input, string delimiter)
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
            return true;
        }

        private bool SupportDifferentSingleAndMultipleDelimiters(ref string input, string[] delimiterChars)
        {
            string[] tempstr = input.Split('\n');
            for (int i = 0; i < tempstr[1].Length; i++)
            {
                if (!char.IsNumber(tempstr[1][i]))
                {
                    delimiterChars[i] = tempstr[1][i].ToString();
                }
            }
            input = input.Substring(input.IndexOf("\n") + 1);
            return false;
        }

        private int Calculate(string[] numbers, string operand)
        {
            int output = 0;
            bool hasNegatives = false;
            StringBuilder sbnegativenos = new StringBuilder();
            for (int i = 0; i < numbers.Length; i++)
            {
                int num = _utilityMethods.ConvertToNumber(numbers[i].Replace("\n", ""));
                if (num >= 0 && num <= 1000)
                {
                    switch (operand)
                    {
                        case "+":
                            output += num;
                            break;
                    }
                }
                if (num < 0)
                {
                    sbnegativenos.Append(numbers[i] + ",");
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
