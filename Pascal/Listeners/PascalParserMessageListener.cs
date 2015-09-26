using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler.Messages;

namespace Pascal.Listeners
{
    public class PascalParserMessageListener : MessageHandler
    {
        private List<Message> messages= new List<Message>(); 

        public override void HandleMessage(object o, Message args)
        {
            messages.Add(args);
        }

        public override Message[] GetMessages()
        {
            return messages.ToArray();
        }
    }
}
