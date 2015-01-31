namespace DecimalsToRomans
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NFluent;

    [TestClass]
    public class RomanBaseTenConverterTest
    {
        // I II III IV V VI VII VIII IX X
        // X XX XXX XL L LI LII LIII IL C
        // C CC CCC CD C DC DCC DCCC CM M
        // M MM MMM

        private readonly  RomanBaseTenConverter _converter = new RomanBaseTenConverter();

        [TestMethod]
        public void WhenConvert2ThenReturnII()
        {
            Check.That(_converter.Convert(2)).Equals("II");
        }
        
        [TestMethod]
        public void WhenConvert3046ThenReturnMMMXLVI()
        {
            Check.That(_converter.Convert(3046)).Equals("MMMXLVI");
        }
    }
}
