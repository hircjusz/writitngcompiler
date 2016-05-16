using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler;
using Compiler.Exception;
using Intermediate.Code;
using Pascal.Tokens;

namespace Pascal.Parsers
{
    public class BlockParser : IParserStatement
    {
        private Parser _parser;

        public BlockParser(Parser parser)
        {
            this._parser = parser;
        }


        public ICodeNode Parse(Token token)
        {
            var declarationsParser=new DeclarationsParser(_parser);
            var statementParser = new StatementParser(_parser);

            declarationsParser.Parse(token);
            //todo token synchronize

             token = _parser.CurrentToken;
            ICodeNode rootNode = null;

            if (token.Type.GetType() == typeof (ReservedWordToken) &&
                token.Type.GetTokenName() == PascalTokenReservedEnum.BEGIN.ToString())
            {
                rootNode = statementParser.Parse(token);
            }
            else
            {
                _parser.RegisterException(token,ParserExceptionEnum.MISSING_BEGIN);

                //todo parse it anyway
            }

            return rootNode;
        }
    }
}
