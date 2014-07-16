using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler
{
    public class Scanner
    {

        public Token currentToken() {

            return new Token();
        }

        public Token nextToken() {

            return new Token();
        }

        protected Token extractToken() {

            return new Token();
        }
        
        public char currentChar() {

            return 'a';
        }

        public char nextChar() {

            return 'b';
        }



    }
}
