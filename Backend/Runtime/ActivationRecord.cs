using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intermediate.Symbols;

namespace Backend.Runtime
{
    public class ActivationRecord: IActivationRecord
    {
        private readonly ISymTabEntry routineId;
        private IActivationRecord _link;
        private readonly int nestingLevel;
        private readonly IMemoryMap memoryMap;


        public ActivationRecord(SymTabEntry routineId)
        {
            var symTab = routineId.GetAttribute(SymTabEnum.ROUTINE_SYMTAB) as ISymTab;
            this.routineId = routineId;
            this.nestingLevel = symTab.GetNestingLevel();
            this.memoryMap = MemoryFactory.CreaMemoryMap(symTab);
            this.routineId = routineId;
        }


        public ISymTabEntry GetRoutineId()
        {
            return routineId;
        }

        public ICell GetCell(string name)
        {
            return memoryMap.GetCell(name);
        }

        public List<string> GetAllNames()
        {
            return memoryMap.GetAllNames();
        }

        public int GetNestingLevel()
        {
            return nestingLevel;
        }

        public IActivationRecord LinkedTo()
        {
            return _link;
        }

        public IActivationRecord MakeLinkTo(IActivationRecord ar)
        {
            _link = ar;
            return this;
        }
    }

    public interface IActivationRecord
    {
        ISymTabEntry GetRoutineId();

        ICell GetCell(string name);
        List<string> GetAllNames();

        int GetNestingLevel();

        IActivationRecord LinkedTo();

        IActivationRecord MakeLinkTo(IActivationRecord ar);

    }
}
