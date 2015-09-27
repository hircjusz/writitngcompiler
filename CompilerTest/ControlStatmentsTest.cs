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
    public class ControlControlStatements
    {
        PascalHelper helper = new PascalHelper();


        [TestMethod]
        public void While_Test1()
        {
            var parser = helper.Pascal("compile", "../../Sources/ControlStatements/While_Test1.txt", "F1");
            var parserTreePrinter = new ParserTreePrint();
            var txt = parserTreePrinter.Print(parser.Code.GetRoot(), 0);

        }


    }
}
