using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using Intermediate.Symbols;
using Intermediate.Type;

namespace Backend.Runtime
{
    public class MemoryMap: Dictionary<String,ICell>,IMemoryMap
    {
        private ISymTab _symTab;

        public MemoryMap(ISymTab symTab)
        {
            this._symTab = symTab;
            var entries=symTab.SortedEntries();

            foreach (var entry in entries)
            {
               var defn= entry.GetDefinition();
                if (defn.GetDef() == DefinitionEnum.VARIABLE || defn.GetDef() == DefinitionEnum.FUNCTION ||
                    defn.GetDef() == DefinitionEnum.VALUE_PARAM || defn.GetDef() == DefinitionEnum.FIELD)
                {
                    var name = entry.GetName();
                    var type = entry.GetTypeSpec();
                  this.Add(name,MemoryFactory.CreateCell(AllocateCellValue(type)));
                }else if (defn.GetDef() == DefinitionEnum.VAR_PARAM)
                {
                    var name = entry.GetName();
                    this.Add(name,MemoryFactory.CreateCell(null));
                }
            }


        }

        private Object AllocateCellValue(ITypeSpec typeSpec)
        {
            var typeForm = typeSpec.GetForm();
            switch (typeForm)
            {
                    case TypeFormEnum.ARRAY:
                    return AllocateArrayCells(typeSpec);
                    case TypeFormEnum.RECORD:
                    return AllocateRecordMap(typeSpec);
                default:
                {
                    return null;
                }
            }
        }

        private Cell[] AllocateArrayCells(ITypeSpec typeSpec)
        {
            int elmCount = (int)typeSpec.GetAttribute(TypeKeyEnum.ARRAY_ELEMENT_COUNT);
            var emtType = (ITypeSpec)typeSpec.GetAttribute(TypeKeyEnum.ARRAY_ELEMENT_TYPE);
            Cell[] allocation= new Cell[elmCount];
            for (int i = 0; i < elmCount; i++)
            {
                allocation[i] = MemoryFactory.CreateCell(AllocateCellValue(emtType));
            }
            return allocation;
        }

        private IMemoryMap AllocateRecordMap(ITypeSpec typeSpec)
        {
            var attribute = (ISymTab)typeSpec.GetAttribute(TypeKeyEnum.RECORD_SYMTAB);
            var memoryMap = MemoryFactory.CreaMemoryMap(attribute);
            return memoryMap;
        }


        public ICell GetCell(string name)
        {
            return this[name];
        }

        public List<string> GetAllNames()
        {
            return this.Keys.ToList();
        }
    }

    public interface IMemoryMap
    {
        ICell GetCell(string name);
        List<string> GetAllNames();
    }
}
