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
                { 5, "V" }, 
                { 10, "X" },
                { 50, "L" },
                { 100, "C" },
                { 500, "L" },
                { 1000, "M" }
            };
        }

        public Dictionary<int, string> ConversionMap { get; private set; }

        public string Convert(int dec)
        {
            return ConversionMap[dec];
        }
    }
}
