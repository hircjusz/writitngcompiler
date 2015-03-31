using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler.Messages;

namespace Compiler
{
    public class Scanner
    {

         protected Source source = null;

         //#region Events

        //public event EventHandler<MessageType> MessageEvents;

        //protected void OnMessage(MessageType message) {
        //    if (MessageEvents != null) {
        //        MessageEvents(this, message);
        //    }
        //}

        //#endregion

        public Scanner(Source source) {
            this.source = source;
        
        }


        
        public virtual Token currentToken() {
            var token = new Token(source);
            return token;
        }

        public virtual Token nextToken() {
            var token = new Token(source);
            return token;
        }

        public virtual Token extractToken() {
            var token = new Token(source);
            return token;
        }
        
        public virtual char currentChar() {
            return source.NextChar();
        }

        public virtual char peekChar()
        {
            return source.PeekCurrentChar();
        }

        public virtual char nextChar() {
            return 'a';
        }



    }
}
