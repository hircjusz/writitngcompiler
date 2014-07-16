using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler
{
    public class Parser
    {

        //ICode 
        //SymTab
        Scanner scanner = null;

        public Parser(Scanner scanner)
        {
            this.scanner = scanner;
        }

        public void Parse()
        {

        }

        public int getErrorCount()
        {

            //returns number of tokens
            return 0;
        }

        public Token currentToken()
        {
            return new Token();
        }

        public Token NextToken() {
            return new Token();
        
        }


    }
}
