using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPINT_Wk1_Strategies
{
    class BinaryNumberConverter : INumberConverter
    {
        public string ToLocalString(int fromNumber)
        {
            return fromNumber.ToString();
        }

        public int ToNumerical(string FromText)
        {
            return Int32.Parse(FromText);
        }
    }
}
