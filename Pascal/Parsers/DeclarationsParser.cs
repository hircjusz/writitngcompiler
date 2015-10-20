using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler;
using Pascal.Tokens;

namespace Pascal.Parsers
{
    public class DeclarationsParser : IParserStatement
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
            PascalTokenReservedEnum.BEGIN
        };


        private Parser _parser;
        public DeclarationsParser(Parser parser)
        {
            this._parser = parser;
        }



        public Intermediate.Code.ICodeNode Parse(Token token)
        {
            token = _parser.Synchronize(PascalTokenType.GetReservedTokens(declarations_start_set));
            if (token.Type.GetTokenName() == PascalTokenReservedEnum.CONST.ToString())
            {
                token = _parser.NextToken();
                var constantDefinitionParser = new ConstantDefinitionParser(_parser);
                constantDefinitionParser.Parse(token);
            }



            return null;
        }
    }
}
