# number-converter
The most powerful, accurate and robust number conversion tool developed in C# for .NET Framework 4.5 and higher.

## Advantages over other converters
* Handles both positive and negative numbers.
* Handles a high range of numbers ranging from **-1 to 1 Octillion**; That is (+/-) **1,000,000,000,000,000,000,000,000,000**.
* Handles numbers with decimal places. e.g; **1,234.567** = *One thousand, two hundred and thirty four point five six seven*
* Accurately uses commas & the and conjunction when converting large numbers to output a very grammatically correct sentence. e.g; **12,654,768,123** = *Twelve billion, Six hundred and fifty four million, seven hundred and sixty eight million, one hundred and twenty three.*
* Fast and efficient conversions with speeds of less than 1 microsecronds.

### Usage
```
using System;

namespace NumberConverter.Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            NumberConverter numberConverter = new NumberConverter();

            string numberInWords = numberConverter.ConvertToWords("12,345.89");

            // Or (The method has been overloaded to handle both strings and numerical values)

            numberInWords = numberConverter.ConvertToWords(12345.89);

            Console.WriteLine(numberInWords);
            Console.ReadKey();
        }
    }
}

Output: Twelve thousand, three hundred and forty five point eight nine
```
### Tips
Numbers greater than **999,999,999,999,999** - *Nine hundred and ninety nine trillion, nine hundred and ninety nine billion, nine hundred and ninety nine million, nine hundred and ninety nine thousand, nine hundred and ninety nine* should be passed as a string for accurate coversion.

i.e;
```
numberInWords = numberConverter.ConvertToWords("1,000,000,000,000,001"); //Will be One quadrillion and one. but
numberInWords = numberConverter.ConvertToWords(1000000000000001); //Will be Over one quadrillion.
```
## Authors
* **Dennis Kay** - *C# Enthusiast* - [GitHub](https://github.com/denniskay101)


