using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPINT_Wk1_Strategies
{
    class OctalNumberConverter : INumberConverter
    { 
        public string ToLocalString(int fromNumber)
        {
            String s = fromNumber.ToString();
            return Convert.ToInt32(s, 8).ToString();
        }

        public int ToNumerical(string FromText)
        {
            return Convert.ToInt32(FromText, 8);
        }
    }
}

