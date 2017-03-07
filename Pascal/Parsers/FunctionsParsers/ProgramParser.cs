using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler;
using Intermediate.Code;
using Intermediate.Symbols;

namespace Pascal.Parsers.FunctionsParsers
{
    public class ProgramParser: IDeclarationsParser
    {
        public ISymTabEntry Parse(Token token, ISymTabEntry parentId)
        {
            throw new NotImplementedException();
        }
    }
}
