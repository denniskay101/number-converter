using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberConverter.UnitTests
{
    [TestFixture]
    public class NumberConverter_ConvertToCurrency_UnitTests
    {
        NumberConverter numberConverter;

        [SetUp]
        public void SetUp()
        {
            numberConverter = new NumberConverter();
        }

        [TestCase(1, ConversionType.ToCurrency, CurrencyType.Shillings, "One shillings")]
        [TestCase(1.7, ConversionType.ToCurrency, CurrencyType.Dollars, "One dollars and seven cents")]
        [TestCase(1.70, ConversionType.ToCurrency, CurrencyType.Dollars, "One dollars and seven cents")]
        [TestCase(-1.70, ConversionType.ToCurrency, CurrencyType.Dollars, "Negative one dollars and seven cents")]
        [TestCase(1.798, ConversionType.ToCurrency, CurrencyType.Dollars, "One dollars and seventy nine cents")]
        [TestCase(17, ConversionType.ToCurrency, CurrencyType.None, "Seventeen")]
        [TestCase(19, ConversionType.ToCurrency, CurrencyType.Dollars, "Nineteen dollars")]
        [TestCase(172.45, ConversionType.ToWords, CurrencyType.None, "One hundred and seventy two point four five")]
        [TestCase(172.45, ConversionType.ToCurrency, CurrencyType.None, "One hundred and seventy two and forty five cents")]
        [TestCase(-23, ConversionType.ToCurrency, CurrencyType.Dollars, "Negative twenty three dollars")]
        [TestCase(873.99, ConversionType.ToCurrency, CurrencyType.Shillings, "Eight hundred and seventy three shillings and ninety nine cents")]
        [TestCase(1234.549, ConversionType.ToCurrency, CurrencyType.Shillings, "One thousand, two hundred and thirty four shillings and fifty four cents")]
        public void Convert_CurrencyConversionNumericTests(double input, ConversionType conversionType, CurrencyType currencyType, string expected)
        {
            string actual = numberConverter.Convert(input, conversionType, currencyType);
            Assert.AreEqual(expected, actual);
        }

       
        [TestCase("1.70", ConversionType.ToCurrency, CurrencyType.Dollars, "One dollars and seventy cents")]
        [TestCase("-1.70", ConversionType.ToCurrency, CurrencyType.Shillings, "Negative one shillings and seventy cents")]
        public void Convert_CurrencyConversionStringTests(string input, ConversionType conversionType, CurrencyType currencyType, string expected)
        {
            string actual = numberConverter.Convert(input, conversionType, currencyType);
            Assert.AreEqual(expected, actual);
        }
    }
}
