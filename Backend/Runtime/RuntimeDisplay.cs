using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Runtime
{
    public class RuntimeDisplay: IRuntimeDisplay
    {
        public ActivationRecord GetActivationRecord()
        {
            throw new NotImplementedException();
        }

        public void CallUpdate()
        {
            throw new NotImplementedException();
        }

        public void ReturnUpdate()
        {
            throw new NotImplementedException();
        }
    }

    public interface IRuntimeDisplay
    {
        ActivationRecord GetActivationRecord();
        void CallUpdate();

        void ReturnUpdate();

    }

}
