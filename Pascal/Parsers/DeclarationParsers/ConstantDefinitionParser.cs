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

                    var constantType = token.Type.GetTokenName() == PascalTokenType.IdentifierToken
                        ? GetConstantType(token) : GetConstantType(value);
                    constantId.SetTypeSpec(constantType);
                }

                token = _parser.CurrentToken;
                if (token.Text == TokenConst.Semicolon)
                {
                    token = _parser.NextToken(); //consume the ;
                }
                else
                {
                    _parser.RegisterException(token, ParserExceptionEnum.MISSING_SEMICOLON);
                }


            }
            return null;
        }

        public  object ParseConstant(Token token)
        {
            string sign = null;

            if (token.Text == TokenConst.Plus || token.Text == TokenConst.Minus)
            {
                sign = token.Text;
                token = _parser.NextToken();//consume next token
            }

            switch (token.Type.GetTokenName())
            {
                case PascalTokenType.IdentifierToken:
                    {
                        return ParseIdentifierConstant(token, sign);
                    }
                case PascalTokenType.IntegerToken:
                    {
                        int value = (int)token.Value;
                        _parser.NextToken();
                        return sign == TokenConst.Minus ? -value : value;
                    }
                case PascalTokenType.RealToken:
                    {
                        double value = (double)token.Value;
                        _parser.NextToken();
                        return sign == TokenConst.Minus ? -value : value;
                    }
                case PascalTokenType.StringToken:
                    {
                        if (sign != null) _parser.RegisterException(token, ParserExceptionEnum.INVALID_CONSTANT);
                        _parser.NextToken();
                        return (string)token.Value;
                    }
                default:
                    {
                        _parser.RegisterException(token, ParserExceptionEnum.INVALID_CONSTANT);
                        return null;
                    }
            }


            return null;
        }

        private object ParseIdentifierConstant(Token token, string sign)
        {
            string name = token.Text;
            ISymTabEntry id = _parser.SymTabStack.Lookup(name);

            //consume identifier
            _parser.NextToken();

            if (id == null)
            {
                _parser.RegisterException(token, ParserExceptionEnum.IDENTIFIER_UNDEFINED);
                return null;
            }

            var definition = id.GetDefinition();
            if (definition.GetDef() == DefinitionEnum.CONSTANT)
            {
                object value = id.GetAttribute(SymTabEnum.CONSTANT_VALUE);
                id.AppendLineNumber(token.LineNum);

                if (value is int)
                {
                    return sign == TokenConst.Minus ? -((int)value) : value;
                }
                if (value is double || value is float)
                {
                    return sign == TokenConst.Minus ? -((double)value) : value;
                }
                if (value is string)
                {
                    if (sign != null)
                    {
                        _parser.RegisterException(token, ParserExceptionEnum.INVALID_CONSTANT);
                    }
                    return value;
                }
                else return null;
            }
            //TODO parsing enumaration constant

            return null;
        }

        public  ITypeSpec GetConstantType(object value)
        {
            ITypeSpec constantType = null;

            if (value is int)
            {
                constantType = Predefined.IntegerType;
            }
            else if (value is float || value is double)
            {
                constantType = Predefined.RealType;
            }
            else
            {
                var s = value as string;
                if (s != null)
                {
                    constantType = s.Length == 1 ? Predefined.CharType : TypeFactory.CreateStringType(s);
                }
            }
            return constantType;
        }

        private ITypeSpec GetConstantType(Token token)
        {
            var id = _parser.SymTabStack.Lookup(token.Text);
            if (id == null) return null;
            var definition = id.GetDefinition();

            if (definition.GetDef() == DefinitionEnum.CONSTANT
                || definition.GetDef() == DefinitionEnum.ENUMERATION_CONSTANT)
            {
                return id.GetTypeSpec();
            }

            return null;
        }


    }
}
