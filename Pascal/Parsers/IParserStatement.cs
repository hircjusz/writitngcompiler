using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler;
using Intermediate.Code;

namespace Pascal.Parsers
{
    interface IParserStatement
    {
        ICodeNode Parse(Token token);
    }

    public abstract class ParserAbstractBase : IParserStatement
    {

        protected Parser _parser;

        protected ParserAbstractBase(Parser parser)
        {
            this._parser = parser;
        }


        public virtual ICodeNode Parse(Token token)
        {
            throw new NotImplementedException();
        }
    }
}
