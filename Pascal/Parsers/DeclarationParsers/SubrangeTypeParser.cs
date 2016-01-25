using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler;
using Compiler.Exception;
using Intermediate.Code;
using Intermediate.Type;
using Pascal.Tokens;

namespace Pascal.Parsers.DeclarationParsers
{
    public class SubrangeTypeParser : ParserAbstractSpecification
    {
        public SubrangeTypeParser(Parser parser)
            : base(parser)
        {
        }

        public override ITypeSpec Parse(Token token)
        {
            ITypeSpec typeSpec = TypeFactory.CreateType(TypeFormEnum.SUBRANGE);
            object minValue = null;
            object maxValue = null;

            var constantDefinitionParser = new ConstantDefinitionParser(_parser);
            minValue = constantDefinitionParser.ParseConstant(token);
            ITypeSpec minType = token.Type.GetTokenName() == PascalTokenType.IdentifierToken
                ? constantDefinitionParser.GetConstantType(token)
                : constantDefinitionParser.GetConstantType(minValue);

            //todo checkValue Token

            token = _parser.CurrentToken;

            bool wasDotDot = false;

            if (token.Text == TokenConst.Dot_dot)
            {
                token = _parser.NextToken();
                wasDotDot = true;
            }

            if (!wasDotDot)
            {
                _parser.RegisterException(token, ParserExceptionEnum.MISSING_DOT_DOT);
            }
            //todo Constant_start_set synchornization

            maxValue = constantDefinitionParser.ParseConstant(token);
            ITypeSpec maxType = token.Type.GetTokenName() == PascalTokenType.IdentifierToken
                ? constantDefinitionParser.GetConstantType(token)
                : constantDefinitionParser.GetConstantType(maxValue);

            //todo checkValue

            if (minType == null || maxType == null)
            {
                _parser.RegisterException(token, ParserExceptionEnum.INCOMPATIBLE_TYPES);
            }
            else
                if (minType != maxType)
                {
                    _parser.RegisterException(token, ParserExceptionEnum.INCOMPATIBLE_TYPES);
                }
                else if ((int)minValue > (int)maxValue)
                {
                    _parser.RegisterException(token, ParserExceptionEnum.MIN_GT_MAX);
                }

            typeSpec.SetAttribute(TypeKeyEnum.SUBRANGE_INDEX_TYPE, minType);
            typeSpec.SetAttribute(TypeKeyEnum.SUBRANGE_MIN_VALUE, minValue);
            typeSpec.SetAttribute(TypeKeyEnum.SUBRANGE_MAX_VALUE, maxValue);
            return typeSpec;

        }
    }
}
