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
        public static HashSet<string> RESERVED_WORDS = new HashSet<string>() {"BEGIN" };

        private static int counter=16;
        public static int IDENTIFIER = counter+1;
        public static int RESERVED_WORD = counter + 2;



        
    }
}
