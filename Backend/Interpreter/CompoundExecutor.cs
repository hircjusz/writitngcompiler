using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intermediate.Code;

namespace Backend.Interpreter
{
    public class CompoundExecutor:IExecutor
    {
        public object Execute(ICodeNode node)
        {
            var statementExecutor = new StatementExecutor();
            foreach (var item in node.Children)
            {
                 statementExecutor.Execute(item);
            }
            return null;
        }
    }
}
