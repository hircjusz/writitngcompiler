using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utility;

namespace CompilerTest.Sources.ParsingProgramsFunctions
{
    [TestClass]
    public class ParsingProgramsFunctions:CompilerTestBase
    {

        [TestMethod]
        public void Procedure1()
        {
            var parser = Helper.Pascal("compile", this.CurrentPath, "F1");
            var txt = ParserTreePrinter.Print(parser.Code.GetRoot(), 0);

        }
    }
}
