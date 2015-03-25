using System;
using System.Collections.Generic;

namespace Intermediate.Symbols
{

    public class SymTab : ISymTab
    {
        public int GetNestingLevel()
        {
            throw new NotImplementedException();
        }

        public SymTabEntry Enter(string name)
        {
            throw new NotImplementedException();
        }

        public SymTabEntry Lookup(string name)
        {
            throw new NotImplementedException();
        }

        public IList<SymTabEntry> SortedEntries()
        {
            throw new NotImplementedException();
        }
    }

    public interface ISymTab
    {

        /**
    * Getter.
    * @return the scope nesting level of this entry.
    */
        int GetNestingLevel();

        /**
         * Create and enter a new entry into the symbol table.
         * @param name the name of the entry.
         * @return the new entry.
         */
        SymTabEntry Enter(String name);

        /**
         * Look up an existing symbol table entry.
         * @param name the name of the entry.
         * @return the entry, or null if it does not exist.
         */
        SymTabEntry Lookup(String name);

        /**
         * @return a list of symbol table entries sorted by name.
         */
        IList<SymTabEntry> SortedEntries();
    }
}
