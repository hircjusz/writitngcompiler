using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Runtime
{
    public class RuntimeStack: List<ActivationRecord>,IRuntimeStack
    {
        public List<ActivationRecord> Records()
        {
            throw new NotImplementedException();
        }

        public ActivationRecord GetTopMost(int nestingLevel)
        {
            throw new NotImplementedException();
        }

        public int CurrentNestingLevel()
        {
            throw new NotImplementedException();
        }

        public void Pop()
        {
            throw new NotImplementedException();
        }

        public void Push(ActivationRecord activationRecord)
        {
            throw new NotImplementedException();
        }
    }

    public interface IRuntimeStack
    {
        /// <summary>
        /// returns list of activations records on the stack
        /// </summary>
        /// <returns></returns>
        List<ActivationRecord> Records();

        /// <summary>
        /// return the activation record on nesting level
        /// </summary>
        /// <returns></returns>
        ActivationRecord GetTopMost(int nestingLevel);

        int CurrentNestingLevel();

        /// <summary>
        /// Pop record from the stack
        /// </summary>
        void Pop();

        /// <summary>
        /// wkłada rekord na stos
        /// </summary>
        void Push(ActivationRecord activationRecord);

    }

}
