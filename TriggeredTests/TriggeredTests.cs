using System;
using System.Collections.Generic;
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
        public void SplitOnAndMethod()
        {
            List<string> expected = new List<string>(new string[] { "XPLAYELIFE<10", "XPLAYEMANA<=5" });
            string trigger = "XPLAYELIFE<10A!XPLAYEMANA<=5";

            parser.parseTrigger(trigger);

            CollectionAssert.AreEqual( expected, parser.getQueries());
        }

        [TestMethod]
        public void SplitOnOrMethod()
        {
            List<string> expected = new List<string>(new string[] { "XPLAYELIFE<10", "XPLAYEMANA<=5" });
            string trigger = "XPLAYELIFE<10O!XPLAYEMANA<=5";

            parser.parseTrigger(trigger);

            CollectionAssert.AreEqual(expected, parser.getQueries());

        }

        [TestMethod]
        public void SplitOnSimpleParenthesis()
        {
            List<string> expected = new List<string>(new string[] { "XPLAYEMANA<=5" , "XPLAYEXP=10", "XPLAYELIFE<10" });
            string trigger = "XPLAYELIFE<10O!(XPLAYEMANA<=5A!XPLAYEXP=10)";
            parser.parseTrigger(trigger);

            CollectionAssert.AreEqual(expected, parser.getQueries());
            parser.emptyQueries();

            List<string> expectedTwo = new List<string>(new string[] { "XPLAYEMANA<=5", "XPLAYEXP=10", "XPLAYELIFE<10" });
            string triggerTwo = "(XPLAYEMANA<=5A!XPLAYEXP=10)O!XPLAYELIFE<10";
            parser.parseTrigger(triggerTwo);

            CollectionAssert.AreEqual(expectedTwo, parser.getQueries());

        }
       
    }
}
