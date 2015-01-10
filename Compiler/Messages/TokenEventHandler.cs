using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Compiler.Messages
{
    public class TokenEventHandler : MessageHandler
    {
        public override void HandleMessage(object o, Message args)
        {
            if (args.messageType != MessageType.TOKEN) return;

            var token = args.obj as Token;

            if (token is EolToken) {
                Console.WriteLine();
            
            }
            Console.WriteLine(string.Format("{0}  {1} {2}", token.Type.GetTokenName(),token.Text,token.Value));
            
            Console.Write(" ");
        }

    }
}
