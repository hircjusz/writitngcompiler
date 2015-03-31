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
        PascalHelper helper = new PascalHelper();

        [TestMethod]
        public void TestCodeFatory1()
        {
            var iCode = CodeFactory.CreateICode();
        }

        [TestMethod]
        public void TestCodeNodeFatory1()
        {
            var iCode = CodeFactory.CreateICodeNode(CodeNodeTypeEnum.CALL);
        }

        [TestMethod]
        public void CodeNodeTest1()
        {
            var iCode = CodeFactory.CreateICodeNode(CodeNodeTypeEnum.CALL);
            Assert.AreEqual(iCode.Type, CodeNodeTypeEnum.CALL);
            iCode.SetAttribute(CodeKeyEnum.LINE, 1);
            iCode.SetAttribute(CodeKeyEnum.VALUE, 9);

            var iCode1 = CodeFactory.CreateICodeNode(CodeNodeTypeEnum.ASSIGN);
            iCode.AddChild(iCode1);
            var iCode2 = CodeFactory.CreateICodeNode(CodeNodeTypeEnum.FUNCTION);
            iCode.AddChild(iCode2);

            Assert.AreEqual(iCode.Children.Count, 2);
            var copy = iCode.Copy();

        }

        [TestMethod]
        public void CodeNodeparseBegin()
        {
            var parser = helper.Pascal("compile", "../../Sources/CodeNodeTest.txt", "F1");

        }
    }
}
