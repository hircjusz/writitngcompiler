using System;
using Intermediate.Symbols;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CompilerTest
{
    [TestClass]
    public class SymTabTest
    {
        PascalHelper helper= new PascalHelper();

        [TestInitialize]
        public void SetUp()
        {

        }

        [TestMethod]
        public void TestMethodCreateSymTabStack()
        {
            var symTabStack = SymTabFactory.CreateSymTabStack(0);
        }

        [TestMethod]
        public void SymTabEntryEnter()
        {
            var symTabStack = SymTabFactory.CreateSymTabStack(0);
            var entry = symTabStack.EnterLocal("Darek");
            Assert.AreEqual(entry.GetName(), "Darek");
            entry.SetAttribute(SymTabEnum.CONSTANT_VALUE, 7);
            Assert.AreEqual(entry.GetAttribute(SymTabEnum.CONSTANT_VALUE),7);
        }

        // var pascal = new Pascal(operation, "../../Sources/specialtoken.txt", "F1");

        [TestMethod]
        public void SymTabParse()
        {
            var parser=helper.Pascal("compile", "../../Sources/symTabTest.txt", "F1");
            var symStack = parser.SymTabStack;
            var entry= symStack.Lookup("a990");
            Assert.AreEqual(entry.GetName(), "a990");
        }
    }
}
