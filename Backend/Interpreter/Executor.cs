using System;
using System.Security.Cryptography.X509Certificates;
using Backend.Runtime;
using Intermediate.Code;
using Intermediate.Symbols;

namespace Backend.Interpreter
{
    public class Executor:IBackend
    {
        private ICode _code;
        private ISymTab symtab;
        protected int executionCount;
        protected IRuntimeStack runtimeStack;
         

        public void Process(ICode code, ISymTab symtab)
        {
            _code = code;
            this.symtab = symtab;


            var rootNode=code.GetRoot();
            var statementExecutor = new StatementExecutor();
            statementExecutor.Execute(rootNode);

            //Todo send message




        }
    }


    public interface IExecutor
    {
        Object Execute(ICodeNode node);
    }
}
