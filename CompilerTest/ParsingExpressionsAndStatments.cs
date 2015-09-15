using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intermediate.Code;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utility;

namespace CompilerTest
{
    [TestClass]
    public class ParsingExpressionsAndStatments
    {
        PascalHelper helper = new PascalHelper();




        //[TestMethod]
        //public void TestCodeFatory1()
        //{
        //    var iCode = CodeFactory.CreateICode();
        //}

        //[TestMethod]
        //public void TestCodeNodeFatory1()
        //{
        //    var iCode = CodeFactory.CreateICodeNode(CodeNodeTypeEnum.CALL);
        //}

        //[TestMethod]
        //public void CodeNodeTest1()
        //{
        //    var iCode = CodeFactory.CreateICodeNode(CodeNodeTypeEnum.CALL);
        //    Assert.AreEqual(iCode.Type, CodeNodeTypeEnum.CALL);
        //    iCode.SetAttribute(CodeKeyEnum.LINE, 1);
        //    iCode.SetAttribute(CodeKeyEnum.VALUE, 9);

        //    var iCode1 = CodeFactory.CreateICodeNode(CodeNodeTypeEnum.ASSIGN);
        //    iCode.AddChild(iCode1);
        //    var iCode2 = CodeFactory.CreateICodeNode(CodeNodeTypeEnum.FUNCTION);
        //    iCode.AddChild(iCode2);

        //    Assert.AreEqual(iCode.Children.Count, 2);
        //    var copy = iCode.Copy();
        //C:\DATA\SOURCES\GitHub\writingcompiler\CompilerTest\Sources\CompoundTest1.txt
        //}

        [TestMethod]
        public void CompoundTest1()
        {
            var parser = helper.Pascal("compile", "../../Sources/CompoundTest1.txt", "F1");
            // parser.Parse();

        }


        [TestMethod]
        public void AssignTest1()
        {
            var parser = helper.Pascal("compile", "../../Sources/AssignTest.txt", "F1");
            var treePrint= new ParserTreePrint();
            var codeTree = treePrint.Print(parser.Code.GetRoot());
            Console.WriteLine(codeTree);
        }

    }
}
