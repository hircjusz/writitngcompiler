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
    public class InterpretingControlStatements
    {
        PascalHelper helper = new PascalHelper();


        [TestMethod]
        public void WhileTest1()
        {
            var parser = helper.Pascal("compile", "../../Sources/InterpretingControlStatements/While_Test1.txt", "F1");
            // parser.Parse();
            var executor=BackendFactory.Createbackend("execute");
            executor.Process(parser.Code,parser.SymTab);
        }


    }
}
