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
                    return (double)node.GetAttribute(CodeKeyEnum.VALUE);
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
                    return ExecuteBinaryOperator(node);
            }
            return null;
        }


        private object ExecuteBinaryOperator(ICodeNode node)
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
                        case CodeNodeTypeEnum.ADD:
                            return value1 + value2;
                        case CodeNodeTypeEnum.SUBTRACT:
                            return value1 - value2;
                        case CodeNodeTypeEnum.MULTIPLY:
                            return value1*value2;
                        case CodeNodeTypeEnum.FLOAT_DIVIDE:
                        {
                            if (value2 != 0)
                            {
                                return (double) (value1)/(double) (value2);
                            }
                            else
                            {
                                throw new Exception("Niepoprawna wartość, dzielenie przez 0");
                            }
                        }
                        case CodeNodeTypeEnum.INTEGER_DIVIDE:
                        {
                            if (value2 != 0)
                            {
                                return value1/value2;
                            }
                            else
                            {
                                throw new Exception("Dzielenie przez 0");
                            }

                        }
                        case CodeNodeTypeEnum.MOD:
                        {
                            if (value2 != 0)
                            {
                                return value1%value2;
                            }
                            else
                            {
                                throw new Exception("Dzielenie przez 0");
                            }
                        }
                    }

                }
                else
                {
                    double value1 = Convert.ToDouble(operand1);
                    double value2 = Convert.ToDouble(operand2);

                    switch (nodeType)
                    {
                        case CodeNodeTypeEnum.ADD:
                            return value1 + value2;
                        case CodeNodeTypeEnum.SUBTRACT:
                            return value1 - value2;
                        case CodeNodeTypeEnum.MULTIPLY:
                            return value1*value2;
                        case CodeNodeTypeEnum.FLOAT_DIVIDE:
                        {
                            if (value2 != 0)
                            {
                                return (double) (value1)/(double) (value2);
                            }
                            else
                            {
                                throw new Exception("Niepoprawna wartość, dzielenie przez 0");
                            }
                        }
                    }
                }
            }else if (nodeType == CodeNodeTypeEnum.AND || nodeType == CodeNodeTypeEnum.OR)
            {
                bool value1 = (bool) operand1;
                bool value2 = (bool) operand2;
                switch (nodeType)
                {
                    case CodeNodeTypeEnum.AND:
                        return value1 && value2;
                    case CodeNodeTypeEnum.OR:
                        return value1 || value2;
                }
            }
            else
            {
                if (integerMode)
                {
                    var value1 = (int)operand1;
                    var value2 = (int) operand2;

                    switch (nodeType)
                    {
                        case CodeNodeTypeEnum.EQ:
                            return value1 == value2;
                        case CodeNodeTypeEnum.NE:
                            return value1 != value2;
                        case CodeNodeTypeEnum.LE:
                            return value1 <= value2;
                        case CodeNodeTypeEnum.LT:
                            return value1 < value2;
                        case CodeNodeTypeEnum.GE:
                            return value1 >= value2;
                        case CodeNodeTypeEnum.GT:
                            return value1 > value2; 
                    }

                }
                else
                {
                    var value1 = (double)operand1;
                    var value2 = (double)operand2;

                    switch (nodeType)
                    {
                        case CodeNodeTypeEnum.EQ:
                            return Math.Abs(value1 - value2) < 0.0000001;
                        case CodeNodeTypeEnum.NE:
                            return Math.Abs(value1 - value2) > 0.0000001;
                        case CodeNodeTypeEnum.LE:
                            return value1 <= value2;
                        case CodeNodeTypeEnum.LT:
                            return value1 < value2;
                        case CodeNodeTypeEnum.GE:
                            return value1 >= value2;
                        case CodeNodeTypeEnum.GT:
                            return value1 > value2;
                    }
                }


            }

            return null;
        }
    }
}
