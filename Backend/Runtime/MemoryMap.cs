using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intermediate.Symbols;

namespace Backend.Runtime
{
    public class MemoryMap: IMemoryMap
    {
        private ISymTab symTab;

        public MemoryMap(ISymTab symTab)
        {
            this.symTab = symTab;
        }

        public Cell GetCell(string name)
        {
            throw new NotImplementedException();
        }

        public List<string> GetAllNames()
        {
            throw new NotImplementedException();
        }
    }

    public interface IMemoryMap
    {
        Cell GetCell(string name);
        List<string> GetAllNames();
    }
}
