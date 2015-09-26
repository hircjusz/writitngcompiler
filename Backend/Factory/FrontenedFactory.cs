using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pascal;

namespace Compiler.Factory
{
    public class FrontenedFactory
    {
        public static Parser CreateParser(string language,string type,Source source) {

            switch (language)
            {
                case "Pascal":
                    var scanner = new PascalScanner(source);
                    var parser = new PascalParserTD(scanner);
                    return parser;
               
            }
        throw  new System.Exception();
        }


    }
}
