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

        #region
         protected Source source = null;


        #endregion

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
            var token = new Token();
            //OnMessage(new MessageType("Token"));
            return token;
        }

        public virtual Token nextToken() {
            return new Token();
        }

        protected virtual Token extractToken() {
            return new Token();
        }
        
        public virtual char currentChar() {
            return source.CurrentChar();
        }

        public virtual char nextChar() {
            return 'a';
        }



    }
}
