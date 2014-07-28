using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler;
using  System.Collections.Generic;
namespace Pascal.Tokens
{
    public  class PascalTokenType:TokenType
    {
        public static HashSet<char> RESERVED_SYMBOLS = new HashSet<char>() {'+','=',':','<','>','.' };



        
    }
}
