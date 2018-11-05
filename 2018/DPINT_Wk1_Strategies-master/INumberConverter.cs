using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPINT_Wk1_Strategies
{
    interface INumberConverter
    {
        String ToLocalString(int fromNumber);
        int ToNumerical(String FromText);


    }
}
