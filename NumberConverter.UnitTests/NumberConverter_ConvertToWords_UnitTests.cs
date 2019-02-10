using NUnit.Framework;

namespace NumberConverter.UnitTests
{
    [TestFixture]
    public class NumberConverter_ConvertToWords_UnitTests
    {
        NumberConverter numberConverter;

        [SetUp]
        public void SetUp()
        {
            numberConverter = new NumberConverter();
        }

        [TestCase(0, "Zero")]
        [TestCase(1, "One")]
        [TestCase(2, "Two")]
        [TestCase(3, "Three")]
        [TestCase(4, "Four")]
        [TestCase(5, "Five")]
        [TestCase(6, "Six")]
        [TestCase(7, "Seven")]
        [TestCase(8, "Eight")]
        [TestCase(9, "Nine")]
        [TestCase(10, "Ten")]
        [TestCase(11, "Eleven")]
        [TestCase(12, "Twelve")]
        [TestCase(13, "Thirteen")]
        [TestCase(14, "Fourteen")]
        [TestCase(15, "Fifteen")]
        [TestCase(16, "Sixteen")]
        [TestCase(17, "Seventeen")]
        [TestCase(18, "Eighteen")]
        [TestCase(19, "Nineteen")]
        public void Convert_TestFirst19DistincNumbers(double input, string expected)
        {
            string actual = numberConverter.Convert(input);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(20, "Twenty")]
        [TestCase(30, "Thirty")]
        [TestCase(40, "Forty")]
        [TestCase(50, "Fifty")]
        [TestCase(60, "Sixty")]
        [TestCase(70, "Seventy")]
        [TestCase(80, "Eighty")]
        [TestCase(90, "Ninety")]
        public void Convert_TestAllNumbersEndingWithTy(double input, string expected)
        {
            string actual = numberConverter.Convert(input);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(10.2, "Ten point two")]
        [TestCase(21.47, "Twenty one point four seven")]
        [TestCase(32.609, "Thirty two point six zero nine")]
        [TestCase(1.23456789, "One point two three four five six seven eight nine")]
        public void Convert_TestNumbersWithFractionalPart(double input, string expected)
        {
            string actual = numberConverter.Convert(input);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(-1, "Negative one")]
        [TestCase(-60, "Negative sixty")]
        [TestCase(-76, "Negative seventy six")]
        [TestCase(-486, "Negative four hundred and eighty six")]
        [TestCase(-10.2, "Negative ten point two")]
        [TestCase(-21.47, "Negative twenty one point four seven")]
        [TestCase(-32.609, "Negative thirty two point six zero nine")]
        [TestCase(-1.23456789, "Negative one point two three four five six seven eight nine")]
        public void Convert_TestNegativeNumbers(double input, string expected)
        {
            string actual = numberConverter.Convert(input);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(21, "Twenty one")]
        [TestCase(32, "Thirty two")]
        [TestCase(43, "Forty three")]
        [TestCase(54, "Fifty four")]
        [TestCase(65, "Sixty five")]
        [TestCase(76, "Seventy six")]
        [TestCase(87, "Eighty seven")]
        [TestCase(98, "Ninety eight")]
        [TestCase(99, "Ninety nine")]
        public void Convert_0_99_Test(double input, string expected)
        {
            string actual = numberConverter.Convert(input);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(100, "One hundred")]
        [TestCase(200, "Two hundred")]
        [TestCase(300, "Three hundred")]
        [TestCase(400, "Four hundred")]
        [TestCase(500, "Five hundred")]
        [TestCase(600, "Six hundred")]
        [TestCase(700, "Seven hundred")]
        [TestCase(800, "Eight hundred")]
        [TestCase(900, "Nine hundred")]
        [TestCase(101, "One hundred and one")]
        [TestCase(119, "One hundred and nineteen")]
        [TestCase(123, "One hundred and twenty three")]
        [TestCase(321, "Three hundred and twenty one")]
        [TestCase(210, "Two hundred and ten")]
        [TestCase(220, "Two hundred and twenty")]
        [TestCase(221, "Two hundred and twenty one")]
        [TestCase(305, "Three hundred and five")]
        [TestCase(333, "Three hundred and thirty three")]
        [TestCase(415, "Four hundred and fifteen")]
        [TestCase(480, "Four hundred and eighty")]
        [TestCase(486, "Four hundred and eighty six")]
        [TestCase(907, "Nine hundred and seven")]
        [TestCase(999, "Nine hundred and ninety nine")]
        public void Convert_100_999_Test(double input, string expected)
        {
            string actual = numberConverter.Convert(input);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1000, "One thousand")]
        [TestCase(2000, "Two thousand")]
        [TestCase(3000, "Three thousand")]
        [TestCase(4000, "Four thousand")]
        [TestCase(5000, "Five thousand")]
        [TestCase(6000, "Six thousand")]
        [TestCase(7000, "Seven thousand")]
        [TestCase(8000, "Eight thousand")]
        [TestCase(9000, "Nine thousand")]
        [TestCase(1001, "One thousand and one")]
        [TestCase(1010, "One thousand and ten")]
        [TestCase(1019, "One thousand and nineteen")]
        [TestCase(1234, "One thousand, two hundred and thirty four")]
        [TestCase(2600, "Two thousand six hundred")]
        [TestCase(4321, "Four thousand, three hundred and twenty one")]
        [TestCase(2010, "Two thousand and ten")]
        [TestCase(2020, "Two thousand and twenty")]
        [TestCase(2021, "Two thousand and twenty one")]
        [TestCase(2100, "Two thousand one hundred")]
        [TestCase(3105, "Three thousand, one hundred and five")]
        [TestCase(3233, "Three thousand, two hundred and thirty three")]
        [TestCase(4015, "Four thousand and fifteen")]
        [TestCase(4180, "Four thousand, one hundred and eighty")]
        [TestCase(4987, "Four thousand, nine hundred and eighty seven")]
        [TestCase(9007, "Nine thousand and seven")]
        [TestCase(9999, "Nine thousand, nine hundred and ninety nine")]
        public void Convert_1000_9999_Test(double input, string expected)
        {
            string actual = numberConverter.Convert(input);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(10000, "Ten thousand")]
        [TestCase(20000, "Twenty thousand")]
        [TestCase(30000, "Thirty thousand")]
        [TestCase(40000, "Forty thousand")]
        [TestCase(50000, "Fifty thousand")]
        [TestCase(60000, "Sixty thousand")]
        [TestCase(70000, "Seventy thousand")]
        [TestCase(80000, "Eighty thousand")]
        [TestCase(90000, "Ninety thousand")]
        [TestCase(10001, "Ten thousand and one")]
        [TestCase(10010, "Ten thousand and ten")]
        [TestCase(10100, "Ten thousand and one hundred")]
        [TestCase(11000, "Eleven thousand")]
        [TestCase(11011, "Eleven thousand and eleven")]
        [TestCase(11101, "Eleven thousand, one hundred and one")]
        [TestCase(11111, "Eleven thousand, one hundred and eleven")]
        [TestCase(12345, "Twelve thousand, three hundred and forty five")]
        [TestCase(54321, "Fifty four thousand, three hundred and twenty one")]
        [TestCase(20000, "Twenty thousand")]
        [TestCase(20110, "Twenty thousand, one hundred and ten")]
        [TestCase(20201, "Twenty thousand, two hundred and one")]
        [TestCase(21219, "Twenty one thousand, two hundred and nineteen")]
        [TestCase(20500, "Twenty thousand and five hundred")]
        [TestCase(31059, "Thirty one thousand and fifty nine")]
        [TestCase(32373, "Thirty two thousand, three hundred and seventy three")]
        [TestCase(40009, "Forty thousand and nine")]
        [TestCase(49880, "Forty nine thousand, eight hundred and eighty")]
        [TestCase(49897, "Forty nine thousand, eight hundred and ninety seven")]
        [TestCase(50000, "Fifty thousand")]
        [TestCase(50600, "Fifty thousand and six hundred")]
        [TestCase(60777, "Sixty thousand, seven hundred and seventy seven")]
        [TestCase(90101, "Ninety thousand, one hundred and one")]
        [TestCase(90900, "Ninety thousand and nine hundred")]
        [TestCase(99999, "Ninety nine thousand, nine hundred and ninety nine")]
        public void Convert_10000_99999_Test(double input, string expected)
        {
            string actual = numberConverter.Convert(input);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(100000, "One hundred thousand")]
        [TestCase(200000, "Two hundred thousand")]
        [TestCase(300000, "Three hundred thousand")]
        [TestCase(400000, "Four hundred thousand")]
        [TestCase(500000, "Five hundred thousand")]
        [TestCase(600000, "Six hundred thousand")]
        [TestCase(700000, "Seven hundred thousand")]
        [TestCase(800000, "Eight hundred thousand")]
        [TestCase(900000, "Nine hundred thousand")]
        [TestCase(100001, "One hundred thousand and one")]
        [TestCase(100010, "One hundred thousand and ten")]
        [TestCase(100100, "One hundred thousand and one hundred")]
        [TestCase(101000, "One hundred and one thousand")]
        [TestCase(110000, "One hundred and ten thousand")]
        [TestCase(210011, "Two hundred and ten thousand and eleven")]
        [TestCase(120101, "One hundred and twenty thousand, one hundred and one")]
        [TestCase(101211, "One hundred and one thousand, two hundred and eleven")]
        [TestCase(123456, "One hundred and twenty three thousand, four hundred and fifty six")]
        [TestCase(654321, "Six hundred and fifty four thousand, three hundred and twenty one")]
        [TestCase(210000, "Two hundred and ten thousand")]
        [TestCase(271100, "Two hundred and seventy one thousand and one hundred")]
        [TestCase(202010, "Two hundred and two thousand and ten")]
        [TestCase(201219, "Two hundred and one thousand, two hundred and nineteen")]
        [TestCase(205000, "Two hundred and five thousand")]
        [TestCase(310059, "Three hundred and ten thousand and fifty nine")]
        [TestCase(323713, "Three hundred and twenty three thousand, seven hundred and thirteen")]
        [TestCase(400019, "Four hundred thousand and nineteen")]
        [TestCase(498180, "Four hundred and ninety eight thousand, one hundred and eighty")]
        [TestCase(419897, "Four hundred and nineteen thousand, eight hundred and ninety seven")]
        [TestCase(500009, "Five hundred thousand and nine")]
        [TestCase(607177, "Six hundred and seven thousand, one hundred and seventy seven")]
        [TestCase(719000, "Seven hundred and nineteen thousand")]
        [TestCase(901010, "Nine hundred and one thousand and ten")]
        [TestCase(909000, "Nine hundred and nine thousand")]
        [TestCase(999999, "Nine hundred and ninety nine thousand, nine hundred and ninety nine")]
        public void Convert_100000_999999_Test(double input, string expected)
        {
            string actual = numberConverter.Convert(input);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1000000, "One million")]
        [TestCase(2000000, "Two million")]
        [TestCase(3000000, "Three million")]
        [TestCase(4000000, "Four million")]
        [TestCase(5000000, "Five million")]
        [TestCase(6000000, "Six million")]
        [TestCase(7000000, "Seven million")]
        [TestCase(8000000, "Eight million")]
        [TestCase(9000000, "Nine million")]
        [TestCase(1000001, "One million and one")]
        [TestCase(2000010, "Two million and ten")]
        [TestCase(3000100, "Three million and one hundred")]
        [TestCase(4001000, "Four million and one thousand")]
        [TestCase(5010000, "Five million and ten thousand")]
        [TestCase(6100000, "Six million, one hundred thousand")]
        [TestCase(7210011, "Seven million, two hundred and ten thousand and eleven")]
        [TestCase(8220101, "Eight million, two hundred and twenty thousand, one hundred and one")]
        [TestCase(9031211, "Nine million, thirty one thousand, two hundred and eleven")]
        [TestCase(1234567, "One million, two hundred and thirty four thousand, five hundred and sixty seven")]
        [TestCase(7654321, "Seven million, six hundred and fifty four thousand, three hundred and twenty one")]
        [TestCase(3000060, "Three million and sixty")]
        [TestCase(3100060, "Three million, one hundred thousand and sixty")]
        [TestCase(4711007, "Four million, seven hundred and eleven thousand and seven")]
        [TestCase(5020108, "Five million, twenty thousand, one hundred and eight")]
        [TestCase(6201219, "Six million, two hundred and one thousand, two hundred and nineteen")]
        [TestCase(7805000, "Seven million, eight hundred and five thousand")]
        [TestCase(8170059, "Eight million, one hundred and seventy thousand and fifty nine")]
        [TestCase(9236713, "Nine million, two hundred and thirty six thousand, seven hundred and thirteen")]
        [TestCase(1000519, "One million, five hundred and nineteen")]
        [TestCase(2981840, "Two million, nine hundred and eighty one thousand, eight hundred and forty")]
        [TestCase(3198973, "Three million, one hundred and ninety eight thousand, nine hundred and seventy three")]
        [TestCase(4000092, "Four million and ninety two")]
        [TestCase(5007177, "Five million, seven thousand, one hundred and seventy seven")]
        [TestCase(6000209, "Six million, two hundred and nine")]
        [TestCase(7091010, "Seven million, ninety one thousand and ten")]
        [TestCase(8008000, "Eight million and eight thousand")]
        [TestCase(9999999, "Nine million, nine hundred and ninety nine thousand, nine hundred and ninety nine")]
        public void Convert_1000000_9999999_Test(double input, string expected)
        {
            string actual = numberConverter.Convert(input);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(10000000, "Ten million")]
        [TestCase(11000000, "Eleven million")]
        [TestCase(19000000, "Nineteen million")]
        [TestCase(20000000, "Twenty million")]
        [TestCase(21000000, "Twenty one million")]
        [TestCase(30000000, "Thirty million")]
        [TestCase(32000000, "Thirty two million")]
        [TestCase(40000000, "Forty million")]
        [TestCase(43000000, "Forty three million")]
        [TestCase(50000000, "Fifty million")]
        [TestCase(54000000, "Fifty four million")]
        [TestCase(60000000, "Sixty million")]
        [TestCase(65000000, "Sixty five million")]
        [TestCase(70000000, "Seventy million")]
        [TestCase(76000000, "Seventy six million")]
        [TestCase(80000000, "Eighty million")]
        [TestCase(89000000, "Eighty nine million")]
        [TestCase(90000000, "Ninety million")]
        [TestCase(99000000, "Ninety nine million")]
        [TestCase(11000001, "Eleven million and one")]
        [TestCase(22000010, "Twenty two million and ten")]
        [TestCase(30300100, "Thirty million, three hundred thousand and one hundred")]
        [TestCase(40041000, "Forty million and forty one thousand")]
        [TestCase(50105000, "Fifty million, one hundred and five thousand")]
        [TestCase(61000600, "Sixty one million and six hundred")]
        [TestCase(72100171, "Seventy two million, one hundred thousand, one hundred and seventy one")]
        [TestCase(83201018, "Eighty three million, two hundred and one thousand and eighteen")]
        [TestCase(90312119, "Ninety million, three hundred and twelve thousand, one hundred and nineteen")]
        [TestCase(12345678, "Twelve million, three hundred and forty five thousand, six hundred and seventy eight")]
        [TestCase(87654321, "Eighty seven million, six hundred and fifty four thousand, three hundred and twenty one")]
        [TestCase(13000060, "Thirteen million and sixty")]
        [TestCase(32100060, "Thirty two million, one hundred thousand and sixty")]
        [TestCase(47311007, "Forty seven million, three hundred and eleven thousand and seven")]
        [TestCase(50240108, "Fifty million, two hundred and forty thousand, one hundred and eight")]
        [TestCase(62015219, "Sixty two million, fifteen thousand, two hundred and nineteen")]
        [TestCase(78050600, "Seventy eight million, fifty thousand and six hundred")]
        [TestCase(81700579, "Eighty one million, seven hundred thousand, five hundred and seventy nine")]
        [TestCase(92367138, "Ninety two million, three hundred and sixty seven thousand, one hundred and thirty eight")]
        [TestCase(10005199, "Ten million, five thousand, one hundred and ninety nine")]
        [TestCase(12981840, "Twelve million, nine hundred and eighty one thousand, eight hundred and forty")]
        [TestCase(32198973, "Thirty two million, one hundred and ninety eight thousand, nine hundred and seventy three")]
        [TestCase(40300092, "Forty million, three hundred thousand and ninety two")]
        [TestCase(50047177, "Fifty million, forty seven thousand, one hundred and seventy seven")]
        [TestCase(60005209, "Sixty million, five thousand, two hundred and nine")]
        [TestCase(70910610, "Seventy million, nine hundred and ten thousand, six hundred and ten")]
        [TestCase(80080070, "Eighty million, eighty thousand and seventy")]
        [TestCase(99999999, "Ninety nine million, nine hundred and ninety nine thousand, nine hundred and ninety nine")]
        public void Convert_10000000_99999999_Test(double input, string expected)
        {
            string actual = numberConverter.Convert(input);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(100000000, "One hundred million")]
        [TestCase(110000000, "One hundred and ten million")]
        [TestCase(111000000, "One hundred and eleven million")]
        [TestCase(190000000, "One hundred and ninety million")]
        [TestCase(200000000, "Two hundred million")]
        [TestCase(230000000, "Two hundred and thirty million")]
        [TestCase(300000000, "Three hundred million")]
        [TestCase(319000000, "Three hundred and nineteen million")]
        [TestCase(400000000, "Four hundred million")]
        [TestCase(437000000, "Four hundred and thirty seven million")]
        [TestCase(500000000, "Five hundred million")]
        [TestCase(541000000, "Five hundred and forty one million")]
        [TestCase(601000000, "Six hundred and one million")]
        [TestCase(650000000, "Six hundred and fifty million")]
        [TestCase(700000000, "Seven hundred million")]
        [TestCase(799000000, "Seven hundred and ninety nine million")]
        [TestCase(800000000, "Eight hundred million")]
        [TestCase(888000000, "Eight hundred and eighty eight million")]
        [TestCase(900000000, "Nine hundred million")]
        [TestCase(999000000, "Nine hundred and ninety nine million")]
        [TestCase(911000001, "Nine hundred and eleven million and one")]
        [TestCase(282000010, "Two hundred and eighty two million and ten")]
        [TestCase(307300100, "Three hundred and seven million, three hundred thousand and one hundred")]
        [TestCase(400641000, "Four hundred million, six hundred and forty one thousand")]
        [TestCase(501055000, "Five hundred and one million and fifty five thousand")]
        [TestCase(610004600, "Six hundred and ten million, four thousand six hundred")]
        [TestCase(610046000, "Six hundred and ten million and forty six thousand")]
        [TestCase(721001371, "Seven hundred and twenty one million, one thousand, three hundred and seventy one")]
        [TestCase(832010128, "Eight hundred and thirty two million, ten thousand, one hundred and twenty eight")]
        [TestCase(903121191, "Nine hundred and three million, one hundred and twenty one thousand, one hundred and ninety one")]
        [TestCase(123456789, "One hundred and twenty three million, four hundred and fifty six thousand, seven hundred and eighty nine")]
        [TestCase(987654321, "Nine hundred and eighty seven million, six hundred and fifty four thousand, three hundred and twenty one")]
        [TestCase(113000060, "One hundred and thirteen million and sixty")]
        [TestCase(322100017, "Three hundred and twenty two million, one hundred thousand and seventeen")]
        [TestCase(473311009, "Four hundred and seventy three million, three hundred and eleven thousand and nine")]
        [TestCase(502440108, "Five hundred and two million, four hundred and forty thousand, one hundred and eight")]
        [TestCase(620155219, "Six hundred and twenty million, one hundred and fifty five thousand, two hundred and nineteen")]
        [TestCase(780506600, "Seven hundred and eighty million, five hundred and six thousand and six hundred")]
        [TestCase(817005779, "Eight hundred and seventeen million, five thousand, seven hundred and seventy nine")]
        [TestCase(923671388, "Nine hundred and twenty three million, six hundred and seventy one thousand, three hundred and eighty eight")]
        [TestCase(100051999, "One hundred million, fifty one thousand, nine hundred and ninety nine")]
        [TestCase(912981840, "Nine hundred and twelve million, nine hundred and eighty one thousand, eight hundred and forty")]
        [TestCase(382198970, "Three hundred and eighty two million, one hundred and ninety eight thousand, nine hundred and seventy")]
        [TestCase(407300000, "Four hundred and seven million, three hundred thousand")]
        [TestCase(500000077, "Five hundred million and seventy seven")]
        [TestCase(600000009, "Six hundred million and nine")]
        [TestCase(709100010, "Seven hundred and nine million, one hundred thousand and ten")]
        [TestCase(800800270, "Eight hundred million, eight hundred thousand, two hundred and seventy")]
        [TestCase(999999999, "Nine hundred and ninety nine million, nine hundred and ninety nine thousand, nine hundred and ninety nine")]
        public void Convert_100000000_999999999_Test(double input, string expected)
        {
            string actual = numberConverter.Convert(input);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1000000000, "One billion")]
        [TestCase(2000000019, "Two billion and nineteen")]
        [TestCase(3000000099, "Three billion and ninety nine")]
        [TestCase(4000000100, "Four billion, one hundred")]
        [TestCase(5000000605, "Five billion, six hundred and five")]
        [TestCase(6000000915, "Six billion, nine hundred and fifteen")]
        [TestCase(7000001000, "Seven billion, one thousand")]
        [TestCase(8000005003, "Eight billion, five thousand and three")]
        [TestCase(9000070003, "Nine billion, seventy thousand and three")]
        [TestCase(1000000001, "One billion and one")]
        [TestCase(2000000020, "Two billion and twenty")]
        [TestCase(3000000300, "Three billion, three hundred")]
        [TestCase(4000004000, "Four billion, four thousand")]
        [TestCase(5000050000, "Five billion, fifty thousand")]
        [TestCase(6000600000, "Six billion, six hundred thousand")]
        [TestCase(7007000000, "Seven billion, seven million")]
        [TestCase(8080000000, "Eight billion, eighty million")]
        [TestCase(9900000000, "Nine billion, nine hundred million")]
        [TestCase(10000000000, "Ten billion")]
        [TestCase(18000000000, "Eighteen billion")]
        [TestCase(99000000000, "Ninety nine billion")]
        [TestCase(99741478484, "Ninety nine billion, seven hundred and forty one million, four hundred and seventy eight thousand, four hundred and eighty four")]
        [TestCase(500000000000, "Five hundred billion")]
        [TestCase(723691289398, "Seven hundred and twenty three billion, six hundred and ninety one million, two hundred and eighty nine thousand, three hundred and ninety eight")]
        [TestCase(123456789012, "One hundred and twenty three billion, four hundred and fifty six million, seven hundred and eighty nine thousand and twelve")]
        [TestCase(987654321098, "Nine hundred and eighty seven billion, six hundred and fifty four million, three hundred and twenty one thousand and ninety eight")]
        [TestCase(999999999999, "Nine hundred and ninety nine billion, nine hundred and ninety nine million, nine hundred and ninety nine thousand, nine hundred and ninety nine")]
        public void Convert_Billions_Test(double input, string expected)
        {
            string actual = numberConverter.Convert(input);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1000000000000, "One trillion")]
        [TestCase(19000000001000, "Nineteen trillion, one thousand")]
        [TestCase(31000000000029, "Thirty one trillion and twenty nine")]
        [TestCase(123456789012345, "One hundred and twenty three trillion, four hundred and fifty six billion, seven hundred and eighty nine million, twelve thousand, three hundred and forty five")]
        [TestCase(987654321098765, "Nine hundred and eighty seven trillion, six hundred and fifty four billion, three hundred and twenty one million, ninety eight thousand, seven hundred and sixty five")]
        [TestCase(999999999999999, "Nine hundred and ninety nine trillion, nine hundred and ninety nine billion, nine hundred and ninety nine million, nine hundred and ninety nine thousand, nine hundred and ninety nine")]
        [TestCase(1000000000000000, "Over one quadrillion")]
        [TestCase(999999999999999999, "Over one quadrillion")]
        public void Convert_Trillions_Test(double input, string expected)
        {
            string actual = numberConverter.Convert(input);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1000000000000000", "One quadrillion")]
        [TestCase("999999999999999999", "Nine hundred and ninety nine quadrillion, nine hundred and ninety nine trillion, nine hundred and ninety nine billion, nine hundred and ninety nine million, nine hundred and ninety nine thousand, nine hundred and ninety nine")]
        public void Convert_Quadrillions_Test(string input, string expected)
        {
            string actual = numberConverter.Convert(input);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1000000000000000000", "One quintillion")]
        [TestCase("999999999999999999999", "Nine hundred and ninety nine quintillion, nine hundred and ninety nine quadrillion, nine hundred and ninety nine trillion, nine hundred and ninety nine billion, nine hundred and ninety nine million, nine hundred and ninety nine thousand, nine hundred and ninety nine")]
        public void Convert_Quintillions_Test(string input, string expected)
        {
            string actual = numberConverter.Convert(input);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1000000000000000000000", "One sextillion")]
        [TestCase("999999999999999999999999", "Nine hundred and ninety nine sextillion, nine hundred and ninety nine quintillion, nine hundred and ninety nine quadrillion, nine hundred and ninety nine trillion, nine hundred and ninety nine billion, nine hundred and ninety nine million, nine hundred and ninety nine thousand, nine hundred and ninety nine")]
        public void Convert_Sextillions_Test(string input, string expected)
        {
            string actual = numberConverter.Convert(input);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1000000000000000000000000", "One septillion")]
        [TestCase("999999999999999999999999999", "Nine hundred and ninety nine septillion, nine hundred and ninety nine sextillion, nine hundred and ninety nine quintillion, nine hundred and ninety nine quadrillion, nine hundred and ninety nine trillion, nine hundred and ninety nine billion, nine hundred and ninety nine million, nine hundred and ninety nine thousand, nine hundred and ninety nine")]
        public void Convert_Septillions_Test(string input, string expected)
        {
            string actual = numberConverter.Convert(input);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1000000000000000000000000000", "Over one octillion")]
        [TestCase("9999999999999999999999999999", "Over one octillion")]
        public void Convert_OctillionAndOver_Test(string input, string expected)
        {
            string actual = numberConverter.Convert(input);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(-32768, "Negative thirty two thousand, seven hundred and sixty eight", Description = "Smallest Int16/short")]
        [TestCase(-2147483648, "Negative two billion, one hundred and forty seven million, four hundred and eighty three thousand, six hundred and forty eight", Description = "Smallest Int32/int")]
        [TestCase(-9223372036854775808, "Over negative one quadrillion", Description = "Smallest Int64/long")]
        public void Convert_TestMinimums(double input, string expected)
        {
            string actual = numberConverter.Convert(input);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("-9,223,372,036,854,775,808", "Negative nine quintillion, two hundred and twenty three quadrillion, three hundred and seventy two trillion, thirty six billion, eight hundred and fifty four million, seven hundred and seventy five thousand, eight hundred and eight", Description = "Smallest Int64/long")]
        public void Convert_TestMinimums(string input, string expected)
        {
            string actual = numberConverter.Convert(input);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(32768, "Thirty two thousand, seven hundred and sixty eight", Description = "Largest Int16/short")]
        [TestCase(2147483648, "Two billion, one hundred and forty seven million, four hundred and eighty three thousand, six hundred and forty eight", Description = "Largest Int32/int")]
        [TestCase(9223372036854775807, "Over one quadrillion", Description = "Largest Int64/long")]
        public void Convert_TestMaximums(double input, string expected)
        {
            string actual = numberConverter.Convert(input);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("9,223,372,036,854,775,807", "Nine quintillion, two hundred and twenty three quadrillion, three hundred and seventy two trillion, thirty six billion, eight hundred and fifty four million, seven hundred and seventy five thousand, eight hundred and seven", Description = "Largest Int64/long")]
        public void Convert_TestMaximums(string input, string expected)
        {
            string actual = numberConverter.Convert(input);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1.999999999999999999, "Two")]
        [TestCase(1.99999999999999999, "Two")]
        [TestCase(1.9999999999999999, "Two")]
        [TestCase(1.999999999999999, "Two")]
        [TestCase(1.12345678901234589878, "One point one two three four five six seven eight nine zero one two three five")]
        [TestCase(1.12345678901234489878, "One point one two three four five six seven eight nine zero one two three four")]
        [TestCase(1.99999999999999, "One point nine nine nine nine nine nine nine nine nine nine nine nine nine nine")]
        [TestCase(99.99999999999999999, "One hundred")]
        [TestCase(999999999999999.99999999999999999, "Over one quadrillion")]
        public void Convert_TestDecimails(double input, string expected)
        {
            string actual = numberConverter.Convert(input);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(-1.999999999999999999, "Negative two")]
        [TestCase(-1.99999999999999999, "Negative two")]
        [TestCase(-1.9999999999999999, "Negative two")]
        [TestCase(-1.999999999999999, "Negative two")]
        [TestCase(-1.12345678901234589878, "Negative one point one two three four five six seven eight nine zero one two three five")]
        [TestCase(-1.12345678901234489878, "Negative one point one two three four five six seven eight nine zero one two three four")]
        [TestCase(-1.99999999999999, "Negative one point nine nine nine nine nine nine nine nine nine nine nine nine nine nine")]
        [TestCase(-99.99999999999999999, "Negative one hundred")]
        [TestCase(-999999999999999.99999999999999999, "Over negative one quadrillion")]
        public void Convert_TestNegativeDecimails(double input, string expected)
        {
            string actual = numberConverter.Convert(input);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1,298.609", "One thousand, two hundred and ninety eight point six zero nine")]
        [TestCase("19.0123456789", "Nineteen point zero one two three four five six seven eight nine")]
        [TestCase("1.999999999999999999", "One point nine nine nine nine nine nine nine nine nine nine nine nine nine nine nine nine nine nine")]
        [TestCase("9999999999999999999999999999.654", "Over one octillion")]
        public void Convert_TestDecimails(string input, string expected)
        {
            string actual = numberConverter.Convert(input);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void MinSupportedNumber_ShouldBeNegative999999999999999()
        {
            Assert.AreEqual(-999999999999999, numberConverter.MinSupportedNumber);
        }

        [Test]
        public void MaxSupportedNumber_ShouldBe999999999999999()
        {
            Assert.AreEqual(999999999999999, numberConverter.MaxSupportedNumber);
        }

        [Test]
        public void MinSupportedString_ShouldBeNegative999999999999999999999999999()
        {
            Assert.AreEqual("-999,999,999,999,999,999,999,999,999", numberConverter.MinSupportedString);
        }

        [Test]
        public void MaxSupportedString_ShouldBe999999999999999999999999999()
        {
            Assert.AreEqual("999,999,999,999,999,999,999,999,999", numberConverter.MaxSupportedString);
        }

        [TestCase(-9223372036854775808)]
        [TestCase(9223372036854775807)]
        public void IsValid_ShouldReturnTrue_IfTheNumberIsValid(double input)
        {
            Assert.IsTrue(numberConverter.IsValid(input));
        }

        [TestCase("1O")]
        [TestCase("ABCD")]
        [TestCase("1.23.4")]
        [TestCase("12,34")]
        [TestCase("123A.98")]
        [TestCase("I,234.987")]
        [TestCase("-1,234,89")]
        [TestCase("-1,234.9876.92")]
        [TestCase("9-223372036854775808")]
        [TestCase("-9,223,372,036,854,7758,08")]
        public void Convert_ShouldReturnInvalidNumber__IfTheNumberIsValid(string input)
        {
            Assert.AreEqual("Invalid number", numberConverter.Convert(input));
        }

        [TestCase("1234")]
        [TestCase("1,234")]
        [TestCase("1234.98")]
        [TestCase("1,234.987")]
        [TestCase("-1,234")]
        [TestCase("-1,234.9876")]
        [TestCase("-9223372036854775808")]
        [TestCase("-9,223,372,036,854,775,808")]
        public void IsValid_ShouldReturnTrue_IfTheNumberIsValid(string input)
        {
            Assert.IsTrue(numberConverter.IsValid(input));
        }

        [TestCase("1O")]
        [TestCase("ABCD")]
        [TestCase("1.23.4")]
        [TestCase("12,34")]
        [TestCase("123A.98")]
        [TestCase("I,234.987")]
        [TestCase("-1,234,89")]
        [TestCase("-1,234.9876.92")]
        [TestCase("9-223372036854775808")]
        [TestCase("-9,223,372,036,854,7758,08")]
        public void IsValid_ShouldReturFalse_IfTheNumberIsInvalid(string input)
        {
            Assert.IsFalse(numberConverter.IsValid(input));
        }

        [Test]
        public void Test_That_The_Tester_Is_Testing()
        {
            Assert.Pass();
        }
    }
}
