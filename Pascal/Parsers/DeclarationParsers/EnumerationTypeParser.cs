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

namespace Pascal.Parsers.DeclarationParsers
{
    public class EnumerationTypeParser:ParserAbstractSpecification
    {
        public EnumerationTypeParser(Parser parser) : base(parser)
        {
        }

        public override ITypeSpec Parse(Token token)
        {
            var enumerationType = TypeFactory.CreateType(TypeFormEnum.ENUMERATION);
            int value = -1;
            var constants = new List<ISymTabEntry>();
            token = _parser.NextToken();//consume the opening
            do
            {
                ParseEnumerationIdentfier(token,++value,enumerationType,constants);
                token = _parser.CurrentToken;
                if (token.Text == TokenConst.Coma)
                {
                    token = _parser.NextToken();//consume coma
                }
            } while (token.Type.GetTokenName() == PascalTokenType.IdentifierToken); 
            //look for the closing
            if (token.Text == TokenConst.Rigth_Parent)
            {
                token = _parser.NextToken(); //consume the )
            }
            else
            {
                _parser.RegisterException(token,ParserExceptionEnum.MISSING_RIGHT_PARENT);
            }
            
            enumerationType.SetAttribute(TypeKeyEnum.ENUMERATION_CONSTANTS, constants);
            return enumerationType;
        }

        public void ParseEnumerationIdentfier(Token token,int value,
            ITypeSpec enumerationType,IList<ISymTabEntry>constants)
        {
            if (token.Type.GetTokenName() == PascalTokenType.IdentifierToken)
            {
                var name = token.Text.ToLower();
                var constantId = _parser.SymTabStack.LookupLocal(name);
                if (constantId != null)
                {
                    _parser.RegisterException(token, ParserExceptionEnum.IDENTIFIER_REDEFINED);
                }
                else
                {
                    constantId = _parser.SymTabStack.EnterLocal(token.Text);
                    constantId.SetDefinition(new Definition(DefinitionEnum.CONSTANT));
                    constantId.SetTypeSpec(enumerationType);
                    constantId.SetAttribute(SymTabEnum.CONSTANT_VALUE, value);
                    constantId.AppendLineNumber(token.LineNum);
                    constants.Add(constantId);
                }
                token = _parser.NextToken();//consume the identifier
            }
            else
            {
                _parser.RegisterException(token, ParserExceptionEnum.MISSING_IDENTIFIER);
            }

        }
    }
}
