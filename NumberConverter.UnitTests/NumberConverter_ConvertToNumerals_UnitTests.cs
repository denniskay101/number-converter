using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberConverter.UnitTests
{
    [TestFixture]
    public class NumberConverter_ConvertToNumerals_UnitTests
    {
        NumberConverter numberConverter;

        [SetUp]
        public void SetUp()
        {
            numberConverter = new NumberConverter();
        }

        [TestCase(-1912.9798, ConversionType.ToNumerals, CurrencyType.Shillings, "-1,912.98 shillings")]
        [TestCase(1912.9998, ConversionType.ToNumerals, CurrencyType.Dollars, "1,913.00 dollars")]
        [TestCase(-1912, ConversionType.ToNumerals, CurrencyType.Shillings, "-1,912.00 shillings")]
        [TestCase(1, ConversionType.ToNumerals, CurrencyType.Dollars, "1.00 dollars")]
        [TestCase(-1912.9998, ConversionType.ToNumerals, CurrencyType.None, "-1,912.9998")]
        [TestCase(-1912, ConversionType.ToNumerals, CurrencyType.None, "-1,912")]
        [TestCase(1, ConversionType.ToNumerals, CurrencyType.None, "1")]
        public void Convert_CurrencyConversionNumericTests(double input, ConversionType conversionType, CurrencyType currencyType, string expected)
        {
            string actual = numberConverter.Convert(input, conversionType, currencyType);
            Assert.AreEqual(expected, actual);
        }
    }
}
