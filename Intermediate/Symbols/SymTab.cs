using System;
using System.Collections.Generic;
using System.Linq;

namespace Intermediate.Symbols
{

    public class SymTab : Dictionary<string, ISymTabEntry>, ISymTab
    {
        private int _currentNestingLevel;

        public SymTab()
        {
        }

        public SymTab(int nestingLevel)
        {
            _currentNestingLevel = nestingLevel;
        }

        public int GetNestingLevel()
        {
            throw new NotImplementedException();
        }

        public ISymTabEntry Enter(string name)
        {
            var netry = SymTabFactory.CreateSymTabEntry(name, this);
            Add(name, netry);
            return netry;
        }

        public ISymTabEntry Lookup(string name)
        {
            return this.FirstOrDefault(t => t.Key == name).Value;
        }

        public IList<ISymTabEntry> SortedEntries()
        {
            return this.OrderBy(t => t.Key).Select(t=>t.Value).ToList();
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
        ISymTabEntry Enter(String name);

        /**
         * Look up an existing symbol table entry.
         * @param name the name of the entry.
         * @return the entry, or null if it does not exist.
         */
        ISymTabEntry Lookup(String name);

        /**
         * @return a list of symbol table entries sorted by name.
         */
        IList<ISymTabEntry> SortedEntries();
    }
}
