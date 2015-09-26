using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intermediate.Code;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CompilerTest
{
    [TestClass]
    public class ParserExceptions
    {
        PascalHelper helper = new PascalHelper();

        

        [TestMethod]
        public void CodeNodeparseBegin()
        {
            var parser = helper.Pascal("compile", "../../Sources/ParserExceptions/Test1_Missing_End.txt", "F1");
            Assert.AreEqual(parser.GetErrorCount(), 1);
        }
    }
}
