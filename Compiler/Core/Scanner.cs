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

        #region Events
        
        public event EventHandler<Messages.MessageType> MessageEvents;

        protected void OnMessage(MessageType message) {

            if (MessageEvents != null) {
                MessageEvents(this, message);
            }
        
        }

        #endregion


        public Token currentToken() {
            var token = new Token();
            OnMessage(new MessageType("Token"));
            return token;
        }

        public Token nextToken() {

            return new Token();
        }

        protected Token extractToken() {

            return new Token();
        }
        
        public char currentChar() {

            return 'a';
        }

        public char nextChar() {

            return 'b';
        }



    }
}
