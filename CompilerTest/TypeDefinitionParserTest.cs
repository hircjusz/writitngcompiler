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
    public class TypeDefinitionParserTest
    {

        PascalHelper helper = new PascalHelper();
        ParserTreePrint parserTreePrinter = new ParserTreePrint();


        [TestMethod]
        public void ParsingTypeArray()
        {
            var parser = helper.Pascal("compile", "../../Sources/TypeDefinitionParser/ParsingTypeArray.txt", "F1");
            var txt = parserTreePrinter.Print(parser.Code.GetRoot(), 0);

        }
    }
}
