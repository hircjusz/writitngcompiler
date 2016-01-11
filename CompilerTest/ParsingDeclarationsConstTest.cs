using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utility;

namespace CompilerTest
{
    [TestClass]
    public class ParsingDeclarationsConstTest
    {

        PascalHelper helper = new PascalHelper();
        ParserTreePrint parserTreePrinter = new ParserTreePrint();


        [TestMethod]
        public void ConstantDefinitionParser1()
        {
            var parser = helper.Pascal("compile", "../../Sources/ParsingDeclarations/ParsingDeclarationsConst.txt", "F1");
            var txt = parserTreePrinter.Print(parser.Code.GetRoot(), 0);

        }
    }
}
