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
                //{ 4, "IV" }, 
                { 5, "V" }, 
                //{ 9, "IX" },
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

            var inferieurDecimal = ConversionMap.Keys.Last(k => k <= decimalInt);
            var superiorDecimal = ConversionMap.Keys.First(k => k > inferieurDecimal);
            var lowerDecimalReducedRest = (decimalInt % superiorDecimal) / inferieurDecimal;

            var decimalIntReducedTo1Digit = ReduceIntTo1Digit(decimalInt);
            if (lowerDecimalReducedRest != 0 && decimalIntReducedTo1Digit < 4)
            {
                return ConversionMap[inferieurDecimal] + RepeatRoman(ConversionMap[inferieurDecimal], lowerDecimalReducedRest - 1);
            }

            if (lowerDecimalReducedRest != 0 && decimalIntReducedTo1Digit > 5)
            {
                return ConversionMap[inferieurDecimal] + RepeatRoman(ConversionMap[ConversionMap.Keys.Last(k => k < inferieurDecimal)], lowerDecimalReducedRest);
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

        private int ReduceIntTo1Digit(int multipleOf10)
        {
            while (multipleOf10 / 10 > 0)
            {
                multipleOf10 = multipleOf10 / 10;
            }

            return multipleOf10;
        }
    }
}
