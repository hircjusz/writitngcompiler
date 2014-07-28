using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler;

namespace Pascal
{
    public class PascalScanner : Scanner
    {

        public PascalScanner(Source source)
            : base(source)
        {
        }
        public override Token extractToken()
        {
            char currentChar = source.CurrentChar();
            Token token = null;
            if (currentChar == Source.EOF)
            {
                token = new EofToken(source);
            }
            else
            {
                token = new Token(source);
            }
            return token;
        }
       
    }
}
