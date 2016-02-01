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
    public class RecordTypeParser : ParserAbstractSpecification
    {
        public RecordTypeParser(Parser parser)
            : base(parser)
        {

        }

        public override ITypeSpec Parse(Token token)
        {
            var recordType = TypeFactory.CreateType(TypeFormEnum.RECORD);
            token = NextToken();
            recordType.SetAttribute(TypeKeyEnum.RECORD_SYMTAB, _parser.SymTabStack.Push());
            var variableDeclarationsParser = new VariableDeclarationsParser(_parser);

            variableDeclarationsParser.Parse(token);

            _parser.SymTabStack.Pop();
            token = CurrentToken();
            if (token.Text.ToLower() == PascalTokenReservedEnum.END.ToString().ToLower())
            {
                token = NextToken();
            }
            else
            {
                _parser.RegisterException(token, ParserExceptionEnum.MISSING_END);
            }
            return recordType;
        }
    }
}
