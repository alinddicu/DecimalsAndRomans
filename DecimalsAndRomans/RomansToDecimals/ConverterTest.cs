using NFluent;

namespace RomansToDecimals
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ConverterTest
    {
        private readonly static Converter Converter = new Converter();

        [TestMethod]
        public void WhenIThenReturn1()
        {
            Check.That(Converter.Convert("I")).IsEqualTo(1);
        }

        [TestMethod]
        public void WhenXIThenReturn11()
        {
            Check.That(Converter.Convert("XI")).IsEqualTo(11);
        }

        [TestMethod]
        public void WhenXThenReturn10()
        {
            Check.That(Converter.Convert("X")).IsEqualTo(10);
        }

        [TestMethod]
        public void WhenXIIIThenReturn13()
        {
            Check.That(Converter.Convert("XIII")).IsEqualTo(13);
        }

        [TestMethod]
        public void WhenXIVThenReturn14()
        {
            Check.That(Converter.Convert("XIV")).IsEqualTo(14);
        }
    }
}
