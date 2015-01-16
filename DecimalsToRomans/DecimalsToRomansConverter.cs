using System;
using System.Linq;
using System.Reflection;

namespace DecimalsToRomans
{
    using System.Collections.Generic;

    public class DecimalsToRomansConverter
    {
        // I II III IV V VI VII VIII IX X
        // X XX XXX XL L LI LII LIII IL C
        // C CC CCC CD C DC DCC DCCC CM M
        // M MM MMM

        public DecimalsToRomansConverter()
        {
            ConversionMap = new Dictionary<int, string>
            {
                { 1, "I" }, 
                // { 4, "IV" }, 
                { 5, "V" }, 
                // { 9, "IX" },
                { 10, "X" },
                // { 40, "XL" },
                { 50, "L" },
                // { 90, "XC" },
                { 100, "C" },
                // { 400, "CL" },
                { 500, "L" },
                // { 900, "CM" },
                { 1000, "M" }
            };
        }

        public Dictionary<int, string> ConversionMap { get; private set; }

        public string Convert(int decimalInt)
        {
            var romanInt = string.Empty;
            if (ConversionMap.Keys.Contains(decimalInt))
            {
                return ConversionMap[decimalInt];
            }

            var lowerKey = ConversionMap.Keys.Last(k => k < decimalInt);
            var nextSuperiorKey = ConversionMap.Keys.First(k => k > lowerKey);
            var lowerKeyReducedRest = (decimalInt / lowerKey) % (nextSuperiorKey / lowerKey);
            if (lowerKeyReducedRest != 0)
            {
                return RepeatRoman(ConversionMap[lowerKey], lowerKeyReducedRest);
            }

            return romanInt;
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
