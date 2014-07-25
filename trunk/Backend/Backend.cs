using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler.Core;

namespace Backend
{
    public interface IBackend
    {
        void Process(ICode code, SymTab symtab);
    }
}
