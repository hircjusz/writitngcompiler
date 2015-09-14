using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler;
using Intermediate.Code;
using Pascal.Tokens;

namespace Pascal.Parsers
{
    public class StatementParser:IParserStatement
    {
        private Parser _parser;

        public StatementParser( Parser parser)
        {
            _parser = parser;
        }

        public ICodeNode Parse(Token token)
        {
            ICodeNode statementNode = null;

            if (token.Type.GetType() == typeof (ReservedWordToken) && token.Type.GetTokenName() == PascalTokenReservedEnum.BEGIN.ToString())
            {
                var compoundParser = new CompoundStatementParser(_parser);
                statementNode = compoundParser.Parse(token);

            }
            else
           
            if (token.Type.GetType() == typeof(IdentifierToken) )
            {
                var assignmentStatementParser= new AssignmentStatementParser(_parser);
                statementNode = assignmentStatementParser.Parse(token);
            }
            else
            {
                statementNode = CodeFactory.CreateICodeNode(CodeNodeTypeEnum.NO_OP);
            }
            SetLineNumber(statementNode, token);
            return statementNode;
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
        public void ParseList(Token token,ICodeNode parentNode,PascalTokenReservedEnum terminator,PascalErrorToken errorCode)
        {

            while (!(token is EofToken) && 
                !(token.Type.GetType() == typeof(ReservedWordToken) && terminator==((ReservedWordToken)token.Type).ReservedEnum))
            {
                ICodeNode statementNode = Parse(token);
                parentNode.AddChild(statementNode);
                token = _parser.currentToken();

                TokenType type = token.Type;

                if (type.GetType() == typeof (SpecialToken) && Equals(token.Value, ";"))
                {
                    //zjadamy kolejny token
                    token = _parser.NextToken();
                }

            }




        }


        protected void SetLineNumber(ICodeNode node, Token token)
        {
            if (node != null)
            {
                node.SetAttribute(CodeKeyEnum.LINE,token.LineNum);
            }

        }
    }
}
