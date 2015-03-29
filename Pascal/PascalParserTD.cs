using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler;
using Compiler.Messages;
using Intermediate.Symbols;
using Pascal.Tokens;

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
                if (token.Type.GetType() == typeof (IdentifierToken))
                {
                    string name = token.Text.ToLower();
                    var entry=symTabStack.Lookup(name) ?? symTabStack.EnterLocal(name);
                    entry.AppendLineNumber(token.LineNum);
                }
                OnMessage(new Message(token.Text,MessageType.TOKEN,token));
            }


        }

    }
}
