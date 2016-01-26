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
    public class ArrayTypeParser : ParserAbstractSpecification
    {
        public ArrayTypeParser(Parser parser)
            : base(parser)
        {
        }

        public override ITypeSpec Parse(Token token)
        {
            //createType
            var arrayType = TypeFactory.CreateType(TypeFormEnum.ARRAY);
            token = _parser.NextToken();

            if (token.Text != TokenConst.Left_Bracket)
            {
                _parser.RegisterException(token, ParserExceptionEnum.MISSING_LEFT_BRACKET);
            }
            //left [

            var elementType = ParseIndexTypeList(token, arrayType);
            //todo parse indexTypeList()

            if (token.Text == TokenConst.Rigth_Bracket)
            {
                token = _parser.NextToken();//consume [
            }
            else
            {
                _parser.RegisterException(token, ParserExceptionEnum.MISSING_RIGHT_BRACKET);
            }
            //right bracket
            //synchronize
            if (token.Text == TokenConst.Of)
            {
                token = _parser.NextToken(); //consume of
            }
            else
            {
                _parser.RegisterException(token, ParserExceptionEnum.MISSING_OF);
            }

            //parse OF
            //todo parseElementType
            arrayType.SetAttribute(TypeKeyEnum.ARRAY_ELEMENT_TYPE, ParseElementType(token));

            return null;
        }

        private ITypeSpec ParseIndexTypeList(Token token, ITypeSpec typeSpec)
        {
            bool anotherIndex;
            _parser.NextToken();//consume left bracket
            do
            {
                anotherIndex = false;
                ParseIndexType(token, typeSpec);
                if (token.Text != TokenConst.Coma && token.Text != TokenConst.Rigth_Bracket)
                {
                    //todo error handling
                }
                else if (token.Text == TokenConst.Coma)
                {
                    var newElementType = TypeFactory.CreateType(TypeFormEnum.ARRAY);
                    newElementType.SetAttribute(TypeKeyEnum.ARRAY_ELEMENT_TYPE, typeSpec);
                    typeSpec = newElementType;
                    token = _parser.NextToken();// consume comma
                    anotherIndex = true;
                }
            } while (anotherIndex);

            return typeSpec;
        }

        private void ParseIndexType(Token token, ITypeSpec arrayType)
        {
            var simpleTypeParser = new SimpleTypeParser(_parser);
            var indexType = simpleTypeParser.Parse(token);
            arrayType.SetAttribute(TypeKeyEnum.AARRAY_INDEX_TYPE, indexType);

            if (indexType == null) return;
            ;
            var form = indexType.GetForm();
            int count = 0;

            if (form == TypeFormEnum.SUBRANGE)
            {
                int minValue = (int)indexType.GetAttribute(TypeKeyEnum.SUBRANGE_MIN_VALUE);
                int maxValue = (int)indexType.GetAttribute(TypeKeyEnum.SUBRANGE_MAX_VALUE);

                count = maxValue - minValue + 1;

            }
            else if (form == TypeFormEnum.ENUMERATION)
            {
                var constants = (IList<ISymTabEntry>)indexType.GetAttribute(TypeKeyEnum.ENUMERATION_CONSTANTS);
                count = constants.Count;
            }
            else
            {
                _parser.RegisterException(token, ParserExceptionEnum.INVALID_INDEX_TYPE);
            }
            arrayType.SetAttribute(TypeKeyEnum.ARRAY_ELEMENT_COUNT, count);
        }

        private ITypeSpec ParseElementType(Token token)
        {
            return new TypeSpecificationParser(_parser).Parse(token);
        }


    }
}
