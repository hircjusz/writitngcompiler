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
            var symTabStack=SymTabFactory.CreateSymTabStack(0);
        }
    }
}
