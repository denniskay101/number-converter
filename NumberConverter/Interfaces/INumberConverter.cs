using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberConverter.Interfaces
{
    interface INumberConverter
    {
        double MinSupportedNumber { get; }
        double MaxSupportedNumber { get; }
        string MinSupportedString { get; }
        string MaxSupportedString { get; }
        bool IsValid(double number);
        bool IsValid(string number);
        string ConvertToWords(string number);
        string ConvertToWords(double number);
        string ConvertToCurrencyWords(string number);
        string ConvertToCurrencyWords(double number);
    }
}
