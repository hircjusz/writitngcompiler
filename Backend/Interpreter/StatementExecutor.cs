using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intermediate.Code;

namespace Backend.Interpreter
{
    public class StatementExecutor:IExecutor
    {
        public object Execute(ICodeNode node)
        {
            var nodeType=node.Type;

            switch (nodeType)
            {
                 case CodeNodeTypeEnum.COMPOUND:
                    var compoundExecutor = new CompoundExecutor();
                    return compoundExecutor.Execute(node);
                    break;
                case CodeNodeTypeEnum.ASSIGN:
                    var assignmentExecutor = new AssignmentExecutor();
                    return assignmentExecutor.Execute(node);
                    break;
            }
            return null;

        }
    }
}
