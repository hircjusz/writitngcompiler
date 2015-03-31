using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler;
using Intermediate.Code;

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
            throw new NotImplementedException();
        }
    }
}
