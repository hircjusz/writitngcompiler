using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intermediate.Code;
using Intermediate.Symbols;

namespace Backend.Interpreter
{
    public class ExpressionExecutor : IExecutor
    {
        public object Execute(ICodeNode node)
        {
            switch (node.Type)
            {
                case CodeNodeTypeEnum.VARIABLE:
                    var entry = node.GetAttribute(CodeKeyEnum.ID) as SymTabEntry;
                    return entry.GetAttribute(SymTabEnum.DATA_VALUE);
                case CodeNodeTypeEnum.INTEGER_CONSTANT:
                    return (int)node.GetAttribute(CodeKeyEnum.VALUE);
                case CodeNodeTypeEnum.REAL_CONSTANT:
                    return (decimal)node.GetAttribute(CodeKeyEnum.VALUE);
                case CodeNodeTypeEnum.STRING_CONSTANT:
                    return (string)node.GetAttribute(CodeKeyEnum.VALUE);
                case CodeNodeTypeEnum.NEGATE:
                    {
                        var children = node.Children[0];
                        var value = Execute(children);
                        if (value is int)
                        {
                            return -(int)(value);
                        }
                        else
                        {
                            return -(double)(value);
                        }

                    }
                default:
                    return executeBinaryOperator(node);
            }
            return null;
        }


        private object executeBinaryOperator(ICodeNode node)
        {
            //uruchomic Binary operator
            return null;
        }
    }
}
