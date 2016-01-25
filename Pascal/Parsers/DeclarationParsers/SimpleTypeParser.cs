using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler;
using Compiler.Exception;
using Intermediate.Code;
using Intermediate.Type;
using Pascal.Parsers.DeclarationParsers;
using Pascal.Tokens;

namespace Pascal.Parsers
{
    public class SimpleTypeParser : ParserAbstractSpecification
    {
        public SimpleTypeParser(Parser parser)
            : base(parser)
        {
        }

        public override ITypeSpec Parse(Token token)
        {
            switch (token.Type.GetTokenName())
            {
                case PascalTokenType.IdentifierToken:
                {
                    string name = token.Text.ToLower();
                    var id = _parser.SymTabStack.Lookup(name);

                    if (id != null)
                    {
                        var definition = id.GetDefinition();
                        //It's either a type identifier
                        //or the start of a subrange type

                        if (definition.GetDef() == DefinitionEnum.TYPE)
                        {
                            id.AppendLineNumber(token.LineNum);
                            token = _parser.NextToken(); //consume the idnetifier
                            //return reference
                            return id.GetTypeSpec();
                        }
                        if (definition.GetDef() != DefinitionEnum.CONSTANT &&
                            definition.GetDef() != DefinitionEnum.ENUMERATION_CONSTANT)
                        {
                            _parser.RegisterException(token, ParserExceptionEnum.NO_TYPE_IDENTIFIER);
                            token = _parser.NextToken();
                            return null;
                        }
                        var subRangeTypeParser = new SubrangeTypeParser(_parser);
                        return subRangeTypeParser.Parse(token);
                    }
                    _parser.RegisterException(token,ParserExceptionEnum.IDENTIFIER_UNDEFINED);
                    token = _parser.NextToken();
                    return null;
                }
                case PascalTokenType.SpecialToken:
                    {
                        if (token.Text == TokenConst.Left_Parent)
                        {
                            var enumerationTypeParser = new EnumerationTypeParser(_parser);
                            return enumerationTypeParser.Parse(token);
                        }
                        _parser.RegisterException(token,ParserExceptionEnum.INVALID_CONSTANT);
                        return null;
                    }
                default:
                    {
                        var subrangeTypeParser = new SubrangeTypeParser(_parser);
                        return subrangeTypeParser.Parse(token);
                    }
            }
        }

    }
}
