using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermediate.Symbols
{
    public class SymTabEntry : ISymTabEntry
    {
        public string GetName()
        {
            throw new NotImplementedException();
        }

        public ISymTab GetSymTab()
        {
            throw new NotImplementedException();
        }

        public void AppendLineNumber(int lineNumber)
        {
            throw new NotImplementedException();
        }

        public IList<int> GetLineNumbers()
        {
            throw new NotImplementedException();
        }

        public void SetAttribute(ISymTabKey key, object value)
        {
            throw new NotImplementedException();
        }

        public object GetAttribute(ISymTabKey key)
        {
            throw new NotImplementedException();
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
         void SetAttribute(ISymTabKey key, Object value);

        Object GetAttribute(ISymTabKey key);

    }
}
