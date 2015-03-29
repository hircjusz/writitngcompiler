using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler.Core;
using Intermediate.Symbols;

namespace Backend
{
    public class Executor:IBackend
    {
        public void Process(ICode code, ISymTab symtab)
        {
            throw new NotImplementedException();
        }
    }
}
