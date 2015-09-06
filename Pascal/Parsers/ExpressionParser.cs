using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intermediate.Code;

namespace Pascal.Parsers
{
    public class ExpressionParser : IParserStatement
    {

        private ICodeNode ParseExpression()
        {
            throw new NotImplementedException();
        }

        private ICodeNode ParseSmpleExpression()
        {
            throw new NotImplementedException();
        }

        private ICodeNode  ParseTerm()
        {
            throw new NotImplementedException();
        }

        private ICodeNode ParseFactor()
        {
            throw new NotImplementedException();
        }

        public ICodeNode Parse(Compiler.Token token)
        {
            throw new NotImplementedException();
        }
    }
}
