using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
