using DPINT_Wk1_Strategies.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            _converters["Roman"] = new RomanNumberConverter();
            _converters["Hexadecimal"] = new HexadecimalNumberConverter();
            _converters["Binary"] = new BinaryNumberConverter();
            _converters["Octal"] = new OctalNumberConverter();
        }

        public INumberConverter GetConverter(string name)
        {
            if (name == null)
                return _converters["Numerical"];
            return _converters[name];
        }

        public string GetConverterName(INumberConverter numberConverter)
        {
            if(numberConverter == null)
            {
                return "Numerical";
            }           
            foreach(KeyValuePair<string, INumberConverter> pair in _converters)
            {
                if(numberConverter == pair.Value)
                {
                    return pair.Key;
                }
            }
            return null;
        }
    }
}
