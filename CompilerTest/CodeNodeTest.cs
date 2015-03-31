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
    public class CodeNodeTest
    {
        [TestMethod]
        public void TestCodeFatory1()
        {
            var iCode=CodeFactory.CreateICode();
        }

        [TestMethod]
        public void TestCodeNodeFatory1()
        {
            var iCode = CodeFactory.CreateICodeNode(CodeNodeTypeEnum.CALL);
        }
    }
}
