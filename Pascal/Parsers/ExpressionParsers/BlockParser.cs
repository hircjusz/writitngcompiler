using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler;
using Intermediate.Code;

namespace Pascal.Parsers
{
    public class BlockParser : IParserStatement
    {
        private Parser _parser;

        public BlockParser(Parser parser)
        {
            this._parser = parser;
        }


        public ICodeNode Parse(Token token)
        {
            var declarationsParser=new DeclarationsParser(_parser);
            var statementParser = new StatementParser(_parser);

            declarationsParser.Parse(token);


            return null;
        }
    }
}
