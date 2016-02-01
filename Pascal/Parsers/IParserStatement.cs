using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler;
using Intermediate.Code;
using Intermediate.Type;

namespace Pascal.Parsers
{
    interface IParserStatement
    {
        ICodeNode Parse(Token token);
    }

    interface IParserSpecification
    {
        ITypeSpec Parse(Token token);
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


        protected Token NextToken()
        {
            return _parser.NextToken();
        }

        protected Token CurrentToken()
        {
            return _parser.CurrentToken;
        }
    }


    public abstract class ParserAbstractSpecification : IParserSpecification
    {

        protected Parser _parser;

        protected ParserAbstractSpecification(Parser parser)
        {
            this._parser = parser;
        }


        public virtual ITypeSpec Parse(Token token)
        {
            throw new NotImplementedException();
        }

        protected Token NextToken()
        {
            return _parser.NextToken();
        }

        protected Token CurrentToken()
        {
            return _parser.CurrentToken;
        }
    }
}
