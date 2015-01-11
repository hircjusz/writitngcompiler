using System;
using Compiler;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CompilerTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SourceTestReadFile()
        {
            var source = new Source("../../Sources/File1.txt");


            string lineMessage = String.Empty ;
            char c='x';

            while ((c = source.NextChar()) != Source.EOF) {

                if (c == Source.EOL)
                {
                    Console.WriteLine(c);
                    lineMessage = String.Empty;
                }
                else
                {
                    lineMessage += c;
                }
            
            }


        }
    }
}
