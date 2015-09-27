using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intermediate.Code;

namespace Backend.Interpreter
{
    public class LoopExecutor:IExecutor
    {
        public object Execute(ICodeNode node)
        {
            bool exitLoop = false;
            int executionCount = 0;
            ICodeNode exprNode = null;

            var expressionExecutor = new ExpressionExecutor();
            var statementExecutor = new StatementExecutor();

            while (!exitLoop)
            {
                executionCount++;
                foreach (var item in node.Children)
                {
                    var nodeType= item.Type;
                    if (nodeType == CodeNodeTypeEnum.TEST)
                    {
                        if (exprNode == null)
                        {
                            exprNode = item.Children[0];
                        }
                        exitLoop = (bool) expressionExecutor.Execute(exprNode);
                    }
                    else
                    {
                        statementExecutor.Execute(item);
                    }
                }

                if (exitLoop)
                {
                    break;
                }
            }
            return null;
        }
    }
}
