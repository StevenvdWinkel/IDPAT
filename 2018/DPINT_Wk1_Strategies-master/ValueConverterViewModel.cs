using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DPINT_Wk1_Strategies
{
    public class ValueConverterViewModel : ViewModelBase
    {
        private INumberConverter _toConverter;
        private INumberConverter _fromConverter;

        private NumberConverterFactory _converterFactory;
        private string _fromText;
        public string FromText
        {
            get { return _fromText; }
            set
            {
                _fromText = value;
                RaisePropertyChanged("FromText");
                this.ConvertNumbers();
            }
        }

        private string _toText;
        public string ToText
        {
            get { return _toText; }
            set
            {
                _toText = value;
                RaisePropertyChanged("ToText");
            }
        }

        private string _fromConverterName;
        public string FromConverterName
        {
            get { return _fromConverterName; }
            set
            {
                _fromConverterName = value;
                _fromConverter = _converterFactory.GetNumberConverter(value);
                RaisePropertyChanged("FromConverterName");
                this.ConvertNumbers();
            }
        }

        private string _toConverterName;
        public string ToConverterName
        {
            get { return _toConverterName; }
            set
            {
                _toConverterName = value;
                _toConverter = _converterFactory.GetNumberConverter(value);
                RaisePropertyChanged("ToConverterName");
                this.ConvertNumbers();
            }
        }

        public ObservableCollection<string> ConverterNames { get; set; }

        public ICommand ConvertCommand { get; set; }

        public ValueConverterViewModel()
        {
            _converterFactory = new NumberConverterFactory();

            ConverterNames = new ObservableCollection<string>(_converterFactory.ConverterNames);

            _toConverter = _converterFactory.GetNumberConverter("Numerical");
            _fromConverter = _converterFactory.GetNumberConverter("Numerical");

            FromText = "0";
            ToText = "0";
            FromConverterName = "Numerical";
            ToConverterName = "Numerical";

            ConvertCommand = new RelayCommand(ConvertNumbers);
        }

        private void ConvertNumbers()
        {
            try
            {
                int number = _fromConverter.ToNumerical(FromText);
                ToText = _toConverter.ToLocalString(number);
            }
            catch{
                ToText = "Error";
            }
        }


    }
}
