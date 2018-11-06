using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPINT_Wk1_Strategies
{
    class NumberConverterFactory
    {
        public IEnumerable<string> ConverterNames
        {
            get { return _converters.Keys; }
        }

        private Dictionary<string, INumberConverter> _converters;

        public NumberConverterFactory()
        {
            _converters = new Dictionary<string, INumberConverter>();

            _converters["Numerical"] = new NumericalNumberConverter();
            _converters["Binary"] = new BinaryNumberConverter();
            _converters["Roman"] = new RomanNumberConverter();
            _converters["Hexadecimal"] = new HexadecimelNumberConverter();
            _converters["Octal"] = new OctalNumberConverter();
        }

        public INumberConverter GetNumberConverter(string name)
        {
            return _converters[name];
        }
    }
}
