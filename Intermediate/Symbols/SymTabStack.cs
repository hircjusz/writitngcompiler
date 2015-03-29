using System;
using System.Collections;
using System.Collections.Generic;

namespace Intermediate.Symbols
{
    public class SymTabStack :List<ISymTab>, ISymTabStack
    {
        public SymTabStack(int currentNestingLevel)
        {
            this._currentNestingLevel = currentNestingLevel;
            Add(SymTabFactory.CreateSymTab(_currentNestingLevel));
        }
        public SymTabStack()
        {
            this._currentNestingLevel = 0;
            Add(SymTabFactory.CreateSymTab(_currentNestingLevel));

        }

        public int _currentNestingLevel;

        public ISymTab GetLocalSymTab()
        {
            return this[_currentNestingLevel];
        }

        public ISymTabEntry EnterLocal(string name)
        {
            return this[_currentNestingLevel].Enter(name);
        }

        public ISymTabEntry LookupLocal(string name)
        {
            return this[_currentNestingLevel].Lookup(name);
        }

        public ISymTabEntry Lookup(string name)
        {
            return LookupLocal(name);
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
         ISymTab GetLocalSymTab();

         /**
          * Create and enter a new entry into the local symbol table.
          * @param name the name of the entry.
          * @return the new entry.
          */
        ISymTabEntry EnterLocal(String name);

        /**
         * Look up an existing symbol table entry in the local symbol table.
         * @param name the name of the entry.
         * @return the entry, or null if it does not exist.
         */
        ISymTabEntry LookupLocal(String name);

        /**
         * Look up an existing symbol table entry throughout the stack.
         * @param name the name of the entry.
         * @return the entry, or null if it does not exist.
         */
        ISymTabEntry Lookup(String name);

    }
}
