using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler;
using Compiler.Messages;
using Intermediate.Code;
using Intermediate.Symbols;
using Pascal.Parsers;
using Pascal.Tokens;


namespace Pascal
{
    public class PascalParserTD:Parser
    {
        public PascalParserTD(Scanner scanner):base(scanner){
        }

        public override void Parse()
        {

            ICode code = CodeFactory.CreateICode();

            try
            {
                var token = NextToken();
                ICodeNode root = null;

                if (token.Type.GetType() == typeof (ReservedWordToken) && token.Type.GetTokenName() ==PascalTokenReservedEnum.BEGIN.ToString())
                {
                    var statementParser = new StatementParser(this);
                    root = statementParser.Parse(token);
                    //token = currentToken();

                }

                token = currentToken();
                if (root != null)
                {
                    iCode.SetRoot(root);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            //Token token;
            //while(!((token=scanner.extractToken()) is EofToken )){
            //    if (token.Type.GetType() == typeof (IdentifierToken))
            //    {
            //        string name = token.Text.ToLower();
            //        var entry=symTabStack.Lookup(name) ?? symTabStack.EnterLocal(name);
            //        entry.AppendLineNumber(token.LineNum);
            //    }
            //    OnMessage(new Message(token.Text,MessageType.TOKEN,token));
            //}


        }

    }
}
