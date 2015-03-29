using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermediate.Symbols
{
    public static class SymTabFactory
    {

        public static ISymTabStack CreateSymTabStack()
        {
            return new SymTabStack();
        }

        public static ISymTabStack CreateSymTabStack(int nestingLevel)
        {
            return new SymTabStack(nestingLevel);
        }

        public static ISymTab CreateSymTab(int nestingLevel)
        {
            return new SymTab(nestingLevel);
        }

    }
}
