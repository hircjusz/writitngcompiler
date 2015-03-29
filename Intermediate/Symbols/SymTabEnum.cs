using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermediate.Symbols
{
    public enum SymTabEnum 
    {
        // Constant.
        CONSTANT_VALUE,
        // Procedure or function.
        ROUTINE_CODE, ROUTINE_SYMTAB, ROUTINE_ICODE,
        ROUTINE_PARMS, ROUTINE_ROUTINES,

        // Variable or record field value.
        DATA_VALUE

    }


}
