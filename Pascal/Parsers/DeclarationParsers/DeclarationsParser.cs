using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler;
using Intermediate.Symbols;
using Pascal.Parsers.DeclarationParsers;
using Pascal.Parsers.FunctionsParsers;
using Pascal.Tokens;

namespace Pascal.Parsers
{

    public interface IDeclarationsParser
    {
        ISymTabEntry Parse(Token token, ISymTabEntry parentId);
    }

    public class DeclarationsParser : IDeclarationsParser
    {
        private IList<PascalTokenReservedEnum> declarations_start_set = new List<PascalTokenReservedEnum>()
        {
            PascalTokenReservedEnum.CONST,PascalTokenReservedEnum.TYPE,PascalTokenReservedEnum.VAR,
            PascalTokenReservedEnum.PROCEDURE,PascalTokenReservedEnum.FUNCTION,PascalTokenReservedEnum.BEGIN
        };

        private IList<PascalTokenReservedEnum> type_start_set = new List<PascalTokenReservedEnum>()
        {
            PascalTokenReservedEnum.TYPE
        };

        private IList<PascalTokenReservedEnum> var_start_set = new List<PascalTokenReservedEnum>()
        {
            PascalTokenReservedEnum.VAR
        };

        private IList<PascalTokenReservedEnum> routine_start_set = new List<PascalTokenReservedEnum>()
        {
            PascalTokenReservedEnum.PROCEDURE,PascalTokenReservedEnum.FUNCTION,PascalTokenReservedEnum.BEGIN
        };


        private Parser _parser;
        public DeclarationsParser(Parser parser)
        {
            this._parser = parser;
        }



        public ISymTabEntry Parse(Token token, ISymTabEntry parentId)
        {
            token = _parser.Synchronize(PascalTokenType.GetReservedTokens(declarations_start_set));
            if (token.Type.GetTokenName() == PascalTokenReservedEnum.CONST.ToString())
            {
                token = _parser.NextToken();//consume const
                var constantDefinitionParser = new ConstantDefinitionParser(_parser);
                constantDefinitionParser.Parse(token);
            }
            //token = _parser.Synchronize(PascalTokenType.GetReservedTokens(type_start_set));

            if (token.Type.GetTokenName() == PascalTokenReservedEnum.TYPE.ToString())
            {
                token = _parser.NextToken();//consume type
                var typeDefinitionParser = new TypeDefinitionParser(_parser);
                typeDefinitionParser.Parse(token);
            }

            if (token.Type.GetTokenName() == PascalTokenReservedEnum.VAR.ToString())
            {
                token = _parser.NextToken();//consume var
                var variableDeclarationsParser = new VariableDeclarationsParser(_parser);
                variableDeclarationsParser.Parse(token);

            }
            _parser.Synchronize(routine_start_set.Select(t => new ReservedWordToken(t) as TokenType).ToList());
            var tokenType = token.Type;
            while ((tokenType.GetTokenName() == PascalTokenReservedEnum.PROCEDURE.ToString()) || (tokenType.GetTokenName() == PascalTokenReservedEnum.FUNCTION.ToString()))
            {
                var declaredRoutineParser = new DeclaredRoutineParser(_parser);
                declaredRoutineParser.Parse(token, parentId);

                token = _parser.CurrentToken;
                if (token.Type.GetTokenName() == TokenConst.Semicolon)
                {
                    while (token.Type.GetTokenName() == TokenConst.Semicolon)
                    {
                        token = _parser.NextToken();
                    }
                }
                _parser.Synchronize(routine_start_set.Select(t => new ReservedWordToken(t) as TokenType).ToList());
            }


            return null;
        }
    }
}
