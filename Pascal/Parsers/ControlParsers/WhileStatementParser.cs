using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler;
using Compiler.Exception;
using Intermediate.Code;
using Pascal.Tokens;

namespace Pascal.Parsers
{
    public class WhileStatementParser : IParserStatement
    {
        protected Parser _parser;

        public WhileStatementParser(Parser parser)
        {
            _parser = parser;
        }

        public Intermediate.Code.ICodeNode Parse(Compiler.Token token)
        {
            token = _parser.NextToken();

            var loopNode = CodeFactory.CreateICodeNode(CodeNodeTypeEnum.LOOP);
            var breakNode = CodeFactory.CreateICodeNode(CodeNodeTypeEnum.TEST);
            var notNode = CodeFactory.CreateICodeNode(CodeNodeTypeEnum.NOT);

            loopNode.AddChild(breakNode);
            breakNode.AddChild(notNode);

            var expressionParser = new ExpressionParser(_parser);
            notNode.AddChild(expressionParser.Parse(token));
            token=_parser.Synchronize(new List<TokenType>() {new ReservedWordToken(PascalTokenReservedEnum.DO)});
            if (token.Type.GetTokenName().ToLower() == "do")
            {
                token = _parser.NextToken();
            }
            else
            {
                _parser.RegisterException(token,ParserExceptionEnum.MISSING_DO);
            }

            var statementParser = new StatementParser(_parser);
            loopNode.AddChild(statementParser.Parse(token));
            return loopNode;

        }
    }
}
