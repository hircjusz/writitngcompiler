using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Messages
{
    public abstract class MessageHandler
    {
        public abstract void HandleMessage(object o, Message args );

        public abstract Message[] GetMessages();
    }
}
