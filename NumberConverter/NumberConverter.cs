using NumberConverter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberConverter
{
    public class NumberConverter : INumberConverter
    {
        private string[] _0to19;
        private string[] _ty;
        private string[] _Zeros;

        public NumberConverter()
        {
            _0to19 = new string[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen", };
            _ty = new string[] { "", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
            _Zeros = new string[] { "", "", "hundred", "thousand", "", "", "million", "", "", "billion", "", "", "trillion", "", "", "quadrillion", "", "", "quintillion", "", "", "sextillion", "", "", "septillion", };
        }

        /// <summary>
        /// Returns the minimum number supported for conversion
        /// </summary>
        public double MinSupportedNumber
        {
            get
            {
                return -999999999999999;
            }
        }

        /// <summary>
        /// Returns the maximum number supported for conversion
        /// </summary>
        public double MaxSupportedNumber
        {
            get
            {
                return 999999999999999;
            }
        }

        /// <summary>
        /// Returns the minimum string supported for conversion
        /// </summary>
        public string MinSupportedString
        {
            get
            {
                return "-999,999,999,999,999,999,999,999,999";
            }
        }

        /// <summary>
        /// Returns the maximum string supported for conversion
        /// </summary>
        public string MaxSupportedString
        {
            get
            {
                return "999,999,999,999,999,999,999,999,999";
            }
        }

        public string ConvertToWords(string number)
        {
            if(IsValid(number))
            {
                if(number.Contains("."))
                    return ConvertQuadrillionAndOverToWords(number);

                if (double.Parse(number) >= 0 && double.Parse(number) <= MaxSupportedNumber)
                    return ConvertToWords(double.Parse(number));
                else
                {
                    return ConvertQuadrillionAndOverToWords(number);
                }
            }

            return "Invalid number";
        }

        public string ConvertToWords(double number)
        {
            if (number.ToString().Contains("E+"))
            {
                if(number < 0)
                    return "Over negative one quadrillion";
                else
                    return "Over one quadrillion";
            } 

            StringBuilder numberInWords = new StringBuilder();

            bool isNegative = false;
            if (number < 0)
                isNegative = true;

            string sNumber = number.ToString();

            double wholeNumberPart = number;

            //Fixes bug on numbers with more decimal points than can be handled by a double 
            //by rounding off the number
            if (!sNumber.Contains("."))
            {
                if (double.Parse(sNumber) > wholeNumberPart)
                {
                    wholeNumberPart = double.Parse(sNumber);
                }

                if(isNegative)
                {
                    if (double.Parse(sNumber) < wholeNumberPart)
                    {
                        wholeNumberPart = double.Parse(sNumber);
                    }
                }
            }

            string fractionalPart = null;

            if (sNumber.Contains("."))
            {
                wholeNumberPart = double.Parse(sNumber.Substring(0, sNumber.IndexOf(".")));
                fractionalPart = sNumber.Substring(sNumber.IndexOf(".") + 1);
            }

            if (isNegative)
                wholeNumberPart *= -1;

            if (wholeNumberPart >= 0 && wholeNumberPart <= 99)
                numberInWords.Append(Convert_0_99(wholeNumberPart));
            if (wholeNumberPart >= 100 && wholeNumberPart <= 999)
                numberInWords.Append(Convert_100_999(wholeNumberPart));
            if (wholeNumberPart >= 1000 && wholeNumberPart <= 9999)
                numberInWords.Append(Convert_1000_9999(wholeNumberPart));
            if (wholeNumberPart >= 10000 && wholeNumberPart <= 99999)
                numberInWords.Append(Convert_10000_99999(wholeNumberPart));
            if (wholeNumberPart >= 100000 && wholeNumberPart <= 999999)
                numberInWords.Append(Convert_100000_999999(wholeNumberPart));
            if (wholeNumberPart >= 1000000 && wholeNumberPart <= 9999999)
                numberInWords.Append(Convert_1000000_9999999(wholeNumberPart));
            if (wholeNumberPart >= 10000000 && wholeNumberPart <= 99999999)
                numberInWords.Append(Convert_10000000_99999999(wholeNumberPart));
            if (wholeNumberPart >= 100000000 && wholeNumberPart <= 999999999)
                numberInWords.Append(Convert_100000000_999999999(wholeNumberPart));
            if (wholeNumberPart >= 1000000000 && wholeNumberPart <= 999999999999)
                numberInWords.Append(Convert_Billions(wholeNumberPart));
            if (wholeNumberPart >= 1000000000000 && wholeNumberPart <= 999999999999999)
                numberInWords.Append(Convert_Trillions(wholeNumberPart));

            if (fractionalPart != null)
            {
                numberInWords.Append(" point");
                foreach (var num in fractionalPart.ToCharArray())
                {
                    numberInWords.Append($" {Convert_0_99(double.Parse(num.ToString())).ToLower()}");
                }
            }

            if (isNegative)
                return $"Negative {numberInWords.ToString().ToLower()}";

            return numberInWords.ToString();
        }

        private string ConvertQuadrillionAndOverToWords(string number)
        {
            StringBuilder numberInWords = new StringBuilder();

            bool isNegative = false;
            if (number.Contains("-"))
                isNegative = true;

            string sNumber = number.ToString();

            string wholeNumberPart = number.Replace(",", string.Empty);

            string fractionalPart = null;

            if (sNumber.Contains("."))
            {
                wholeNumberPart = sNumber.Substring(0, sNumber.IndexOf("."));
                fractionalPart = sNumber.Substring(sNumber.IndexOf(".") + 1);
            }

            if (isNegative)
                wholeNumberPart = wholeNumberPart.Replace("-", string.Empty);

            if (double.Parse(wholeNumberPart) <= 999999999999999)
                numberInWords.Append(Convert_Trillions(double.Parse(wholeNumberPart)));
            if (wholeNumberPart.Length >= 16 && wholeNumberPart.Length <= 18)
                numberInWords.Append(Convert_Quadrillions(wholeNumberPart));
            if (wholeNumberPart.Length >= 19 && wholeNumberPart.Length <= 21)
                numberInWords.Append(Convert_Quintillions(wholeNumberPart));
            if (wholeNumberPart.Length >= 22 && wholeNumberPart.Length <= 24)
                numberInWords.Append(Convert_Sextillions(wholeNumberPart));
            if (wholeNumberPart.Length >= 25 && wholeNumberPart.Length <= 27)
                numberInWords.Append(Convert_Septillions(wholeNumberPart));
            if(wholeNumberPart.Length >= 28 )
            {
                if (isNegative)
                    return "Over negative one octillion";
                else
                    return "Over one octillion";
            }

            if (fractionalPart != null)
            {
                numberInWords.Append(" point");
                foreach (var num in fractionalPart.ToCharArray())
                {
                    numberInWords.Append($" {Convert_0_99(double.Parse(num.ToString())).ToLower()}");
                }
            }

            if (isNegative)
                return $"Negative {numberInWords.ToString().ToLower()}";

            return numberInWords.ToString();
        }

        public string ConvertToCurrencyWords(string number)
        {
            if (IsValid(number))
            {
                return ConvertToCurrencyWords(double.Parse(number));
            }

            return "Invalid number";
        }

        public string ConvertToCurrencyWords(double number)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Handles all numbers less than than 100 i.e; 0 - 99
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private string Convert_0_99(double numberToConvert)
        {
            int number = (int)numberToConvert;

            if (number < 20)
                return $"{_0to19[number]}";

            if (number % 10 == 0)
                return _ty[number / 10];
            else
                return $"{_ty[number / 10]} {_0to19[number % 10].ToLower()}";
        }

        /// <summary>
        /// Handles all numbers less than than 1,000 i.e; 100 - 999
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private string Convert_100_999(double numberToConvert)
        {
            int number = (int)numberToConvert;

            if (number < 100)
                return Convert_0_99(number);

            if (number % 100 == 0)
                return $"{_0to19[number / 100]} {_Zeros[2]}";
            else
                return $"{_0to19[number / 100]} {_Zeros[2]} and {Convert_0_99(double.Parse(number.ToString().Substring(1, 2))).ToLower()}";
        }

        /// <summary>
        /// Handles all numbers less than than 10,000 i.e; 1,000 - 9,999
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private string Convert_1000_9999(double number)
        {
            if (number < 100)
                return Convert_0_99(number);
            if (number < 1000)
                return Convert_100_999(number);

            long dividedNumber = (long)(number / 1000);

            if (number % 1000 == 0)
                return $"{_0to19[dividedNumber]} {_Zeros[3]}";
            else
            {
                long splitNumber = long.Parse(number.ToString().Substring(1, 3));

                if (splitNumber < 20)
                    return $"{_0to19[dividedNumber]} {_Zeros[3]} and {Convert_0_99(splitNumber).ToLower()}";
                else
                {
                    if (splitNumber % 100 == 0)
                        return $"{_0to19[dividedNumber]} {_Zeros[3]} {Convert_100_999(splitNumber).ToLower()}";
                    else
                    {
                        if (splitNumber < 100)
                            return $"{_0to19[dividedNumber]} {_Zeros[3]} and {Convert_100_999(splitNumber).ToLower()}";
                        else
                            return $"{_0to19[dividedNumber]} {_Zeros[3]}, {Convert_100_999(splitNumber).ToLower()}";
                    }
                }
            }
        }

        /// <summary>
        /// Handles all numbers less than than 100,000 i.e; 10,000 - 99,999
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private string Convert_10000_99999(double number)
        {
            if (number < 100)
                return Convert_0_99(number);
            if (number < 1000)
                return Convert_100_999(number);
            if (number < 10000)
                return Convert_1000_9999(number);

            long dividedNumber = (long)(number / 1000);

            if (number % 10000 == 0)
                return $"{_ty[dividedNumber / 10]} {_Zeros[3]}";
            if (number % 1000 == 0)
                return $"{Convert_0_99(number / 1000)} {_Zeros[3]}";
            else
            {
                long splitNumber = long.Parse(number.ToString().Substring(2, 3));

                string str = string.Empty;
                if ((number / 1000) < 20)
                    str = _0to19[dividedNumber];
                else
                    str = Convert_0_99(number / 1000);

                if (splitNumber < 20)
                    return $"{str} {_Zeros[3]} and {Convert_0_99(splitNumber).ToLower()}";
                if (splitNumber < 100)
                    return $"{str} {_Zeros[3]} and {Convert_100_999(splitNumber).ToLower()}";
                if (splitNumber < 1000)
                {
                    if (splitNumber % 100 == 0)
                        return $"{str} {_Zeros[3]} and {Convert_100_999(splitNumber).ToLower()}";
                    else
                        return $"{str} {_Zeros[3]}, {Convert_100_999(splitNumber).ToLower()}";
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        /// <summary>
        /// Handles all numbers less than than 1,000,000 i.e; 100,000 - 999,999
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private string Convert_100000_999999(double number)
        {
            if (number < 100)
                return Convert_0_99(number);
            if (number < 1000)
                return Convert_100_999(number);
            if (number < 10000)
                return Convert_1000_9999(number);
            if (number < 100000)
                return Convert_10000_99999(number);

            long dividedNumber = (long)(number / 1000);

            if (number % 100000 == 0)
                return $"{_0to19[dividedNumber / 100]} {_Zeros[2]} {_Zeros[3]}";
            if (number % 1000 == 0)
                return $"{Convert_100_999(long.Parse(number.ToString().Substring(0, 3)))} {_Zeros[3]}";

            long splitNumber = long.Parse(number.ToString().Substring(3, 3));
            if (splitNumber < 100 || (splitNumber % 100 == 0))
                return $"{Convert_100_999(long.Parse(number.ToString().Substring(0, 3)))} {_Zeros[3]} and {Convert_100_999(splitNumber).ToLower()}";
            else
                return $"{Convert_100_999(long.Parse(number.ToString().Substring(0, 3)))} {_Zeros[3]}, {Convert_100_999(splitNumber).ToLower()}";
        }

        /// <summary>
        /// Handles all numbers less than than 10,000,000 i.e; 1,000,000 - 9,999,999
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private string Convert_1000000_9999999(double number)
        {
            if (number < 100)
                return Convert_0_99(number);
            if (number < 1000)
                return Convert_100_999(number);
            if (number < 10000)
                return Convert_1000_9999(number);
            if (number < 100000)
                return Convert_10000_99999(number);
            if (number < 1000000)
                return Convert_100000_999999(number);

            long dividedNumber = (long)(number / 1000);

            if (number % 1000000 == 0)
                return $"{_0to19[dividedNumber / 1000]} {_Zeros[6]}";

            long splitNumber = int.Parse(number.ToString().Substring(1));

            if (splitNumber < 100)
                return $"{_0to19[dividedNumber / 1000]} {_Zeros[6]} and {Convert_0_99(splitNumber).ToLower()}";
            if (splitNumber < 1000)
            {
                if (splitNumber % 100 == 0)
                    return $"{_0to19[dividedNumber / 1000]} {_Zeros[6]} and {Convert_100_999(splitNumber).ToLower()}";
                else
                    return $"{_0to19[dividedNumber / 1000]} {_Zeros[6]}, {Convert_100_999(splitNumber).ToLower()}";
            }

            if (splitNumber < 10000)
            {
                if (splitNumber % 1000 == 0)
                    return $"{_0to19[dividedNumber / 1000]} {_Zeros[6]} and {Convert_1000_9999(splitNumber).ToLower()}";
                else
                    return $"{_0to19[dividedNumber / 1000]} {_Zeros[6]}, {Convert_1000_9999(splitNumber).ToLower()}";
            }

            if (splitNumber < 100000)
            {
                if (splitNumber % 10000 == 0)
                    return $"{_0to19[dividedNumber / 1000]} {_Zeros[6]} and {Convert_10000_99999(splitNumber).ToLower()}";
                else
                    return $"{_0to19[dividedNumber / 1000]} {_Zeros[6]}, {Convert_10000_99999(splitNumber).ToLower()}";
            }

            return $"{_0to19[dividedNumber / 1000]} {_Zeros[6]}, {Convert_100000_999999(splitNumber).ToLower()}";
        }

        /// <summary>
        /// Handles all numbers less than than 100,000,000 i.e; 10,000,000 - 99,999,999
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private string Convert_10000000_99999999(double number)
        {
            if (number < 100)
                return Convert_0_99(number);
            if (number < 1000)
                return Convert_100_999(number);
            if (number < 10000)
                return Convert_1000_9999(number);
            if (number < 100000)
                return Convert_10000_99999(number);
            if (number < 1000000)
                return Convert_100000_999999(number);
            if (number < 10000000)
                return Convert_1000000_9999999(number);

            long splitNumber = int.Parse(number.ToString().Substring(0, 2));
            long dividedNumber = (long)(number / 1000);

            string str = string.Empty;
            if (splitNumber < 20)
                str = $"{_0to19[dividedNumber / 1000]} {_Zeros[6]}";
            else
                str = $"{Convert_0_99(splitNumber)} {_Zeros[6]}";

            if (number % 1000000 == 0)
            {
                return str;
            }
            else
            {
                splitNumber = int.Parse(number.ToString().Substring(2));

                if (splitNumber < 100)
                    return $"{str} and {Convert_0_99(splitNumber).ToLower()}";
                if (splitNumber < 1000)
                {
                    if (splitNumber % 100 == 0)
                        return $"{str} and {Convert_100_999(splitNumber).ToLower()}";
                    else
                        return $"{str}, {Convert_100_999(splitNumber).ToLower()}";
                }

                if (splitNumber < 10000)
                {
                    if (splitNumber % 1000 == 0)
                        return $"{str} and {Convert_1000_9999(splitNumber).ToLower()}";
                    else
                        return $"{str}, {Convert_1000_9999(splitNumber).ToLower()}";
                }

                if (splitNumber < 100000)
                {
                    if (splitNumber % 10000 == 0)
                        return $"{str} and {Convert_10000_99999(splitNumber).ToLower()}";
                    else
                    {
                        if (splitNumber % 1000 == 0)
                            return $"{str} and {Convert_10000_99999(splitNumber).ToLower()}";
                        else
                            return $"{str}, {Convert_10000_99999(splitNumber).ToLower()}";
                    }
                }

                return $"{str}, {Convert_100000_999999(splitNumber).ToLower()}";
            }
        }

        /// <summary>
        /// Handles all numbers less than than 1,000,000,000 i.e; 100,000,000 - 999,999,999
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private string Convert_100000000_999999999(double number)
        {
            if (number < 100)
                return Convert_0_99(number);
            if (number < 1000)
                return Convert_100_999(number);
            if (number < 10000)
                return Convert_1000_9999(number);
            if (number < 100000)
                return Convert_10000_99999(number);
            if (number < 1000000)
                return Convert_100000_999999(number);
            if (number < 10000000)
                return Convert_1000000_9999999(number);
            if (number < 100000000)
                return Convert_10000000_99999999(number);

            long splitNumber = int.Parse(number.ToString().Substring(0, 3));

            string str = $"{Convert_100_999(splitNumber)} {_Zeros[6]}";

            if (number % 1000000 == 0)
            {
                return str;
            }
            else
            {
                splitNumber = int.Parse(number.ToString().Substring(3));

                if (splitNumber < 100)
                    return $"{str} and {Convert_100000_999999(splitNumber).ToLower()}";
                else
                {
                    if (splitNumber % 1000 == 0 && splitNumber < 100000)
                        return $"{str} and {Convert_100000_999999(splitNumber).ToLower()}";
                    else
                        return $"{str}, {Convert_100000_999999(splitNumber).ToLower()}";
                }
            }
        }

        /// <summary>
        /// Handles all numbers less than than 1,000,000,000,000 (One trillion) i.e; 1,000,000,000 - 999, 999,999,999
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private string Convert_Billions(double number)
        {
            if (number < 100)
                return Convert_0_99(number);
            if (number < 1000)
                return Convert_100_999(number);
            if (number < 10000)
                return Convert_1000_9999(number);
            if (number < 100000)
                return Convert_10000_99999(number);
            if (number < 1000000)
                return Convert_100000_999999(number);
            if (number < 10000000)
                return Convert_1000000_9999999(number);
            if (number < 100000000)
                return Convert_10000000_99999999(number);
            if (number < 1000000000)
                return Convert_100000000_999999999(number);

            long splitNumber = 0;
            string str = string.Empty;
            if (number.ToString().Length == 10)
            {
                splitNumber = long.Parse(number.ToString().Substring(0, 1));
                str = Convert_0_99(splitNumber);
                splitNumber = long.Parse(number.ToString().Substring(1));
            }

            if (number.ToString().Length == 11)
            {
                splitNumber = long.Parse(number.ToString().Substring(0, 2));
                str = Convert_0_99(splitNumber);
                splitNumber = long.Parse(number.ToString().Substring(2));
            }

            if (number.ToString().Length == 12)
            {
                splitNumber = long.Parse(number.ToString().Substring(0, 3));
                str = Convert_100_999(splitNumber);
                splitNumber = long.Parse(number.ToString().Substring(3));
            }

            if (number % 1000000000 == 0)
                return $"{str} {_Zeros[9]}";
            else
            {
                if (splitNumber < 100)
                    return $"{str} {_Zeros[9]} and {Convert_100000000_999999999(splitNumber).ToLower()}";
                else
                    return $"{str} {_Zeros[9]}, {Convert_100000000_999999999(splitNumber).ToLower()}";
            }
        }

        /// <summary>
        /// Handles all numbers less than than 1,000,000,000,000,000 (One quadrillion) i.e; 1,000,000,000,000 - 999, 999, 999,999,999
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private string Convert_Trillions(double number)
        {
            if (number < 100)
                return Convert_0_99(number);
            if (number < 1000)
                return Convert_100_999(number);
            if (number < 10000)
                return Convert_1000_9999(number);
            if (number < 100000)
                return Convert_10000_99999(number);
            if (number < 1000000)
                return Convert_100000_999999(number);
            if (number < 10000000)
                return Convert_1000000_9999999(number);
            if (number < 100000000)
                return Convert_10000000_99999999(number);
            if (number < 1000000000)
                return Convert_100000000_999999999(number);
            if (number < 1000000000000)
                return Convert_Billions(number);

            long splitNumber = 0;
            string str = string.Empty;
            if (number.ToString().Length == 13)
            {
                splitNumber = long.Parse(number.ToString().Substring(0, 1));
                str = Convert_0_99(splitNumber);
                splitNumber = long.Parse(number.ToString().Substring(1));
            }

            if (number.ToString().Length == 14)
            {
                splitNumber = long.Parse(number.ToString().Substring(0, 2));
                str = Convert_0_99(splitNumber);
                splitNumber = long.Parse(number.ToString().Substring(2));
            }

            if (number.ToString().Length == 15)
            {
                splitNumber = long.Parse(number.ToString().Substring(0, 3));
                str = Convert_100_999(splitNumber);
                splitNumber = long.Parse(number.ToString().Substring(3));
            }

            if (number % 1000000000000 == 0)
                return $"{str} {_Zeros[12]}";
            else
            {
                if (splitNumber < 100)
                    return $"{str} {_Zeros[12]} and {Convert_Billions(splitNumber).ToLower()}";
                else
                    return $"{str} {_Zeros[12]}, {Convert_Billions(splitNumber).ToLower()}";
            }
        }

        /// <summary>
        /// Handles all numbers less than than 1,000,000,000,000,000,000 (One quintillion) i.e; 1,000,000,000,000,000 - 999,999, 999, 999,999,999
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private string Convert_Quadrillions(string numberToConvert)
        {
            double number = double.Parse(numberToConvert);

            if (number < 100)
                return Convert_0_99(number);
            if (number < 1000)
                return Convert_100_999(number);
            if (number < 10000)
                return Convert_1000_9999(number);
            if (number < 100000)
                return Convert_10000_99999(number);
            if (number < 1000000)
                return Convert_100000_999999(number);
            if (number < 10000000)
                return Convert_1000000_9999999(number);
            if (number < 100000000)
                return Convert_10000000_99999999(number);
            if (number < 1000000000)
                return Convert_100000000_999999999(number);
            if (number < 1000000000000)
                return Convert_Billions(number);
            if (number < 1000000000000000)
                return Convert_Trillions(number);

            long splitNumber = 0;
            string str = string.Empty;
            if (numberToConvert.ToString().Length == 16)
            {
                splitNumber = long.Parse(numberToConvert.ToString().Substring(0, 1));
                str = Convert_0_99(splitNumber);
                splitNumber = long.Parse(numberToConvert.ToString().Substring(1));
            }

            if (numberToConvert.ToString().Length == 17)
            {
                splitNumber = long.Parse(numberToConvert.ToString().Substring(0, 2));
                str = Convert_0_99(splitNumber);
                splitNumber = long.Parse(numberToConvert.ToString().Substring(2));
            }

            if (numberToConvert.ToString().Length == 18)
            {
                splitNumber = long.Parse(numberToConvert.ToString().Substring(0, 3));
                str = Convert_100_999(splitNumber);
                splitNumber = long.Parse(numberToConvert.ToString().Substring(3));
            }

            if (numberToConvert.Contains("000000000000000"))
                return $"{str} {_Zeros[15]}";
            else
            {
                if (splitNumber < 100)
                    return $"{str} {_Zeros[15]} and {Convert_Trillions(splitNumber).ToLower()}";
                else
                    return $"{str} {_Zeros[15]}, {Convert_Trillions(splitNumber).ToLower()}";
            }
        }

        /// <summary>
        /// Handles all numbers less than than 1,000,000,000,000,000,000,000 (One sextillion) i.e; 1,000,000,000,000,000,000 - 999,999,999,999,999,999,999
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private string Convert_Quintillions(string numberToConvert)
        {
            double number = double.Parse(numberToConvert);

            if (number < 100)
                return Convert_0_99(number);
            if (number < 1000)
                return Convert_100_999(number);
            if (number < 10000)
                return Convert_1000_9999(number);
            if (number < 100000)
                return Convert_10000_99999(number);
            if (number < 1000000)
                return Convert_100000_999999(number);
            if (number < 10000000)
                return Convert_1000000_9999999(number);
            if (number < 100000000)
                return Convert_10000000_99999999(number);
            if (number < 1000000000)
                return Convert_100000000_999999999(number);
            if (number < 1000000000000)
                return Convert_Billions(number);
            if (number < 1000000000000000)
                return Convert_Trillions(number);
            if (numberToConvert.Length >= 16 && numberToConvert.Length <= 18)
                return Convert_Quadrillions(numberToConvert);

            string splitNumber = "0";
            string str = string.Empty;
            if (numberToConvert.ToString().Length == 19)
            {
                splitNumber = numberToConvert.ToString().Substring(0, 1);
                str = Convert_0_99(long.Parse(splitNumber));
                splitNumber = numberToConvert.ToString().Substring(1);
            }

            if (numberToConvert.ToString().Length == 20)
            {
                splitNumber = numberToConvert.ToString().Substring(0, 2);
                str = Convert_0_99(long.Parse(splitNumber));
                splitNumber = numberToConvert.ToString().Substring(2);
            }

            if (numberToConvert.ToString().Length == 21)
            {
                splitNumber = numberToConvert.ToString().Substring(0, 3);
                str = Convert_100_999(long.Parse(splitNumber));
                splitNumber = numberToConvert.ToString().Substring(3);
            }

            if (numberToConvert.Contains("000000000000000000"))
                return $"{str} {_Zeros[18]}";
            else
            {
                if (long.Parse(splitNumber) < 100)
                    return $"{str} {_Zeros[18]} and {Convert_Quadrillions(splitNumber).ToLower()}";
                else
                    return $"{str} {_Zeros[18]}, {Convert_Quadrillions(splitNumber).ToLower()}";
            }
        }

        /// <summary>
        /// Handles all numbers less than than 1,000,000,000,000,000,000,000,000 (One septillion) i.e; 1,000,000,000,000,000,000,000 - 999,999,999,999,999,999,999,999
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private string Convert_Sextillions(string numberToConvert)
        {
            double number = double.Parse(numberToConvert);

            if (number < 100)
                return Convert_0_99(number);
            if (number < 1000)
                return Convert_100_999(number);
            if (number < 10000)
                return Convert_1000_9999(number);
            if (number < 100000)
                return Convert_10000_99999(number);
            if (number < 1000000)
                return Convert_100000_999999(number);
            if (number < 10000000)
                return Convert_1000000_9999999(number);
            if (number < 100000000)
                return Convert_10000000_99999999(number);
            if (number < 1000000000)
                return Convert_100000000_999999999(number);
            if (number < 1000000000000)
                return Convert_Billions(number);
            if (number < 1000000000000000)
                return Convert_Trillions(number);
            if (numberToConvert.Length >= 16 && numberToConvert.Length <= 18)
                return Convert_Quadrillions(numberToConvert);
            if (numberToConvert.Length >= 19 && numberToConvert.Length <= 21)
                return Convert_Quintillions(numberToConvert);

            string splitNumber = "0";
            string str = string.Empty;
            if (numberToConvert.ToString().Length == 22)
            {
                splitNumber = numberToConvert.ToString().Substring(0, 1);
                str = Convert_0_99(long.Parse(splitNumber));
                splitNumber = numberToConvert.ToString().Substring(1);
            }

            if (numberToConvert.ToString().Length == 23)
            {
                splitNumber = numberToConvert.ToString().Substring(0, 2);
                str = Convert_0_99(long.Parse(splitNumber));
                splitNumber = numberToConvert.ToString().Substring(2);
            }

            if (numberToConvert.ToString().Length == 24)
            {
                splitNumber = numberToConvert.ToString().Substring(0, 3);
                str = Convert_100_999(long.Parse(splitNumber));
                splitNumber = numberToConvert.ToString().Substring(3);
            }

            if (numberToConvert.Contains("000000000000000000000"))
                return $"{str} {_Zeros[21]}";
            else
            {
                if (double.Parse(splitNumber) < 100)
                    return $"{str} {_Zeros[21]} and {Convert_Quintillions(splitNumber).ToLower()}";
                else
                    return $"{str} {_Zeros[21]}, {Convert_Quintillions(splitNumber).ToLower()}";
            }
        }

        /// <summary>
        /// Handles all numbers less than than 999,999,999,999,999,999,999,999,999 (Septillion - 1)
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private string Convert_Septillions(string numberToConvert)
        {
            double number = double.Parse(numberToConvert);

            if (number < 100)
                return Convert_0_99(number);
            if (number < 1000)
                return Convert_100_999(number);
            if (number < 10000)
                return Convert_1000_9999(number);
            if (number < 100000)
                return Convert_10000_99999(number);
            if (number < 1000000)
                return Convert_100000_999999(number);
            if (number < 10000000)
                return Convert_1000000_9999999(number);
            if (number < 100000000)
                return Convert_10000000_99999999(number);
            if (number < 1000000000)
                return Convert_100000000_999999999(number);
            if (number < 1000000000000)
                return Convert_Billions(number);
            if (number < 1000000000000000)
                return Convert_Trillions(number);
            if (numberToConvert.Length >= 16 && numberToConvert.Length <= 18)
                return Convert_Quadrillions(numberToConvert);
            if (numberToConvert.Length >= 19 && numberToConvert.Length <= 21)
                return Convert_Quintillions(numberToConvert);
            if (numberToConvert.Length >= 22 && numberToConvert.Length <= 24)
                return Convert_Sextillions(numberToConvert);

            string splitNumber = "0";
            string str = string.Empty;
            if (numberToConvert.ToString().Length == 25)
            {
                splitNumber = numberToConvert.ToString().Substring(0, 1);
                str = Convert_0_99(long.Parse(splitNumber));
                splitNumber = numberToConvert.ToString().Substring(1);
            }

            if (numberToConvert.ToString().Length == 26)
            {
                splitNumber = numberToConvert.ToString().Substring(0, 2);
                str = Convert_0_99(long.Parse(splitNumber));
                splitNumber = numberToConvert.ToString().Substring(2);
            }

            if (numberToConvert.ToString().Length == 27)
            {
                splitNumber = numberToConvert.ToString().Substring(0, 3);
                str = Convert_100_999(long.Parse(splitNumber));
                splitNumber = numberToConvert.ToString().Substring(3);
            }

            if (numberToConvert.Contains("000000000000000000000000"))
                return $"{str} {_Zeros[24]}";
            else
            {
                if (double.Parse(splitNumber) < 100)
                    return $"{str} {_Zeros[24]} and {Convert_Sextillions(splitNumber).ToLower()}";
                else
                    return $"{str} {_Zeros[24]}, {Convert_Sextillions(splitNumber).ToLower()}";
            }
        }

        /// <summary>
        /// Checks whether the provided number is valid and returns a boolean (true or false)
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public bool IsValid(double number)
        {
            return IsValid(number.ToString());
        }

        /// <summary>
        /// Check whether the provided number is valid and returns a boolean (true or false)
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public bool IsValid(string number)
        {
            string tempNumber = number.Replace(" ", string.Empty).Replace("-", string.Empty);
            
            //Check the position of commas in a comma seperated tempNumber to determine if it's valid or not.
            //i.e; 1,234 is a valid tempNumber but 12,34 is not.
            if(tempNumber.Contains(","))
            {
                string[] splittempNumber = null;
                if(tempNumber.Contains("."))
                    splittempNumber = tempNumber.Substring(0, tempNumber.IndexOf(".")).Split(',');
                else
                    splittempNumber = tempNumber.Split(',');

                //Start looping at position 1 to check if each element contins three values
                //The element at position 0 can contain either 1, 2 or three values.
                for (int i = 1; i<splittempNumber.Length;i++)
                {
                    if (splittempNumber[i].Length != 3)
                        return false;
                }
            }

            number = number.Replace(",", string.Empty);

            return double.TryParse(number, out double n);
        }
    }
}
