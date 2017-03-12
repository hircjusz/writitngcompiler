using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace CompilerTest
{
    public abstract class CompilerTestBase
    {
        protected readonly PascalHelper Helper = new PascalHelper();
        protected readonly ParserTreePrint ParserTreePrinter = new ParserTreePrint();

        protected string CurrentPath {
            get
            {
                var stackTrace= new StackTrace();
                return $"../../Sources/{this.GetType().Name}/Files/{stackTrace.GetFrame(1).GetMethod().Name}.txt";
            }
        }
    }
}
