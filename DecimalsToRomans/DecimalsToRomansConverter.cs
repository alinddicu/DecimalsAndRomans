using System;
using System.Linq;
using System.Reflection;

namespace DecimalsToRomans
{
    using System.Collections.Generic;

    public class DecimalsToRomansConverter
    {
        public DecimalsToRomansConverter()
        {
            ConversionMap = new Dictionary<int, string>
            {
                { 1, "I" }, 
                { 4, "IV" }, 
                { 5, "V" }, 
                { 9, "IX" },
                { 10, "X" },
                { 40, "XL" },
                { 50, "L" },
                { 90, "XC" },
                { 100, "C" },
                { 400, "CL" },
                { 500, "L" },
                { 900, "CM" },
                { 1000, "M" }
            };
        }

        public Dictionary<int, string> ConversionMap { get; private set; }

        public string Convert(int dec)
        {
            var roman = string.Empty;
            if (ConversionMap.Keys.Contains(dec))
            {
                return ConversionMap[dec];
            }

            var superiorLimitDecimal = ConversionMap.Keys.First(k => dec > k);
            if (dec % 4 != 0)
            {
                return RepeatRoman(ConversionMap[superiorLimitDecimal], dec);
            }

            return roman;
        }

        private string RepeatRoman(string roman, int times)
        {
            var repetition = string.Empty;
            for (var i = 0; i < times; i++)
            {
                repetition += roman;
            }

            return repetition;
        }
    }
}
