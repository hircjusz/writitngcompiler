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
    public class RepeatStatementParser:IParserStatement
    {
        private Parser _parser;
        
        public RepeatStatementParser(Parser parser)
        {
            this._parser = parser;
        }

        public Intermediate.Code.ICodeNode Parse(Compiler.Token token)
        {
            token = _parser.NextToken();
            var loopNode = CodeFactory.CreateICodeNode(CodeNodeTypeEnum.LOOP);
            var testNode = CodeFactory.CreateICodeNode(CodeNodeTypeEnum.TEST);

            var statementParser = new StatementParser(_parser);
            statementParser.ParseList(token,loopNode,PascalTokenReservedEnum.UNTIL,null);
            token = _parser.CurrentToken;

            var expressionParser = new ExpressionParser(_parser);
            testNode.AddChild(expressionParser.Parse(token));
            loopNode.AddChild(testNode);
            return loopNode;

        }
    }
}
