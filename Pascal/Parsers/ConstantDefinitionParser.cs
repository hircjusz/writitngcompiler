using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler;
using Compiler.Exception;
using Intermediate.Code;
using Intermediate.Symbols;
using Intermediate.Type;
using Pascal.Tokens;

namespace Pascal.Parsers
{
    public class ConstantDefinitionParser : IParserStatement
    {

        private Parser _parser;
        public ConstantDefinitionParser(Parser parser)
        {
            this._parser = parser;
        }

        public ICodeNode Parse(Token token)
        {
            while (token.Type.GetTokenName() == PascalTokenType.IdentifierToken)
            {
                string name = token.Text.ToLower();
                var constantId = _parser.SymTabStack.LookupLocal(name);
                if (constantId == null)
                {
                    constantId = _parser.SymTabStack.EnterLocal(name);
                    constantId.AppendLineNumber(token.LineNum);
                }
                else
                {
                    _parser.RegisterException(token, ParserExceptionEnum.IDENTIFIER_UNDEFINED);
                    constantId = null;
                }
                token = _parser.NextToken(); //consume the identifier

                if (!(token.Type.GetTokenName() == PascalTokenType.SpecialToken
                    && token.Text == TokenConst.Equals))
                {
                    _parser.RegisterException(token, ParserExceptionEnum.MISSING_EQUALS);
                }
                token = _parser.NextToken();
                var value = ParseConstant(token);

                if (constantId != null)
                {
                    constantId.SetDefinition(new Definition(DefinitionEnum.CONSTANT));
                    constantId.SetAttribute(SymTabEnum.CONSTANT_VALUE, value);

                    //todo typespec
                }

                token = _parser.CurrentToken;
                if (token.Text == TokenConst.Semicolon)
                {
                    token = _parser.NextToken(); //consume the ;
                }
                else 
                {
                    _parser.RegisterException(token,ParserExceptionEnum.MISSING_SEMICOLON);
                }


            }
            return null;
        }

        private object ParseConstant(Token token)
        {
            string sign = null;

            if (token.Text == TokenConst.Plus || token.Text == TokenConst.Minus)
            {
                sign = token.Text;
                _parser.NextToken();//consume next token
            }

            switch (token.Type.GetTokenName())
            {
                case PascalTokenType.IdentifierToken:
                    {

                    }
                    break;
                case PascalTokenType.IntegerToken:
                {
                    int value = (int) token.Value;
                    _parser.NextToken();
                    return sign == TokenConst.Minus ? -value : value;
                }
                    break;
            }


            return null;
        }
    }
}
