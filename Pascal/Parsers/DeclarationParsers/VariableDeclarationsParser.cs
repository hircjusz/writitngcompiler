using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler;
using Compiler.Exception;
using Intermediate.Symbols;
using Intermediate.Type;
using Pascal.Tokens;

namespace Pascal.Parsers.DeclarationParsers
{
    public class VariableDeclarationsParser : ParserAbstractSpecification
    {
        public VariableDeclarationsParser(Parser parser)
            : base(parser)
        {
        }

        public override ITypeSpec Parse(Token token)
        {
            while (token.Type.GetTokenName() == PascalTokenType.IdentifierToken)
            {
                ParseIdentifierSublist(token);
                token = _parser.CurrentToken;
                if (token.Text == TokenConst.Semicolon)
                {
                    while (token.Text == TokenConst.Semicolon)
                    {
                        token = NextToken();
                    }
                }
                else
                {
                    _parser.RegisterException(token, ParserExceptionEnum.MISSING_SEMICOLON);
                }

            }
            return null;
        }

        protected IList<ISymTabEntry> ParseIdentifierSublist(Token token)
        {
            var sublist = new List<ISymTabEntry>();
            do
            {
                var id = ParseIdentifier(token);
                if (id != null)
                {
                    sublist.Add(id);
                }
                //todo synchronize
                token = CurrentToken();

                if (token.Text == TokenConst.Coma)
                {
                    token = NextToken();
                    if (token.Type.GetTokenName() != PascalTokenType.IdentifierToken)
                    {
                        _parser.RegisterException(token, ParserExceptionEnum.MISSING_IDENTIFIER);
                    }
                }

            } while (token.Text != TokenConst.Colon);
            var typeSpecification = ParseTypeSpecification(token);
            sublist.ForEach(t => t.SetTypeSpec(typeSpecification));
            return sublist;
        }

        protected ISymTabEntry ParseIdentifier(Token token)
        {
            ISymTabEntry id = null;
            if (token.Type.GetTokenName() == PascalTokenType.IdentifierToken)
            {
                var name = token.Text.ToLower();
                id = _parser.SymTabStack.LookupLocal(name);

                if (id == null)
                {
                    id = _parser.SymTabStack.EnterLocal(name);
                    id.SetDefinition(new Definition(DefinitionEnum.FIELD));
                    id.AppendLineNumber(token.LineNum);

                }
                else
                {
                    _parser.RegisterException(token, ParserExceptionEnum.IDENTIFIER_REDEFINED);
                }
                token = NextToken(); //consume identifier
            }
            else
            {
                _parser.RegisterException(token, ParserExceptionEnum.MISSING_IDENTIFIER);
            }
            return id;
        }

        private ITypeSpec ParseTypeSpecification(Token token)
        {
            if (token.Text == TokenConst.Colon)
            {
                token = NextToken();
            }
            else
            {
                _parser.RegisterException(token, ParserExceptionEnum.MISSING_COLON);
            }
            var typeSpecificationParser = new TypeSpecificationParser(_parser);
            return typeSpecificationParser.Parse(token);
        }

    }
}
