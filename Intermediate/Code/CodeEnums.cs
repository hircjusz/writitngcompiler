using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermediate.Code
{
     public enum  CodeNodeTypeEnum
    {
        PROGRAM, PROCEDURE, FUNCTION,

        // Statements
        COMPOUND, ASSIGN, LOOP, TEST, CALL, PARAMETERS,
        IF, SELECT, SELECT_BRANCH, SELECT_CONSTANTS, NO_OP,

        // Relational operators
        EQ, NE, LT, LE, GT, GE, NOT,

        // Additive operators
        ADD, SUBTRACT, OR, NEGATE,

        // Multiplicative operators
        MULTIPLY, INTEGER_DIVIDE, FLOAT_DIVIDE, MOD, AND,

        // Operands
        VARIABLE, SUBSCRIPTS, FIELD,
        INTEGER_CONSTANT, REAL_CONSTANT,
        STRING_CONSTANT, BOOLEAN_CONSTANT

    }

    public enum CodeKeyEnum
    {
        LINE, 
        ID,
        VALUE
    }

}
