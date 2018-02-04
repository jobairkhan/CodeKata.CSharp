using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Kata.RomanNumerals.Tests
{
    public class RomanNumerailsUnitTest1
    {
        [Theory]
        [InlineData(1, "I")]
        [InlineData(2, "II")]
        [InlineData(3, "III")]
        [InlineData(4, "IV")]
        [InlineData(5, "V")]
        [InlineData(6, "VI")]
        [InlineData(7, "VII")]
        [InlineData(8, "IIX")]
        [InlineData(9, "IX")]
        [InlineData(10, "X")]
        [InlineData(21, "XXI")]
        [InlineData(50, "L")]
        [InlineData(100, "C")]
        [InlineData(496, "CDXCVI")]
        [InlineData(497, "CDXCVII")]
        [InlineData(498, "CDXCVIII")]
        [InlineData(499, "CDXCIX")]
        [InlineData(500, "D")]
        [InlineData(526, "DXXVI")]
        [InlineData(1000, "M")]
        public void ConvertIntToRoman(int input, string expected)
        {
            var sut = new RomanNumeral1();

            var actual = sut.Convert(input);

            Assert.Equal(expected, actual);
        }
    }
    public class RomanNumeral1
    {
        private Dictionary<int, string> _dictionary;


        public RomanNumeral1()
        {
            _dictionary = new Dictionary<int, string>{
                { 1000, "M"},
                { 500, "D"},
                { 100, "C"},
                { 50, "L"},
                { 10, "X"},
                {5, "V"},
                //{1, "I"}
            };
        }

        public string Convert(int number)
        {
            var result = "";
            var remainToConvert = number;

            foreach (var pair in _dictionary.OrderByDescending(x => x.Key))
            {
                result += CheckModulus(
                    ref remainToConvert,
                    pair.Value,
                    pair.Key);
            }

            if (remainToConvert <= 3)
            {
                result += AddIs(remainToConvert);
            }

            return result;
        }

        private static string AddIs(int numberOfTimes)
        {
            return 
                new string(
                    'I', 
                    numberOfTimes);
        }

        private static string CheckModulus(ref int remainToConvert, string romanValue, int divisibleBy)
        {
            var result = string.Empty;

            while (remainToConvert >= divisibleBy && remainToConvert % divisibleBy >= 0)
            {
                result += romanValue;
                remainToConvert = remainToConvert - divisibleBy;
            }

            if (remainToConvert >= divisibleBy || remainToConvert == 3) return result;

            for (var i = 1; i <= 2; i++)
            {
                if (remainToConvert + i == divisibleBy)
                {
                    result += romanValue;
                    if (remainToConvert + i == divisibleBy)
                    {
                        result = AddIs(i) + result;
                        remainToConvert = 0;
                        break;
                    }
                }
            }

            return result;
        }
    }
}