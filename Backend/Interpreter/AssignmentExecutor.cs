using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intermediate.Code;
using Intermediate.Symbols;

namespace Backend.Interpreter
{
    public class AssignmentExecutor : IExecutor
    {
        public object Execute(ICodeNode node)
        {
            var variableNode = node.Children[0];
            var expressionNode = node.Children[1];

            var expressionExecutor = new ExpressionExecutor();
            Object value = expressionExecutor.Execute(expressionNode);

            var symTabEntry = variableNode.GetAttribute(CodeKeyEnum.ID) as SymTabEntry;
            symTabEntry.SetAttribute(SymTabEnum.DATA_VALUE, value);

            //TODO send Message
            return null;
        }
    }
}
