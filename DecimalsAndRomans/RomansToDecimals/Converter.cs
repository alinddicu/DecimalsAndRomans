using System;
using System.Linq;

namespace RomansToDecimals
{
    using System.Collections.Generic;

    public class Converter
    {
        private static readonly string[] RomanBaseDigit = new[]
        {
            "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX", "X"
        };

        private static readonly Dictionary<string, int> ConversionMap = new Dictionary<string, int>
        {
            {"I", 1}, {"II", 2}, {"III", 3}, {"IV", 4},{ "V", 5}, {"VI",6}, {"VII",7}, {"VIII",8}, {"IX", 9},
            {"X", 10}
            //{"X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC"},
            //{"C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM"},
            //{"M", "MM", "MMM", "", "", "", "", "", ""}
        };

        public int Convert(string romanNumeral)
        {
            if (romanNumeral == string.Empty)
            {
                return 0;
            }

            var groupAtTheEnd = ExtractGreatestRomanDigit(romanNumeral);
            var theRest = romanNumeral.Substring(0, romanNumeral.Length - groupAtTheEnd.Length);

            return ConversionMap[groupAtTheEnd] + Convert(theRest);
        }

        public string ExtractGreatestRomanDigit(string romanNumeral)
        {
            var endsWithMatchs = RomanBaseDigit.Where(romanNumeral.EndsWith).ToList();
            var maxRomanCharsGroupCountInMatches = endsWithMatchs.Select(m1 => m1.ToCharArray().Count()).Max(charsCount => charsCount);
            endsWithMatchs = endsWithMatchs.Where(m => m.ToCharArray().Length == maxRomanCharsGroupCountInMatches).ToList();

            var maxDecimalValue = endsWithMatchs.Select(m => ConversionMap[m]).Max(o => o);

            return ConversionMap.Keys.Single(k => ConversionMap[k] == maxDecimalValue);
        }
    }
}
