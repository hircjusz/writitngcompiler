using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Messages
{
    public class LoggerEventHandler : MessageHandler
    {
        public override void HandleMessage(object o, Message args)
        {
            if (args.text == Convert.ToString(Source.EOL))
            {
                Console.WriteLine();
            }
            else
            {
                Console.Write(args.text);
            }
        }
    }
}
