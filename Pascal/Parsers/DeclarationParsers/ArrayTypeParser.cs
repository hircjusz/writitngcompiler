using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler;
using Intermediate.Code;

namespace Pascal.Parsers
{
    public class ArrayTypeParser : ParserAbstractBase
    {
        public ArrayTypeParser(Parser parser) : base(parser)
        {
        }

        public override ICodeNode Parse(Token token)
        {
            throw new Exception();
        }
    }
}
