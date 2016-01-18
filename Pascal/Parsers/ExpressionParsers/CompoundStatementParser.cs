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
    public class CompoundStatementParser : IParserStatement
    {

        private Parser _parser;


        public CompoundStatementParser(Parser parser)
        {
            this._parser = parser;
        }

        public ICodeNode Parse(Compiler.Token token)
        {
            token = _parser.NextToken();//Consume the BEGIN
            var compoundNode = CodeFactory.CreateICodeNode(CodeNodeTypeEnum.COMPOUND);
            var statementParser = new StatementParser(_parser);
            statementParser.ParseList(token, compoundNode, PascalTokenReservedEnum.END, null);
            return compoundNode;
        }
    }
}
