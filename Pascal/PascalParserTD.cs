using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler;
using Compiler.Messages;

namespace Pascal
{
    public class PascalParserTD:Parser
    {
        public PascalParserTD(Scanner scanner):base(scanner){
        
        }

        public override void Parse()
        {

            

            Token token;
            while(!((token=scanner.extractToken()) is EofToken )){
            
              //  OnMessage(new Message(token.Text,MessageType.TEXT));
                OnMessage(new Message(token.Text,MessageType.TOKEN,token));
            }


        }

    }
}
