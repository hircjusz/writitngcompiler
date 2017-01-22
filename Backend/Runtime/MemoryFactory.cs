using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intermediate.Symbols;

namespace Backend.Runtime
{
    public class MemoryFactory
    {

        public static IRuntimeStack CreateRuntimeStack()
        {
            return new RuntimeStack();
        }

        public static IRuntimeDisplay CreateRuntimeDisplay()
        {
            return  new RuntimeDisplay();
        }

        public static ActivationRecord CreateActivationRecord(SymTabEntry routineId)
        {
            return new ActivationRecord(routineId);
        }

        public static IMemoryMap CreaMemoryMap(ISymTab symTab)
        {
            return new MemoryMap(symTab);
        }

        public static Cell CreateCell(Object value)
        {
            return new Cell(value);
        }


    }

   
}
