using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend;
using Intermediate.Code;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utility;

namespace CompilerTest
{
    [TestClass]
    public class BlockParserTest
    {
        PascalHelper helper = new PascalHelper();
        ParserTreePrint parserTreePrinter = new ParserTreePrint();


        [TestMethod]
        public void BlockParser1()
        {
            var parser = helper.Pascal("compile", "../../Sources/BlockParser/BlockParser1.txt", "F1");
            var txt = parserTreePrinter.Print(parser.Code.GetRoot(), 0);

        }

        //[TestMethod]
        //public void Repeat_Test1()
        //{
        //    var parser = helper.Pascal("compile", "../../Sources/ControlStatements/Repeat_Test1.txt", "F1");
        //    var txt = parserTreePrinter.Print(parser.Code.GetRoot(), 0);

        //}


    }
}
