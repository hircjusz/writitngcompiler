using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Runtime
{
    public class RuntimeDisplay : List<IActivationRecord>, IRuntimeDisplay
    {
        public RuntimeDisplay()
        {
            this.Add(null);
        }

        public IActivationRecord GetActivationRecord(int nestingLevel)
        {
            return this[nestingLevel];
        }

        public void CallUpdate(int nestingLevel, IActivationRecord activationRecord)
        {
            if (nestingLevel >= Count)
            {
                Add(activationRecord);
            }
            else
            {
                var prevAr = this[nestingLevel];
                this[nestingLevel] = activationRecord.MakeLinkTo(prevAr);
            }
        }

        public void ReturnUpdate(int nestingLevel)
        {
            int topIndex = Count - 1;
            var ar = this[nestingLevel];
            var prevAr = ar.LinkedTo();
            if (prevAr != null)
            {
                this[nestingLevel] = prevAr;
            }
            else if (nestingLevel == topIndex)
            {
                RemoveAt(topIndex);
            }
        }
    }

    public interface IRuntimeDisplay
    {
        IActivationRecord GetActivationRecord(int nestingLevel);
        void CallUpdate(int nestingLevel, IActivationRecord activationRecord);

        void ReturnUpdate(int nestingLevel);

    }

}
