using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler;
using Intermediate.Code;
using Pascal.Tokens;

namespace Pascal.Parsers
{
    public class TypeSpecificationParser : ParserAbstractBase
    {
        private IList<PascalTokenReservedEnum> type_start_set = new List<PascalTokenReservedEnum>()
        {
            PascalTokenReservedEnum.ARRAY,PascalTokenReservedEnum.RECORD
        };

        public TypeSpecificationParser(Parser parser)
            : base(parser)
        {
        }

        public override ICodeNode Parse(Token token)
        {
            _parser.Synchronize(PascalTokenType.GetReservedTokens(type_start_set));

            switch (token.Type.GetTokenName())
            {
                case "ARRAY":
                    {
                        return null;
                    }
                case "RECORD":
                    {
                        return null;
                    }
                default:
                    {
                        var simpleTypeParser = new SimpleTypeParser(_parser);
                        return simpleTypeParser.Parse(token);
                    }

            }

            return null;
        }

    }
}
