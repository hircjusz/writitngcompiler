using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler.Messages;

namespace Compiler
{
    public class Parser
    {

        //ICode 
        //SymTab
        Scanner scanner = null;
        LoggerEventHandler logger = new LoggerEventHandler();


        public Parser(Scanner scanner)
        {
            this.scanner = scanner;
            scanner.MessageEvents += logger.HandleMessage;
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
            return scanner.currentToken();
        }

        public Token NextToken() {
            return new Token();
        }


    }
}
