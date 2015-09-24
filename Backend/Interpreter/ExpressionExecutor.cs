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
        private IList<CodeNodeTypeEnum> _arithmeticOperations= new List<CodeNodeTypeEnum>()
        {
            CodeNodeTypeEnum.ADD,CodeNodeTypeEnum.SUBTRACT,CodeNodeTypeEnum.MULTIPLY,CodeNodeTypeEnum.FLOAT_DIVIDE,
            CodeNodeTypeEnum.INTEGER_DIVIDE
        }; 

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
                        return -(double)(value);
                    }
                default:
                    return executeBinaryOperator(node);
            }
            return null;
        }


        private object executeBinaryOperator(ICodeNode node)
        {
            var operandNode1 = node.Children[0];
            var operandNode2 = node.Children[1];

            Object operand1 = Execute(operandNode1);
            Object operand2 = Execute(operandNode2);
            bool integerMode = operand1 is int && operand2 is int;


            var nodeType = node.Type;

            if (_arithmeticOperations.Contains(nodeType))
            {
                if (integerMode)
                {
                    var value1 = (int) operand1;
                    var value2 = (int) operand2;
                    switch (nodeType)
                    {
                        case CodeNodeTypeEnum.ADD: return value1 + value2;
                        case CodeNodeTypeEnum.SUBTRACT: return value1 - value2;
                        case CodeNodeTypeEnum.MULTIPLY: return value1 * value2;
                    }

                }



            }

            //uruchomic Binary operator
            return null;
        }
    }
}
