using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intermediate.Code;
using Intermediate.Symbols;

namespace Backend
{
    public interface IBackend
    {
        void Process(ICode code, ISymTab symtab);
    }
}
