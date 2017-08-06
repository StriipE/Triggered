using System;
using Triggered;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TriggeredTests
{
    [TestClass]
    public class TriggeredTests
    {
        private Parser parser;

        [TestInitialize]
        public void TestInitialize()
        {
            parser = new Parser();
        }

        [TestMethod]
        public void TestMethod1()
        {
            string trigger = "XPLAYELIFE<10AXPLAYEMANA<=5OXPLAYEXP___=10";
            parser.parseTrigger(trigger);
        }
    }
}
