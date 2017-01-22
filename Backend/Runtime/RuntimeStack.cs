using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Runtime
{
    public class RuntimeStack : List<IActivationRecord>, IRuntimeStack
    {

        private IRuntimeDisplay display;

        public RuntimeStack()
        {
            display = MemoryFactory.CreateRuntimeDisplay();
        }

        public List<IActivationRecord> Records()
        {
            return this;
        }

        public IActivationRecord GetTopMost(int nestingLevel)
        {
            return display.GetActivationRecord(nestingLevel);

        }

        public int CurrentNestingLevel()
        {
            int topIndex = Count - 1;
            return topIndex >= 0 ? this[topIndex].GetNestingLevel() : -1;

        }

        public void Pop()
        {
           display.ReturnUpdate(this.CurrentNestingLevel());
            RemoveAt(Count-1);
        }

        public void Push(IActivationRecord activationRecord)
        {
            var nestingLevel = activationRecord.GetNestingLevel();
            Add(activationRecord);
            display.CallUpdate(nestingLevel,activationRecord);
        }
    }

    public interface IRuntimeStack
    {
        /// <summary>
        /// returns list of activations records on the stack
        /// </summary>
        /// <returns></returns>
        List<IActivationRecord> Records();

        /// <summary>
        /// return the activation record on nesting level
        /// </summary>
        /// <returns></returns>
        IActivationRecord GetTopMost(int nestingLevel);

        int CurrentNestingLevel();

        /// <summary>
        /// Pop record from the stack
        /// </summary>
        void Pop();

        /// <summary>
        /// wkłada rekord na stos
        /// </summary>
        void Push(IActivationRecord activationRecord);

    }

}
