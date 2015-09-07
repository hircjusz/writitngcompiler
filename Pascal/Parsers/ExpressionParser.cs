using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler;
using Intermediate.Code;

namespace Pascal.Parsers
{
    public class ExpressionParser : IParserStatement
    {
        private Parser _parser;

        public ExpressionParser(Parser parser)
        {
            _parser = parser;
        }

        private ICodeNode ParseExpression(Token token)
        {

            return ParseSmpleExpression(token);


        }

        private ICodeNode ParseSmpleExpression(Token token)
        {
            if (token.Text == "-" || token.Text == "+")
            {


            }
            return CodeFactory.CreateICodeNode(CodeNodeTypeEnum.NEGATE);
        }

        private ICodeNode ParseTerm(Token token)
        {
            throw new NotImplementedException();
        }

        private ICodeNode ParseFactor(Token token)
        {
            throw new NotImplementedException();
        }

        public ICodeNode Parse(Token token)
        {
            return ParseExpression(token);
        }
    }
}
