using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermediate.Symbols
{
    public class SymTabEntry : Dictionary<SymTabEnum, object>, ISymTabEntry
    {
        private string name;
        private ISymTab symTab;
        private IList<int> lineNumbers;

        public SymTabEntry(string name, ISymTab symTab)
        {
            this.name = name;
            this.symTab = symTab;
            lineNumbers = new List<int>();
        }

        public string GetName()
        {
            return name;
        }

        public ISymTab GetSymTab()
        {
            return symTab;
        }

        public void AppendLineNumber(int lineNumber)
        {
            lineNumbers.Add(lineNumber);
        }

        public IList<int> GetLineNumbers()
        {
            return lineNumbers;
        }

        public void SetAttribute(SymTabEnum key, object value)
        {
            if (!this.ContainsKey(key))
            {
                Add(key, value);
            }
            else
            {
                this[key] = value;
            }
        }

        public object GetAttribute(SymTabEnum key)
        {
            return this[key];
        }
    }

    public interface ISymTabEntry
    {
        /**
    * Getter.
    * @return the name of the entry.
    */
        String GetName();

        /**
         * Getter.
         * @return the symbol table that contains this entry.
         */
        ISymTab GetSymTab();

        /**
         * Append a source line number to the entry.
         * @param lineNumber the line number to append.
         */
        void AppendLineNumber(int lineNumber);

        /**
         * Getter.
         * @return the list of source line numbers.
         */
        IList<int> GetLineNumbers();

        /**
         * Set an attribute of the entry.
         * @param key the attribute key.
         * @param value the attribute value.
         */
        void SetAttribute(SymTabEnum key, Object value);

        Object GetAttribute(SymTabEnum key);

    }
}
