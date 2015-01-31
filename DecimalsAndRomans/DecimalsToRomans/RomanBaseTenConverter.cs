using System.Globalization;

namespace DecimalsToRomans
{
    using System.Linq;

    public class RomanBaseTenConverter
    {
        private readonly string[,] BaseTenRomans = new string[,]
        {
            {"", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX"},
            {"", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC"},
            {"", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM"},
            {"", "M", "MM", "MMM", "", "", "", "", "", ""}
        };

        public string Convert(int numeral)
        {
            var digitsFromNumeral = numeral
                .ToString(CultureInfo.CurrentCulture)
                .ToCharArray()
                .Reverse()
                .Select(c => c.ToString(CultureInfo.CurrentCulture))
                .ToArray();
            var digitsNumber = digitsFromNumeral.Length;

            var romanNumeral = string.Empty;
            while (digitsNumber > 0)
            {
                digitsNumber--;
                var xTable = digitsNumber;
                var yTable = int.Parse(digitsFromNumeral[digitsNumber]);
                romanNumeral += BaseTenRomans[xTable, yTable];
            }

            return romanNumeral;
        }
    }
}
