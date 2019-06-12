using System;
namespace StringCalculator
{
    public class Utility
    {
        public int ConvertToNumber(string number)
        {
            if (Int32.TryParse(number, out int res))
            {
                return res;
            }
            return res;
        }
    }
}
