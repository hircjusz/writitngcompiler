using System;

namespace Intermediate.Symbols
{
    public class SymTabStack : ISymTabStack
    {
        public SymTab GetLocalSymTab()
        {
            throw new NotImplementedException();
        }

        public SymTabEntry EnterLocal(string name)
        {
            throw new NotImplementedException();
        }

        public SymTabEntry LookupLocal(string name)
        {
            throw new NotImplementedException();
        }

        public SymTabEntry Lookup(string name)
        {
            throw new NotImplementedException();
        }
    }

    public interface ISymTabStack
    {
        /**
    * Getter.
    * @return the current nesting level.
    */
        //public int getCurrentNestingLevel();

        /**
         * Return the local symbol table which is at the top of the stack.
         * @return the local symbol table.
         */
         SymTab GetLocalSymTab();

         /**
          * Create and enter a new entry into the local symbol table.
          * @param name the name of the entry.
          * @return the new entry.
          */
        SymTabEntry EnterLocal(String name);

        /**
         * Look up an existing symbol table entry in the local symbol table.
         * @param name the name of the entry.
         * @return the entry, or null if it does not exist.
         */
        SymTabEntry LookupLocal(String name);

        /**
         * Look up an existing symbol table entry throughout the stack.
         * @param name the name of the entry.
         * @return the entry, or null if it does not exist.
         */
        SymTabEntry Lookup(String name);

    }
}
