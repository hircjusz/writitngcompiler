using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler;
using Compiler.Exception;
using Intermediate.Type;
using Pascal.Tokens;

namespace Pascal.Parsers
{
    public class TypeDefinitionParser : ParserAbstractBase
    {

        private IList<TokenType> var_start_set = new List<TokenType>()
        {
            new IdentifierToken()
        };

        public TypeDefinitionParser(Parser parser)
            : base(parser)
        {
        }

        public override Intermediate.Code.ICodeNode Parse(Compiler.Token token)
        {
            _parser.Synchronize(var_start_set);
            while (token.Type.GetTokenName() == PascalTokenType.IdentifierToken)
            {
                string name = token.Text.ToLower();
                var typeId = _parser.SymTabStack.LookupLocal(name);

                if (typeId == null)
                {
                    typeId = _parser.SymTabStack.EnterLocal(name);
                    typeId.AppendLineNumber(token.LineNum);
                }
                else
                {
                    _parser.RegisterException(token, ParserExceptionEnum.IDENTIFIER_UNDEFINED);
                    typeId = null;
                }

                token = _parser.NextToken();//consume identifier token
                //synchrozine the = token
                //token=_parser.Synchronize(new {})
                if (token.Text == TokenConst.Equals)
                {
                    token = _parser.NextToken();
                }
                else
                {
                    _parser.RegisterException(token,ParserExceptionEnum.MISSING_EQUALS);
                }

                var typeSpecification=new TypeSpecificationParser(_parser);
                var type = typeSpecification.Parse(token);

                if (typeId != null)
                {
                    typeId.SetDefinition(new Definition(DefinitionEnum.TYPE));
                }
                if ((type!=null) && (typeId!=null))
                {

                }

            }

            return null;
        }


    }
}
