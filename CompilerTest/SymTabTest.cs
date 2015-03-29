using System;
using Intermediate.Symbols;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CompilerTest
{
    [TestClass]
    public class SymTabTest
    {
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
    }
}
