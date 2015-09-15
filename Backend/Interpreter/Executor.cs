using System;
using System.Security.Cryptography.X509Certificates;
using Intermediate.Code;
using Intermediate.Symbols;

namespace Backend.Interpreter
{
    public class Executor:IBackend
    {
        public void Process(ICode code, ISymTab symtab)
        {
            throw new NotImplementedException();
        }
    }


    public interface IExecutor
    {
        Object Execute(ICodeNode node);
    }
}
