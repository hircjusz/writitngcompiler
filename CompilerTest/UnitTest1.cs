using System;
using System.Text;
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
            var source = new Source("../../Sources/AssignTest.txt");
            var builder = new StringBuilder();

            string lineMessage = String.Empty;
            char c = 'x';

            while ((c = source.NextChar()) != Source.EOF)
            {

                if (c == Source.EOL)
                {
                    Console.WriteLine(c);
                    builder.Append(lineMessage);
                    lineMessage = String.Empty;

                }
                else
                {
                    lineMessage += c;
                }

            }

            var txt = builder.ToString();
        }


    }
}
